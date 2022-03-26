using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;
using static sampleApp.QuizCreator;

namespace sampleApp.Views
{
    public interface IQuizCreatorView : IUserAccessibility
    {
        QuizCreatorPresenter Presenter { set; }


        List<Question> Questions { get; }
        string SelectedTraining { get; }


    }
}
