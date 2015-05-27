using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS课设_坦克大战最短路_;
using System.Windows.Forms;
namespace DS课设_坦克大战最短路_
{
    #region Direction枚举
    /// <summary>
    /// 方向枚举变量
    /// </summary>
    enum Direction
    {
        /// <summary>
        /// 向上
        /// </summary>
        Up,
        /// <summary>
        /// 向下
        /// </summary>
        Down,
        /// <summary>
        /// 向左
        /// </summary>
        Left,
        /// <summary>
        /// 向右
        /// </summary>
        Right
    }
    #endregion
    abstract class GameObject
    {
        //MainForm.
        #region "全局"参数
        public  const int Max_Len=100;
        /// <summary>
        /// 标记该点是否可以走
        /// </summary>
        public static bool[,] IsVisit = new bool[15, 15];
        /// <summary>
        /// 保存当前地图
        /// </summary>
        public static char[,] InitMap = new char[15, 15];
        public static bool[,] InitIsVisit = new bool[15, 15];
        /// <summary>
        /// 坦克起点
        /// </summary>
        public static Point StartPoint;
        /// <summary>
        /// 星星位置(终点)
        /// </summary>
        public static Point EndPoint;
        /// <summary>
        /// 当前消耗能量值
        /// </summary>
        public static int Cost = 0;
        /// <summary>
        /// 用来标记是否可以绘制
        /// </summary>
        public static bool IsDrawOk = true;
        /// <summary>
        /// 保存路径
        /// </summary>
        public static TankAcationType[] AcationPath = new TankAcationType[Max_Len];
        #endregion
        #region 游戏对象属性
        /// <summary>
        /// 游戏对象横坐标
        /// </summary>
        public int X
        {
            get;
            set;
        }
        /// <summary>
        /// 游戏对象纵坐标
        /// </summary>
        public int Y
        {
            get;
            set;
        }
        /// <summary>
        /// 游戏对象宽度
        /// </summary>
        public int Width
        {
            get;
            set;
        }
        /// <summary>
        /// 游戏对象高度
        /// </summary>
        public int Height
        {
            get;
            set;
        }
        #endregion
        #region 游戏对象构造方法
        /// <summary>
        /// 游戏对象构造函数
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public GameObject(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
        #endregion
        #region 游戏对象方法
        /// <summary>
        /// 绘制函数
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// 获取当前对象所 在矩形区域
        /// </summary>
        /// <returns></returns>
        public Rectangle Getangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
       
         #endregion
    }
}
