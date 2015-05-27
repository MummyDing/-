using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class RSFather:GameObject
    {
        public Image Img
        {
            get;
            set;
        }
        #region 构造函数
        public RSFather(int x,int y,Image img)
            : base(x, y, img.Width,img.Height) {
                this.Img = img;
            }
        #endregion
        #region 重写Draw
        public override void Draw(Graphics g)
        {
            g.DrawImage(Img,this.X, this.Y);
        }
        #endregion
    }
}
