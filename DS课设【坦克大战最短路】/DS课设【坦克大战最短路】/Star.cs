using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class Star:RSFather
    {
        /// <summary>
        /// 导入“星星”图片资源
        /// </summary>
         public static  Image StarImg = Resources.Star;
        public Star(int x,int y)
            : base(x, y,StarImg){}
    }
}
