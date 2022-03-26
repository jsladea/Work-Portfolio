using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common.CustomExceptions;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;
using static sampleApp.Models.Employee;

namespace sampleApp
{
    public partial class EmployeeEditor : SaveableForm, IEditEmployeeView
    {

        private UserRights oldAccess;

        public EmployeeEditor()
        {
            InitializeComponent();
            oldAccess = UserRights.BaseUser;
        }

        public EmployeeEditPresenter Presenter { set; private get; }

        public string DepartmentName => deptNameBox.GetItemText(deptNameBox.SelectedItem);

        public string EmployeeUsername
        {
            get
            {
                try
                {
                    string str = employeeSearchBox.Text;
                    return str.Substring(str.IndexOf('-') + 2);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Username Entered.\nMake sure that your input follows the format: <FirstName> <LastName> - <Username>", "Invalid Input");
                }
                return "";
            }
        }

        public string Email => emailBox.Text;

        public UserRights AccessLevel
        {
            get
            {
                if (!accessLevelBox.Visible || accessLevelBox.SelectedItem == null)
                    return UserRights.BaseUser;
                return (UserRights)accessLevelBox.SelectedItem;
            }
        }

        public string SelectedEmployee {
            set
            {
                selectedEmployeeLbl.Visible = true;
                selectedEmployeeLbl.Text = "Selected Employee: " + value;
            }
        }

        public string NewUsername => firstUsernameBox.Text;

        public async void SetFormLayout()
        {
            UserRights[] userAccessOptions = (UserRights[])Enum.GetValues(typeof(UserRights));
            accessLevelBox.Items.AddRange(userAccessOptions.Cast<object>().ToArray());
            accessLevelBox.Enabled = false;
            tempPasswordLbl.Visible = false;

            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this form");
                case UserRights.DepartmentAccess:
                    goto case UserRights.BaseUser;
                case UserRights.Executive:
                    goto case UserRights.DepartmentAccess;
                case UserRights.DocControl:
                    Department docControl = await Department.GetDepartment("QC-Document Control");
                    Employee docControlManager = await docControl.GetManager();
                    if (ApplicationState.CurrentUser.UserId == docControlManager.UserId) //allow Doc Control Manager to change user access
                    {
                        goto case UserRights.AdminAccess;
                    }
                    else
                        accessLevelLbl.Text = "Access Level (ONLY ACCESSIBLE TO DOC CONTROL MANAGER AND ADMINISTRATORS):";
                    break;
                case UserRights.AdminAccess:
                    accessLevelBox.Enabled = true;
                    break;
            }
            employeeSearchBox.AutoCompleteCustomSource.AddRange(await CommonFunctions.GetUserIDNameAutoComplete());
            deptNameBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete());

            oldDeptLbl.Visible = false;
            oldEmailLbl.Visible = false;
            oldAccessLevelLbl.Visible = false;
            selectedEmployeeLbl.Visible = false;
        }

        public void SetOldDepartment(string deptName)
        {
            oldDeptLbl.Visible = true;
            oldDeptLbl.Text = "(Old Department: " + deptName + ")";
        }

        public void SetOldEmail(string email)
        {
            oldEmailLbl.Visible = true;
            oldEmailLbl.Text = "(Old Email: " + email + ")";
        }

        public void SetOldAccessLevel(UserRights accessLvl)
        {
            oldAccess = accessLvl;
            accessLevelBox.SelectedItem = accessLvl;
            oldAccessLevelLbl.Visible = true;
            oldAccessLevelLbl.Text = "(Old Access Level: " + accessLvl + ")";
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if (!await Presenter.SearchEmployee())
            {
                MessageBox.Show("Employee not found. Please check input and try again.");
            }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            if (!Saving)
            {
                Saving = true;
                if (await Presenter.SaveEmployee())
                {
                    ClearInputs();
                }
                else
                    MessageBox.Show("Unable to Save Employee.\nPlease check the input fields and try again. Verify that there is not a current employee with the specified username.\n" +
                    "If error persists, please contact the IT Department.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Saving = false;
                ClearInputs();
            }
        }

        private bool ValidateUsername()
        {
            Regex validRegex = new Regex(@"^[\w]+$");
            string username = firstUsernameBox.Text;
            string confirmation = secondUsernameBox.Text;

            if (username != confirmation || string.IsNullOrWhiteSpace(username) || !validRegex.IsMatch(username))
            {
                MessageBox.Show("The usernames do not match.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            deptNameBox.SelectedIndex = -1;
            accessLevelBox.SelectedIndex = -1;
            oldDeptLbl.Visible = false;
            oldEmailLbl.Visible = false;
            oldAccessLevelLbl.Visible = false;
            selectedEmployeeLbl.Visible = false;
            emailBox.Text = "";
            employeeSearchBox.Text = "";
            employeeSearchBox.AutoCompleteCustomSource.Clear();
            accessLevelBox.Items.Clear();
            SetFormLayout();
        }

        private void accessLevelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Don't allow Document Control manager to grant AdminAccess.
            if(ApplicationState.CurrentUser.UserAccess == UserRights.DocControl)
            {
                if(AccessLevel == UserRights.AdminAccess)
                {
                    if (oldAccess != UserRights.AdminAccess)
                    {
                        MessageBox.Show("You are not permitted to grant Administrator Access.");
                        accessLevelBox.SelectedItem = oldAccess;
                    }
                }

            }
        }

        private async void restPasswordBtn_Click(object sender, EventArgs e)
        {
            string result = await Presenter.ResetPassword();
            if (result.Length < 20)
                tempPasswordLbl.Text = "Temporary Password: " + result;
            else
                tempPasswordLbl.Text = result;
            tempPasswordLbl.Visible = true;
        }

        private async void changeUserNameBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(employeeSearchBox.Text))
            {
                if (ValidateUsername())
                    if (await Presenter.ChangeUsername())
                        MessageBox.Show("Username has been updated.", "Success");
                    else
                        MessageBox.Show("A user with that username already exists.");
            }
            else
                MessageBox.Show("You must first select an employee.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
