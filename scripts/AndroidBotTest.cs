using Aibote4Sharp.sdk;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibote4Sharp.scripts
{
    public class AndroidBotTest : AndroidBot
    {
        public AndroidBotTest()
        {

        }

        public AndroidBotTest(IChannelHandlerContext aiboteChanel) : base(aiboteChanel)
        {
        }

        public override void DoScript()
        {
            sleep(5000);
            string? s = this.getAndroidId();
            Debug.WriteLine($"返回结果：{s}");
        }

        public override string GetScriptName()
        {
            return "测试脚本112";
        }
    }
}
