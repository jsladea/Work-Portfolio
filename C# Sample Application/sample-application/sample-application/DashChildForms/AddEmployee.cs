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
    public partial class AddEmployee : SaveableForm, IAddEmployeeView
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        public string Username => userIdBox.Text;

        public string FirstName => firstNameBox.Text;

        public string LastName => lastNameBox.Text;

        public string Department => deptBox.Text;

        public string JobTitle => jobTitleBox.Text;

        public string Email => emailBox.Text;

        public UserRights UserAccess
        {
            get
            {
                if (userRightsBox.SelectedItem == null)
                    return UserRights.BaseUser;
                return (UserRights) userRightsBox.SelectedItem;
            }
        }

        public AddEmployeePresenter Presenter { private get; set; }

        public async void SetFormLayout()
        {
            string[] departments = null;
            userRightsLbl.Visible = false;
            userRightsBox.Visible = false;
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page.");
                case UserRights.DepartmentAccess:
                    departments = await CommonFunctions.GetDepartmentAutoComplete(true);
                    break;
                case UserRights.Executive:
                    goto case UserRights.DepartmentAccess;
                case UserRights.AdminAccess:
                    userRightsLbl.Visible = true;
                    userRightsBox.Visible = true;
                    UserRights[] userAccessOptions = (UserRights[]) Enum.GetValues(typeof(UserRights));
                    userRightsBox.Items.AddRange(userAccessOptions.Cast<object>().ToArray());
                    departments = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
                case UserRights.DocControl:
                    userRightsLbl.Visible = true;
                    userRightsBox.Visible = true;
                    UserRights[] userAccess = { UserRights.BaseUser, UserRights.DepartmentAccess, UserRights.DocControl, UserRights.Executive};
                    userRightsBox.Items.AddRange(userAccess.Cast<object>().ToArray());
                    departments = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
                case UserRights.HumanResources:
                    departments = await CommonFunctions.GetDepartmentAutoComplete();
                    break;
            }
            deptBox.Items.AddRange(departments);
            
        }

        public void ClearInputs()
        {
            userIdBox.Text = "";
            firstNameBox.Text = "";
            lastNameBox.Text = "";
            jobTitleBox.Text = "";
            emailBox.Text = "";
            deptBox.SelectedIndex = -1;
            userRightsBox.SelectedItem = null;
            userRightsBox.SelectedIndex = -1;
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            
            Saving = true;
            if (ValidateFields() && Presenter.AreValidInputs())
            {
                if (await Presenter.AddEmployee())
                {
                    ClearInputs();
                }
                else
                    MessageBox.Show("Error while adding employee.\nThe username entered already belongs to a current employee.", "Error");
            }
            else
            {
                MessageBox.Show("Error while adding employee.\nVerify that all fields have been entered with valid inputs.", "Error");
                ClearValidation();
            }
            Saving = false;
        }

        private bool ValidateFields()
        {
            return ValidateFirstName() & ValidateLastName() & ValidateUsername() & ValidateEmail() & ValidateJobTitle();
        }

        private void ClearValidation()
        {
            errorProvider.SetError(firstNameBox, "");
            errorProvider.SetError(lastNameBox, "");
            errorProvider.SetError(userIdBox, "");
            errorProvider.SetError(emailBox, "");
            errorProvider.SetError(jobTitleBox, "");
        }

        private bool ValidateFirstName()
        {
            Regex validRegex = new Regex(@"^[a-zA-Z\(\)]+$");
            if (string.IsNullOrWhiteSpace(firstNameBox.Text) || !validRegex.IsMatch(firstNameBox.Text))
            {
                errorProvider.SetError(firstNameBox, "Invalid Input");
                return false;
            }
            errorProvider.SetError(firstNameBox, "");
            return true;
        }

        private bool ValidateLastName()
        {
            Regex validRegex = new Regex(@"^[a-zA-Z\(\)]+$");
            if (string.IsNullOrWhiteSpace(lastNameBox.Text) || !validRegex.IsMatch(lastNameBox.Text))
            {
                errorProvider.SetError(lastNameBox, "Invalid Input");
                return false;
            }
            errorProvider.SetError(lastNameBox, "");
            return true;
        }

        private bool ValidateUsername()
        {
            Regex validRegex = new Regex(@"^[\w]+$");
            if (string.IsNullOrWhiteSpace(userIdBox.Text) || !validRegex.IsMatch(userIdBox.Text))
            {
                errorProvider.SetError(userIdBox, "Invalid Input");
                return false;
            }
            errorProvider.SetError(userIdBox, "");
            return true;
        }

        private bool ValidateEmail()
        {
            Regex validRegex = new Regex(@"^[\w-\.]+@[\w-\.]+\.(com|org|net)+$");
            //only validate if email box is NOT empty
            if (!string.IsNullOrWhiteSpace(Email))
            {
                if (!validRegex.IsMatch(Email))
                {
                    errorProvider.SetError(emailBox, "Invalid Input");
                    return false;
                }
            }
            errorProvider.SetError(emailBox, "");
            return true;
        }

        private bool ValidateJobTitle()
        {
            Regex validRegex = new Regex(@"^[a-zA-Z ]+$");
            
            if (string.IsNullOrWhiteSpace(jobTitleBox.Text) || !validRegex.IsMatch(jobTitleBox.Text))
            {
                errorProvider.SetError(jobTitleBox, "Invalid Input");
                return false;
            }
            errorProvider.SetError(jobTitleBox, "");
            return true;
        }


    }
}
