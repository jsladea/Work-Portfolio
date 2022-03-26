using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common;
using sampleApp.Common.CustomExceptions;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;
using static sampleApp.Models.Employee;

namespace sampleApp
{
    public partial class TrainingCreator : SaveableForm, ITrainingCreatorView
    {
        public TrainingCreatorPresenter Presenter { private get; set; }

        public bool Create => createCheckBox.Checked;

        public bool RetrainingRequired => retrainingCheckBox.Checked;

        public string TrainingName
        {
            get
            {
                if (Create)
                    return trainingNameBox.Text;

                string trainingString = trainingSelectorBox.SelectedItem as string;
                return trainingString.Substring(0, trainingString.IndexOf(' '));
            }
        }

        public string TrainingDescription => descriptionTextBox.Text;

        public string TrainingType => (string)trainingTypeBox.SelectedItem;

        public string Filepath => filePathBox.Text.Replace("\\", "/");

        public DateTime DueDate => dueDatePicker.Value.Date;

        public double Revision
        {
            get
            {
                try
                {
                    return double.Parse(revisionTextBox.Text);
                }
                catch (Exception)
                {
                    errorProvider.SetError(revisionTextBox, "Invalid Input");
                    MessageBox.Show("The revision can only contain numerical values and one \".\"");
                    errorProvider.SetError(revisionTextBox, "");
                }
                return -1;
            }

            set
            {
                oldRevisionLbl.Text = "(Old Revision: " + value + ")";
            }
        }

        public int CompletionFrequency {
            get
            {
                try
                {
                    return int.Parse(compFrequencyBox.Text);
                }
                catch (Exception)
                {
                    errorProvider.SetError(compFrequencyBox, "Invalid Input");
                    MessageBox.Show("Completion frequency must be a whole number greater than or equal to zero.\nEnter zero if the training should only be completed once.");
                    errorProvider.SetError(compFrequencyBox, "");
                }
                return -1;
            }
        }

        public TrainingCreator()
        {
            InitializeComponent();
        }

        public void ClearInputs()
        {
            createCheckBox.Checked = false;
            replaceCheckBox.Checked = false;
            retrainingCheckBox.Checked = false;
            trainingSelectorBox.SelectedIndex = -1;
            trainingTypeBox.SelectedIndex = -1;
            trainingNameBox.Text = "";
            descriptionTextBox.Text = "";
            filePathBox.Text = "";
            revisionTextBox.Text = "";
            compFrequencyBox.Text = "";

            trainingTypeBox.Items.Clear();
            trainingSelectorBox.Items.Clear();
            SetFormLayout();
        }

        public async void SetFormLayout()
        {
            string[] trainingSource = null;

            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to Create Training Functionality.");
                case UserRights.DepartmentAccess:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete(ApplicationState.CurrentUser.Department);
                    trainingTypeBox.Items.AddRange(await GetTrainingTypeAutoComplete());
                    break;
                case UserRights.Executive:
                    goto case UserRights.DepartmentAccess;
                case UserRights.HumanResources:
                    goto case UserRights.BaseUser;
                default:
                    trainingTypeBox.Items.AddRange(config.Types.TrainingTypes);
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    break;
            }

            trainingSelectorBox.Items.AddRange(trainingSource);

            compFrequencyLbl.Visible = false;
            compFrequencyBox.Visible = false;
            dueDateLbl.Visible = false;
            dueDatePicker.Visible = false;
        }

        private async Task<string[]> GetTrainingTypeAutoComplete()
        {
            Department department = ApplicationState.CurrentUser.Department;
            List<Department> validDepartments = await department.GetChildDepartments();
            validDepartments.Add(department);
            string[] departmentSource = new string[validDepartments.Count];
            for (int i = 0; i < departmentSource.Length; i++)
            {
                departmentSource[i] = "DEPT-" + validDepartments[i].Name + "(" + validDepartments[i].Id + ")";
            }
            return departmentSource;
        }

        private void createCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Create)
            {
                retrainingCheckBox.Checked = false;
                replaceCheckBox.Checked = false;
                SetCreationControlVisibility(true);
            }
        }

        private void replaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (replaceCheckBox.Checked)
            {
                createCheckBox.Checked = false;
                SetCreationControlVisibility(false);
            }
        }

        private void SetCreationControlVisibility(bool visible)
        {
            selectReplaceLabel.Visible = !visible;
            trainingSelectorBox.Visible = !visible;
            oldRevisionLbl.Visible = !visible;
            retrainingCheckBox.Visible = !visible;

            createBtn.Text = visible ? "Create" : "Replace";

            typeLbl.Visible = visible;
            compFrequencyBox.Visible = visible;
            compFrequencyLbl.Visible = visible;
            trainingTypeBox.Visible = visible;
            descriptionLbl.Visible = visible;
            descriptionTextBox.Visible = visible;
            nameLbl.Visible = visible;
            trainingNameBox.Visible = visible;
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                await CreateTraining();
            }
            else
            {
                MessageBox.Show("Inputs are invalid.", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearValidation();
            }
        }

        private async Task CreateTraining()
        {
            Saving = true;
            bool created = false;
            this.UseWaitCursor = true;

            if (Create)
                created = await Presenter.CreateTraining();
            else
                created = await Presenter.ReplaceTraining();

            Saving = false;
            this.UseWaitCursor = false;
            if (!created)
                MessageBox.Show("Unable to create/replace training because the inputs are invalid.");
        }

        private void attachFileBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathBox.Text = openFileDialog.FileName;
            }
        }

        private async void trainingSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(trainingSelectorBox.SelectedIndex != -1)
                await Presenter.DisplayOldInfo();
        }

        private void retrainingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RetrainingRequired)
            {
                dueDateLbl.Visible = true;
                dueDatePicker.Visible = true;
            }
            else
            {
                dueDateLbl.Visible = false;
                dueDatePicker.Visible = false;
            }
        }

        private bool ValidateInputs()
        {
            return ValidateName() & ValidateDate();
        }

        private bool ValidateName()
        {
            Regex validRegex = new Regex(@"^[\w-]+$");

            if (string.IsNullOrWhiteSpace(TrainingName) || !validRegex.IsMatch(TrainingName))
            {
                errorProvider.SetError(trainingNameBox, "Input is invalid.");
                return false;
            }
            errorProvider.SetError(trainingNameBox, "");
            return true;

        }

        private bool ValidateDate()
        {
            if (!(DateFunctions.CompareDates(DueDate.ToShortDateString(), DateFunctions.GetCurrentDateString()) >= 0))
            { //if the duedate is in the past
                errorProvider.SetError(dueDatePicker, "Invalid input");
                return false;
            }
            errorProvider.SetError(dueDatePicker, "");
            return true;
        }

        private void ClearValidation()
        {
            errorProvider.SetError(trainingNameBox, "");
            errorProvider.SetError(dueDatePicker, "");
        }
        

    }
}
