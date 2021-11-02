using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        partial void ExtraInit()
        {
            button1.Click += (o, a) => this.BackColor = Color.Green;
        }
        public Form1()
        {
            InitializeComponent();
        }

    }
}
