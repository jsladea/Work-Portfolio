using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class EmployeeEditPresenter
    {
        private IEditEmployeeView view;
        private Employee selectedEmployee;

        public EmployeeEditPresenter(IEditEmployeeView editView)
        {
            view = editView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> SaveEmployee()
        {
            if (selectedEmployee != null)
            {
                Department department = await Department.Exists(view.DepartmentName) ? await Department.GetDepartment(view.DepartmentName) : selectedEmployee.Department;
                string email;
                if (!string.IsNullOrWhiteSpace(view.Email))
                {
                    if (CommonFunctions.IsValidEmailFormat(view.Email))
                        email = view.Email;
                    else
                        return false;
                }
                else
                    email = selectedEmployee.Email;
                
                string jobTitle = selectedEmployee.JobTitle;
                bool result =  await selectedEmployee.Update(department, jobTitle, email, view.AccessLevel);
                selectedEmployee = null;
                return result;
            }
            return false;
        }

        public async Task<bool> ChangeUsername()
        {
            if (selectedEmployee != null)
                return await selectedEmployee.ChangeUsername(view.NewUsername);
            return false;
        }
        

        public async Task<bool> SearchEmployee()
        {
            string username = view.EmployeeUsername;
            if (!string.IsNullOrEmpty(username) && await Employee.Exists(username))
            {
                selectedEmployee = await Employee.GetEmployee(username);
                view.SetOldDepartment(selectedEmployee.Department.Name);
                view.SetOldEmail(selectedEmployee.Email);
                view.SetOldAccessLevel(selectedEmployee.UserAccess);
                view.SelectedEmployee = selectedEmployee.Name;
                return true;
            }
            return false;
        }

        public async Task<string> ResetPassword()
        {
            if(selectedEmployee != null)
            {
                return await UserAuthentication.SetTemporaryPassword(selectedEmployee.UserId);
            }
            
            return "Error. Please make sure that an employee is selected. (Make sure to click \"Search\")";
        }

    }
}
