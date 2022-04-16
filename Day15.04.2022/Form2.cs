using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Day14._04._2022;

namespace Day15._04._2022
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
    }
}
