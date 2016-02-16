using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSTseverTools
{
    public partial class prompt : Form
    {
        public prompt()
        {
            InitializeComponent();
        }
        public string title="输入框";
        public string tips = "请输入";
        public string retxt;
        private void prompt_Load(object sender, EventArgs e)
        {
            this.Text = title;
            label1.Text = tips;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt =textBox1.Text;
            if (txt.Length > 0)
            {
                retxt = txt;
                DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("请输入内容");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
