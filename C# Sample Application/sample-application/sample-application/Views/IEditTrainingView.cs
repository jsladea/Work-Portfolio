using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IEditTrainingView : IUserAccessibility
    {
        EditTrainingPresenter Presenter { set; }
    }
}
