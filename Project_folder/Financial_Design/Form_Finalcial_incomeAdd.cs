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
    public partial class Form_Finalcial_incomeAdd : Form
    {

        public Form_Finalcial_incomeAdd()
        {
            InitializeComponent();
        }

        private void btn_F_sal_add_Click(object sender, EventArgs e)
        {
            if(gap_Check()) // 정확한 값이 입력이 됬는지 확인
            {
                File_Save();

                this.Close();
            }
        }

        private void File_Save()
        {
            string path = Application.StartupPath + "\\월급관리\\급여\\", income_line = "", tax_line = "";

            File_Check(ref path);

            double income = double.Parse(t1.Text) + double.Parse(t2.Text) + double.Parse(t3.Text) + double.Parse(t4.Text);
            income_line = dtp1.Text + "$" + t1.Text + "$" + t2.Text + "$" + t3.Text + "$" + t4.Text + "$" + ((int)income).ToString();
            Tax_Compute(income, ref tax_line);

            File.AppendAllText(path, income_line + "\r\n"); // 월소득 추가
            File.AppendAllText(path, tax_line); // 과세 추가

        }

        private bool gap_Check()
        {
            int num = 0;

            if (int.TryParse(t1.Text, out num) && int.TryParse(t1.Text, out num) && int.TryParse(t1.Text, out num)
                && int.TryParse(t1.Text, out num) && int.TryParse(t1.Text, out num))
            {
                return true;
            }
            else
            {
                MessageBox.Show("정확히 입력해주세요.", "오류");
                return false;
            }
        }

        private void Tax_Compute(double income, ref string tax_line)
        {
            
            double income_tax, local_income_tax, nation_tax, health_tax, future_tax, hire_tax;

            // 소득세 적용
            if ((income * 12) <= 12000000)
                income_tax = (income * 0.06);
            else if ((income * 12) <= 46000000)
                income_tax = (income * 0.15);
            else if ((income * 12) <= 88000000)
                income_tax = (income * 0.24);
            else if ((income * 12) <= 150000000)
                income_tax = (income * 0.35);
            else 
                income_tax = (income * 0.38);

            // 지방소득세
            local_income_tax = (income_tax * 0.1);
            nation_tax = (income * 0.045);

            // 건강보험
            health_tax = (income * 0.0306);

            // 장기요양보험
            future_tax = (health_tax * 0.0655);

            // 고용보험
            hire_tax = (income * 0.0065);

            tax_line = ((int)income_tax).ToString() + "$" + ((int)local_income_tax).ToString() + "$" + ((int)nation_tax).ToString() 
                + "$" + ((int)health_tax).ToString() + "$" + ((int)future_tax).ToString() + "$" + ((int)hire_tax).ToString();
        }

        private void File_Check(ref string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\" + dtp1.Text + ".txt";

            if (File.Exists(path))
                File.Delete(path);

            File.Create(path).Close();
        }
    }
}
