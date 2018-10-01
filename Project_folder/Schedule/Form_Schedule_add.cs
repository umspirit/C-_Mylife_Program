using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 비프
{
    public partial class Form_Schedule_add : Form
    {
        int year = 0;
        int month = 0;
        int day = 0;
        private int save_btn = 0;

        public Form_Schedule_add(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            InitializeComponent();
            comboBox_when.SelectedIndex = 0;
        }

        public int Pass_Value
        {
            get { return this.save_btn; }
            set { this.save_btn = value; }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string tmp_str = "";
            string path = Application.StartupPath + "\\Schedule" + "\\" + year.ToString() + "\\" + month.ToString();

            if (textbox_topic.Text.Length == 0)
                textbox_topic.Text = "null";
            if (textbox_hour.Text.Length == 0)
                textbox_hour.Text = "null";
            if (textbox_min.Text.Length == 0)
                textbox_min.Text = "null";
            if (textbox_context.Text.Length == 0)
                textbox_context.Text = "null";

            tmp_str = textbox_topic.Text + "$" + comboBox_when.SelectedItem.ToString()
                + " " + textbox_hour.Text + ":" + textbox_min.Text + "$" + textbox_context.Text + "\r\n";

            DirectoryInfo di = new DirectoryInfo(path);

            if (di.Exists == false) // 디렉토리 경로가 존재하는지 검사
            {
                di.Create();
            }
            path += "\\" + day.ToString() + ".txt";
            FileInfo file_info = new FileInfo(path);

            if (file_info.Exists == false) // 파일이 존재하는지 검사
            {
                FileStream fs = file_info.Create();
                fs.Close();
            }
            File.AppendAllText(path, tmp_str);

            save_btn = 1;
            this.Close();
        }

        private void Form_Schedule_sub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}