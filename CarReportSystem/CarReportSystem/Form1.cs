using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            listCarReport.Insert(0,carReport); //1レコードの追加

            setCbAuthor(cdAuthor.Text);
            setCbCarName(cbCarName.Text);

            cdAuthor.Text = "";
            cbCarName.Text = "";
            tbReport.Clear();
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
            if (e.RowIndex == -1) {
                return;
            }
            CarReport selectedcar = listCarReport[e.RowIndex];
            btpDate.Value = selectedcar.Date;
            cdAuthor.Text = selectedcar.Auther;            
            setMakerRedioButton(selectedcar.Maker);
            cbCarName.Text = selectedcar.CarName;
            tbReport.Text = selectedcar.Report;
            pbPicture.Image = selectedcar.Picture;

            //foreach (var rb in gbMaker.Controls) {
            //    if (selectedcar.Maker == (CarReport.MakarGroup)int.Parse((string)((RadioButton)rb).Tag)) {
            //        ((RadioButton)rb).Checked = true;
            //    }
            //}
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
                btpDate.Value, 
                cdAuthor.Text,
                selectedGroup(), 
                cbCarName.Text,
                tbReport.Text,
                pbPicture.Image);

            dgvRegistData.Refresh();  //コントロールの強制再描画
        }

        private void btSave_Click(object sender, EventArgs e) {
            if (sfdFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(sfdFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReport);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btOpen_Click(object sender, EventArgs e) {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(ofdFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        //逆シリアル化して読み込む
                        listCarReport = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRegistData.DataSource = null;
                        dgvRegistData.DataSource = listCarReport;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                foreach (var rc in listCarReport) {
                    setCbAuthor(rc.Auther);
                    setCbCarName(rc.CarName);
                }
                //バイナリ形式で逆シリアル化

                //for (int i = 0; i < dgvRegistData.RowCount; i++) {
                //    setCbAuthor(dgvRegistData.Rows[i].Cells[1].Value.ToString());
                //    setCbCarName(dgvRegistData.Rows[i].Cells[3].Value.ToString());
                //}

            }
        }

        private void fmMain_Load(object sender, EventArgs e) {
            dgvRegistData.Columns[5].Visible = false;
        }
    }
}

