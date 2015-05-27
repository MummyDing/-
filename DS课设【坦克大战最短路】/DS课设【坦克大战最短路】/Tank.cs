using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DS课设_坦克大战最短路_.Properties;
using System.Windows.Forms;
namespace DS课设_坦克大战最短路_
{
    class Tank:GameObject
    {
        #region 窗体规格参数
        public static int LeftUpX = 0;
        public static int LeftUpY = 25;
        public static int RightDownX = 660;
        public static int RightDownY = 625;
        public static int Padding = 60;
        #endregion
        #region 导入资源
        public static Image[] TankImg =
        {
            Resources.TankU,
            Resources.TankD,
            Resources.TankL,
            Resources.TankR
        };
        #endregion
        #region 坦克属性
        public int Power
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public Direction Dir
        {
            get;
            set;
        }
        #endregion
        #region 坦克构造方法
        public Tank(int x,int y,Direction dir)
            :base(x,y,TankImg[0].Width,TankImg[0].Height){
                this.Dir = dir;
                this.Speed = TankImg[0].Width;
        }
        #endregion
        #region 重写Draw方法
        public override void Draw(Graphics g)
        {
            switch (this.Dir)
            {
                case Direction.Up:
                      g.DrawImage(TankImg[0], this.X, this.Y);
                    break;
                case Direction.Down:
                    g.DrawImage(TankImg[1], this.X, this.Y);
                    break;
                case Direction.Left:
                    g.DrawImage(TankImg[2], this.X, this.Y);
                    break;
                case Direction.Right:
                    g.DrawImage(TankImg[3], this.X, this.Y);
                    break; 
            }
        }
        #endregion
        #region 响应KeyDown事件
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (this.Dir == Direction.Up) this.Move();
                    else 
                    { 
                        this.Dir = Direction.Up;
                        GameObject.Cost++;
                    }
                    break;
                case Keys.Down:
                    if (this.Dir == Direction.Down) this.Move();
                    else
                    {
                        this.Dir = Direction.Down;
                        GameObject.Cost++;
                    }
                    break;
                case Keys.Left:
                    if (this.Dir == Direction.Left) this.Move();
                    else
                    {
                        this.Dir = Direction.Left;
                        GameObject.Cost++;
                    }
                    break;
                case Keys.Right:
                    if (this.Dir == Direction.Right) this.Move();
                    else
                    {
                        this.Dir = Direction.Right;
                        GameObject.Cost++;
                    }
                    break;
                case Keys.Enter:
                    this.Fire();
                    break;
            }
        }
        #endregion
        #region 添加Fire方法
        public void Fire()
        {
            SingleObject.GetObject().AddGameObject(new Bullet(this));
            GameObject.Cost++;
        }
        #endregion
        #region 添加Move方法
        public void Move()
        {
            //用于标记是否有走
            bool IsMove = true ;
            //存储没走之前的坐标
            int tempX = this.X;
            int tempY = this.Y;
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
            if(this.X<LeftUpX)
            {
                IsMove = false;
                this.X = LeftUpX;
            }
            else if (this.X > RightDownX)
            {
                IsMove = false;
                this.X = RightDownX;
            }
            if (this.Y < LeftUpY)
            {
                IsMove = false;
                this.Y = LeftUpY;
            }
            else if (this.Y > RightDownY)
            {
                IsMove = false;
                this.Y = RightDownY;
            }

            int GridX = this.X / MainForm.GridWidth;
            int GridY = (this.Y - LeftUpY) / MainForm.GridWidth;
            if (GameObject.EndPoint.X == GridX && GameObject.EndPoint.Y == GridY)
            {
                GameObject.Cost++;
                if(MainForm.AutoModelOpen==true)
                {
                    MessageBox.Show("\t共消耗能量值: " + GameObject.Cost.ToString() , "到达终点!");
                }
                else
                {
                    if (GameObject.Cost > MainForm.TotalCost)
                        MessageBox.Show("\t共消耗能量值: " + GameObject.Cost.ToString() + "\n\t" + "不过还不是最佳方案，加油哦！", "恭喜，到达终点!");
                    else
                        MessageBox.Show("\t共消耗能量值: " + GameObject.Cost.ToString() + "\n\t" + "好厉害，采用了最佳的方案，再接再厉！", "恭喜，到达终点!");
                }
                return;
            }
            //判断该点是否还能走
            if (GameObject.IsVisit[GridX, GridY] == false&&IsMove)
            {
                IsMove = false;
                this.X = tempX;
                this.Y = tempY;
            }
            if (IsMove) GameObject.Cost++;
        }
        #endregion
    }
}