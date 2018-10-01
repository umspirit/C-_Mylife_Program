using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 비프
{
    class Class_Kookmin
    {
        Form_Financial f;

        public Class_Kookmin(Form_Financial form)
        {
            f = form;
        }

        public void Control_Setting()
        {
            File_Call();
        }

        private void File_Call()
        {
            List<string> s_list = new List<string> { };
            string path = Application.StartupPath + "\\연금관리\\연금정보.txt";

            if(File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line = "";

                while((line = sr.ReadLine()) != null)
                {
                    s_list.Add(line);
                }
                sr.Close();
                if(s_list.Count > 1)
                    Label_Setting(s_list);
            }
        }

        private void Label_Setting(List<string> list)
        {
            // 기본정보에 있는 Label 세팅
            string[] tmp_s = list[0].Split('$');
            string str = "";
            int n = 0;

            DateTime T1 = DateTime.Parse(tmp_s[0]);
            DateTime T2 = DateTime.Parse(DateTime.Now.ToString("yy-MM-dd"));

            TimeSpan TS = T2 - T1;

            double diffDay = ((double)(TS.Days / 30) / 12);
            diffDay = diffDay / 100.0;

            f.lbl_pension_birth.Text = tmp_s[0];
            f.lbl_pension_firstin.Text = tmp_s[1];
            f.lbl_pension_lastout.Text = tmp_s[2];
            f.lbl_pension_expect.Text = tmp_s[3];

            // 연금정보에 있는 Label 세팅
            tmp_s = list[1].Split('$');
            f.lbl_pension_salaryfirst.Text = tmp_s[0];
            f.lbl_pension_salarylast.Text = tmp_s[1];
            f.lbl_pension_salary.Text = tmp_s[2];
            str = f.lbl_pension_months.Text = Day_interval(tmp_s[0], tmp_s[1]);
            n = int.Parse(str);

            double tmp_num = double.Parse(tmp_s[2]) * 0.045;
            f.lbl_pension_part1.Text = ((int)tmp_num).ToString();

            float A = 210, B = int.Parse(tmp_s[2]) < 408 ? int.Parse(tmp_s[2]) : 408;
            
            if(n > 240)
            {
                n -= 228;
            }

            f.lbl_pension_part2.Text = ((int)((1.2*(A + B))*(1 + (0.05 * (n/12))) / 12)).ToString();
            f.lbl_pension_part2.Text = string.Format("{0:f0}", ((A + B) * (1.0 + (float)diffDay) / 12.0 * (232.0 / 240.0)));
        }

        private string Day_interval(string day1, string day2)
        {
            DateTime T1 = DateTime.Parse(day1);
            DateTime T2 = DateTime.Parse(day2);

            TimeSpan TS = T2 - T1;

            int diffDay = TS.Days;

            return (diffDay / 30).ToString();
        }
        
   
        public void File_Make()
        {
            string path = Application.StartupPath + "\\연금관리", tmp_str = "";
            
            DirectoryInfo direc_info = new DirectoryInfo(path);
            if(!direc_info.Exists)
            {
                direc_info.Create();
            }
            path += "\\연금정보.txt";

            File.Create(path).Close();

            tmp_str = f.dtp_pension_birth.Text + " $ " + f.dtp_pension_first.Text + " $ " + f.dtp_pension_last.Text + " $ " + f.cbo_pension_expect.Text;
            File.AppendAllText(path, tmp_str + "\r\n");
            tmp_str = f.dtp_pension_salaryfirst.Text + " $ " + f.dtp_pension_salarylast.Text + " $ " + f.txt_pension_salary.Text;
            File.AppendAllText(path, tmp_str + "\r\n");
        }
    }
}
