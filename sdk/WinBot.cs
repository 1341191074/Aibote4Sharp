using Aibote4Sharp.sdk.options;
using DotNetty.Transport.Channels;
using Newtonsoft.Json.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Aibote4Sharp.sdk
{
    public abstract class WinBot : Aibote
    {
        public WinBot() { }

        public WinBot(IChannelHandlerContext aiboteChanel) : base(aiboteChanel)
        {
        }

        /**
    * 查找窗口句柄
    *
    * @param className  窗口类名
    * @param windowName 窗口名
    * @return string 成功返回窗口句柄，失败返回null
    */
        public string FindWindow(string className, string windowName)
        {
            return StrCmd("findWindow", className, windowName);
        }

        /**
         * 查找窗口句柄数组，  以 “|” 分割
         *
         * @param className  窗口类名
         * @param windowName 窗口名
         * @return string 成功返回窗口句柄，失败返回null
         */
        public string FindWindows(string className, string windowName)
        {
            return StrCmd("findWindows", className, windowName);
        }

        /**
         * 查找窗口句柄
         *
         * @param curHwnd    当前窗口句柄
         * @param className  窗口类名
         * @param windowName 窗口名
         * @return string 成功返回窗口句柄，失败返回null
         */
        public string FindSubWindow(string curHwnd, string className, string windowName)
        {
            return StrCmd("findSubWindow", curHwnd, className, windowName);
        }

        /**
         * 查找父窗口句柄
         *
         * @param curHwnd 当前窗口句柄
         * @return string 成功返回窗口句柄，失败返回null
         */
        public string FindParentWindow(string curHwnd)
        {
            return StrCmd("findParentWindow", curHwnd);
        }

        /**
         * 查找桌面窗口句柄
         *
         * @return 成功返回窗口句柄，失败返回null
         */
        public string FindDesktopWindow()
        {
            return StrCmd("findDesktopWindow");
        }

        /**
         * 获取窗口名称
         *
         * @param hwnd 当前窗口句柄
         * @return string 成功返回窗口句柄，失败返回null
         */
        public string GetWindowName(string hwnd)
        {
            return StrCmd("getWindowName", hwnd);
        }

        /**
         * 显示/隐藏窗口
         *
         * @param hwnd   当前窗口句柄
         * @param isShow 是否显示
         * @return bool  成功返回true，失败返回false
         */
        public bool ShowWindow(string hwnd, bool isShow)
        {
            return BoolCmd("showWindow", hwnd, isShow.ToString());
        }

        /**
         * 显示/隐藏窗口
         *
         * @param hwnd  当前窗口句柄
         * @param isTop 是否置顶
         * @return bool  成功返回true，失败返回false
         */
        public bool SetWindowTop(string hwnd, bool isTop)
        {
            return BoolCmd("setWindowTop", hwnd, isTop.ToString());
        }

        /**
         * 获取窗口位置。 用“|”分割
         *
         * @param hwnd 当前窗口句柄
         * @return 0|0|0|0
         */
        public string GetWindowPos(string hwnd)
        {
            return StrCmd("getWindowPos", hwnd);
        }

        /**
         * 设置窗口位置
         *
         * @param hwnd   当前窗口句柄
         * @param left   左上角横坐标
         * @param top    左上角纵坐标
         * @param width  width 窗口宽度
         * @param height height 窗口高度
         * @return bool 成功返回true 失败返回 false
         */
        public bool SetWindowPos(string hwnd, int left, int top, int width, int height)
        {
            return BoolCmd("setWindowPos", hwnd, left.ToString(), top.ToString(), width.ToString(), height.ToString());
        }

        /**
         * 移动鼠标 <br />
         * 如果mode值为true且目标控件有单独的句柄，则需要通过getElementWindow获得元素句柄，指定elementHwnd的值(极少应用窗口由父窗口响应消息，则无需指定)
         *
         * @param hwnd        窗口句柄
         * @param x           横坐标
         * @param y           纵坐标
         * @param mode        操作模式，后台 true，前台 false。默认前台操作。
         * @param elementHwnd 元素句柄
         * @return bool 总是返回true
         */
        public bool MoveMouse(string hwnd, int x, int y, bool mode, string elementHwnd)
        {
            return BoolCmd("moveMouse", hwnd, x.ToString(), y.ToString(), mode.ToString(), elementHwnd);
        }

        /**
         * 移动鼠标(相对坐标)
         *
         * @param hwnd 窗口句柄
         * @param x    相对横坐标
         * @param y    相对纵坐标
         * @param mode 操作模式，后台 true，前台 false。默认前台操作
         * @return bool 总是返回true
         */
        public bool MoveMouseRelative(string hwnd, int x, int y, bool mode)
        {
            return BoolCmd("moveMouseRelative", hwnd, x.ToString(), y.ToString(), mode.ToString());
        }

        /**
         * 滚动鼠标
         *
         * @param hwnd   窗口句柄
         * @param x      横坐标
         * @param y      纵坐标
         * @param dwData 鼠标滚动次数,负数下滚鼠标,正数上滚鼠标
         * @param mode   操作模式，后台 true，前台 false。默认前台操作
         * @return bool 总是返回true
         */
        public bool RollMouse(string hwnd, int x, int y, int dwData, bool mode)
        {
            return BoolCmd("rollMouse", hwnd, x.ToString(), y.ToString(), dwData.ToString(), mode.ToString());
        }

        /**
         * 鼠标点击<br />
         * 如果mode值为true且目标控件有单独的句柄，则需要通过getElementWindow获得元素句柄，指定elementHwnd的值(极少应用窗口由父窗口响应消息，则无需指定)
         *
         * @param hwnd        窗口句柄
         * @param x           横坐标
         * @param y           纵坐标
         * @param mouseType   单击左键:1 单击右键:2 按下左键:3 弹起左键:4 按下右键:5 弹起右键:6 双击左键:7 双击右键:8
         * @param mode        操作模式，后台 true，前台 false。默认前台操作。
         * @param elementHwnd 元素句柄
         * @return bool 总是返回true。
         */
        public bool ClickMouse(string hwnd, int x, int y, int mouseType, bool mode, string elementHwnd)
        {
            return BoolCmd("clickMouse", hwnd, x.ToString(), y.ToString(), mouseType.ToString(), mode.ToString(), elementHwnd);
        }

        /**
         * 输入文本
         *
         * @param txt 输入的文本
         * @return bool 总是返回true
         */
        public bool SendKeys(string txt)
        {
            return BoolCmd("sendKeys", txt);
        }

        /**
         * 后台输入文本
         *
         * @param hwnd 窗口句柄，如果目标控件有单独的句柄，需要通过getElementWindow获得句柄
         * @param txt  输入的文本
         * @return bool 总是返回true
         */
        public bool SendKeysByHwnd(string hwnd, string txt)
        {
            return BoolCmd("sendKeysByHwnd", hwnd, txt);
        }

        /**
         * 输入虚拟键值(VK)
         *
         * @param vk       VK键值，例如：回车对应 VK键值 13
         * @param keyState 按下弹起:1 按下:2 弹起:3
         * @return bool 总是返回true
         */
        public bool SendVk(int vk, int keyState)
        {
            return BoolCmd("sendVk", vk.ToString(), keyState.ToString());
        }

        /**
         * 后台输入虚拟键值(VK)
         *
         * @param hwnd     窗口句柄，如果目标控件有单独的句柄，需要通过getElementWindow获得句柄
         * @param vk       VK键值，例如：回车对应 VK键值 13
         * @param keyState 按下弹起:1 按下:2 弹起:3
         * @return bool 总是返回true
         */
        public bool SendVkByHwnd(string hwnd, int vk, int keyState)
        {
            return BoolCmd("sendVkByHwnd", hwnd, vk.ToString(), keyState.ToString());
        }

        /**
         * 截图保存。threshold默认保存原图。
         *
         * @param hwnd          窗口句柄
         * @param savePath      保存的位置
         * @param region        区域
         * @param thresholdType hresholdType算法类型。<br />
         *                      0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0
         *                      1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva
         *                      2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0
         *                      3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变
         *                      4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变
         *                      5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值
         *                      6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值
         * @param thresh        阈值。 thresh和maxval同为255时灰度处理
         * @param maxval        最大值。 thresh和maxval同为255时灰度处理
         * @return bool
         */
        public bool SaveScreenshot(string hwnd, string savePath, AiboteRegion region, int thresholdType, int thresh, int maxval)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }
            return BoolCmd("saveScreenshot", hwnd, savePath, region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString());
        }

        /**
         * 获取指定坐标点的色值
         *
         * @param hwnd 窗口句柄
         * @param x    横坐标
         * @param y    纵坐标
         * @param mode 操作模式，后台 true，前台 false。默认前台操作
         * @return 成功返回#开头的颜色值，失败返回null
         */
        public string GetColor(string hwnd, int x, int y, bool mode)
        {
            return StrCmd("getColor", hwnd, x.ToString(), y.ToString(), mode.ToString());
        }

        /**
         * @param hwndOrBigImagePath 窗口句柄或者图片路径
         * @param smallImagePath     小图片路径，多张小图查找应当用"|"分开小图路径
         * @param region             区域
         * @param sim                图片相似度 0.0-1.0，sim默认0.95
         * @param thresholdType      thresholdType算法类型：<br />
         *                           0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0
         *                           1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva
         *                           2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0
         *                           3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变
         *                           4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变
         *                           5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值
         *                           6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值
         * @param thresh             阈值。threshold默认保存原图。thresh和maxval同为255时灰度处理
         * @param maxval             最大值。threshold默认保存原图。thresh和maxval同为255时灰度处理
         * @param multi              找图数量，默认为1 找单个图片坐标
         * @param mode               操作模式，后台 true，前台 false。默认前台操作。hwndOrBigImagePath为图片文件，此参数无效
         * @return 成功返回 单坐标点[{x:number, y:number}]，多坐标点[{x1:number, y1:number}, {x2:number, y2:number}...] 失败返回null
         */
        public string FindImages(string hwndOrBigImagePath, string smallImagePath, AiboteRegion region, float sim, int thresholdType, int thresh, int maxval, int multi, bool mode)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            if (hwndOrBigImagePath.ToString().IndexOf(".") == -1)
            {//在窗口上找图
                return this.StrDelayCmd("findImage", hwndOrBigImagePath, smallImagePath, region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), sim.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString(), multi.ToString(), mode.ToString());
            }
            else
            {//在文件上找图
                return this.StrDelayCmd("findImageByFile", hwndOrBigImagePath, smallImagePath, region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), sim.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString(), multi.ToString(), mode.ToString());
            }
        }

        /**
         * 找动态图
         *
         * @param hwnd      窗口句柄
         * @param frameRate 前后两张图相隔的时间，单位毫秒
         * @param mode      操作模式，后台 true，前台 false。默认前台操作
         * @return 成功返回 单坐标点[{x:number, y:number}]，多坐标点[{x1:number, y1:number}, {x2:number, y2:number}...] 失败返回null
         */
        public string FindAnimation(string hwnd, int frameRate, AiboteRegion region, bool mode)
        {
            return this.StrDelayCmd("findAnimation", hwnd, frameRate.ToString(), region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), mode.ToString());
        }

        /**
         * 查找指定色值的坐标点
         *
         * @param hwnd         窗口句柄
         * @param strMainColor 颜色字符串，必须以 # 开头，例如：#008577；
         * @param subColors    辅助定位的其他颜色；
         * @param region       在指定区域内找色，默认全屏；
         * @param sim          相似度。0.0-1.0，sim默认为1
         * @param mode         后台 true，前台 false。默认前台操作。
         * @return string 成功返回 x|y 失败返回null
         */
        public string FindColor(string hwnd, string strMainColor, SubColor[] subColors, AiboteRegion region, float sim, bool mode)
        {
            StringBuilder subColorsStr = new StringBuilder();
            if (null != subColors)
            {
                SubColor subColor;
                for (int i = 0; i < subColors.Length; i++)
                {
                    subColor = subColors[i];
                    subColorsStr.Append(subColor.offsetX).Append("/");
                    subColorsStr.Append(subColor.offsetY).Append("/");
                    subColorsStr.Append(subColor.colorStr);
                    if (i < subColors.Length - 1)
                    { //最后不需要\n
                        subColorsStr.Append("\n");
                    }
                }
            }

            return this.StrDelayCmd("findColor", hwnd, strMainColor, subColorsStr.ToString(), region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), sim.ToString(), mode.ToString());
        }

        /**
         * 比较指定坐标点的颜色值
         *
         * @param hwnd         窗口句柄
         * @param mainX        主颜色所在的X坐标
         * @param mainY        主颜色所在的Y坐标
         * @param mainColorStr 颜色字符串，必须以 # 开头，例如：#008577；
         * @param subColors    辅助定位的其他颜色；
         * @param region       截图区域 默认全屏
         * @param sim          相似度，0-1 的浮点数
         * @param mode         操作模式，后台 true，前台 false,
         * @return bool
         */
        public bool CompareColor(string hwnd, int mainX, int mainY, string mainColorStr, SubColor[] subColors, AiboteRegion region, float sim, bool mode)
        {
            StringBuilder subColorsStr = new StringBuilder();
            if (null != subColors)
            {
                SubColor subColor;
                for (int i = 0; i < subColors.Length; i++)
                {
                    subColor = subColors[i];
                    subColorsStr.Append(subColor.offsetX).Append("/");
                    subColorsStr.Append(subColor.offsetY).Append("/");
                    subColorsStr.Append(subColor.colorStr);
                    if (i < subColors.Length - 1)
                    { //最后不需要\n
                        subColorsStr.Append("\n");
                    }
                }
            }
            return this.BoolDelayCmd("compareColor", hwnd, mainX.ToString(), mainY.ToString(), mainColorStr, subColorsStr.ToString(), region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), sim.ToString(), mode.ToString());
        }

        /**
         * 提取视频帧
         *
         * @param videoPath  视频路径
         * @param saveFolder 提取的图片保存的文件夹目录
         * @param jumpFrame  跳帧，默认为1 不跳帧
         * @return bool 成功返回true，失败返回false
         */
        public bool ExtractImageByVideo(string videoPath, string saveFolder, int jumpFrame)
        {
            return this.BoolCmd("extractImageByVideo", videoPath, saveFolder, jumpFrame.ToString());
        }

        /**
         * 裁剪图片
         *
         * @param imagePath  图片路径
         * @param saveFolder 裁剪后保存的图片路径
         * @param region     区域
         * @return bool 成功返回true，失败返回false
         */
        public bool CropImage(string imagePath, string saveFolder, AiboteRegion region)
        {
            return this.BoolCmd("cropImage", imagePath, saveFolder, region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString());
        }

        /**
         * 初始化ocr服务
         *
         * @param ocrServerIp    ocr服务器IP
         * @param ocrServerPort  ocr服务器端口，固定端口9527。 注意，如果传入的值<=0 ，则都会当默认端口处理。
         * @param useAngleModel  支持图像旋转。 默认false。仅内置ocr有效。内置OCR需要安装
         * @param enableGPU      启动GPU 模式。默认false 。GPU模式需要电脑安装NVIDIA驱动，并且到群文件下载对应cuda版本
         * @param enableTensorrt 启动加速，仅 enableGPU = true 时有效，默认false 。图片太大可能会导致GPU内存不足
         * @return bool 总是返回true
         */
        public bool InitOcr(string ocrServerIp, int ocrServerPort, bool useAngleModel, bool enableGPU, bool enableTensorrt)
        {
            //if (ocrServerPort <= 0) {
            ocrServerPort = 9527;
            //}
            return this.BoolCmd("initOcr", ocrServerIp, ocrServerPort.ToString(), useAngleModel.ToString(), enableGPU.ToString(), enableTensorrt.ToString());
        }

        /**
     * ocr识别
     *
     * @param hwnd          窗口句柄
     * @param region        区域
     * @param thresholdType 二值化算法类型
     * @param thresh        阈值
     * @param maxval        最大值
     * @param mode          操作模式，后台 true，前台 false。默认前台操作
     * @return string jsonstr
     */
        public List<OCRResult> OcrByHwnd(string hwnd, AiboteRegion region, int thresholdType, int thresh, int maxval, bool mode)
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
            string strRet = this.StrCmd("ocrByHwnd", hwnd, region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString(), mode.ToString());
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

        /**
         * ocr识别
         *
         * @param imagePath     图片路径
         * @param region        区域
         * @param thresholdType 二值化算法类型
         * @param thresh        阈值
         * @param maxval        最大值
         * @return string jsonstr
         */
        public List<OCRResult> OcrByFile(string imagePath, AiboteRegion region, int thresholdType, int thresh, int maxval)
        {
            if (null == region)
            {
                region = new AiboteRegion();
            }
            string strRet = this.StrCmd("ocrByFile", imagePath, region.left.ToString(), region.top.ToString(), region.right.ToString(), region.bottom.ToString(), thresholdType.ToString(), thresh.ToString(), maxval.ToString());
            if (strRet == null || strRet == "" || strRet == "null" || strRet == "[]")
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

        /**
         * 获取屏幕文字
         *
         * @param hwndOrImagePath 窗口句柄或者图片路径
         * @param region          区域
         * @param thresholdType   thresholdType算法类型：<br />
         *                        0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0<br />
         *                        1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva<br />
         *                        2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0<br />
         *                        3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变<br />
         *                        4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变<br />
         *                        5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值<br />
         *                        6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值
         * @param thresh          阈值
         * @param maxval          最大值
         * @param mode            后台 true，前台 false。默认前台操作, 仅适用于hwnd
         * @return 失败返回null，成功返窗口上的文字
         */
        public string GetWords(string hwndOrImagePath, AiboteRegion region, int thresholdType, int thresh, int maxval, bool mode)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            List<OCRResult> wordsResult = null;
            if (hwndOrImagePath.IndexOf(".") == -1)
            {
                wordsResult = this.OcrByHwnd(hwndOrImagePath, region, thresholdType, thresh, maxval, mode);
            }
            else
            {
                wordsResult = this.OcrByFile(hwndOrImagePath, region, thresholdType, thresh, maxval);
            }

            if (null == wordsResult)
            {
                return null;
            }

            StringBuilder words = new StringBuilder();
            foreach (var obj in wordsResult)
            {
                words.Append(obj.word).Append("\n");
            }

            return words.ToString();
        }

        /**
         * 查找文字
         *
         * @param hwndOrImagePath 窗口句柄或者图片路径
         * @param word            要查找的文字
         * @param region          区域
         * @param thresholdType   算法类型：<br />
         *                        *                        0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0<br />
         *                        *                        1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva<br />
         *                        *                        2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0<br />
         *                        *                        3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变<br />
         *                        *                        4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变<br />
         *                        *                        5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值<br />
         *                        *                        6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值
         * @param thresh          阈值
         * @param maxval          最大值
         * @param mode            后台 true，前台 false。默认前台操作, 仅适用于hwnd
         * @return Point
         */
        public AibotePoint FindWords(string hwndOrImagePath, string word, AiboteRegion region, int thresholdType, int thresh, int maxval, bool mode)
        {
            if (thresholdType == 5 || thresholdType == 6)
            {
                thresh = 127;
                maxval = 255;
            }

            List<OCRResult> wordsResult = null;
            if (hwndOrImagePath.IndexOf(".") == -1)
            {
                wordsResult = this.OcrByHwnd(hwndOrImagePath, region, thresholdType, thresh, maxval, mode);
            }
            else
            {
                wordsResult = this.OcrByFile(hwndOrImagePath, region, thresholdType, thresh, maxval);
            }

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

        /**
         * 初始化yolo服务
         *
         * @param yoloServerIp yolo服务器IP。端口固定为9528
         * @param modelPath    模型路径
         *  @param classesPath    种类路径，CPU模式需要此参数
         * @return {Promise.<bool>} 总是返回true
         */
        public bool InitYolo(string yoloServerIp, string modelPath, string classesPath)
        {
            return this.BoolCmd("initYolo", yoloServerIp, modelPath, classesPath);
        }

        /**
         * yoloByHwnd
         *
         * @param hwnd 窗口句柄
         * @param mode 操作模式，后台 true，前台 false。默认前台操作
         * @return {Promise.<[]>} 失败返回null，成功返回数组形式的识别结果
         */
        public JArray YoloByHwnd(string hwnd, bool mode)
        {
            string strRet = this.StrCmd("yoloByHwnd", hwnd, mode.ToString());
            if (!string.IsNullOrEmpty(strRet))
            {
                return JArray.Parse(strRet);
            }
            return null;
        }

        /**
         * yoloByFile
         *
         * @param imagePath 图片路径
         * @return {Promise.<[]>} 失败返回null，成功返回数组形式的识别结果
         */
        public JArray YoloByFile(string imagePath)
        {
            string strRet = this.StrCmd("yoloByFile", imagePath);
            if (!string.IsNullOrEmpty(strRet))
            {
                return JArray.Parse(strRet);
            }
            return null;
        }

        /**
         * 获取指定元素名称
         *
         * @param hwnd  窗口句柄。如果是java窗口并且窗口句柄和元素句柄不一致，需要使用getElementWindow获取窗口句柄。
         * @param xpath 元素路径 getElementWindow参数的xpath，Aibote Tool应当使用正常模式下获取的XPATH路径，不要 “勾选java窗口” 复选按钮。对话框子窗口，需要获取对应的窗口句柄操作
         * @return 成功返回元素名称
         */
        public string GetElementName(string hwnd, string xpath)
        {
            return this.StrDelayCmd("getElementName", hwnd, xpath);
        }

        /**
         * 获取指定元素文本
         *
         * @param hwnd  窗口句柄
         * @param xpath 元素路径
         * @return 成功返回元素文本
         */
        public string GetElementValue(string hwnd, string xpath)
        {
            return this.StrDelayCmd("getElementValue", hwnd, xpath);
        }

        /**
         * 获取指定元素矩形大小
         *
         * @param hwnd  窗口句柄。如果是java窗口并且窗口句柄和元素句柄不一致，需要使用getElementWindow获取窗口句柄。
         *                   * getElementWindow参数的xpath，Aibote Tool应当使用正常模式下获取的XPATH路径，不要 “勾选java窗口” 复选按钮。对话框子窗口，需要获取对应的窗口句柄操作
         * @param xpath 元素路径
         * @return Region
         */
        public AiboteRegion GetElementRect(string hwnd, string xpath)
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

        /**
         * 获取元素窗口句柄
         *
         * @param hwnd  窗口句柄
         * @param xpath 元素路径
         * @return 成功返回元素窗口句柄，失败返回null
         */
        public string GetElementWindow(string hwnd, string xpath)
        {
            return this.StrDelayCmd("getElementWindow", hwnd, xpath);
        }

        /**
         * 点击元素
         *
         * @param hwnd  窗口句柄。如果是java窗口并且窗口句柄和元素句柄不一致，需要使用getElementWindow获取窗口句柄。
         *              getElementWindow参数的xpath，Aibote Tool应当使用正常模式下获取的XPATH路径，不要 “勾选java窗口” 复选按钮。对话框子窗口，需要获取对应的窗口句柄操作
         * @param xpath 元素路径
         * @param opt   单击左键:1 单击右键:2 按下左键:3 弹起左键:4 按下右键:5 弹起右键:6 双击左键:7 双击右键:8
         * @return {Promise.<bool>} 成功返回true 失败返回 false
         */
        public bool ClickElement(string hwnd, string xpath, string opt)
        {
            return this.BoolDelayCmd("clickElement", hwnd, xpath, opt);
        }

        /**
         * 执行元素默认操作(一般是点击操作)
         *
         * @param {string|number} hwnd  窗口句柄。
         * @param {string}        xpath 元素路径
         * @return {Promise.<bool>} 成功返回true 失败返回 false
         */
        public bool InvokeElement(string hwnd, string xpath)
        {
            return this.BoolDelayCmd("invokeElement", hwnd, xpath);
        }

        /**
         * 设置指定元素作为焦点
         *
         * @param {string|number} hwnd  窗口句柄
         * @param {string}        xpath 元素路径
         * @return {Promise.<bool>} 成功返回true 失败返回 false
         */
        public bool SetElementFocus(string hwnd, string xpath)
        {
            return this.BoolDelayCmd("setElementFocus", hwnd, xpath);
        }

        /**
         * 设置元素文本
         *
         * @param hwnd  窗口句柄。如果是java窗口并且窗口句柄和元素句柄不一致，需要使用getElementWindow获取窗口句柄。
         *              getElementWindow参数的xpath，Aibote Tool应当使用正常模式下获取的XPATH路径，不要 “勾选java窗口” 复选按钮。对话框子窗口，需要获取对应的窗口句柄操作
         * @param xpath 元素路径
         * @param value 要设置的内容
         * @return {Promise.<bool>} 成功返回true 失败返回 false
         */
        public bool SetElementValue(string hwnd, string xpath, string value)
        {
            return this.BoolDelayCmd("setElementValue", hwnd, xpath, value);
        }

        /**
         * 滚动元素
         *
         * @param hwnd              窗口句柄
         * @param xpath             元素路径
         * @param horizontalPercent 水平百分比 -1不滚动
         * @param verticalPercent   垂直百分比 -1不滚动
         * @return 成功返回true 失败返回 false
         */
        public bool SetElementScroll(string hwnd, string xpath, float horizontalPercent, float verticalPercent)
        {
            return this.BoolDelayCmd("setElementScroll", hwnd, xpath, horizontalPercent.ToString(), verticalPercent.ToString());
        }

        /**
         * 单/复选框是否选中
         *
         * @param hwnd  窗口句柄
         * @param xpath 元素路径
         * @return 成功返回true 失败返回 false
         */
        public bool IsSelected(string hwnd, string xpath)
        {
            string strRet = this.StrDelayCmd("isSelected", hwnd, xpath);
            if ("selected".Equals(strRet)) return true;
            else return false;
        }

        /**
         * 关闭窗口
         *
         * @param hwnd  窗口句柄
         * @param xpath 元素路径
         * @return 成功返回true 失败返回 false
         */
        public bool CloseWindow(string hwnd, string xpath)
        {
            return BoolCmd("closeWindow", hwnd, xpath);
        }

        /**
         * 设置窗口状态
         *
         * @param hwnd  hwnd  窗口句柄。如果是java窗口并且窗口句柄和元素句柄不一致，需要使用getElementWindow获取窗口句柄。
         *              getElementWindow参数的xpath，Aibote Tool应当使用正常模式下获取的XPATH路径，不要 “勾选java窗口” 复选按钮。对话框子窗口，需要获取对应的窗口句柄操作
         * @param xpath 元素路径
         * @param state 0正常 1最大化 2 最小化
         * @return bool
         */
        public bool SetWindowState(string hwnd, string xpath, int state)
        {
            return BoolCmd("setWindowState", hwnd, xpath, state.ToString());
        }

        /**
         * 设置剪贴板
         *
         * @param text 文字内容
         * @return bool
         */
        public bool SetClipboardText(string text)
        {
            return BoolCmd("setClipboardText", text);
        }

        /**
         * 获取剪贴板内容
         *
         * @return
         */
        public string GetClipboardText()
        {
            return StrCmd("getClipboardText");
        }

        /**
         * 启动指定程序
         *
         * @param commandLine 启动命令行
         * @param showWindow  是否显示窗口。可选参数,默认显示窗口
         * @param isWait      是否等待程序结束。可选参数,默认不等待
         * @return {Promise.<bool>} 成功返回true,失败返回false
         */
        public bool StartProcess(string commandLine, bool showWindow, bool isWait)
        {
            return BoolCmd("startProcess", commandLine, showWindow.ToString(), isWait.ToString());
        }

        /**
         * 执行cmd命令
         *
         * @param command     cmd命令，不能含 "cmd"字串
         * @param waitTimeout 可选参数，等待结果返回超时，单位毫秒，默认300毫秒
         * @return {Promise.<string>} 返回cmd执行结果
         */
        public string ExecuteCommand(string command, int waitTimeout)
        {
            return StrCmd("executeCommand", command, waitTimeout.ToString());
        }

        /**
         * 指定url下载文件
         *
         * @param url      文件地址
         * @param filePath 文件保存的路径
         * @param isWait   是否等待.为true时,等待下载完成
         * @return {Promise.<bool>} 总是返回true
         */
        public bool DownloadFile(string url, string filePath, bool isWait)
        {
            return BoolCmd("downloadFile", url, filePath, isWait.ToString());
        }

        /**
         * 打开excel文档
         *
         * @param excelPath excle路径
         * @return {Promise.<Object>} 成功返回excel对象，失败返回null
         */
        public JObject OpenExcel(string excelPath)
        {
            string strRet = StrCmd("openExcel", excelPath);
            return JObject.Parse(strRet);
        }

        /**
         * 打开excel表格
         *
         * @param excelObject excel对象
         * @param sheetName   表名
         * @return {Promise.<Object>} 成功返回sheet对象，失败返回null
         */
        public JObject OpenExcelSheet(JObject excelObject, string sheetName)
        {
            string strRet = StrCmd("openExcelSheet", excelObject["book"].Value<string>(), excelObject["path"].Value<string>(), sheetName);
            return JObject.Parse(strRet);
        }

        /**
         * 保存excel文档
         *
         * @param excelObject excel对象
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool SaveExcel(JObject excelObject)
        {
            return BoolCmd("saveExcel", excelObject["book"].Value<string>(), excelObject["path"].Value<string>());
        }

        /**
         * 写入数字到excel表格
         *
         * @param sheetObject sheet对象
         * @param row         行
         * @param col         列
         * @param value       写入的值
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool WriteExcelNum(JObject sheetObject, int row, int col, int value)
        {
            return BoolCmd("writeExcelNum", sheetObject.ToString(), row.ToString(), col.ToString(), value.ToString());
        }

        /**
         * 写入字符串到excel表格
         *
         * @param sheetObject sheet对象
         * @param row         行
         * @param col         列
         * @param strValue    写入的值
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool WriteExcelStr(JObject sheetObject, int row, int col, string strValue)
        {
            return BoolCmd("writeExcelStr", sheetObject.ToString(), row.ToString(), col.ToString(), strValue);
        }

        /**
         * 读取excel表格数字
         *
         * @param sheetObject sheet对象
         * @param row         行
         * @param col         列
         * @return {Promise.<number>} 返回读取到的数字
         */
        public float ReadExcelNum(JObject sheetObject, int row, int col)
        {
            string strRet = StrCmd("readExcelNum", sheetObject.ToString(), row.ToString(), col.ToString());
            return float.Parse(strRet);
        }

        /**
         * 读取excel表格数字
         *
         * @param sheetObject sheet对象
         * @param row         行
         * @param col         列
         * @return {Promise.<number>} 返回读取到的数字
         */
        public string ReadExcelStr(JObject sheetObject, int row, int col)
        {
            return StrCmd("readExcelStr", sheetObject.ToString(), row.ToString(), col.ToString());
        }

        /**
         * 删除excel表格行
         *
         * @param sheetObject sheet对象
         * @param rowFirst    起始行
         * @param rowLast     结束行
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool RemoveExcelRow(JObject sheetObject, int rowFirst, int rowLast)
        {
            return BoolCmd("removeExcelRow", sheetObject.ToString(), rowFirst.ToString(), rowLast.ToString());
        }

        /**
         * 删除excel表格列
         *
         * @param sheetObject sheet对象
         * @param rowFirst    起始列
         * @param rowLast     结束列
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool RemoveExcelCol(JObject sheetObject, int rowFirst, int rowLast)
        {
            return BoolCmd("removeExcelCol", sheetObject.ToString(), rowFirst.ToString(), rowLast.ToString());
        }

        /**
         * 识别验证码
         *
         * @param filePath 图片文件路径
         * @param username 用户名
         * @param password 密码
         * @param softId   软件ID
         * @param codeType 图片类型 参考https://www.chaojiying.com/price.html
         * @param lenMin   最小位数 默认0为不启用,图片类型为可变位长时可启用这个参数
         * @return {Promise.<{err_no:number, err_str:string, pic_id:string, pic_str:string, md5:string}>} 返回JSON
         * err_no,(数值) 返回代码  为0 表示正常，错误代码 参考https://www.chaojiying.com/api-23.html
         * err_str,(字符串) 中文描述的返回信息
         * pic_id,(字符串) 图片标识号，或图片id号
         * pic_str,(字符串) 识别出的结果
         * md5,(字符串) md5校验值,用来校验此条数据返回是否真实有效
         */
        public JObject GetCaptcha(string filePath, string username, string password, string softId, string codeType, string lenMin)
        {
            if (string.IsNullOrEmpty(lenMin))
            {
                lenMin = "0";
            }
            byte[] bytes = File.ReadAllBytes(filePath);
            string file_base64 = Convert.ToBase64String(bytes);

            string url = "http://upload.chaojiying.net/Upload/Processing.php";
            JObject dataJsonObject = new JObject();
            dataJsonObject.Add("user", username);
            dataJsonObject.Add("pass", password);
            dataJsonObject.Add("softid", softId);
            dataJsonObject.Add("codetype", codeType);
            dataJsonObject.Add("len_min", lenMin);
            dataJsonObject.Add("file_base64", file_base64);

            JObject paramJsonObject = new JObject();
            paramJsonObject.Add("multipart", true);
            paramJsonObject.Add("data", dataJsonObject);

            string retStr = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:24.0) Gecko/20100101 Firefox/24.0");
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // 设置请求的URL

                // 设置请求的内容
                var content = new StringContent(paramJsonObject.ToString());

                var task = client.PostAsync(url, content);
                // 发送POST请求
                HttpResponseMessage response = task.Result;

                // 获取响应内容
                var task2 = response.Content.ReadAsStringAsync();
                retStr = task2.Result;//在这里会等待task返回。
                return JObject.Parse(retStr);

            }

            return null;

        }

        /**
         * 识别报错返分
         *
         * @param username 用户名
         * @param password 密码
         * @param softId   软件ID
         * @param picId    图片ID 对应 getCaptcha返回值的pic_id 字段
         * @return {Promise.<{err_no:number, err_str:string}>} 返回JSON
         * err_no,(数值) 返回代码
         * err_str,(字符串) 中文描述的返回信息
         */
        public JObject ErrorCaptcha(string username, string password, string softId, string picId)
        {

            string url = "http://upload.chaojiying.net/Upload/ReportError.php";
            JObject dataJsonObject = new JObject();
            dataJsonObject.Add("user", username);
            dataJsonObject.Add("pass", password);
            dataJsonObject.Add("softid", softId);
            dataJsonObject.Add("id", picId);

            JObject paramJsonObject = new JObject();
            paramJsonObject.Add("multipart", true);
            paramJsonObject.Add("data", dataJsonObject);

            string retStr = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:24.0) Gecko/20100101 Firefox/24.0");
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // 设置请求的URL

                // 设置请求的内容
                var content = new StringContent(paramJsonObject.ToString());

                var task = client.PostAsync(url, content);
                // 发送POST请求
                HttpResponseMessage response = task.Result;

                // 获取响应内容
                var task2 = response.Content.ReadAsStringAsync();
                retStr = task2.Result;//在这里会等待task返回。
                return JObject.Parse(retStr);

            }
            return null;
        }

        /**
         * 查询验证码剩余题分
         *
         * @param username 用户名
         * @param password 密码
         * @return {Promise.<{err_no:number, err_str:string, tifen:string, tifen_lock:string}>} 返回JSON
         * err_no,(数值) 返回代码
         * err_str,(字符串) 中文描述的返回信息
         * tifen,(数值) 题分
         * tifen_lock,(数值) 锁定题分
         */
        public JObject ScoreCaptcha(string username, string password)
        {

            string url = "http://upload.chaojiying.net/Upload/GetScore.php";
            JObject dataJsonObject = new JObject();
            dataJsonObject.Add("user", username);
            dataJsonObject.Add("pass", password);

            JObject paramJsonObject = new JObject();
            paramJsonObject.Add("multipart", true);
            paramJsonObject.Add("data", dataJsonObject);


            string retStr = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:24.0) Gecko/20100101 Firefox/24.0");
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // 设置请求的URL

                // 设置请求的内容
                var content = new StringContent(paramJsonObject.ToString());

                var task = client.PostAsync(url, content);
                // 发送POST请求
                HttpResponseMessage response = task.Result;

                // 获取响应内容
                var task2 = response.Content.ReadAsStringAsync();
                retStr = task2.Result;//在这里会等待task返回。
                return JObject.Parse(retStr);

            }
            return null;
        }

        /**
         * 初始化语音服务(不支持win7)
         *
         * @param speechKey,    微软语音API密钥
         * @param speechRegion, 区域
         * @return {Promise.<bool>} 成功返回true 失败返回false
         */
        public bool RemoveExcelCol(string speechKey, string speechRegion)
        {
            return BoolCmd("initSpeechService", speechKey, speechRegion);
        }

        /**
         * 音频文件转文本
         *
         * @param filePath, 音频文件路径
         * @param language, 语言，参考开发文档 语言和发音人
         * @return {Promise.<string || null>} 成功返回转换后的音频文本，失败返回null
         */
        public string AudioFileToText(string filePath, string language)
        {
            return StrCmd("audioFileToText", filePath, language);
        }

        /**
         * 麦克风输入流转换文本
         *
         * @param language, 语言，参考开发文档 语言和发音人
         * @return {Promise.<string || null>} 成功返回转换后的音频文本，失败返回null
         */
        public string MicrophoneToText(string language)
        {
            return StrCmd("microphoneToText", language);
        }

        /**
         * 文本合成音频到扬声器
         *
         * @param ssmlPathOrText，要转换语音的文本或者".xml"格式文件路径
         * @param language，语言，参考开发文档                    语言和发音人
         * @param voiceName，发音人，参考开发文档                  语言和发音人
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool TextToBullhorn(string ssmlPathOrText, string language, string voiceName)
        {
            return BoolCmd("textToBullhorn", ssmlPathOrText, language, voiceName);
        }

        /**
         * 文本合成音频并保存到文件
         *
         * @param ssmlPathOrText，要转换语音的文本或者".xml"格式文件路径
         * @param language，语言，参考开发文档                    语言和发音人
         * @param voiceName，发音人，参考开发文档                  语言和发音人
         * @param audioPath，保存音频文件路径
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool TextToAudioFile(string ssmlPathOrText, string language, string voiceName, string audioPath)
        {
            return BoolCmd("textToAudioFile", ssmlPathOrText, language, voiceName);
        }

        /**
         * 麦克风音频翻译成目标语言文本
         *
         * @param sourceLanguage，要翻译的语言，参考开发文档 语言和发音人
         * @param targetLanguage，翻译后的语言，参考开发文档 语言和发音人
         * @return {Promise.<string || null>} 成功返回翻译后的语言文本，失败返回null
         */
        public string MicrophoneTranslationText(string sourceLanguage, string targetLanguage)
        {
            return StrCmd("microphoneTranslationText", sourceLanguage, targetLanguage);
        }

        /**
         * 音频文件翻译成目标语言文本
         *
         * @param audioPath，                   要翻译的音频文件路径
         * @param sourceLanguage，要翻译的语言，参考开发文档 语言和发音人
         * @param targetLanguage，翻译后的语言，参考开发文档 语言和发音人
         * @return {Promise.<string || null>}成功返回翻译后的语言文本，失败返回null
         */
        public string AudioFileTranslationText(string audioPath, string sourceLanguage, string targetLanguage)
        {
            return StrCmd("audioFileTranslationText", audioPath, sourceLanguage, targetLanguage);
        }

        /**
         * 初始化数字人，第一次初始化需要一些时间
         *
         * @param metahumanModePath,   数字人模型路径
         * @param metahumanScaleValue, 数字人缩放倍数，1为原始大小。为0.5时放大一倍，2则缩小一半
         * @param isUpdateMetahuman,   是否强制更新，默认fasle。为true时强制更新会拖慢初始化速度
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool InitMetahuman(string metahumanModePath, float metahumanScaleValue, bool isUpdateMetahuman)
        {
            return BoolCmd("initMetahuman", metahumanModePath, metahumanScaleValue.ToString(), isUpdateMetahuman.ToString());
        }

        /**
         * 数字人说话，此函数需要调用 initSpeechService 初始化语音服务
         *
         * @param saveVoiceFolder, 保存的发音文件目录，文件名以0开始依次增加，扩展为.wav格式
         * @param text             要转换语音的文本
         * @param language         语言，参考开发文档                       语言和发音人
         * @param voiceName        发音人，参考开发文档                     语言和发音人
         * @param quality          音质，0低品质                          1中品质  2高品质， 默认为0低品质
         * @param waitPlaySound    等待音频播报完毕，true等待/false不等待
         * @param speechRate       语速，默认为0，取值范围 -100 至 200
         * @param voiceStyle       语音风格，默认General常规风格，其他风格参考开发文档 语言和发音人
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool MetahumanSpeech(string saveVoiceFolder, string text, string language, string voiceName, int quality, bool waitPlaySound, int speechRate, string voiceStyle)
        {
            if (string.IsNullOrEmpty(voiceStyle))
            {
                voiceStyle = "General";
            }
            return this.BoolCmd("metahumanSpeech", saveVoiceFolder, text, language, voiceName, quality.ToString(), waitPlaySound.ToString(), speechRate.ToString(), voiceStyle);
        }

        /**
         * 数字人说话缓存模式，需要调用 initSpeechService 初始化语音服务。函数一般用于常用的话术播报，非常用话术切勿使用，否则内存泄漏
         *
         * @param saveVoiceFolder 保存的发音文件目录，文件名以0开始依次增加，扩展为.wav格式
         * @param text            要转换语音的文本
         * @param language        语言，参考开发文档                       语言和发音人
         * @param voiceName       发音人，参考开发文档                     语言和发音人
         * @param quality         音质，0低品质                          1中品质  2高品质， 默认为0低品质
         * @param waitPlaySound   等待音频播报完毕，true等待/false不等待
         * @param speechRate      语速，默认为0，取值范围 -100 至 200
         * @param voiceStyle      语音风格，默认General常规风格，其他风格参考开发文档 语言和发音人
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool MetahumanSpeechCache(string saveVoiceFolder, string text, string language, string voiceName, int quality, bool waitPlaySound, int speechRate, string voiceStyle)
        {
            if (string.IsNullOrEmpty(voiceStyle))
            {
                voiceStyle = "General";
            }
            return this.BoolCmd("metahumanSpeechCache", saveVoiceFolder, text, language, voiceName, quality.ToString(), waitPlaySound.ToString(), speechRate.ToString(), voiceStyle);
        }


        /**
         * 数字人插入视频
         *
         * @param videoFilePath  插入的视频文件路径
         * @param audioFilePath  插入的视频文件路径
         * @param audioFilePath, 插入的音频文件路径
         * @param waitPlayVideo  等待视频播放完毕,true等待/false不等待
         * @return
         */
        public bool MetahumanInsertVideo(string videoFilePath, string audioFilePath, bool waitPlayVideo)
        {
            return BoolCmd("metahumanInsertVideo", videoFilePath, audioFilePath, waitPlayVideo.ToString());
        }

        /**
         * 替换数字人背景
         *
         * @param bgFilePath   数字人背景 图片/视频 路径。仅替换绿幕背景的数字人模型
         * @param replaceRed   数字人背景的三通道之一的 R通道色值。默认-1 自动提取
         * @param replaceGreen 数字人背景的三通道之一的 G通道色值。默认-1 自动提取
         * @param replaceBlue  数字人背景的三通道之一的 B通道色值。默认-1 自动提取
         * @param simValue     相似度。 默认为0，此处参数用作微调RBG值。取值应当大于等于0
         * @return {Promise.<bool>} 总是返回true。此函数依赖 initMetahuman函数运行，否则程序会崩溃
         */
        public bool ReplaceBackground(string bgFilePath, int replaceRed, int replaceGreen, int replaceBlue, int simValue)
        {
            return BoolCmd("replaceBackground", bgFilePath, replaceRed.ToString(), replaceGreen.ToString(), replaceBlue.ToString(), simValue.ToString());
        }

        /**
         * 显示数字人说话的文本
         *
         * @param originY   第一个字显示的起始Y坐标点。 默认0 自适应高度
         * @param fontType  字体样式，支持操作系统已安装的字体。例如"Arial"、"微软雅黑"、"楷体"
         * @param fontSize  字体的大小。默认30
         * @param fontRed   字体颜色三通道之一的 R通道色值。默认可填入 128
         * @param fontGreen 字体颜色三通道之一的 G通道色值。默认可填入 255
         * @param fontBlue  字体颜色三通道之一的 B通道色值。默认可填入 0
         * @param italic    是否斜体,默认false
         * @param underline 是否有下划线,默认false
         * @return {Promise.<bool>} 总是返回true。此函数依赖 initMetahuman函数运行，否则程序会崩溃
         */
        public bool ShowSpeechText(int originY, string fontType, int fontSize, int fontRed, int fontGreen, int fontBlue, bool italic, bool underline)
        {
            return BoolCmd("showSpeechText", originY.ToString(), fontType, fontSize.ToString(), fontRed.ToString(), fontGreen.ToString(), fontBlue.ToString(), italic.ToString(), underline.ToString());
        }

        /**
         * 生成数字人短视频，此函数需要调用 initSpeechService 初始化语音服务
         *
         * @param saveVideoFolder, 保存的视频目录
         * @param text             要转换语音的文本
         * @param language         语言，参考开发文档 语言和发音人
         * @param voiceName        发音人，参考开发文档 语言和发音人
         * @param bgFilePath       数字人背景 图片/视频 路径，扣除绿幕会自动获取绿幕的RGB值，null 则不替换背景。仅替换绿幕背景的数字人模型
         * @param simValue         相似度，默认为0。此处参数用作绿幕扣除微调RBG值。取值应当大于等于0
         * @param voiceStyle       语音风格，默认General常规风格，其他风格参考开发文档 语言和发音人
         * @param quality          音质，0低品质  1中品质  2高品质， 默认为0低品质
         * @param speechRate       语速，默认为0，取值范围 -100 至 200
         * @return {Promise.<bool>} 成功返回true，失败返回false
         */
        public bool MakeMetahumanVideo(string saveVideoFolder, string text, string language, string voiceName, string bgFilePath, int simValue, string voiceStyle, int quality, int speechRate)
        {
            return BoolCmd("makeMetahumanVideo", saveVideoFolder, text, language, voiceName, bgFilePath, simValue.ToString(), voiceStyle, quality.ToString(), speechRate.ToString());
        }

        /**初始化数字人声音克隆服务
         * @param {string} apiKey, API密钥
         * @param {string} voiceId, 声音ID
         * @return {Promise.<boolean>} 成功返回true，失败返回false
        */
        public bool InitSpeechCloneService(string apiKey, string voiceId)
        {
            return BoolCmd("initSpeechCloneService", apiKey, voiceId);
        }

        /**数字人使用克隆声音说话，此函数需要调用 initSpeechCloneService 初始化语音服务
         * @param {string} saveAudioPath, 保存的发音文件路径。这里是路径，不是目录！
         * @param {string} text,要转换语音的文本
         * @param {string} language，语言，中文：zh-cn，其他语言：other-languages 
         * @param {boolean} waitPlaySound，等待音频播报完毕，默认为 true等待
         * @return {Promise.<boolean>} 成功返回true，失败返回false
        */
        public bool MetahumanSpeechClone(string saveAudioPath, string text, string language, bool waitPlaySound = true)
        {
            return BoolCmd("metahumanSpeechClone", saveAudioPath, text, language, waitPlaySound.ToString());
        }

        /**使用克隆声音生成数字人短视频，此函数需要调用 initSpeechCloneService 初始化语音服务
         * @param {string} saveVideoFolder, 保存的视频和音频文件目录
         * @param {string} text,要转换语音的文本
         * @param {string} language，语言，中文：zh-cn，其他语言：other-languages
         * @param {string} bgFilePath,数字人背景 图片/视频 路径，扣除绿幕会自动获取绿幕的RGB值，null 则不替换背景。仅替换绿幕背景的数字人模型
         * @param {number} simValue, 相似度，默认为0。此处参数用作绿幕扣除微调RBG值。取值应当大于等于0
         * @return {Promise.<boolean>} 成功返回true，失败返回false
        */
        public bool MakeMetahumanVideoClone(string saveVideoFolder, string text, string language, string bgFilePath,int simValue = 0)
        {
            return BoolCmd("makeMetahumanVideoClone", saveVideoFolder, text, language, bgFilePath, simValue.ToString());
        }

        /**打断数字人说话，一般用作人机对话场景。
         * metahumanSpeech和metahumanSpeechCache的 waitPlaySound 参数 设置为false时，此函数才有意义
         * @return {Promise.<boolean>} 总是返回true
        */
        public bool MetahumanSpeechBreak()
        {
            return BoolCmd("metahumanSpeechBreak");
        }

        /**数字人说话文件缓存模式
         * @param {string} audioPath, 音频路径， 同名的 .lab文件需要和音频文件在同一目录下
         * @param {boolean} waitPlaySound，等待音频播报完毕，默认为 true等待
         * @return {Promise.<boolean>} 成功返回true，失败返回false
        */
        public bool MetahumanSpeechByFile(string audioPath, bool waitPlaySound = true)
        {
            return BoolCmd("metahumanSpeechByFile", audioPath, waitPlaySound.ToString());
        }

        /**
         * 获取WindowsDriver.exe 命令扩展参数，一般用作脚本远程部署场景，WindowsDriver.exe驱动程序传递参数给脚本服务端
         *
         * @return {Promise.<string>} 返回WindowsDriver驱动程序的命令行参数(不包含ip和port)
         */
        public string GetExtendParam()
        {
            return StrCmd("getExtendParam");
        }

        /**
         * 关闭驱动
         *
         * @return bool
         */
        public bool CloseDriver()
        {
            return BoolCmd("closeDriver");
        }
    }
}
