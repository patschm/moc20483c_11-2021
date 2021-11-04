using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RekenMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string sA = txtA.Text;
            string sB = txtB.Text;
            int.TryParse(sA, out int a);
            int.TryParse(sB, out int b);

            //int result = LongAdd(a, b);
            //UpdateLabel(result);

            //SynchronizationContext ctx = SynchronizationContext.Current;
            //Task.Run(() => LongAdd(a, b))
            //    .ContinueWith(pt => ctx.Post(UpdateLabel, pt.Result));

            int result = await LongAddAsync(a, b);// Niet doen .ConfigureAwait(false);
            UpdateLabel(result);
        }

        private void UpdateLabel(object result)
        {
            lblAnswer.Text = result.ToString();
        }

        private int LongAdd(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<int> LongAddAsync(int a, int b)
        {
            return Task.Run(() => LongAdd(a, b));
        }
    }
}
