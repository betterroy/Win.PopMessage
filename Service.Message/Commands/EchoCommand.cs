using Service.Message.Servers;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Message.Commands
{
    /// <summary>
    /// ECHO命令
    /// </summary>
    [Command(Key = "ECHO")]
    [Servers.CommandFilter]
    public class EchoCommand : BaseCommand
    {
        protected override string GetResult(StringPackageInfo package)
        {
            return package.Body;
        }
    }
}
