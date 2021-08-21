using SuperSocket.Command;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Message.Servers
{
    public class CommandFilterAttribute : AsyncCommandFilterAttribute
    {
        public override async ValueTask<bool> OnCommandExecutingAsync(CommandExecutingContext commandContext)
        {
            //if (commandContext.Package is StringPackageInfo package)
            //{
            //    Console.WriteLine($"session ip: {commandContext.Session.RemoteEndPoint}, " +
            //                      $" command: {package.Key}");
            //}

            await Task.Delay(0);
            return true;
        }

        public override async ValueTask OnCommandExecutedAsync(CommandExecutingContext commandContext)
        {
            await Task.Delay(0);
        }
    }
}
