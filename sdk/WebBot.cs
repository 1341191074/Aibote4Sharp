using DotNetty.Transport.Channels;
using System.Diagnostics;

namespace Aibote4Sharp.sdk
{
    public abstract class WebBot : Aibote
    {
        public WebBot() { }

        public WebBot(IChannelHandlerContext aiboteChanel) : base(aiboteChanel)
        {
        }

        /**
        * 导航至 url
        *
        * @param url 网址
        * @return bool
        */
        public bool Navigate(string url)
        {
            return BoolCmd("goto", url);
        }

        /**
         * 新建tab页面并跳转到指定url
         *
         * @param url 网址
         * @return bool
         */
        public bool NewPage(string url)
        {
            return BoolCmd("newPage", url);
        }

        /**
         * 返回
         *
         * @return bool
         */
        public bool Back()
        {
            return BoolCmd("back");
        }

        /**
         * 前进
         *
         * @return bool
         */
        public bool Forward()
        {
            return BoolCmd("forward");
        }


        /**
         * 刷新
         *
         * @return bool
         */
        public bool Refresh()
        {
            return BoolCmd("refresh");
        }

        /**
         * 获取当前页面id
         *
         * @return string
         */
        public string GetCurPageId()
        {
            return StrCmd("getCurPageId");
        }

        /**
         * 获取所有页面id
         *
         * @return string
         */
        public string GetAllPageId()
        {
            return StrCmd("getAllPageId");
        }


        /**
         * 切换指定页面
         *
         * @return bool
         */
        public bool SwitchPage(string pageId)
        {
            return BoolCmd("switchPage", pageId);
        }

        /**
         * 关闭当前页面
         *
         * @return bool
         */
        public bool ClosePage()
        {
            return BoolCmd("closePage");
        }

        /**
         * 获取当前url
         *
         * @return string
         */
        public string GetCurrentUrl()
        {
            return StrCmd("getCurrentUrl");
        }


        /**
         * 获取当前标题
         *
         * @return string
         */
        public string GetTitle()
        {
            return StrCmd("getTitle");
        }

        /**
         * 切换frame
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool SwitchFrame(string xpath)
        {
            return BoolCmd("switchFrame", xpath);
        }


        /**
         * 切换到主frame
         *
         * @return bool
         */
        public bool SwitchMainFrame()
        {
            return BoolCmd("switchMainFrame");
        }

        /**
         * 点击元素
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool ClickElement(string xpath)
        {
            return BoolCmd("clickElement", xpath);
        }

        /**
         * 设置编辑框值
         *
         * @param xpath xpath路径
         * @param value 目标值
         * @return bool
         */
        public bool SetElementValue(string xpath, string value)
        {
            return BoolCmd("setElementValue", xpath, value);
        }


        /**
         * 获取文本
         *
         * @param xpath xpath路径
         * @return bool
         */
        public string GetElementText(string xpath)
        {
            return StrCmd("getElementText", xpath);
        }


        /**
         * 获取outerHTML
         *
         * @param xpath xpath路径
         * @return bool
         */
        public string GetElementOuterHTML(string xpath)
        {
            return StrCmd("getElementOuterHTML", xpath);
        }


        /**
         * 获取innerHTML
         *
         * @param xpath xpath路径
         * @return bool
         */
        public string GetElementInnerHTML(string xpath)
        {
            return StrCmd("getElementInnerHTML", xpath);
        }

        /**
         * 设置属性值
         *
         * @param xpath xpath路径
         * @param value 属性值
         * @return bool
         */
        public bool SetElementAttribute(string xpath, string value)
        {
            return BoolCmd("setElementAttribute", xpath, value);
        }

        /**
         * 获取指定属性的值
         *
         * @param xpath     xpath路径
         * @param attribute 属性名
         * @return bool
         */
        public string GetElementAttribute(string xpath, string attribute)
        {
            return StrCmd("getElementAttribute", xpath, attribute);
        }


        /**
         * 获取矩形位置
         *
         * @param xpath xpath路径
         * @return bool
         */
        public string GetElementRect(string xpath)
        {
            return StrCmd("getElementRect", xpath);
        }


        /**
         * 判断元素是否选中
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool IsSelected(string xpath)
        {
            return BoolCmd("isSelected", xpath);
        }


        /**
         * 判断元素是否可见
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool IsDisplayed(string xpath)
        {
            return BoolCmd("isDisplayed", xpath);
        }

        /**
         * 判断元素是否可用
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool IsEnabled(string xpath)
        {
            return BoolCmd("isEnabled", xpath);
        }

        /**
         * 清空元素
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool ClearElement(string xpath)
        {
            return BoolCmd("clearElement", xpath);
        }

        /**
         * 设置元素焦点
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool SetElementFocus(string xpath)
        {
            return BoolCmd("setElementFocus", xpath);
        }

        /**
         * 通过元素上传文件
         *
         * @param xpath       xpath路径
         * @param uploadFiles 上传的文件路径
         * @return bool
         */
        public bool UploadFile(string xpath, string uploadFiles)
        {
            return BoolCmd("uploadFile", xpath, uploadFiles);
        }

        /**显示元素xpath路径，页面加载完毕再调用。
        * 调用此函数后，可在页面移动鼠标会显示元素区域。移动并按下ctrl键，会在浏览器控制台打印相对xpath 和 绝对xpath路径
        * ifrmae 内的元素，需要先调用 switchFrame 切入进去，再调用showXpath函数
        * @return {Promise.<boolean>} 总是返回true
       */
        public bool showXpath()
        {
            return BoolCmd("showXpath");
        }

        /**
         * 输入文本
         *
         * @param xpath xpath路径
         * @param txt   文本内容
         * @return bool
         */
        public bool SendKeys(string xpath, string txt)
        {
            return BoolCmd("sendKeys", xpath, txt);
        }


        /**
         * 发送Vk虚拟键
         *
         * @param vk 虚拟键
         * @return bool
         */
        public bool SendVk(string vk)
        {
            return BoolCmd("sendVk", vk);
        }

        /**
         * 单击鼠标
         *
         * @param x   x 横坐标，非Windows坐标，页面左上角为起始坐标
         * @param y   y 纵坐标，非Windows坐标，页面左上角为起始坐标
         * @param opt 功能键。单击左键:1  单击右键:2  按下左键:3  弹起左键:4  按下右键:5  弹起右键:6  双击左键：7
         * @return bool
         */
        public bool ClickMouse(string x, string y, string opt)
        {
            return BoolCmd("clickMouse", x, y, opt);
        }

        /**
         * 移动鼠标
         *
         * @param x x 横坐标，非Windows坐标，页面左上角为起始坐标
         * @param y y 纵坐标，非Windows坐标，页面左上角为起始坐标
         * @return bool
         */
        public bool MoveMouse(string x, string y)
        {
            return BoolCmd("moveMouse", x, y);
        }

        /**
         * 滚动鼠标
         *
         * @param deltaX deltaX 水平滚动条移动的距离
         * @param deltaY deltaY 垂直滚动条移动的距离
         * @param x      可选参数，鼠标横坐标位置， 默认为0
         * @param y      可选参数，鼠标纵坐标位置， 默认为0
         * @return bool
         */
        public bool WheelMouse(string deltaX, string deltaY, string x = "0", string y = "0")
        {
            return BoolCmd("wheelMouse", deltaX, deltaY, x, y);
        }

        /**
         * 通过xpath 点击鼠标
         *
         * @param xpath xpath路径
         * @param opt   功能键。单击左键:1  单击右键:2  按下左键:3  弹起左键:4  按下右键:5  弹起右键:6  双击左键：7
         * @return
         */
        public bool ClickMouseByXpath(string xpath, string opt)
        {
            return BoolCmd("clickMouseByXpath", xpath, opt);
        }

        /**
         * xpath移动鼠标(元素中心点)
         *
         * @param xpath xpath路径
         * @return bool
         */
        public bool MoveMouseByXpath(string xpath)
        {
            return BoolCmd("moveMouseByXpath", xpath);
        }

        /**
         * xpath滚动鼠标
         *
         * @param xpath  元素路径
         * @param deltaX 水平滚动条移动的距离
         * @param deltaY 垂直滚动条移动的距离
         * @return bool
         */
        public bool WheelMouseByXpath(string xpath, string deltaX, string deltaY)
        {
            return BoolCmd("wheelMouseByXpath", xpath, deltaX, deltaY);
        }


        /**
         * 截图
         *
         * @param xpath 可选参数，元素路径。如果指定该参数则截取元素图片
         * @return string
         */
        public string TakeScreenshot(string xpath)
        {
            if (string.IsNullOrEmpty(xpath))
            {
                return StrCmd("takeScreenshot");
            }
            return StrCmd("takeScreenshot", xpath);
        }


        /**
         * 点击警告框
         *
         * @param acceptOrCancel true接受, false取消
         * @param promptText     可选参数，输入prompt警告框文本
         * @return bool
         */
        public bool ClickAlert(bool acceptOrCancel, string promptText)
        {
            return BoolCmd("clickAlert", acceptOrCancel.ToString(), promptText);
        }


        /**
         * 截图
         *
         * @return string
         */
        public string GetAlertText()
        {
            return StrCmd("getAlertText");
        }

        /**
         * 获取指定url匹配的cookies
         *
         * @param url 指定的url http://或https:// 起头
         * @return 成功返回json格式的字符串，失败返回null
         */
        public string GetCookies(string url)
        {
            return StrCmd("getCookies", url);
        }

        /**
         * 获取指定url匹配的cookies
         *
         * @return 成功返回json格式的字符串，失败返回null
         */
        public string GetAllCookies()
        {
            return StrCmd("getAllCookies");
        }

        public bool SetCookie(string name, string value, string url)
        {
            string domain = "", path = "", sameSite = "", priority = "", sourceScheme = "", partitionKey = "";
            bool secure = false, httpOnly = false, sameParty = false;
            int expires = 0, sourcePort = 0;
            return SetCookie(name, value, url, domain, path, secure, httpOnly, sameSite, expires, priority, sameParty, sourceScheme, sourcePort, partitionKey);
        }

        public bool SetCookie(string name, string value, string url, string domain)
        {
            string path = "", sameSite = "", priority = "", sourceScheme = "", partitionKey = "";
            bool secure = false, httpOnly = false, sameParty = false;
            int expires = 0, sourcePort = 0;
            return SetCookie(name, value, url, domain, path, secure, httpOnly, sameSite, expires, priority, sameParty, sourceScheme, sourcePort, partitionKey);
        }

        public bool SetCookie(string name, string value, string url, string domain, Dictionary<string, string> options)
        {
            string path = "", sameSite = "", priority = "", sourceScheme = "", partitionKey = "";
            bool secure = false, httpOnly = false, sameParty = false;
            int expires = 0, sourcePort = 0;
            if (!string.IsNullOrEmpty(options["path"]))
            {
                path = options["path"];
            }
            if (!string.IsNullOrEmpty(options["sameSite"]))
            {
                sameSite = options["sameSite"];
            }
            if (!string.IsNullOrEmpty(options["priority"]))
            {
                priority = options["priority"];
            }
            if (!string.IsNullOrEmpty(options["sourceScheme"]))
            {
                sourceScheme = options["sourceScheme"];
            }
            if (!string.IsNullOrEmpty(options["partitionKey"]))
            {
                partitionKey = options["partitionKey"];
            }
            if (!string.IsNullOrEmpty(options["secure"]))
            {
                if ("true".Equals(options["secure"]))
                {
                    secure = true;
                }
            }
            if (!string.IsNullOrEmpty(options["httpOnly"]))
            {
                if ("true".Equals(options["httpOnly"]))
                {
                    httpOnly = true;
                }
            }
            if (!string.IsNullOrEmpty(options["sameParty"]))
            {
                if ("sameParty".Equals(options["sameParty"]))
                {
                    sameParty = true;
                }
            }
            if (!string.IsNullOrEmpty(options["expires"]))
            {
                expires = Convert.ToInt32(options["expires"]);
            }
            if (!string.IsNullOrEmpty(options["sourcePort"]))
            {
                sourcePort = Convert.ToInt32(options["sourcePort"]);
            }
            return SetCookie(name, value, url, domain, path, secure, httpOnly, sameSite, expires, priority, sameParty, sourceScheme, sourcePort, partitionKey);
        }

        /**
         * 设置cookie  name、value和url必填参数，其他参数可选
         *
         * @param name         string
         * @param value        string
         * @param url          string
         * @param domain       string
         * @param path         string
         * @param secure       bool
         * @param httpOnly     bool
         * @param sameSite     string
         * @param expires      string
         * @param priority     string
         * @param sameParty    bool
         * @param sourceScheme string
         * @param sourcePort   string
         * @param partitionKey string
         * @return
         */
        public bool SetCookie(string name, string value, string url, string domain, string path, bool secure, bool httpOnly, string sameSite, int expires, string priority, bool sameParty, string sourceScheme, int sourcePort, string partitionKey)
        {
            return BoolCmd("setCookie", name, value, url, domain, path, secure.ToString(), httpOnly.ToString(), sameSite, expires.ToString(), priority, sameParty.ToString(), sourceScheme, sourcePort.ToString(), partitionKey);
        }

        /**
         * 删除指定cookies
         *
         * @param name 要删除的 Cookie 的名称。
         * @return bool
         */
        public bool DeleteCookies(string name)
        {
            return BoolCmd("deleteCookies", name);
        }

        /**
         * 删除指定cookies
         *
         * @param name 要删除的 Cookie 的名称。
         * @param url  url
         * @return bool
         */
        public bool DeleteCookies(string name, string url)
        {
            return BoolCmd("deleteCookies", name, url);
        }

        /**
         * 删除指定cookies
         *
         * @param name 要删除的 Cookie 的名称。
         * @param url  url
         * @return bool
         */
        public bool DeleteCookies(string name, string url, string domain)
        {
            return BoolCmd("deleteCookies", name, url, domain);
        }

        /**
         * 删除指定cookies
         *
         * @param name 要删除的 Cookie 的名称。
         * @param url  url
         * @return bool
         */
        public bool DeleteCookies(string name, string url, string domain, string path)
        {
            return BoolCmd("deleteCookies", name, url, domain, path);
        }

        /**
         * 删除所有cookies
         *
         * @return bool
         */
        public bool DeleteAllCookies()
        {
            return BoolCmd("deleteAllCookies");
        }

        /**
         * 注入JavaScript <br />
         * 假如注入代码为函数且有return语句，则返回retrun 的值，否则返回null;  注入示例：(function () {return "aibote rpa"})();
         *
         * @param command 注入的js代码
         * @return
         */
        public string ExecuteScript(string command)
        {
            return StrCmd("executeScript", command);
        }

        /**
         * 获取窗口位置和状态 <br />
         * 成功返回矩形位置和窗口状态，失败返回null
         *
         * @return {left:number, top:number, width:number, height:number, windowState:string}
         */
        public string GetWindowPos()
        {
            return StrCmd("getWindowPos");
        }

        /**
         * 设置窗口位置和状态
         *
         * @param windowState 窗口状态，正常:"normal"  最小化:"minimized"  最大化:"maximized"  全屏:"fullscreen"
         * @param left        可选参数，浏览器窗口位置，此参数仅windowState 值为 "normal" 时有效
         * @param top         可选参数，浏览器窗口位置，此参数仅windowState 值为 "normal" 时有效
         * @param width       可选参数，浏览器窗口位置，此参数仅windowState 值为 "normal" 时有效
         * @param height      可选参数，浏览器窗口位置，此参数仅windowState 值为 "normal" 时有效
         * @return
         */
        public bool SetWindowPos(string windowState, float left, float top, int width, float height)
        {
            return BoolCmd("setWindowPos", left.ToString(), top.ToString(), width.ToString(), height.ToString());
        }

        /**
         * 获取WebDriver.exe 命令扩展参数，一般用作脚本远程部署场景，WebDriver.exe驱动程序传递参数给脚本服务端
         *
         * @return string 返回WebDriver 驱动程序的命令行["extendParam"] 字段的参数
         */
        public string GetExtendParam()
        {
            return StrCmd("getExtendParam");
        }

        /**
         * 手机浏览器仿真
         *
         * @param width           宽度
         * @param height          高度
         * @param userAgent       用户代理
         * @param platform        系统，例如 "Android"、"IOS"、"iPhone"
         * @param platformVersion 系统版本号，例如 "9.0"，应当与userAgent提供的版本号对应
         * @param acceptLanguage  可选参数 - 语言，例如 "zh-CN"、"en"
         * @param timezoneId      可选参数 - 时区，时区标识，例如"Asia/Shanghai"、"Europe/Berlin"、"Europe/London" 时区应当与 语言、经纬度 对应
         * @param latitude        可选参数 - 纬度，例如 31.230416
         * @param longitude       可选参数 - 经度，例如 121.473701
         * @param accuracy        可选参数 - 准确度，例如 1111
         * @return bool
         */
        public bool MobileEmulation(int width, int height, string userAgent, string platform, string platformVersion, string acceptLanguage, string timezoneId, float latitude, float longitude, float accuracy)
        {
            return BoolCmd("mobileEmulation", width.ToString(), height.ToString(), userAgent, platform, platformVersion, acceptLanguage, timezoneId, latitude.ToString(), longitude.ToString(), accuracy.ToString());
        }

        /**
         * 关闭浏览器
         *
         * @return bool
         */
        public bool CloseBrowser()
        {
            return BoolCmd("closeBrowser");
        }

        /**
         * 关闭WebDriver.exe驱动程序
         *
         * @return bool
         */
        public bool CloseDriver()
        {
            return BoolCmd("closeDriver");
        }

        /**
         * 仿真模式 开始触屏
         *
         * @param x x坐标
         * @param y y坐标
         * @return
         */
        public bool TouchStart(int x, int y)
        {
            return BoolCmd("touchStart", x.ToString(), y.ToString());
        }

        /**
         * 仿真模式 移动触屏
         *
         * @param x x坐标
         * @param y y坐标
         * @return
         */
        public bool TouchMove(int x, int y)
        {
            return BoolCmd("touchMove", x.ToString(), y.ToString());
        }

        /**
         * 仿真模式 结束触屏
         *
         * @param x x坐标
         * @param y y坐标
         * @return
         */
        public bool TouchEnd(int x, int y)
        {
            return BoolCmd("touchEnd", x.ToString(), y.ToString());
        }

        /**
         * 激活框架
         * @param {string} activateKey, 激活密钥，联系管理员
         * @return {Promise.<boolean>} 返回激活信息
        */
        public bool ActivateFrame(string activateKey)
        {
            return BoolCmd("touchEnd", activateKey);
        }
    }
}
