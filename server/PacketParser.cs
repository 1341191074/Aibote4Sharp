using System.Diagnostics;

namespace Aibote4Sharp
{
    public class PacketParser
    {
        private readonly List<byte[]> _bufferList = new List<byte[]>();

        public void TryParsing(ref byte[] inBytes, ref List<byte[]> outBytes)
        {
            try
            {
                _bufferList.Add(inBytes);
                var tempBuffer = new byte[_bufferList.Sum(item => item.Length)];

                var size = 0;
                foreach (var item in _bufferList)
                {
                    item.CopyTo(tempBuffer, size);
                    size += item.Length;
                }

                if (tempBuffer.Length < 4) return;
                var packetLen = BitConverter.ToInt32(tempBuffer, 0);
                

                if (tempBuffer.Length < (4 + packetLen))
                {
                    return;
                }

                if (tempBuffer.Length == (4 + packetLen))
                {
                    _bufferList.Clear();
                    outBytes.Add(tempBuffer);
                }

                if (tempBuffer.Length > (4 + packetLen))
                {
                    var left = new byte[4 + packetLen];
                    Array.Copy(tempBuffer, 0, left, 0, left.Length);
                    var right = new byte[tempBuffer.Length - left.Length];
                    Array.Copy(tempBuffer, left.Length, right, 0, right.Length);
                    _bufferList.Clear();
                    outBytes.Add(left);
                    TryParsing(ref right, ref outBytes);
                }
            }
            catch (Exception ex)
            {
               Trace.TraceError("PacketParser Error", ex.Message, ex);
            }
        }
    }

}
