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
    public partial class consoleform : Form
    {
        public string ctxt="";
        public consoleform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                ctxt += "-offline ";
            }
            if (checkBox2.Checked) {
                ctxt += "-console ";
            }
            this.ctxt += textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.baidu.com"); 
        }
    }
}
