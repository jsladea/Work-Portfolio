using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common.CustomExceptions;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;
using static sampleApp.Models.Employee;

namespace sampleApp
{
    public partial class UnassignTraining : Form, IUnassignTrainingView
    {

        private string[] employeeSource;
        private string[] deptSource;

        public UnassignTraining()
        {
            InitializeComponent();
        }

        public string SelectedTraining => trainingSelectorBox.GetItemText(trainingSelectorBox.SelectedItem);

        public string UnassignmentSelection => unassignSelectorBox.GetItemText(unassignSelectorBox.SelectedItem);

        public string UnassignBy => unassignBySelectorBox.GetItemText(unassignBySelectorBox.SelectedItem);

        public UnassignTrainingPresenter Presenter { set; private get; }

        public async void SetFormLayout()
        {
            string[] trainingSource = null;

            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page.");
                case UserRights.DepartmentAccess:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete(ApplicationState.CurrentUser.Department);
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete(ApplicationState.CurrentUser.Department);
                    deptSource = await CommonFunctions.GetDepartmentAutoComplete(true);
                    break;
                case UserRights.Executive:
                    goto case UserRights.DepartmentAccess;
                case UserRights.HumanResources:
                    trainingSource = await CommonFunctions.GetNewHireTrainingSource();
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete();
                    deptSource = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
                case UserRights.DocControl:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete();
                    deptSource = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
                case UserRights.AdminAccess:
                    goto case UserRights.DocControl;

            }
            trainingSelectorBox.Items.AddRange(trainingSource);

            SetUnassignmentSelectionVisibility(false);
        }

        private void ClearInputs()
        {
            trainingSelectorBox.SelectedIndex = -1;
            unassignSelectorBox.SelectedIndex = -1;
            unassignBySelectorBox.SelectedIndex = -1;
            SetUnassignmentSelectionVisibility(false);
        }

        private void SetUnassignmentSelectionVisibility(bool visible)
        {
            unassignSelectorBox.Visible = visible;
            unassignSelectLbl.Visible = visible;
        }

        private async void unassignBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove training: " + SelectedTraining + " from " + UnassignmentSelection + "?",
                "Confirm Unassignment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (await Presenter.UnassignTraining())
                {
                    ClearInputs();
                }
                else
                    MessageBox.Show("Make sure to fill in all fields.", "Error Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void unassignBySelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            unassignSelectorBox.Items.Clear();
            string selectedItem = UnassignBy;
            if (selectedItem == "Department")
            {
                unassignSelectorBox.Items.AddRange(deptSource);
                unassignSelectLbl.Text = "Select Department:";
            }
            else if (selectedItem == "Employee")
            {
                unassignSelectorBox.Items.AddRange(employeeSource);
                unassignSelectLbl.Text = "Select Employee";
            }
                
            SetUnassignmentSelectionVisibility(true);
        }
    }
}
