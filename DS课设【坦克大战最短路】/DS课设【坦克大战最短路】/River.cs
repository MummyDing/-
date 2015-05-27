using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class River:RSFather
    {
        /// <summary>
        /// 导入河水图片资源
        /// </summary>
        public static  Image RiverImg = Resources.River;
        public River(int x,int y)
            : base(x, y,RiverImg){}
    }
}
