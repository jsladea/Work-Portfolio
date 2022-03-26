using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;
using sampleApp.Models;
using sampleApp.Models.CSVIO;
using sampleApp.Views;

namespace sampleApp.Presenters
{

    public class QuizPresenter
    {
        private IQuizView view;
        private Training training;

        public List<string> CorrectAnswers { get; private set; }
        private int numQuestions;
        public int Attempts { get; private set; } = 0;

        public double Score { get; private set; }


        public QuizPresenter(IQuizView quizView, Training training)
        {
            view = quizView;
            view.Presenter = this;
            this.training = training;
            view.TrainingName = training.Name;
            CorrectAnswers = new List<string>();
        }

        public async Task<bool> SubmitQuiz()
        {
            List<string> userAnswers = view.Answers;
            if (AreValidInputs(userAnswers))
            {
                for(int i = 0; i < userAnswers.Count; i++)
                {
                    Console.WriteLine("UserAnswer: " + userAnswers[i] + " - Correct Answer: " + CorrectAnswers[i]);
                    if (userAnswers[i] == CorrectAnswers[i])
                        Score += (1.0 / userAnswers.Count) * 100;
                }
                Attempts = await ApplicationState.CurrentUser.AddQuizScore(Score, training.Id);

                await SaveTrainingRecord();
                return true;
            }
            return false;
        }

        private Boolean ShouldSaveTrainingRecord()
        {
            return Score >= config.QuizSettings.MinimumScore && Attempts <= config.QuizSettings.MaxAttempts;
        }

        private async Task<bool> SaveTrainingRecord()
        {
            if (ShouldSaveTrainingRecord())
            {
                TrainingRecordCreator recordPrinter = new TrainingRecordCreator(training.Name, ApplicationState.CurrentUser.Name + " - " + ApplicationState.CurrentUser.UserId, Attempts + "", Score + "%", false);
                string saveLocation = recordPrinter.SavePDF();

                TrainingRecord record = await CreateRecordObject(saveLocation);

                Console.WriteLine("\nAttempting EFile Save");

                EFileManager.EFileOperationResult result = await record.SaveToEFileAsync();

                Console.WriteLine("EFile Save Result: " + result + "\n");

                if (result == EFileManager.EFileOperationResult.Success)
                {
                    await record.SaveRecordDB();
                    return true;
                }
            }
            return false;
        }

        private async Task<TrainingRecord> CreateRecordObject(string saveLocation)
        {
            TrainingRecord record = new TrainingRecord(TrainingRecord.Type.Individual, ApplicationState.CurrentUser.UserId);
            record.FileLocation = saveLocation;
            record.DateCompleted = DateTime.Now.Date;
            record.AddEmployee(ApplicationState.CurrentUser);
            record.AddTraining(training);

            return record;
        }

        public async Task<List<Tuple<string, string[]>>> LoadQuiz()
        {
            string filepath = GetTrainingQuizFilepath();
            List<Tuple<string, string[]>> questions = new List<Tuple<string, string[]>>();
            if(FileTester.Exists(filepath))
            {
                using(CSVFileReader reader = await CSVFileReader.GetReaderAsync(filepath))
                {
                    await LoadQuestions(questions, reader);
                }
                return questions;
            }
            return null;
        }


        private bool AreValidInputs(List<string> answers)
        {
            return answers.Count == numQuestions; 
        }

        public async Task<bool> NotifyManager()
        {
            try
            {
                Employee currUser = ApplicationState.CurrentUser;
                Employee manager = await currUser.Department.GetManager(true);
                List<string> recipients = new List<string>();
                recipients.Add(manager.Email);
                string subject = currUser.Name + " Completed training - Score: " + Score + "%";
                string body = currUser.Name + " Completed training: " + training.Name + " - " + training.Description + " with a score of: " +
                   Score + "\nAttempt: " + Attempts + "\nA training record should be printed, signed, scanned into sampleApp, and given to document control.";
                await EmailSender.SendEmailAsync(recipients, null, subject, body, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task LoadQuestions(List<Tuple<string, string[]>> questions, CSVFileReader reader)
        {
            string[] row;
            string questionText = null;
            List<string> answers = null;
            while ((row = await reader.ReadRowArrayAsync()) != null)
            {
                string str = row[0].Trim();
                if (str == "Question")
                {
                    AddQuestion(questions, questionText, answers);

                    questionText = row[1];
                    answers = new List<string>();
                }
                else if (str.Contains("Answer"))
                {
                    answers.Add(row[1]);
                    if (str.Trim() == "CorrectAnswer")
                        CorrectAnswers.Add(row[1]);
                }
            }
            AddQuestion(questions, questionText, answers);
        }

        private void AddQuestion(List<Tuple<string, string[]>> questions, string questionText, List<string> answers)
        {
            if (questionText != null)
            {
                questions.Add(new Tuple<string, string[]>(questionText, answers.ToArray()));
                numQuestions++;
            }
        }

        private string GetTrainingQuizFilepath()
        {
            return config.FileLocations.TrainingQuizDirectory + "/" + GetTrainingQuizFilename();
        }

        private string GetTrainingQuizFilename()
        {
            return "TrainingQuiz-" + training.Id + ".csv";
        }
    }
}
