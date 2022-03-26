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
    public partial class ComprehensiveRecordViewer : SaveableForm, IComprehensiveView
    {

        public ComprehensiveRecordViewer()
        {
            InitializeComponent();
        }

        public ComprehensiveViewPresenter Presenter { set; private get; }

        public int SelectedEmployeeId
        {
            get
            {
                try
                {
                    string str = employeeSearchBox.Text;
                    str = str.Substring(str.IndexOf('-') + 2).Trim();
                    return int.Parse(str);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid employee entered. Please follow the format: <FirstName> <LastName> - <EmployeeId>");
                }
                return -1;
            }
        }

        public DataTable RecordTable { set => recordDGV.DataSource = value; }

        public async void SetFormLayout()
        {
            switch (ApplicationState.CurrentUser.UserAccess)
            {
                case UserRights.DepartmentAccess:
                    goto case UserRights.BaseUser;
                case UserRights.BaseUser:
                    throw new UserAccessException("User should not have access to this form.");
            }
            employeeSearchBox.AutoCompleteCustomSource.AddRange(await Presenter.GetAutoComplete());
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await Presenter.Display();
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
