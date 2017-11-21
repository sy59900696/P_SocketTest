using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StaticCode;
using Newtonsoft.Json;

namespace CS_CDClient
{
    public partial class Form_All : Form
    {
        public string m_sIP = "127.0.0.1";
        public int m_iPort = 8888;
        private List<Thread> m_lstThread = new List<Thread>();
        private bool m_IsRun = true;
        private int m_i线程数 = 0;
        private int m_i单个线程循环间隔 = 0;
        private int m_iCount = 0;
        private int m_iCntError = 0;

        private C_MsgToServer m_MsgToServer1 = new C_MsgToServer();
        private List<C_MsgToServer> m_lstMsgToServer1 = new List<C_MsgToServer>(); 

        bool m_Is用户点击了桩的停止键 = false; 

        private BackgroundWorker m_bgw0 = new BackgroundWorker();

        public Form_All()
        {
            InitializeComponent();
            m_bgw0.WorkerSupportsCancellation = true;
            m_bgw0.DoWork += M_bgw0_DoWork;
            btn_停止充电.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void M_bgw0_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                try
                {
                    Logger.Debug(string.Format("第{0}次循环。。。", m_iCount));

                    if (m_Is用户点击了桩的停止键)
                    {
                        m_MsgToServer1.m_iState = 5;
                        M_SendCmd(m_MsgToServer1);
                        m_Is用户点击了桩的停止键 = false;
                    }
                    else if (m_MsgToServer1.m_iState == 5)
                    {
                        M_SendCmd(m_MsgToServer1.ToString());
                    }
                    else if (m_MsgToServer1.m_iState == 2)
                    {
                        Logger.Debug("进入m_MsgToServer1.m_iState == 2 的处理。先停止设备服务。");
                        M_停止给车充电();
                        m_MsgToServer1.m_iState = 3;
                        M_SendCmd(m_MsgToServer1.ToString());
                    }

                    if (M_Do自检())
                    {
                        if (m_MsgToServer1.m_iState == 0)
                            m_MsgToServer1.m_iState = 3;
                    }
                    else
                    {
                        m_MsgToServer1.m_iState = 0;
                    }

                    m_MsgToServer1.m_sCar = ckbx_枪连接OK.Checked ? "车辆信息XXXX" : "";

                    M_SendCmd(m_MsgToServer1);
                }
                catch (Exception ex)
                {
                    Logger.Debug(string.Format("M_bgw0_DoWork()循环异常：{0}", ex.Message.ToString()));
                }
                M_刷新桩界面();
                Thread.Sleep(1000);
            }
        }

        private void M_给车辆充电()
        {
            Logger.Debug("M_给车辆充电()");
        }

        private void M_停止给车充电()
        {
            Logger.Debug("M_停止给车充电()");
        }

        public void M_SendCmd(object _obj)
        {
            Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.ReceiveTimeout = 10000;
            _socket.SendTimeout = 10000;
            C_MsgToServer _MsgToServer1 = _obj as C_MsgToServer;
            //string _sCmd = _obj.ToString();

            try
            {
                IPEndPoint _EndPoint = new IPEndPoint(IPAddress.Parse(m_sIP), m_iPort);
                byte[] _byteSend = Encoding.UTF8.GetBytes(_MsgToServer1.ToString());
                //M_Logger(string.Format("向IP=【{0}:{1}】发送消息【{2}】准备发送。", m_sIP, m_iPort, _sCmd));
                _socket.SendTo(_byteSend, _byteSend.Length, SocketFlags.None, _EndPoint);
                Logger.Debug(string.Format("发送完成。进入接收。"));

                byte[] _buffer = new byte[1024];
                EndPoint _EndPointRemote = new IPEndPoint(IPAddress.Any, 0) as EndPoint;
                int _iReceiveCount = _socket.ReceiveFrom(_buffer, ref _EndPointRemote);
                IPEndPoint _ipEndPoint2 = ((IPEndPoint)_EndPointRemote);

                string _sReturn = Encoding.UTF8.GetString(_buffer, 0, _iReceiveCount);
                Logger.Debug(string.Format("向IP=【{0}:{1}】发送消息【{2}】成功。收到Server=【{3}:{4}】返回值【{5}】，。", m_sIP, m_iPort, _MsgToServer1.ToString(), _ipEndPoint2.Address.ToString(), _ipEndPoint2.Port, _sReturn));

                C_MsgToClient _msg2Client = JsonConvert.DeserializeObject<C_MsgToClient>(_sReturn);
                Logger.Debug(string.Format("接收服务端=【{0}:{1}】\t解析OK", _ipEndPoint2.Address.ToString(), _ipEndPoint2.Port));
                _MsgToServer1.m_MsgToClient.Copy(_msg2Client);

                if (_msg2Client.m_sCmd == "00001")//收到开始指令
                {
                    Logger.Debug("收到【开始指令】了。");
                    if (ckbx_枪连接OK.Checked)
                    {
                        _MsgToServer1.m_iState = 1;
                    }
                    else
                    {
                        _MsgToServer1.m_iState = 4;
                    }
                    this.Invoke(new Action(() =>
                    {
                    }));
                }
                else if (_msg2Client.m_sCmd == "00002")//收到停止指令
                {
                    Logger.Debug("收到【停止指令】了。");
                    _MsgToServer1.m_iState = 2;
                }
                else if (_msg2Client.m_sCmd == "00000" && _MsgToServer1.m_iState == 5)//收到停止指令
                {
                    _MsgToServer1.m_iState = 3;
                    //收到其他指令，不需要做任何处理。
                }
            }
            catch (Exception ex)
            {
                m_iCntError++;
                Logger.Debug(string.Format("m_iCntError={0}", m_iCntError));
                Logger.Error(string.Format("向IP=【{0}:{1}】发送消息【{2}】异常：{3}", m_sIP, m_iPort, _MsgToServer1.ToString(), ex.Message.ToString()));
                Thread.Sleep(1000);//连接服务器异常了，就先停一停。
            }
            finally
            {
                if (_socket != null)
                {
                    _socket.Close();
                    _socket.Dispose();
                }
            };
        }

        private bool M_Do自检()
        {
            bool _IsOk = true;
            if ( m_iCount % 100 == 99) _IsOk = false;
            if (m_iCount > 50 && m_iCount < 100) _IsOk = false;
            Logger.Debug(_IsOk ? "自检成功。" : "自检发现故障。");
            Thread.Sleep(100);
            return _IsOk;
        }

        private void M_桩提供充电()
        {
            Logger.Debug("M_桩提供充电()");
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

        private void M_刷新桩界面()
        {
            this.Invoke(new Action(() =>
            {
                txt_Logo_ID.Text = m_MsgToServer1.m_sClientID;
                txt_Logo_Car.Text = m_MsgToServer1.m_sCar;
                txt_Logo_Msg.Text = m_MsgToServer1.m_iState.ToString();
                txt_充电页_实时电价.Text = m_MsgToServer1.m_MsgToClient.m_sPrice;
                lbl_Msg2Client.Text = m_MsgToServer1.m_MsgToClient.ToString();
                lbl_Msg2Server.Text = m_MsgToServer1.ToString();
            }));
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
                    C_MsgToServer _msg0 = new C_MsgToServer();
                    _msg0.m_sClientID = _t0.Name;
                    m_lstMsgToServer1.Add(_msg0);
                    _t0.Start(_msg0);
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
            C_MsgToServer _MsgToServer1 = _obj as C_MsgToServer;
            while (true)
            {
                try
                {
                    Logger.Debug(string.Format("第{0}次循环。。。", m_iCount));

                    if (m_Is用户点击了桩的停止键)
                    {
                        _MsgToServer1.m_iState = 5;
                        M_SendCmd(_MsgToServer1);
                        m_Is用户点击了桩的停止键 = false;
                    }
                    else if (_MsgToServer1.m_iState == 5)
                    {
                        M_SendCmd(_MsgToServer1);
                    }
                    else if (_MsgToServer1.m_iState == 2)
                    {
                        Logger.Debug("进入m_MsgToServer1.m_iState == 2 的处理。先停止设备服务。");
                        M_停止给车充电();
                        _MsgToServer1.m_iState = 3;
                        M_SendCmd(_MsgToServer1);
                    }

                    if (M_Do自检())
                    {
                        if (_MsgToServer1.m_iState == 0)
                            _MsgToServer1.m_iState = 3;
                    }
                    else
                    {
                        _MsgToServer1.m_iState = 0;
                    }

                    _MsgToServer1.m_sCar = ckbx_枪连接OK.Checked ? "车辆信息XXXX" : "";

                    M_SendCmd(_MsgToServer1);
                }
                catch (Exception ex)
                {
                    Logger.Debug(string.Format("M_bgw0_DoWork()循环异常：{0}", ex.Message.ToString()));
                }
                //M_刷新桩界面();
                Thread.Sleep(1000);
            }
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

        private void btn_停止充电_Click(object sender, EventArgs e)
        {
            Logger.Debug("btn_停止充电_Click()");
            M_停止给车充电();
            m_Is用户点击了桩的停止键 = true;
        }

        private void btn_启动桩_Click(object sender, EventArgs e)
        {
            m_sIP = IPAddress.Parse(txt_IP.Text).ToString();
            m_MsgToServer1.m_sClientID = txt_Logo_ID.Text;
            m_iPort = int.Parse(txt_端口.Text);
            m_bgw0.RunWorkerAsync();
            btn_启动桩.Enabled = false;
            btn_停止充电.Enabled = true;  
        }

    }
}
