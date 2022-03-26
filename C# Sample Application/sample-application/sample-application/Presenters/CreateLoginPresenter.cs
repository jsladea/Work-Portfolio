using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;
using static sampleApp.Models.UserAuthentication;

namespace sampleApp.Presenters
{
    public class CreateLoginPresenter
    {
        private ICreateLoginView view;

        public CreateLoginPresenter(ICreateLoginView loginView)
        {
            this.view = loginView;
            view.Presenter = this;
        }



        public async Task CreateLogin()
        {
            Employee employee = await Employee.GetEmployee(view.Username);
            SecurityQuestion firstQuestion = UserAuthentication.GetSecurityQuestion(view.FirstQuestion);
            SecurityQuestion secondQuestion = UserAuthentication.GetSecurityQuestion(view.SecondQuestion);
            if(!view.UpdateExistingLogin)
                await UserAuthentication.StoreNewAuthentication(employee.UserId, view.Password,
                firstQuestion.GetId(), secondQuestion.GetId(), view.FirstAnswer, view.SecondAnswer);
            else
                await UserAuthentication.UpdateAuthenticationInfo(employee.UserId, view.Password,
                firstQuestion.GetId(), secondQuestion.GetId(), view.FirstAnswer, view.SecondAnswer);
        }
        
        public async Task<string> InputsAreValid()
        {
            if (await Employee.Exists(view.Username))
            {

                Employee employee = await Employee.GetEmployee(view.Username);

                //check to make sure the employee doesn't have windows credentials 
                if (UserAuthentication.ADAuthentication.HasADCredentials(employee.Username))
                    return "This user already has windows login credentials.  Contact IT Department for more information.";

                return await ValidateInputs(employee);
            }
            else
                return "The username entered was not found in the system.\nIf you have not been given a username, please see Document Control.";
        }

        private async Task<string> ValidateInputs(Employee employee)
        {
            bool updateLogin = view.UpdateExistingLogin && await UserAuthentication.IsValid(employee.UserId, view.TempPassword);

            if (!await UserAuthentication.IsRegistered(employee.UserId) || updateLogin)
            {
                if (PasswordsMatch())
                {
                    if (QuestionsAreValid())
                    {
                        return "true";
                    }
                    else
                        return "Make sure that two different security questions are selected and answered.";
                }
            }
            else if (view.UpdateExistingLogin)
                return "Incorrect temporary password.";

            return "An employee with this username already has a login created.";
        }

        public async Task<string[]> GetSecurityQuestions()
        {
            List<SecurityQuestion> questionList = await UserAuthentication.GetSecurityQuestions();
            string[] questions = new string[questionList.Count];
            for(int i = 0; i < questionList.Count; i++)
            {
                questions[i] = questionList[i].GetText();
            }

            return questions;
        }

        private bool PasswordsMatch()
        {
            return view.Password.Equals(view.ConfirmPassword);
        }

        private bool QuestionsAreValid()
        {
            if (!view.FirstQuestion.Equals(view.SecondQuestion))
            {
                return !string.IsNullOrWhiteSpace(view.FirstQuestion) && !string.IsNullOrWhiteSpace(view.SecondQuestion) &&
                    !string.IsNullOrWhiteSpace(view.FirstAnswer) && !string.IsNullOrWhiteSpace(view.SecondAnswer);
            }
            else
                return false;
        }
    }
}
