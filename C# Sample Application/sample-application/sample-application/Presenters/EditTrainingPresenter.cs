using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class EditTrainingPresenter
    {
        private IEditTrainingView view;

        public EditTrainingPresenter(IEditTrainingView view)
        {
            this.view = view;
            this.view.Presenter = this;
        }
    }
}
