using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;


namespace Aibote4Sharp
{
    public class DecoderHandler : ByteToMessageDecoder
    {
        private readonly PacketParser packetParser = new PacketParser();

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            var outputBuffList = new List<byte[]>();
            var resultByte = new byte[input.ReadableBytes];
            input.ReadBytes(resultByte);
            //packetParser.TryParsing(ref resultByte,ref outputBuffList);
            //output.AddRange(outputBuffList);
            output.Add(resultByte);
            input.Clear();
        }
    }
}
