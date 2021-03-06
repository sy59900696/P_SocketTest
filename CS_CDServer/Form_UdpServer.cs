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
using System.Windows.Forms;
using StaticCode;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CS_UdpServer
{
    public partial class Form_UdpServer : Form
    {
        public int m_iPort = 8888;
        static Socket m_ServerSocket;
        private bool m_IsRun = true;
        private int m_i收发计数 = 0;
        private DateTime m_dtStart = DateTime.Now;
        private BackgroundWorker m_bgw_View = new BackgroundWorker();

        List<C_MsgToServer> m_lst_MsgToServer = new List<C_MsgToServer>();

        public Form_UdpServer()
        {
            InitializeComponent();
            m_bgw_View.WorkerSupportsCancellation = true;
            m_bgw_View.DoWork += M_bgw_View_DoWork;

            //C_MsgToServer _c1 = new C_MsgToServer(); 
            //string jsonData = JsonConvert.SerializeObject(_c1);
            //C_MsgToServer descJsonStu = JsonConvert.DeserializeObject<C_MsgToServer>(jsonData);//反序列化 

            //Console.WriteLine();
        }

        private void M_bgw_View_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                try
                {
                    StringBuilder _sb0 = new StringBuilder();
                    foreach (C_MsgToServer _msg0 in m_lst_MsgToServer)
                    {
                        _sb0.AppendFormat("m_sClientID ={0}, m_iState ={1}, m_dtLastTime ={2}", _msg0.m_sClientID, _msg0.m_iState, _msg0.m_dtLastTime.ToString());
                        _sb0.AppendLine();
                    }
                    this.Invoke(new Action(() => { rtxt_MsgData.Text = _sb0.ToString(); }));
                }
                catch (Exception ex)
                {
                    Logger.Debug(string.Format("M_bgw_View_DoWork()异常：{0}", ex.Message.ToString()));
                }
                Thread.Sleep(1000);
            }
        }

        private void M_开启监听()
        {
            IPEndPoint _endpoint = new IPEndPoint(IPAddress.Any, m_iPort);
            m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            m_ServerSocket.SendTimeout = 3000;
            m_ServerSocket.ReceiveTimeout = 70000;
            m_ServerSocket.Bind(_endpoint);  //绑定IP地址：端口 

            m_IsRun = true;
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(M_循环监听);
            myThread.IsBackground = true;
            myThread.Start();
            m_dtStart = DateTime.Now;
            m_bgw_View.RunWorkerAsync();
            M_Logger(string.Format("启动监听{0}成功", m_ServerSocket.LocalEndPoint.ToString()));
        }
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void M_循环监听()
        {
            M_Logger("M_循环监听()");
            while (m_IsRun)
            {
                try
                {
                    IPEndPoint _ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint _EndpointRemote = _ipEndPoint as EndPoint;
                    byte[] _buffer = new byte[1024 * 1024];
                    //Logger.Debug("m_ServerSocket.ReceiveFrom()");
                    int _iReceiveCount = m_ServerSocket.ReceiveFrom(_buffer, ref _EndpointRemote);
                    Logger.Debug(string.Format("m_ServerSocket.ReceiveFrom()完成。_iReceiveCount = 【{0}】", _iReceiveCount));

                    string _sReturn = "";

                    try
                    {
                        C_MsgToServer _base_MsgToServer;
                        try
                        {
                            string _sResult = Encoding.UTF8.GetString(_buffer, 0, _iReceiveCount);

                            IPEndPoint _ipEndPoint2 = ((IPEndPoint)_EndpointRemote);
                            Logger.Debug(string.Format("接收客户端=【{0}:{1}】\t消息=【{2}】", _ipEndPoint2.Address.ToString(), _ipEndPoint2.Port, _sResult));

                            C_MsgToServer _msg2Server = JsonConvert.DeserializeObject<C_MsgToServer>(_sResult);
                            if (_msg2Server.m_sClientID.Length<=0) throw new Exception("m_sClientID不合法。");
                            Logger.Debug(string.Format("解析OK" ));

                            _base_MsgToServer = m_lst_MsgToServer.FirstOrDefault(n => n.m_sClientID == _msg2Server.m_sClientID);

                            if (_base_MsgToServer != null)
                            {
                                _base_MsgToServer.Copy(_msg2Server);
                            }
                            else
                            {
                                _base_MsgToServer = _msg2Server.Clone();
                                m_lst_MsgToServer.Add(_base_MsgToServer);
                            }
                            //this.Invoke(new Action(() => { lbl_桩状态.Text = "桩状态:" + _sResult; }));
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("解析异常：{0}", ex.Message.ToString()));
                        }

                        try
                        {
                            switch (_base_MsgToServer.m_iState)
                            {
                                case 1://充电中
                                    break;
                                case 2://用户在手机上点了【停止】，上次已发送了停止，但桩还未停。继续发。 
                                    _base_MsgToServer.m_MsgToClient.m_sCmd = "00002";
                                    break;
                                case 3://桩已就绪
                                    if (_base_MsgToServer.m_MsgToClient.m_sCmd == "00002")//如果上回给桩发的是停止，且装已到就绪状态，则指令改为00000
                                    {
                                        _base_MsgToServer.m_MsgToClient.m_sCmd = "00000";
                                    }
                                    break;
                                case 4://充电中，但枪未插。
                                    break;
                                case 0://桩故障了。
                                case 5://用户在桩上按了停止
                                default:
                                    this.Invoke(new Action(() =>
                                    {
                                        M_调用支付接口停止计费End();
                                        //btn_开始充电.Enabled = true;
                                    }));
                                    _base_MsgToServer.m_MsgToClient.m_sCmd = "00000";
                                    break;
                            }
                            //lbl_桩状态.Text = "桩状态:" + _sResult;
                        }
                        catch (Exception ex)
                        {
                            Logger.Debug(string.Format("M_Logger()异常：{0}", ex.Message.ToString()));
                        }

                        _base_MsgToServer.m_MsgToClient.m_sPrice = (DateTime.Now.Second / 10.0).ToString("F2");

                        _sReturn = JsonConvert.SerializeObject(_base_MsgToServer.m_MsgToClient);
                    }
                    catch (Exception ex)
                    {
                        _sReturn = " ";
                        Logger.Debug(string.Format("M_循环监听().收到了非法数据。异常：{0}", ex.Message.ToString()));
                    }

                    Logger.Debug(string.Format("准备反馈数据：{0}", _sReturn));
                    byte[] _byteSend = Encoding.UTF8.GetBytes(_sReturn);
                    m_ServerSocket.SendTo(_byteSend, _byteSend.Length, SocketFlags.None, _EndpointRemote);
                    Logger.Debug("反馈完成。");
                    m_i收发计数++;
                }
                catch (Exception ex)
                {
                    Logger.Debug(string.Format("M_循环监听()异常：{0}", ex.Message.ToString()));
                }

                //Thread receiveThread = new Thread(ReceiveMessage);
                //receiveThread.IsBackground = true;
                //receiveThread.Start(_clientSocket);
            }
            M_Logger(string.Format("M_循环监听()while结束。"));
        }

        private void M_调用支付接口停止计费End()
        {
            Logger.Debug("M_调用支付接口停止计费End()");
        }

        private void M_调用支付接口启动计费Start()
        {
            Logger.Debug("M_调用支付接口启动计费Start()");
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

                    //if (m_i收发计数 % 5000 == 0)
                    {
                        if (rtxt_Log.TextLength > 3000)
                            rtxt_Log.Clear();
                        rtxt_Log.AppendText(string.Format("{0}\t{1}\r\n", DateTime.Now.ToString("HH:mm:ss-fff"), sMsg));
                        rtxt_Log.SelectionStart = rtxt_Log.Text.Length;
                        rtxt_Log.ScrollToCaret();

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

        private void btn_开始充电_Click(object sender, EventArgs e)
        {
            Logger.Debug("btn_开始充电_Click()");
            //C_MsgToServer _base_MsgToServer = m_lst_MsgToServer.FirstOrDefault(n => n.m_sClientID == "DDDDD00001");
            C_MsgToServer _base_MsgToServer = m_lst_MsgToServer.FirstOrDefault();
            M_调用支付接口启动计费Start();
            _base_MsgToServer.m_MsgToClient.m_sCmd = "00001";
        }

        private void btn_停止充电_Click(object sender, EventArgs e)
        {
            Logger.Debug("btn_停止充电_Click()");
            C_MsgToServer _base_MsgToServer = m_lst_MsgToServer.FirstOrDefault();
            M_调用支付接口停止计费End();
            _base_MsgToServer.m_MsgToClient.m_sCmd = "00002";
        }
    }
}
