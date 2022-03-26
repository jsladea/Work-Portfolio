using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sampleApp.AuthenticationForms
{
    public partial class GetUsernameControl : UserControl
    {

        public string Username { get; private set; }

        public GetUsernameControl()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameBox.Text))
            {
                Username = usernameBox.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("You must enter a username.", "Invalid User Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
