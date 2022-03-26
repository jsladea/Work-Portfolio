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
    public partial class ManagementDash : Form, IManagementDashView
    {
        public ManagementDash()
        {
            InitializeComponent();
        }

        public ManagerDashPresenter Presenter { set; private get; }
        public DataTable PendingTasks { set => pendingTasksDGV.DataSource = value; }
        public int PercentTrainingCompleted { set => throw new NotImplementedException(); }
        public Department Department { get; private set; }

        public async void SetFormLayout()
        {
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this page.");
                case UserRights.DocControl:
                    Department = await Department.GetDepartment("UST");
                    break;
                case UserRights.AdminAccess:
                    goto case UserRights.DocControl;
                case UserRights.DepartmentAccess:
                    Department = ApplicationState.CurrentUser.Department;
                    break;
            }
        }

        private async void reloadPendingBtn_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            await Presenter.DisplayPendingTasks();
            this.UseWaitCursor = false;
        }

        private async void ManagementDash_Shown(object sender, EventArgs e)
        {
            //await Presenter.DisplayPendingTasks();
        }

        private async void pendingTasksDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int trainingColIndex = pendingTasksDGV.Columns["Training Name"].Index;
                int employeeColIndex = pendingTasksDGV.Columns["Employee Name"].Index;
                int attemptColIndex = pendingTasksDGV.Columns["Number of Attempts"].Index;
                int scoreColIndex = pendingTasksDGV.Columns["Score"].Index;
                string trainingName = pendingTasksDGV.Rows[rowIndex].Cells[trainingColIndex].Value.ToString();
                string employeeName = pendingTasksDGV.Rows[rowIndex].Cells[employeeColIndex].Value.ToString();
                string attempts = pendingTasksDGV.Rows[rowIndex].Cells[attemptColIndex].Value.ToString();
                string score = pendingTasksDGV.Rows[rowIndex].Cells[scoreColIndex].Value.ToString() + "%";

                await ApproveRecord(trainingName, employeeName, attempts, score);
            }
        }


        private async Task ApproveRecord(string trainingName, string employeeName, string attempts, string score)
        {
            bool approve = MessageBox.Show("Do you wish to approve this training?", "Approve", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (approve)
            {
                DialogResult approvalResult = MessageBox.Show(String.Format("By clicking Yes, I certify that I have talked with {0} with respect to training {1},\n" +
                    "and that I have confidence in their comprehension and understanding of the training material.",employeeName.Substring(0, employeeName.IndexOf(" -")), trainingName), "Approve Training", MessageBoxButtons.YesNoCancel);
                if(approvalResult == DialogResult.Yes)
                {
                    if (await Presenter.SaveTrainingRecord(trainingName, employeeName, attempts, score))
                        MessageBox.Show("Record Saved Successfully", "Confirmation");
                    else
                        MessageBox.Show("Error while saving record.  Please try again.\n If error persists, contact the IT department.", "Error");
                }
            }

            
        }
    }
}
