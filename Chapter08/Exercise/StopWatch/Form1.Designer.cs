
namespace StopWatch {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTimeDisp = new System.Windows.Forms.Label();
            this.btTimeSt = new System.Windows.Forms.Button();
            this.btTimeSp = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTimeDisp
            // 
            this.lbTimeDisp.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbTimeDisp.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTimeDisp.Location = new System.Drawing.Point(14, 30);
            this.lbTimeDisp.Name = "lbTimeDisp";
            this.lbTimeDisp.Size = new System.Drawing.Size(428, 65);
            this.lbTimeDisp.TabIndex = 0;
            // 
            // btTimeSt
            // 
            this.btTimeSt.Location = new System.Drawing.Point(14, 115);
            this.btTimeSt.Name = "btTimeSt";
            this.btTimeSt.Size = new System.Drawing.Size(211, 101);
            this.btTimeSt.TabIndex = 1;
            this.btTimeSt.Text = "タイマースタート";
            this.btTimeSt.UseVisualStyleBackColor = true;
            this.btTimeSt.Click += new System.EventHandler(this.btTimeSt_Click);
            // 
            // btTimeSp
            // 
            this.btTimeSp.Location = new System.Drawing.Point(231, 115);
            this.btTimeSp.Name = "btTimeSp";
            this.btTimeSp.Size = new System.Drawing.Size(211, 101);
            this.btTimeSp.TabIndex = 1;
            this.btTimeSp.Text = "タイマーストップ";
            this.btTimeSp.UseVisualStyleBackColor = true;
            this.btTimeSp.Click += new System.EventHandler(this.btTimeSp_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(231, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 101);
            this.button3.TabIndex = 1;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(211, 101);
            this.button4.TabIndex = 1;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 380);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btTimeSp);
            this.Controls.Add(this.btTimeSt);
            this.Controls.Add(this.lbTimeDisp);
            this.Name = "Form1";
            this.Text = "タイマー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTimeDisp;
        private System.Windows.Forms.Button btTimeSt;
        private System.Windows.Forms.Button btTimeSp;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

