using DotNetty.Transport.Channels;

namespace Aibote4Sharp.sdk
{
    public class AiboteChannel
    {
        public AiboteChannel(IChannelHandlerContext aiboteChanel)
        {
            this.aiboteChanel = aiboteChanel;
        }

        public String keyId { get; set; }
        public ClientType clientType { get; set; }
        public IChannelHandlerContext aiboteChanel { get; set; }
        private Aibote aibote;

        public void setAibote(Aibote aibote)
        {
            this.aibote = aibote;
            this.aibote.aiboteChanel = this.aiboteChanel;
        }

        public Aibote getAibote() { return this.aibote; }
    }
    public enum ClientType
    {
        Win,
        Web,
        Android
    }

}
