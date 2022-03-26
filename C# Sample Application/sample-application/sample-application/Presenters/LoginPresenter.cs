using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace sampleApp.Presenters
{
    public class LoginPresenter
    {
        private ILoginView loginView;
        private SQLDatabaseManager dbManager;

        public enum LoginResult {Success, MissingInput, Failure};

        public LoginPresenter(ILoginView login)
        {
            loginView = login;
            loginView.Presenter = this;
            dbManager = new SQLDatabaseManager();
        }
        
        public async Task<LoginResult> Login()
        {
            if (await IsRegistered()) //if the employee has sampleApp access
            {
                if (!InputsAreFilled())
                    return LoginResult.MissingInput;

                if (ADLogon() || await IsValidsampleAppLogin())
                {
                    //create employee instance and set to currentUser
                    await ApplicationState.SetCurrentUser(loginView.Username);
                    ApplicationState.LoggedIn = true;
             
                    loginView.Password = ""; //clear the password box
                    ((Form)(loginView)).Hide();
                    return LoginResult.Success;
                }
            }

            return LoginResult.Failure;
        }

        private bool ADLogon()
        {
            return UserAuthentication.ADAuthentication.ADLogon(loginView.Username, loginView.Password);
        }

        private async Task<bool> IsValidsampleAppLogin()
        {
            Employee employee = await Employee.GetEmployee(loginView.Username);
            return await UserAuthentication.IsValid(employee.UserId, loginView.Password) ;
        }

        /// <summary>
        /// Checks to see if the entered Username is paired with a registered Employee
        /// </summary>
        /// <returns>true if the entered Username matches with a current Employee</returns>
        private async Task<bool> IsRegistered()
        {
            return await Employee.Exists(loginView.Username);
        }


        public void SetUserClosed()
        {
            ApplicationState.UserClosedLogin = true;
        }

        public void ShowAboutSection()
        {
            MessageBox.Show("This Application uses icons from https://icons8.com");
        }


        private bool InputsAreFilled()
        {
            return !loginView.Username.Equals("") && !loginView.Password.Equals("");
        }

    }
}
