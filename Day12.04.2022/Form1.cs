using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Day12._04._2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double Calc(double x)
        {
            return (2 * Math.Cos(x - Math.PI / 6)) / (1 / 2 + Math.Pow(Math.Sin(1 + Math.Pow(x, 2) / 3), 2));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Add(new ChartArea("area"));
            chart1.Dock = DockStyle.Fill;
            Series fn = new Series("fn");
            fn.ChartArea = "area";
            fn.ChartType = SeriesChartType.Line;
            var from = Convert.ToDouble(textBox1.Text);
            var to = Convert.ToDouble(textBox2.Text);
            var step = Convert.ToDouble(textBox3.Text);
            for (double x = from; x <= to; x += step)
                fn.Points.AddXY(x, Calc(x));
            chart1.Series.Add(fn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK) UpdateFont(dialog);
        }
        private void UpdateFont(FontDialog dialog)
        {
            label1.Font = dialog.Font;
            label2.Font = dialog.Font;
            label3.Font = dialog.Font;
            chart1.Font = dialog.Font;
            textBox1.Font = dialog.Font;
            textBox2.Font = dialog.Font;
            textBox3.Font = dialog.Font;
            button1.Font = dialog.Font;
            button2.Font = dialog.Font;
        }
    }
}
