using Service.Message.Servers;
using SuperSocket;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Message.Models
{
    public static class ClientDataHandle
    {

        /// <summary>
        /// 触发事件
        /// </summary>
        public static Action MessagesAdded;

        private static List<ClientModels> Datas { get; set; }

        /// <summary>
        /// 集合
        /// </summary>
        public static string msg
        {
            get { return msg; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Datas.Add(new ClientModels() { msg = value, isPush = false });
                    MessagesAdded.Invoke();
                }
            }
        }

        static ClientDataHandle()
        {
            Datas = new List<ClientModels>();
            MessagesAdded += SendMsg;
        }

        public static void SendMsg()
        {
            List<IAppSession> _appSessions = TelnetService<StringPackageInfo>._appSessions;
            var ds = Datas.Where(d => { return d.isPush == false; }).ToList();
            foreach (var item in _appSessions)
            {
                for (int j = 0; j < ds.Count; j++)
                {
                    ClientModels d = ds[j];
                    item.SendAsync(Encoding.UTF8.GetBytes(d.msg));
                    d.isPush = true;
                }
            }
        }
    }
}
