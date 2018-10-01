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
    public partial class Form_Schedule_delete : Form
    {
        int year, month, day, delete_count = 0; // del_count : 지워진횟수 | del_btn = 일정이 삭제됬는지 아닌지 확인
        List<string> del_list = new List<string> { }; // 리스트에서 삭제된 항목을 문자열로 저장

        public Form_Schedule_delete(int year, int month, int day) // 생성자
        {
            this.year = year;
            this.month = month;
            this.day = day;

            InitializeComponent();
            label_inmonth.Text = month.ToString();
            label_inday.Text = day.ToString();
            Set_List();
        }

        public int Pass_Value
        {
            get { return this.delete_count; }
            set { this.delete_count = value; }
        }

        private void button_delete_Click(object sender, EventArgs e) // 삭제버튼을 눌렀을 때
        {
            if (listbox_sch.SelectedIndex != -1)
            {
                del_list.Add(listbox_sch.SelectedItem.ToString());
                listbox_sch.Items.RemoveAt(listbox_sch.SelectedIndex);

                delete_count++;
            }
        }

        private void Form_Schedule_delete_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (delete_count > 0)
                File_revise();
        }

        private void Form_Schedule_delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void File_revise() // 파일을 수정해서 저장
        {
            string path = Application.StartupPath + "\\Schedule\\" + year.ToString() + "\\" + month.ToString();
            DirectoryInfo direc_info = new DirectoryInfo(path);

            if (direc_info.Exists == true) // 폴더까지 파일경로가 존재하면
            {
                path += "\\" + day.ToString() + ".txt";
                FileInfo f_info = new FileInfo(path);

                string tmp_str = "";
                string[] str_arr;

                f_info.Delete();

                FileStream file = f_info.Create();
                file.Close();

                for (int i = 0; i < listbox_sch.Items.Count; i++)
                {
                    str_arr = listbox_sch.Items[i].ToString().Split('/');

                    for (int j = 0; j < str_arr.Length; j++)
                    {
                        str_arr[j].Trim();
                        if (str_arr[j] == "-")
                            str_arr[j] = "null";

                        if (j == 0)
                            tmp_str += str_arr[j];
                        else
                            tmp_str += "$" + str_arr[j];
                    }
                    tmp_str += "\r\n";

                    File.AppendAllText(path, tmp_str);
                }
                file.Close();
            }
        }

        private void button_deleteback_Click(object sender, EventArgs e) // 되돌리기 버튼을 눌렀을 때
        {
            if (delete_count > 0)
            {
                int last_index = del_list.Count - 1; // List<>의 마지막 인덱스를 뽑기위한 index

                listbox_sch.Items.Insert(0, del_list[last_index]); // ListBox에 삭제했던 데이터를 추가
                del_list.RemoveAt(last_index);

                delete_count--;
            }
        }

        private void Set_List()
        {
            string path = Application.StartupPath + "\\Schedule\\" + year.ToString() + "\\" + month.ToString();
            DirectoryInfo direc_info = new DirectoryInfo(path);
            List<string> back_list = new List<string> { };

            if (direc_info.Exists == true)
            {
                path += "\\" + day.ToString() + ".txt";

                StreamReader sr = new StreamReader(path);
                string line;
                string[] str_arr;

                while ((line = sr.ReadLine()) != null)
                {
                    str_arr = line.Split('$');
                    line = "";
                    for (int i = 0; i < str_arr.Length; i++)
                    {
                        if (str_arr[i] != "null")
                        {
                            if (i < (str_arr.Length - 1))
                                line += str_arr[i] + " / ";
                            else
                                line += str_arr[i];
                        }
                        else
                            line += " - ";
                    }
                    listbox_sch.Items.Add(line);
                }
                sr.Close();
            }
            else
                MessageBox.Show("dw");
        }
    }
}