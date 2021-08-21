using Microsoft.Extensions.Hosting;
using Service.Message.Filters;
using Service.Message.Models;
using SuperSocket;
using SuperSocket.Channel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Message.Servers
{    /// <summary>
     /// 服务帮助类
     /// </summary>
    public class ServerHelper
    {
        /// <summary>
        /// 使用自定义的数据包和过滤器创建的服务宿主
        /// </summary>
        private readonly ISuperSocketHostBuilder<DataPackage> host = SuperSocketHostBuilder.Create<DataPackage, DataFilter>();
        /// <summary>
        /// 会话集合
        /// </summary>
        private readonly ConcurrentDictionary<string, IAppSession> SessionsDict = new ConcurrentDictionary<string, IAppSession>();
        /// <summary>
        /// 启动Socket服务(只须调用此方法即可启动)
        /// </summary>
        /// <returns></returns>
        public bool RunServer()
        {
            bool isSuccess = true;
            //配置参数
            host.ConfigureSuperSocket(options =>
            {
                options.Name = "PxIotServer";
                options.MaxPackageLength = 1024 * 1024;
                options.ReceiveBufferSize = 4 * 1024;
                options.SendBufferSize = 4 * 1024;
                options.ReceiveTimeout = 0;
                options.SendTimeout = 500 * 1000;
                options.Listeners = new[] { new ListenOptions { Ip = "Any", Port = 10241, BackLog = 1024 } }.ToList();
            });
            //使用会话的连接和断开事件
            host.UseSessionHandler(OnConnectedAsync, OnClosedAsync);
            //使用会话的数据接收时间
            host.UsePackageHandler(OnPackageAsync);
            //启动
            host.RunConsoleAsync();
            return isSuccess;
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        public bool StopServer()
        {
            bool isSuccess = false;
            foreach (var v in SessionsDict)
            {
                v.Value.CloseAsync(CloseReason.ServerShutdown);
            }
            SessionsDict.Clear();
            return isSuccess;
        }
        /// <summary>
        /// 会话的连接事件
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private async ValueTask OnConnectedAsync(IAppSession session)
        {
            await Task.Run(() =>
            {
                while (!SessionsDict.ContainsKey(session.SessionID))
                {
                    //添加不成功则重复添加
                    if (!SessionsDict.TryAdd(session.SessionID, session))
                        Thread.Sleep(1);
                }
            });
        }
        /// <summary>
        /// 会话的断开事件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private async ValueTask OnClosedAsync(IAppSession session, CloseEventArgs e)
        {
            await Task.Run(() =>
            {
                while (SessionsDict.ContainsKey(session.SessionID))
                {
                    //移除不成功则重复移除
                    if (!SessionsDict.TryRemove(session.SessionID, out _))
                        Thread.Sleep(1);
                }
            });
        }
        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="package"></param>
        /// <returns></returns>
        private async ValueTask OnPackageAsync(IAppSession session, DataPackage package)
        {
            await Task.Run(() =>
            {
                //发送收到的数据
                session.SendAsync(package.Datas);
            });
        }

    }
}
