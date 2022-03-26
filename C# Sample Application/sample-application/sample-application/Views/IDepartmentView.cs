using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IDepartmentView : IUserAccessibility
    {
        DepartmentViewPresenter Presenter { set; }

        string Department { get;}
        DataTable EmpTrainingsData { set; }
        DataTable DeptTrainingsData { set; }
    }
}
