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
    public partial class DepartmentEditor : SaveableForm, IDeptEditView
    {
        public DepartmentEditor()
        {
            InitializeComponent();
        }

        public DepartmentEditPresenter Presenter { set; private get; }

        public string SelectedDeptName => deptSelectorBox.GetItemText(deptSelectorBox.SelectedItem);

        public string SelectedManager => managerSelectorBox.GetItemText(managerSelectorBox.SelectedItem);

        public async void SetFormLayout()
        {
            Employee.UserRights accessLevel = ApplicationState.CurrentUser.UserAccess;
            if (accessLevel != Employee.UserRights.AdminAccess && accessLevel != Employee.UserRights.DocControl)
                throw new UserAccessException("User should not have access to this page.");

            deptSelectorBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete());
            currManagerLbl.Visible = false;
            managerSelectorBox.SelectedIndex = -1;
        }

        private async void deptSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Presenter.SetDepartment();
            currManagerLbl.Text = "(Current Manager: " + await Presenter.GetCurrentManagerName() + ")";
            currManagerLbl.Visible = true;

            managerSelectorBox.Items.Clear();
            managerSelectorBox.Items.AddRange(await Presenter.GetDeptAutoComplete());
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            if (!IsSafeToSubmit())
            {
                MessageBox.Show("Only administrators can make changes to the Document Control Department.");
                return;
            }

            Saving = true;
            bool changesMade = await Presenter.SubmitChanges();
            Saving = false;
            currManagerLbl.Visible = false;
            if (changesMade)
                MessageBox.Show("Successfully Updated Department");
            else
                MessageBox.Show("Unable to make changes.\nPlease verify that you have selected a department and a manager.\n If error persists, contact the IT department.");
        }

        private bool IsSafeToSubmit()
        {
            bool unsafeCase = SelectedDeptName.Contains("Doc") && SelectedDeptName.Contains("Cont") && ApplicationState.CurrentUser.UserAccess != Employee.UserRights.AdminAccess;
            return !unsafeCase;
        }

    }
}
