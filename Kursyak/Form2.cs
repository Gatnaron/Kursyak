using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursyak
{
    public partial class Form2 : Form
    {
        public Form1 form;
        public Form2(Form1 form_)
        {
            InitializeComponent();
            form = form_;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.weight1 = (int)numericUpDown1.Value;
            this.Close();
        }
    }
}
