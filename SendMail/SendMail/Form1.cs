using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Serialization;

namespace SendMail
{
    public partial class Form1 : Form
    {
        //SmtpClientオブジェクト
        SmtpClient smtpClient = null;

        //設定画面
        public ConfigForm configForm = new ConfigForm();

        //設定情報
        public Settings settings =Settings.getInstance();

        //xmlファイルの作成
        public static XmlWriter xmlConfigFile;
        //
        public Form1()
        {
            

            if (xmlConfigFile == null)
            {
                xmlConfigFile = XmlWriter.Create("ConfigXml.xml");
                xmlConfigFile.WriteStartDocument();
                xmlConfigFile.Close();
                var xws = new XmlWriterSettings
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = true,
                    IndentChars = " "

                };
                using (xmlConfigFile = XmlWriter.Create("ConfigXml.xml", xws))
                {
                    var serializer = new DataContractSerializer(settings.GetType());
                    serializer.WriteObject(xmlConfigFile, settings);
                }
                configForm.ShowDialog();
            }
            InitializeComponent();
            btCancel.Enabled = false;
        }


        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                btSend.Enabled = false;
                btCancel.Enabled = true;
                //メース送信のためのインスタンスを生成
                MailMessage mailMessage = new MailMessage();
                //差出人アドレス
                mailMessage.From = new MailAddress(settings.MailAddr/*"ojsinfosys01@gmail.com"*/);

                if (smtpClient == null)
                {
                    smtpClient = new SmtpClient();
                    //イベントハンドラの追加
                    smtpClient.SendCompleted += sc_SendCompleted;
                }

                //宛先（To,CC,Bcc)
                if (tbTo.Text != null)
                {
                    mailMessage.To.Add(tbTo.Text);
                } else
                if (tbCc.Text != null)
                {
                    mailMessage.CC.Add(tbCc.Text);
                } else
                if (tbBcc.Text != null)
                {
                    mailMessage.Bcc.Add(tbBcc.Text);
                }
                

                //件名（タイトル）
                mailMessage.Subject = tbTitle.Text;
                //本文
                mailMessage.Body = tbMessage.Text;
                
                //メール送信のための認証情報を設定（ユーザー名、パスワード）
                smtpClient.Credentials
                    = new NetworkCredential(settings.MailAddr/*"ojsinfosys01@gmail.com"*/, settings.Pass /*"Infosys2021"*/);
                smtpClient.Host = settings.Host;    /*"smtp.gmail.com"*/
                smtpClient.Port = settings.Port;    /*587*/
                smtpClient.EnableSsl = settings.Ssl;

                smtpClient.SendAsync(mailMessage, mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sc_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                //SendAsyncで指定されたMailMessageを取得する
                MailMessage msg = (MailMessage)e.UserState;

                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else
                {
                    MessageBox.Show("送信が完了しました。");
                }
                msg.Dispose();
                btSend.Enabled = true;
                btCancel.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }           
            

        }

        private void btConfig_Click(object sender, EventArgs e)
        {
            configForm.ShowDialog();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (smtpClient != null)
                smtpClient.SendAsyncCancel();
            MessageBox.Show("送信をキャンセルしました。");
            btSend.Enabled = true;
            btCancel.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var reader = XmlReader.Create("ConfigXml.xml"))
            {
                var serializer = new DataContractSerializer(typeof(Settings));
                var novel = serializer.ReadObject(reader) as Settings;
            }
            configForm.tbHost.Text = settings.Host; //ホスト名
            configForm.tbPort.Text = settings.Port.ToString(); //ポート番号
            configForm.tbPass.Text = settings.Pass; //パスワード
            configForm.tbUserName.Text = settings.MailAddr; //ユーザ名
            configForm.cbSSL.Checked = settings.Ssl; //SSL
            configForm.tbSender.Text = settings.MailAddr; //送信元
        }
    }
}
