using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace auto_reply3
{
    public partial class MailComposeRibbon
    {
        private void MailComposeRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector != null && inspector.CurrentItem is Outlook.MailItem mailItem)
            {
                ScheduleEmailForm scheduleForm = new ScheduleEmailForm(mailItem);
                scheduleForm.Show();
            }
        }
    }
}
