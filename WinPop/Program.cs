using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinPop
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool noRun;
            //判断是否已经有需要运行一个实例，如果系统没有，则运行一个
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out noRun))
            {
                //if (noRun)
                //{
                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    //Form Login = new Fm_Login();
                    //Login.ShowDialog();//显示登陆窗体  
                    //if (Login.DialogResult == DialogResult.OK)
                    //{
                    //    Application.Run(new Fm_main());
                    //}//判断登陆成功时主进程显示主窗口  
                    //else return;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MyPop());
                //}
                //else
                //{
                //    MessageBox.Show("目前已有一个程序在运行，在右下角小图标中", "提示");
                //}
            }
        }
    }
}
