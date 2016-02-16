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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }
       public string timeq="";
       public string des ="";
       public string url ="";
       public string titletxt = "有新版本了~(*^__^*)快来看看啊~";
       public string must = "";
       public string gg = "";
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(url); 
        }

        private void update_Load(object sender, EventArgs e)
        {
 
            if (timeq == "" || des == "" || url == "")
            {
              //  DialogResult = DialogResult.OK;
            }
            else {
                title.Text = titletxt;
                title.ForeColor = Color.Red;  
                desbox.Text = des;
                time.Text = timeq;
                if (gg != "true") {
                    button1.Visible = true;

                }

                
            }
        }

        private void update_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (must == "true")
            {
                DialogResult = DialogResult.OK;
            }
    
        }
    }
}
