using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmMain : Form {
        BindingList<CarReport> listCarReport = new BindingList<CarReport>();

        public fmMain() {
            InitializeComponent();
            dgvRegistData.DataSource = listCarReport;
        }

        private void btExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        //画像を開くボタン
        private void btPictureOpen_Click(object sender, EventArgs e) {
            if (ofdPictureOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPictureOpen.FileName);
            }
        }
        //画像削除ボタン
        private void btPictuerDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //追加ボタン
        private void btDataAdd_Click(object sender, EventArgs e) {

            if (cdAuthor.Text == "" || cbCarName.Text == "") {
                MessageBox.Show("正しい値を入力してください。");
                return;
            }
            CarReport carReport = new CarReport {
                Date = btpDate.Value,
                Auther = cdAuthor.Text,
                Maker = selectedGroup(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            listCarReport.Add(carReport); //1レコードの追加
            setCbAuthor(cdAuthor.Text);
            setCbCarName(cbCarName.Text);
        }

        private CarReport.MakarGroup selectedGroup() {

            foreach (var rb in gbMaker.Controls) {
                if (((RadioButton)rb).Checked) {
                    return (CarReport.MakarGroup)int.Parse((string)((RadioButton)rb).Tag);
                }
            }
            return CarReport.MakarGroup.その他;


        }

        private void setCbAuthor(string author) {
            if (!cdAuthor.Items.Contains(author)) {
                cdAuthor.Items.Add(author);
            }
        }
        //コンボボックスに車名をセットする
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void dgvRegistData_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > 0)
                return;

            CarReport selectedcar = listCarReport[e.RowIndex];
            btpDate.Value = selectedcar.Date;
            cdAuthor.Text = selectedcar.Auther;
            //foreach (var rb in gbMaker.Controls) {
            //    if (selectedcar.Maker == (CarReport.MakarGroup)int.Parse((string)((RadioButton)rb).Tag)) {
            //        ((RadioButton)rb).Checked = true;
            //    }
            //}
            setMakerRedioButton(selectedcar.Maker);
            cbCarName.Text = selectedcar.CarName;
            tbReport.Text = selectedcar.Report;
            pbPicture.Image = selectedcar.Picture;


        }

        private void setMakerRedioButton(CarReport.MakarGroup mg) {
            switch (mg) {
                case CarReport.MakarGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakarGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakarGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakarGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakarGroup.外国車:
                    rbImport.Checked = true;
                    break;
                default: // その他
                    rbOther.Checked = true;
                    break;
            }
        }

        private void btDataDelete_Click(object sender, EventArgs e) {
            listCarReport.RemoveAt(dgvRegistData.CurrentRow.Index);
        }

        private void btDataCorrect_Click(object sender, EventArgs e) {
            listCarReport[dgvRegistData.CurrentRow.Index].UpDate(
                btpDate.Value,   cdAuthor.Text,
                selectedGroup(), cbCarName.Text,
                tbReport.Text,   pbPicture.Image);
            dgvRegistData.Update();


        }
    }
}

