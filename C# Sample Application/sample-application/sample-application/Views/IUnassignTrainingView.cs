using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IUnassignTrainingView : IUserAccessibility
    {
        UnassignTrainingPresenter Presenter { set; }

        string UnassignBy { get; }
        string SelectedTraining { get; }
        string UnassignmentSelection { get; } 

    }
}
