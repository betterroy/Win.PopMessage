using Service.Message.Servers;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Message.Commands
{
    public abstract class BaseCommand : IAsyncCommand<StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            await Task.Delay(0);

            var result = GetResult(package);

            List<IAppSession> _appSessions = TelnetService<StringPackageInfo>._appSessions;
            foreach (var item in _appSessions)
            {
                await item.SendAsync(Encoding.UTF8.GetBytes(result + "EndMsg\r\n"));
            }
            //发送消息给客户端
            //await session.SendAsync(Encoding.UTF8.GetBytes(result + "\r\n"));
        }

        protected abstract string GetResult(StringPackageInfo package);
    }
}
