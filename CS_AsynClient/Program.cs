﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
//using Utilities.LeakAlgorithm;

namespace CS_AsynClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Logger.Fatal("Main()开始。。。。。。。。。。。。。。。。。。。。。。。");


                Application.EnableVisualStyles();
                Application.Run(new Form_AsynClient());
                Logger.Fatal("Main()执行完成。。。。。。。。。。。。。。。。。。。。。。");
            }
            catch (Exception ex)
            {
                Logger.Fatal("Main()异常！！！！！！！！！！！！！！：" + ex.Message.ToString());
            }
        }
    }
}
