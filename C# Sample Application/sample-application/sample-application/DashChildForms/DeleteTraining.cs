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
using static sampleApp.Models.Employee;

namespace sampleApp
{
    public partial class DeleteTraining : SaveableForm, IDeleteTrainingView
    {
        public DeleteTraining()
        {
            InitializeComponent();
        }

        public DeleteTrainingPresenter Presenter { private get; set; }

        public string SelectedTraining => trainingSelectorBox.Text;

        public async void SetFormLayout()
        {
            string[] trainingSource;
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page");
                case UserRights.DepartmentAccess:
                    trainingSelectorBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete(ApplicationState.CurrentUser.Department);
                    break;
                case UserRights.Executive:
                    goto case UserRights.DepartmentAccess;
                default:
                    trainingSource = await CommonFunctions.GetTrainingAutoComplete();
                    trainingSelectorBox.AutoCompleteCustomSource.AddRange(trainingSource);
                    break;
            }
            trainingSelectorBox.Items.AddRange(trainingSource);
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            Saving = true;
            DialogResult result = MessageBox.Show("Are you sure you want to archive this training.", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (await Presenter.DeleteTraining())
                {
                    ClearInputs();
                }
                else
                    MessageBox.Show("Invalid User Input entered.");
            }
            Saving = false;
        }

        private void ClearInputs()
        {
            trainingSelectorBox.Text = "";
            trainingSelectorBox.SelectedIndex = -1;
            trainingSelectorBox.Items.Clear();
            trainingSelectorBox.AutoCompleteCustomSource.Clear();
            SetFormLayout();
        }


    }
}
