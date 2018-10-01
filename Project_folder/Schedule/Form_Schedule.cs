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
    public partial class Form_Schedule : Form
    {
        int MAX_year = 2100, year = 0, month = 3, day = 0, yoil = 0, max_day = 0, today = 0, today_month = 0, status = 0;
        int old_select = 43, new_select = 43;
        List<string> file_list = new List<string> { };

        public Form_Schedule()
        {
            InitializeComponent();
            Control_Setting();
            Calendar_Setting();
        }

        private void Control_Setting() // comtrol을 세팅합니다.
        {
            string str;

            for (int i = MAX_year - 100; i < MAX_year; i++) // 2000 ~ 2099까지 총 100개
            {
                combo_year.Items.Add("   " + i);
            }
            for (int i = 1; i <= 12; i++)
            {
                combo_month.Items.Add("  " + i);
            }

            combo_year.SelectedIndex = int.Parse(DateTime.Now.ToString("yyyy")) - 2000;
            str = DateTime.Now.ToString("MM");
            today = int.Parse(DateTime.Now.ToString("dd"));
            today_month = int.Parse(str);

            combo_month.SelectedIndex = int.Parse(str) - 1;

            year = combo_year.SelectedIndex + 2000; // 년
            month = combo_month.SelectedIndex + 1;  // 월
        }

        private void Calendar_Setting() // 달력을 세팅합니다.
        {
            DateTime dateValue = new DateTime(year, month, 1);

            yoil = (int)dateValue.DayOfWeek;
            max_day = (int)DateTime.DaysInMonth(year, month);

            if (status == 0)
            {
                for (int i = 1; i <= 42; i++)
                {
                    Label la = (Controls.Find("lb_day" + i.ToString(), true)[0] as Label);
                    la.Text = "";
                }
                for (int i = yoil + 1, j = 1; j <= max_day; i++, j++)
                {
                    Label la = (Controls.Find("lb_day" + i.ToString(), true)[0] as Label);
                    la.Text = j.ToString() + "\n\n";

                    if ((i) == (today + 1))
                    {
                        la.BackColor = Color.Beige;
                    }
                }
                Schedulue_plan();
            }
            else
            {
                Label la = (Controls.Find("lb_day" + (day + yoil).ToString(), true)[0] as Label);
                la.Text = day.ToString() + "\n\n";
                day_ScheduleUpdate();
            }
            Color_Set();
        }

        private void Color_Set() // 색을 초기화 시켜주는 함수
        {
            Label lab = null;
            today_month = int.Parse(DateTime.Now.ToString("MM"));

            for (int i = yoil + 1, j = 1; j <= max_day; i++, j++)
            {
                lab = (Controls.Find("lb_day" + i.ToString(), true)[0] as Label);
                lab.BackColor = SystemColors.Control;
            }

            if (month == today_month)
            {
                lab = (Controls.Find("lb_day" + (today + yoil).ToString(), true)[0] as Label);
                lab.BackColor = Color.Beige;
            }

            old_select = 43;
            new_select = 43;
        }

        private void Schedulue_plan() // 달력에 일정을 보여주는 함수 ( 월단위 파일입출력 )
        {
            string file_path = Application.StartupPath + "\\Schedule\\" + year.ToString() + "\\" + month.ToString();

            DirectoryInfo direc_info = new DirectoryInfo(file_path);

            if (direc_info.Exists == true)
            {
                foreach (var item in direc_info.GetFiles())
                {
                    string[] s1 = item.Name.Split('.');
                    file_list.Add(s1[0]);
                }

                for (int i = 0; i < file_list.Count; i++)
                {
                    string str, tmp_str = file_list[i];
                    int count = 0;
                    FileInfo file_info = new FileInfo(file_path + "\\" + tmp_str + ".txt");

                    if (file_info.Exists == true)
                    {
                        StreamReader sr = new StreamReader(file_path + "\\" + tmp_str + ".txt");
                        Label la = null;

                        while ((str = sr.ReadLine()) != null)
                        {
                            if (count < 2)
                            {
                                string[] s2 = str.Split('$');
                                la = (Controls.Find("lb_day" + (int.Parse(tmp_str) + yoil).ToString(), true)[0] as Label);
                                la.Text += s2[0];
                                if (count < 1)
                                    la.Text += "\r\n";
                            }
                            count++;
                        }
                        if (count >= 2)
                        {
                            if ((count - 2) != 0)
                            {
                                la.Text += " +" + (count - 2).ToString();
                            }
                        }
                        sr.Close();
                    }
                }
            }
            file_list.Clear();
        }

        private void day_ScheduleUpdate() // 일 단위로 파일입출력을 하는 함수
        {
            string line, path = Application.StartupPath + "\\Schedule\\" + year.ToString() + "\\" + month.ToString() + "\\" + day.ToString() + ".txt";
            int count = 0;

            if (File.Exists(path) == true)
            {
                StreamReader sr = new StreamReader(path);
                Label la = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (count < 2)
                    {
                        string[] s2 = line.Split('$');
                        la = (Controls.Find("lb_day" + (day + yoil).ToString(), true)[0] as Label);
                        la.Text += s2[0];
                        if (count < 1)
                            la.Text += "\r\n";
                    }
                    count++;
                }
                if (count >= 2)
                {
                    if ((count - 2) != 0)
                        la.Text += " +" + (count - 2).ToString();
                }
                sr.Close();
            }
        }

        private void btn_yearleft_Click(object sender, EventArgs e) // 년 Combobox옆에 ◀ 버튼을 클릭했을 때
        {
            if (combo_year.SelectedIndex > 0) // 2000까지만 작아지게함
                combo_year.SelectedIndex -= 1;
            year = combo_year.SelectedIndex + 2000; // 년

            Calendar_Setting();
        }

        private void btn_yearright_Click(object sender, EventArgs e) // 년 옆에 ▶ 버튼을 클릭했을 때
        {
            if (combo_year.SelectedIndex < (MAX_year - 1)) // 2100전까지만 커지게함
                combo_year.SelectedIndex += 1;
            year = combo_year.SelectedIndex + 2000; // 년

            Calendar_Setting();
        }

        private void btn_monthleft_Click(object sender, EventArgs e) // 월 Combobox옆에 ◀ 버튼을 클릭했을 때
        {
            if (combo_month.SelectedIndex > 0)
                combo_month.SelectedIndex -= 1;
            else if (combo_month.SelectedIndex == 0 && combo_year.SelectedIndex > 0)
            {
                combo_month.SelectedIndex = 11;
                combo_year.SelectedIndex -= 1;
            }
            month = combo_month.SelectedIndex + 1;

            Calendar_Setting();
        }

        private void btn_monthright_Click(object sender, EventArgs e) // 월의 오른쪽 버튼 눌렀을 때
        {
            if (combo_month.SelectedIndex < 11)
                combo_month.SelectedIndex += 1;
            else if (combo_month.SelectedIndex == 11 && combo_year.SelectedIndex < (MAX_year - 1))
            {
                combo_month.SelectedIndex = 0;
                combo_year.SelectedIndex += 1;
            }
            month = combo_month.SelectedIndex + 1;

            Calendar_Setting();
        }

        private void combo_year_SelectedIndexChanged(object sender, EventArgs e) // 년 Combobox가 변경될 때
        {
            year = combo_year.SelectedIndex + 2000; // 년

            Color_Set();
            Calendar_Setting();
        }

        private void combo_month_SelectedIndexChanged(object sender, EventArgs e) // 월 Combobox가 변경될 때
        {
            month = combo_month.SelectedIndex + 1;

            Calendar_Setting();
        }

        private void lb_day42_MouseEnter(object sender, EventArgs e) // 날짜 label에 마우스가 들어갔을 떄
        {
            Label tmp_label = (Label)sender;
            string[] s1 = tmp_label.Text.Split('\n');
            for (int i = 1; i <= max_day; i++)
            {
                if ((i).ToString() == s1[0])
                {
                    if (tmp_label.BackColor != Color.Gray)
                        tmp_label.BackColor = Color.PowderBlue;
                    break;
                }
            }
        }

        private void lb_day42_MouseLeave(object sender, EventArgs e) // 날짜 label에서 마우스가 떠났을 때
        {
            Label tmp_label = (Label)sender;
            string[] str_arr = tmp_label.Text.Split('\n');

            if (tmp_label.BackColor == Color.PowderBlue)
            {
                if (int.Parse(str_arr[0]) == today && month == today_month)
                    tmp_label.BackColor = Color.Beige;
                else
                    tmp_label.BackColor = SystemColors.Control;
            }
        }

        private void btn_today_Click(object sender, EventArgs e) // 오늘로 버튼
        {
            string str;

            combo_year.SelectedIndex = int.Parse(DateTime.Now.ToString("yyyy")) - 2000;
            str = DateTime.Now.ToString("MM");

            combo_month.SelectedIndex = int.Parse(str) - 1;

            year = combo_year.SelectedIndex + 2000; // 년
            month = combo_month.SelectedIndex + 1;  // 월

            Calendar_Setting();
        }

        private void 일정추가ToolStripMenuItem_Click(object sender, EventArgs e) // 스트립메뉴에서 <일정 추가> 메뉴를 선택
        {
            Form_Schedule_add form_sch_add = new Form_Schedule_add(year, month, day);
            this.Hide();
            form_sch_add.ShowDialog();
            status = form_sch_add.Pass_Value;

            if (status > 0)
            {
                Calendar_Setting();
                status = 0;
            }
            this.Show();
        }

        private void 일정삭제ToolStripMenuItem_Click(object sender, EventArgs e) // 스트립메뉴에서 <일정 삭제> 메뉴를 선택
        {
            Form_Schedule_delete form_sch_del = new Form_Schedule_delete(year, month, day);
            this.Hide();
            form_sch_del.ShowDialog();
            status = form_sch_del.Pass_Value;

            if (status > 0)
            {
                Calendar_Setting();
                status = 0;
            }
            this.Show();
        }

        private void lb_day42_MouseClick(object sender, MouseEventArgs e)
        {
            Label la = (Label)sender;
            string[] str_arr;
            int tmp_num;

            if (e.Button == MouseButtons.Left) // 마우스 왼쪽을 클릭
            {
                str_arr = la.Name.Split('y');
                tmp_num = int.Parse(str_arr[1]);

                if (tmp_num > yoil && tmp_num <= (max_day + yoil))
                {
                    old_select = new_select;
                    new_select = tmp_num;

                    la.BackColor = Color.Gray;

                    if (old_select != -1) // 처음이 아니다
                    {
                        Label tmp_la = (Controls.Find("lb_day" + old_select.ToString(), true)[0] as Label);

                        if ((old_select - yoil) == today && month == today_month)
                            tmp_la.BackColor = Color.Beige;
                        else
                            tmp_la.BackColor = SystemColors.Control;
                    }
                }
            }

            else if (e.Button == MouseButtons.Right) // 마우스 오른쪽을 클릭
            {
                str_arr = la.Text.Split('\n');
                day = int.Parse(str_arr[0]);
                contextMenuStrip1.Show(la.Location.X + this.Location.X + 50, la.Location.Y + this.Location.Y + 70);
            }
        }
    }
}