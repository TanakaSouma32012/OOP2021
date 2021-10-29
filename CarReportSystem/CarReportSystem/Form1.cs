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
            //dgvRegistData.DataSource = listCarReport;
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
            //listCarReport.RemoveAt(dgvRegistData.CurrentRow.Index);
        }
        private void btDataCorrect_Click(object sender, EventArgs e) {
            //listCarReport[dgvRegistData.CurrentRow.Index].UpDate(
            //    btpDate.Value, 
            //    cdAuthor.Text,
            //    selectedGroup(), 
            //    cbCarName.Text,
            //    tbReport.Text,
            //    pbPicture.Image);

            //dgvRegistData.Refresh();  //コントロールの強制再描画
        }
        //更新ボタンイベント処理
        private void btUpdate_Click(object sender, EventArgs e) {
            if (carReportDataGridView.CurrentRow == null) return;

            carReportDataGridView.CurrentRow.Cells[1].Value = btpDate.Value;  //日付
            carReportDataGridView.CurrentRow.Cells[2].Value = cdAuthor.Text;  //記録者
            carReportDataGridView.CurrentRow.Cells[3].Value = selectedGroup();  //メーカー
            carReportDataGridView.CurrentRow.Cells[4].Value = cbCarName.Text;  //車名
            carReportDataGridView.CurrentRow.Cells[5].Value = tbReport.Text;  //レポート
            carReportDataGridView.CurrentRow.Cells[6].Value = ImageToByteArray(pbPicture.Image);  //画像
            //データベースへ反映
            this.Validate();
            this.carReportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202102DataSet);

#if false
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
#endif
        }
        private void btConnect_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202102DataSet.CarReport' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableAdapter.Fill(this.infosys202102DataSet.CarReport);
            for (int i = 0; i < carReportDataGridView.RowCount; i++)
            {
                setCbAuthor(carReportDataGridView.Rows[i].Cells[2].Value.ToString());
                setCbCarName(carReportDataGridView.Rows[i].Cells[4].Value.ToString());
            }
#if false
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

                

            }
            //バイナリ形式で逆シリアル化

            //for (int i = 0; i < dgvRegistData.RowCount; i++)
            //{
            //    setCbAuthor(dgvRegistData.Rows[i].Cells[1].Value.ToString());
            //    setCbCarName(dgvRegistData.Rows[i].Cells[3].Value.ToString());
            //}
#endif
        }

        private void fmMain_Load(object sender, EventArgs e) {
            carReportDataGridView.Columns[0].Visible = false;
            carReportDataGridView.Columns[1].HeaderText = "日付";
        }

        private void carReportBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carReportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202102DataSet);
        }

        private void carReportDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (carReportDataGridView.CurrentRow == null) return;
            try
            {
                btpDate.Value = (DateTime)carReportDataGridView.CurrentRow.Cells[1].Value;  //日付
                cdAuthor.Text = carReportDataGridView.CurrentRow.Cells[2].Value.ToString();  //記録者

                //メーカー(文字列 → 列挙型)
                setMakerRedioButton(
                    (CarReport.MakarGroup)
                    Enum.Parse(typeof(CarReport.MakarGroup),carReportDataGridView.CurrentRow.Cells[3].Value.ToString())); 

                cbCarName.Text = carReportDataGridView.CurrentRow.Cells[4].Value.ToString();  //車名
                tbReport.Text = carReportDataGridView.CurrentRow.Cells[5].Value.ToString();  //レポート
                pbPicture.Image = ByteArrayToImage((byte[])carReportDataGridView.CurrentRow.Cells[6].Value);  //画像
            }
            catch (Exception)
            {
                pbPicture.Image = null;
            }

            

        }
        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b)
        {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }
        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }
        DateTime initial_date = new DateTime(2021, 1, 1);
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
            btpDate.Value = initial_date;
            cdAuthor.Text = null;
            rbOther.Checked = true;
            cbCarName.Text = null;
            tbReport.Text = null;
            pbPicture.Image = null;
        }





        private void carReportDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}

