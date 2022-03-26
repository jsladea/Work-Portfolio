using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface ITrainingCreatorView : IUserAccessibility
    {
        TrainingCreatorPresenter Presenter { set; }

        bool Create { get; }
        bool RetrainingRequired { get;  }

        string TrainingName { get; }
        string TrainingDescription { get; }
        string TrainingType { get; }
        string Filepath { get; }
        DateTime DueDate { get; }

        double Revision { get; set; }
        int CompletionFrequency { get;}

        void ClearInputs();
    }
}
