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
    public partial class DepartmentView : SaveableForm, IDepartmentView
    {

        private bool loading = false;

        public DepartmentView()
        {
            InitializeComponent();

        }

        public DepartmentViewPresenter Presenter { private get; set; }

        public string Department
        {
            get => deptSelectorBox.GetItemText(deptSelectorBox.SelectedItem);
        }

        public DataTable EmpTrainingsData
        {
            set => BeginInvoke((MethodInvoker)(() => {
                deptEmpDGV.DataSource = value;
                deptEmpDGV.Columns["Required For"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }));

        }

        public DataTable DeptTrainingsData
        {
            set => BeginInvoke((MethodInvoker)(() =>
            {
                deptDGV.DataSource = value;
                deptDGV.Columns["Assigned Trainings"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                deptDGV.Columns["Employees"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }));
        }

        public async void SetFormLayout()
        {
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this form.");
                case UserRights.DepartmentAccess:
                    deptSelectorBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete(true));
                    break;
                default:
                    deptSelectorBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete());
                    break;
            }
        }

        private async void deptSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                this.UseWaitCursor = true;
                await Presenter.DisplayEmpData();
                await Presenter.DisplayDeptData();
                this.UseWaitCursor = false;
                loading = false;
            }
            else
            {
                MessageBox.Show("Currently Loading last selection. Please wait, then reselect a department.", "Loading");
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Presenter.ShowAssignRequiredTrainingForm();
        }

        private async void deptDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int trainingColIndex = deptEmpDGV.Columns["Training"].Index;
                await Presenter.ShowInDepth(deptEmpDGV.Rows[e.RowIndex].Cells[trainingColIndex].Value.ToString());
            }
        }

        private async void exportBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Saving = true;
                if (!await Presenter.Export(folderBrowserDialog.SelectedPath))
                    MessageBox.Show("Unable to export file. Please try again and contact IT Department if error persists.", "Error");
                Saving = false;
            }


        }
    }
}
