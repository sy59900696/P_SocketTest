namespace CS_AsynServer
{
    partial class Form_AsynServer
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_端口 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_累计收发 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(733, 234);
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
            this.splitContainer1.Panel1.Controls.Add(this.txt_端口);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_累计收发);
            this.splitContainer1.Panel1.Controls.Add(this.btn_开启监听);
            this.splitContainer1.Panel1.Controls.Add(this.btn_停止监听);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(737, 328);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.SplitterWidth = 14;
            this.splitContainer1.TabIndex = 3;
            // 
            // txt_端口
            // 
            this.txt_端口.Location = new System.Drawing.Point(186, 10);
            this.txt_端口.Name = "txt_端口";
            this.txt_端口.Size = new System.Drawing.Size(35, 21);
            this.txt_端口.TabIndex = 6;
            this.txt_端口.Text = "7777";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 328);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "CS_AsynServer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_开启监听;
        private System.Windows.Forms.Button btn_停止监听;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_累计收发;
        private System.Windows.Forms.TextBox txt_端口;
        private System.Windows.Forms.Label label3;
    }
}

