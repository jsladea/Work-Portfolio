using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Common;
using sampleApp.config;
using sampleApp.Models;
using sampleApp.Views;

using static sampleApp.Models.EFileManager;

namespace sampleApp.Presenters
{
    public class AddTrainingRecordPresenter
    {
        private SQLDatabaseManager dbManager = new SQLDatabaseManager();
        private IAddTrainingRecordView view;

        public enum OperationResult {EFileLoginFailure, Success, Failure, RuntimeException, EFileCabinetNotFound,
            DatabaseFailure, InvalidInputs}

        public AddTrainingRecordPresenter(IAddTrainingRecordView view, string trainingType)
        {
            this.view = view;
            this.view.RecordPresenter = this;
            view.TrainingType = trainingType;
            view.ChangeLayoutForType();
        }

        public void InitForm()
        {
            view.SetFormLayout();
        }

        public void RemoveEmployee()
        {
            RemoveEmployee(view.EmployeeSearchText);
        }

        public void RemoveEmployee(string employee)
        {
            List<string> employees = new List<string>(view.Employees);
            employees.Remove(employee);
            view.Employees = employees;
        }


        public void RemoveTraining()
        {
            RemoveTraining(view.TrainingSearchText);
        }

        public void RemoveTraining(string training)
        {
            List<string> trainings = new List<string>(view.Trainings);
            trainings.Remove(training);
            view.Trainings = trainings;
        }


        public async Task<bool> AddEmployee()
        {
            if (!view.Employees.Contains(view.EmployeeSearchText) && (view.TrainingType == "Group" || view.Employees.Count == 0)) //don't allow duplicates or more than one employee for individual records
            {
                if (await CommonFunctions.FilterEmployeeByUserAccess(view.EmployeeSearchText)) //make sure that the user didn't change the casing of the employeeid and that user has access to modify training record of that employee
                {
                    List<string> employees = new List<string>(view.Employees);
                    //make sure that the Employee name has the correct casing when added to list
                    Employee employee = await CommonFunctions.GetEmployeeFromSelection(view.EmployeeSearchText);  
                    employees.Add(employee.Name + " - " + employee.Username);
                    view.Employees = employees;

                    return true;
                }
            }
            return false;
        }

        

        public async Task<bool> AddTraining()
        {
            if (!view.Trainings.Contains(view.TrainingSearchText)) //don't allow duplicates and incorrect training names
            {
                string trainingName = CommonFunctions.GetTrainingNameFromInput(view.TrainingSearchText).ToUpper();
                if (await Training.Exists(trainingName))
                {
                    List<string> trainings = new List<string>(view.Trainings);
                    trainings.Add(trainingName + view.TrainingSearchText.Substring(view.TrainingSearchText.IndexOf(" ")));
                    view.Trainings = trainings;
                    return true;
                }
            }
            return false;
        }



        public async Task<OperationResult> AddRecord()
        {
            if (await AreValidInputs()) //if the form fields contain valid data
            {
                TrainingRecord record = await CreateRecord();

                EFileOperationResult eFileSaveResult = await record.SaveToEFileAsync();

                if(eFileSaveResult == EFileOperationResult.Success) //if the training record saved successfully
                {
                    await record.SaveRecordDB(); //update database records to reflect training completion
                    return OperationResult.Success;
                }

                return CvtEFileResult(eFileSaveResult);

            }

            return OperationResult.InvalidInputs;
        }

        private async Task<TrainingRecord> CreateRecord(){
            TrainingRecord.Type trainingType = GetViewTrainingType();
            int trainerId = (await CommonFunctions.GetEmployeeFromSelection(view.TrainerSearchText)).UserId;
            TrainingRecord record = new TrainingRecord(trainingType, trainerId);

            record.FileLocation = view.Filepath.Replace("\\", "/");
            record.DateCompleted = view.DateCompleted;

            List<Employee> employees = await GetEmployees();

            record.AddEmployees(employees);
            record.AddTrainings(await GetTrainings());

            Console.WriteLine("Adding Training Record: " + record);

            return record;
        }

        private OperationResult CvtEFileResult(EFileOperationResult eFileResult)
        {
            switch (eFileResult)
            {
                case EFileOperationResult.CabinetNotFound:
                    return OperationResult.EFileCabinetNotFound;
                case EFileOperationResult.Failure:
                    return OperationResult.Failure;
                case EFileOperationResult.LoginFail:
                    return OperationResult.EFileLoginFailure;
                case EFileOperationResult.RuntimeException:
                    return OperationResult.RuntimeException;
                case EFileOperationResult.Success:
                    return OperationResult.Success;
            }
            return OperationResult.Failure;
        }


        public void AttachFile()
        {
            string filepath = view.GetFile();
            view.Filepath = filepath;
        }

        public void PrintTrainingRecord()
        {
            if (view.ShowPrintDialog())
            {

                //add only training names and employee names to the training record form
                List<string> trainingNames = new List<String>();
                foreach (string training in view.Trainings)
                    trainingNames.Add(training.Split('-')[0].Trim());

                List<string> employeeNames = new List<String>();
                foreach (string employee in view.Employees)
                    employeeNames.Add(employee.Split('-')[0].Trim());

                TrainingRecordCreator printer = new TrainingRecordCreator(trainingNames, employeeNames, view.DateCompleted.ToShortDateString());
                printer.CreateTrainingRecord();

                printer.PrintTrainingRecord(view.PrintSettings);
            }
        }

        private TrainingRecord.Type GetViewTrainingType()
        {
            return view.TrainingType.Equals("Group") ? TrainingRecord.Type.Group : TrainingRecord.Type.Individual;
        }


        private async Task<bool> AreValidInputs()
        {
            bool validEmployeeNum = view.Employees.Count >= 1;
            if (GetViewTrainingType() == TrainingRecord.Type.Individual)
                validEmployeeNum = validEmployeeNum && !(view.Employees.Count > 1); //false if the training type is individual and there is more than one employee
            else
                validEmployeeNum = validEmployeeNum && !(view.Employees.Count == 1); //false if the training type is group and there is only one employee

            //if there are trainings and a valid number of employees
            return view.Trainings.Count > 0 && validEmployeeNum
                && DateFunctions.CompareDates(view.DateCompleted.ToShortDateString(), DateFunctions.GetCurrentDateString()) <= 0 //if the selected date is valid
                     && !string.IsNullOrWhiteSpace(view.TrainerSearchText) && await CommonFunctions.IsValidEmployeeUsername(view.TrainerSearchText)
                     && !string.IsNullOrWhiteSpace(view.Filepath); //if user has selected a training record file
        }


        private async Task UpdateEmployeeRecords(TrainingRecord record)
        {
            List<Task> addRecordTasks = new List<Task>();
            foreach (Employee employee in record.GetEmployeesCopy())
                addRecordTasks.Add(employee.AddTrainingRecord(record));

            await Task.WhenAll(addRecordTasks);
        }
        
        /// <summary>
        /// Creates and returns a list of Training objects from the user selection
        /// </summary>
        /// <returns>List of Trainings</returns>
        private async Task<List<Training>> GetTrainings()
        {
            List<Training> trainings = new List<Training>();
            foreach(string training in view.Trainings)
            {
                trainings.Add(await CommonFunctions.GetTrainingFromSelection(training));
            }
            return trainings;
        }

        /// <summary>
        /// Creates and returns a list of Employee objects from the user selection
        /// </summary>
        /// <returns>List of Employees trained</returns>
        private async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            foreach (string employeeStr in view.Employees)
            {
                Employee employee = await CommonFunctions.GetEmployeeFromSelection(employeeStr);
                employees.Add(employee);
            }
            return employees;
        }

    }
}