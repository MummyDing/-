namespace DS课设_坦克大战最短路_
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NewGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TankMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BrickMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SteelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RiverMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.StarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoModelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualModelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EnergyCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameMenu,
            this.DrawMenu,
            this.ModelMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(720, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NewGameMenu
            // 
            this.NewGameMenu.Name = "NewGameMenu";
            this.NewGameMenu.Size = new System.Drawing.Size(56, 21);
            this.NewGameMenu.Text = "新游戏";
            this.NewGameMenu.Click += new System.EventHandler(this.NewGameMenu_Click);
            // 
            // DrawMenu
            // 
            this.DrawMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TankMenu,
            this.BrickMenu,
            this.SteelMenu,
            this.RiverMenu,
            this.StarMenu});
            this.DrawMenu.Name = "DrawMenu";
            this.DrawMenu.Size = new System.Drawing.Size(44, 21);
            this.DrawMenu.Text = "绘制";
            // 
            // TankMenu
            // 
            this.TankMenu.Name = "TankMenu";
            this.TankMenu.Size = new System.Drawing.Size(100, 22);
            this.TankMenu.Text = "坦克";
            this.TankMenu.Click += new System.EventHandler(this.TankMenu_Click);
            // 
            // BrickMenu
            // 
            this.BrickMenu.Name = "BrickMenu";
            this.BrickMenu.Size = new System.Drawing.Size(100, 22);
            this.BrickMenu.Text = "砖块";
            this.BrickMenu.Click += new System.EventHandler(this.BrickMenu_Click);
            // 
            // SteelMenu
            // 
            this.SteelMenu.Name = "SteelMenu";
            this.SteelMenu.Size = new System.Drawing.Size(100, 22);
            this.SteelMenu.Text = "钢墙";
            this.SteelMenu.Click += new System.EventHandler(this.SteelMenu_Click);
            // 
            // RiverMenu
            // 
            this.RiverMenu.Name = "RiverMenu";
            this.RiverMenu.Size = new System.Drawing.Size(100, 22);
            this.RiverMenu.Text = "河水";
            this.RiverMenu.Click += new System.EventHandler(this.RiverMenu_Click);
            // 
            // StarMenu
            // 
            this.StarMenu.Name = "StarMenu";
            this.StarMenu.Size = new System.Drawing.Size(100, 22);
            this.StarMenu.Text = "星星";
            this.StarMenu.Click += new System.EventHandler(this.StarMenu_Click);
            // 
            // ModelMenu
            // 
            this.ModelMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoModelMenu,
            this.ManualModelMenu});
            this.ModelMenu.Name = "ModelMenu";
            this.ModelMenu.Size = new System.Drawing.Size(44, 21);
            this.ModelMenu.Text = "模式";
            // 
            // AutoModelMenu
            // 
            this.AutoModelMenu.Name = "AutoModelMenu";
            this.AutoModelMenu.Size = new System.Drawing.Size(100, 22);
            this.AutoModelMenu.Text = "自动";
            this.AutoModelMenu.Click += new System.EventHandler(this.AutoModelMenu_Click);
            // 
            // ManualModelMenu
            // 
            this.ManualModelMenu.Name = "ManualModelMenu";
            this.ManualModelMenu.Size = new System.Drawing.Size(100, 22);
            this.ManualModelMenu.Text = "手动";
            this.ManualModelMenu.Click += new System.EventHandler(this.ManualModelMenu_Click);
            // 
            // EnergyCost
            // 
            this.EnergyCost.Enabled = false;
            this.EnergyCost.Location = new System.Drawing.Point(572, 0);
            this.EnergyCost.Name = "EnergyCost";
            this.EnergyCost.Size = new System.Drawing.Size(72, 23);
            this.EnergyCost.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(480, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前能量消耗:";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(184, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前坦克坐标:";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(333, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前鼠标坐标:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(720, 678);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnergyCost);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "坦克大战最短路";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DrawMenu;
        private System.Windows.Forms.ToolStripMenuItem TankMenu;
        private System.Windows.Forms.ToolStripMenuItem BrickMenu;
        private System.Windows.Forms.ToolStripMenuItem SteelMenu;
        private System.Windows.Forms.ToolStripMenuItem RiverMenu;
        private System.Windows.Forms.ToolStripMenuItem StarMenu;
        private System.Windows.Forms.ToolStripMenuItem ModelMenu;
        private System.Windows.Forms.ToolStripMenuItem AutoModelMenu;
        private System.Windows.Forms.ToolStripMenuItem ManualModelMenu;
        private System.Windows.Forms.TextBox EnergyCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem NewGameMenu;
        private System.Windows.Forms.Label label3;
    }
}

