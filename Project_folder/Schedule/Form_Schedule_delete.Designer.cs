namespace 비프
{
    partial class Form_Schedule_delete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Schedule_delete));
            this.label_inmonth = new System.Windows.Forms.Label();
            this.wdwd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_inday = new System.Windows.Forms.Label();
            this.listbox_sch = new System.Windows.Forms.ListBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_deleteback = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_inmonth
            // 
            this.label_inmonth.AutoSize = true;
            this.label_inmonth.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_inmonth.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_inmonth.ForeColor = System.Drawing.SystemColors.Control;
            this.label_inmonth.Location = new System.Drawing.Point(65, 26);
            this.label_inmonth.Name = "label_inmonth";
            this.label_inmonth.Size = new System.Drawing.Size(28, 21);
            this.label_inmonth.TabIndex = 0;
            this.label_inmonth.Text = "00";
            // 
            // wdwd
            // 
            this.wdwd.AutoSize = true;
            this.wdwd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.wdwd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.wdwd.ForeColor = System.Drawing.SystemColors.Control;
            this.wdwd.Location = new System.Drawing.Point(90, 26);
            this.wdwd.Name = "wdwd";
            this.wdwd.Size = new System.Drawing.Size(26, 21);
            this.wdwd.TabIndex = 1;
            this.wdwd.Text = "월";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(141, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "일";
            // 
            // label_inday
            // 
            this.label_inday.AutoSize = true;
            this.label_inday.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_inday.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_inday.ForeColor = System.Drawing.SystemColors.Control;
            this.label_inday.Location = new System.Drawing.Point(116, 26);
            this.label_inday.Name = "label_inday";
            this.label_inday.Size = new System.Drawing.Size(28, 21);
            this.label_inday.TabIndex = 2;
            this.label_inday.Text = "00";
            // 
            // listbox_sch
            // 
            this.listbox_sch.BackColor = System.Drawing.Color.Gainsboro;
            this.listbox_sch.FormattingEnabled = true;
            this.listbox_sch.HorizontalExtent = 200;
            this.listbox_sch.HorizontalScrollbar = true;
            this.listbox_sch.ItemHeight = 12;
            this.listbox_sch.Location = new System.Drawing.Point(19, 57);
            this.listbox_sch.Name = "listbox_sch";
            this.listbox_sch.ScrollAlwaysVisible = true;
            this.listbox_sch.Size = new System.Drawing.Size(270, 184);
            this.listbox_sch.TabIndex = 4;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Silver;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_delete.ForeColor = System.Drawing.Color.Black;
            this.button_delete.Location = new System.Drawing.Point(164, 249);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 32);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "일정 삭제";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_deleteback
            // 
            this.button_deleteback.BackColor = System.Drawing.Color.Silver;
            this.button_deleteback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deleteback.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_deleteback.ForeColor = System.Drawing.Color.Black;
            this.button_deleteback.Location = new System.Drawing.Point(66, 249);
            this.button_deleteback.Name = "button_deleteback";
            this.button_deleteback.Size = new System.Drawing.Size(75, 32);
            this.button_deleteback.TabIndex = 6;
            this.button_deleteback.Text = "되돌리기";
            this.button_deleteback.UseVisualStyleBackColor = false;
            this.button_deleteback.Click += new System.EventHandler(this.button_deleteback_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(181, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "일정표";
            // 
            // Form_Schedule_delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(309, 286);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_deleteback);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.listbox_sch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_inday);
            this.Controls.Add(this.wdwd);
            this.Controls.Add(this.label_inmonth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Form_Schedule_delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "스케줄 확인";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Schedule_delete_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Schedule_delete_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_inmonth;
        private System.Windows.Forms.Label wdwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_inday;
        private System.Windows.Forms.ListBox listbox_sch;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_deleteback;
        private System.Windows.Forms.Label label2;
    }
}