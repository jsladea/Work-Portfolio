using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IChangePasswordView
    {
        ChangePasswordPresenter Presenter { set; }

        string FirstQuestion { set; }
        string SecondQuestion { set; }

        string Username { get; }
        string FirstAnswer { get; }
        string SecondAnswer { get; }
        string Password { get; }
    }
}
