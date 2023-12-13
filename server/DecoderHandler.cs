using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using System.Diagnostics;
using System.Text;


namespace Aibote4Sharp
{

    public class InputState
    {
        public int readIdx { get; set; }
    }

    public class DecoderHandler : ByteToMessageDecoder
    {
        private readonly PacketParser packetParser = new PacketParser();

        InputState state;

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {

            if (state == null)
            { // 首次读取
                context.FireChannelRead(input);
            }

            var outputBuffList = new List<byte[]>();
            var resultByte = new byte[input.ReadableBytes];
            input.ReadBytes(resultByte);

            MemoryStream ms = new MemoryStream();
            int size = resultByte.Length;
            int tag = - -1;
            for (int i = 0; i < size; i++)
            {
                if (resultByte[i] == 47) //寻找协议头
                {
                    tag = i; break;
                }
                ms.WriteByte(resultByte[i]);
            }

            ms = new MemoryStream();
            ms.Write(resultByte.Skip(tag).ToArray());

            size = Convert.ToInt32(Encoding.UTF8.GetString(ms.ToArray())); //取得包体的长度


            //ReplayingDecoder
            //packetParser.TryParsing(ref resultByte,ref outputBuffList);
            //output.AddRange(outputBuffList);
            output.Add(resultByte);
            input.Clear();
        }
    }
}
