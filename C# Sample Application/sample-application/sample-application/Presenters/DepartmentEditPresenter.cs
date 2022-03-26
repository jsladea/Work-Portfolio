using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class DepartmentEditPresenter
    {
        private IDeptEditView view;
        private Department selectedDepartment;

        public DepartmentEditPresenter(IDeptEditView deptView)
        {
            view = deptView;
            view.Presenter = this;

            view.SetFormLayout();
        }

        public async Task SetDepartment()
        {
            selectedDepartment = await Department.GetDepartment(view.SelectedDeptName);
        }

        public async Task<bool> SubmitChanges()
        {
            if(selectedDepartment != null)
            {
                Employee selectedManager = !string.IsNullOrWhiteSpace(view.SelectedManager) ? await CommonFunctions.GetEmployeeFromSelection(view.SelectedManager) : null;
                if (selectedManager != null)
                {
                    await selectedDepartment.SetManager(selectedManager.UserId);
                    return true;
                }
            }
            return false;
        }

        public async Task<string[]> GetDeptAutoComplete()
        {
            return await CommonFunctions.GetUserIDNameAutoComplete(selectedDepartment);
        }

        public async Task<string> GetCurrentManagerName()
        {
            if (selectedDepartment != null)
            {
                Employee manager = await selectedDepartment.GetManager();
                if(manager != null)
                    return manager.Name;
            }
            return "None";
        }

    }
}
