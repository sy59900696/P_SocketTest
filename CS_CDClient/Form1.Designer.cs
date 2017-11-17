namespace CS_CDClient
{
    partial class Form1
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
            this.btn_单条发送 = new System.Windows.Forms.Button();
            this.btn_循环发送 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_充电页_实时电价 = new System.Windows.Forms.TextBox();
            this.gbx_Logo = new System.Windows.Forms.GroupBox();
            this.txt_Logo_Car = new System.Windows.Forms.TextBox();
            this.txt_Logo_Msg = new System.Windows.Forms.TextBox();
            this.txt_Logo_ID = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_启动桩 = new System.Windows.Forms.Button();
            this.lbl_Msg2Server = new System.Windows.Forms.Label();
            this.lbl_Msg2Client = new System.Windows.Forms.Label();
            this.ckbx_枪连接OK = new System.Windows.Forms.CheckBox();
            this.btn_停止充电 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_端口 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_间隔 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_停止循环 = new System.Windows.Forms.Button();
            this.txt_线程数 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Msg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbx_Logo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_单条发送
            // 
            this.btn_单条发送.Location = new System.Drawing.Point(16, 15);
            this.btn_单条发送.Name = "btn_单条发送";
            this.btn_单条发送.Size = new System.Drawing.Size(107, 23);
            this.btn_单条发送.TabIndex = 0;
            this.btn_单条发送.Text = "单条发送(&S)";
            this.btn_单条发送.UseVisualStyleBackColor = true;
            this.btn_单条发送.Click += new System.EventHandler(this.btn_单条发送_Click);
            // 
            // btn_循环发送
            // 
            this.btn_循环发送.Location = new System.Drawing.Point(11, 39);
            this.btn_循环发送.Name = "btn_循环发送";
            this.btn_循环发送.Size = new System.Drawing.Size(107, 23);
            this.btn_循环发送.TabIndex = 1;
            this.btn_循环发送.Text = "循环发送(&T)";
            this.btn_循环发送.UseVisualStyleBackColor = true;
            this.btn_循环发送.Click += new System.EventHandler(this.btn_循环发送_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1247, 258);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.gbx_Logo);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1251, 477);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.SplitterWidth = 14;
            this.splitContainer1.TabIndex = 3;
            // 
            // txt_充电页_实时电价
            // 
            this.txt_充电页_实时电价.Location = new System.Drawing.Point(193, 20);
            this.txt_充电页_实时电价.Name = "txt_充电页_实时电价";
            this.txt_充电页_实时电价.Size = new System.Drawing.Size(181, 21);
            this.txt_充电页_实时电价.TabIndex = 0;
            // 
            // gbx_Logo
            // 
            this.gbx_Logo.Controls.Add(this.txt_Logo_Car);
            this.gbx_Logo.Controls.Add(this.txt_充电页_实时电价);
            this.gbx_Logo.Controls.Add(this.txt_Logo_Msg);
            this.gbx_Logo.Location = new System.Drawing.Point(174, 10);
            this.gbx_Logo.Name = "gbx_Logo";
            this.gbx_Logo.Size = new System.Drawing.Size(382, 98);
            this.gbx_Logo.TabIndex = 9;
            this.gbx_Logo.TabStop = false;
            this.gbx_Logo.Text = "Logo页：状态/车辆/电价";
            // 
            // txt_Logo_Car
            // 
            this.txt_Logo_Car.Location = new System.Drawing.Point(6, 47);
            this.txt_Logo_Car.Multiline = true;
            this.txt_Logo_Car.Name = "txt_Logo_Car";
            this.txt_Logo_Car.Size = new System.Drawing.Size(368, 45);
            this.txt_Logo_Car.TabIndex = 2;
            // 
            // txt_Logo_Msg
            // 
            this.txt_Logo_Msg.Location = new System.Drawing.Point(6, 20);
            this.txt_Logo_Msg.Name = "txt_Logo_Msg";
            this.txt_Logo_Msg.Size = new System.Drawing.Size(181, 21);
            this.txt_Logo_Msg.TabIndex = 1;
            // 
            // txt_Logo_ID
            // 
            this.txt_Logo_ID.Location = new System.Drawing.Point(44, 65);
            this.txt_Logo_ID.Name = "txt_Logo_ID";
            this.txt_Logo_ID.Size = new System.Drawing.Size(105, 21);
            this.txt_Logo_ID.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_Msg2Server);
            this.groupBox4.Controls.Add(this.lbl_Msg2Client);
            this.groupBox4.Controls.Add(this.ckbx_枪连接OK);
            this.groupBox4.Controls.Add(this.btn_停止充电);
            this.groupBox4.Location = new System.Drawing.Point(10, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1075, 69);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "充电桩";
            // 
            // btn_启动桩
            // 
            this.btn_启动桩.Location = new System.Drawing.Point(86, 39);
            this.btn_启动桩.Name = "btn_启动桩";
            this.btn_启动桩.Size = new System.Drawing.Size(63, 23);
            this.btn_启动桩.TabIndex = 12;
            this.btn_启动桩.Text = "启动桩";
            this.btn_启动桩.UseVisualStyleBackColor = true;
            this.btn_启动桩.Click += new System.EventHandler(this.btn_启动桩_Click);
            // 
            // lbl_Msg2Server
            // 
            this.lbl_Msg2Server.AutoSize = true;
            this.lbl_Msg2Server.Location = new System.Drawing.Point(84, 44);
            this.lbl_Msg2Server.Name = "lbl_Msg2Server";
            this.lbl_Msg2Server.Size = new System.Drawing.Size(65, 12);
            this.lbl_Msg2Server.TabIndex = 11;
            this.lbl_Msg2Server.Text = "Msg2Server";
            // 
            // lbl_Msg2Client
            // 
            this.lbl_Msg2Client.AutoSize = true;
            this.lbl_Msg2Client.Location = new System.Drawing.Point(84, 17);
            this.lbl_Msg2Client.Name = "lbl_Msg2Client";
            this.lbl_Msg2Client.Size = new System.Drawing.Size(65, 12);
            this.lbl_Msg2Client.TabIndex = 10;
            this.lbl_Msg2Client.Text = "Msg2Client";
            // 
            // ckbx_枪连接OK
            // 
            this.ckbx_枪连接OK.AutoSize = true;
            this.ckbx_枪连接OK.Location = new System.Drawing.Point(6, 44);
            this.ckbx_枪连接OK.Name = "ckbx_枪连接OK";
            this.ckbx_枪连接OK.Size = new System.Drawing.Size(72, 16);
            this.ckbx_枪连接OK.TabIndex = 9;
            this.ckbx_枪连接OK.Text = "枪连接OK";
            this.ckbx_枪连接OK.UseVisualStyleBackColor = true;
            // 
            // btn_停止充电
            // 
            this.btn_停止充电.Location = new System.Drawing.Point(6, 14);
            this.btn_停止充电.Name = "btn_停止充电";
            this.btn_停止充电.Size = new System.Drawing.Size(63, 23);
            this.btn_停止充电.TabIndex = 3;
            this.btn_停止充电.Text = "停止充电";
            this.btn_停止充电.UseVisualStyleBackColor = true;
            this.btn_停止充电.Click += new System.EventHandler(this.btn_停止充电_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btn_启动桩);
            this.groupBox3.Controls.Add(this.txt_端口);
            this.groupBox3.Controls.Add(this.txt_Logo_ID);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txt_IP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 86);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // txt_端口
            // 
            this.txt_端口.Location = new System.Drawing.Point(44, 41);
            this.txt_端口.Name = "txt_端口";
            this.txt_端口.Size = new System.Drawing.Size(35, 21);
            this.txt_端口.TabIndex = 6;
            this.txt_端口.Text = "8888";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(44, 17);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(105, 21);
            this.txt_IP.TabIndex = 3;
            this.txt_IP.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_间隔);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_停止循环);
            this.groupBox2.Controls.Add(this.btn_循环发送);
            this.groupBox2.Controls.Add(this.txt_线程数);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(10, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 63);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量循环发送";
            // 
            // txt_间隔
            // 
            this.txt_间隔.Location = new System.Drawing.Point(218, 17);
            this.txt_间隔.Name = "txt_间隔";
            this.txt_间隔.Size = new System.Drawing.Size(35, 21);
            this.txt_间隔.TabIndex = 6;
            this.txt_间隔.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "单线程间隔毫秒";
            // 
            // btn_停止循环
            // 
            this.btn_停止循环.Location = new System.Drawing.Point(135, 40);
            this.btn_停止循环.Name = "btn_停止循环";
            this.btn_停止循环.Size = new System.Drawing.Size(107, 23);
            this.btn_停止循环.TabIndex = 5;
            this.btn_停止循环.Text = "停止循环(&C)";
            this.btn_停止循环.UseVisualStyleBackColor = true;
            this.btn_停止循环.Click += new System.EventHandler(this.btn_停止循环_Click);
            // 
            // txt_线程数
            // 
            this.txt_线程数.Location = new System.Drawing.Point(56, 17);
            this.txt_线程数.Name = "txt_线程数";
            this.txt_线程数.Size = new System.Drawing.Size(35, 21);
            this.txt_线程数.TabIndex = 3;
            this.txt_线程数.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "线程数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_单条发送);
            this.groupBox1.Controls.Add(this.txt_Msg);
            this.groupBox1.Location = new System.Drawing.Point(10, 281);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 38);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单条发送";
            // 
            // txt_Msg
            // 
            this.txt_Msg.Location = new System.Drawing.Point(129, 15);
            this.txt_Msg.Name = "txt_Msg";
            this.txt_Msg.Size = new System.Drawing.Size(146, 21);
            this.txt_Msg.TabIndex = 2;
            this.txt_Msg.Text = "测试一下";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "桩ID";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox2);
            this.groupBox5.Location = new System.Drawing.Point(563, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(681, 98);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "说明";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 17);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(675, 78);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "左侧Logo页，代表了桩界面。。\n状态：0:桩故障; 1:充电中; 2:收到了服务端的停止指令; 3:就绪; 4:充电中，枪未连接; 5:用户按下桩上的停止键\n电" +
    "价：从Server实时取得。(当前秒数/10)\n枪连接后，展示车辆信息。\n\n操作：\n1。Server——开启监听\n2。Client——启动桩\n3。App扫码\n4" +
    "。插拔枪\n5。停止、APP停止等。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 477);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "单枪充电桩";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbx_Logo.ResumeLayout(false);
            this.gbx_Logo.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_单条发送;
        private System.Windows.Forms.Button btn_循环发送;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Msg;
        private System.Windows.Forms.TextBox txt_线程数;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_停止循环;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_间隔;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_端口;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_停止充电;
        private System.Windows.Forms.CheckBox ckbx_枪连接OK;
        private System.Windows.Forms.Label lbl_Msg2Server;
        private System.Windows.Forms.Label lbl_Msg2Client;
        private System.Windows.Forms.Button btn_启动桩;
        private System.Windows.Forms.GroupBox gbx_Logo;
        private System.Windows.Forms.TextBox txt_Logo_Msg;
        private System.Windows.Forms.TextBox txt_Logo_ID;
        private System.Windows.Forms.TextBox txt_充电页_实时电价;
        private System.Windows.Forms.TextBox txt_Logo_Car;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

