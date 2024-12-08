using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEEK04_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            int x =  this.ClientSize.Width - button1.Width;
            int y = this.ClientSize.Height - button1.Height;

            button1.Location = new Point(rnd.Next(x), rnd.Next(y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            int x = this.ClientSize.Width - button1.Width;
            int y = this.ClientSize.Height - button1.Height;

            button1.Location = new Point(rnd.Next(x), rnd.Next(y));
        }
    }
}
