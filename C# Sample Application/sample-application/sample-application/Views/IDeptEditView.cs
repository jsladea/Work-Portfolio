using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IDeptEditView : IUserAccessibility
    {
        DepartmentEditPresenter Presenter { set; }

        string SelectedDeptName { get; }
        string SelectedManager { get; }
    }
}
