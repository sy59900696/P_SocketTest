﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace StaticCode
{
    public class C_MsgToServer
    {
        /// <summary>
        /// 0:桩故障; 1:充电中; 2:收到了服务端的停止指令; 3:就绪; 4:充电中，枪未连接; 5:用户按下桩上的停止键
        /// </summary> 
        public int m_iState = 0;

        private string _sClientID = "";

        public string m_sClientID
        {
            get
            {
                return _sClientID;
            }
            set
            {
                _sClientID = value;
                m_MsgToClient.m_sClientID = value;
            }
        }// = "DDDDD00000";

        public string m_sCar = "";

        public DateTime m_dtLastTime = DateTime.FromOADate(0);

        public C_MsgToClient m_MsgToClient = new C_MsgToClient();

        public C_MsgToServer()
        {
        }
        public C_MsgToServer(string sClientID)
        {
            m_sClientID = sClientID;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public C_MsgToServer Clone()
        {
            C_MsgToServer _c1 = new C_MsgToServer();
            _c1.m_iState = m_iState;
            _c1.m_sClientID = m_sClientID;
            _c1.m_sCar = m_sCar;
            m_dtLastTime = DateTime.Now;
            return _c1;
        }
        public C_MsgToServer Copy(C_MsgToServer _c1)
        {
            m_iState = _c1.m_iState;
            m_sClientID = _c1.m_sClientID;
            m_sCar = _c1.m_sCar;
            m_dtLastTime = DateTime.Now;
            return this;
        }
    }

    public class C_MsgToClient
    {
        public string m_sClientID = "";

        /// <summary>
        /// 00000:空;  00001:开启充电; 00002:停止充电
        /// </summary> 
        public string m_sCmd = "00000";
        public string m_sPrice = "2.0";

        public C_MsgToClient Copy(C_MsgToClient _c1)
        {
            m_sCmd = _c1.m_sCmd;
            m_sPrice = _c1.m_sPrice;
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class C_Msg
    {
        public int m_iCode = 0;
        public string m_sMessage = "";
        public string m_sResult = "";
    }
}
