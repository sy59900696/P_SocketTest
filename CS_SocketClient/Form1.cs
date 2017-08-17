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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_SocketServer
{
    public partial class Form1 : Form
    {
        public string m_sIP = "127.0.0.1";
        public int m_iPort = 7777;
        private List<Thread> m_lstThread = new List<Thread>();
        private bool m_IsRun = true;
        private int m_i线程数 = 0;
        private int m_i单个线程循环间隔 = 0;

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

        private void btn_单条发送_Click(object sender, EventArgs e)
        {
            try
            {
                M_Logger("btn_单条发送_Click()");
                m_sIP = IPAddress.Parse(txt_IP.Text).ToString();
                m_iPort = int.Parse(txt_端口.Text);
                M_Send(txt_Msg.Text);
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
                    Thread _t0 = new Thread(new ParameterizedThreadStart(M_循环发送));
                    _t0.IsBackground = true;
                    _t0.Name = string.Format("Sender{0}", i);
                    m_lstThread.Add(_t0);
                }

                //启动线程。
                foreach (Thread _t0 in m_lstThread)
                {
                    _t0.Start(_t0.Name);
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
            string _sID = _obj.ToString();
            for (int i = 0; i < 99999999 && m_IsRun; i++)
            {
                try
                {
                    M_Send(string.Format("[{0}]\t{1}", _sID, i));
                    Thread.Sleep(m_i单个线程循环间隔);
                }
                catch (Exception ex)
                {
                    M_Logger(string.Format("M_循环发送()异常：{0}", ex.Message.ToString()));
                }
            }
        }

        public void M_Send(object _obj)
        {
            Socket m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_ClientSocket.ReceiveTimeout = 1000;
            m_ClientSocket.SendTimeout = 1000;
            string _sCmd = _obj.ToString();
            try
            {
                try
                {
                    m_ClientSocket.Connect(new IPEndPoint(IPAddress.Parse(m_sIP), m_iPort)); //配置服务器IP与端口
                    Logger.Debug(string.Format("向IP=【{0}】，port=【{1}】连接成功。。。", m_sIP, m_iPort));
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("向IP=【{0}】，port=【{1}】连接异常：{2}", m_sIP, m_iPort, ex.Message.ToString()));
                }
                Thread.Sleep(2);    //等待2毫秒，防止指令流粘连
                m_ClientSocket.Send(Encoding.UTF8.GetBytes(_sCmd));

                List<byte> _lst0 = new List<byte>();
                byte[] _buffer = new byte[1024];

                int _iReceiveCount = m_ClientSocket.Receive(_buffer);

                string _sReturn = Encoding.UTF8.GetString(_buffer, 0, _iReceiveCount);

                Logger.Debug(string.Format("向IP=【{0}】，port=【{1}】发送消息【{2}】成功。收到返回【{3}】。", m_sIP, m_iPort, _sCmd, _sReturn));

            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("向IP=【{0}】，port=【{1}】发送消息【{2}】异常：{3}", m_sIP, m_iPort, _sCmd, ex.Message.ToString()));
            }
            finally
            {
                if (m_ClientSocket != null)
                {
                    m_ClientSocket.Close();
                    m_ClientSocket.Dispose();
                }
            };
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

                M_Logger(string.Format("m_lstThread.Count={0}", m_lstThread.Count));
                foreach (Thread _t0 in m_lstThread)
                {
                    try
                    {
                        _t0.Abort(); 
                    }
                    catch (Exception ex)
                    {
                        M_Logger(string.Format("强制中断原有子线程【{0}】，抛出About异常：{1}", _t0.Name, ex.Message.ToString()));
                    }
                }
                Thread.Sleep(200);
                foreach (Thread _t0 in m_lstThread) M_Logger(string.Format("_t0.ThreadState={0},\t_t0.IsAlive={1}", _t0.ThreadState, _t0.IsAlive));
                m_lstThread.Clear();
                btn_循环发送.Enabled = true;
                m_IsRun = false;
                M_Logger(string.Format("btn_停止循环_Click()完成。"));
            }
            catch (Exception ex)
            {
                M_Logger(string.Format("btn_循环发送_Click()异常：{0}", ex.Message.ToString()));
            }
        }
    }
}
