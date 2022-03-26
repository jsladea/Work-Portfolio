using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IManagementDashView : IUserAccessibility
    {
        ManagerDashPresenter Presenter { set; }

        DataTable PendingTasks { set; }

        Department Department { get; }
        
        int PercentTrainingCompleted { set; }
    }
}
