using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using System.Diagnostics;
using System.Text;


namespace Aibote4Sharp
{

    public class AiboteDecoder : ByteToMessageDecoder
    {


        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            // 获取数据
            var resultByte = new byte[input.ReadableBytes];
            input.GetBytes(0, resultByte); //使用get, 不移动指针。read移动指针

            MemoryStream ms = new MemoryStream();
            int size = resultByte.Length;
            int tag = - -1;
            for (int i = 0; i < size; i++)
            {
                if (resultByte[i] == 47) //寻找协议头
                {
                    tag = i + 1;
                    break;
                }
                ms.WriteByte(resultByte[i]);
            }

            int packLen = Convert.ToInt32(Encoding.UTF8.GetString(ms.ToArray())); //取得包体的长度

            if (size == packLen + tag)
            {
                output.Add(resultByte.Skip(tag).ToArray());
                input.Clear();
            }
        }
    }
}
