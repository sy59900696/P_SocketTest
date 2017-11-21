namespace CS_UdpServer
{
    partial class Form_UdpServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_开启监听 = new System.Windows.Forms.Button();
            this.btn_停止监听 = new System.Windows.Forms.Button();
            this.rtxt_Log = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_停止充电 = new System.Windows.Forms.Button();
            this.btn_开始充电 = new System.Windows.Forms.Button();
            this.txt_端口 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_累计收发 = new System.Windows.Forms.Label();
            this.rtxt_MsgData = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_开启监听
            // 
            this.btn_开启监听.Location = new System.Drawing.Point(10, 8);
            this.btn_开启监听.Name = "btn_开启监听";
            this.btn_开启监听.Size = new System.Drawing.Size(125, 23);
            this.btn_开启监听.TabIndex = 0;
            this.btn_开启监听.Text = "开启监听(&S)";
            this.btn_开启监听.UseVisualStyleBackColor = true;
            this.btn_开启监听.Click += new System.EventHandler(this.btn_开启监听_Click);
            // 
            // btn_停止监听
            // 
            this.btn_停止监听.Location = new System.Drawing.Point(10, 37);
            this.btn_停止监听.Name = "btn_停止监听";
            this.btn_停止监听.Size = new System.Drawing.Size(125, 23);
            this.btn_停止监听.TabIndex = 1;
            this.btn_停止监听.Text = "停止监听(&C)";
            this.btn_停止监听.UseVisualStyleBackColor = true;
            this.btn_停止监听.Click += new System.EventHandler(this.btn_停止监听_Click);
            // 
            // rtxt_Log
            // 
            this.rtxt_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_Log.Location = new System.Drawing.Point(0, 0);
            this.rtxt_Log.Name = "rtxt_Log";
            this.rtxt_Log.Size = new System.Drawing.Size(330, 223);
            this.rtxt_Log.TabIndex = 2;
            this.rtxt_Log.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_端口);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_累计收发);
            this.splitContainer1.Panel1.Controls.Add(this.btn_开启监听);
            this.splitContainer1.Panel1.Controls.Add(this.btn_停止监听);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(855, 328);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.SplitterWidth = 14;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btn_停止充电);
            this.groupBox1.Controls.Add(this.btn_开始充电);
            this.groupBox1.Location = new System.Drawing.Point(286, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 70);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "0";
            // 
            // btn_停止充电
            // 
            this.btn_停止充电.Location = new System.Drawing.Point(87, 20);
            this.btn_停止充电.Name = "btn_停止充电";
            this.btn_停止充电.Size = new System.Drawing.Size(90, 23);
            this.btn_停止充电.TabIndex = 11;
            this.btn_停止充电.Text = "APP停止充电";
            this.btn_停止充电.UseVisualStyleBackColor = true;
            this.btn_停止充电.Click += new System.EventHandler(this.btn_停止充电_Click);
            // 
            // btn_开始充电
            // 
            this.btn_开始充电.Location = new System.Drawing.Point(6, 20);
            this.btn_开始充电.Name = "btn_开始充电";
            this.btn_开始充电.Size = new System.Drawing.Size(75, 23);
            this.btn_开始充电.TabIndex = 10;
            this.btn_开始充电.Text = "APP扫码";
            this.btn_开始充电.UseVisualStyleBackColor = true;
            this.btn_开始充电.Click += new System.EventHandler(this.btn_开始充电_Click);
            // 
            // txt_端口
            // 
            this.txt_端口.Location = new System.Drawing.Point(186, 10);
            this.txt_端口.Name = "txt_端口";
            this.txt_端口.Size = new System.Drawing.Size(35, 21);
            this.txt_端口.TabIndex = 6;
            this.txt_端口.Text = "8888";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // lbl_累计收发
            // 
            this.lbl_累计收发.AutoSize = true;
            this.lbl_累计收发.Location = new System.Drawing.Point(151, 42);
            this.lbl_累计收发.Name = "lbl_累计收发";
            this.lbl_累计收发.Size = new System.Drawing.Size(119, 12);
            this.lbl_累计收发.TabIndex = 2;
            this.lbl_累计收发.Text = "累计收发【{0}】次。";
            // 
            // rtxt_MsgData
            // 
            this.rtxt_MsgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_MsgData.Location = new System.Drawing.Point(0, 0);
            this.rtxt_MsgData.Name = "rtxt_MsgData";
            this.rtxt_MsgData.Size = new System.Drawing.Size(497, 223);
            this.rtxt_MsgData.TabIndex = 13;
            this.rtxt_MsgData.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rtxt_MsgData);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtxt_Log);
            this.splitContainer2.Size = new System.Drawing.Size(855, 227);
            this.splitContainer2.SplitterDistance = 501;
            this.splitContainer2.SplitterWidth = 20;
            this.splitContainer2.TabIndex = 3;
            // 
            // Form_UdpServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 328);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_UdpServer";
            this.Text = "UdpServer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_开启监听;
        private System.Windows.Forms.Button btn_停止监听;
        private System.Windows.Forms.RichTextBox rtxt_Log;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_累计收发;
        private System.Windows.Forms.TextBox txt_端口;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_开始充电;
        private System.Windows.Forms.Button btn_停止充电;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox rtxt_MsgData;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

