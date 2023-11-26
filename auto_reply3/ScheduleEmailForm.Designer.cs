namespace auto_reply3
{
    partial class ScheduleEmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.Schedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(36, 27);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTime.TabIndex = 0;
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(36, 74);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDate.TabIndex = 1;
            // 
            // Schedule
            // 
            this.Schedule.Location = new System.Drawing.Point(86, 241);
            this.Schedule.Name = "Schedule";
            this.Schedule.Size = new System.Drawing.Size(75, 23);
            this.Schedule.TabIndex = 2;
            this.Schedule.Text = "Schedule";
            this.Schedule.UseVisualStyleBackColor = true;
            this.Schedule.Click += new System.EventHandler(this.Schedule_Click);
            // 
            // ScheduleEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 276);
            this.Controls.Add(this.Schedule);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.dateTimePickerTime);
            this.Name = "ScheduleEmailForm";
            this.Text = "ScheduleEmailForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Button Schedule;
    }
}