using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Models.CSVIO;
using sampleApp.Views;

namespace sampleApp.Presenters
{
    public class AuditLogPresenter
    {
        private IAuditLogView view;
        private DataTable currDataSource;
        private bool exporting = false;

        public AuditLogPresenter(IAuditLogView auditLogView)
        {
            view = auditLogView;
            view.Presenter = this;
            view.SetFormLayout();
        }

        public async Task<bool> DisplayLog()
        {
            if (AreValidDates())
            {
                currDataSource = await AuditTrail.GetAuditLog(view.StartDate, view.EndDate.AddDays(1), view.SelectedAction);
                view.AuditLogSource = currDataSource;
                return true;
            }
            return false;
        }

        private bool AreValidDates()
        {
            return view.StartDate.CompareTo(view.EndDate) <= 0 && view.StartDate.CompareTo(DateTime.Now) <= 0;
        }

        public async Task<bool> ExportToExcel(string directory)
        {
            if (exporting)
                return false;
            exporting = true;
            string currTime = DateTime.Now.ToString().Replace(":", "-").Replace("/", "").Replace(" ", "");
            string filepath = directory.Replace("\\", "/") + "/AuditLog-" + currTime + ".csv";
            if (currDataSource != null)
            {
                return await CommonFunctions.ExportToExcel(currDataSource, filepath);
            }
            return false;
        }
    }
}
