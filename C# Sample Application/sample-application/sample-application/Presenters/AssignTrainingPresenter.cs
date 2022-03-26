using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class AssignTrainingPresenter
    {
        private IAssignTrainingView view;
        private HashSet<Employee> employeeSet = new HashSet<Employee>();

        public AssignTrainingPresenter(IAssignTrainingView assignView)
        {
            view = assignView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task InitForm()
        {
            view.AssignmentType = "Employee(s)"; //set default assignment type
            
        }

        /// <summary>
        /// Adds the selected employee to the displayed list
        /// </summary>
        /// <returns>true if the employee was added successfully, false otherwise</returns>
        public async Task<bool> AddEmployee()
        {
            if (!view.Employees.Contains(view.EmployeeSearchText)) //don't allow duplicates
            {
                if (await CommonFunctions.FilterEmployeeByUserAccess(view.EmployeeSearchText)) //make sure that the user didn't change the casing of the employeeid and that the user has access to perform the action
                {
                    List<string> employees = new List<string>(view.Employees);
                    //make sure that the Employee name has the correct casing when added to list
                    Employee employee = await CommonFunctions.GetEmployeeFromSelection(view.EmployeeSearchText);
                    employeeSet.Add(employee);
                    employees.Add(employee.Name + " - " + employee.Username);
                    view.Employees = employees;

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a training to the displayed list
        /// </summary>
        /// <returns>true if the training was added successfully, false otherwise</returns>
        public async Task<bool> AddTraining()
        {
            string trainingName = CommonFunctions.GetTrainingNameFromInput(view.SelectedTraining);
            if (!view.Trainings.Contains(view.SelectedTraining) && await CommonFunctions.FilterTrainingByUserRights(trainingName)) //don't allow duplicates and incorrect training names
            {
                List<string> trainings = new List<string>(view.Trainings);
                trainings.Add(trainingName + view.SelectedTraining.Substring(view.SelectedTraining.IndexOf(" ")));
                view.Trainings = trainings;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the selected employee from the displayed list
        /// </summary>
        public async Task RemoveEmployee()
        {
            await RemoveEmployee(view.EmployeeSearchText);
        }

        /// <summary>
        /// Removes the specified employee from the displayed list
        /// </summary>
        /// <param name="employee">employee to remove format: [name - userId]</param>
        public async Task RemoveEmployee(string employee)
        {
            List<string> employees = new List<string>(view.Employees);
            employees.Remove(employee);
            employeeSet.Remove(await CommonFunctions.GetEmployeeFromSelection(employee));
            view.Employees = employees;
        }

        /// <summary>
        /// removes the training from the displayed list
        /// </summary>
        /// <param name="training">training to remove format: [name - description]</param>
        public void RemoveTraining(string training)
        {
            List<string> trainings = new List<string>(view.Trainings);
            trainings.Remove(training);
            view.Trainings = trainings;
        }

        public void ResetEmployees()
        {
            view.Employees = new List<string>();
            employeeSet.Clear();
        }

        /// <summary>
        /// Assigns the selected trainings to the selected employees
        /// </summary>
        public async Task<bool> AssignTraining()
        {
            if (InputsAreValid())
            {
                try
                {
                    await AssignTrainings();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception while assigning training\n" + ex.Message + "\n" + ex.TargetSite + "\n" + ex.Source);
                    return false;
                }
                view.ClearUserInput();
                return true;
            }
            return false;
        }

        public async Task AddDepartmentEmployees()
        {
            employeeSet.Clear();
            List<Department> selectedDepartments = await GetSelectedDepartments();
            HashSet<string> employeeStrings = new HashSet<string>();
            await Task.Run(async () => 
            {
                foreach (Department department in selectedDepartments)
                {
                    if (!await IsRedundantDepartment(department, selectedDepartments))
                    {
                        List<Employee> deptEmployees = await department.GetEmployees();
                        foreach (Employee employee in deptEmployees)
                        {
                            employeeSet.Add(employee);
                            string employeeDataStr = employee.Name + " - " + employee.Username;
                            employeeStrings.Add(employeeDataStr);
                        }
                    }
                }
            });
            view.Employees = employeeStrings.ToList();
        }

        private async Task<bool> IsRedundantDepartment(Department department, List<Department> selectedDepartments)
        {
            List<Department> parentDepartments = await department.GetParentDepartments();

            foreach (Department parentDepartment in parentDepartments)
                if (IsSelected(parentDepartment, selectedDepartments))
                    return true;

            return false;
        }

        private bool IsSelected(Department department, List<Department> selectedDepartments)
        {
            foreach(Department selectedDept in selectedDepartments)
            {
                if (selectedDept.Id == department.Id)
                    return true;
            }
            return false;
        }



        private async Task AssignTrainings()
        {
            List<Training> trainings = await GetTrainings();
            await AssignToEmployees(trainings);

            if (view.AssignmentType == "Department")
                await AssignToDept(trainings);
        }

        private async Task AssignToEmployees(List<Training> trainings)
        {
            List<Task> tasks = new List<Task>();
            foreach (Employee employee in employeeSet)
            {
                await employee.AssignTrainings(trainings, view.DueDate, view.Required);
                tasks.Add(NotifyEmployee(employee));
            }
            await Task.WhenAll(tasks);
        }


        private async Task AssignToDept(List<Training> trainings)
        {
            List<Department> departments = await GetSelectedDepartments();
            foreach(Department department in departments)
            {
                if(!await IsRedundantDepartment(department, departments))
                {
                    foreach(Training training in trainings)
                    {
                        await department.AssignDeptTraining(training, view.Required);
                    }
                }
            }
        }

        /// <summary>
        /// Sends an email to each of the selected employees to notify them about the training assignment
        /// </summary>
        /// <param name="employees">employees to notify</param>
        private async Task Notify(List<Employee> employees)
        {
            List<string> recipients = new List<String>();
            foreach (Employee employee in employees)
                recipients.Add(employee.Email);

            await EmailSender.SendEmailAsync(recipients, null, config.EmailText.TrainingAssignedSubject,
                config.EmailText.GetTrainingAssignmentBody(view.Trainings, view.DueDate.ToShortDateString()), null);
        }

        private async Task NotifyEmployee(Employee employee)
        {
            List<string> recipients = new List<string>(){ employee.Email }; 
            await EmailSender.SendEmailAsync(recipients, null, config.EmailText.TrainingAssignedSubject,
                config.EmailText.GetTrainingAssignmentBody(view.Trainings, view.DueDate.ToShortDateString()), null);
        }

        /// <summary>
        /// checks to see if the user inputs are valid
        /// </summary>
        /// <returns>true if the user inputs are valid, otherwise returns false</returns>
        private bool InputsAreValid()
        {
            return ValidEmployeeSelection() && view.Trainings.Count > 0 && ValidAssignmentSelection() && IsValidDate();
        }

        private bool ValidEmployeeSelection()
        {
            return view.Employees.Count > 0;
        }

        private bool ValidAssignmentSelection()
        {
            return !(!view.AssignmentType.Equals("Employee(s)") && view.AssignmentSelection.Count == 0);
        }

        /// <summary>
        /// Checks to see if the user selected date is greater than or equal to the current date
        /// </summary>
        /// <returns>true if the user selected date is today or in the future, otherwise returns false</returns>
        private bool IsValidDate()
        {
            return DateFunctions.CompareDates(view.DueDate.ToShortDateString(), DateFunctions.GetCurrentDateString()) >= 0;
        }


        /// <summary>
        /// Gets the trainings from the User selection
        /// </summary>
        private async Task<List<Training>> GetTrainings()
        {
            List<Training> trainings = new List<Training>();
            foreach(string trainingStr in view.Trainings)
            {
                trainings.Add(await CommonFunctions.GetTrainingFromSelection(trainingStr));
            }
            return trainings;
        }

        /// <summary>
        /// Gets the employees from the user selection
        /// </summary>
        private async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            foreach(string employeeStr in view.Employees)
            {
                employees.Add(await CommonFunctions.GetEmployeeFromSelection(employeeStr));
            }
            return employees;
        }

        /// <summary>
        /// Gets the Departments from the user selection
        /// </summary>
        private async Task<List<Department>> GetSelectedDepartments()
        {
            List<Department> departments = new List<Department>();
            foreach(string departmentStr in view.AssignmentSelection)
            {
                departments.Add(await Department.GetDepartment(departmentStr));
            }
            return departments;
        }
    }
}
