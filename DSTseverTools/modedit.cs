using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DSTseverTools
{
    public partial class modedit : Form
    {
        string modurl = "http://t.vvwall.com/DST/modinfo.php";
        string moddl = "";
        string modid = "";
        string gamepath = "";
        public string cpath = "";
        UTF8Encoding utf8 = new UTF8Encoding(false);
        public modedit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            button1.Text = "加载中";
            button1.Enabled = false;
            textBox1.Enabled = false;
            if (textBox1.Text == "")
            {
                MessageBox.Show("请填写mod编号");
                button1.Enabled = true;
                textBox1.Enabled = true;
                button1.Text = "添加";
            }
            else {
             string sub = "mid="+textBox1.Text;
             
             http tp = new http();
              string back= tp.HttpPost(modurl,sub);
             
                  var jObject = JObject.Parse(back);
                  if(jObject["code"].ToString()=="200"){

                   ListViewItem lvi = new ListViewItem();
                   
                  lvi.Text = jObject["mid"].ToString();

                  if (checkhas(lvi.Text)) {
                      MessageBox.Show("已经添加了【"+lvi.Text+"】这个mod");
                      button1.Enabled = true;
                      textBox1.Enabled = true;
                      button1.Text = "添加";
                      return;//中断
                  }
                  modid = lvi.Text;
                  if (jObject["title"] != null)
                  {
                      lvi.SubItems.Add(jObject["title"].ToString());
                    
                      label2.Text = jObject["title"].ToString();
                      if (jObject["des"] != null) {
                          textBox2.Text = jObject["des"].ToString();
                      }
                  }
                  if (jObject["url"] != null) { 
                     moddl =jObject["url"].ToString();
                  }
                  //可下载的
                  xiazai.Visible = true;
                  lvi.Checked = true;
                  listView1.Items.Add(lvi);
                  MessageBox.Show("添加成功");
                  button5.Visible = true;
                  button4.Visible = true;
                  }else{
                      if (jObject["code"].ToString() == "404")
                      {
                          MessageBox.Show("部分功能不能使用");
                      }
                      else {
                          MessageBox.Show("未找到该mod");
                      }
                
                  }
                  button1.Enabled = true;
                  textBox1.Enabled = true;
                  button1.Text = "添加";
              }
        
         }
     

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
            textBox2.Text = "";
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("你真的要删除吗？","提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                //点确定的代码
                    foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历
                    {
                        listView1.Items.RemoveAt(lvi.Index); // 按索引移除
                        //listView1.Items.Remove(lvi);   //按项移除
                    }   
                 MessageBox.Show("已删除");
                }
                else
                { //点取消的代码 


                }
        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历
            {
                string sub = "mid=" +lvi.Text;

                http tp = new http();
                string back = tp.HttpPost(modurl, sub);

                var jObject = JObject.Parse(back);
                if (jObject["code"].ToString() == "200")
                {
                    if (jObject["title"] != null)
                    {

                        label2.Text = jObject["title"].ToString();
                        if (jObject["des"] != null)
                        {
                            textBox2.Text = jObject["des"].ToString();
                        }
                    }
                }
            }
        }

        private void 打开目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("仅供提供方便使用\n");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private Boolean checkhas(string a) {

            foreach (ListViewItem i in listView1.Items) {
                if (a == i.Text) {
                    return true;
                }
            
            }
            return false;
        }
        private void noenable() {
            button1.Enabled = false;
            textBox1.Enabled = false;
        }
        private void enable() {
            button1.Enabled = true;
            textBox1.Enabled = true; 
        }

        private void chenckok(string path) {
          //string[] aa = Directory.GetFiles(path);   
           
            if (Directory.Exists(path))
            {
                     
            }
            else { 
            
            }
        }
        private void xiazai_Click(object sender, EventArgs e)
        {
            if (moddl != "") {
                http http = new http();
                noenable();
                xiazai.Enabled = false;
                xiazai.Visible = false;

                http.DownloadFile(moddl,@".\temp\mod\workshop-"+modid+".zip",dlabel);
                xiazai.Enabled = true;
                enable();
                MessageBox.Show("下载成功~");
                string path = @".\temp\mod\";
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }

        private void 生成文件至程序目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StreamWriter sww = new StreamWriter(@"temp\DSTTools\Save_1\Slave\modoverrides.lua", false, utf8);
            StreamWriter sww1 = new StreamWriter(@"temp\DSTTools\Save_1\Master\modoverrides.lua", false, utf8);
            StreamWriter sww2 = new StreamWriter(@"temp\DSTTools\dedicated_server_mods_setup.lua", false, utf8);
            //string str = "--这个文件请放到我的文档\\klei\\DoNotStarveTogether_EasyConfigOverworld和DoNotStarveTogether_EasyConfigCaves目录中\r\nreturn{\r\n <#ss> }";
            sww.WriteLine("return{");
            sww1.WriteLine("return{");
           int cont=0;
            foreach (ListViewItem lvi in listView1.Items)  //选中项遍历
            {
                string str2 = "";
                string txt = "";
                if (lvi.Checked) {
                    str2 = "[\"workshop-" + lvi.Text + "\"] = { enabled = true },	-- " + lvi.SubItems[1].Text ;
                    sww.WriteLine(str2);
                    sww1.WriteLine(str2);
                    txt = "ServerModSetup(\"" + lvi.Text + "\")           --" + lvi.SubItems[1].Text;
                    sww2.WriteLine(txt);
                    cont++;
                }
            }
            sww.WriteLine("}");
            sww1.WriteLine("}");
           string txttt = "--由JV工具生成weibo:" + @"http://weibo.com/findlike";
           sww.WriteLine(txttt);
           sww1.WriteLine(txttt);
           sww2.WriteLine(txttt);
            sww.Close();
            sww1.Close();
            sww2.Close();
          //  MessageBox.Show("生成成功本次添加了"+cont.ToString()+"个mod");
            string path = @"temp\DSTTools\";
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void modedit_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"\temp\mod\")) {
                Directory.CreateDirectory(@"\temp\mod\");
            }
        }

        private void 自动部署文件到应该的地方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //选择文件夹
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "选择游戏目录(游戏根目录)";
            if (fb.ShowDialog() == DialogResult.OK)
            {
                gamepath = fb.SelectedPath;

                if (!Directory.Exists(gamepath + @"\mods\"))
                {
                    MessageBox.Show("选择的不是根目录，\n根目录下有mods文件夹你的没有\n请重新选择");
                    gamepath = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("未设置游戏目录不可以-自动生成");
                gamepath = "";
                return;
            }

            StreamWriter sw,sw2,sw1;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           
            if (cpath != "") {
                 sw = new StreamWriter(cpath + @"\Master\modoverrides.lua", false, utf8);
                sw2 = new StreamWriter(gamepath + @"\mods\dedicated_server_mods_setup.lua", false, utf8);
                sw1 = new StreamWriter(cpath + @"\Slave\modoverrides.lua", false, utf8);

            } else {
                SelectSavePath slp = new SelectSavePath();
                slp.checkfile = @"\Master\modoverrides.lua";
               
                    if (slp.ShowDialog() == DialogResult.OK)
                    {
                        path = slp.pathret;
                       
                    }
                    else
                    {
                        MessageBox.Show("请选择目录");
                        return;

                    }
               
                //modoverrides.lua||dedicated_server_mods_setup.lua||ServerModSetup("workshop-365119238") 	-- "SmartCrockPot"
                sw = new StreamWriter(path + @"\Master\modoverrides.lua", false, utf8);
                sw2 = new StreamWriter(gamepath + @"\mods\dedicated_server_mods_setup.lua", false, utf8);
                sw1 = new StreamWriter(path + @"\Slave\modoverrides.lua", false, utf8);
                //  sw.WriteLine("--这个文件请放到我的文档\\klei\\DoNotStarveTogether_EasyConfigOverworld和DoNotStarveTogether_EasyConfigCaves目录中");     
            }
            sw.WriteLine("return{");
            sw1.WriteLine("return{");
            string str2 = "";
            string txt = "";
            int cont = 0;
            foreach (ListViewItem lvi in listView1.Items)  //选中项遍历
            {
                if (lvi.Checked) {
                    str2 = "[\"workshop-" + lvi.Text + "\"] = { enabled = true },	--" + lvi.SubItems[1].Text ;
                    sw.WriteLine(str2);
                    sw1.WriteLine(str2);
                    txt = "ServerModSetup(\"" + lvi.Text + "\")           --" + lvi.SubItems[1].Text;
                    sw2.WriteLine(txt);
                    cont++;
                }
            }
           
            sw.WriteLine("}");
            sw1.WriteLine("}");
              txt = "--由JV工具生成weibo:" + @"http://weibo.com/findlike";
             sw.WriteLine(txt);
             sw1.WriteLine(txt);
             sw2.WriteLine(txt);
            sw.Close(); 
            sw2.Close();
            sw1.Close();
            MessageBox.Show("生成成功本次添加了" + cont.ToString() + "个mod");
     
            System.Diagnostics.Process.Start("explorer.exe", path );
            System.Diagnostics.Process.Start("explorer.exe", gamepath+@"\mods\");
            if (cpath != "")
            {
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "选择游戏目录(游戏根目录)";
            if (fb.ShowDialog() == DialogResult.OK)
            {
                gamepath = fb.SelectedPath;

                if (!Directory.Exists(gamepath + @"\mods\"))
                {
                    MessageBox.Show("选择的不是根目录，\n根目录下有mods|bin等文件夹\n你的选择的没有\n请重新选择");
                    gamepath = "";
                    return;
                }
                else {
                    this.Text = "Mod管理--[游戏目录：" + gamepath + "]";
                }
            }
            else
            {
                MessageBox.Show("未设置游戏目录不可以-自动生成");
                gamepath = "";
                return;
            }
        }

        private void 生成到临时目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gamepath == "")
            {
                if (!sldir())
                {
                    return;
                }
             
            }
            String[] t = Directory.GetDirectories(gamepath + @"\mods\");
            creatmods(t, true);
        }
        private void creatmods(string[] t,Boolean o) {


            string str = "--由JV工具生成-\r\n--WeiBo:" + @"http://weibo.com/findlike" + " \r\n return{\r\n <#ss> }";
            string str2 = "";
            string txt = "--由JV工具生成-\r\n--WeiBo:" + @"http://weibo.com/findlike" + " \r\n";
            foreach (string i in t)
            {
                
                string tt = i.Replace(gamepath+@"\mods\","");
                str2 += "[\"" + tt + "\"] = { enabled = true },  \r\n";
                string temp = tt.Replace("workshop-","");
                txt += "ServerModSetup(\"" + temp + "\")  \r\n";
            }
            str = str.Replace("<#ss>", str2);
            //true 表示生成到临时的
            if (o)
            {
                //modoverrides.lua||dedicated_server_mods_setup.lua||ServerModSetup("workshop-365119238") 	-- "SmartCrockPot"
                StreamWriter sw = new StreamWriter(@".\temp\mod\modoverrides.lua", false, utf8);
                sw.Write(str);
                sw.Close();
                StreamWriter sw2 = new StreamWriter(@".\temp\mod\dedicated_server_mods_setup.lua", false, utf8);
                sw2.Write(txt);
                sw2.Close();
                MessageBox.Show("生成成功");
                string path = @".\temp\mod\";
                System.Diagnostics.Process.Start("explorer.exe", path);
            }               
            else {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //modoverrides.lua||dedicated_server_mods_setup.lua||ServerModSetup("workshop-365119238") 	-- "SmartCrockPot"
                StreamWriter sw = new StreamWriter(path + @"\Klei\DSTTools\Cluster_1\Master\modoverrides.lua", false, utf8);
                sw.Write(str);
                sw.Close();
                sw = new StreamWriter(path + @"\Klei\DSTTools\Cluster_1\Slave\modoverrides.lua", false, utf8);
                sw.Write(str);
                sw.Close();
                StreamWriter sw2 = new StreamWriter(gamepath + @"\mods\dedicated_server_mods_setup.lua", false, utf8);
                sw2.Write(txt);
                sw2.Close();
                MessageBox.Show("生成成功请查看目录");
                System.Diagnostics.Process.Start("explorer.exe", path + @"\Klei\DSTTools\");
                System.Diagnostics.Process.Start("explorer.exe", gamepath + @"\mods\");
            }
        }

        private Boolean sldir() {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "选择游戏目录(游戏根目录)";
            if (fb.ShowDialog() == DialogResult.OK)
            {
                gamepath = fb.SelectedPath;

                if (!Directory.Exists(gamepath + @"\mods\"))
                {
                    MessageBox.Show("选择的不是根目录，\n根目录下有mods|bin等文件夹\n你的选择的没有\n请重新选择");
                    gamepath = "";
                    return false;
                }
                else
                {
                    this.Text = "Mod管理--[游戏目录：" + gamepath+"]";
                    return true;
                }
            }
            else
            {
                MessageBox.Show("未设置游戏目录不可以-自动生成");
                gamepath = "";
                return false;
            }
        }


        private string loadmodinfo(string input) {
            string[] results = input.Split('\r', '\n');
            return results[0];
        }


        private void 生成到游戏目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gamepath == "")
            {
                if (!sldir()) {
                    gamepath = "";
                 return;
                }
               
            }
            String[] t = Directory.GetDirectories(gamepath + @"\mods\");
            creatmods(t, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gamepath == "") {
                if (!sldir())
                {
                    gamepath = "";
                    return;
                }
            }
            String[] t = Directory.GetDirectories(gamepath + @"\mods\");
            MessageBox.Show("请勾选你要启用的mod~！");
             foreach (string i in t) {
                
                    ListViewItem aa =new ListViewItem();   
                    string tt = i.Replace(gamepath + @"\mods\", "");
                    string temp = tt.Replace("workshop-", "");
                    aa.Text = temp;
                    StreamReader sr = new StreamReader(i + @"\modinfo.lua");
                    string txt= sr.ReadToEnd();
                    sr.Close();
                   string[] input= txt.Split('\n');
                   foreach (string v in input) {
                       if (v.StartsWith("name"))
                       {
                           aa.SubItems.Add(v.Substring(6));
                           break;
                       }
                   }
                   
                    listView1.Items.Add(aa);
                }

             if (listView1.Items.Count != 0) {
                 button5.Visible = true;
                 button4.Visible = true;
             
             }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





    }
}
