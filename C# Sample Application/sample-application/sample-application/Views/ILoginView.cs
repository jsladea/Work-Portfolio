using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface ILoginView
    {
        LoginPresenter Presenter { set; }

        string Username { get; set; }
        string Password { get; set; }
    }
}
