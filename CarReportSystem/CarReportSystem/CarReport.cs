using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem
{
    [Serializable]
    public class CarReport
    {
        [DisplayName("日付")]
        public DateTime Date { get; set; }
        [DisplayName("記録者")]
        public string Auther { get; set; }
        [DisplayName("メーカー")]
        public MakarGroup Maker { get; set; }
        [DisplayName("車名")]
        public string CarName { get; set; }
        [DisplayName("レポート")]
        public string Report { get; set; }
        [DisplayName("写真")]
        public Image Picture { get; set; }

        //メーカー
        public enum MakarGroup
        {
            トヨタ,
            日産,
            ホンダ,
            スバル,
            外国車,
            その他
        }
        //データ更新用
        public void UpDate(DateTime date,
                         string auther,
                         MakarGroup maker,
                         string carName,
                         string report,
                         Image picture)
        {
            this.Date = date;
            this.Auther = auther;
            this.Maker = maker;
            this.CarName = carName;
            this.Report = report;
            this.Picture = picture;


        }


    }
}
