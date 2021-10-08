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
            btApply_Click(sender,e);
            this.Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            try
            {
                settings.setSendConfig(tbHost.Text, int.Parse(tbPort.Text),
                                   tbUserName.Text, tbPass.Text, cbSSL.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //SettingRegist();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            tbHost.Text = settings.Host; //ホスト名
            tbPort.Text = settings.Port.ToString(); //ポート番号
            tbPass.Text = settings.Pass; //パスワード
            tbUserName.Text = settings.MailAddr; //ユーザ名
            cbSSL.Checked = settings.Ssl; //SSL
            tbSender.Text = settings.MailAddr; //送信元
        }
    }
}
