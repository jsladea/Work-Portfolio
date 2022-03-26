using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class DeleteTrainingPresenter
    {
        private IDeleteTrainingView view;

        public DeleteTrainingPresenter(IDeleteTrainingView view)
        {
            this.view = view;
            this.view.Presenter = this;
            view.SetFormLayout();
        }

        private async Task<Training> GetSelectedTraining()
        {
            string trainingName = CommonFunctions.GetTrainingNameFromInput(view.SelectedTraining);
            if (await CommonFunctions.FilterTrainingByUserRights(trainingName))
            {
                return await CommonFunctions.GetTrainingFromSelection(view.SelectedTraining.ToUpper());
            }
            return null;
        }

        public async Task<bool> DeleteTraining()
        {
            Training training = await GetSelectedTraining();
            if (training != null)
            {
                await training.Archive();
                return true;
            }
            return false;
        }
    }
}
