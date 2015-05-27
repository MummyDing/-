using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DS课设_坦克大战最短路_.Properties;
using System.Media;
using System.Runtime.InteropServices; 
namespace DS课设_坦克大战最短路_
{
  
    #region 枚举变量定义
    /// <summary>
    /// 绘制类型
    /// </summary>
    public enum OperType
    {
        /// <summary>
        /// 绘制坦克
        /// </summary>
        DrawTank,
        /// <summary>
        /// 绘制砖块
        /// </summary>
        DrawBrick,
        /// <summary>
        /// 绘制铁墙
        /// </summary>
        DrawSteel,
        /// <summary>
        /// 绘制河水
        /// </summary>
        DrawRiver,
        /// <summary>
        /// 绘制星星
        /// </summary>
        DrawStar,
        None
    };
    /// <summary>
    /// 地图绘制模式
    /// </summary>
    public enum MapDrawMode
    {
        Auto,
        Manual,
        None
    };
    public enum TankAcationType
    {
        //Move
        MoveStep,
        //Fire Move
        FireOneWall,
        //Fire Fire Move
        FireTwoWall,

        //Dir->Up Move
        ChangeTheDirToUp,
        //Dir->Up Fire
        ChangeToUpFireOne,
        //Dir->Up Fire Fire
        ChangeToUpFireTwo,

        //Dir->Down Fire
        ChangeToDownFireOne,
        //Dir->Down Move
        ChangeTheDirToDown,
        //Dir->Down Fire Fire
        ChangeToDownFireTwo,


        //Dir->Left Move
        ChangeTheDirToLeft,
        //Dir->Left Fire
        ChangeToLeftFireOne,
        //Dir->Left Fire Fire
        ChangeToLeftFireTwo,

        //Dir->Right Move
        ChangeTheDirToRight,
        //Dir->Right Fire
        ChangeToRightFireOne,
        //Dir->Right Fire Fire
        ChangeToRightFireTwo,

        None
     } ;
    #endregion
    public partial class MainForm : Form
    {
        #region 参数定义
        public static Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width,
              Screen.AllScreens[0].Bounds.Height);
        public static bool isCutDraw = false;
        //创建截图窗体
        Cutter cutter = new Cutter();
        [DllImport("CppDll.dll", SetLastError = true,CallingConvention=CallingConvention.Cdecl)]
        private static extern int bfs(string Map,  TankAcationType[] Path,ref int ToTalStep);
        /// <summary>
        /// 方格边长
        /// </summary>
        public static int GridWidth=60;
        public static int WidthX = 12;
        public static int HeightY = 11;
        /// <summary>
        /// 一条边的方格数
        /// </summary>
        public static int GridNum = 15;
        public static int TotalStep;
        public static Random randomNum = new Random();
        /// <summary>
        /// 总共需要消耗的能量
        /// </summary>
        public static int TotalCost=-2;
        /// <summary>
        /// 当前"绘制"类型
        /// </summary>
        public static OperType Type=OperType.None;
        /// <summary>
        /// 当前地图绘制类型
        /// </summary>
        public static MapDrawMode mapDrawMode = MapDrawMode.None;

        /// <summary>
        /// 自动模式标记变量
        /// </summary>
        public static bool AutoModelOpen = false;
        /// <summary>
        /// 手动模式标记变量
        /// </summary>
        public static bool ManualModelOpen = false;


         #endregion
         public MainForm()
        {
            InitializeComponent();
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度
            this.Location = new Point(-5,-25);

        }
        #region 初始化方法
         public void InitMap()
         {
             for (int i = 0; i < GridNum; i++)
             {
                 for (int j = 0; j < GridNum; j++)
                 {
                     GameObject.InitMap[i, j] = '#';
                     GameObject.IsVisit[i, j] = true;
                     GameObject.InitIsVisit[i, j] = true;
                 }
             }
             GameObject.StartPoint.X = -1;
             GameObject.EndPoint.X = -1;
         }
        /// <summary>
        /// 【新游戏】
        /// </summary>
        public void NewGame()
        {
            #region  清理所有游戏对象
            SingleObject.listBrick.Clear();
            SingleObject.listRiver.Clear();
            SingleObject.listBullet.Clear();
            SingleObject.listBoom.Clear();
            SingleObject.listStell.Clear();
            #endregion
            #region 初始化变量
            InitMap();
            GameObject.IsDrawOk = true;
            GameObject.Cost = 0;
            TotalCost = -2;
            AutoModelOpen = false;
            ManualModelOpen = false;
            mapDrawMode = MapDrawMode.None;
            Type = OperType.None;
            SingleObject.GetObject().T = null;
            SingleObject.GetObject().S = null; 
            label2.Text = "当前坦克坐标 :  ";
            label3.Text = "当前鼠标坐标: ";
            #endregion
        }
        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitGame()
        {
            #region  清理所有游戏对象
            SingleObject.listBrick.Clear();
            SingleObject.listRiver.Clear();
            SingleObject.listBullet.Clear();
            SingleObject.listBoom.Clear();
            SingleObject.listStell.Clear();
            #endregion
            #region 重新添加游戏对象
            int TmpWidth, TmpHeight;
            for (int i = 0; i < GridNum; i++)
                for (int j = 0; j < GridNum; j++)
                {
                    TmpWidth = i * GridWidth;
                    TmpHeight = j* GridWidth + Tank.LeftUpY;
                    switch (GameObject.InitMap[i, j])
                    {
                        case 'T':
                            Tank TmpTank = new Tank(TmpWidth, TmpHeight, Direction.Up);
                            SingleObject.GetObject().T = TmpTank;
                            break;
                        case 'B':
                            Brick TmpBrick = new Brick(TmpWidth, TmpHeight);
                            SingleObject.listBrick.Add(TmpBrick);
                            break;
                        case 'S':
                            Stell TmpStell = new Stell(TmpWidth, TmpHeight);
                            SingleObject.listStell.Add(TmpStell);
                            break;
                        case 'R':
                            River TmpRiver = new River(TmpWidth, TmpHeight);
                            SingleObject.listRiver.Add(TmpRiver);
                            break;
                        case 'X':
                            Star TmpStar=new Star(TmpWidth,TmpHeight);
                            SingleObject.GetObject().S = TmpStar;
                            break;
                    }
                }
            #endregion
            #region 变量初始化
            for (int i=0;i<15;i++)
                for(int j=0;j<15;j++)
                {
                    GameObject.IsVisit[i, j] = GameObject.InitIsVisit[i, j];
                }
            GameObject.Cost = 0;
            #endregion
        }
        #endregion
        #region 响应菜单事件
        private void TankMenu_Click(object sender, EventArgs e)
        {
            if (mapDrawMode == MapDrawMode.None)
            {
                MessageBox.Show("还未指定地图绘制模式，不能进行绘制！");
                return;
            }
            if(mapDrawMode==MapDrawMode.Auto)
            {
                MessageBox.Show("你当前选择的是自动模式，不能进行手动绘制");
                return;
            }
            if(SingleObject.GetObject().T==null)
            Type = OperType.DrawTank;
        }

        private void BrickMenu_Click(object sender, EventArgs e)
        {
            if (mapDrawMode == MapDrawMode.None)
            {
                MessageBox.Show("还未指定地图绘制模式，不能进行绘制！");
                return;
            }
            if (mapDrawMode == MapDrawMode.Auto)
            {
                MessageBox.Show("你当前选择的是自动模式，不能进行手动绘制");
                return;
            }
            Type = OperType.DrawBrick;
        }

        private void SteelMenu_Click(object sender, EventArgs e)
        {
            if (mapDrawMode == MapDrawMode.None)
            {
                MessageBox.Show("还未指定地图绘制模式，不能进行绘制！");
                return;
            }
            if (mapDrawMode == MapDrawMode.Auto)
            {
                MessageBox.Show("你当前选择的是自动模式，不能进行手动绘制");
                return;
            }
            Type = OperType.DrawSteel;
         }
        private void RiverMenu_Click(object sender, EventArgs e)
        {
            if (mapDrawMode == MapDrawMode.None)
            {
                MessageBox.Show("还未指定地图绘制模式，不能进行绘制！");
                return;
            }
            if (mapDrawMode == MapDrawMode.Auto)
            {
                MessageBox.Show("你当前选择的是自动模式，不能进行手动绘制");
                return;
            }
            Type = OperType.DrawRiver;
        }

        private void StarMenu_Click(object sender, EventArgs e)
        {
            if(SingleObject.GetObject().S==null)
            Type = OperType.DrawStar;
        }

        private void AutoModelMenu_Click(object sender, EventArgs e)
        {
            if (GameObject.EndPoint.X == -1)
            {
                MessageBox.Show("你还未绘制终点(星星)，不能开始游戏！");
                return;
            }
            else if (GameObject.StartPoint.X == -1)
            {
                MessageBox.Show("你还未绘制坦克，不能开始游戏！");
                return;
            }
            InitGame();
            //自动模式开启  手动模式关闭
            AutoModelOpen = true;
            ManualModelOpen = false;
            //绘制关闭
            GameObject.IsDrawOk = false;
        /*
            //地图类型转换
            int add = 0;
            StringBuilder sb = new StringBuilder();
            foreach (char c in GameObject.InitMap)
            {
                sb.Append(c);
                add++;
             //   if (add % 15 == 0) sb.Append("\n");
            }
            string s = sb.ToString();
       //     MessageBox.Show(s);
            //调用C++ dll 处理
            TotalCost = bfs(s, GameObject.AcationPath,ref TotalStep);
          //  MessageBox.Show(TotalCost.ToString());
              */
            
            if (mapDrawMode== MapDrawMode.Manual&&RunTest()==false)
            {
                MessageBox.Show("此图无法到达终点","非法数据");
                return;
            }
            AutoRun();
        }
        private void ManualModelMenu_Click(object sender, EventArgs e)
        {
            if (GameObject.EndPoint.X == -1)
            {
                MessageBox.Show("你还未绘制终点(星星)，不能开始游戏！");
                return;
            }
            else if (GameObject.StartPoint.X == -1)
            {
                MessageBox.Show("你还未绘制坦克，不能开始游戏！");
                return;
            }
            InitGame();
            //手动模式开启，自动模式关闭
            ManualModelOpen = true;
            AutoModelOpen = false;
            GameObject.IsDrawOk = false;
        }
        #endregion
        #region 响应鼠标事件
        /// <summary>
        /// 响应鼠标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            //判断现在当前是否允许绘制
            if (GameObject.IsDrawOk == false) return;
            if (Type == OperType.None)
            {
                MessageBox.Show("请选择你要绘制的类型！");
            }
            //获取格子坐标
            int GridX = e.X / GridWidth;
            int GridY = (e.Y-Tank.LeftUpY) / GridWidth;
            //如果该点出现在坦克或是星星上，则return
            if (GridX == GameObject.StartPoint.X && GridY == GameObject.StartPoint.Y ||
                GridX == GameObject.EndPoint.X && GridY == GameObject.EndPoint.Y)
                return;
            //判断该点是否还能放置
            if (GameObject.IsVisit[GridX, GridY] == false) return;
            //获取该点坐标
            int MouseX=GridX*GridWidth;
            int MouseY =GridY*GridWidth+Tank.LeftUpY;
            switch(Type)
            {
                case OperType.DrawTank:
                    GameObject.StartPoint.X = GridX;
                    GameObject.StartPoint.Y = GridY;
                    GameObject.InitMap[GridX,GridY] = 'T';
                    SingleObject.GetObject().AddGameObject(new Tank(MouseX, MouseY,Direction.Up));
                    Type = OperType.None;
                    break;
                case OperType.DrawBrick:
                    GameObject.InitMap[GridX, GridY] = 'B';
                    GameObject.IsVisit[GridX, GridY] = false;
                    SingleObject.GetObject().AddGameObject(new Brick(MouseX, MouseY));
                    break;
                case OperType.DrawSteel:
                    GameObject.InitMap[GridX, GridY] = 'S';
                    GameObject.IsVisit[GridX, GridY] = false;
                    SingleObject.GetObject().AddGameObject(new Stell(MouseX, MouseY));
                     break;
                case OperType.DrawRiver:
                     GameObject.InitMap[GridX, GridY] = 'R';
                     GameObject.IsVisit[GridX, GridY] = false;
                     SingleObject.GetObject().AddGameObject(new River(MouseX, MouseY));
                    break;
                case OperType.DrawStar:
                     GameObject.InitMap[GridX, GridY] = 'X';
                     GameObject.EndPoint.X = GridX;
                     GameObject.EndPoint.Y = GridY;
                    SingleObject.GetObject().AddGameObject(new Star(MouseX, MouseY));
                    Type = OperType.None;
                    break;
            }
            //保存IsVisit
            for (int i = 0; i < GridNum; i++)
                for (int j = 0; j < GridNum; j++)
                    GameObject.InitIsVisit[i, j] = GameObject.IsVisit[i, j];
        }
        #endregion
        #region Paint
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //更新当前坦克能量消耗值
            EnergyCost.Text = GameObject.Cost.ToString();
            //绘制当前界面
            SingleObject.GetObject().Draw(e.Graphics);
            //更新当前时间
            NextStep.Text=DateTime.Now.ToLongTimeString().ToString(); 
            //更新当前坦克坐标
            if (SingleObject.GetObject().T != null)
            {
                label2.Text = "当前坦克坐标 :  " + (SingleObject.GetObject().T.X / GridWidth).ToString() + "," + ((SingleObject.GetObject().T.Y - Tank.LeftUpY) / GridWidth).ToString();
            }
        }
    
        #endregion
        #region Timer_Tick事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            //对窗体进行更新
            this.Invalidate();
            //调用碰撞检测方法
            SingleObject.GetObject().Check();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        #endregion
        #region load事件
        private void MainForm_Load(object sender, EventArgs e)
        {
            helpProvider.HelpNamespace = Application.StartupPath + @"\帮助文档.chm";
          helpProvider.SetShowHelp(this, true);
            SplashScreen.ShowSplashScreen();
            System.Threading.Thread.Sleep(4000);
            if (SplashScreen.Instance != null)
            {
                SplashScreen.Instance.BeginInvoke(new MethodInvoker(SplashScreen.Instance.Dispose));
                SplashScreen.Instance = null;
            }  
            //初始化变量
             NewGame();
            //激活时间控件
            timer1.Enabled = true; 
            //让控件不闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

        }
        #endregion
        #region KeyDown事件
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers== Keys.Control&&e.KeyCode == Keys.H)
            {
                Introduction introductionForm = new Introduction();
                Image image = Resources.游戏操作说明;
                introductionForm.Width = image.Width + 5;
                introductionForm.Height = image.Height + 35;
                introductionForm.BackgroundImage = image;
                introductionForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          
                introductionForm.ShowDialog();
                //introductionForm.TopLevel = true;
              //  introductionForm.TopMost = true;
                return;
            }
            if (!(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right||e.KeyCode==Keys.Enter))
            {
                return;
            }
            if (AutoModelOpen == true)
            {
                //如果自动模式开启，则不响应按键
                return;
            }
            if (GameObject.IsDrawOk == true)
            {
                MessageBox.Show("你还未选择游戏模式，不能开始游戏");
                return;
            }
            SingleObject.GetObject().T.KeyDown(e);
            
        }
        #endregion
        #region RunTest
        public bool RunTest()
        {
            //地图类型转换
            int add = 0;
            StringBuilder sb = new StringBuilder();
            foreach (char c in GameObject.InitMap)
            {
                sb.Append(c);
                add++;
                //   if (add % 15 == 0) sb.Append("\n");
            }
            string s = sb.ToString();
            //     MessageBox.Show(s);
            //调用C++ dll 处理
            TotalCost = bfs(s, GameObject.AcationPath, ref TotalStep);
            if (TotalCost == -1) return false;
            return true;
        }
        #endregion
        #region AutoRun 方法
        public  void AutoRun()
        {
            for (int i = 0; i <TotalStep; i++)
            {
                switch (GameObject.AcationPath[i])
                {
                    case TankAcationType.ChangeTheDirToUp:
                        NextStep.Text = "下一步: 向上";
                        MessageBox.Show("向上");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Up;
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeTheDirToDown:
                        MessageBox.Show("向下");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Down;
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeTheDirToLeft:
                        MessageBox.Show("向左");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Left;
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeTheDirToRight:
                        MessageBox.Show("向右");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Right;
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.FireOneWall:
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.FireTwoWall:
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                         SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.MoveStep:
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToDownFireOne:
                        MessageBox.Show("向下");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Down;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToDownFireTwo:
                        MessageBox.Show("向下");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Down;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToLeftFireOne:
                        MessageBox.Show("向左");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Left;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToLeftFireTwo:
                        MessageBox.Show("向左");
                        GameObject.Cost++;
                         SingleObject.GetObject().T.Dir = Direction.Left;
                         MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToRightFireOne:
                        MessageBox.Show("向右");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Right;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToRightFireTwo:
                        MessageBox.Show("向右");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Right;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToUpFireOne:
                        MessageBox.Show("向上");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Up;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                    case TankAcationType.ChangeToUpFireTwo:
                        MessageBox.Show("向上");
                        GameObject.Cost++;
                        SingleObject.GetObject().T.Dir = Direction.Up;
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("开火");
                        SingleObject.GetObject().T.Fire();
                        MessageBox.Show("向前");
                        SingleObject.GetObject().T.Move();
                        break;
                }
            }
        }
        #endregion
        #region AuotDrawMap
        public void AuotDrawMap(int totalNum)
        {
            bool toDraw= true;
            while(toDraw)
            {
                InitMap();
                //生成坦克
                int tmpx = randomNum.Next() % WidthX;
                int tmpy = randomNum.Next() % HeightY;
                GameObject.StartPoint.X = tmpx;
                GameObject.StartPoint.Y = tmpy;
                GameObject.InitMap[tmpx, tmpy] = 'T';
                //生成星星
                while (GameObject.InitMap[tmpx, tmpy] != 'X')
                {
                    tmpx = randomNum.Next() % WidthX;
                    tmpy = randomNum.Next() % HeightY;
                    if (GameObject.InitMap[tmpx, tmpy] == '#')
                    {
                        GameObject.InitMap[tmpx, tmpy] = 'X';
                        GameObject.EndPoint.X = tmpx;
                        GameObject.EndPoint.Y = tmpy;
                    }
                }

                //生成砖块
                for (int i = 0; i < totalNum; i++)
                {
                    tmpx = randomNum.Next() % WidthX;
                    tmpy = randomNum.Next() % HeightY;
                    if (GameObject.InitMap[tmpx, tmpy] == '#')
                    {
                        GameObject.InitMap[tmpx, tmpy] = 'B';
                        GameObject.InitIsVisit[tmpx, tmpy] = false;
                    }
                }
                //生成河水
                for (int i = 0; i < totalNum; i++)
                {
                    tmpx = randomNum.Next() %  WidthX;
                    tmpy = randomNum.Next() % HeightY;
                    if (GameObject.InitMap[tmpx, tmpy] == '#')
                    {
                        GameObject.InitMap[tmpx, tmpy] = 'R';
                        GameObject.InitIsVisit[tmpx, tmpy] = false;
                    }
                }

                //生成钢墙
                for (int i = 0; i < totalNum; i++)
                {
                    tmpx = randomNum.Next() % WidthX;
                    tmpy = randomNum.Next() % HeightY;
                    if (GameObject.InitMap[tmpx, tmpy] == '#')
                    {
                        GameObject.InitMap[tmpx, tmpy] = 'S';
                        GameObject.InitIsVisit[tmpx, tmpy] = false;
                    }
                }
                if (RunTest())
                {
                    InitGame();
                    toDraw = false;
                }
            }
           
        }
        #endregion
        /// <summary>
        /// 重新开始新游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameMenu_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        /// <summary>
        /// 捕捉鼠标位置 并显示在窗体上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text="当前鼠标坐标: "+(e.X/GridWidth).ToString()+","+((e.Y-Tank.LeftUpY)/GridWidth).ToString();
            //label3.Text = "当前鼠标坐标: " + (e.X).ToString() + "," + (e.Y).ToString();
        }

        private void CutPic_Click(object sender, EventArgs e)
        {
            //允许绘制
            isCutDraw = true; 
            Graphics g = Graphics.FromImage(CatchBmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width,
                Screen.AllScreens[0].Bounds.Width));
            cutter.Width = CatchBmp.Width;
            cutter.Height = CatchBmp.Height;
            cutter.BackgroundImage = CatchBmp;
            cutter.Visible = true;
        }
        private void 自动生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapDrawMode = MapDrawMode.Auto;
            AuotDrawMap(20);
        }

        private void ManualMapMenu_Click(object sender, EventArgs e)
        {
            mapDrawMode = MapDrawMode.Manual;
        }

        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void 游戏说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Introduction introductionForm = new Introduction();
            Image image = Resources.游戏操作说明;
            introductionForm.Width = image.Width + 10;
            introductionForm.Height = image.Height + 35;
            introductionForm.BackgroundImage = image;
            introductionForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
     
            introductionForm.ShowDialog();
        }
    }
    
}
