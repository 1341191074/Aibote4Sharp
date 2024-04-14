using DotNetty.Transport.Channels;
using Aibote4Sharp.sdk.options;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace Aibote4Sharp.sdk
{
    public abstract class AndroidBot : Aibote
    {
        public AndroidBot() { }

        public AndroidBot(IChannelHandlerContext aiboteChanel) : base(aiboteChanel)
        {
        }

        /// <summary>
        /// 获取安卓ID
        /// </summary>
        /// <returns>string</returns>
        public string? GetAndroidId()
        {
            return this.StrCmd("getAndroidId");
        }

        /// <summary>
        /// 获取投屏组号
        /// </summary>
        /// <returns>string</returns>
        public string? GetGroup()
        {
            return this.StrCmd("getGroup");
        }

        /// <summary>
        /// 获取投屏编号
        /// </summary>
        /// <returns>string</returns>
        public string? GetIdentifier()
        {
            return this.StrCmd("getIdentifier");
        }

        /// <summary>
        /// 获取投屏标题
        /// </summary>
        /// <returns>string</returns>
        public string? GetTitle()
        {
            return this.StrCmd("getTitle");
        }

        /// <summary>
        /// 截图保存<br />
        /// 截图保存在客户端本地了<br />
        /// thresh和maxval同为255时灰度处理
        /// </summary>
        /// <param name="savePath">保存的位置</param>
        /// <param name="region">截图区域region默认全屏</param>
        /// <param name="thresholdType">
        /// 算法类型：<br />
        ///   0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0<br />
        ///   1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva<br />
        ///   2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0<br />
        ///   3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变<br />
        ///   4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变<br />
        ///   5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值<br />
        ///   6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值<br />
        /// </param>
        /// <param name="thresh">阈值</param>
        /// <param name="maxval">最大值</param>
        /// <returns>bool</returns>
        public bool SaveScreenshot(string savePath, AiboteRegion region, int thresholdType = 0, int thresh = 0, int maxval = 0)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            return this.BoolCmd("saveScreenshot", savePath, region.left.ToString(), region.top.ToString(),
                region.right.ToString(), region.bottom.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString());
        }

        /// <summary>
        /// 截图保存<br />
        /// 截图保存在客户端本地了<br />
        /// thresh和maxval同为255时灰度处理
        /// </summary>
        /// <param name="region">截图区域region默认全屏</param>
        /// <param name="thresholdType">
        /// 算法类型：<br />
        ///   0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0<br />
        ///   1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva<br />
        ///   2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0<br />
        ///   3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变<br />
        ///   4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变<br />
        ///   5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值<br />
        ///   6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值<br />
        /// </param>
        /// <param name="thresh">阈值</param>
        /// <param name="maxval">最大值</param>
        /// <param name="scale">最大值</param>
        /// <returns>byte[]</returns>
        public byte[] TakeScreenshot(AiboteRegion region, int thresholdType = 0, int thresh = 0, int maxval = 0, float scale = 1.0F)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            return this.BytesCmd("takeScreenshot", region.left.ToString(), region.top.ToString(),
                region.right.ToString(), region.bottom.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString(), scale.ToString());
        }

        /// <summary>
        /// 获取指定坐标点的色值
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <returns></returns>
        public string? GetColor(int x, int y)
        {
            return this.StrCmd("getColor", x.ToString(), y.ToString());
        }

        /// <summary>
        /// 找图
        /// </summary>
        /// <param name="imagePath">小图片路径（手机）,多张小图查找应当用"|"分开小图路径。工具截图保存目录：/storage/emulated/0/Android/data/com.aibot.client/files/param>
        /// <param name="region">指定区域找图 [10, 20, 100, 200]，region默认全屏</param>
        /// <param name="sim">图片相似度 0.0-1.0，sim默认0.9</param>
        /// <param name="thresholdType">
        /// 算法类型：<br />
        ///   0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0<br />
        ///   1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva<br />
        ///   2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0<br />
        ///   3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变<br />
        ///   4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变<br />
        ///   5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值<br />
        ///   6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值<br />
        /// </param>
        /// <param name="multi">找图数量，默认为1 找单个图片坐标</param>
        /// <param name="thresh">阈值</param>
        /// <param name="maxval">最大值</param>
        /// <returns>成功返回 单坐标点[{x:number, y:number}]，多坐标点[{x1:number, y1:number}, {x2:number, y2:number}...] 失败返回null</returns>
        public string? FindImages(string imagePath, AiboteRegion region, float sim = 0.9F, int thresholdType = 0,
            int multi = 1, int thresh = 0, int maxval = 0)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            return this.StrDelayCmd("findImage", imagePath, region.left.ToString(), region.top.ToString(),
                region.right.ToString(), region.bottom.ToString(), sim.ToString(), thresholdType.ToString(),
                thresh.ToString(), maxval.ToString(), multi.ToString());
        }

        /// <summary>
        /// 找动态图
        /// </summary>
        /// <param name="frameRate">前后两张图相隔的时间，单位毫秒</param>
        /// <param name="region">指定区域找图 [10, 20, 100, 200]，region默认全屏</param>
        /// <returns></returns>
        public string? findAnimation(int frameRate, AiboteRegion region)
        {
            return StrDelayCmd("findAnimation", frameRate.ToString(), region.left.ToString(), region.top.ToString(),
                region.right.ToString(), region.bottom.ToString());
        }

        /// <summary>
        /// 查找指定色值的坐标点
        /// </summary>
        /// <param name="strMainColor">颜色字符串，必须以 # 开头，例如：#008577；</param>
        /// <param name="subColors">辅助定位的其他颜色；</param>
        /// <param name="region">在指定区域内找色，默认全屏；</param>
        /// <param name="sim">相似度。0.0-1.0，sim默认为1</param>
        /// <returns>string</returns>
        public string? FindColor(string strMainColor, SubColor[]? subColors = null, AiboteRegion? region = null, float sim = 1F)
        {
            StringBuilder subColorsStr = new StringBuilder();
            if (null == subColors)
            {
                subColorsStr.Append("null");
            }
            else
            {
                SubColor subColor;
                for (int i = 0; i < subColors.Length; i++)
                {
                    subColor = subColors[i];
                    subColorsStr.Append(subColor.offsetX).Append("/");
                    subColorsStr.Append(subColor.offsetY).Append("/");
                    subColorsStr.Append(subColor.colorStr);
                    if (i < subColors.Length - 1)
                    {
                        subColorsStr.Append('\n');
                    }
                }
            }

            if (region == null)
            {
                region = new AiboteRegion();
            }

            return this.StrDelayCmd("findColor", strMainColor, subColorsStr.ToString(), region.left.ToString(), region.top.ToString(),
                region.right.ToString(), region.bottom.ToString(), sim.ToString());
        }

        /// <summary>
        /// 比较指定坐标点的颜色值
        /// </summary>
        /// <param name="mainX">主颜色所在的X坐标</param>
        /// <param name="mainY">主颜色所在的Y坐标</param>
        /// <param name="mainColorStr">#开头的色值</param>
        /// <param name="subColors">相对于strMainColor 的子色值，[[offsetX, offsetY, "#FFFFFF"], ...]，subColors默认为null</param>
        /// <param name="region">指定区域找色 [10, 20, 100, 200]，region默认全屏</param>
        /// <param name="sim">相似度0.0-1.0，sim默认为1</param>
        /// <returns>bool</returns>
        public bool CompareColor(int mainX, int mainY, string mainColorStr, SubColor[]? subColors = null, AiboteRegion? region = null,
            float sim = 1F)
        {
            StringBuilder subColorsStr = new StringBuilder();
            if (null == subColors)
            {
                subColorsStr.Append("null");
            }
            else
            {
                SubColor subColor;
                for (int i = 0; i < subColors.Length; i++)
                {
                    subColor = subColors[i];
                    subColorsStr.Append(subColor.offsetX).Append("/");
                    subColorsStr.Append(subColor.offsetY).Append("/");
                    subColorsStr.Append(subColor.colorStr);
                    if (i < subColors.Length - 1)
                    {
                        subColorsStr.Append('\n');
                    }
                }
            }

            if (region == null)
            {
                region = new AiboteRegion();
            }
            return this.BoolDelayCmd("compareColor", mainX.ToString(), mainY.ToString(), mainColorStr, subColorsStr.ToString(), region.left.ToString(), region.top.ToString(),
                region.right.ToString(), region.bottom.ToString(), sim.ToString());
        }

        /// <summary>
        /// 手指按下
        /// </summary>
        /// <param name="x">x 横坐标</param>
        /// <param name="y">y 纵坐标</param>
        /// <param name="duration">duration 按下时长，单位毫秒 </param>
        /// <returns>bool。成功返回true 失败返回false</returns>
        public bool Press(int x, int y, int duration)
        {
            return this.BoolCmd("press", x.ToString(), y.ToString(), duration.ToString());
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="x">x 横坐标</param>
        /// <param name="y">y 纵坐标</param>
        /// <param name="duration">移动时长，单位毫秒 </param>
        /// <returns></returns>
        public bool Move(int x, int y, int duration)
        {
            return this.BoolCmd("move", x.ToString(), y.ToString(), duration.ToString());
        }

        /// <summary>
        /// 手指释放
        /// </summary>
        /// <returns>bool</returns>
        public bool Release()
        {
            return this.BoolCmd("release");
        }

        /// <summary>
        /// 点击坐标
        /// </summary>
        /// <param name="x">x 横坐标</param>
        /// <param name="y">y 纵坐标</param>
        /// <returns>bool</returns>
        public bool Click(int x, int y)
        {
            return this.BoolCmd("click", x.ToString(), y.ToString());
        }

        /// <summary>
        /// 双击坐标
        /// </summary>
        /// <param name="x">x 横坐标</param>
        /// <param name="y">y 纵坐标</param>
        /// <returns>bool</returns>
        public bool DoubleClick(int x, int y)
        {
            return this.BoolCmd("doubleClick", x.ToString(), y.ToString());
        }

        /// <summary>
        /// 长按坐标
        /// </summary>
        /// <param name="x">x 横坐标</param>
        /// <param name="y">y 纵坐标</param>
        /// <param name="duration">duration 按下时长，单位毫秒 </param>
        /// <returns></returns>
        public bool LongClick(int x, int y, int duration)
        {
            return this.BoolCmd("longClick", x.ToString(), y.ToString(), duration.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startX">起始横坐标X</param>
        /// <param name="startY">起始纵坐标Y</param>
        /// <param name="endX">结束横坐标X</param>
        /// <param name="endY">结束横坐标Y</param>
        /// <param name="duration">滑动时长，单位毫秒</param>
        /// <returns>bool</returns>
        public bool Swipe(int startX, int startY, int endX, int endY, float duration)
        {
            return this.BoolCmd("swipe", startX.ToString(), startY.ToString(), endX.ToString(), endY.ToString(), duration.ToString());
        }

        /// <summary>
        /// 执行手势
        /// </summary>
        /// <param name="gesturePath">手势路径</param>
        /// <param name="duration">手势时长，单位毫秒</param>
        /// <returns>bool</returns>
        public bool DispatchGesture(GesturePath gesturePath, float duration)
        {
            return this.BoolCmd("dispatchGesture", gesturePath.gesturePathStr("\n"), duration.ToString());
        }

        /// <summary>
        /// 发送的文本
        /// </summary>
        /// <param name="text">发送的文本，需要打开aibote输入法</param>
        /// <returns>bool</returns>
        public bool SendKeys(string text)
        {
            return this.BoolCmd("sendKeys", text);
        }

        /// <summary>
        /// 发送按键
        /// </summary>
        /// <param name="keyCode">
        /// 发送的虚拟按键，需要打开aibote输入法。例如：最近应用列表：187  回车：66<br />
        /// 按键对照表 https://blog.csdn.net/yaoyaozaiye/article/details/122826340
        /// </param>
        /// <returns>bool</returns>
        public bool SendVk(int keyCode)
        {
            return this.BoolCmd("sendVk", keyCode.ToString());
        }

        /// <summary>
        /// back
        /// </summary>
        /// <returns>bool</returns>
        public bool Back()
        {
            return this.BoolCmd("back");
        }

        /// <summary>
        /// home
        /// </summary>
        /// <returns>bool</returns>
        public bool Home()
        {
            return this.BoolCmd("home");
        }

        /// <summary>
        /// 显示最近任务
        /// </summary>
        /// <returns>bool</returns>
        public bool Recents()
        {
            return this.BoolCmd("recents");
        }

        /// <summary>
        /// 打开 开/关机 对话框，基于无障碍权限
        /// </summary>
        /// <returns>bool</returns>
        public bool PowerDialog()
        {
            return this.BoolCmd("powerDialog");
        }

        /// <summary>
        /// 初始化ocr服务
        /// </summary>
        /// <param name="ocrServerIp">ocr服务器IP。当参数值为 "127.0.0.1"时，则使用手机内置的ocr识别，不必打开AiboteAndroidOcr.exe服务端</param>
        /// <param name="useAngleModel">支持图像旋转。 默认false</param>
        /// <param name="enableGPU">启动GPU 模式。默认false</param>
        /// <param name="enableTensorrt">启动加速，仅enableGPU = true 时有效，默认false</param>
        /// <returns></returns>
        public bool InitOcr(string ocrServerIp, bool useAngleModel = false, bool enableGPU = false, bool enableTensorrt = false)
        {
            int ocrServerPort = 9527;
            return this.BoolCmd("initOcr", ocrServerIp, ocrServerPort.ToString(), useAngleModel.ToString(), enableGPU.ToString(), enableTensorrt.ToString());
        }

        /// <summary>
        /// ocr
        /// </summary>
        /// <param name="region">区域</param>
        /// <param name="thresholdType">二值化算法类型</param>
        /// <param name="thresh">阈值</param>
        /// <param name="maxval">最大值</param>
        /// <param name="scale">scale 图片缩放率, 默认为 1.0 原大小。大于1.0放大，小于1.0缩小，不能为负数。</param>
        /// <returns></returns>
        public List<OCRResult>? Ocr(AiboteRegion region, int thresholdType, int thresh, int maxval, float scale = 1.0F)
        {
            if (null == region)
            {
                region = new AiboteRegion();
            }
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }
            string? strRet = this.StrCmd("ocr", region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(),
                thresholdType.ToString(), thresh.ToString(), maxval.ToString(), scale.ToString());
            if (null == strRet || strRet == "" || strRet == "null" || strRet == "[]")
            {
                return null;
            }
            else
            {
                List<OCRResult> list = new List<OCRResult>();

                JArray jsonArray = JArray.Parse(strRet);
                foreach (var ary in jsonArray)
                {
                    JArray a = (JArray)ary;
                    OCRResult ocrResult = new OCRResult
                    {
                        lt = new AibotePoint(x: a[0][0][0].Value<int>(), y: a[0][0][1].Value<int>()),
                        rt = new AibotePoint(x: a[0][1][0].Value<int>(), y: a[0][1][1].Value<int>()),
                        ld = new AibotePoint(x: a[0][2][0].Value<int>(), y: a[0][2][1].Value<int>()),
                        rd = new AibotePoint(x: a[0][3][0].Value<int>(), y: a[0][3][1].Value<int>()),
                        word = a[1][0].ToString(),
                        rate = a[1][1].Value<double>(),
                    };

                    list.Add(ocrResult);
                }
                return list;
            }
        }

        /// <summary>
        /// 获取屏幕文字
        /// </summary>
        /// <param name="region">区域</param>
        /// <param name="thresholdType">二值化算法类型</param>
        /// <param name="thresh">阈值</param>
        /// <param name="maxval">最大值</param>
        /// <param name="scale">scale 图片缩放率, 默认为 1.0 原大小。大于1.0放大，小于1.0缩小，不能为负数。</param>
        /// <returns>string</returns>
        public string? GetWords(AiboteRegion region, int thresholdType = 0, int thresh = 0, int maxval = 0, float scale = 1.0F)
        {
            if (null == region)
            {
                region = new AiboteRegion();
            }
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            List<OCRResult>? wordsResult = wordsResult = this.Ocr(region, thresholdType, thresh, maxval, scale);

            if (null == wordsResult)
            {
                return null;
            }

            StringBuilder words = new StringBuilder();
            foreach (OCRResult obj in wordsResult)
            {
                words.Append(obj.word).Append("\n");
            }

            return words.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word">要查找的文字</param>
        /// <param name="region">截图区域region默认全屏</param>
        /// <param name="thresholdType">
        /// 算法类型：<br />
        ///   0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0<br />
        ///   1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva<br />
        ///   2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0<br />
        ///   3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变<br />
        ///   4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变<br />
        ///   5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值<br />
        ///   6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值<br />
        /// </param>
        /// <param name="thresh">阈值</param>
        /// <param name="maxval">最大值</param>
        /// <param name="scale">scale 图片缩放率, 默认为 1.0 原大小。大于1.0放大，小于1.0缩小，不能为负数。</param>
        /// <returns>AibotePoint</returns>
        public AibotePoint FindWords(string word, AiboteRegion region, int thresholdType = 0, int thresh = 0, int maxval = 0, float scale = 1.0F)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            List<OCRResult>? wordsResult = this.Ocr(region, thresholdType, thresh, maxval, scale);

            if (null == wordsResult)
            {
                return null;
            }

            AibotePoint point = new AibotePoint(-1, -1);
            StringBuilder words = new StringBuilder();
            OCRResult ocrResult = wordsResult.First(ele => ele.word.IndexOf(word) != -1);
            if (ocrResult != null)
            {
                int localLeft, localTop, localRight, localBottom, width, height, wordWidth, offsetX, offsetY, index, x, y;
                localLeft = ocrResult.lt.x;
                localTop = ocrResult.lt.y;
                localRight = ocrResult.ld.x;
                localBottom = ocrResult.ld.y;
                width = localRight - localLeft;
                height = localBottom - localTop;
                wordWidth = width / ocrResult.word.Length;
                index = ocrResult.word.IndexOf(word);
                offsetX = wordWidth * (index + words.Length / 2);
                offsetY = height / 2;
                x = (localLeft + offsetX + region.left);
                y = (localTop + offsetY + region.top);
                point.x = x;
                point.y = y;
            }
            return point;
        }

        /// <summary>
        /// 初始化yolo服务
        /// </summary>
        /// <param name="yoloServerIp">yolo服务器IP。端口固定为9528</param>
        /// <param name="modelPath">模型路径</param>
        /// <param name="classesPath">种类路径，CPU模式需要此参数</param>
        /// <returns>bool</returns>
        public bool InitYolo(string yoloServerIp, string modelPath, string classesPath)
        {
            return this.BoolCmd("initYolo", yoloServerIp, modelPath, classesPath);
        }

        /// <summary>
        /// yolo
        /// </summary>
        /// <param name="scale">图片缩放率, 默认为 1.0 原大小。大于1.0放大，小于1.0缩小，不能为负数。</param>
        /// <returns>失败返回null，成功返回数组形式的识别结果， 0~3目标矩形位置  4目标类别  5置信度</returns>
        public JArray? Yolo(float scale)
        {
            if (scale <= 0)
            {
                scale = 1.0F;
            }
            string strRet = this.StrCmd("yolo", scale.ToString());
            if (strRet != null)
            {
                JArray retJson = JArray.Parse(strRet);
                for (int i = 0; i < retJson.Count; i++)
                {
                    JArray? jsonArray = (JArray?)retJson[i];
                    jsonArray[0] = jsonArray[0].Value<float>() / scale;
                    jsonArray[1] = jsonArray[1].Value<float>() / scale;
                    jsonArray[2] = jsonArray[2].Value<float>() / scale;
                    jsonArray[3] = jsonArray[3].Value<float>() / scale;
                }
                return retJson;
            }
            return null;
        }

        public string? UrlRequest(string url, string requestType, string headers, string postData)
        {
            return this.StrCmd("urlRequest", url, requestType, headers, postData);
        }

        /// <summary>
        /// Toast消息提示
        /// </summary>
        /// <param name="text">提示的文本</param>
        /// <param name="duration">显示时长，最大时长3500毫秒</param>
        /// <returns>返回true</returns>
        public bool ShowToast(string text, float duration)
        {
            return this.BoolCmd("showToast", text, duration.ToString());
        }

        /// <summary>
        /// 启动App
        /// </summary>
        /// <param name="name">包名或者app名称</param>
        /// <returns>成功返回true 失败返回false。非Aibote界面时候调用，需要开启悬浮窗</returns>
        public bool StartApp(string name)
        {
            return this.BoolCmd("startApp", name);
        }

        /// <summary>
        /// 判断app是否正在运行(包含前后台)
        /// </summary>
        /// <param name="name">包名或者app名称</param>
        /// <returns>正在运行返回true，否则返回false</returns>
        public bool AppIsRunnig(string name)
        {
            return this.BoolCmd("appIsRunnig", name);
        }

        /// <summary>
        /// 获取已安装app的包名(不包含系统APP)
        /// </summary>
        /// <returns>成功返回已安装app包名数组(使用 | 分割)，失败返回null</returns>
        public string? GetInstalledPackages()
        {
            return this.StrCmd("getInstalledPackages");
        }

        /// <summary>
        /// 屏幕大小
        /// </summary>
        /// <returns>成功返回屏幕大小使用 | 分割</returns>
        public string? GetWindowSize()
        {
            return this.StrCmd("getWindowSize");
        }

        /// <summary>
        /// 图片大小
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <returns>成功返回 图片大小使用 | 分割</returns>
        public string getImageSize(string imagePath)
        {
            return this.StrCmd("getImageSize", imagePath);
        }

        /// <summary>
        /// 获取安卓ID
        /// </summary>
        /// <returns>成功返回安卓手机ID</returns>
        public string getAndroidId()
        {
            return this.StrCmd("getAndroidId");
        }

        /// <summary>
        /// 获取投屏组号
        /// </summary>
        /// <returns>成功返回投屏组号</returns>
        public string getGroup()
        {
            return this.StrCmd("getGroup");
        }

        /// <summary>
        /// 获取投屏编号
        /// </summary>
        /// <returns>成功返回投屏编号</returns>
        public string getIdentifier()
        {
            return this.StrCmd("getIdentifier");
        }

        /// <summary>
        /// 获取投屏标题
        /// </summary>
        /// <returns>成功返回投屏标题</returns>
        public string getTitle()
        {
            return this.StrCmd("getTitle");
        }

        /// <summary>
        /// 识别验证码
        /// </summary>
        /// <param name="filePath">图片文件路径</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="softId">软件ID</param>
        /// <param name="codeType">图片类型 参考https://www.chaojiying.com/price.html</param>
        /// <param name="lenMin">最小位数 默认0为不启用,图片类型为可变位长时可启用这个参数</param>
        /// <returns>
        /// {err_no:number, err_str:string, pic_id:string, pic_str:string, md5:string}返回JSON
        ///  err_no,(数值) 返回代码  为0 表示正常，错误代码 参考https://www.chaojiying.com/api-23.html
        ///  err_str,(字符串) 中文描述的返回信息
        ///  pic_id,(字符串) 图片标识号，或图片id号
        ///  pic_str,(字符串) 识别出的结果
        ///  md5,(字符串) md5校验值,用来校验此条数据返回是否真实有效
        /// </returns>
        public JObject getCaptcha(string filePath, string username, string password, string softId, string codeType, int lenMin)
        {
            string strRet = this.StrCmd("getCaptcha", filePath, username, password, softId, codeType, lenMin.ToString());
            return JObject.Parse(strRet);
        }

        /// <summary>
        /// 识别报错返分
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="softId">软件ID</param>
        /// <param name="picId">图片ID 对应 getCaptcha返回值的pic_id 字段</param>
        /// <returns>
        /// {err_no:number, err_str:string} 返回JSON
        /// err_no,(数值) 返回代码
        /// err_str,(字符串) 中文描述的返回信息
        /// </returns>
        public JObject errorCaptcha(string username, string password, string softId, string picId)
        {
            string strRet = this.StrCmd("errorCaptcha", username, password, softId, picId);
            return JObject.Parse(strRet);
        }

        /// <summary>
        /// 查询验证码剩余题分
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>
        /// {err_no:number, err_str:string, tifen:string, tifen_lock:string}返回JSON
        /// err_no,(数值) 返回代码
        /// err_str,(字符串) 中文描述的返回信息
        /// tifen,(数值) 题分
        /// tifen_lock,(数值) 锁定题分
        /// </returns>
        public JObject scoreCaptcha(string username, string password)
        {
            string strRet = this.StrCmd("scoreCaptcha", username, password);
            return JObject.Parse(strRet);
        }

        /// <summary>
        /// 获取元素位置
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>
        /// {left:number, top:number, right:number, bottom:number} 成功返回元素位置，失败返回null
        /// </returns>
        public AiboteRegion getElementRect(string xpath)
        {
            string strRet = this.StrDelayCmd("getElementRect", xpath);
            string[] arrRet = strRet.Split("\\|");
            AiboteRegion region = new AiboteRegion();
            region.left = Convert.ToInt32(arrRet[0]);
            region.top = Convert.ToInt32(arrRet[1]);
            region.right = Convert.ToInt32(arrRet[2]);
            region.bottom = Convert.ToInt32(arrRet[3]);
            return region;
        }

        /// <summary>
        /// 获取元素描述
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>成功返回元素内容，失败返回null</returns>
        public string getElementDescription(string xpath)
        {
            return this.StrDelayCmd("getElementDescription", xpath);
        }

        /// <summary>
        /// 获取元素文本
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>成功返回元素内容，失败返回null</returns>
        public string getElementText(string xpath)
        {
            return this.StrCmd("getElementText", xpath);
        }

        /// <summary>
        /// 判断元素是否可见
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>可见 ture，不可见 false</returns>
        public bool elementIsVisible(string xpath)
        {
            string windowRect = this.GetWindowSize();
            AiboteRegion elementRect = this.getElementRect(xpath);
            if (elementRect == null) return false;

            string[] split = windowRect.Split("\\|");
            int elementWidth = elementRect.right - elementRect.left;
            int elementHeight = elementRect.bottom - elementRect.top;
            if (elementRect.top < 0 || elementRect.left < 0 || elementWidth > Convert.ToInt32(split[0]) || elementHeight > Convert.ToInt32(split[1])) return false;
            else return true;
        }

        /// <summary>
        /// 设置元素文本
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <param name="text">设置的文本</param>
        /// <returns>成功返回true 失败返回false</returns>
        public bool setElementText(string xpath, string text)
        {
            return this.BoolDelayCmd("setElementText", xpath, text);
        }

        /// <summary>
        /// 点击元素
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>成功返回true 失败返回false</returns>
        public bool clickElement(string xpath)
        {
            return this.BoolDelayCmd("clickElement", xpath);
        }

        /// <summary>
        /// 滚动元素
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <param name="direction">0 向前滑动， 1 向后滑动</param>
        /// <returns>成功返回true 失败返回false</returns>
        public bool scrollElement(string xpath, int direction)
        {
            return this.BoolDelayCmd("scrollElement", xpath, direction.ToString());
        }

        /// <summary>
        /// 判断元素是否存在
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>成功返回true 失败返回false</returns>
        public bool existsElement(string xpath)
        {
            return this.BoolCmd("existsElement", xpath);
        }

        /// <summary>
        /// 判断元素是否选中
        /// </summary>
        /// <param name="xpath">元素路径</param>
        /// <returns>成功返回true 失败返回false</returns>
        public bool isSelectedElement(string xpath)
        {
            return this.BoolCmd("isSelectedElement", xpath);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="windowsFilePath">电脑文件路径，注意电脑路径 "\\"转义问题</param>
        /// <param name="androidFilePath">安卓文件保存路径, 安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回true 失败返回false</returns>
        public bool pushFile(string windowsFilePath, string androidFilePath)
        {
            byte[] fileData = File.ReadAllBytes(windowsFilePath);
            return this.sendFile("pushFile", androidFilePath, fileData);
        }

        /// <summary>
        /// 拉取文件
        /// </summary>
        /// <param name="androidFilePath">安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <param name="windowsFilePath">电脑文件保存路径，注意电脑路径 "\\"转义问题</param>
        public void pullFile(string androidFilePath, string windowsFilePath)
        {
            byte[] byteData = this.bytesCmd("pullFile", androidFilePath);
            File.WriteAllBytes(windowsFilePath, byteData);
        }


        /// <summary>
        /// GET 下载url文件
        /// </summary>
        /// <param name="">url 文件请求地址</param>
        /// <param name="">savePath 安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool downloadFile(string url, string savePath)
        {
            return this.BoolCmd("writeAndroidFile", url, savePath);
        }

        /// <summary>
        /// 写入安卓文件
        /// </summary>
        /// <param name="androidFilePath">安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <param name="text">写入的内容</param>
        /// <param name="isAppend">可选参数，是否追加，默认覆盖文件内容</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool writeAndroidFile(string androidFilePath, string text, bool isAppend = false)
        {
            return this.BoolCmd("writeAndroidFile", androidFilePath, text, isAppend.ToString());
        }

        /// <summary>
        /// 读取安卓文件
        /// </summary>
        /// <param name="androidFilePath">安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回文件内容，失败返回 null</returns>
        public string readAndroidFile(string androidFilePath)
        {
            return this.StrCmd("readAndroidFile", androidFilePath);
        }

        /// <summary>
        /// 读取安卓文件
        /// </summary>
        /// <param name="androidFilePath">安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回文件字节数组，失败返回 null</returns>
        public byte[] readAndroidFileBytes(string androidFilePath)
        {
            return this.bytesCmd("readAndroidFile", androidFilePath);
        }

        /// <summary>
        /// 删除安卓文件
        /// </summary>
        /// <param name="androidFilePath">安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public string deleteAndroidFile(string androidFilePath)
        {
            return this.StrCmd("deleteAndroidFile", androidFilePath);
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="androidFilePath">安卓文件路径，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public string existsAndroidFile(string androidFilePath)
        {
            return this.StrCmd("existsAndroidFile", androidFilePath);
        }

        /// <summary>
        /// 获取文件夹内的所有文件(不包含深层子目录)
        /// </summary>
        /// <param name="androidDirectory">安卓目录，安卓外部存储根目录 /storage/emulated/0/</param>
        /// <returns>成功返回所有子文件名称，用|分割，失败返回null</returns>
        public string getAndroidSubFiles(string androidDirectory)
        {
            return this.StrCmd("getAndroidSubFiles", androidDirectory);
        }

        /// <summary>
        /// 创建安卓文件夹
        /// </summary>
        /// <param name="androidDirectory">安卓目录</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool makeAndroidDir(string androidDirectory)
        {
            return this.BoolCmd("makeAndroidDir", androidDirectory);
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="action">动作，例如 "android.intent.action.VIEW"</param>
        /// <param name="uri">跳转链接，可选参数 例如：打开支付宝扫一扫界面，"alipayqr://platformapi/startapp?saId=10000007"</param>
        /// <param name="packageName">包名，可选参数 "com.xxx.xxxxx"</param>
        /// <param name="className">类名，可选参数</param>
        /// <param name="type">类型，可选参数</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool startActivity(string action, string uri, string packageName, string className, string type)
        {
            return this.BoolCmd("startActivity", action, uri, packageName, className, type);
        }

        /// <summary>
        /// 拨打电话
        /// </summary>
        /// <param name="phoneNumber">拨打的电话号码</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool callPhone(string phoneNumber)
        {
            return this.BoolCmd("callPhone", phoneNumber);
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phoneNumber">送的电话号码</param>
        /// <param name="message">短信内容</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool sendMsg(string phoneNumber, string message)
        {
            return this.BoolCmd("sendMsg", phoneNumber, message);
        }

        /// <summary>
        /// 获取当前活动窗口(Activity)
        /// </summary>
        /// <returns>成功返回当前activity</returns>
        public string getActivity()
        {
            return this.StrCmd("getActivity");
        }

        /// <summary>
        /// 获取当前活动包名(Package)
        /// </summary>
        /// <returns>成功返回当前包名</returns>
        public string getPackage()
        {
            return this.StrCmd("getPackage");
        }

        /// <summary>
        /// 设置剪切板文本
        /// </summary>
        /// <param name="text">设置的文本</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool setClipboardText(string text)
        {
            return this.BoolCmd("setClipboardText", text);
        }

        /// <summary>
        /// 获取剪切板文本
        /// </summary>
        /// <returns>需要打开aibote输入法。成功返回剪切板文本，失败返回null</returns>
        public string getClipboardText()
        {
            return this.StrCmd("getClipboardText");
        }

        /// <summary>
        /// 创建TextView控件
        /// </summary>
        /// <param name="id">控件ID，不可与其他控件重复</param>
        /// <param name="text">控件文本</param>
        /// <param name="x">控件在屏幕上x坐标</param>
        /// <param name="y">控件在屏幕上y坐标</param>
        /// <param name="width">控件宽度</param>
        /// <param name="height">控件高度</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool createTextView(int id, string text, int x, int y, int width, int height)
        {
            return this.BoolCmd("createTextView", id.ToString(), text, x.ToString(), y.ToString(), width.ToString(), height.ToString());
        }

        /// <summary>
        /// 创建EditText控件
        /// </summary>
        /// <param name="id">控件ID，不可与其他控件重复</param>
        /// <param name="text">控件文本</param>
        /// <param name="x">控件在屏幕上x坐标</param>
        /// <param name="y">控件在屏幕上y坐标</param>
        /// <param name="width">控件宽度</param>
        /// <param name="height">控件高度</param>
        /// <returns>成功返回true，失败返回 false</returns>
        /// <returns></returns>
        public bool createEditText(int id, string text, int x, int y, int width, int height)
        {
            return this.BoolCmd("createEditText", id.ToString(), text, x.ToString(), y.ToString(), width.ToString(), height.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">控件ID，不可与其他控件重复</param>
        /// <param name="text">控件文本</param>
        /// <param name="x">控件在屏幕上x坐标</param>
        /// <param name="y">控件在屏幕上y坐标</param>
        /// <param name="width">控件宽度</param>
        /// <param name="height">控件高度</param>
        /// <param name="isSelect">是否勾选</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool createCheckBox(int id, string text, int x, int y, int width, int height, bool isSelect)
        {
            return this.BoolCmd("createCheckBox", id.ToString(), text, x.ToString(), y.ToString(), width.ToString(), height.ToString(), isSelect.ToString());
        }

        /// <summary>
        /// 创建ListText控件
        /// </summary>
        /// <param name="id">控件ID，不可与其他控件重复</param>
        /// <param name="text">控件文本</param>
        /// <param name="x">控件在屏幕上x坐标</param>
        /// <param name="y">控件在屏幕上y坐标</param>
        /// <param name="width">控件宽度</param>
        /// <param name="height">控件高度</param>
        /// <param name="listText">列表文本</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool createListText(int id, string text, int x, int y, int width, int height, string listText)
        {
            return this.BoolCmd("createListText", id.ToString(), text, x.ToString(), y.ToString(), width.ToString(), height.ToString(), listText);
        }

        /// <summary>
        /// 创建WebView控件
        /// </summary>
        /// <param name="id">控件ID，不可与其他控件重复</param>
        /// <param name="url">加载的链接</param>
        /// <param name="x">控件在屏幕上x坐标，值为-1时自动填充宽高</param>
        /// <param name="y">控件在屏幕上y坐标，值为-1时自动填充宽高</param>
        /// <param name="width">控件宽度，值为-1时自动填充宽高</param>
        /// <param name="height">控件高度，值为-1时自动填充宽高</param>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool createWebView(int id, string url, int x, int y, int width, int height)
        {
            return this.BoolCmd("createWebView", id.ToString(), url, x.ToString(), y.ToString(), width.ToString(), height.ToString());
        }

        /// <summary>
        /// 清除脚本控件
        /// </summary>
        /// <returns>成功返回true，失败返回 false</returns>
        public bool clearScriptControl()
        {
            return this.BoolCmd("clearScriptControl");
        }

        /// <summary>
        ///  获取脚本配置参数
        /// </summary>
        /// <returns>成功返回{"id":"text", "id":"isSelect"} 此类对象，失败返回null。函数仅返回TextEdit和CheckBox控件值，需要用户点击安卓端 "提交参数" 按钮</returns>
        public JObject getScriptParam()
        {
            string strRet = this.StrCmd("getScriptParam");
            if (strRet == null) return null;
            else return JObject.Parse(strRet);
        }

        //hid 使用 port = 56668;//固定端口
        /// <summary>
        /// 初始化android Accessory，获取手机hid相关的数据。
        /// </summary>
        /// <returns>bool</returns>
        public bool initAccessory()
        {
            return this.BoolCmd("initAccessory");
        }


    }
}
