using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IAssignTrainingView : IUserAccessibility
    {
        AssignTrainingPresenter Presenter { set; }

        string AssignmentType { get; set;  }
        string SelectedTraining { get; }
        string EmployeeSearchText { get; set; }
        DateTime DueDate { get; }

        bool Required { get; }
        
        List<string> AssignmentSelection { get; }
        List<string> Employees { get; set; }
        List<string> Trainings { get; set; }

        void ClearUserInput();
    }
}
