using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS课设_坦克大战最短路_.Properties;
using System.Drawing;
namespace DS课设_坦克大战最短路_
{
    class Brick:WallFather
    {
        #region 导入资源
        /// <summary>
        /// 导入“砖块”图片资源
        /// </summary>
        public static Image BrickImg = Resources.Brick;
        #endregion
        #region 砖块构造方法
        public Brick(int x,int  y)
            : base(x, y, 1, BrickImg) {
            }
        #endregion
    }
}
