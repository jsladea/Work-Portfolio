using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common.CustomExceptions;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;
using static sampleApp.Presenters.AddTrainingRecordPresenter;

namespace sampleApp
{
    public sealed partial class AddTrainingRecord : SaveableForm, IAddTrainingRecordView
    {

        #region View Interface Implementation
        public AddTrainingRecordPresenter RecordPresenter { private get; set; }

        public string EmployeeSearchText { get { return employeeSearchBox.Text; } set => employeeSearchBox.Text = value; }

        public string TrainingSearchText { get { return trainingSelectorBox.GetItemText(trainingSelectorBox.SelectedItem); } set => trainingSelectorBox.Text = value; }

        public string TrainerSearchText { get => trainerSearchBox.Text; set => trainerSearchBox.Text = value; }

        public string TrainingType
        {
            get { return trainingTypeSelectorBox.GetItemText(trainingTypeSelectorBox.SelectedItem); }
            set
            {
                trainingTypeSelectorBox.SelectedItem = value;
            }
        }

        public DateTime DateCompleted { get { return dateTimePicker.Value.Date; }  }

        private List<string> trainings = new List<string>();
        public List<string> Trainings
        {
            get
            {
                return trainings;
            }

            set
            {
                

                trainings = value;

                selectedTrainingsListBox.BeginUpdate();

                selectedTrainingsListBox.Items.Clear();
                

                for (int i = 0; i < value.Count; i++) //add values and check all boxes
                {
                    selectedTrainingsListBox.Items.Add(value[i]);
                    selectedTrainingsListBox.SetItemChecked(i, true);
                }
                
                selectedTrainingsListBox.EndUpdate();
            }
        }


        private List<string> employees = new List<string>();
        public List<string> Employees
        {
            get
            {
                return employees;
                //selectedEmployeesListBox.Items.Cast<string>().ToList();
            }


            set
            {
                employees = value;

                selectedEmployeesListBox.BeginUpdate(); //don't draw the CheckedListBox while updating

                selectedEmployeesListBox.Items.Clear();


                for (int i = 0; i < value.Count; i++) //add all values and check all boxes
                {
                    selectedEmployeesListBox.Items.Add(value[i]);
                    selectedEmployeesListBox.SetItemChecked(i, true);
                }

                selectedEmployeesListBox.EndUpdate();
            }
        }

        private bool EvaluateAddition(List<string> list)
        {
            return !(TrainingType.Equals("Individual") && list.Count > 1);
        }

        public void ChangeLayoutForType()
        {
            if (TrainingType.Equals("Individual"))
                tableLayoutPanel1.SetRowSpan(selectedEmployeesListBox, 1);
            else
                tableLayoutPanel1.SetRowSpan(selectedEmployeesListBox, 2);
        }

        public string Filepath
        {
            get
            {
                return filenameBox.Text;
            }
            set
            {
                filenameBox.Text = value;
            }
        }

        public string GetFile()
        {
            if (openTrainingRecordDialog.ShowDialog() == DialogResult.OK) //if the user clicks ok, load chosen picture
            {
                return openTrainingRecordDialog.FileName;
            }
            return "";
        }

        public PrinterSettings PrintSettings { get; private set; }

        public bool ShowPrintDialog()
        {
            bool print = printDialog.ShowDialog() == DialogResult.OK;
            if(print)
            {
                PrintSettings = printDialog.PrinterSettings;
            }
            return print;
        }

        #endregion

        public AddTrainingRecord()
        {
            InitializeComponent();
        }

        private async void addTrainingBtn_Click(object sender, EventArgs e)
        {
            if (!await RecordPresenter.AddTraining())
                MessageBox.Show("Make sure you have entered a valid training.\nPossible Duplicate or Invalid Name.", "Error: Invalid User Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void removeTrainingBtn_Click(object sender, EventArgs e)
        {
            RecordPresenter.RemoveTraining();
        }

        private async void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            if(!await RecordPresenter.AddEmployee()) //if employee add operation was unsuccessful
                MessageBox.Show("Make sure you have entered a valid employee.\nPossible Duplicate or Invalid input.", "Error: Invalid User Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void removeEmployeeBtn_Click(object sender, EventArgs e)
        {
            RecordPresenter.RemoveEmployee();
        }

        private void selectedTrainingsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string training = selectedTrainingsListBox.Items[e.Index].ToString();
            if(e.NewValue == CheckState.Unchecked)
                selectedTrainingsListBox.BeginInvoke((MethodInvoker)delegate
                {
                    RecordPresenter.RemoveTraining(training);
                });
        }

        private void selectedEmployeesListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string employee = selectedEmployeesListBox.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Unchecked)
                selectedEmployeesListBox.BeginInvoke((MethodInvoker) delegate //the event fires before the box is updated so all modifications must happen after the box checking is updated
                {
                    RecordPresenter.RemoveEmployee(employee);
                });
        }

        private async void addRecordBtn_Click(object sender, EventArgs e)
        {
            if (!Saving)
            {
                if (ConfirmTrainingRevisions())
                {
                    this.UseWaitCursor = true;
                    Saving = true;
                    await SaveRecord();
                    Saving = false;
                    this.UseWaitCursor = false;
                }
            }
            else
                MessageBox.Show("Record Currently saving. Please wait to add another record.");
        }

        private async Task SaveRecord()
        {
            ValidateTrainerBox();
            switch(await RecordPresenter.AddRecord())
            {
                case OperationResult.Success:
                    ClearInputs();
                    break;
                case OperationResult.InvalidInputs:
                    MessageBox.Show("Error: Invalid Inputs. Check that you have entered all information correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case OperationResult.EFileLoginFailure:
                    MessageBox.Show("Error: The sampleApp Application failed to login to EFile.\n  Please contact the IT department.\n" +
                        "Make sure that EFile settings were not changed to only allow windows user authentication.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case OperationResult.EFileCabinetNotFound:
                    MessageBox.Show("Error: Unable to find the sampleApp LMS cabinet in EFile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case OperationResult.RuntimeException:
                    MessageBox.Show("A problem ocurred while attempting to save to EFile.\n Please try again.\n If errors persist, contact the IT department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("An unexpected error occurred.\nPlease try again.\n" +
                        "If errors persist, please contact the IT department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            ClearValidation();
        }

        private bool ConfirmTrainingRevisions()
        {
            return MessageBox.Show("Please make sure that the revisions of the selected trainings are the same as the revisions to which the employees were trained.\n" +
                    "Use the buttons below to confirm that all entered information is correct.",
                    "Confirm Training Revision", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes;
        }

        private void AddTrainingRecord_Load(object sender, EventArgs e)
        {
            RecordPresenter.InitForm();
        }

        private void trainingTypeSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLayoutForType();
        }

        private void attachFileBtn_Click(object sender, EventArgs e)
        {
            RecordPresenter.AttachFile();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            //resize the filename textbox
            if (flowLayoutPanel1.Width < 700)
                filenameBox.Width = (int)(flowLayoutPanel1.Width * 0.76);
            else
                filenameBox.Width = 532;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            RecordPresenter.PrintTrainingRecord();
        }

        public async void SetFormLayout()
        {
            string[] employeeAutoComplete;
            string[] trainingSource;
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case Employee.UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page");
                case Employee.UserRights.Executive:
                    goto case Employee.UserRights.DepartmentAccess;
                case Employee.UserRights.DepartmentAccess:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    employeeAutoComplete =  await CommonFunctions.GetUserIDNameAutoComplete(ApplicationState.CurrentUser.Department);
                    break;
                case Employee.UserRights.HumanResources:
                    trainingSource = await CommonFunctions.GetNewHireTrainingSource();
                    employeeAutoComplete = await CommonFunctions.GetUserIDNameAutoComplete();
                    break;
                default:
                    employeeAutoComplete = await CommonFunctions.GetUserIDNameAutoComplete();
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    break;
            }
            employeeSearchBox.AutoCompleteCustomSource.AddRange(employeeAutoComplete);
            trainerSearchBox.AutoCompleteCustomSource.AddRange(employeeAutoComplete);

            trainingSelectorBox.Items.AddRange(trainingSource);
            trainingSelectorBox.AutoCompleteCustomSource.AddRange(trainingSource);
        }


        private void ClearInputs()
        {
            filenameBox.Text = "";
            employeeSearchBox.Text = "";
            trainerSearchBox.Text = "";
            trainingSelectorBox.Text = "";
            trainingSelectorBox.SelectedIndex = -1;
            Trainings = new List<string>();
            Employees = new List<string>();
        }

        private void ValidateTrainerBox()
        {
            if (!trainerSearchBox.AutoCompleteCustomSource.Contains(trainerSearchBox.Text))
            {
                errorProvider.SetError(trainerSearchBox, "Input not valid, please see help guide for more information.");
            }
            else
                errorProvider.SetError(trainerSearchBox, "");
        }

        private void ClearValidation()
        {
            errorProvider.SetError(trainerSearchBox, "");
        }

    }
}
