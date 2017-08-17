using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CS_SocketServer
{
    public partial class Form1 : Form
    {
        public int m_iPort = 7777;
        static Socket m_ServerSocket;
        private bool m_IsRun = true;
        private int m_i收发计数 = 0;
        private DateTime m_dtStart = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void M_开启监听()
        {
            //服务器IP地址   
            m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_ServerSocket.SendTimeout = 1000;
            m_ServerSocket.ReceiveTimeout = 1000;
            m_ServerSocket.Bind(new IPEndPoint(IPAddress.Any, m_iPort));  //绑定IP地址：端口  
            m_ServerSocket.Listen(100);    //设定最多10个排队连接请求  
            m_IsRun = true;
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(M_循环监听);
            myThread.IsBackground = true;
            myThread.Start();
            m_dtStart = DateTime.Now;
            M_Logger(string.Format("启动监听{0}成功", m_ServerSocket.LocalEndPoint.ToString()));
        }
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void M_循环监听()
        {
            try
            {
                M_Logger("M_循环监听()");
                while (m_IsRun)
                {
                    Socket _clientSocket = m_ServerSocket.Accept();
                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.IsBackground = true;
                    receiveThread.Start(_clientSocket);
                }
                M_Logger(string.Format("M_循环监听()while结束。"));
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("M_循环监听()异常：{0}", ex.Message.ToString()));
            }
        }

        /// <summary>  
        /// 接收消息。//简单期间，假设传输的数据都不超过1K。否则需要约定结束标志，接收时做循环接收，直至检查到结束标志。
        /// </summary>  
        /// <param name="obj"></param>  
        private void ReceiveMessage(object obj)
        {
            try
            {
                Socket _clientSocket = (Socket)obj;
                try
                {
                    byte[] _buffer = new byte[1024];
                    int _iReceiveCount = _clientSocket.Receive(_buffer);
                    //接收后，拆解数据，格式不合法则抛出异常。
                    string _sResult = Encoding.UTF8.GetString(_buffer, 0, _iReceiveCount);
                    M_Logger(string.Format("接收客户端=【{0}】\t消息=【{1}】", _clientSocket.RemoteEndPoint.ToString(), _sResult));
                    {
                    }
                    _clientSocket.Send(Encoding.UTF8.GetBytes(_sResult));
                    M_Logger("反馈完成。");
                    m_i收发计数++;
                }
                catch (Exception ex)
                {
                    M_Logger(string.Format("Receive()反馈时异常：{0}", ex.Message.ToString()));
                }
                finally
                {
                    _clientSocket.Shutdown(SocketShutdown.Both);
                    _clientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("ReceiveMessage()异常：{0}", ex.Message.ToString()));
            }
        }

        private void btn_开启监听_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_开启监听_Click()");
                btn_开启监听.Enabled = false;
                m_iPort = int.Parse(txt_端口.Text);
                M_开启监听();
                M_Logger(string.Format("btn_开启监听_Click()完成;"));
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_开启监听_Click()异常：{0}", ex.Message.ToString()));
            }
        }

        private void btn_停止监听_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_停止监听_Click()");
                btn_开启监听.Enabled = true;
                m_IsRun = false;
                m_ServerSocket.Close();
                m_ServerSocket.Dispose();
                M_Logger(string.Format("btn_停止监听_Click()m_ServerSocket.Dispose();"));
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_停止监听_Click()异常：{0}", ex.Message.ToString()));
            }
        }

        private void M_Logger(string sMsg)
        {
            Logger.Debug(sMsg);
            this.Invoke(new Action(() =>
            {
                try
                {

                    if (m_i收发计数 % 5000 == 0)
                    {
                        if (richTextBox1.TextLength > 3000)
                            richTextBox1.Clear();
                        richTextBox1.AppendText(string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("HH:mm:ss-fff"), sMsg));
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.ScrollToCaret();

                        double _dTimeSpan = (DateTime.Now - m_dtStart).TotalSeconds;

                        lbl_累计收发.Text = string.Format("累计收发【{0}】次。开始时间【{1}】，已耗时【{2}】，速度大概【{3}】次每秒", m_i收发计数.ToString(), m_dtStart.ToString(), _dTimeSpan, m_i收发计数 / _dTimeSpan);
                        if (m_i收发计数 > 99999999)
                        {
                            this.Text += "A";
                            m_i收发计数 = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug(string.Format("M_Logger()异常：{0}", ex.Message.ToString()));
                }
            }));
        }
    }
}
