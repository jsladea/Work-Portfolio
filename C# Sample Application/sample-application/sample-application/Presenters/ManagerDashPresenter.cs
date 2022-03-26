using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{

    public class ManagerDashPresenter
    {
        private IManagementDashView view;

        public ManagerDashPresenter(IManagementDashView dashView)
        {
            view = dashView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task DisplayPendingTasks()
        {
            DataTable table = CreateBlankPendingTable();
            await FillPendingTable(table);
            view.PendingTasks = table;
        }

        public async Task<bool> SaveTrainingRecord(string trainingName, string employeeName, string quizAttempts, string score)
        {
            TrainingRecordCreator recordPrinter = new TrainingRecordCreator(trainingName, employeeName, quizAttempts, score, true); //change to true for publish!!!!
            string saveLocation = recordPrinter.SavePDF();

            TrainingRecord record = await CreateRecordObject(trainingName, employeeName, saveLocation);

            Console.WriteLine("\nAttempting EFile Save");

            EFileManager.EFileOperationResult result = await record.SaveToEFileAsync();

            Console.WriteLine("EFile Save Result: " + result + "\n");

            if(result == EFileManager.EFileOperationResult.Success)
            {
                await record.SaveRecordDB();
                return true;
            }
            return false;
        }

        private async Task<TrainingRecord> CreateRecordObject(string trainingName, string employeeStr, string saveLocation)
        {
            int employeeId = Int32.Parse(employeeStr.Substring(employeeStr.LastIndexOf(" ") + 1));
            Employee employee = await Employee.GetEmployee(employeeId);

            TrainingRecord record = new TrainingRecord(TrainingRecord.Type.Individual, employee.UserId);
            record.FileLocation = saveLocation;
            record.DateCompleted = DateTime.Now.Date;
            record.AddEmployee(employee);
            record.AddTraining(await Training.GetTraining(trainingName));

            return record;
        }

        private async Task FillPendingTable(DataTable pendingTable)
        {
            await Task.Run(async () =>
            {
                DataTable unformattedTable = await view.Department.GetQuizzesNeedingApproval();
                foreach (DataRow row in unformattedTable.Rows)
                {
                    await CreateRow(row, pendingTable);
                }
            });
        }

        private async Task CreateRow(DataRow row, DataTable pendingTable)
        {
            object[] values = row.ItemArray;
            Employee employee = await Employee.GetEmployee((short)values[0]);
            Training training = await Training.GetTraining((short)values[1]);

            DataRow newRow = pendingTable.NewRow();
            newRow[0] = employee.Name + " - " + employee.UserId;
            newRow[1] = training.Name; newRow[2] = training.Description;
            newRow[3] = (byte)values[2]; newRow[4] = Convert.ToDouble(values[3]);
            pendingTable.Rows.Add(newRow);
        }

        private DataTable CreateBlankPendingTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Employee Name", typeof(string));
            table.Columns.Add("Training Name", typeof(string));
            table.Columns.Add("Training Description", typeof(string));
            table.Columns.Add("Number of Attempts", typeof(int));
            table.Columns.Add("Score", typeof(double));

            return table;
        }
    }
}
