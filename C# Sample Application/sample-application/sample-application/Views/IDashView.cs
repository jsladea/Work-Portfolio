using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Models;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IDashView : IUserAccessibility
    {
        DashPresenter DashPresenter { set; }

        string RecordSearchBoxText { get; set; }
        string CurrentUser { set; }

        string[] DepartmentList { set; }

        DataTable PastDueTrainings { set; }
        DataTable UpcomingTrainings { set; }
        DataTable TrainingRecord { set; }

        Form ManagementSelectedForm { set; }

    }
}
