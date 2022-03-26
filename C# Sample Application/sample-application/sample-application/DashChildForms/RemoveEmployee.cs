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

namespace sampleApp.DashChildForms
{
    public partial class RemoveEmployee : SaveableForm, IRemoveEmployeeView
    {
        public RemoveEmployee()
        {
            InitializeComponent();
        }

        public RemoveEmployeePresenter Presenter { private get; set; }

        public string EmployeeId1 => CommonFunctions.GetUsername(employeeSelectorBox.Text);

        public string EmployeeId2 => userIdBox.Text;

        public async void SetFormLayout()
        {
            string[] employees;
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User Should not have access to this form.");
                case UserRights.DepartmentAccess:
                    employees = await CommonFunctions.GetUserIDNameAutoComplete(ApplicationState.CurrentUser.Department);
                    break;
                default:
                    employees = await CommonFunctions.GetUserIDNameAutoComplete();
                    break;
            }
            employeeSelectorBox.AutoCompleteCustomSource.AddRange(employees);
            employeeSelectorBox.Items.AddRange(employees);
        }

        private async void removeBtn_Click(object sender, EventArgs e)
        {
            if (await Presenter.InputsAreValid() && !Saving)
            {
                Saving = true;
                statusLbl.Text = "Status: Archiving employee, please wait.";
                this.UseWaitCursor = true;
                if (await Presenter.RemoveEmployee())
                {
                    ClearInputs();
                    statusLbl.Text = "Status: ";
                }
                else
                    MessageBox.Show("Error while attempting to archive the employee records. Please contact the IT Department.");
                Saving = false;
                this.UseWaitCursor = false;
            }
            else
                MessageBox.Show("Invalid Inputs. Check to make sure the user Id's match, and that the employee is valid.");
        }

        private void ClearInputs()
        {
            employeeSelectorBox.Text = "";
            employeeSelectorBox.SelectedIndex = -1;
            userIdBox.Text = "";
        }


    }
}
