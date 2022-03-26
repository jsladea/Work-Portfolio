using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Presenters;
using sampleApp.Views;

namespace sampleApp
{
    public partial class QuizViewer : SaveableForm, IQuizView
    {
        private TableLayoutPanel questionPanel;
        private int questionNum;
        private List<Question> questions = new List<Question>();
        private bool submitted;

        private static readonly Color correctColor = Color.FromArgb(147, 245, 66);

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuizViewer()
        {
            InitializeComponent();

            questionNum = 0;
            questionPanel = new TableLayoutPanel();
            questionPanel.Dock = DockStyle.Top;
            questionPanel.AutoSize = true;
            scrollPanel.Controls.Add(questionPanel);
            submitted = false;
        }

        /// <summary>
        /// Constructor for QuizViewer
        /// </summary>
        /// <param name="viewOnly">Submit button is disabled when viewOnly is true.</param>
        public QuizViewer(bool viewOnly) : this()
        {
            if(viewOnly)
                submitBtn.Visible = false;
        }

        public QuizPresenter Presenter { set; private get; }
        public string TrainingName { set => headerLbl.Text = "Quiz " + value; }

        public List<string> Answers
        {
            get
            {
                List<string> answers = new List<string>();
                foreach(Question question in questions)
                {
                    string answer = question.GetSelectedAnswer();
                    if(answer != null)
                        answers.Add(question.GetSelectedAnswer());
                }
                return answers;
            }
        }

        private void LoadQuestions(List<Tuple<string, string[]>> questions)
        {
            SuspendLayout();
            foreach (Tuple<string, string[]> questionTuple in questions)
            {
                AddQuestion(questionTuple.Item1, questionTuple.Item2);
            }
            ResumeLayout();
        }

        private void AddQuestion(string questionText, string[] answers)
        {
            Question question = new Question(answers, ++questionNum + ". " + questionText);
            questionPanel.RowCount += 2;
            questionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            questionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            questionPanel.Controls.Add(question, 0, questionPanel.RowCount - 2);
            questions.Add(question);
        }

        private class Question : TableLayoutPanel
        {
            private Answer[] answers;

            public Question(string[] answerStrings, string text)
            {
                CreateQuestionLine(text);
                answers = new Answer[answerStrings.Length];
                LoadAnswers(answerStrings);
                AutoSize = true;
            }

            private void CreateQuestionLine(string text)
            {
                Label questionLbl = new Label();
                questionLbl.AutoSize = true;
                questionLbl.MaximumSize = new Size(750, 0);
                questionLbl.Text = text;
                questionLbl.Font = new Font("Microsoft Sans Serif", 14F);
                questionLbl.Anchor = AnchorStyles.None;
                questionLbl.Anchor = AnchorStyles.Left;
                RowCount++;
                RowStyles.Add(new RowStyle(SizeType.AutoSize));
                Controls.Add(questionLbl, 0, RowCount - 1);
            }

            private void LoadAnswers(string[] answerStrings)
            {
                SuspendLayout();
                
                for(int i = 0; i < answerStrings.Length; i++)
                {
                    answers[i] = AddAnswer(GetAnswerLetter(i) + ". " + answerStrings[i]);
                }
                ResumeLayout();
            }

            private Answer AddAnswer(string answerText)
            {
                Answer answer = new Answer(answerText, this);
                RowCount += 2;
                RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
                RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
                Controls.Add(answer, 0, RowCount - 2);
                return answer;
            }

            private char GetAnswerLetter(int i)
            {
                switch (i)
                {
                    case 0: return 'A';
                    case 1: return 'B';
                    case 2: return 'C';
                    case 3: return 'D';
                    case 4: return 'E';
                    case 5: return 'F';
                    case 6: return 'G';
                    case 7: return 'H';
                    case 8: return 'I';
                    case 9: return 'J';
                    default: return '0';
                }
            }

            public string GetSelectedAnswer()
            {
                foreach(Answer answer in answers)
                {
                    if (answer.Checked)
                        return answer.Text.Substring(answer.Text.IndexOf(' ') + 1);
                }
                return null;
            }

            public void HighlightCorrectAnswer(string correctAnswer)
            {
                
                foreach(Answer answer in answers)
                {
                    if (answer.Text.Substring(answer.Text.IndexOf(' ') + 1) == correctAnswer)
                        answer.ForeColor = correctColor;
                }
            }

            private class Answer : RadioButton
            {
                private Question question;
                public Answer(string text, Question question)
                {
                    Text = text;
                    Margin = new Padding(35, 3, 3, 3);
                    AutoSize = true;
                    this.CheckedChanged += Answer_CheckedChanged;
                    this.question = question;
                }

                private void Answer_CheckedChanged(object sender, EventArgs e)
                {
                    if (Checked)
                    {
                        foreach (Answer answer in question.answers)
                        {
                            if (answer != this)
                                answer.Checked = false;
                        }
                    }
                }

            }
        }

        private async void QuizViewer_Shown(object sender, EventArgs e)
        {
            List<Tuple<string, string[]>> questions = await Presenter.LoadQuiz();
            if (questions != null)
            {
                LoadQuestions(questions);
            }
            else
            {
                MessageBox.Show("A training quiz has not been created for the selected training.", "Unable to Load Training Quiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            if(await EvaluateSubmission())
            {
                submitted = true;
                DisplayResult();
                if(!await Presenter.NotifyManager())
                {
                    MessageBox.Show("Unable to email department manager." +
                        "\n Please let your department manager know that you have completed the training.",
                        "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                submitBtn.Visible = false;
                ShowCorrectAnswers();
            }
            this.UseWaitCursor = false;
        }

        private async Task<bool> EvaluateSubmission()
        {
            if (submitted) //if the user has already submitted the quiz
            {
                this.UseWaitCursor = false;
                MessageBox.Show("You have already submitted this quiz attempt.\nIf you wish to submit another attempt, please return to the dashboard and retake the quiz.");
                return false;
            }
            else if(await Presenter.SubmitQuiz())
            {
                return true;
            }

            MessageBox.Show("Please make sure that you have selected an answer for each question.\n" +
                    "If error persists, please contact the IT department.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void DisplayResult()
        {
            string passingResult = Presenter.Score >= config.QuizSettings.MinimumScore ? "You passed!" : "Your score does not meet the minimum necessary score of " + config.QuizSettings.MinimumScore + "%.";
            string attemptsResult = Presenter.Attempts <= config.QuizSettings.MaxAttempts ? "" : "You have exceeded the maximum number of allowed attempts.  " +
                "You must speak with your manager or document control to have your training approved.";

            MessageBox.Show(String.Format("Score: {0}%, Attempts: {3}\n\n {4}\n\n {5}\n\n If your score is greater than {1}% and you have taken {2} attempts or less,\n" +
                    " your training will be recorded.\n  If you have taken more than {2} attempts, then you must speak with your manager or document control to have your training approved.",
                    Presenter.Score, config.QuizSettings.MinimumScore, config.QuizSettings.MaxAttempts, Presenter.Attempts, passingResult, attemptsResult));
        }

        private void ShowCorrectAnswers()
        {
            List<string> correctAnswers = Presenter.CorrectAnswers;
            for(int i = 0; i < correctAnswers.Count; i++)
            {
                Question question = questions[i];
                question.HighlightCorrectAnswer(correctAnswers[i]);
            }
        }
    }
}