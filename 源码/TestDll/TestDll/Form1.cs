using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace TestDll
{
    public partial class Form1 : Form
    {
        [DllImport("CppDll.dll", SetLastError = true)]
        private static extern int bfs( string Map);
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str="YBEBEERESSTE";
            int m =3;
            int n =4;
            char[,] chess=new char[305,305];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                       chess[i,j]=str[i*n+j];
                }
            } 
            int sum = bfs(str);
            textBox1.Text=Convert.ToString(sum);
        }
    }
}
