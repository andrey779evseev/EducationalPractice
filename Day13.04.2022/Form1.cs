using System;
using System.Windows.Forms;
using Day05._04._2022;

namespace Day13._04._2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Data? data { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            var inp = textBox1.Text.Split("/");
            var day = Convert.ToInt32(inp[0]);
            var month = Convert.ToInt32(inp[1]);
            var year = Convert.ToInt32(inp[2]);

            this.data = new Data(year, month, day);
            var now = new Data();
            label2.Text = now.ToString();
            label4.Text = this.data.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.AddMonths(Convert.ToInt32(textBox2.Text));
            label8.Text = data.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.AddYears(Convert.ToInt32(textBox3.Text));
            label9.Text = data.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data.AddDays(Convert.ToInt32(textBox4.Text));
            label10.Text = data.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label2.Text = "";
            label4.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
        }
    }
}
