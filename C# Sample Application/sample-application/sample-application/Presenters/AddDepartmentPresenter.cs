using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    

    public class AddDepartmentPresenter
    {
        private IAddDepartmentView view;

        public AddDepartmentPresenter(IAddDepartmentView addDeptView)
        {
            view = addDeptView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> CreateDepartment()
        {
            Employee manager = await CommonFunctions.GetEmployeeFromSelection(view.DepartmentManager);
            return await Department.CreateNewDepartment(view.DepartmentName, (short) manager.UserId, view.ParentDepartment);
        }
    }
}
