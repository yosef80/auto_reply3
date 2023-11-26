using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace auto_reply3
{
    public partial class ScheduleEmailForm : Form
    {
        private readonly Outlook.MailItem _mailItem;

        public ScheduleEmailForm(Outlook.MailItem mailItem)
        {
            InitializeComponent();
            _mailItem = mailItem;
            dateTimePickerDate.MinDate = DateTime.Now;
            dateTimePickerTime.MinDate = DateTime.Now;
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickerDate.Value.Date;
            DateTime selectedTime = dateTimePickerTime.Value;
            DateTime scheduleTime = selectedDate.Add(selectedTime.TimeOfDay);

            if (scheduleTime < DateTime.Now)
            {
                MessageBox.Show("Please select a future date and time.");
                return;
            }

 

            if (_mailItem != null)
            {
                try
                {
                    // Schedule the email using the Outlook Object Model
                    _mailItem.DeferredDeliveryTime = scheduleTime;

                    // Save the changes to the mail item
                    _mailItem.Save();
                    

                    MessageBox.Show("Email scheduled for " + scheduleTime.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error scheduling email: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No email item is associated with this form.");
            }

            this.Close();
        }

      

    }
}
