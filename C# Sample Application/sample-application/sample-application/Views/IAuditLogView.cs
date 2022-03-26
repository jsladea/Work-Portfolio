using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Models;
using sampleApp.Presenters;

namespace sampleApp.Views
{
    public interface IAuditLogView : IUserAccessibility
    {
        AuditLogPresenter Presenter { set; }

        AuditTrail.Actions SelectedAction { get; }

        DataTable AuditLogSource { set;}

        DateTime StartDate { get; }
        DateTime EndDate { get; }

    }
}
