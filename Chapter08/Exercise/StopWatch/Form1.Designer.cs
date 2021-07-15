
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
            this.tmdisp = new System.Windows.Forms.Timer(this.components);
            this.lbTimeDisp = new System.Windows.Forms.Label();
            this.btTimeSt = new System.Windows.Forms.Button();
            this.btTimeSp = new System.Windows.Forms.Button();
            this.btLap = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.lbLapDisp = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tmdisp
            // 
            this.tmdisp.Tick += new System.EventHandler(this.tmdisp_Tick_1);
            // 
            // lbTimeDisp
            // 
            this.lbTimeDisp.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbTimeDisp.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTimeDisp.Location = new System.Drawing.Point(15, 30);
            this.lbTimeDisp.Name = "lbTimeDisp";
            this.lbTimeDisp.Size = new System.Drawing.Size(382, 65);
            this.lbTimeDisp.TabIndex = 0;
            // 
            // btTimeSt
            // 
            this.btTimeSt.Location = new System.Drawing.Point(15, 109);
            this.btTimeSt.Name = "btTimeSt";
            this.btTimeSt.Size = new System.Drawing.Size(188, 105);
            this.btTimeSt.TabIndex = 1;
            this.btTimeSt.Text = "タイマースタート";
            this.btTimeSt.UseVisualStyleBackColor = true;
            this.btTimeSt.Click += new System.EventHandler(this.btTimeSt_Click);
            // 
            // btTimeSp
            // 
            this.btTimeSp.Location = new System.Drawing.Point(15, 216);
            this.btTimeSp.Name = "btTimeSp";
            this.btTimeSp.Size = new System.Drawing.Size(188, 105);
            this.btTimeSp.TabIndex = 1;
            this.btTimeSp.Text = "タイマーストップ";
            this.btTimeSp.UseVisualStyleBackColor = true;
            this.btTimeSp.Click += new System.EventHandler(this.btTimeSp_Click);
            // 
            // btLap
            // 
            this.btLap.Location = new System.Drawing.Point(209, 216);
            this.btLap.Name = "btLap";
            this.btLap.Size = new System.Drawing.Size(188, 105);
            this.btLap.TabIndex = 1;
            this.btLap.Text = "ラップ→";
            this.btLap.UseVisualStyleBackColor = true;
            this.btLap.Click += new System.EventHandler(this.btLap_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(209, 109);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(188, 105);
            this.btReset.TabIndex = 1;
            this.btReset.Text = "リセット";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // lbLapDisp
            // 
            this.lbLapDisp.FormattingEnabled = true;
            this.lbLapDisp.ItemHeight = 12;
            this.lbLapDisp.Location = new System.Drawing.Point(403, 30);
            this.lbLapDisp.Name = "lbLapDisp";
            this.lbLapDisp.Size = new System.Drawing.Size(168, 292);
            this.lbLapDisp.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 337);
            this.Controls.Add(this.lbLapDisp);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btLap);
            this.Controls.Add(this.btTimeSp);
            this.Controls.Add(this.btTimeSt);
            this.Controls.Add(this.lbTimeDisp);
            this.Name = "Form1";
            this.Text = "タイマー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmdisp;
        private System.Windows.Forms.Label lbTimeDisp;
        private System.Windows.Forms.Button btTimeSt;
        private System.Windows.Forms.Button btTimeSp;
        private System.Windows.Forms.Button btLap;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.ListBox lbLapDisp;
    }
}

