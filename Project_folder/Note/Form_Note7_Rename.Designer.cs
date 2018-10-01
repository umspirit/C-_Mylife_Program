namespace 비프
{
    partial class Form_Note7_Rename
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
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.button_rename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(9, 43);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(85, 15);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "새 파일 이름 :";
            // 
            // textBox_filename
            // 
            this.textBox_filename.Location = new System.Drawing.Point(92, 40);
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.Size = new System.Drawing.Size(158, 21);
            this.textBox_filename.TabIndex = 1;
            // 
            // button_rename
            // 
            this.button_rename.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_rename.FlatAppearance.BorderSize = 0;
            this.button_rename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rename.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_rename.Location = new System.Drawing.Point(91, 114);
            this.button_rename.Name = "button_rename";
            this.button_rename.Size = new System.Drawing.Size(75, 30);
            this.button_rename.TabIndex = 2;
            this.button_rename.Text = "수 정";
            this.button_rename.UseVisualStyleBackColor = false;
            this.button_rename.Click += new System.EventHandler(this.button_rename_Click);
            // 
            // Form_Note7_Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(261, 156);
            this.Controls.Add(this.button_rename);
            this.Controls.Add(this.textBox_filename);
            this.Controls.Add(this.label_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_Note7_Rename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 이름 수정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.Button button_rename;
    }
}