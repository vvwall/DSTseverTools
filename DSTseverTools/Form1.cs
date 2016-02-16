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
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;


namespace DSTseverTools
{

    public partial class Form1 : Form
    {
        private string version = "8000";
        private string consoletxt = "-console ";
        private string Setexe ="";//服务端程序
        private string config = "setting.ini";//配置文件
        string locpath = "";
        string token =  "";
        private Process pro;
        public Form1()
        {
            InitializeComponent();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看帮主ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about aboutform = new about();
            aboutform.ShowDialog();
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 绑定启动器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blindexe();
        }
        private void blindexe() {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "饥荒服务端|dontstarve_dedicated_server_nullrenderer.exe|EXE|*.exe";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Setexe = op.FileName;//文件路径
                this.Text += " [已选择]";
                conbox.AppendText("\n[设置文件]" + Setexe + "\n");
                string temp = rconfig();
                JObject json = JObject.Parse(temp);
                json["path"] = Setexe;

                string vp = Path.GetDirectoryName(Setexe);

                vp = vp.Substring(0, vp.Length - 4);
                conbox.AppendText(vp);
                if (File.Exists(vp + @"\version.txt"))
                {

                    StreamReader rf = File.OpenText(vp + @"\version.txt");
                    string txt = rf.ReadToEnd();

                    rf.Close();
                    json["version"] = txt;
                    versionlable.Text = "V" + txt;
                }
                temp = json.ToString();
                wconfig(temp);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           locpath= this.GetType().Assembly.Location;
            if (File.Exists(config)){
                StreamReader rf= File.OpenText(config);
                 string txt= rf.ReadToEnd();
                 if (txt.Length > 0)
                 {
                     var jObject = JObject.Parse(txt);
                    
                     Setexe = jObject["path"].ToString();
                     if (Setexe != "")
                     {
                         this.Text += " [已选择]";
                         conbox.AppendText("\n[设置文件]" + Setexe + "\n");
                     }
                     if (jObject["version"].ToString() != "")
                     {
                         versionlable.Text = "V" + jObject["version"].ToString();
                     }
                     if (jObject["console"].ToString() != "")
                     {

                         consoletxt = jObject["console"].ToString();
                     }
                     if (jObject["token"].ToString() != "")
                     {

                         token = jObject["token"].ToString();
                     }
                 }

                 rf.Close();
            }
            else {
                StreamWriter sw = File.CreateText(config); 
                string str ="{\"path\":\"\",\"console\":\"\",\"version\":12020,\"token\":\"\"}";
                sw.Write(str);
                sw.Close();
            }
            JObject jj = JObject.Parse(rconfig());
            if (jj["token"].ToString() == "")
            {
                if (MessageBox.Show("首次运行，请设置你的token（服务器令牌）\n如果是游侠用户请点击取消", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    settoken();
                }
                else {
                    MessageBox.Show("你没有设置token,如果想设置请点操作->设置token");
                }
                
            }
            if (!Directory.Exists(@".\temp\"))
            { Directory.CreateDirectory(@".\temp\"); }

            if (!Directory.Exists(@".\temp\DSTTools\"))
            {
                Directory.CreateDirectory(@".\temp\DSTTools\");
            }
             string pathaaa = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             if (!Directory.Exists(pathaaa + @"\Klei\DSTTools\"))
             {
                 Directory.CreateDirectory(pathaaa + @"\Klei\DSTTools\");            
            }

             string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = path + @"\Klei\DSTTools\";
            string[] a = Directory.GetDirectories(path);
           
            foreach (string i in a)
            {
                ListViewItem ls = new ListViewItem();
                
                string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                ls.Text = temp;
                string time = Directory.GetCreationTime(i).ToString();
                if (File.Exists(i + @"\intro.txt"))
                {
                    String intro = File.ReadAllText(i + @"\intro.txt", Encoding.UTF8);
                    
                    ls.SubItems.Add(intro);
                    ls.SubItems.Add(time);
                }
                else
                {

                    ls.SubItems.Add("[无描述文件]");
                    ls.SubItems.Add(time);
                }
                listView1.Items.Add(ls);
            }

            //自动检查更新

             timer1.Enabled = true;
        }

        private string rconfig() { 
         StreamReader rf= File.OpenText(config);
                 string txt= rf.ReadToEnd();
                 rf.Close();
                 return txt;

        }
        private void wconfig(string json) {
            StreamWriter sw = File.CreateText(config);     
            sw.Write(json);
            sw.Close();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//退出
        }

        private void 设置启动参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consoleform cf = new consoleform();
            if(cf.ShowDialog()== DialogResult.OK){
                consoletxt=cf.ctxt;
                conbox.AppendText("\n[设置控制命令]" + consoletxt + "\n");
              string temp=  rconfig();
            JObject json = JObject.Parse(temp);

                json["console"] = consoletxt;
                temp =json.ToString();
                wconfig(temp);
            }
        }

        private void 设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //调用函数,
        public void Exe(string filename, string args)
        {
            if (File.Exists(filename))
            {
               Directory.SetCurrentDirectory(Path.GetDirectoryName(filename));//设置当前为档运行路径
               string filename1 = Path.GetFileName(filename);      
                Process cmd = new Process();
                pro = cmd;
                cmd.StartInfo.FileName = filename1;
                cmd.StartInfo.Arguments = args;
                
                cmd.Start();     
                Directory.SetCurrentDirectory(Path.GetDirectoryName(locpath));//设置当前为档运行路径
            }
            else {
                MessageBox.Show("所选文件不存在");
            }

         
        }

        private string creatbat(string path){
            path = Path.GetDirectoryName(path);
            path += @"\run.bat";
            StreamWriter sw = File.CreateText(path);
            string str = "start \"Overworld\" /D \"%~dp0\" \"%~dp0.\\dontstarve_dedicated_server_nullrenderer.exe\" -conf_dir DoNotStarveTogether_EasyConfigOverworld " + consoletxt;
            str += "\n start \"Caves\" /D \"%~dp0\" \"%~dp0.\\dontstarve_dedicated_server_nullrenderer.exe\" -conf_dir DoNotStarveTogether_EasyConfigCaves " + consoletxt;
            sw.Write(str);
            sw.Close();
            return path;
        }
        private void 资源配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting2 st = new Setting2();
            st.ShowDialog();
        }

        private void 服务器设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniform inif = new iniform();
           
            inif.ShowDialog();
        }

        private void mOD配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modedit me = new modedit();
            me.ShowDialog();
        }



        private void 下载modsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modedit me = new modedit();
            me.ShowDialog();
        }


        private void checkup() {
            timer1.Enabled = false;
            update up = new update();       
            http h = new http();
            string bd = h.HttpGet(@"http://t.vvwall.com/DST/version.php", "");
            JObject json = JObject.Parse(bd);
            if (Int32.Parse(version) < Int32.Parse(json["version"].ToString()))
            {
                up.url = json["url"].ToString();
                up.timeq = json["time"].ToString();
                up.des = json["des"].ToString();
                up.titletxt = json["title"].ToString();
                up.must = json["must"].ToString();
                up.gg = json["gg"].ToString();
                if (up.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("你必须更新新版本才能使用");
                    this.Close();
                }
            }
        }
        private void 检查更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           update up = new update();

           http h = new http();
           string bd = h.HttpGet(@"http://t.vvwall.com/DST/version.php", "");
           JObject json = JObject.Parse(bd);

           if (Int32.Parse(version) < Int32.Parse(json["version"].ToString()))
           {
               up.url = json["url"].ToString();
               up.timeq = json["time"].ToString();
               up.des = json["des"].ToString();
               up.titletxt = json["title"].ToString();
               up.must = json["must"].ToString();
               up.gg = json["gg"].ToString();

           }
           if (up.ShowDialog() == DialogResult.OK) {
               MessageBox.Show("你必须更新新版本才能使用");
               this.Close();
           }

        }

        private void 反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2C0LJ6R"); 
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者懒得写了。。。去微博看吧可能有");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string contxt ="";

            string path="";
            MessageBox.Show("选择服务器启动启动文件\ndontstarve_dedicated_server_nullrenderer.exe");
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "饥荒服务端|dontstarve_dedicated_server_nullrenderer.exe|EXE|*.exe";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    path = op.FileName;//文件路径
                    path = Path.GetDirectoryName(path);
                    string path1 = path + @"\run.bat";
                    StreamWriter sw = File.CreateText(path1);
                    string str = "start \"Overworld\" /D \"%~dp0\" \"%~dp0.\\dontstarve_dedicated_server_nullrenderer.exe\" -conf_dir DoNotStarveTogether_EasyConfigOverworld " + consoletxt+" " +contxt;
                    str += "\n start \"Caves\" /D \"%~dp0\" \"%~dp0.\\dontstarve_dedicated_server_nullrenderer.exe\" -conf_dir DoNotStarveTogether_EasyConfigCaves " + consoletxt + " " + contxt;
                    sw.Write(str);
                    sw.Close();
                    MessageBox.Show("生成好了，请认准->【run.bat】");
                    System.Diagnostics.Process.Start("explorer.exe", path);

                }
                else {
                    MessageBox.Show("没能生成文件");
                }
           
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://vvwall.com/2016/01/23/dsttools/"); 
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://vvwall.com/2016/01/23/dsttools/"); 
        }

        private void 下载服务器端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vvwall.com/2016/01/23/dsttools/"); 
        }


        private int timecont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timecont == 1)
            {
                timecont = 0;
                checkup();
            }
            else {

                timecont++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists(@".\DSTGMtools.exe"))
            {
                System.Diagnostics.Process.Start("DSTGMtools.exe","lalalalal");
                this.Close();

            }
            else {
                MessageBox.Show("未发现DSTGMtools.exe");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void settoken() {
            prompt pr = new prompt();
            pr.title = "请输入令牌";
            pr.tips = "启动游戏->开始游戏->右下角[帐户信息]\n打开的页面加载完后拉倒最后复制表格最后一项的那串英文";
            if (pr.ShowDialog() == DialogResult.OK) {
                token = pr.retxt;
               string con= rconfig();
               JObject json = JObject.Parse(con);
               json["token"] = token;
               wconfig(json.ToString());
                MessageBox.Show("设置完成");
            }
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            settoken();
        }

        private void 删除该存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择你要删除的项目");
                    return;
                }
                string slepath = listView1.SelectedItems[0].Text;
                if (slepath != "")
                {
                    if (MessageBox.Show("你真的要删除"+slepath+"这个档吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        path = path + @"\Klei\DSTTools\";
                        string[] a = Directory.GetDirectories(path);
                        foreach (string i in a)
                        {
                            string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                            if (temp == slepath)
                            {
                                Directory.Delete(i, true);
                                MessageBox.Show("删除成功");
                                listView1.SelectedItems[0].Remove();
                            }
                        }
                    }

                }

            }
            catch {

                MessageBox.Show("删除失败");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择你要重置的项目");
                    return;
                }
                string slepath = listView1.SelectedItems[0].Text;
                if (slepath != "")
                {
                    if (MessageBox.Show("你真的要重置" + slepath + "这个档吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        path = path + @"\Klei\DSTTools\";
                        string[] a = Directory.GetDirectories(path);
                        foreach (string i in a)
                        {
                            string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                            if (temp == slepath)
                            {
                                string[] al =Directory.GetDirectories(i);
                                foreach (string t in al) {
                                    if (Directory.Exists(t + @"\save")) {
                                        Directory.Delete(t + @"\save", true);
                                    }
                                }
                                MessageBox.Show("重置完毕~","报告");
                             
                            }
                        }
                    }

                }

            }
            catch
            {

                MessageBox.Show("重置失败");
            }
        }

        private void 恢复世界ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择你要恢复的项目");
                    return;
                }
                string slepath = listView1.SelectedItems[0].Text;
                if (slepath != "")
                {
                    if (MessageBox.Show("你真的要恢复" + slepath + "这个档吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (Setexe == "") {
                            MessageBox.Show("请选择服务器启动程序");
                            blindexe();
                        }
                        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        path = path + @"\Klei\DSTTools\";
                        string[] a = Directory.GetDirectories(path);
                        foreach (string i in a)
                        {
                            string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                            if (temp == slepath)
                            {
                                if (File.Exists(i + @"\offline")) {
                                    consoletxt += " -offline";
                                }
                             string[] ba=   buildags(i).Split('|');
                             for (int k = 0; k < ba.Length - 1; k++)
                             {
                                 string cons = "-cluster " + temp + " -shard "+ba[k]+" -conf_dir DSTTools " + consoletxt;
                                 Exe(Setexe, cons);
                             }


                            }
                        }
                    }

                }

            }
            catch
            {

                MessageBox.Show("恢复失败");
            }
        }

        private string buildags(string i) {
          String[] all=  Directory.GetDirectories(i);
          string b = "";
          foreach (string a in all) {
              string temp = a.Replace(Directory.GetParent(a).ToString() + "\\", "");
              b += temp+"|";
          }
            return b;
        }

        private void 新开存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (Setexe == "")
                {
                    blindexe();
                    
                }
            
          
            SelectSavePath ssp = new SelectSavePath();
            if (ssp.ShowDialog() == DialogResult.OK) {

                MessageBox.Show(ssp.pathret);
                string pt = ssp.pathret;
                MessageBox.Show("第一步：你需要设置服务参数（必选）\n设置后请点击部署到游戏目录", "向导");
                iniform ii=new iniform();
                do
                {
                    ii.cpath = pt;
                    if (ii.ShowDialog() == DialogResult.OK)
                    {
                        break;
                    }
                    else {
                        MessageBox.Show("设置有问题，请重新设置");
                    }
                } while (true);

            //设置mod
                if (MessageBox.Show("第二步，你可以添加你喜欢的mod（可选跳过）\n点击取消跳过设置", "向导", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                    modedit me = new modedit();
                    me.cpath = pt;
                    do {

                        if (me.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("很好，已经完成一半了，马上就能玩了，继续吧");
                            break;
                        }
                        else
                        {

                            if (MessageBox.Show("mod没设置是否继续设置？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                break;
                            }
                        }
                    } while (true);
                
                }
        //设置世界
                if (MessageBox.Show("第三步，最后一步了设置世界（可选跳过）\n点击取消跳过设置", "向导", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Setting2 st = new Setting2();
                    st.cpath = pt;
                    do {
                        if (st.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("很好，已经完成了，马上就能玩了，继续吧");
                            break;
                        }
                        else {
                            if (MessageBox.Show("世界配置没设置是否继续设置？（跳过有可能出问题哦）", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                break;
                            }
                        
                        }
                    
                    } while (true);
                }
        //生成token

                do
                {
                    if (token != "")
                    {
                        UTF8Encoding utf8 = new UTF8Encoding(false);
                        StreamWriter sw = new StreamWriter(pt + @"\cluster_token.txt",false, utf8);
                        sw.Write(token);
                        sw.Close();
                        break;
                    }
                    else
                    {
                        if (MessageBox.Show("请设置token,不然只能以局域网模式启动服务器了\n是否设置？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            settoken();
                        }
                        else {
                            consoletxt += " -offline";
                            StreamWriter sw1 = new StreamWriter( pt + @"\offline", false,Encoding.UTF8);
                            sw1.Write("offline");
                            sw1.Close();
                            break;
                        }
                       
                    }
                } while (true);
            //启动服务器
                ListViewItem lvi = new ListViewItem();
                string temp = pt.Replace(Directory.GetParent(pt).ToString() + "\\", "");
                lvi.Text=temp;           
                lvi.SubItems.Add(File.ReadAllText(pt + @"\intro.txt"));
                lvi.SubItems.Add(Directory.GetCreationTime(pt).ToString());
                listView1.Items.Add(lvi);
                if (MessageBox.Show("是否现在启动？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    string[] ba = buildags(pt).Split('|');
                  for(int k =0;k<ba.Length-1;k++){
                      string cons = "-cluster " + temp + " -shard " + ba[k]+ " -conf_dir DSTTools " + consoletxt;
                      Exe(Setexe, cons);
                  }   

                }
                else {
                    MessageBox.Show("未启动");
                }
        

            }
        }

        private void 刷新列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = path + @"\Klei\DSTTools\";
            string[] a = Directory.GetDirectories(path);

            foreach (string i in a)
            {
                ListViewItem ls = new ListViewItem();

                string temp = i.Replace(Directory.GetParent(i).ToString() + "\\", "");
                ls.Text = temp;
                string time = Directory.GetCreationTime(i).ToString();
                if (File.Exists(i + @"\intro.txt"))
                {
                    String intro = File.ReadAllText(i + @"\intro.txt", Encoding.UTF8);

                    ls.SubItems.Add(intro);
                    ls.SubItems.Add(time);
                }
                else
                {

                    ls.SubItems.Add("[无描述文件]");
                    ls.SubItems.Add(time);
                }
                listView1.Items.Add(ls);
            }
        }

        private void 打开存档目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择你要打开的项目");
                    return;
                }
                string slepath = listView1.SelectedItems[0].Text;
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = path + @"\Klei\DSTTools\"+slepath;
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            catch
            {

                MessageBox.Show("恢复失败");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            huifushijiebtn.Enabled = true;
            button8.Enabled = true;
            chongzhibtn.Enabled = true;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2C0LJ6R"); 
        }


    }
}
