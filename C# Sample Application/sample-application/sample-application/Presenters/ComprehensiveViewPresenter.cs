using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class ComprehensiveViewPresenter
    {
        private IComprehensiveView view;
        private Dictionary<int, Employee> employeeMap;
        private DataTable currDataSource;
        private bool exporting = false;

        public ComprehensiveViewPresenter(IComprehensiveView comprehensiveView)
        {
            view = comprehensiveView;
            view.Presenter = this;
            view.SetFormLayout(); 
        }

        public async Task<string[]> GetAutoComplete()
        {
            employeeMap = await Employee.GetComprehensiveMap();
            string[] employeeStrings = new string[employeeMap.Count];
            int i = 0;
            foreach(int id in employeeMap.Keys)
            {
                employeeStrings[i++] = employeeMap[id].Name + " - " + id;
            }
            return employeeStrings;
        }

        public async Task Display()
        {
            int employeeId = view.SelectedEmployeeId;
            if (employeeId != -1)
            {
                currDataSource = await GetComprehensiveDataTable(employeeMap[view.SelectedEmployeeId]);
                view.RecordTable = currDataSource;
            }
        }

        private DataTable GetBlankTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Completion Date", typeof(DateTime));
            table.Columns.Add("Training", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Revision", typeof(double));
            table.Columns.Add("TrainerId", typeof(int));
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            return table;
        }

        private async Task<DataTable> GetComprehensiveDataTable(Employee employee)
        {
            DataTable employeeRecord = await employee.GetComprehensiveData();
            DataTable table = GetBlankTable();

            foreach(DataRow row in employeeRecord.Rows)
            {
                object[] values = row.ItemArray;
                DataRow newRow = table.NewRow();
                for(int i = 0; i < values.Length; i++)
                {
                    if (i == 4) //revision
                        newRow[i] = Math.Round(Convert.ToDouble(values[i]), 4);
                    else
                        newRow[i] = values[i];
                }
                table.Rows.Add(newRow);
            }

            return table;
        }

        public async Task<bool> Export(string directory)
        {
            if(currDataSource != null && !exporting)
            {
                exporting = true;
                string currTime = DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Trim();
                string filepath = directory + "/" + view.SelectedEmployeeId + "-ComprehensiveRecord-" + currTime + ".csv";
                bool result = await CommonFunctions.ExportToExcel(currDataSource, filepath);
                return result;
            }
            return false;
        }

    }
}
