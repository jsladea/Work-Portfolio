using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IRemoveEmployeeView : IUserAccessibility
    {
        RemoveEmployeePresenter Presenter { set; }

        string EmployeeId1 { get; }
        string EmployeeId2 { get; }
    }
}
