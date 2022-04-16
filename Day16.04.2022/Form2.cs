using System;
using System.IO;
using System.Windows.Forms;
using Day14._04._2022;
using Newtonsoft.Json;

namespace Day16._04._2022
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Init(Data data)
        {
            label8.Text = data.Id.ToString();
            label7.Text = data.Day.ToString();
            label6.Text = data.Month.ToString();
            label5.Text = data.Year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Json File|*.json";
            saveFileDialog1.Title = "Save an Date to file";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var data = new Data() {
                    Id = Guid.Parse(label8.Text),
                    Day = int.Parse(label7.Text),
                    Month = int.Parse(label6.Text),
                    Year = int.Parse(label5.Text)
                };
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(data));
            }
        }
    }
}
