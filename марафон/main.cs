using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace марафон
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("8.04.2020 6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " +
            time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            more mr = new more();
            mr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkrun ch = new checkrun();
            ch.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sponsor sp = new sponsor();
            sp.Show();
            this.Hide();
        }
    }
}
