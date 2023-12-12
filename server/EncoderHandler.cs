using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System.Diagnostics;
using System.Text;

namespace Aibote4Sharp
{
    public class EncoderHandler : MessageToByteEncoder<string[]>
    {
        protected override void Encode(IChannelHandlerContext context, string[] message, IByteBuffer output)
        {
            Trace.WriteLine("字符串编码器：" + message.Length);
            StringBuilder strData = new StringBuilder();
            StringBuilder tempStr = new StringBuilder();
            foreach (string msg in message)
            {
                tempStr.Append(msg);
                strData.Append(Encoding.UTF8.GetByteCount(msg));//获取包含中文实际长度
                strData.Append('/');
            }
            strData.Append('\n');
            strData.Append(tempStr);
            output.WriteBytes(Encoding.UTF8.GetBytes(strData.ToString()));
        }
    }
    public class BytesEncoderHandler : MessageToByteEncoder<byte[]>
    {
        protected override void Encode(IChannelHandlerContext context, byte[] message, IByteBuffer output)
        {
            Trace.WriteLine("字节数组编码器：" + message.Length);
            output.WriteBytes(message);
        }
    }
}
