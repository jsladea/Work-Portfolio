using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class ChangePasswordPresenter
    {
        private IChangePasswordView view;
        private int employeeId;

        public enum ChangePasswordResult { Success, IncorrectAnswer, Error};

        public ChangePasswordPresenter(IChangePasswordView viewForm)
        {
            view = viewForm;
            view.Presenter = this;
        }

        public async Task InitializeQuestions()
        {
            employeeId = (await Employee.GetEmployee(view.Username)).UserId;
            view.FirstQuestion = await UserAuthentication.GetFirstQuestion(employeeId);
            view.SecondQuestion = await UserAuthentication.GetSecondQuestion(employeeId);
        }

        public async Task<ChangePasswordResult> ChangePassword()
        {
            if(await UserAuthentication.AnsweredCorrectly(employeeId, view.FirstAnswer, view.SecondAnswer))
            {
                try
                {
                    await UserAuthentication.UpdatePassword(employeeId, view.Password);
                    return ChangePasswordResult.Success;
                }
                catch (Exception){ return ChangePasswordResult.Error;}
            }
            return ChangePasswordResult.IncorrectAnswer;
        }

    }
}
