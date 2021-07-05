using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btAction_Click(object sender, EventArgs e) {
            //var today = DateTime.Today;
            var today = new DateTime((int)nudYear.Value, (int)nudMonth.Value, (int)nudDay.Value);
            DayOfWeek dayOfWeek = today.DayOfWeek;

            string dow = "";
            switch (dayOfWeek) {
                case DayOfWeek.Sunday:
                    dow = "日";
                    break;
                case DayOfWeek.Monday:
                    dow = "月";
                    break;
                case DayOfWeek.Tuesday:
                    dow = "火";
                    break;
                case DayOfWeek.Wednesday:
                    dow = "水";
                    break;
                case DayOfWeek.Thursday:
                    dow = "木";
                    break;
                case DayOfWeek.Friday:
                    dow = "金";
                    break;
                case DayOfWeek.Saturday:
                    dow = "土";
                    break;
                default:
                    break;
            }
            tbOutput.Text =  dow + "曜日です";

            //閏年
            if (DateTime.IsLeapYear( (int)nudYear.Value)) {
                tbLeapYear.Text = "閏年です。";
            } else {
                tbLeapYear.Text = "閏年ではないです。";
            }

            tbDays.Text = (DateTime.Now - today).Days.ToString();
            //tbOutput.Text = DateTime.Today.DayOfYear.ToString();

            var todayOld = DateTime.Today;
            //年齢
            tB_years_old.Text =GetAge(dateTimePicker1.Value, todayOld).ToString();
        }
        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            
            return age;
        }

        
    }
}
