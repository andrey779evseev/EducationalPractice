using System;
using System.Windows.Forms;
using Common;

namespace Day14._04._2022
{
    public partial class Form1 : Form
    {
        private const string Path = @"../../../../Day14.04.2022/data.json";
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Helper.ReadFromJson<Data>(Path);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var day = int.Parse(textBox1.Text);
            var month = int.Parse(textBox2.Text);
            var year = int.Parse(textBox3.Text);
            var arr = Helper.ReadFromJson<Data>(Path);
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                var data = new Data(year, month, day);
                arr.Add(data);
            }
            else
            {
                var index = arr.FindIndex(x => x.Id == Guid.Parse(textBox4.Text));
                arr[index].Day = day;
                arr[index].Month = month;
                arr[index].Year = year;
                textBox4.Clear();
            }
            Helper.RewriteToJson(Path, arr);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.DataSource = arr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var items = Helper.ReadFromJson<Data>(Path);
            var item = items.Find(x => x.Id == Guid.Parse(textBox4.Text));
            textBox1.Text = item.Day.ToString();
            textBox2.Text = item.Month.ToString();
            textBox3.Text = item.Year.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var items = Helper.ReadFromJson<Data>(Path);
            var item = items.Find(x => x.Id == Guid.Parse(textBox4.Text));
            items.Remove(item);
            Helper.RewriteToJson(Path, items);
            dataGridView1.DataSource = items;
            textBox4.Clear();
        }
    }
}
