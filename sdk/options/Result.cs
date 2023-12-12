using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aibote4Sharp.sdk.options
{
    public class OCRResult
    {
        public AibotePoint lt;
        public AibotePoint rt;
        public AibotePoint ld;
        public AibotePoint rd;
        public string? word;
        public double rate;
    }
    public class AibotePoint
    {
        /// <summary>
        /// x。默认0
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// y。默认0
        /// </summary>
        public int y { get; set; }
        public AibotePoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
