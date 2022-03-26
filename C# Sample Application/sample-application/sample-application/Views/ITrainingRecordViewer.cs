using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;
using static sampleApp.Presenters.ViewTrainingRecordPresenter;

namespace sampleApp.Views
{
    public interface ITrainingRecordViewer : IUserAccessibility
    {
        ViewTrainingRecordPresenter Presenter { set; }

        ViewType ViewBy { get; set; }

        List<string> SelectedEmployees { get; }

        string SelectedView { get; }
        string SelectedDepartment { get; }
        string SelectedTraining { get; set; }

        DataTable TrainingRecord{ set; }
    }
}
