﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_TcpClient
{
    public partial class Form1 : Form
    {
        public string m_sIP = "127.0.0.1";
        public int m_iPort = 7777;
        //private List<Thread> m_lstThread = new List<Thread>();
        private bool m_IsRun = true;
        private int m_i线程数 = 0;
        private int m_i单个线程循环间隔 = 0;
        private List<C_MyThread> m_lstMyThread = new List<C_MyThread>();
        private C_MyThread m_MyThread;

        //private Socket m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        public Form1()
        {
            InitializeComponent();
        }

        private void M_Logger(string sMsg)
        {
            Logger.Debug(sMsg);
            this.Invoke(new Action(() =>
            {
                try
                {
                    if (richTextBox1.TextLength > 3000)
                        richTextBox1.Clear();
                    richTextBox1.AppendText(string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("HH:mm:ss-fff"), sMsg));
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }
                catch (Exception ex)
                {
                    M_Logger(string.Format("M_Logger()异常：{0}", ex.Message.ToString()));
                }
            }));
        }

        private void btn_建立连接_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_建立连接_Click()");
                m_sIP = IPAddress.Parse(txt_IP.Text).ToString();
                m_iPort = int.Parse(txt_端口.Text);
                m_MyThread = new C_MyThread(m_sIP, m_iPort, "单条发送0");
                m_MyThread.M_Connect();
                btn_建立连接.Enabled = false;
                btn_断开连接.Enabled = true;
                M_Logger("btn_建立连接_Click()完成。");
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_建立连接_Click()异常：{0}", ex.Message.ToString()));
            }
        }

        private void btn_单条发送_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_单条发送_Click()");
                m_MyThread.M_Send(txt_Msg.Text);
                M_Logger("btn_单条发送_Click()完成。");
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_单条发送_Click()异常：{0}", ex.Message.ToString()));
            }
        }

        private void btn_循环发送_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_循环发送_Click()");
                m_sIP = IPAddress.Parse(txt_IP.Text).ToString();
                m_iPort = int.Parse(txt_端口.Text);
                btn_循环发送.Enabled = false;
                m_i线程数 = int.Parse(txt_线程数.Text.Trim());
                m_i单个线程循环间隔 = int.Parse(txt_间隔.Text.Trim());
                m_IsRun = true;

                //重新建立线程。
                for (int i = 0; i < m_i线程数; i++)
                {
                    C_MyThread _c0 = new C_MyThread(m_sIP, m_iPort, "Client " + i.ToString());

                    _c0.m_Thread = new Thread(new ParameterizedThreadStart(M_循环发送));
                    _c0.m_Thread.IsBackground = true;
                    _c0.m_Thread.Name = string.Format("Sender{0}", i);
                    m_lstMyThread.Add(_c0);
                    //m_lstThread.Add(_t0);
                }

                //启动线程。
                foreach (C_MyThread _c0 in m_lstMyThread)
                {
                    _c0.m_Thread.Start(_c0);
                }

                M_Logger("btn_循环发送_Click()完成。");
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_循环发送_Click()异常：{0}", ex.Message.ToString()));
                btn_循环发送.Enabled = true;
            }
        }

        private void M_循环发送(object _obj)
        {
            try
            {

                C_MyThread _c0 = _obj as C_MyThread;
                string _sID = _c0.m_Thread.Name;

                try
                {
                    _c0.m_Socket.Connect(new IPEndPoint(IPAddress.Parse(m_sIP), m_iPort)); //配置服务器IP与端口
                    Logger.Debug(string.Format("向IP=【{0}】，port=【{1}】连接成功。。。", m_sIP, m_iPort));
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("向IP=【{0}】，port=【{1}】连接异常：{2}", m_sIP, m_iPort, ex.Message.ToString()));
                }
                for (int i = 0; i < 99999999 && m_IsRun; i++)
                {
                    try
                    {
                        _c0.M_Send(string.Format("[{0}]\t{1}", _sID, i));
                        Thread.Sleep(m_i单个线程循环间隔);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("M_循环发送for内()异常：{0}", ex.Message.ToString()));
                    }
                }
                _c0.m_Socket.Shutdown(SocketShutdown.Both);
                _c0.m_Socket.Close();
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("M_循环发送()异常{0}:", ex.Message.ToString()));
            }

        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void btn_停止循环_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger(string.Format("btn_停止循环_Click()"));
                //先中断原有子线程。强行终止后，可能导致部分socket未能释放。需服务端等待超时后自行释放。

                M_Logger(string.Format("m_lstMyThread.Count={0}", m_lstMyThread.Count));
                foreach (C_MyThread _c0 in m_lstMyThread)
                {
                    try
                    {
                        _c0.m_Socket.Shutdown(SocketShutdown.Both);
                        _c0.m_Thread.Abort();
                    }
                    catch (Exception ex)
                    {
                        M_Logger(string.Format("强制中断原有子线程【{0}】，抛出About异常：{1}", _c0.m_Thread.Name, ex.Message.ToString()));
                    }
                }
                Thread.Sleep(200);
                foreach (C_MyThread _c0 in m_lstMyThread) M_Logger(string.Format("_t0.ThreadState={0},\t_t0.IsAlive={1}", _c0.m_Thread.ThreadState, _c0.m_Thread.IsAlive));
                m_lstMyThread.Clear();
                btn_循环发送.Enabled = true;
                m_IsRun = false;
                M_Logger(string.Format("btn_停止循环_Click()完成。"));
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_循环发送_Click()异常：{0}", ex.Message.ToString()));
            }
        }

        private void btn_断开连接_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_断开连接_Click()");
                m_MyThread.M_DisConnect();
                btn_建立连接.Enabled = true;
                btn_断开连接.Enabled = false;
                M_Logger("btn_断开连接_Click()完成。");
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_断开连接_Click()异常：{0}", ex.Message.ToString()));
            }
        }
    }

    class C_MyThread
    {
        public Thread m_Thread { get; set; }
        public Socket m_Socket { get; set; }
        private string m_sIP = "127.0.0.1";
        private int m_iPort = 7777;

        public C_MyThread()
        {

        }

        public C_MyThread(string sIP, int iPort, string sID)
        {
            m_sIP = sIP;
            m_iPort = iPort;
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_Socket.SendTimeout =  1000;
            m_Socket.ReceiveTimeout =  1000;
        }

        public bool M_Connect()
        {
            try
            {
                m_Socket.Connect(new IPEndPoint(IPAddress.Parse(m_sIP), m_iPort)); //配置服务器IP与端口
                Logger.Debug(string.Format("向IP=【{0}】，port=【{1}】连接成功。。。", m_sIP, m_iPort));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("向IP=【{0}】，port=【{1}】连接异常：{2}", m_sIP, m_iPort, ex.Message.ToString()));
            }
        }

        public bool M_DisConnect()
        {
            try
            {
                m_Socket.Shutdown(SocketShutdown.Both);
                m_Socket.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("向IP=【{0}】，port=【{1}】断开连接异常：{2}", m_sIP, m_iPort, ex.Message.ToString()));
            }
        }

        public void M_Send(string _sCmd)
        {
            try
            {
                m_Socket.Send(Encoding.UTF8.GetBytes(_sCmd));

                List<byte> _lst0 = new List<byte>();
                byte[] _buffer = new byte[1024];
                int _iReceiveCount = m_Socket.Receive(_buffer);
                string _sReturn = Encoding.UTF8.GetString(_buffer, 0, _iReceiveCount);

                Logger.Debug(string.Format("向IP=【{0}】，port=【{1}】发送消息【{2}】成功。收到返回【{3}】。", m_sIP, m_iPort, _sCmd, _sReturn));

            }
            catch (Exception ex)
            {
                string _sMsg = string.Format("向IP=【{0}】，port=【{1}】发送消息【{2}】异常：{3}", m_sIP, m_iPort, _sCmd, ex.Message.ToString());
                if (!m_Socket.Connected)
                    throw new Exception(_sCmd);
                else
                    Logger.Debug(_sMsg);
            }
        }


    }
}
