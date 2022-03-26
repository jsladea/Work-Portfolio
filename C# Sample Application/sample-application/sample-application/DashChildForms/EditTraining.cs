using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Models;
using sampleApp.Presenters;
using sampleApp.Views;

namespace sampleApp
{
    public partial class EditTraining : Form, IEditTrainingView
    {
        public EditTraining()
        {
            InitializeComponent();
        }

        public EditTrainingPresenter Presenter { private get; set; }

        public void SetFormLayout()
        {
            throw new NotImplementedException();
        }
    }
}
