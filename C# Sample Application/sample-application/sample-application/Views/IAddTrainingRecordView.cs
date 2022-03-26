using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IAddTrainingRecordView : IUserAccessibility
    {
        AddTrainingRecordPresenter RecordPresenter { set; }

        string EmployeeSearchText { get; }
        string TrainingSearchText { get; }
        string TrainingType { get; set; }
        DateTime DateCompleted { get; }
        string Filepath { get; set; }
        string TrainerSearchText { get; set; }


        List<string> Trainings { get; set; }
        List<string> Employees { get; set; }

        PrinterSettings PrintSettings { get; }

        bool ShowPrintDialog();

        string GetFile();

        void ChangeLayoutForType();
    }
}
