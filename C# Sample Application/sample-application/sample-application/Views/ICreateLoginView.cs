using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface ICreateLoginView
    {
        CreateLoginPresenter Presenter { set; }

        bool UpdateExistingLogin { get; }
        string Username { get; }
        string TempPassword { get; }
        string Password { get; }
        string ConfirmPassword { get; }
        string FirstQuestion { get; }
        string SecondQuestion { get; }
        string FirstAnswer { get; }
        string SecondAnswer { get; }

    }
}
