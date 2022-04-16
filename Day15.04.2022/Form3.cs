using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Day14._04._2022;

namespace Day15._04._2022
{
    public partial class Form3 : Form
    {
        public Guid? Id { get; set; } = null;
        private const string Path = @"../../../../Day15.04.2022/data.json";

        public Form3()
        {
            InitializeComponent();
        }

        public void Init(Data data)
        {
            Id = data.Id;
            textBox1.Text = data.Day.ToString();
            textBox2.Text = data.Month.ToString();
            textBox3.Text = data.Year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var day = Convert.ToInt32(textBox1.Text);
            var month = Convert.ToInt32(textBox2.Text);
            var year = Convert.ToInt32(textBox3.Text);            
            if (Id == null)
            {
                Helper.AddToJson(Path, new Data(year, month, day));
            } 
            else
            {
                var items = Helper.ReadFromJson<Data>(Path);
                var index = items.FindIndex(x => x.Id == Id);
                items[index].Year = year;
                items[index].Month = month;
                items[index].Day = day;
                Helper.RewriteToJson(Path, items);
                this.Close();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
