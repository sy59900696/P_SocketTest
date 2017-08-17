namespace CS_SocketServer
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
            this.txt_Msg = new System.Windows.Forms.TextBox();
            this.txt_线程数 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_停止循环 = new System.Windows.Forms.Button();
            this.txt_间隔 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_端口 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.richTextBox1.Size = new System.Drawing.Size(923, 230);
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(927, 328);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.SplitterWidth = 14;
            this.splitContainer1.TabIndex = 3;
            // 
            // txt_Msg
            // 
            this.txt_Msg.Location = new System.Drawing.Point(129, 15);
            this.txt_Msg.Name = "txt_Msg";
            this.txt_Msg.Size = new System.Drawing.Size(146, 21);
            this.txt_Msg.TabIndex = 2;
            this.txt_Msg.Text = "测试一下";
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
            this.groupBox1.Location = new System.Drawing.Point(438, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 38);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单条发送";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_间隔);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_停止循环);
            this.groupBox2.Controls.Add(this.btn_循环发送);
            this.groupBox2.Controls.Add(this.txt_线程数);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(174, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 63);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量循环发送";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_端口);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txt_IP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 69);
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
            this.txt_端口.Text = "7777";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 328);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "CS_SocketClient";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
    }
}

