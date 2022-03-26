using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class UnassignTrainingPresenter
    {

        private IUnassignTrainingView view;

        public UnassignTrainingPresenter(IUnassignTrainingView view)
        {
            this.view = view;
            view.Presenter = this;
            view.SetFormLayout();
        }


        public async Task<bool> UnassignTraining()
        {
            if(!string.IsNullOrWhiteSpace(view.UnassignmentSelection) && !string.IsNullOrWhiteSpace(view.SelectedTraining))
            {
                Training selectedTraining = await CommonFunctions.GetTrainingFromSelection(view.SelectedTraining);
                if (view.UnassignBy == "Employee")
                {
                    Employee selectedEmployee = await CommonFunctions.GetEmployeeFromSelection(view.UnassignmentSelection);
                    await selectedEmployee.UnassignTraining(selectedTraining);
                }
                else
                {
                    Department selectedDepartment = await Department.GetDepartment(view.UnassignmentSelection);
                    await selectedDepartment.UnassignTraining(selectedTraining);
                    if(ShouldUnassignFromEmployees())
                        await UnassignFromDeptEmployees(selectedDepartment, selectedTraining);
                }
                return true;
            }
            return false;
        }

        private bool ShouldUnassignFromEmployees() //in the future this should be refactored and placed in the view. It doesn't belong in the presenter.
        {
            DialogResult result = MessageBox.Show("The training has been removed from the training list for that department.\n" +
                "Do you wish to unassign the training from the current employees of the department?\n This cannot be undone without the IT department.",
                "Unassign From Department Employees?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            return result == DialogResult.Yes;
        }

        private async Task UnassignFromDeptEmployees(Department dept, Training training)
        {
            List<Employee> employees = await dept.GetEmployees();
            foreach(Employee employee in employees)
            {
                await employee.UnassignTraining(training);
            }
        }

    }
}