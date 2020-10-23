namespace WinTest
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.GProBrowser = new System.Windows.Forms.WebBrowser();
            this.GProDataOutput = new System.Windows.Forms.RichTextBox();
            this.CalcBrowser = new System.Windows.Forms.WebBrowser();
            this.CalcDataOutput = new System.Windows.Forms.RichTextBox();
            this.Load = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SaveList = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.CalcCarWear = new System.Windows.Forms.Button();
            this.webView1 = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scrape GProData";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GProBrowser
            // 
            this.GProBrowser.Location = new System.Drawing.Point(103, 12);
            this.GProBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.GProBrowser.Name = "GProBrowser";
            this.GProBrowser.Size = new System.Drawing.Size(1287, 276);
            this.GProBrowser.TabIndex = 1;
            // 
            // GProDataOutput
            // 
            this.GProDataOutput.Location = new System.Drawing.Point(1396, 12);
            this.GProDataOutput.Name = "GProDataOutput";
            this.GProDataOutput.Size = new System.Drawing.Size(297, 276);
            this.GProDataOutput.TabIndex = 2;
            this.GProDataOutput.Text = "";
            // 
            // CalcBrowser
            // 
            this.CalcBrowser.Location = new System.Drawing.Point(103, 294);
            this.CalcBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.CalcBrowser.Name = "CalcBrowser";
            this.CalcBrowser.Size = new System.Drawing.Size(1287, 58);
            this.CalcBrowser.TabIndex = 3;
            // 
            // CalcDataOutput
            // 
            this.CalcDataOutput.Location = new System.Drawing.Point(1396, 294);
            this.CalcDataOutput.Name = "CalcDataOutput";
            this.CalcDataOutput.Size = new System.Drawing.Size(297, 561);
            this.CalcDataOutput.TabIndex = 4;
            this.CalcDataOutput.Text = "";
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(22, 309);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 5;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Showdata";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SaveList
            // 
            this.SaveList.Location = new System.Drawing.Point(22, 338);
            this.SaveList.Name = "SaveList";
            this.SaveList.Size = new System.Drawing.Size(75, 23);
            this.SaveList.TabIndex = 7;
            this.SaveList.Text = "SaveList";
            this.SaveList.UseVisualStyleBackColor = true;
            this.SaveList.Click += new System.EventHandler(this.Calc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "DumpData";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 412);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CalcCarWear
            // 
            this.CalcCarWear.Location = new System.Drawing.Point(22, 463);
            this.CalcCarWear.Name = "CalcCarWear";
            this.CalcCarWear.Size = new System.Drawing.Size(75, 23);
            this.CalcCarWear.TabIndex = 10;
            this.CalcCarWear.Text = "CarWear";
            this.CalcCarWear.UseVisualStyleBackColor = true;
            this.CalcCarWear.Click += new System.EventHandler(this.CalcCarWear_Click);
            // 
            // webView1
            // 
            this.webView1.Location = new System.Drawing.Point(104, 359);
            this.webView1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webView1.Name = "webView1";
            this.webView1.Size = new System.Drawing.Size(1286, 250);
            this.webView1.TabIndex = 11;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 124);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1705, 867);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.webView1);
            this.Controls.Add(this.CalcCarWear);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SaveList);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.CalcDataOutput);
            this.Controls.Add(this.CalcBrowser);
            this.Controls.Add(this.GProDataOutput);
            this.Controls.Add(this.GProBrowser);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "GPro Autopilot";
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser GProBrowser;
        private System.Windows.Forms.RichTextBox GProDataOutput;
        private System.Windows.Forms.WebBrowser CalcBrowser;
        private System.Windows.Forms.RichTextBox CalcDataOutput;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button SaveList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button CalcCarWear;
        [System.Obsolete]
        private Microsoft.Toolkit.Forms.UI.Controls.WebView webView1;
        private System.Windows.Forms.Button button5;
    }
}

