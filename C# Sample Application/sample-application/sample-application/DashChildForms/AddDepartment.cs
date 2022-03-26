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

namespace sampleApp.DashChildForms
{
    public partial class AddDepartment : SaveableForm, IAddDepartmentView
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        public AddDepartmentPresenter Presenter { set; private get; }

        public string DepartmentName => firstDeptNameBox.Text;

        public string DepartmentManager => managerSelectorBox.GetItemText(managerSelectorBox.SelectedItem);
        
        public string ParentDepartment => parentDeptSelectorBox.GetItemText(parentDeptSelectorBox.SelectedItem);

        public async void SetFormLayout()
        {
            Employee.UserRights accessLevel = ApplicationState.CurrentUser.UserAccess;
            if (accessLevel != Employee.UserRights.AdminAccess && accessLevel != Employee.UserRights.DocControl)
                throw new UserAccessException("User should not have access to this page.");

            managerSelectorBox.Items.AddRange(await CommonFunctions.GetUserIDNameAutoComplete());
            parentDeptSelectorBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete());
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            Saving = true;
            if (ValidateInputs() && await Presenter.CreateDepartment())
            {
                Saving = false;
                MessageBox.Show("Department has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                ClearInputs();
            }
            else
            {
                Saving = false; //don't put after messagebox show because it could be confusing for users trying to exit the application
                MessageBox.Show("Unable to Create Department.");
            }
        }

        private bool ValidateInputs()
        {
            if (firstDeptNameBox.Text == secondDeptNameBox.Text && !string.IsNullOrWhiteSpace(firstDeptNameBox.Text))
            {
                if(managerSelectorBox.SelectedIndex != -1)
                {
                    if (parentDeptSelectorBox.SelectedIndex != -1)
                        return true;
                    else
                        MessageBox.Show("You must select a parent department.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("You must select a department manager.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("The department names do not match.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void ClearInputs()
        {
            firstDeptNameBox.Text = "";
            secondDeptNameBox.Text = "";
            managerSelectorBox.SelectedIndex = -1;
            parentDeptSelectorBox.SelectedIndex = -1;
        }
    }
}
