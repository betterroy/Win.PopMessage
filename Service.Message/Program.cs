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

            #region �ɽ�����Ϣ,��ʷ�汾
            ServerHelper socketApi = new ServerHelper();
            socketApi.RunServer();
            #endregion

            #region �ɵ��������������

            ////������������Package�����ͺ�PipelineFilter�����ʹ���SuperSocket������
            //var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
            //    //ע�����ڴ������ӡ��رյ�Session������
            //    .UseSessionHandler(async (session) =>
            //    {
            //        logger.Info($"session connected: {session.RemoteEndPoint}");

            //        //������Ϣ���ͻ���
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
            //    //������־
            //    .ConfigureLogging((hostCtx, loggingBuilder) =>
            //    {
            //        loggingBuilder.AddConsole();
            //    })
            //    .Build();
            //host.RunAsync();

            #endregion


            #region ���û�����

            var host = MultipleServerHostBuilder.Create()
                .AddServer<TelnetService<StringPackageInfo>, StringPackageInfo, CommandLinePipelineFilter>(builder =>
                {
                    builder.ConfigureServerOptions((ctx, config) =>
                    {
                        //��ȡ��������
                        // ReSharper disable once ConvertToLambdaExpression
                        return config.GetSection("TelnetServer");
                    })
                        .UseSession<TelnetSession>()
                        .UseCommand(commandOptions =>
                        {
                            commandOptions.AddCommand<EchoCommand>();
                        });
                })
                //������־
                //.ConfigureLogging((hostCtx, loggingBuilder) =>
                //{
                //    //��ӿ���̨���
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
