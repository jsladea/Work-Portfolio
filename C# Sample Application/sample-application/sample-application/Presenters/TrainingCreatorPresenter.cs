using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class TrainingCreatorPresenter
    {
        private ITrainingCreatorView view;


        public TrainingCreatorPresenter(ITrainingCreatorView view)
        {
            this.view = view;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> CreateTraining()
        {
            if (!InputsAreValid() || await Training.Exists(view.TrainingName.ToUpper()))
                return false;

            Training training = new Training(view.TrainingName.ToUpper(), GetTrainingType(), view.TrainingDescription, view.Revision, view.CompletionFrequency);
            await training.Save(view.Filepath); //save the new training

            view.ClearInputs();
            return true;
        }

        public async Task<bool> ReplaceTraining()
        {
            if (!InputsAreValid() || DateFunctions.CompareDates(view.DueDate.ToShortDateString(), DateFunctions.GetCurrentDateString()) < 0)
                return false;

            Training trainingToReplace = await Training.GetTraining(view.TrainingName);

            if (view.RetrainingRequired)
            {
                Training replacementTraining = await trainingToReplace.Replace(view.Filepath, view.Revision, view.DueDate);
                await NotifyEmployees(replacementTraining); //email employees about the required retraining
            }
            else
            {
                await trainingToReplace.Replace(view.Filepath, view.Revision);
            }

            view.ClearInputs();
            return true;
        }


        public async Task DisplayOldInfo()
        {
            Training oldTraining = await Training.GetTraining(view.TrainingName);
            //view.CompletionFrequency = oldTraining.CompletionFrequency;
            view.Revision = oldTraining.Revision;
        }

        private async Task NotifyEmployees(Training replacementTraining)
        {
            List<string> emails = new List<string>();
            HashSet<Employee> requiredForSet = await replacementTraining.GetRequiredForSet();
            foreach(Employee employee in requiredForSet)
            {
                List<string> recipients = new List<string>() { employee.Email }; //each employee will receive their own email
                await Notify(recipients);
            }
        }

        private string GetTrainingType()
        {
            string typeStr = view.TrainingType;
            if (typeStr.Contains("DEPT"))
            {
                int startIndex = typeStr.IndexOf('(') + 1;
                int endIndex = typeStr.LastIndexOf(')');

                return "DEPT-" + typeStr.Substring(startIndex, endIndex - startIndex);
            }
            return view.TrainingType;
        }

        private async Task Notify(List<string> recipients)
        {
            await EmailSender.SendEmailAsync(recipients, null, config.EmailText.TrainingReplacedSubject, config.EmailText.GetTrainingReplacedBody(view.TrainingName, view.DueDate.ToShortDateString()), null);
        }

        private bool InputsAreValid()
        {
            if (view.Create)
                return !string.IsNullOrWhiteSpace(view.Filepath) && !string.IsNullOrWhiteSpace(view.TrainingDescription)
                    && !string.IsNullOrWhiteSpace(view.TrainingName) && !string.IsNullOrWhiteSpace(view.TrainingType)
                    && view.CompletionFrequency != -1 && view.Revision != -1;

            return !string.IsNullOrWhiteSpace(view.TrainingName) && !string.IsNullOrWhiteSpace(view.Filepath)  && view.Revision != -1;
        }

    }
}
