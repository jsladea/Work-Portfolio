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
    public partial class AuditLog : SaveableForm, IAuditLogView
    {
        public AuditLog()
        {
            InitializeComponent();
            startDatePicker.Value = DateTime.Now.Date;
            endDatePicker.Value = DateTime.Now.Date;
        }

        public AuditLogPresenter Presenter { set; private get; }

        public DateTime StartDate => startDatePicker.Value.Date;
        public DateTime EndDate => endDatePicker.Value.Date;

        public AuditTrail.Actions SelectedAction
        {
            get
            {
                AuditTrail.Actions action;
                if (actionSelectorBox.SelectedIndex != -1 && Enum.TryParse(actionSelectorBox.GetItemText(actionSelectorBox.SelectedItem), out action))
                    return action;

                return AuditTrail.Actions.Unspecified;
            }
            
        }

        public DataTable AuditLogSource
        {
            set
            {
                logDGV.DataSource = value;
                logDGV.Columns["Date Performed"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
            }
        }

        public void SetFormLayout()
        {
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case Employee.UserRights.DepartmentAccess:
                    goto case Employee.UserRights.BaseUser;
                case Employee.UserRights.Executive:
                    goto case Employee.UserRights.BaseUser;
                case Employee.UserRights.BaseUser:
                    throw new UserAccessException("User is not allowed to access this page");
            }
            actionSelectorBox.Items.AddRange(Enum.GetNames(typeof(AuditTrail.Actions)));
            folderBrowserDialog.Description = "Select a folder in which to save the file.";
        }

        private async void actionSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await DisplayAuditLog();
        }

        private async void exportBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                Saving = true;
                if(!await Presenter.ExportToExcel(folderBrowserDialog.SelectedPath))
                {
                    MessageBox.Show("Unable to export data to Excel. Please try again.\nIf error persists, contact the IT Department.", "Error");
                }
                Saving = false;
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await DisplayAuditLog();
        }

        private async Task DisplayAuditLog()
        {
            this.UseWaitCursor = true;
            if (!await Presenter.DisplayLog())
                MessageBox.Show("Check to make sure that the dates are valid. \nStart date must be less than or equal to current date.");
            this.UseWaitCursor = false;
        }
    }
}
