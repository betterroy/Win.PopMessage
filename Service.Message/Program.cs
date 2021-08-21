using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.Message.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using SuperSocket.WebSocket.Server;
using Service.Message.Commands;
using SuperSocket;
using System.Text;
using SuperSocket.Server;
using Utility;

namespace Service.Message
{
    public class Program
    {
        private static Logger logger = new Logger(typeof(Program));
        public static void Main(string[] args)
        {

            #region 可接收消息,历史版本
            ServerHelper socketApi = new ServerHelper();
            socketApi.RunServer();
            #endregion

            #region 可单主机发送与接收

            ////创建宿主：用Package的类型和PipelineFilter的类型创建SuperSocket宿主。
            //var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
            //    //注册用于处理连接、关闭的Session处理器
            //    .UseSessionHandler(async (session) =>
            //    {
            //        logger.Info($"session connected: {session.RemoteEndPoint}");

            //        //发送消息给客户端
            //        var msg = $@"Welcome to TelnetServer: {session.RemoteEndPoint}";
            //        await session.SendAsync(Encoding.UTF8.GetBytes(msg + "\r\n"));
            //    }, async (session, reason) =>
            //    {
            //        await Task.Delay(0);
            //        logger.Info($"session {session.RemoteEndPoint} closed: {reason}");
            //    })
            //    .UseCommand((commandOptions) =>
            //    {
            //        commandOptions.AddCommand<EchoCommand>();
            //    })
            //    //配置日志
            //    .ConfigureLogging((hostCtx, loggingBuilder) =>
            //    {
            //        loggingBuilder.AddConsole();
            //    })
            //    .Build();
            //host.RunAsync();

            #endregion


            #region 多用户发送

            var host = MultipleServerHostBuilder.Create()
                .AddServer<TelnetService<StringPackageInfo>, StringPackageInfo, CommandLinePipelineFilter>(builder =>
                {
                    builder.ConfigureServerOptions((ctx, config) =>
                    {
                        //获取服务配置
                        // ReSharper disable once ConvertToLambdaExpression
                        return config.GetSection("TelnetServer");
                    })
                        .UseSession<TelnetSession>()
                        .UseCommand(commandOptions =>
                        {
                            commandOptions.AddCommand<EchoCommand>();
                        });
                })
                //配置日志
                //.ConfigureLogging((hostCtx, loggingBuilder) =>
                //{
                //    //添加控制台输出
                //    loggingBuilder.AddConsole();
                //})
                .Build();
            try
            {
                host.RunAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            #endregion

            CreateHostBuilder(args).Build().Run();

            //Console.Read();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
