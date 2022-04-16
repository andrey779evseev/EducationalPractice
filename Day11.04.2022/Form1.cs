using System;
using System.IO;
using System.Windows.Forms;

namespace Day11._04._2022
{
    public partial class Form1 : Form
    {
        static int Ans { get; set; }
        static int N { get; set; }
        static int Inputed { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            N = Convert.ToInt32(textBox1.Text);
            label4.Text = $"You entered 0 vertexes";
        }
        static int Gcd(int a, int b)
        {
            while (b > 0)
                (a, b) = (b, a % b);
            return a;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Text = $"Count of points inside polygon that aren't intersect between each other and borders: {Ans}";
            var text = label5.Text + $"\nN:{N}";
            File.WriteAllText("../../../rect.txt", text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var xfirst = Convert.ToInt32(textBox2.Text);
            var yfirst = Convert.ToInt32(textBox3.Text);
            var xprev = xfirst;
            var yprev = yfirst;
            for (var i = 0; i < N - 1; i++)
            {
                var x = Convert.ToInt32(Console.ReadLine());
                var y = Convert.ToInt32(Console.ReadLine());
                Ans += Gcd(Math.Abs(x - xprev), Math.Abs(y - yprev));
                (xprev, yprev) = (x, y);
                Ans += Gcd(Math.Abs(x - xfirst), Math.Abs(y - yfirst));
            }
            textBox2.Clear();
            textBox3.Clear();
            Inputed++;
            label4.Text = $"You entered {Inputed} vertexes";
            if (Inputed == N)
            {
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = File.ReadAllText("../../../rect.txt");
            var n = text.Split("N:")[1];
            label4.Text = $"You entered {n} vertexes";
            textBox1.Text = n;
            label5.Text = text.Split("N:")[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            textBox1.Text = "";
            label5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
