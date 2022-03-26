using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Presenters;

namespace sampleApp.CustomControls.HelpLink
{
    public class HelpLink : LinkLabel
    {

        public HelpLink()
        {
            LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelClicked);
            Text = "Help";
        }

        private void LinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(config.FileLocations.HelpMenuFilePath);
            MessageBox.Show("The help menu has been opened in your web browser.", "Help Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
