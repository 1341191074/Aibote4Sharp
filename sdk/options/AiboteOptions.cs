using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibote4Sharp.sdk.options
{
    public class AiboteRegion
    {
        /**
 * 左。默认0
 */
        public int left;
        /**
         * 上。默认0
         */
        public int top;
        /**
         * 右。默认0
         */
        public int right;
        /**
         * 下。默认0
         */
        public int bottom;

    }

    public class SubColor
    {
        public int offsetX;
        public int offsetY;
        public string colorStr;
    }

    /**
 * 手势路径
 */
    public class GesturePath
    {
        private StringBuilder GesturePathStr = new StringBuilder();

        public void addXY(int x, int y)
        {
            GesturePathStr.Append(x).Append("/");
            GesturePathStr.Append(y).Append("/");
        }

        /**
         * 返回原始数据
         *
         * @return
         */
        public String gesturePathStr()
        {
            return GesturePathStr.ToString();
        }

        /**
         * 返回s 补位信息
         *
         * @return
         */
        public String gesturePathStr(String s)
        {
            GesturePathStr.Append(s);
            return GesturePathStr.ToString();
        }


    }
}
