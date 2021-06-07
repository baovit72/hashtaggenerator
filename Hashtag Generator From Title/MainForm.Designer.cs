namespace Hashtag_Generator_From_Title
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbKeyword = new System.Windows.Forms.TextBox();
            this.tbRelevantKeywords = new System.Windows.Forms.TextBox();
            this.tbInsertedKeywords = new System.Windows.Forms.TextBox();
            this.lbKeyword = new System.Windows.Forms.Label();
            this.lbRelevantKeywords = new System.Windows.Forms.Label();
            this.lbInsertedKeywords = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbFileInfo = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lb_tagInput = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbKeyword
            // 
            this.tbKeyword.Location = new System.Drawing.Point(132, 116);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(187, 20);
            this.tbKeyword.TabIndex = 0;
            this.tbKeyword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbRelevantKeywords
            // 
            this.tbRelevantKeywords.Location = new System.Drawing.Point(29, 187);
            this.tbRelevantKeywords.Multiline = true;
            this.tbRelevantKeywords.Name = "tbRelevantKeywords";
            this.tbRelevantKeywords.Size = new System.Drawing.Size(289, 155);
            this.tbRelevantKeywords.TabIndex = 0;
            // 
            // tbInsertedKeywords
            // 
            this.tbInsertedKeywords.Location = new System.Drawing.Point(339, 187);
            this.tbInsertedKeywords.Multiline = true;
            this.tbInsertedKeywords.Name = "tbInsertedKeywords";
            this.tbInsertedKeywords.Size = new System.Drawing.Size(287, 158);
            this.tbInsertedKeywords.TabIndex = 0;
            // 
            // lbKeyword
            // 
            this.lbKeyword.AutoSize = true;
            this.lbKeyword.Location = new System.Drawing.Point(29, 119);
            this.lbKeyword.Name = "lbKeyword";
            this.lbKeyword.Size = new System.Drawing.Size(48, 13);
            this.lbKeyword.TabIndex = 1;
            this.lbKeyword.Text = "Keyword";
            // 
            // lbRelevantKeywords
            // 
            this.lbRelevantKeywords.AutoSize = true;
            this.lbRelevantKeywords.Location = new System.Drawing.Point(26, 158);
            this.lbRelevantKeywords.Name = "lbRelevantKeywords";
            this.lbRelevantKeywords.Size = new System.Drawing.Size(99, 13);
            this.lbRelevantKeywords.TabIndex = 1;
            this.lbRelevantKeywords.Text = "Relevant Keywords";
            // 
            // lbInsertedKeywords
            // 
            this.lbInsertedKeywords.AutoSize = true;
            this.lbInsertedKeywords.Location = new System.Drawing.Point(336, 158);
            this.lbInsertedKeywords.Name = "lbInsertedKeywords";
            this.lbInsertedKeywords.Size = new System.Drawing.Size(94, 13);
            this.lbInsertedKeywords.TabIndex = 1;
            this.lbInsertedKeywords.Text = "Inserted Keywords";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(29, 25);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Open Title";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 435);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(597, 23);
            this.progressBar.TabIndex = 3;
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnBegin.Location = new System.Drawing.Point(29, 361);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(290, 55);
            this.btnBegin.TabIndex = 4;
            this.btnBegin.Text = "BEGIN";
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.DarkRed;
            this.btnStop.Location = new System.Drawing.Point(336, 361);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(290, 55);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbFileInfo
            // 
            this.lbFileInfo.AutoSize = true;
            this.lbFileInfo.Location = new System.Drawing.Point(123, 46);
            this.lbFileInfo.Name = "lbFileInfo";
            this.lbFileInfo.Size = new System.Drawing.Size(0, 13);
            this.lbFileInfo.TabIndex = 5;
            // 
            // lb_tagInput
            // 
            this.lb_tagInput.AutoSize = true;
            this.lb_tagInput.Location = new System.Drawing.Point(126, 93);
            this.lb_tagInput.Name = "lb_tagInput";
            this.lb_tagInput.Size = new System.Drawing.Size(0, 13);
            this.lb_tagInput.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Open Tag";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(651, 478);
            this.Controls.Add(this.lb_tagInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbFileInfo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lbInsertedKeywords);
            this.Controls.Add(this.lbRelevantKeywords);
            this.Controls.Add(this.lbKeyword);
            this.Controls.Add(this.tbInsertedKeywords);
            this.Controls.Add(this.tbRelevantKeywords);
            this.Controls.Add(this.tbKeyword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Hashtag Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbKeyword;
        private System.Windows.Forms.TextBox tbRelevantKeywords;
        private System.Windows.Forms.TextBox tbInsertedKeywords;
        private System.Windows.Forms.Label lbKeyword;
        private System.Windows.Forms.Label lbRelevantKeywords;
        private System.Windows.Forms.Label lbInsertedKeywords;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lbFileInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lb_tagInput;
        private System.Windows.Forms.Button button1;
    }
}

