using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using SuperSocket.WebSocket;

namespace Service.Message.Servers
{
    /// <summary>
    /// WebSocketPackage转换器
    /// </summary>
    public class StringPackageConverter : IPackageMapper<WebSocketPackage, StringPackageInfo>
    {
        public StringPackageInfo Map(WebSocketPackage package)
        {
            var packInfo = new StringPackageInfo();
            var array = package.Message.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            packInfo.Key = array[0];
            packInfo.Parameters = array.Skip(1).ToArray();
            packInfo.Body = string.Join(' ', packInfo.Parameters);
            return packInfo;
        }
    }
}
