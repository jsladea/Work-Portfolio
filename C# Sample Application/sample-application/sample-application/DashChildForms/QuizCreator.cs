using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common.CustomExceptions;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;

namespace sampleApp
{
    public partial class QuizCreator : SaveableForm, IQuizCreatorView
    {
        private TableLayoutPanel questionPanel;
        private List<Question> questions = new List<Question>();

        public List<Question> Questions => new List<Question>(questions);

        public QuizCreatorPresenter Presenter { set; private get; }

        public string SelectedTraining
        {
            get
            {
                string trainingText = "";
       
                trainingSelectorBox.Invoke((MethodInvoker)(() =>  trainingText = trainingSelectorBox.Text));
                return trainingText;
            }
            
        }

        

        public async void SetFormLayout()
        {
            string[] trainingSource;
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case Employee.UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page");
                case Employee.UserRights.DepartmentAccess:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete(ApplicationState.CurrentUser.Department);
                    break;
                case Employee.UserRights.Executive:
                    goto case Employee.UserRights.DepartmentAccess;
                default:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    break;
            }
            trainingSelectorBox.Items.AddRange(trainingSource);
            trainingSelectorBox.AutoCompleteCustomSource.AddRange(trainingSource);
        }

        public QuizCreator()
        {
            InitializeComponent();

            questionPanel = new TableLayoutPanel();
            questionPanel.Dock = DockStyle.Top;
            questionPanel.AutoSize = true;
            questionPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            scrollPanel.Controls.Add(questionPanel);
        }

        private void ClearInputs()
        {
            SuspendLayout();
            foreach (Question question in questions)
                question.Dispose();
            questions.Clear();
            questionPanel.RowStyles.Clear();
            questionPanel.RowCount = 0;
            ResumeLayout();
        }

        private void addQuestionBtn_Click(object sender, EventArgs e)
        {
            questionPanel.RowCount = questionPanel.RowCount + 2;
            questionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            questionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            AddQuestion();
        }

        private void removeQuestionBtn_Click(object sender, EventArgs e)
        {
            if(questions.Count > 0)
            {
                RemoveQuestion();
                questionPanel.RowStyles.RemoveAt(questionPanel.RowStyles.Count - 1);
                questionPanel.RowStyles.RemoveAt(questionPanel.RowStyles.Count - 1);
                questionPanel.RowCount = questionPanel.RowCount - 2;
            }
        }

        private void RemoveQuestion()
        {
            Question question = (Question)questionPanel.GetControlFromPosition(0, questionPanel.RowCount - 2);
            questions.Remove(question);
            question.Dispose();
        }

        private void RemoveQuestion(Question question)
        {
            questions.Remove(question);
            question.Dispose();
            int rowIndex = (question.QuestionNum - 1) * 2; //the row of the question in the question panel
            questionPanel.RowStyles.RemoveAt(rowIndex); //remove the question
            questionPanel.RowStyles.RemoveAt(rowIndex); //remove the "margin"
            for (int i = 0; i < questions.Count; i++)
                questions[i].QuestionNum = i + 1; 
        }

        private void AddQuestion()
        {
            SuspendLayout();
            Question question = new Question(questions.Count + 1);
            questionPanel.Controls.Add(question, 0, questionPanel.RowCount - 2);
            questions.Add(question);
            ResumeLayout();
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            Saving = true;
            if (await Presenter.TrainingQuizExists())
            {
                DialogResult result = MessageBox.Show("A training quiz already exists for this training.\nDo you wish to replace the existing training quiz?", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    await CreateQuiz();
                }
            }
            else
            {
                await CreateQuiz();
            }
            Saving = false;
        }

        private async Task CreateQuiz()
        {
            if (await Presenter.CreateQuiz())
            {
                ClearInputs();
            }
            else
                MessageBox.Show("Unable to create training quiz.\nCheck to make sure that every question has a correct answer selected.",
                    "Unable to create quiz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void viewTrainingBtn_Click(object sender, EventArgs e)
        {
            await Presenter.ShowTraining();
        }

        public class Question : TableLayoutPanel
        {
            public string QuestionText => questionBox.Text;
            public List<Answer> Answers => new List<Answer>(answers);
            public int QuestionNum
            {
                get => questionNum;

                set
                {
                    questionNum = value;
                    questionLbl.Text = questionNum + ". Question:";
                }
            }

            private Label questionLbl;
            private TextBox questionBox;
            private FlowLayoutPanel answerLine;
            private List<Answer> answers = new List<Answer>();
            private List<CheckBox> checkBoxes = new List<CheckBox>();
            private int questionNum;

            private readonly Font questionFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

            public Question(int questNum)
            {
                AutoSize = true;
                Dock = DockStyle.Fill;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                RowCount = 2;
                ColumnCount = 1;
                questionNum = questNum;
                CreateQuestionLine();
                CreateAddAnswerLine();
                
            }

            public Answer GetCorrectAnswer()
            {
                foreach(Answer answer in answers)
                {
                    if (answer.Correct)
                        return answer;
                }
                return null;
            }

            private void CreateQuestionLine()
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.FlowDirection = FlowDirection.LeftToRight;
                panel.Dock = DockStyle.Fill;
                
                questionLbl = new Label();
                questionLbl.Margin = new Padding(2, 4, 10, 2);
                questionLbl.Text = questionNum + ". Question:";
                questionBox = new TextBox();
                questionBox.Width = 400;
                questionBox.Margin = new Padding(2, 2, 10, 2);

                panel.Controls.Add(questionLbl);
                panel.Controls.Add(questionBox);
                panel.Controls.Add(CreateRemoveQuestionButton());
                Controls.Add(panel, 0, 0);
            }

            private void CreateAddAnswerLine()
            {
                answerLine = new FlowLayoutPanel();
                answerLine.Dock = DockStyle.Fill;

                RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
                Button addAnswerButton = CreateAddAnswerButton();
                Button removeAnswerButton = CreateRemoveAnswerButton();
                answerLine.Controls.Add(addAnswerButton);
                answerLine.Controls.Add(removeAnswerButton);
                
                Controls.Add(answerLine, 0, 1);
            }

            private Button CreateAddAnswerButton()
            {
                Button addAnswerBtn = new Button();
                addAnswerBtn.Font = new Font("Microsoft Sans Serif", 12);
                addAnswerBtn.Height = 26;
                addAnswerBtn.Width = 120;
                addAnswerBtn.Margin = new Padding(3, 2, 35, 2);
                addAnswerBtn.Text = "Add Answer";
                addAnswerBtn.Click += AddAnswer;
                return addAnswerBtn;
            }

            private Button CreateRemoveAnswerButton()
            {
                Button removeAnswerBtn = new Button();
                removeAnswerBtn.Font = new Font("Microsoft Sans Serif", 12);
                removeAnswerBtn.Height = 26;
                removeAnswerBtn.Width = 140;
                removeAnswerBtn.Margin = new Padding(3, 2, 0, 2);
                removeAnswerBtn.Text = "Remove Answer";
                removeAnswerBtn.Click += RemoveAnswer;
                return removeAnswerBtn;
            }

            private Button CreateRemoveQuestionButton()
            {
                Button removeQuestionBtn = new Button();
                removeQuestionBtn.Font = new Font("Microsoft Sans Serif", 12);
                removeQuestionBtn.Height = 26;
                removeQuestionBtn.Width = 210;
                removeQuestionBtn.Margin = new Padding(3, 2, 0, 2);
                removeQuestionBtn.Text = "Remove Question";
                removeQuestionBtn.Click += Remove;
                return removeQuestionBtn;
            }

            private void AddAnswer(object sender, EventArgs e)
            {
                char answerLetter = GetAnswerLetter();
                if (answerLetter != '0')
                {
                    SuspendLayout();
                    RowCount = RowCount + 2;
                    RowStyles.Insert(RowStyles.Count - 1, new RowStyle(SizeType.Absolute, 35F));
                    RowStyles.Insert(RowStyles.Count - 1, new RowStyle(SizeType.Absolute, 2F));
                    Answer answer = new Answer(this);
                    answers.Add(answer);
   
                    SetRow(answerLine, RowCount - 1);
                    Controls.Add(answer, 0, RowCount - 3);
                    ResumeLayout();
                }
                else
                    MessageBox.Show("A question can only have a maximum of 10 answers.");
            }

            private void RemoveAnswer(object sender, EventArgs e)
            {
                if (answers.Count > 0)
                {
                    SuspendLayout();
                    Answer answer = (Answer)GetControlFromPosition(0, RowCount - 3);
                    answers.Remove(answer);
                    answer.Dispose();

                    RowStyles.RemoveAt(RowStyles.Count - 2);
                    RowStyles.RemoveAt(RowStyles.Count - 2);
                    RowCount = RowCount - 2;
                    ResumeLayout();
                }
            }

            private void Remove(object sender, EventArgs e)
            {
                QuizCreator form = FindForm() as QuizCreator;
                form.RemoveQuestion(this);
            }

            private char GetAnswerLetter()
            {
                switch (answers.Count)
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

            public class Answer : FlowLayoutPanel
            {
                public string AnswerText => answerBox.Text;
                public char AnswerLetter { get; private set; }
                public bool Correct => correctBox.Checked;

                private Question question;
                private TextBox answerBox = new TextBox();
                private Label answerLbl = new Label();
                private CheckBox correctBox;

                public Answer(Question question)
                {
                    this.question = question;
                    AnswerLetter = question.GetAnswerLetter();

                    Dock = DockStyle.Fill;
                    FlowDirection = FlowDirection.LeftToRight;
                    answerLbl.Text = AnswerLetter + ".";
                    answerLbl.Width = 20;
                    answerLbl.Margin = new Padding(35, 4, 10, 2);
                    answerBox.Margin = new Padding(0, 2, 10, 2);
                    answerBox.Width = 200;

                    correctBox = new CheckBox();
                    correctBox.Margin = new Padding(0, 0, 0, 2);
                    question.checkBoxes.Add(correctBox);
                    correctBox.CheckedChanged += CorrectAnswerBox_CheckedChanged;

                    Label correctLbl = new Label();
                    correctLbl.Margin = new Padding(0, 4, 5, 2);
                    correctLbl.Text = "Correct:";
                    correctLbl.Width = 50;

                    Controls.Add(answerLbl);
                    Controls.Add(answerBox);
                    Controls.Add(correctLbl);
                    Controls.Add(correctBox);
                }

                private char GetAnswerLetter()
                {
                    switch (question.answers.Count)
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

                private void CorrectAnswerBox_CheckedChanged(object sender, EventArgs e)
                {
                    if(correctBox.Checked)
                        foreach(CheckBox cBox in question.checkBoxes)
                        {
                            if (!cBox.Equals(correctBox))
                                cBox.Checked = false;
                        }
                }

                public string GetText()
                {
                    return answerLbl.Text + "-" + answerBox.Text;
                }
            }

        }

        private async void viewQuizBtn_Click(object sender, EventArgs e)
        {
            await Presenter.ShowTrainingQuiz();
        }

        private async void trainingSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await DisplayQuizViewBtn();
        }

        private async Task DisplayQuizViewBtn()
        {
            if (await Presenter.TrainingQuizExists())
            {
                viewQuizBtn.Enabled = true;
                createBtn.Text = "Replace Quiz";
            }
            else
            {
                viewQuizBtn.Enabled = false;
                createBtn.Text = "Create Quiz";
            }
        }
    }
}