using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class RemoveEmployeePresenter
    {

        IRemoveEmployeeView view;

        public RemoveEmployeePresenter(IRemoveEmployeeView view)
        {
            this.view = view;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> RemoveEmployee()
        {
            Employee employee = await Employee.GetEmployee(view.EmployeeId2);
            return await employee.Archive();
        }

        public async Task<bool> InputsAreValid()
        {
            return view.EmployeeId1 == view.EmployeeId2 && await Employee.Exists(view.EmployeeId2);
        }
    }
}
