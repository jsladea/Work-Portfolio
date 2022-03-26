using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Models;
using sampleApp.Presenters;

namespace sampleApp.DashChildForms.Popups
{
    public partial class TrainingQuizPopup : Form
    {
        private Training training;

        public TrainingQuizPopup(Training training)
        {
            InitializeComponent();
            this.training = training;
            selectedTrainingLbl.Text = "Selected Training: " + training.Name + " " + training.Description;
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            if (!await EFileManager.OpenFile(training.EFileLocation))
                MessageBox.Show("Unable to open the training file.  Please contact the IT department.");

            this.Close();
        }

        private void quizBtn_Click(object sender, EventArgs e)
        {
            QuizViewer form = new QuizViewer();
            QuizPresenter presenter = new QuizPresenter(form, training);
            CommonFunctions.ShowAsModalPopup(form, FormBorderStyle.FixedToolWindow);
            this.Close();
        }
    }
}
