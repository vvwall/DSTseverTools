using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DSTseverTools
{
    public partial class addSeverPath : Form
    {
        public addSeverPath()
        {
            InitializeComponent();
        }
        public String pathname = "";
        private void button1_Click(object sender, EventArgs e)
        {
            String txt =textBox1.Text;
            if (txt.Length > 0)
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = path + @"\Klei\DSTTools\";
                DirectoryInfo newc;
                string[] a = Directory.GetDirectories(path);
                int len= a.Length+1;
                do
                {
                    string paname = "Cluster_";
                    if (Directory.Exists(path + paname + len.ToString()))
                    {
                        len++;
                    }
                    else {
                      newc=  Directory.CreateDirectory(path + paname + len.ToString());
                      StreamWriter sw = new StreamWriter(path + paname + len.ToString()+ @"\intro.txt", true, Encoding.UTF8);
                      Directory.CreateDirectory(path + paname + len.ToString() + @"\Master\");
                      Directory.CreateDirectory(path + paname + len.ToString() + @"\Slave\");
                      sw.Write(txt);
                      sw.Close();
                        break;
                    }
                } while (true);
                MessageBox.Show("已经创建新的存档 : " + newc.Name,"提示");
                pathname =newc.Name;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("请输入内容", "提示");
            }
        }
    }
}
