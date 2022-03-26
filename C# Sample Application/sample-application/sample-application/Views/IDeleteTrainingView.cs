using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IDeleteTrainingView : IUserAccessibility
    {
        DeleteTrainingPresenter Presenter { set; }
        
        string SelectedTraining { get; }
    
    }
}
