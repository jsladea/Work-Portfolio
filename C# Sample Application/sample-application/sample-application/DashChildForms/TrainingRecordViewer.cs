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
using sampleApp.Views;
using sampleApp.Common.CustomExceptions;
using PresentationControls;

namespace sampleApp
{
    public partial class TrainingRecordViewer : Form, ITrainingRecordViewer
    {
        private bool loadingRecords = false;

        public TrainingRecordViewer()
        {
            InitializeComponent();
        }

        public ViewTrainingRecordPresenter Presenter { private get; set; }
        public ViewType ViewBy {
            get
            {
                return ViewType.GetByName(viewBySelectorBox.GetItemText(viewBySelectorBox.SelectedItem));
            }
            set
            {
                viewBySelectorBox.SelectedItem = value.Name;
            }
        }

        public string SelectedView => viewTypeSelectorBox.GetItemText(viewTypeSelectorBox.SelectedItem);

        public string SelectedDepartment => deptSelectorBox.GetItemText(deptSelectorBox.SelectedItem);

        public List<string> SelectedEmployees
        {
            get
            {
                List<string> employees = new List<string>();
                foreach (CheckBoxComboBoxItem item in employeeSelectorBox.CheckBoxItems)
                    if (item.Checked)
                        employees.Add(item.Text);
                return employees;
            }
        }


        public string SelectedTraining { get => trainingSearchBox.GetItemText(trainingSearchBox.SelectedItem); set => trainingSearchBox.SelectedItem = value; }
        public DataTable TrainingRecord {
            set
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    recordsDGV.DataSource = value;
                });
            }
        }

        public async void SetFormLayout()
        {
            Employee currUser = ApplicationState.CurrentUser;

            string[] employeeSource;

            switch (currUser.UserAccess)
            {
                case Employee.UserRights.BaseUser:
                    throw new UserAccessException("Attempt to access TrainingRecordViewer with BaseUserAccess");
                case Employee.UserRights.DepartmentAccess:
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete(currUser.Department);
                    deptSelectorBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete(true));
                    break;
                default: //all users with access to management tab except Department managers should be able to see all UST Employee records
                    employeeSource = await CommonFunctions.GetUserIDNameAutoComplete();
                    deptSelectorBox.Items.AddRange(await CommonFunctions.GetDepartmentAutoComplete());
                    break;
            }

            employeeSelectorBox.AutoCompleteCustomSource.AddRange(employeeSource);
            employeeSelectorBox.Items.AddRange(employeeSource);
        }

        private void employeeSearchBtn_Click(object sender, EventArgs e)
        {

        }

        private void employeeSelectorBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                
        }


        private async void loadRecordsBtn_Click(object sender, EventArgs e)
        {
            if (!await LoadDGV())
                MessageBox.Show("Make sure that you have filled all fields.");
        }

        private void viewBySelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewBy == ViewType.Department)
            {
                employeeLbl.Visible = false;
                employeeSelectorBox.Visible = false;
                clearEmployeesBtn.Visible = false;

                deptSelectorBox.Visible = true;
                deptLbl.Visible = true;
            }
            else if(ViewBy == ViewType.Employee)
            {
                employeeLbl.Visible = true;
                employeeSelectorBox.Visible = true;
                clearEmployeesBtn.Visible = true;

                deptLbl.Visible = false;
                deptSelectorBox.Visible = false;
            }
        }

        private void SetVisibilty(bool viewByDept)
        {
            employeeLbl.Visible = !viewByDept;
            employeeSelectorBox.Visible = !viewByDept;
            clearEmployeesBtn.Visible = !viewByDept;

            deptSelectorBox.Visible = viewByDept;
            deptLbl.Visible = viewByDept;
        }

        private async void viewTypeSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDGV();
        }

        private async void deptSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDGV();
        }

        private async void employeeSelectorBox_SelectedValueChanged(object sender, EventArgs e)
        {
            await LoadDGV();
        }

        private void employeeSelectorBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (CheckBoxComboBoxItem item in employeeSelectorBox.CheckBoxItems)
                    if (item.Text == employeeSelectorBox.Text)
                        item.Checked = true;
            }
        }

        private void clearEmployeesBtn_Click(object sender, EventArgs e)
        {
            employeeSelectorBox.ClearSelection();
        }

        private async void TrainingRecordViewer_Shown(object sender, EventArgs e)
        {
            await Presenter.LoadTrainingMap();
        }

        private async Task<bool> LoadDGV()
        {
            if (!loadingRecords)
            {
                loadingRecords = true;
                this.UseWaitCursor = true;
                bool result = await Presenter.ShowSelectedView();
                this.UseWaitCursor = false;
                loadingRecords = false;
                return result;
            }
            return true;
        }
    }
}
