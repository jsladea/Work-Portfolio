using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IAddEmployeeView : IUserAccessibility
    {

        AddEmployeePresenter Presenter { set; }

        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
        string Department { get; }
        string JobTitle { get; }
        string Email { get; }
        Employee.UserRights UserAccess { get; }
        

    }
}
