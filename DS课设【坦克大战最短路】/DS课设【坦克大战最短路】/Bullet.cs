using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class Bullet : GameObject
    {
        #region 窗体规格参数
        /// <summary>
        /// 游戏区域左上角横坐标
        /// </summary>
        public static int LeftUpX = 0;
        /// <summary>
        /// 游戏区域左上角纵坐标
        /// </summary>
        public static int LeftUpY = 25;
        /// <summary>
        /// 游戏区域右下角横坐标
        /// </summary>
        public static int RightDownX = 660;
        /// <summary>
        /// 游戏区域右下角纵坐标
        /// </summary>
        public static int RightDownY = 625;
        public static int Padding = 60;
        #endregion
        #region 导入资源
        public static Image BulletImg = Resources.Bullet;
        #endregion
        #region 添加属性
        public int Power
        {
            get;
            set;
        }
        public Image Img
        {
            get;
            set;
        }
        public Direction Dir
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        #endregion
        #region 子弹构造方法
        /// <summary>
        /// 子弹构造方法
        /// </summary>
        /// <param name="T">坦克</param>
        public Bullet(Tank T)
            : base(T.X + T.Height / 2-10, T.Y + T.Width / 2-10, BulletImg.Width, BulletImg.Height)
        {
            this.Img = BulletImg;
            this.Dir = T.Dir;
            this.Speed = 30;
            this.Power = 1;
        }
        #endregion
        #region 重写Draw函数
        /// <summary>
        /// 重写绘图函数
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y-=this.Speed;
                    break;
                case Direction.Down:
                    this.Y+=this.Speed;
                    break;
                case Direction.Left:
                    this.X-=this.Speed;
                    break;
                case Direction.Right:
                   this.X+=this.Speed;
                    break;
            }
            //子弹打出墙
            if (this.X <=LeftUpX)
            {
                this.X-=Padding;
            }
            if(this.X>=RightDownX+Padding)
            {
                this.X += Padding;
            }
            if (this.Y >= RightDownY+Padding)
            {
                this.Y += Padding;
            }
            if(this.Y<=LeftUpY)
            {
                this.Y -= Padding;
            }
            g.DrawImage(this.Img,this.X,this.Y);
        }
        #endregion
    }
}
