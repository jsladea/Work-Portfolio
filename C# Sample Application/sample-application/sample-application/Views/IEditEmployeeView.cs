using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;
using static sampleApp.Models.Employee;

namespace sampleApp.Views
{
    public interface IEditEmployeeView : IUserAccessibility
    {
        EmployeeEditPresenter Presenter { set; }

        string DepartmentName { get; }
        string EmployeeUsername { get; }
        string Email { get; }
        string NewUsername { get; }
        string SelectedEmployee { set; }

        UserRights AccessLevel { get; }

        void SetOldAccessLevel(UserRights accessLvl);
        void SetOldDepartment(string deptName);
        void SetOldEmail(string email);
    }
}
