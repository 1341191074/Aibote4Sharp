using DotNetty.Transport.Channels;
using System.Diagnostics;
using System.Text;

namespace Aibote4Sharp.sdk
{
    public abstract class Aibote
    {
        private object lockObj = new object();//创建一个对

        public string? keyId { get; set; }
        public string? runStatus { get; set; }
        public byte[]? retBuffer { get; set; }
        public IChannelHandlerContext? aiboteChanel { get; set; }

        private long retTimeout = 1000; // 正常下获取返回值的时间。
        private long retDelayTimeout = 5000; // 超时情况获取返回值的时间。

        public Aibote()
        {
            this.runStatus = "未运行";
            Debug.WriteLine("调用了父类的构造方法");
        }

        public Aibote(IChannelHandlerContext aiboteChanel)
        {
            this.aiboteChanel = aiboteChanel;
            this.runStatus = "未运行";
            Debug.WriteLine("调用了父类的构造方法");
        }

        public abstract string GetScriptName();

        public abstract void DoScript();

        public static string getVersion()
        {
            return "2023-11-25";
        }

        public static void sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }

        private void Send(params string[] arrArgs)
        {
            this.Send(this.retTimeout, arrArgs);
        }

        private void Send(long timeOut, params string[] arrArgs)
        {
            if (this.aiboteChanel is null)
            {
                throw new Exception("链接错误");
            }
            _ = this.aiboteChanel.WriteAndFlushAsync(arrArgs);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            lock (lockObj)
            {
                while (this.retBuffer == null)
                {
                    if (stopwatch.ElapsedMilliseconds > retTimeout)
                    {
                        break;
                    }
                    else
                    {
                        sleep(200);
                    }
                }
            }
            stopwatch.Stop();
        }

        private void SendBytes(long timeOut, byte[] arrArgs)
        {
            if (this.aiboteChanel is null)
            {
                throw new Exception("链接错误");
            }
            _ = this.aiboteChanel.WriteAndFlushAsync(arrArgs);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            lock (lockObj)
            {
                while (this.retBuffer == null)
                {
                    if (stopwatch.ElapsedMilliseconds > retTimeout)
                    {
                        break;
                    }
                    else
                    {
                        sleep(200);
                    }
                }
            }
            stopwatch.Stop();
        }

        public byte[] BytesCmd(params string[] arrArgs)
        {
            this.Send(arrArgs);
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                return ret;
            }
            return null;
        }

        public bool BoolCmd(params string[] arrArgs)
        {
            this.Send(arrArgs);
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                return "true".Equals(Encoding.UTF8.GetString(ret));
            }
            return false;
        }

        public bool BoolDelayCmd(params string[] arrArgs)
        {
            this.Send(this.retDelayTimeout, arrArgs);
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                return "true".Equals(Encoding.UTF8.GetString(ret));
            }
            return false;
        }

        protected string? StrCmd(params string[] arrArgs)
        {
            this.Send(arrArgs);
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                string retStr = Encoding.UTF8.GetString(ret);
                if (!"null".Equals(ret))
                {
                    return retStr;
                }
            }
            return null;
        }

        protected string? StrDelayCmd(params string[] arrArgs)
        {
            this.Send(this.retDelayTimeout, arrArgs);
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                string retStr = Encoding.UTF8.GetString(ret);
                if (!"null".Equals(ret))
                {
                    return retStr;
                }
            }
            return null;
        }

        protected byte[] bytesCmd(params string[] arrArgs)
        {
            this.Send(arrArgs);
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                return ret;
            }
            return null;
        }

        protected bool sendFile(string functionName, string androidFilePath, byte[] fileData)
        {
            StringBuilder strData = new StringBuilder();
            strData.Append(Encoding.UTF8.GetByteCount(functionName)).Append("/");
            strData.Append(Encoding.UTF8.GetByteCount(androidFilePath)).Append("/");
            strData.Append(fileData.Length).Append("/");
            strData.Append(functionName);
            strData.Append(androidFilePath);

            MemoryStream stream = new MemoryStream();
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(Encoding.UTF8.GetBytes(strData.ToString()));
                writer.Write(fileData);
            }
            this.SendBytes(this.retDelayTimeout, stream.ToArray());
            if (this.retBuffer != null)
            {
                byte[] ret = this.retBuffer;
                this.retBuffer = null;
                return "true".Equals(Encoding.UTF8.GetString(ret));
            }
            return false;
        }
    }
}
