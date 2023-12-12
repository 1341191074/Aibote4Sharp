using Aibote4Sharp.sdk;
using DotNetty.Transport.Channels;
using System.Diagnostics;

namespace Aibote4Sharp
{
    public abstract class BotHandler : SimpleChannelInboundHandler<byte[]>
    {
        private ClientManager clientManager;

        protected BotHandler()
        {
            clientManager = GetClientManager();
        }

        public abstract ClientManager GetClientManager();

        public override void HandlerAdded(IChannelHandlerContext context)
        {
            base.HandlerAdded(context);
            Trace.WriteLine($"进入了 : {context.Channel.Id.AsLongText()}");
            clientManager.add(context.Channel.Id.AsLongText(), new AiboteChannel(context));
        }

        public override void HandlerRemoved(IChannelHandlerContext context)
        {
            base.HandlerRemoved(context);
            Trace.WriteLine($"掉线了 : {context.Channel.Id.AsLongText()}");
            clientManager.remove(context.Channel.Id.AsLongText());
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, byte[] msg)
        {
            string keyId = ctx.Channel.Id.AsLongText();
            AiboteChannel? aiboteChannel = clientManager.get(keyId);
            if (aiboteChannel != null && aiboteChannel.getAibote() != null)
            {
                aiboteChannel.getAibote().retBuffer = msg;
            }
        }
    }


    public class AndroidHandler : BotHandler
    {
        public override ClientManager GetClientManager()
        {
            return AndroidClientManager.getInstance();
        }
    }
    public class WinHandler : BotHandler
    {
        public override ClientManager GetClientManager()
        {
            return WinClientManager.getInstance();
        }
    }

    public class WebHandler : BotHandler
    {
        public override ClientManager GetClientManager()
        {
            return WebClientManager.getInstance();
        }
    }
}