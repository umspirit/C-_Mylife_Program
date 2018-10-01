namespace 비프
{
    partial class Form_Financial_Futrue
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Futrue_add_name = new System.Windows.Forms.TextBox();
            this.txt_Futrue_add_object = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Futrue_add_register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "미래자금명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "목 표 금 액";
            // 
            // txt_Futrue_add_name
            // 
            this.txt_Futrue_add_name.Location = new System.Drawing.Point(88, 64);
            this.txt_Futrue_add_name.Name = "txt_Futrue_add_name";
            this.txt_Futrue_add_name.Size = new System.Drawing.Size(127, 21);
            this.txt_Futrue_add_name.TabIndex = 2;
            // 
            // txt_Futrue_add_object
            // 
            this.txt_Futrue_add_object.Location = new System.Drawing.Point(88, 101);
            this.txt_Futrue_add_object.Name = "txt_Futrue_add_object";
            this.txt_Futrue_add_object.Size = new System.Drawing.Size(127, 21);
            this.txt_Futrue_add_object.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Khaki;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(-2, -16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 66);
            this.label3.TabIndex = 4;
            this.label3.Text = "미래자금명과 목표금액을 입력해주세요.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Futrue_add_register
            // 
            this.btn_Futrue_add_register.Location = new System.Drawing.Point(85, 166);
            this.btn_Futrue_add_register.Name = "btn_Futrue_add_register";
            this.btn_Futrue_add_register.Size = new System.Drawing.Size(75, 23);
            this.btn_Futrue_add_register.TabIndex = 5;
            this.btn_Futrue_add_register.Text = "등 록";
            this.btn_Futrue_add_register.UseVisualStyleBackColor = true;
            this.btn_Futrue_add_register.Click += new System.EventHandler(this.btn_Futrue_add_register_Click);
            // 
            // Form_Financial_Futrue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(236, 201);
            this.Controls.Add(this.btn_Futrue_add_register);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Futrue_add_object);
            this.Controls.Add(this.txt_Futrue_add_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Financial_Futrue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Financial_Futrue";
            this.Load += new System.EventHandler(this.Form_Financial_Futrue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Futrue_add_name;
        private System.Windows.Forms.TextBox txt_Futrue_add_object;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Futrue_add_register;
    }
}