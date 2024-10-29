using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SnowModManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string Category { get; set; }
        public string Desc { get; set; }

        public DialogResult ShowWithData(string category, string desc) {
            comboBox1.Enabled = false;
            textBox1.Enabled = true;
            comboBox1.Text = category;
            textBox1.Text = desc;
            return ShowDialog();
        }
        public DialogResult ShowForAdd()
        {
            comboBox1.Enabled = true;
            textBox1.Enabled = false;
            return ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Category = comboBox1.Text.Trim();
            Desc = textBox1.Text.Trim();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
