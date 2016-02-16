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
    public partial class SelectSavePath : Form
    {
        public SelectSavePath()
        {
            InitializeComponent();
        }

        public String pathret="";
        public String checkfile = @"\cluster.ini";
        private Boolean dialogcheck = false;
        private void SelectSavePath_Load(object sender, EventArgs e)
        {
           
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = path + @"\Klei\DSTTools\";
           string[] a = Directory.GetDirectories(path);
           comboBox1.Items.Clear();
            foreach(string i in a){
                string temp = i.Replace(Directory.GetParent(i).ToString()+"\\", "");
                if (File.Exists(i + @"\intro.txt"))
                {
                    String intro = File.ReadAllText(i + @"\intro.txt",Encoding.UTF8);
                    temp = temp + "@[" + intro + "]";
                }
                else {
                    temp = temp + "@[无描述文件]";
                }
                comboBox1.Items.Add(temp);   
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = path + @"\Klei\DSTTools\";
            string[] a = Directory.GetDirectories(path);
            foreach (string i in a)
            {
                string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                if (File.Exists(i + @"\intro.txt"))
                {
                    String intro = File.ReadAllText(i + @"\intro.txt", Encoding.UTF8);
                    temp = temp + "@[" + intro + "]";
                }
                else
                {
                    temp = temp + "@[无描述文件]";
                }
                if (comboBox1.SelectedItem.ToString() == temp) {
                    pathret = i;
                    label3.Text = temp;
                    if (checkfile != "")
                    {
                        if (File.Exists(i + checkfile))
                        {
                            dialogcheck = true;
                            label3.Text = temp + "  【检测到该存档有原来的文件，将覆盖原有的文件】";
                            this.Text = "选择要保存的存档-【检测到该存档有原来的文件，将覆盖原有的文件】";
                        }
                        else
                        {
                            if (!Directory.Exists(i + @"\Slave\"))
                            {
                                Directory.CreateDirectory(i + @"\Slave\");
                            }
                            if (!Directory.Exists(i + @"\Master\"))
                            {
                                Directory.CreateDirectory(i + @"\Master\");
                            }
                          
                            this.Text = "选择要保存的存档";
                            dialogcheck = false;
                        }
                    }
                    else {
                        dialogcheck = false;
                    }
                    break;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem==null) {
                MessageBox.Show("请选择存档~");
                return;
            }
            if (dialogcheck)
            {
                if (MessageBox.Show(" 该操作将覆盖掉原来的文件你确定？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("你放弃了操作，请把文件复制到一边或者保存到新的存档文件夹");
                }
            }
            else {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addSeverPath addsp = new addSeverPath();
       
            if (addsp.ShowDialog() == DialogResult.OK)
            {

                //刷新combox
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = path + @"\Klei\DSTTools\";
                string[] a = Directory.GetDirectories(path);
                comboBox1.Items.Clear();
                foreach (string i in a)
                {
                    string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                    if (File.Exists(i + @"\intro.txt"))
                    {
                        String intro = File.ReadAllText(i + @"\intro.txt", Encoding.UTF8);
                        temp = temp + "@[" + intro + "]";
                    }
                    else
                    {
                        temp = temp + "@[无描述文件]";
                    }
                    comboBox1.Items.Add(temp);
                }

            }
     
        }
    }
}
