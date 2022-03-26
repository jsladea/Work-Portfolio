using PresentationControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common;
using sampleApp.Common.CustomExceptions;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;
using static sampleApp.Models.Employee;

namespace sampleApp
{
    public partial class AssignTraining : SaveableForm, IAssignTrainingView
    {

        private string[] deptSource;

        public AssignTraining()
        {
            InitializeComponent();
            Console.WriteLine("AssignRequiredTraining End of Constructor");
        }

        public AssignTrainingPresenter Presenter { set; private get; }


        public string AssignmentType
        {
            get => assignTypeSelectorBox.GetItemText(assignTypeSelectorBox.SelectedItem);

            set => assignTypeSelectorBox.SelectedItem = value;
        }

        public string SelectedTraining {
            get
            {
                return trainingSelectorBox.GetItemText(trainingSelectorBox.SelectedItem);
            }
        }

        public bool Required => yesCheckBox.Checked;

        public string EmployeeSearchText
        {
            get => employeeSearchBox.Text;
            set => employeeSearchBox.Text = value;
        }

        public DateTime DueDate { get => dateTimePicker.Value.Date; }

        private List<string> employees = new List<string>();
        public List<string> Employees {
            get => employees;

            set
            {
                employees = value;

                selectedEmployeesBox.BeginUpdate(); //don't draw the CheckedListBox while updating

                selectedEmployeesBox.Items.Clear();


                for (int i = 0; i < value.Count; i++) //add all values and check all boxes
                {
                    selectedEmployeesBox.Items.Add(value[i]);
                    selectedEmployeesBox.SetItemChecked(i, true);
                }

                selectedEmployeesBox.EndUpdate();
            }
        }

        private List<string> trainings = new List<string>();
        public List<string> Trainings {
            get => trainings;

            set
            {
                trainings = value;

                selectedTrainingsBox.BeginUpdate();

                selectedTrainingsBox.Items.Clear();


                for (int i = 0; i < value.Count; i++) //add values and check all boxes
                {
                    selectedTrainingsBox.Items.Add(value[i]);
                    selectedTrainingsBox.SetItemChecked(i, true);
                }

                selectedTrainingsBox.EndUpdate();
            }
        }

        public List<string> AssignmentSelection
        {
            get
            {
                List<string> selectedItems = new List<string>();
                foreach (CheckBoxComboBoxItem item in assignBox.CheckBoxItems)
                    if (item.Checked)
                        selectedItems.Add(item.Text);

                return selectedItems;
            }
        }

        public void ClearUserInput()
        {
            employeeSearchBox.Text = "";
            Employees = new List<string>();
            Trainings = new List<string>();
            trainingSelectorBox.Text = "";
            assignTypeSelectorBox.SelectedIndex = -1;
            assignBox.SelectedIndex = -1;
            assignBox.Visible = false;
            yesCheckBox.Checked = false;
            noCheckBox.Checked = false;
        }

        private async void assignBtn_Click(object sender, EventArgs e)
        {
            if (!yesCheckBox.Checked && !noCheckBox.Checked)
                MessageBox.Show("You must indicate whether the trainings to be assigned should be required or optional.");
            else if (!Saving)
            {
                this.UseWaitCursor = true;
                Saving = true;
                if (!await Presenter.AssignTraining())
                    MessageBox.Show("Trainings not assigned. Please check that you have entered all information correctly.");
                Saving = false;
                this.UseWaitCursor = false;
            }
            else
                MessageBox.Show("Please wait for the last training assignment operation to finish before attempting to assign more trainings.");
        }

        private void selectedEmployeesBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string employee = selectedEmployeesBox.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Unchecked)
                selectedEmployeesBox.BeginInvoke((MethodInvoker) async delegate //the event fires before the box is updated so all modifications must happen after the box checking is updated
                {
                    await Presenter.RemoveEmployee(employee);
                });
        }

        private void selectedTrainingsBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string training = selectedTrainingsBox.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Unchecked)
                selectedTrainingsBox.BeginInvoke((MethodInvoker)delegate
                {
                    Presenter.RemoveTraining(training);
                });
        }

        private async void AssignRequiredTraining_Load(object sender, EventArgs e)
        {
            await Presenter.InitForm();
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            if(!await Presenter.AddEmployee()) //if addition of the employee was unsuccessful
                MessageBox.Show("Check to make sure the employee was entered correctly and that the employee is not already in the list.", "User Input Error");
        }

        private async void removeBtn_Click(object sender, EventArgs e)
        {
            await Presenter.RemoveEmployee();
        }

        private async void addTrainingBtn_Click(object sender, EventArgs e)
        {
            if (!await Presenter.AddTraining()) //if addition of the training was unsuccessful
                MessageBox.Show("Check to make sure the training was entered correctly and that the training is not already in the list.", "User Input Error");
        }

        private void assignTypeSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeSelectionPanel.Visible = true;
            if (AssignmentType.Equals("Employee(s)"))
            {
                assignBox.Visible = false;
                employeePanel.Visible = true;
            }
            else
            {
                assignBox.Items.Clear();
                assignBox.Items.AddRange(deptSource);
                assignBox.Visible = true;
                employeePanel.Visible = false;
                if (AssignmentType == "Department")
                    employeeSelectionPanel.Visible = false;
            }
            Presenter.ResetEmployees();
        }

        public async void SetFormLayout()
        {
            string[] trainingSource;
            string[] employeeSource;
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page");
                case UserRights.DepartmentAccess:
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete(ApplicationState.CurrentUser.Department);
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete(ApplicationState.CurrentUser.Department);
                    deptSource = await CommonFunctions.GetDepartmentAutoComplete(true);
                    break;
                case UserRights.Executive:
                    goto case UserRights.DepartmentAccess;
                case UserRights.HumanResources:
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete();
                    trainingSource = await CommonFunctions.GetNewHireTrainingSource();
                    deptSource = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
                default:
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete();
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    deptSource = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
            }

            trainingSelectorBox.AutoCompleteCustomSource.AddRange(trainingSource);
            trainingSelectorBox.Items.AddRange(trainingSource);
            employeeSearchBox.AutoCompleteCustomSource.AddRange(employeeSource);
        }

        private void yesCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(yesCheckBox.Checked)
                noCheckBox.Checked = false;
        }

        private void noCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(noCheckBox.Checked)
                yesCheckBox.Checked = false;
        }

        private async void assignBox_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            await Presenter.AddDepartmentEmployees();
        }
    }
}
