using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IQuizView
    {
        QuizPresenter Presenter { set; }

        string TrainingName { set; }

        List<string> Answers { get; }

    }
}
