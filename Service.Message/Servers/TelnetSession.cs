using SuperSocket;
using SuperSocket.Channel;
using SuperSocket.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Message.Servers
{
    public class TelnetSession : AppSession
    {
        private string SessionName => "[TelnetSession]";

        protected override async ValueTask OnSessionConnectedAsync()
        {
            Console.WriteLine($@"{DateTime.Now} {SessionName} New Session connected: {RemoteEndPoint}.");

            //发送消息给客户端
            var msg = $@"Welcome to {SessionName}: {RemoteEndPoint}";
            await (this as IAppSession).SendAsync(Encoding.UTF8.GetBytes(msg + "\r\n"));
        }

        protected override async ValueTask OnSessionClosedAsync(CloseEventArgs e)
        {
            Console.WriteLine($@"{DateTime.Now} {SessionName} Session {RemoteEndPoint} closed: {e.Reason}.");
            await Task.Delay(0);
        }
    }
}
