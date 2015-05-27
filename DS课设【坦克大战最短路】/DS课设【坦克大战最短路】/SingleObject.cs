using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    class SingleObject
    {
        private SingleObject(){}
        #region 初始化方法
        public static SingleObject _singleObject = null;

        public static SingleObject GetObject()
        {
            if (_singleObject == null)
            {
                _singleObject = new SingleObject();
            }
            return _singleObject;
        }
        #endregion
        #region 属性
        /// <summary>
        /// 坦克
        /// </summary>
        public Tank T
        {
            get;
            set;
        }
        /// <summary>
        /// 星星
        /// </summary>
        public  Star S
        {
            get;
            set;
        }
        #endregion
        #region 定义存储对象变量
        /// <summary>
        /// “砖块”存储集合
        /// </summary>
        public static  List<Brick> listBrick = new List<Brick>();
        /// <summary>
        ///“河水”存储集合
        /// </summary>
        public static List<River> listRiver = new List<River>();
        /// <summary>
        /// “子弹”存储集合
        /// </summary>
        public static List<Bullet> listBullet = new List<Bullet>();
        /// <summary>
        /// “铁墙”存储集合
        /// </summary>
        public static List<Stell> listStell = new List<Stell>();
        /// <summary>
        /// “炸弹”存储集合
        /// </summary>
        public static List<Boom> listBoom = new List<Boom>();
        #endregion
        #region 添加删除游戏对象的方法
        /// <summary>
        /// 添加游戏对象
        /// </summary>
        /// <param name="g">游戏对象</param>
        public  void AddGameObject(GameObject g)
        {
            if(g is Tank)
            {
                T = g as Tank;
            }
            else if (g is Brick)
            {
                listBrick.Add(g as Brick);
            }
            else if(g is River)
            {
                listRiver.Add(g as River);
            }
            else if (g is Bullet)
            {
                listBullet.Add(g as Bullet);
            }
            else if (g is Stell)
            {
                listStell.Add(g as Stell);
            }
            else if (g is Boom)
            {
                listBoom.Add(g as Boom);
            }
            else if (g is Star)
            {
                S = g as Star;
            }
        }
        /// <summary>
        /// 删除当前游戏对象
        /// </summary>
        /// <param name="g">游戏对象</param>
        public void RemoveGameObject(GameObject g)
        {
            if (g is Brick)
            {
                listBrick.Remove(g as Brick);
            }
            else if (g is Bullet)
            {
                listBullet.Remove(g as Bullet);
            }
            else if (g is Stell)
            {
                listStell.Remove(g as Stell);
            }
            else if (g is River)
            {
                listRiver.Remove(g as River);
            }
            else if (g is Boom)
            {
                listBoom.Remove(g as Boom);
            }
        }
        #endregion
        #region Draw方法
        public void Draw(Graphics g)
        {
            
            if(T!=null)
            T.Draw(g);
            if (S != null)
             S.Draw(g);
            for (int i = 0; i < listBrick.Count; i++)
            {
                listBrick[i].Draw(g);
            }
            for (int i = 0; i < listRiver.Count; i++)
            {
                listRiver[i].Draw(g);    
            }
            for (int i = 0; i < listBullet.Count; i++)
            {
                listBullet[i].Draw(g);  
            }
            for (int i = 0; i < listStell.Count; i++)
            {
                listStell[i].Draw(g);
            }
            for (int i = 0; i < listBoom.Count; i++)
            {
                listBoom[i].Draw(g);
            }
        }
        #endregion
        /// <summary>
        /// 碰撞检测方法
        /// </summary>
        public void Check()
        {
            #region 子弹打到砖块
            for (int i = 0; i < listBullet.Count; i++)
                for (int j = 0; j < listBrick.Count;j++)
                    if(listBullet[i].Getangle().IntersectsWith(listBrick[j].Getangle()))
                    {
                        listBullet.Remove(listBullet[i]);
                        //播放爆炸声音
                        SoundPlayer sp = new SoundPlayer(Resources.blast);
                        sp.Play();
                        //出现爆炸的图片
                        int tempX = listBrick[j].X / MainForm.GridWidth;
                        int tempY = (listBrick[j].Y -Tank.LeftUpY ) / MainForm.GridWidth;
                        GameObject.IsVisit[tempX,tempY] = true;
                        SingleObject.GetObject().AddGameObject(new Boom(listBrick[j].X, listBrick[j].Y));
                        listBrick.Remove(listBrick[j]);
                        break;
                    }
            #endregion
            #region 子弹打到铁墙
            for (int i = 0; i < listBullet.Count; i++)
                for (int j = 0; j < listStell.Count;j++)
                    if(listBullet[i].Getangle().IntersectsWith(listStell[j].Getangle()))
                    {
                        listStell[j].Life -= listBullet[i].Power;
                        listBullet.Remove(listBullet[i]);
                        if(listStell[j].Life==0)
                        {
                            int tempX = listStell[j].X / MainForm.GridWidth;
                            int tempY = (listStell[j].Y - Tank.LeftUpY) / MainForm.GridWidth;
                            GameObject.IsVisit[tempX, tempY] = true;
                            //播放爆炸声音
                            SoundPlayer sp = new SoundPlayer(Resources.blast);
                            sp.Play();
                            //出现爆炸的图片
                            SingleObject.GetObject().AddGameObject(new Boom(listStell[j].X, listStell[j].Y));
                            listStell.Remove(listStell[j]);
                        }
                        break;
                    }
            #endregion
        }
    }
}
