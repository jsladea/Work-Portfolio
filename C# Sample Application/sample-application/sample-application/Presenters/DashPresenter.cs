using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common;
using sampleApp.DashChildForms;
using sampleApp.DashChildForms.Popups;
using sampleApp.Models;
using sampleApp.Views;
using static sampleApp.Models.Employee;

namespace sampleApp.Presenters
{
    public class DashPresenter
    {
        private IDashView dashView;
        private SQLDatabaseManager dbManager = new SQLDatabaseManager();


        public DashPresenter(IDashView dashboard)
        {
            this.dashView = dashboard;
        }

        
        /// <summary>
        /// Allows the user to log in to the application
        /// </summary>
        public void Login()
        {
            if (!ApplicationState.LoggedIn) //only display login form if the application isn't logged in
            {
                Form dashForm = (Form)dashView;

                dashForm.Enabled = false; //disable the dashboard form just in case
                dashForm.Hide(); //hide the dashboard

                Login loginForm = new Login();
                LoginPresenter loginPresenter = new LoginPresenter(loginForm);

                loginForm.ShowDialog(); //show the form as a modal form

                if (ApplicationState.LoggedIn) //if the login was successful, show the dashboard
                {
                    dashForm.Enabled = true;
                    dashView.SetFormLayout();
                    dashForm.Show();
                    dashView.CurrentUser = ApplicationState.CurrentUser.Name;
                }
                else
                {
                    dashForm.Close();
                }
            }

        }

        public async Task Logout()
        {
            await ApplicationState.Logout();
            DataTable emptyDueTable = GetBlankDueDataTable();
            dashView.UpcomingTrainings = emptyDueTable;
            dashView.PastDueTrainings = emptyDueTable;
            dashView.TrainingRecord = GetBlankRecordDataTable();
            Login();
        }

        

        #region EmployeeDashboard

        public async Task LoadEmployeeDashRecords()
        {
            DataTable pastDueTable = GetBlankDueDataTable();
            DataTable upcomingTable = GetBlankDueDataTable();


            await FillDueDataTables(pastDueTable, upcomingTable);

            dashView.PastDueTrainings = pastDueTable;
            dashView.UpcomingTrainings = upcomingTable;
        }

        public async Task LoadEmployeeTrainingRecord()
        {
            DataTable recordTable = GetBlankRecordDataTable();

            await FillRecordDataTable(recordTable);

            dashView.TrainingRecord = recordTable;
        }


        private DataTable GetBlankDueDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Required", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Revison", typeof(double));
            table.Columns.Add("Due Date", typeof(DateTime));
            table.Columns.Add("Status", typeof(string));
            return table;
        }

        private async Task FillDueDataTables(DataTable pastDueTable, DataTable upcomingTable)
        {
            Employee user = ApplicationState.CurrentUser;
            Dictionary<int, string> trainingRecord = await user.GetAssignedTrainings();
            List<int> pendingTrainings = await user.GetTrainingsWithCompletedQuizzes();

            string currDate = DateFunctions.GetCurrentDateString();

            foreach (int trainingId in trainingRecord.Keys)
            {
                Training training = await Training.GetTraining(trainingId);
                string dueDate = trainingRecord[trainingId];
                DateTime dueDateTime = DateFunctions.DateStringToDateTime(dueDate);
                string required = (await user.HasTraining(trainingId, true)) ? "Yes" : "No";
                string status = pendingTrainings.Contains(trainingId) ? "Did not pass" : "Incomplete";
                
                if (DateFunctions.CompareDates(dueDate, currDate) < 0) //if the dueDate is less than today's date
                {
                    AddTableRow(pastDueTable, required, training, dueDateTime, status);
                }
                else if (DateFunctions.CompareDates(dueDate, DateFunctions.IncrementDate(currDate, config.GUISettings.DashboardUpcomingLimit)) < 0) //if the due date is within upcoming limit months of today
                {
                    AddTableRow(upcomingTable, required, training, dueDateTime, status);
                }
            }
        }

        private void AddTableRow(DataTable table, string required, Training training, DateTime dueDateTime, string status)
        {
            DataRow row = table.NewRow();
            row[0] = required; row[1] = training.Name; row[2] = training.Type; row[3] = training.Description; row[4] = training.Revision;
            row[5] = dueDateTime; row[6] = status;
            table.Rows.Add(row);
        }


        private DataTable GetBlankRecordDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Expires", typeof(DateTime));
            table.Columns.Add("Required", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Revision", typeof(double));
            table.Columns.Add("Date Completed", typeof(DateTime));
            return table;
        }

        private async Task FillRecordDataTable(DataTable table)
        {
            Employee user = ApplicationState.CurrentUser;
            Dictionary<int, string> completedTrainings = await user.GetCompletedTrainings();
            Dictionary<int, string> requiredTrainings = await user.GetRequiredTrainings();

            foreach(int trainingId in completedTrainings.Keys)
            {
                Training training = await Training.GetTraining(trainingId);
                DataRow row = table.NewRow();
                row[2] = training.Name; row[3] = training.Type; row[4] = training.Description; row[5] = training.Revision; row[6] = completedTrainings[trainingId];
                if (requiredTrainings.ContainsKey(trainingId))
                {
                    row[0] = DateFunctions.DateStringToDateTime(requiredTrainings[trainingId]);
                    row[1] = "Yes";
                }
                else
                {
                    string dueDate = DateFunctions.IncrementDate(completedTrainings[trainingId], training.CompletionFrequency);
                    row[0] = DateFunctions.DateStringToDateTime(dueDate);
                    row[1] = "No";
                }
                table.Rows.Add(row);
            }
        }
        

        private string GetCurrDate()
        {
            int[] currDateArray = DateFunctions.GetCurrentDate();

            return currDateArray[0] + "/" + currDateArray[1] + "/" + currDateArray[2];
        }

        private bool IsPastDue(Training training, string dateCompleted)
        {
            string dueDate = DateFunctions.IncrementDate(dateCompleted, training.CompletionFrequency);

            string currDate = GetCurrDate();
            return DateFunctions.CompareDates(dueDate, currDate) < 0; //if the due date is less than todays date
        }

        

        public async Task DisplayTraining(string trainingName)
        {
            TrainingQuizPopup popup = new TrainingQuizPopup(await Training.GetTraining(trainingName));
            CommonFunctions.ShowAsModalPopup(popup, FormBorderStyle.FixedToolWindow);
        }

        #endregion



        #region management

        public void DisplayTrainingRecords()
        {
            TrainingRecordViewer form = new TrainingRecordViewer();
            ViewTrainingRecordPresenter presenter = new ViewTrainingRecordPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void DisplayDepartmentTrainingRecords()
        {
            TrainingRecordViewer form = new TrainingRecordViewer();
            ViewTrainingRecordPresenter presenter = new ViewTrainingRecordPresenter(form, ViewType.Department);
            dashView.ManagementSelectedForm = form;
        }

        public void DisplayEmployeeTrainingRecords()
        {
            TrainingRecordViewer form = new TrainingRecordViewer();
            ViewTrainingRecordPresenter presenter = new ViewTrainingRecordPresenter(form, ViewType.Employee);
            dashView.ManagementSelectedForm = form;
        }


        public void ShowAddTrainingRecordForm()
        {
            AddTrainingRecord addRecordForm = new AddTrainingRecord();
            AddTrainingRecordPresenter presenter = new AddTrainingRecordPresenter(addRecordForm, "Individual");
            dashView.ManagementSelectedForm = addRecordForm;
        }

        public void ShowAddGroupTrainingRecordForm()
        {
            AddTrainingRecord addRecordForm = new AddTrainingRecord();
            AddTrainingRecordPresenter presenter = new AddTrainingRecordPresenter(addRecordForm, "Group");
            dashView.ManagementSelectedForm = addRecordForm;
        }

        public void ShowAssignTrainingForm()
        {
            AssignTraining assignTrainingForm = new AssignTraining();
            AssignTrainingPresenter presenter = new AssignTrainingPresenter(assignTrainingForm);
            dashView.ManagementSelectedForm = assignTrainingForm;
        }

        public void ShowManagementDash()
        {
            UserRights currUserRights = ApplicationState.CurrentUser.UserAccess;
            ManagementDash form = new ManagementDash();
            ManagerDashPresenter presenter = new ManagerDashPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowCreateTrainingForm()
        {
            TrainingCreator form = new TrainingCreator();
            TrainingCreatorPresenter presenter = new TrainingCreatorPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowComprehensiveView()
        {
            ComprehensiveRecordViewer form = new ComprehensiveRecordViewer();
            ComprehensiveViewPresenter presenter = new ComprehensiveViewPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowUnassignTrainingView()
        {
            UnassignTraining form = new UnassignTraining();
            UnassignTrainingPresenter presenter = new UnassignTrainingPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowCreateQuizForm()
        {
            QuizCreator form = new QuizCreator();
            QuizCreatorPresenter presenter = new QuizCreatorPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowEditEmployeeForm()
        {
            EmployeeEditor form = new EmployeeEditor();
            EmployeeEditPresenter presenter = new EmployeeEditPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowReviseTrainingForm()
        {
            EditTraining form = new EditTraining();
            EditTrainingPresenter presenter = new EditTrainingPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowDeleteTrainingForm()
        {
            DeleteTraining form = new DeleteTraining();
            DeleteTrainingPresenter presenter = new DeleteTrainingPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowAuditLog()
        {
            AuditLog form = new AuditLog();
            AuditLogPresenter presenter = new AuditLogPresenter(form);
            dashView.ManagementSelectedForm = form;
        }


        public void ShowAddEmployeeForm()
        {
            AddEmployee form = new AddEmployee();
            AddEmployeePresenter presenter = new AddEmployeePresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowRemoveEmployeeForm()
        {
            RemoveEmployee form = new RemoveEmployee();
            RemoveEmployeePresenter presenter = new RemoveEmployeePresenter(form);
            dashView.ManagementSelectedForm = form;
        }


        public void ShowRemoveDeptManagerForm()
        {

        }

        public void ShowRemoveRecordForm()
        {

        }

        public void ShowDepartmentViewForm()
        {
            DepartmentView form = new DepartmentView();
            DepartmentViewPresenter presenter = new DepartmentViewPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        public void ShowDeptEditor()
        {
            DepartmentEditor form = new DepartmentEditor();
            DepartmentEditPresenter presenter = new DepartmentEditPresenter(form);
            dashView.ManagementSelectedForm = form;
        }

        #endregion
    }
}
