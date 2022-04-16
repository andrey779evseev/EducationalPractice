using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;
using Day14._04._2022;

namespace Day15._04._2022
{
    public partial class Form1 : Form
    {
        private const string Path = @"../../../../Day15.04.2022/data.json";
        public int? rowIndex { get; set; }
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Helper.ReadFromJson<Data>(Path);
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
