using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class AddEmployeePresenter
    {

        IAddEmployeeView view;

        public AddEmployeePresenter(IAddEmployeeView view)
        {
            this.view = view;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> AddEmployee()
        { 
            bool created = await EmployeeCreated();
            await AssignDeptTrainings();
            return created;
        }

        private async Task AssignDeptTrainings()
        {
            Employee employee = await Employee.GetEmployee(view.Username);
            Department dept = employee.Department;
            List<Training> requiredDeptTrainings = await dept.GetDeptAssignedTrainings(true);
            List<Training> optionalDeptTrainings = await dept.GetDeptAssignedTrainings(false);
            DateTime dueDate = DateTime.Today.AddMonths(1);
            await employee.AssignTrainings(requiredDeptTrainings, dueDate, true);
            await employee.AssignTrainings(optionalDeptTrainings, dueDate, false);
        }

        private async Task<bool> EmployeeCreated()
        {
            return await Employee.CreateNewEmployee(view.Username, view.FirstName, view.LastName, view.Department, view.JobTitle, (short)view.UserAccess, view.Email);
        }

        public bool AreValidInputs()
        {
            return IsValidUsername() && IsValid(view.FirstName) && IsValid(view.LastName)
                && IsValid(view.Department) && IsValid(view.JobTitle) && IsValidEmail(view.Email);
        }

        private bool IsValidEmail(string email)
        {
            return !IsValid(email) || CommonFunctions.IsValidEmailFormat(email);
        }

        private bool IsValidUsername()
        {
            return IsValid(view.Username) && !view.Username.Contains(" ") &&
                !view.Username.Contains("-") && !view.Username.Contains("/");
        }

        private bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

    }
}