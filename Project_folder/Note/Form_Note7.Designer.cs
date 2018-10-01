namespace 비프
{
    partial class Form_Note7
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
            this.components = new System.ComponentModel.Container();
            this.listBox_topic = new System.Windows.Forms.ListBox();
            this.btn_newnote = new System.Windows.Forms.Button();
            this.btn_delnote = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.radioButton_readmode = new System.Windows.Forms.RadioButton();
            this.radioButton_writemode = new System.Windows.Forms.RadioButton();
            this.richTextBox_body = new System.Windows.Forms.RichTextBox();
            this.btn_Regular = new System.Windows.Forms.Button();
            this.btn_bold = new System.Windows.Forms.Button();
            this.btn_italic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_fontsize = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.복사ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.붙여넣기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.잘라내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_topic
            // 
            this.listBox_topic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBox_topic.ColumnWidth = 100;
            this.listBox_topic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_topic.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox_topic.FormattingEnabled = true;
            this.listBox_topic.HorizontalExtent = 200;
            this.listBox_topic.HorizontalScrollbar = true;
            this.listBox_topic.ItemHeight = 60;
            this.listBox_topic.Location = new System.Drawing.Point(12, 91);
            this.listBox_topic.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.listBox_topic.Name = "listBox_topic";
            this.listBox_topic.Size = new System.Drawing.Size(248, 484);
            this.listBox_topic.TabIndex = 0;
            this.listBox_topic.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox_topic.SelectedIndexChanged += new System.EventHandler(this.listBox_topic_SelectedIndexChanged);
            this.listBox_topic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_topic_KeyDown);
            this.listBox_topic.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_topic_KeyUp);
            this.listBox_topic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_topic_MouseDoubleClick);
            // 
            // btn_newnote
            // 
            this.btn_newnote.BackColor = System.Drawing.Color.LightCyan;
            this.btn_newnote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_newnote.FlatAppearance.BorderSize = 0;
            this.btn_newnote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newnote.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_newnote.Location = new System.Drawing.Point(12, 32);
            this.btn_newnote.Name = "btn_newnote";
            this.btn_newnote.Size = new System.Drawing.Size(76, 34);
            this.btn_newnote.TabIndex = 4;
            this.btn_newnote.Text = "새 노트";
            this.toolTip1.SetToolTip(this.btn_newnote, "새로운 노트를 생성합니다.");
            this.btn_newnote.UseVisualStyleBackColor = false;
            this.btn_newnote.Click += new System.EventHandler(this.btn_newnote_Click);
            // 
            // btn_delnote
            // 
            this.btn_delnote.BackColor = System.Drawing.Color.LightCyan;
            this.btn_delnote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_delnote.FlatAppearance.BorderSize = 0;
            this.btn_delnote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delnote.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_delnote.Location = new System.Drawing.Point(98, 32);
            this.btn_delnote.Name = "btn_delnote";
            this.btn_delnote.Size = new System.Drawing.Size(76, 34);
            this.btn_delnote.TabIndex = 5;
            this.btn_delnote.Text = "노트 삭제";
            this.toolTip1.SetToolTip(this.btn_delnote, "선택한 노트를 삭제합니다.");
            this.btn_delnote.UseVisualStyleBackColor = false;
            this.btn_delnote.Click += new System.EventHandler(this.btn_delnote_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.BackColor = System.Drawing.Color.LightCyan;
            this.btn_copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_copy.FlatAppearance.BorderSize = 0;
            this.btn_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copy.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_copy.Location = new System.Drawing.Point(184, 32);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(76, 34);
            this.btn_copy.TabIndex = 6;
            this.btn_copy.Text = "노트 복사";
            this.toolTip1.SetToolTip(this.btn_copy, "선택한 노트를 복사합니다.");
            this.btn_copy.UseVisualStyleBackColor = false;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_save.Location = new System.Drawing.Point(962, 57);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(60, 26);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "저 장";
            this.toolTip1.SetToolTip(this.btn_save, "Ctrl + Shift + S");
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // radioButton_readmode
            // 
            this.radioButton_readmode.AutoSize = true;
            this.radioButton_readmode.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton_readmode.Location = new System.Drawing.Point(282, 32);
            this.radioButton_readmode.Name = "radioButton_readmode";
            this.radioButton_readmode.Size = new System.Drawing.Size(86, 21);
            this.radioButton_readmode.TabIndex = 0;
            this.radioButton_readmode.TabStop = true;
            this.radioButton_readmode.Text = "읽기 모드";
            this.toolTip1.SetToolTip(this.radioButton_readmode, "노트내용을 읽기만 가능합니다.");
            this.radioButton_readmode.UseVisualStyleBackColor = true;
            this.radioButton_readmode.CheckedChanged += new System.EventHandler(this.radioButton_readmode_CheckedChanged);
            // 
            // radioButton_writemode
            // 
            this.radioButton_writemode.AutoSize = true;
            this.radioButton_writemode.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton_writemode.Location = new System.Drawing.Point(370, 32);
            this.radioButton_writemode.Name = "radioButton_writemode";
            this.radioButton_writemode.Size = new System.Drawing.Size(86, 21);
            this.radioButton_writemode.TabIndex = 1;
            this.radioButton_writemode.TabStop = true;
            this.radioButton_writemode.Text = "쓰기 모드";
            this.toolTip1.SetToolTip(this.radioButton_writemode, "노트내용을 수정할 수 있습니다.");
            this.radioButton_writemode.UseVisualStyleBackColor = true;
            this.radioButton_writemode.CheckedChanged += new System.EventHandler(this.radioButton_writemode_CheckedChanged);
            // 
            // richTextBox_body
            // 
            this.richTextBox_body.AcceptsTab = true;
            this.richTextBox_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_body.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox_body.Location = new System.Drawing.Point(273, 91);
            this.richTextBox_body.Name = "richTextBox_body";
            this.richTextBox_body.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_body.Size = new System.Drawing.Size(749, 484);
            this.richTextBox_body.TabIndex = 8;
            this.richTextBox_body.Text = "";
            this.richTextBox_body.SelectionChanged += new System.EventHandler(this.richTextBox_body_SelectionChanged);
            this.richTextBox_body.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_body_KeyDown);
            this.richTextBox_body.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_body_KeyUp);
            // 
            // btn_Regular
            // 
            this.btn_Regular.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Regular.Location = new System.Drawing.Point(273, 59);
            this.btn_Regular.Name = "btn_Regular";
            this.btn_Regular.Size = new System.Drawing.Size(62, 26);
            this.btn_Regular.TabIndex = 11;
            this.btn_Regular.Text = "Regular";
            this.toolTip1.SetToolTip(this.btn_Regular, "일반 글씨체로 변경합니다.");
            this.btn_Regular.UseVisualStyleBackColor = true;
            this.btn_Regular.Click += new System.EventHandler(this.btn_Regular_Click);
            // 
            // btn_bold
            // 
            this.btn_bold.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_bold.Location = new System.Drawing.Point(341, 59);
            this.btn_bold.Name = "btn_bold";
            this.btn_bold.Size = new System.Drawing.Size(62, 26);
            this.btn_bold.TabIndex = 12;
            this.btn_bold.Text = "Bold";
            this.toolTip1.SetToolTip(this.btn_bold, "글씨체를 굵게 변경합니다.");
            this.btn_bold.UseVisualStyleBackColor = true;
            this.btn_bold.Click += new System.EventHandler(this.btn_bold_Click);
            // 
            // btn_italic
            // 
            this.btn_italic.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_italic.Location = new System.Drawing.Point(409, 59);
            this.btn_italic.Name = "btn_italic";
            this.btn_italic.Size = new System.Drawing.Size(62, 26);
            this.btn_italic.TabIndex = 13;
            this.btn_italic.Text = "Italic";
            this.toolTip1.SetToolTip(this.btn_italic, "글씨체를 이탤릭체로 변경합니다.");
            this.btn_italic.UseVisualStyleBackColor = true;
            this.btn_italic.Click += new System.EventHandler(this.btn_italic_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(487, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "글씨 크기";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_fontsize
            // 
            this.comboBox_fontsize.FormattingEnabled = true;
            this.comboBox_fontsize.Items.AddRange(new object[] {
            "6 pt",
            "7 pt",
            "8 pt",
            "9 pt",
            "10 pt",
            "11 pt",
            "12 pt",
            "13 pt",
            "14 pt",
            "15 pt",
            "16 pt",
            "18 pt",
            "20 pt",
            "24 pt",
            "32 pt",
            "24 pt",
            "48 pt",
            "72 pt",
            "112 pt",
            "127 pt",
            "254 pt",
            "500 pt"});
            this.comboBox_fontsize.Location = new System.Drawing.Point(557, 64);
            this.comboBox_fontsize.Name = "comboBox_fontsize";
            this.comboBox_fontsize.Size = new System.Drawing.Size(76, 20);
            this.comboBox_fontsize.TabIndex = 16;
            this.toolTip1.SetToolTip(this.comboBox_fontsize, "글씨의 사이즈를 변경합니다.");
            this.comboBox_fontsize.SelectionChangeCommitted += new System.EventHandler(this.comboBox_fontsize_SelectionChangeCommitted);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.삭제ToolStripMenuItem});
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.삭제ToolStripMenuItem.Text = "삭제";
            this.삭제ToolStripMenuItem.Click += new System.EventHandler(this.삭제ToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem1
            // 
            this.dToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.복사ToolStripMenuItem,
            this.붙여넣기ToolStripMenuItem,
            this.잘라내기ToolStripMenuItem});
            this.dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            this.dToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.dToolStripMenuItem1.Text = "편집";
            // 
            // 복사ToolStripMenuItem
            // 
            this.복사ToolStripMenuItem.Name = "복사ToolStripMenuItem";
            this.복사ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.복사ToolStripMenuItem.Text = "복사";
            this.복사ToolStripMenuItem.Click += new System.EventHandler(this.복사ToolStripMenuItem_Click);
            // 
            // 붙여넣기ToolStripMenuItem
            // 
            this.붙여넣기ToolStripMenuItem.Name = "붙여넣기ToolStripMenuItem";
            this.붙여넣기ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.붙여넣기ToolStripMenuItem.Text = "붙여넣기";
            this.붙여넣기ToolStripMenuItem.Click += new System.EventHandler(this.붙여넣기ToolStripMenuItem_Click);
            // 
            // 잘라내기ToolStripMenuItem
            // 
            this.잘라내기ToolStripMenuItem.Name = "잘라내기ToolStripMenuItem";
            this.잘라내기ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.잘라내기ToolStripMenuItem.Text = "잘라내기";
            this.잘라내기ToolStripMenuItem.Click += new System.EventHandler(this.잘라내기ToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem2
            // 
            this.dToolStripMenuItem2.Name = "dToolStripMenuItem2";
            this.dToolStripMenuItem2.Size = new System.Drawing.Size(55, 20);
            this.dToolStripMenuItem2.Text = "도움말";
            this.dToolStripMenuItem2.Click += new System.EventHandler(this.dToolStripMenuItem2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.dToolStripMenuItem1,
            this.dToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form_Note7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1034, 586);
            this.Controls.Add(this.comboBox_fontsize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_italic);
            this.Controls.Add(this.btn_bold);
            this.Controls.Add(this.richTextBox_body);
            this.Controls.Add(this.btn_Regular);
            this.Controls.Add(this.radioButton_readmode);
            this.Controls.Add(this.radioButton_writemode);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.btn_delnote);
            this.Controls.Add(this.btn_newnote);
            this.Controls.Add(this.listBox_topic);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Form_Note7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "노 트";
            this.Load += new System.EventHandler(this.Form_Note7_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_topic;
        private System.Windows.Forms.Button btn_newnote;
        private System.Windows.Forms.Button btn_delnote;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.RadioButton radioButton_writemode;
        private System.Windows.Forms.RadioButton radioButton_readmode;
        private System.Windows.Forms.RichTextBox richTextBox_body;
        private System.Windows.Forms.Button btn_Regular;
        private System.Windows.Forms.Button btn_bold;
        private System.Windows.Forms.Button btn_italic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_fontsize;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 복사ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 붙여넣기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 잘라내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
    }
}