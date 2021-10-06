using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SendMail
{
    public partial class ConfigForm : Form
    {
        private Settings settings = Settings.getInstance();
        public ConfigForm()
        {
            InitializeComponent();

            

        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            tbHost.Text = settings.sHost(); //ホスト名
            tbPort.Text = settings.sPort(); //ポート番号
            tbPass.Text = settings.sPass(); //パスワード
            tbUserName.Text = settings.sMailAddr(); //ユーザ名
            cbSSL.Checked = settings.bSsl(); //SSL
            tbSender.Text = settings.sMailAddr(); //送信元
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            SettingRegist();
            this.Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            SettingRegist();
        }
        
        public void SettingRegist() {
            try
            {
                settings.Host = tbHost.Text;
                settings.Port = int.Parse(tbPort.Text);
                settings.Pass = tbPass.Text;
                settings.MailAddr = tbUserName.Text;
                settings.Ssl = cbSSL.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
