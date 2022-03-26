using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Models;

namespace sampleApp
{
    public class SaveableForm : Form
    {

        public SaveableForm()
        {
            Saving = false;
            ApplicationState.AddSaveableForm(this);
        }

        public bool Saving { get; protected set; }
    }
}
