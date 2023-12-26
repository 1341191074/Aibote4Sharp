using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System.Configuration;
using System.Diagnostics;

namespace Aibote4Sharp
{
    public abstract class BotServer
    {

        private ManualResetEvent _mainThread = new ManualResetEvent(false);
        public void ShutdownGracefully()
        {
            _mainThread.Set();
        }

        public abstract int GetPort();

        public abstract void Handlers(IChannelPipeline pipeline);

        public async Task Start()
        {
            int port = GetPort();//默认值
            var bossGroup = new MultithreadEventLoopGroup(1);
            var workerGroup = new MultithreadEventLoopGroup();
            var bootstrap = new ServerBootstrap();
            try
            {
                bootstrap
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    .Option(ChannelOption.TcpNodelay, true)
                    .Option(ChannelOption.SoKeepalive, true)
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    { // 
                        IChannelPipeline pipeline = channel.Pipeline;
                        pipeline.AddLast("decoder", new AiboteDecoder());
                        pipeline.AddLast("encoder", new AiboteEncoder());
                        pipeline.AddLast(new LoggingHandler("aibote-log"));
                        Handlers(pipeline);//注入自定义处理类
                    }));

                // bootstrap bind port 
                IChannel boundChannel = await bootstrap.BindAsync(port);
                //线程阻塞在WaitOne
                _mainThread.WaitOne();
                Trace.WriteLine("关闭服务");
                //关闭服务
                await boundChannel.CloseAsync();
            }
            finally
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }

    public class AndroidServer : BotServer
    {
        private volatile static AndroidServer instance = new AndroidServer();

        public static AndroidServer getInstance()
        {
            return instance;
        }

        private AndroidServer() { }

        public override int GetPort()
        {
            int port = 16997;
            string? p = ConfigurationManager.AppSettings["AndroidServerPort"];
            if (p != null && !"null".Equals(p))
            {
                port = int.Parse(p);
            }
            return port;
        }

        public override void Handlers(IChannelPipeline pipeline)
        {
            pipeline.AddLast("androidHandler", new AndroidHandler());
        }
    }

    public class WinServer : BotServer
    {
        private volatile static WinServer instance = new WinServer();

        public static WinServer getInstance()
        {
            return instance;
        }

        private WinServer() { }

        public override int GetPort()
        {
            int port = 16998;
            string? p = ConfigurationManager.AppSettings["WinServerPort"];
            if (p != null && !"null".Equals(p))
            {
                port = int.Parse(p);
            }
            return port;
        }

        public override void Handlers(IChannelPipeline pipeline)
        {
            pipeline.AddLast("androidHandler", new AndroidHandler());
        }
    }

    public class WebServer : BotServer
    {
        private volatile static WebServer instance = new WebServer();

        public static WebServer getInstance()
        {
            return instance;
        }

        private WebServer() { }

        public override int GetPort()
        {
            int port = 16999;
            string? p = ConfigurationManager.AppSettings["WebServerPort"];
            if (p != null && !"null".Equals(p))
            {
                port = int.Parse(p);
            }
            return port;
        }

        public override void Handlers(IChannelPipeline pipeline)
        {
            pipeline.AddLast("androidHandler", new AndroidHandler());
        }
    }
}
