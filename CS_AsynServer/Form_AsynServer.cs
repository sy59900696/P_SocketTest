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

namespace CS_AsynServer
{
    public partial class Form_AsynServer : Form
    {
        public int m_iPort = 7777;
        static Socket m_ServerSocket;
        private bool m_IsRun = true;
        private int m_i收发计数 = 0;
        private DateTime m_dtStart = DateTime.Now;

        public Form_AsynServer()
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
            //Thread myThread = new Thread(M_循环监听);
            //myThread.IsBackground = true;
            //myThread.Start(); 
            AsyncAccept(m_ServerSocket);
            m_dtStart = DateTime.Now;
            M_Logger(string.Format("启动监听{0}成功", m_ServerSocket.LocalEndPoint.ToString()));
        }
        ///// <summary>  
        ///// 监听客户端连接  
        ///// </summary>  
        //private void M_循环监听()
        //{
        //    try
        //    {
        //        int _iCountTmp = 0;
        //        M_Logger("M_循环监听()");
        //        while (m_IsRun)
        //        {
        //            M_Logger(string.Format("m_IsRun = {0}, _iCountTmp = {1}", m_IsRun, _iCountTmp));
        //            Socket _clientSocket = m_ServerSocket.Accept();
        //            byte[] buffer = new byte[1024];
        //            _clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), _clientSocket);
        //            M_Logger(string.Format("m_IsRun = {0}, _iCountTmp = {1}，while", m_IsRun, _iCountTmp));
        //        }
        //        M_Logger(string.Format("M_循环监听()while结束。"));
        //    }
        //    catch (Exception ex)
        //    {
        //        M_Logger(string.Format("M_循环监听()异常：{0}", ex.Message.ToString()));
        //    }
        //}
        /// <summary>  
        /// 连接到客户端  
        /// </summary>  
        /// <param name="socket"></param>  
        private void AsyncAccept(Socket socket)
        {
            //Logger.Debug(string.Format("m_IsRun = {0}", m_IsRun));
            socket.BeginAccept(asyncResult =>
            {
                Logger.Debug("进入socket.BeginAccept()");
                //获取客户端套接字  
                Socket client = socket.EndAccept(asyncResult);
                M_Logger(string.Format("客户端{0}请求连接...", client.RemoteEndPoint));
                //AsyncSend(client, "服务器收到连接请求");
                //AsyncSend(client, string.Format("欢迎你{0}", client.RemoteEndPoint));
                AsyncReveive(client);
                Logger.Debug("进入socket.BeginAccept()完成。");
            }, null);
            Logger.Debug("AsyncAccept()完成。");
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="client"></param>  
        private void AsyncReveive(Socket socket)
        {
            byte[] data = new byte[1024];
            try
            {
                //开始接收消息  
                socket.BeginReceive(data, 0, data.Length, SocketFlags.None,
                asyncResult =>
                {
                    while (m_IsRun && socket.Connected)
                    {
                        try
                        {
                            Logger.Debug("进入AsyncReveive()的IsRun。");
                            int length = socket.Receive(data);
                            if (length <= 0)
                            {
                                throw new Exception("length <= 0");
                            }
                            string _sMsg = Encoding.UTF8.GetString(data, 0, length);
                            M_Logger(string.Format("接收客户端=【{0}】\t消息=【{1}】", socket.RemoteEndPoint.ToString(), _sMsg));
                            socket.Send(Encoding.UTF8.GetBytes(_sMsg));
                            M_Logger(string.Format("反馈完成。"));
                            Logger.Debug("进入AsyncReveive()的IsRun完成。。");
                        }
                        catch (Exception ex)
                        {
                            Logger.Debug(string.Format("进入AsyncReveive()的IsRun异常:{0}", ex.Message.ToString()));
                            break;
                        }
                    }
                }, null);
            }
            catch (Exception ex)
            {
                M_Logger(ex.Message);
            }
        }

        /// <summary>  
        /// 发送消息  
        /// </summary>  
        /// <param name="client"></param>  
        /// <param name="p"></param>  
        private void AsyncSend(Socket client, string p)
        {
            if (client == null || p == string.Empty) return;
            //数据转码  
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes(p);
            try
            {
                //开始发送消息  
                client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    //完成消息发送  
                    int length = client.EndSend(asyncResult);
                    //输出消息  
                    M_Logger(string.Format("服务器发出消息:{0}", p));
                }, null);
            }
            catch (Exception e)
            {
                M_Logger(e.Message);
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
