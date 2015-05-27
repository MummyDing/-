using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class WallFather:GameObject
    {
        #region 墙壁父类添加属性
        public int Life
        {
            get;
            set;
        }
        public Image Img
        {
            get;
            set;
        }
        #endregion
        #region 墙壁父类构造方法
        public WallFather(int x,int y,int life,Image img)
            : base(x, y, img.Width, img.Height)
        {
            this.Life = life;
            this.Img = img;
        }
        #endregion
        #region 重写父类Draw函数
        public override void Draw(Graphics g)
        {
            g.DrawImage(this.Img, this.X, this.Y);
        }
        #endregion
     
    }
}
