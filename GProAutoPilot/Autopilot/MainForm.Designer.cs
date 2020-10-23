namespace Autopilot
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TrackData = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateGproData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RaceData = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CarData = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DriverData = new System.Windows.Forms.RichTextBox();
            this.Drivers = new System.Windows.Forms.ComboBox();
            this.WorkingBrowser = new System.Windows.Forms.WebBrowser();
            this.BasicSetup = new System.Windows.Forms.Button();
            this.RaceDataEditor = new System.Windows.Forms.RichTextBox();
            this.LoadDriverProfile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadDriverProfile);
            this.groupBox1.Controls.Add(this.TrackData);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UpdateGproData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RaceData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CarData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DriverData);
            this.groupBox1.Controls.Add(this.Drivers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPro Data";
            // 
            // TrackData
            // 
            this.TrackData.Location = new System.Drawing.Point(528, 189);
            this.TrackData.Name = "TrackData";
            this.TrackData.Size = new System.Drawing.Size(241, 81);
            this.TrackData.TabIndex = 9;
            this.TrackData.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Track data";
            // 
            // UpdateGproData
            // 
            this.UpdateGproData.Location = new System.Drawing.Point(7, 276);
            this.UpdateGproData.Name = "UpdateGproData";
            this.UpdateGproData.Size = new System.Drawing.Size(763, 23);
            this.UpdateGproData.TabIndex = 7;
            this.UpdateGproData.Text = "Update GPro data";
            this.UpdateGproData.UseVisualStyleBackColor = true;
            this.UpdateGproData.Click += new System.EventHandler(this.UpdateGproData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Race data";
            // 
            // RaceData
            // 
            this.RaceData.Location = new System.Drawing.Point(529, 68);
            this.RaceData.Name = "RaceData";
            this.RaceData.Size = new System.Drawing.Size(241, 90);
            this.RaceData.TabIndex = 5;
            this.RaceData.Text = "";
            this.RaceData.DoubleClick += new System.EventHandler(this.DriverData_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Car data";
            // 
            // CarData
            // 
            this.CarData.Location = new System.Drawing.Point(262, 68);
            this.CarData.Name = "CarData";
            this.CarData.Size = new System.Drawing.Size(261, 202);
            this.CarData.TabIndex = 3;
            this.CarData.Text = "";
            this.CarData.DoubleClick += new System.EventHandler(this.DriverData_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Driver data";
            // 
            // DriverData
            // 
            this.DriverData.Location = new System.Drawing.Point(7, 68);
            this.DriverData.Name = "DriverData";
            this.DriverData.Size = new System.Drawing.Size(249, 202);
            this.DriverData.TabIndex = 1;
            this.DriverData.Text = "";
            this.DriverData.DoubleClick += new System.EventHandler(this.DriverData_DoubleClick);
            // 
            // Drivers
            // 
            this.Drivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Drivers.FormattingEnabled = true;
            this.Drivers.Location = new System.Drawing.Point(6, 19);
            this.Drivers.Name = "Drivers";
            this.Drivers.Size = new System.Drawing.Size(339, 21);
            this.Drivers.TabIndex = 0;
            // 
            // WorkingBrowser
            // 
            this.WorkingBrowser.Location = new System.Drawing.Point(794, 14);
            this.WorkingBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WorkingBrowser.Name = "WorkingBrowser";
            this.WorkingBrowser.Size = new System.Drawing.Size(794, 665);
            this.WorkingBrowser.TabIndex = 1;
            // 
            // BasicSetup
            // 
            this.BasicSetup.Location = new System.Drawing.Point(12, 656);
            this.BasicSetup.Name = "BasicSetup";
            this.BasicSetup.Size = new System.Drawing.Size(776, 23);
            this.BasicSetup.TabIndex = 3;
            this.BasicSetup.Text = "Calc basic setup";
            this.BasicSetup.UseVisualStyleBackColor = true;
            this.BasicSetup.Click += new System.EventHandler(this.BasicSetup_Click);
            // 
            // RaceDataEditor
            // 
            this.RaceDataEditor.Location = new System.Drawing.Point(18, 326);
            this.RaceDataEditor.Name = "RaceDataEditor";
            this.RaceDataEditor.Size = new System.Drawing.Size(763, 324);
            this.RaceDataEditor.TabIndex = 4;
            this.RaceDataEditor.Text = "";
            this.RaceDataEditor.TextChanged += new System.EventHandler(this.RaceDataEditor_TextChanged);
            this.RaceDataEditor.DoubleClick += new System.EventHandler(this.RaceDataEditor_DoubleClick);
            // 
            // LoadDriverProfile
            // 
            this.LoadDriverProfile.Location = new System.Drawing.Point(352, 20);
            this.LoadDriverProfile.Name = "LoadDriverProfile";
            this.LoadDriverProfile.Size = new System.Drawing.Size(75, 23);
            this.LoadDriverProfile.TabIndex = 10;
            this.LoadDriverProfile.Text = "Load";
            this.LoadDriverProfile.UseVisualStyleBackColor = true;
            this.LoadDriverProfile.Click += new System.EventHandler(this.LoadDriverProfile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 686);
            this.Controls.Add(this.RaceDataEditor);
            this.Controls.Add(this.BasicSetup);
            this.Controls.Add(this.WorkingBrowser);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Gpro Autopilot ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Drivers;
        private System.Windows.Forms.Button UpdateGproData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RaceData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox CarData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox DriverData;
        private System.Windows.Forms.WebBrowser WorkingBrowser;
        private System.Windows.Forms.RichTextBox TrackData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BasicSetup;
        private System.Windows.Forms.RichTextBox RaceDataEditor;
        private System.Windows.Forms.Button LoadDriverProfile;
    }
}

