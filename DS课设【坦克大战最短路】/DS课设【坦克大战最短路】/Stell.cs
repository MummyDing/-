using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class Stell:WallFather
    {
         #region 导入资源
        /// <summary>
        /// 导入“铁墙”图片资源
        /// </summary>
        public static Image StellImg = Resources.Stell;
        #endregion
        #region 砖块构造方法
        public Stell(int x,int  y)
            : base(x, y, 2,StellImg) {
            }
        #endregion
    }
}
