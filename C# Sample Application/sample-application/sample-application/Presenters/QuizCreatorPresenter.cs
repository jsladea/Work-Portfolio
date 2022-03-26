using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;
using sampleApp.Models;
using sampleApp.Models.CSVIO;
using sampleApp.Views;
using static sampleApp.QuizCreator;
using static sampleApp.QuizCreator.Question;

namespace sampleApp.Presenters
{
    public class QuizCreatorPresenter
    {
        private IQuizCreatorView view;
        private Training training;

        public QuizCreatorPresenter(IQuizCreatorView creatorView)
        {
            view = creatorView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> TrainingQuizExists()
        {
            return FileTester.Exists(await GetTrainingQuizFilepath());
        }

        public async Task<bool> CreateQuiz()
        {
            if (await InputsAreValid())
            {
                await Task.Run(async () => await CreateQuizFile());
                return true;
            }
            return false;
        }

        private async Task CreateQuizFile()
        {
            using (CSVFileWriter writer = await CSVFileWriter.GetWriterAsync(await GetTrainingQuizFilepath(), false))
            {
                await writer.WriteRowAsync(training.Id + "," + training.Name + "," + training.Revision);
                await writer.WriteRowAsync("DateCreated:," + DateFunctions.GetCurrentDateString());
                
                foreach(Question question in view.Questions)
                {
                    await writer.WriteRowAsync("Question," + question.QuestionText.Replace(",", EscapeCharacters.Comma));
                    foreach(Answer answer in question.Answers)
                    {
                        string answerText = answer.AnswerText.Replace(",", EscapeCharacters.Comma);
                        if (answer.Correct)
                            await writer.WriteRowAsync("CorrectAnswer," + answerText);
                        else
                            await writer.WriteRowAsync("IncorrectAnswer," + answerText);
                    }
                }
            }
        }

        public async Task<bool> ShowTraining()
        {
            training = await GetTraining();
            if (training != null)
                return await EFileManager.OpenFile(training.EFileLocation);
            else
                return false;
        }

        public async Task<bool> ShowTrainingQuiz()
        {
            training = await GetTraining();
            if(training != null)
            {
                QuizViewer quizViewer = new QuizViewer(true);
                QuizPresenter presenter = new QuizPresenter(quizViewer, training);
                CommonFunctions.ShowAsPopup(quizViewer, System.Windows.Forms.FormBorderStyle.FixedDialog);
                return true;
            }
            return false;
        }

        private async Task<bool> InputsAreValid()
        {
            foreach(Question question in view.Questions)
            {
                if (question.GetCorrectAnswer() == null || string.IsNullOrWhiteSpace(question.QuestionText))
                    return false;
            }
            training = await GetTraining();
            return training != null && view.Questions.Count > 0;
        }

        private async Task<Training> GetTraining()
        {
            string trainingName = CommonFunctions.GetTrainingNameFromInput(view.SelectedTraining).ToUpper();
            if (await Training.Exists(trainingName))
            {
                return await Training.GetTraining(trainingName);
            }
            else
                return null;
        }

        private async Task<string> GetTrainingQuizFilepath()
        {
            return config.FileLocations.TrainingQuizDirectory + "/" +  await GetTrainingQuizFilename();
        }

        private async Task<string> GetTrainingQuizFilename()
        {
            Training training = await GetTraining();
            if (training == null)
                return null;
            else
                return "TrainingQuiz-" + training.Id + ".csv";
        }

    }

}
