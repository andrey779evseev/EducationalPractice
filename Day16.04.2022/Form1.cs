using System;
using System.Windows.Forms;
using Common;
using Day14._04._2022;

namespace Day16._04._2022
{
    public partial class Form1 : Form
    {
        private const string Path = @"../../../../Day15.04.2022/data.json";
        public int? rowIndex { get; set; }
        public DateTime endTime { get; set; }
        public Timer timer { get; set; }
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Helper.ReadFromJson<Data>(Path);
            timer = new Timer();
            endTime = new DateTime(2022, 4, 18, 13, 0, 0);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var timeSpan = endTime - DateTime.Now;
            label1.Text = $"Today's date time: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} WeekDay: {DateTime.Now.DayOfWeek}";
            label2.Text = "Time left: " + timeSpan.ToString(@"dd\:hh\:mm\:ss");
            if (timeSpan.TotalSeconds <= 0)
            {
                timer.Stop();
                label2.Text = "Time is up!";
            }
        }

        private void delereRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rowIndex != null && !this.dataGridView1.Rows[(int)rowIndex].IsNewRow)
            {
                var id = dataGridView1.Rows[(int)rowIndex].Cells[0].Value;
                var items = Helper.ReadFromJson<Data>(Path);
                items.Remove(items.Find(x => x.Id == Guid.Parse(id.ToString())));
                dataGridView1.DataSource = items;
                Helper.AddToJson(Path, items);
                rowIndex = null;
                contextMenuStrip1.Hide();
            }
        }

        private void cell_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var detail = new Form2();
            var id = dataGridView1.Rows[(int)rowIndex].Cells[0].Value;
            var item = Helper.ReadFromJson<Data>(Path).Find(x => x.Id == Guid.Parse(id.ToString()));
            detail.Init(item);
            detail.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var save = new Form3();
            var id = dataGridView1.Rows[(int)rowIndex].Cells[0].Value;
            var item = Helper.ReadFromJson<Data>(Path).Find(x => x.Id == Guid.Parse(id.ToString()));
            save.Init(item);
            save.ShowDialog();
            dataGridView1.DataSource = Helper.ReadFromJson<Data>(Path);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var save = new Form3();
            save.ShowDialog();
            dataGridView1.DataSource = Helper.ReadFromJson<Data>(Path);
        }
    }
}
