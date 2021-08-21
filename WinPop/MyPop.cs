using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using WinPop.Extension;

namespace WinPop
{
    public partial class MyPop : Form
    {
        private Logger logger = new Logger(typeof(MyPop));
        public MyPop()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 取消关闭窗体
            e.Cancel = true;
            // 将窗体变为最小化
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false; //不显示在系统任务栏 
            MyIcon.Visible = true; //托盘图标可见 
        }

        /// <summary>
        /// 点击最小化图标时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alermIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MyMenu.Show();
            }
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// 窗体退出时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要退出程序吗？", "退出程序", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Dispose();
                Application.Exit();
            }
        }

        private AsyncTcpSession asyncTcpsession = null;
        /// <summary>
        /// 点击连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_link_Click(object sender, EventArgs e1)
        {

            try
            {
                txtMessage.AppendTextColorful("启动一个客户端链接");
                string strIp = "127.0.0.1";
                string strPort = "10241";

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(strIp), Convert.ToInt32(strPort));
                asyncTcpsession = new AsyncTcpSession();
                asyncTcpsession.Connect(endPoint);
                asyncTcpsession.DataReceived += (o, e) =>
                {
                    //在这里就是接收服务发送过来的消息内容；
                    //在这里处理接受到消息 
                    string msg = Encoding.UTF8.GetString(e.Data, 0, e.Data.Length);
                    if(msg.LastIndexOf("EndMsg")>0)
                        msg = msg.Substring(0, msg.LastIndexOf("EndMsg"));
                    this.Invoke(new Action(() =>
                    {
                        txtMessage.AppendTextColorful($"服务器返回：{msg}", Color.Blue);
                    }));
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                txtMessage.AppendTextColorful(ex.Message, Color.Red);
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //string userId = "";
            //string userName = "";
            //string userPassword = "";
            //ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"Login {userId} {userName} {userPassword}\r\n"));
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{txtSend.Text}\r\n"));
            asyncTcpsession.Send(buffer);
        }

        private void btn_break_Click(object sender, EventArgs e)
        {
            try
            {
                asyncTcpsession.Close();
                txtMessage.AppendTextColorful($"链接关闭成功",Color.Green);

            }
            catch (Exception ex)
            {
                txtMessage.AppendTextColorful($"链接关闭失败", Color.Red);
            }
        }
    }
}
