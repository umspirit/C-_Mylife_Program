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
    public partial class Form_Note7_Addnote : Form
    {
        private string str_topic;
        private int n_click;

        public Form_Note7_Addnote(int num)
        {
            InitializeComponent();
            if(num == 1)
            {
                this.Text = "파일 이름 수정";
                btn_new.Text = "수 정";
            }
        }

        public string Topic
        {
            set { str_topic = value; }
            get { return str_topic; }
        }

        public int Btn_click
        {
            set { n_click = value; }
            get { return n_click; }
        }

        private void Form_Note7_Addnote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Btn_click = 0;
                this.Close();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Btn_click = 1;

            if(File_Check(textBox_topic.Text) == 1)
            {
                this.Close();
            }
            else
            {
                textBox_topic.Focus();
                textBox_topic.Clear();
            } 
        }

        private int File_Check(string topic)
        {
            string path = Application.StartupPath + "\\Note\\" + topic + ".txt";

            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
                Topic = topic;
                return 1;
            }
            else
            {
                MessageBox.Show("이미 같은 이름으로 등록된 노트가 있습니다.", "노트 중복");
                return 0;
            }
        }
    }
}