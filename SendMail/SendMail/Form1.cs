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
        public Settings settings = Settings.getInstance();


        //xmlファイルの作成
        public static XmlWriter xmlConfigFile;


        public Form1()
        {
            InitializeComponent();
            btCancel.Enabled = false;
        }


        private void btSend_Click(object sender, EventArgs e)
        {
            if (!Settings.ConfigDataChek)
            {
                MessageBox.Show("送信情報を設定してください");
                return;
            }
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
                }
                else
                if (tbCc.Text != null)
                {
                    mailMessage.CC.Add(tbCc.Text);
                }
                else
                if (tbBcc.Text != null)
                {
                    mailMessage.Bcc.Add(tbBcc.Text);
                }


                //件名（タイトル）
                mailMessage.Subject = tbTitle.Text;
                //本文
                if (tbMessage.Text != "" )
                {
                    mailMessage.Body = tbMessage.Text;
                }
                else
                {
                    MessageBox.Show("本文を入力してください");
                    return;
                }
                

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
                    TextClear();
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
            //起動時に送信情報が未設定の場合、設定画面を表示する
            if (!Settings.ConfigDataChek)
            {
                configForm.ShowDialog();
            }
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextClear();
        }

        private void TextClear() 
        {
            tbTo.Text = null;
            tbBcc.Text = null;
            tbCc.Text = null;
            tbTitle.Text = null;
            tbMessage.Text = null;
        }
    }
}
