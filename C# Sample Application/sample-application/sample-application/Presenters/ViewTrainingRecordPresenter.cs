using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class ViewTrainingRecordPresenter
    {
        private Dictionary<int, Training> trainingMap;
        private ITrainingRecordViewer view;

        public ViewTrainingRecordPresenter(ITrainingRecordViewer view)
        {
            this.view = view;
            view.Presenter = this;
            InitForm();
        }

        public ViewTrainingRecordPresenter(ITrainingRecordViewer view, ViewType type)
        {
            this.view = view;
            view.Presenter = this;
            view.ViewBy = type;
            InitForm();
        }

        public void InitForm()
        {
            view.SetFormLayout();
        }

        //loaded once when the form is shown. Used for efficient lookups of trainings while filling tables
        public async Task LoadTrainingMap()
        {
            trainingMap = await Training.GetTrainingIdMap();
        }

        #region Methods For Displaying Training Records
        public async Task<bool> ShowSelectedView()
        {
            if (InputsAreValid())
            {
                switch (view.SelectedView)
                {
                    case "Past Due Trainings":
                        await ShowPastDue();
                        break;
                    case "Upcoming Trainings":
                        await ShowUpcoming();
                        break;
                    case "Completed Trainings":
                        await ShowCompleted();
                        break;
                }
                
                return true;
            }
            return false;
        }

        /// <summary>
        /// Shows the Past Due required trainings
        /// </summary>
        private async Task ShowPastDue()
        {
            DataTable table = GetBlankRequiredTrainingTable();
            if (view.ViewBy == ViewType.Employee)
                await FillPastDue(table, await GetSelectedEmployees());
            else
                await FillPastDueDepartment(table);

            view.TrainingRecord = table;
        }
        
        /// <summary>
        /// Shows the Upcoming required trainings
        /// </summary>
        private async Task ShowUpcoming()
        {
            DataTable table = GetBlankRequiredTrainingTable();
            if (view.ViewBy == ViewType.Employee)
                await FillUpcoming(table, await GetSelectedEmployees());
            else
                await FillUpcomingDepartment(table);
            view.TrainingRecord = table;
        }

        /// <summary>
        /// Shows all completed trainings (required and non required) including expired trainings
        /// </summary>
        private async Task ShowCompleted()
        {
            DataTable table = GetBlankCompletedTrainingTable();
            if (view.ViewBy == ViewType.Employee)
                await FillCompleted(table, await GetSelectedEmployees());
            else
                await FillCompletedDepartment(table);

            view.TrainingRecord = table;
        }

        private DataTable GetBlankRequiredTrainingTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Expires", typeof(DateTime));
            table.Columns.Add("Employee", typeof(string));
            table.Columns.Add("Training Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Revision", typeof(double));
            table.Columns.Add("Date Completed", typeof(DateTime));
            return table;
        }

        private DataTable GetBlankCompletedTrainingTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Expires", typeof(DateTime));
            table.Columns.Add("Required", typeof(string));
            table.Columns.Add("Employee", typeof(string));
            table.Columns.Add("Training Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Revision", typeof(double));
            table.Columns.Add("Date Completed", typeof(DateTime));
            return table;
        }

        private async Task FillPastDue(DataTable table, List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Dictionary<int, string> requiredTrainings = await employee.GetRequiredTrainings();
                Dictionary<int, string> completedTrainings = await employee.GetCompletedTrainings();

                foreach (int trainingId in requiredTrainings.Keys)
                {
                    Training training = await Training.GetTraining(trainingId);
                    string dueDate = requiredTrainings[trainingId];
                    DateTime dueDateTime = DateFunctions.DateStringToDateTime(dueDate);

                    if (IsPastDue(dueDate)) //if training is expired
                    {
                        DataRow row = table.NewRow();
                        row[0] = dueDateTime; row[1] = employee.Name; row[2] = training.Name; row[3] = training.Type; row[4] = training.Description; row[5] = training.Revision;
                        if (completedTrainings.ContainsKey(trainingId)) //if the training has been completed then add the completion date to the table
                            row[6] = DateFunctions.DateStringToDateTime(completedTrainings[trainingId]);
                        table.Rows.Add(row);
                    }
                }
            }
        }

        private async Task FillPastDueDepartment(DataTable table)
        {
            //Console.WriteLine("Start Time: " + DateTime.Now.ToString("HH:mm:ss:fff"));
            Department department = await Department.GetDepartment(view.SelectedDepartment);
            DataTable requiredTrainings = await department.GetRequiredTrainings();
            //Console.WriteLine("After Getting Trainings: " + DateTime.Now.ToString("HH:mm:ss:fff"));

            foreach (DataRow r in requiredTrainings.Rows)
            {
                object[] values = r.ItemArray;
                Employee employee = await Employee.GetEmployee((short)values[0]);
                Training training = await GetTraining((short)values[1]);
                string completionDate = values[2].GetType().Equals(typeof(DateTime)) ? ((DateTime)values[2]).ToShortDateString() : null;
                string dueDate = ((DateTime)values[3]).ToShortDateString();
                DateTime dueDateTime = DateFunctions.DateStringToDateTime(dueDate);

                if (IsPastDue(dueDate))
                {
                    DataRow row = table.NewRow();
                    row[0] = dueDateTime; row[1] = employee.Name; row[2] = training.Name; row[3] = training.Type; row[4] = training.Description; row[5] = training.Revision;
                    if (completionDate != null)
                        row[6] = completionDate;
                    table.Rows.Add(row);
                }
            }
            Console.WriteLine("After Filling Table: " + DateTime.Now.ToString("HH:mm:ss:fff"));
        }



        private async Task FillUpcoming(DataTable table, List<Employee> employees)
        {
            foreach(Employee employee in employees)
            {
                Dictionary<int, string> completedTrainings = await employee.GetCompletedTrainings();
                Dictionary<int, string> requiredTrainings = await employee.GetRequiredTrainings();

                foreach(int trainingId in requiredTrainings.Keys)
                {
                    Training training = await GetTraining(trainingId);
                    string dueDate = requiredTrainings[trainingId];
                    DateTime dueDateTime = DateFunctions.DateStringToDateTime(dueDate);

                    if(!IsPastDue(dueDate) && DateFunctions.CompareDates(dueDate, DateFunctions.IncrementDate(DateFunctions.GetCurrentDateString(), config.GUISettings.DashboardUpcomingLimit)) < 0) //if the due date is within x months
                    {
                        DataRow row = table.NewRow();
                        row[0] = dueDateTime; row[1] = employee.Name; row[2] = training.Name; row[3] = training.Type; row[4] = training.Description; row[5] = training.Revision;
                        if (completedTrainings.ContainsKey(trainingId))
                            row[6] = completedTrainings[trainingId];
                        table.Rows.Add(row);
                    }
                }
            }
        }

        private async Task FillUpcomingDepartment(DataTable table)
        {
            Department department = await Department.GetDepartment(view.SelectedDepartment);
            DataTable requiredTrainings = await department.GetRequiredTrainings();

            foreach(DataRow r in requiredTrainings.Rows)
            {
                object[] values = r.ItemArray;
                Employee employee = await Employee.GetEmployee((short)values[0]);
                Training training = await GetTraining((short)values[1]);
                string completionDate = values[2].GetType().Equals(typeof(DateTime)) ? ((DateTime)values[2]).ToShortDateString() : null;
                DateTime dueDateTime = (DateTime)values[3];
                string dueDate = dueDateTime.ToShortDateString();

                if (!IsPastDue(dueDate) && DateFunctions.CompareDates(dueDate, DateFunctions.IncrementDate(DateFunctions.GetCurrentDateString(), config.GUISettings.DashboardUpcomingLimit)) < 0) //if the due date is within x months
                {
                    DataRow row = table.NewRow();
                    row[0] = dueDateTime; row[1] = employee.Name; row[2] = training.Name; row[3] = training.Type; row[4] = training.Description; row[5] = training.Revision;
                    if (completionDate != null)
                        row[6] = completionDate;
                    table.Rows.Add(row);
                }
            }
        }

        private async Task FillCompleted(DataTable table, List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Dictionary<int, string> requiredTrainings = await employee.GetRequiredTrainings();
                Dictionary<int, string> completedTrainings = await employee.GetCompletedTrainings();
                Dictionary<int, string> assignedTrainings = await employee.GetAssignedTrainings();

                foreach(int trainingId in completedTrainings.Keys)
                {
                    Training training = await Training.GetTraining(trainingId);
                    DataRow row = table.NewRow();
                    
                    row[0] = assignedTrainings[trainingId];
                    row[1] = requiredTrainings.ContainsKey(trainingId) ? "Yes" : "No";
                    row[2] = employee.Name; row[3] = training.Name; row[4] = training.Type; row[5] = training.Description; row[6] = training.Revision; row[7] = completedTrainings[trainingId];
                    table.Rows.Add(row);
                }
            }
        }

        private async Task FillCompletedDepartment(DataTable table)
        {
            Console.WriteLine("Start Time: " + DateTime.Now.ToString("HH:mm:ss:fff"));
            Department department = await Department.GetDepartment(view.SelectedDepartment);
            DataTable completedTrainings = await department.GetCompletedTrainings();
            Console.WriteLine("After Getting Trainings: " + DateTime.Now.ToString("HH:mm:ss:fff"));

            foreach (DataRow r in completedTrainings.Rows)
            {
                object[] values = r.ItemArray;
                object completionDate = values[2];

                //if (completionDate is DateTime)
                //{
                    Employee employee = await Employee.GetEmployee((short)values[0]);
                    Training training = await GetTraining((short)values[1]);
                    DateTime dueDate = (DateTime)values[3];
                    string required = (bool)values[4]  ? "Yes" : "No";

                    DataRow row = table.NewRow();
                    row[0] = dueDate;
                    row[1] = required;
                    row[2] = employee.Name; row[3] = training.Name; row[4] = training.Type; row[5] = training.Description; row[6] = training.Revision; row[7] = completionDate;
                    table.Rows.Add(row);
                //}
            }

            Console.WriteLine("After Filling Table: " + DateTime.Now.ToString("HH:mm:ss:fff"));
        }

        private bool IsPastDue(string dueDate)
        {
            return DateFunctions.CompareDates(dueDate, DateFunctions.GetCurrentDateString()) < 0;
        }

        /// <summary>
        /// Gets a list of the user selected employees and loads their data
        /// </summary>
        /// <returns>a list of Employees selected by the user</returns>
        private async Task<List<Employee>> GetSelectedEmployees()
        {
            if (view.ViewBy == ViewType.Department)
            {
                Department department = await Department.GetDepartment(view.SelectedDepartment);
                return await department.GetEmployees();
            }
            else if (view.ViewBy == ViewType.Employee)
            {
                List<string> employeeStrings = view.SelectedEmployees;
                List<Employee> employees = new List<Employee>();

                List<Task> loadTasks = new List<Task>();
                foreach(string employeeStr in employeeStrings)
                {
                    Employee employee = await CommonFunctions.GetEmployeeFromSelection(employeeStr);
                    employees.Add(employee);
                }

                await Task.WhenAll(loadTasks);
                return employees;
            }

            //add any future view cases here
            return null;
        }

        #endregion

        private bool InputsAreValid()
        {
            bool validViewType = false;
            if(view.ViewBy == ViewType.Department)
            {
                validViewType = !string.IsNullOrWhiteSpace(view.SelectedDepartment);
            }
            else if(view.ViewBy == ViewType.Employee)
            {
                validViewType = view.SelectedEmployees.Count > 0;
            }
            return validViewType && !string.IsNullOrWhiteSpace(view.SelectedView);
        }

        private async Task<Training> GetTraining(int trainingId)
        {
            if (trainingMap.TryGetValue(trainingId, out Training training))
                return training;
            else
                return await Training.GetTraining(trainingId);
        }

    }
}
