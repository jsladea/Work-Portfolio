using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;
using sampleApp.DashChildForms.Popups;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class DepartmentViewPresenter
    {
        private IDepartmentView view;

        private Dictionary<int, List<int>> deptTrainingMap;
        private DataTable currDataSource;
        private bool exporting = false;

        public DepartmentViewPresenter(IDepartmentView deptView)
        {
            view = deptView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public void ShowAssignRequiredTrainingForm()
        {
            AssignTraining form = new AssignTraining();
            AssignTrainingPresenter presenter = new AssignTrainingPresenter(form);
            CommonFunctions.ShowAsModalPopup(form, System.Windows.Forms.FormBorderStyle.FixedToolWindow);
        }

        #region Data Display/Table Fill Methods Employee Trainings
        public async Task DisplayEmpData()
        {
            if (DepartmentIsSelected())
            {
                DataTable table = GetBlankTable();
                await FillEmpTable(table);
                view.EmpTrainingsData = table;
                currDataSource = table;
            }
        }

        public async Task ShowInDepth(string trainingName)
        {
            DataTable table = await GetInDepthData(await Training.GetTraining(trainingName));
            DeptTrainingPopup popup = new DeptTrainingPopup(view.Department, trainingName);
            popup.DisplayData(table);
            CommonFunctions.ShowAsModalPopup(popup, System.Windows.Forms.FormBorderStyle.SizableToolWindow);
        }

        private async Task<DataTable> GetInDepthData(Training training)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Priority", typeof(string));
            table.Columns.Add("Employees", typeof(string));

            await FillInDepthTable(table, training);

            return table;
        }

        private async Task FillInDepthTable(DataTable table, Training training)
        {
            List<int> employeeIds = deptTrainingMap[training.Id];
            StringBuilder pastBuilder = new StringBuilder();
            StringBuilder upcomingBuilder = new StringBuilder();

            string currDate = DateFunctions.GetCurrentDateString();
            foreach(int employeeId in employeeIds)
            {
                Employee employee = await Employee.GetEmployee(employeeId);
                string dueDate = await employee.GetDueDate(training);

                if (DateFunctions.CompareDates(dueDate, currDate) < 0)
                    pastBuilder.AppendLine(employee.Name);
                else if (DateFunctions.CompareDates(dueDate, DateFunctions.IncrementDate(currDate, config.GUISettings.DashboardUpcomingLimit)) < 0)
                    upcomingBuilder.AppendLine(employee.Name);
            }

            DataRow pastDueRow = table.NewRow();
            pastDueRow[0] = "Past Due";
            pastDueRow[1] = pastBuilder.ToString();
            table.Rows.Add(pastDueRow);

            DataRow upcomingRow = table.NewRow();
            upcomingRow[0] = "Upcoming";
            upcomingRow[1] = upcomingBuilder.ToString();
            table.Rows.Add(upcomingRow);
        }

        private DataTable GetBlankTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Training", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Required For", typeof(string));
            return table;
        }

        private async Task FillEmpTable(DataTable table)
        {
            await LoadDeptEmpTrainingMap();
            
            foreach(int trainingId in deptTrainingMap.Keys)
            {
                Training training = await Training.GetTraining(trainingId);
                DataRow row = table.NewRow();
                row[0] = training.Name; row[1] = training.Type; row[2] = training.Description;
                StringBuilder strBuilder = new StringBuilder();
                foreach (int employeeId in deptTrainingMap[trainingId])
                    strBuilder.AppendLine((await Employee.GetEmployee(employeeId)).Name);

                row[3] = strBuilder.ToString();
                table.Rows.Add(row);
            }

        }

        private async Task LoadDeptEmpTrainingMap()
        {
            Department dept = await Department.GetDepartment(view.Department);
            deptTrainingMap = await dept.GetDepartmentOverView();
        }

        private bool DepartmentIsSelected()
        {
            return !string.IsNullOrWhiteSpace(view.Department);   
        }

        #endregion

        #region Data Display/Table Fill Methods Department Trainings

        public async Task DisplayDeptData()
        {
            if (DepartmentIsSelected())
            {
                DataTable table = GetBlankDeptTable();
                await FillDeptTable(table);
                view.DeptTrainingsData = table;
            }
        }

        private DataTable GetBlankDeptTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("Assigned Trainings", typeof(string));
            table.Columns.Add("Employees", typeof(string));
            return table;
        }

        private async Task FillDeptTable(DataTable table)
        {
            Dictionary<string, string[]> deptTrainingMap = await GetDeptTrainingMap();

            foreach(string dept in deptTrainingMap.Keys)
            {
                DataRow row = table.NewRow();
                row[0] = dept;
                string[] arr = deptTrainingMap[dept];
                row[1] = arr[0];
                row[2] = arr[1];
                table.Rows.Add(row);
            }
        }

        private async Task<Dictionary<string,string[]>> GetDeptTrainingMap()
        {
            Dictionary<string, string[]> trainingMap = new Dictionary<string, string[]>();
            Department department = await Department.GetDepartment(view.Department);
            List<Department> departments = new List<Department>();
            departments.Add(department);
            departments.AddRange(await department.GetChildDepartments());
            await FillDeptTrainingDictionary(trainingMap, departments);
            return trainingMap;
        }

        private async Task FillDeptTrainingDictionary(Dictionary<string, string[]> dictionary, List<Department> departments)
        {
            int maxDescLength = 120;
            foreach (Department dept in departments)
            {
                List<Training> requiredTrainings = await dept.GetDeptAssignedTrainings(true);
                List<Training> optionalTrainings = await dept.GetDeptAssignedTrainings(false);
                List<Employee> deptEmployees = await dept.GetEmployees();
                StringBuilder trainings = new StringBuilder();
                StringBuilder employees = new StringBuilder();

                foreach (Training training in requiredTrainings)
                    trainings.AppendLine(training.Name + " (" + training.Revision + ") - " + (training.Description.Length > maxDescLength ? training.Description.Substring(0, maxDescLength) : training.Description) + " - Required");
                foreach (Training training in optionalTrainings)
                    trainings.AppendLine(training.Name + " (" + training.Revision + ") - " + (training.Description.Length > maxDescLength ? training.Description.Substring(0, maxDescLength) : training.Description));
                foreach (Employee employee in deptEmployees)
                    employees.AppendLine(employee.Name + (employee.JobTitle != null ? " - " + employee.JobTitle : ""));

                string[] arr = { trainings.ToString(), employees.ToString()};
                dictionary.Add(dept.Name, arr);
            }
        }

        #endregion

        public async Task<bool> Export(string directory)
        {
            if(currDataSource != null && !exporting)
            {
                exporting = true;
                string currTime = DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Trim();
                string filepath = directory + "/" + view.Department + "DepartmentOverview-" + currTime + ".csv";
                bool result = await CommonFunctions.ExportToExcel(currDataSource, filepath);
                exporting = false;
                return result;
            }
            return false;
        }

    }
}