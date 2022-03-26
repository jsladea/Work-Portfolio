using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sampleApp.DashChildForms.Popups
{
    public partial class DeptTrainingPopup : Form
    {
        public DeptTrainingPopup(string deptName, string trainingName)
        {
            InitializeComponent();
            deptLbl.Text = "Department: " + deptName;
            trainingLbl.Text = "Training: " + trainingName;
        }

        public void DisplayData(DataTable table)
        {
            trainingDGV.DataSource = table;
            trainingDGV.Columns["Employees"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
    }
}
