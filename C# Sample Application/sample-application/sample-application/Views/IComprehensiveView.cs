using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IComprehensiveView : IUserAccessibility
    {
        int SelectedEmployeeId { get; }
        DataTable RecordTable { set; }
        ComprehensiveViewPresenter Presenter { set; }
    }
}
