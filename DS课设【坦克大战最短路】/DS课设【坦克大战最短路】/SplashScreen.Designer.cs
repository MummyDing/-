using System.Media;
using DS课设_坦克大战最短路_.Properties;
namespace DS课设_坦克大战最短路_
{
    partial class SplashScreen
    {
        public static SoundPlayer Music1 =new SoundPlayer(Resources.start);
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "SplashScreen";
            Music1.Play();
        }

        #endregion
    }
}