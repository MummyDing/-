using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class Boom:GameObject
    {
        /// <summary>
        /// 导入“爆炸”图片资源
        /// </summary>
        private static Image[] imgs = { 
                                Resources.blast1,
                                Resources.blast2,
                                Resources.blast3,
                                Resources.blast4,
                                Resources.blast5,
                                Resources.blast6,
                                Resources.blast7,
                                Resources.blast8,
                               };
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        public Boom(int x, int y)
            : base(x, y,imgs[0].Width,imgs[0].Height)
        {

        }
        /// <summary>
        /// 重写绘制函数
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length; i++)
            {
                g.DrawImage(imgs[i], this.X, this.Y);
            }
            //爆炸图片播放完成  就销毁自己
            SingleObject.GetObject().RemoveGameObject(this);
        }

    }
}
