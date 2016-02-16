using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace DSTseverTools
{
    public partial class Setting2 : Form
    {


        string animalskv = "";
        string resourceskv = "";
        string unpreparedkv = "";
        string monsterskv = "";
        string misckv = "";
        public string cpath ="";
        public Setting2()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {




            foreach (Control c in shijiebox.Controls) {
                if (c.GetType().ToString() == "System.Windows.Forms.ComboBox") {
                    (c as ComboBox).SelectedIndex = 2;
                }
            }

            string[] resources1 = { "fern", "flint", "flower_cave", "flowers", "grass", "marshbush", "meteorshowers", "meteorspawner",
                                 "mushtree","reeds","rock","rock_ice","sapling","trees","tumbleweed","wormlights"
                                 };
            string[] resourcestxt = { "蕨类植物","燧石","洞穴花","花","干草","尖刺灌木","陨石","陨石坑","蘑菇树","芦苇","岩石","冰块","小树枝","树","风滚草","发光浆果"};
            build(resources1,resourcestxt,resourcesbox);

            string[] monsters1 = { "bats", "bearger", "chess", "deciduousmonster", "deerclops", "dragonfly", "fissure", "goosemoose", "houndmound", "hounds", "krampus",
                                "liefs","lureplants","merm","spiders","tentacles","walrus","worms"
                                };
            string[] monsterstxt = {"蝙蝠","秋季boss熊","齿轮马","树精","巨鹿","龙蝇","裂缝" ,"春季boos鸭","猎犬丘","猎狗","小偷","树人",
                                   "食人花","鱼人","蜘蛛","触手","海象洞穴","蠕虫"
                                   };

            build(monsters1, monsterstxt, monsters);
            string[] animals1 = { "alternatehunt", "angrybees", "beefalo", "beefaloheat", "bees", "birds", "bunnymen", "butterfly", "buzzard", "catcoon",
                               "frogs","hunt","lightninggoat","moles","monkey","penguins","perd","pigs","rabbits","rocky","slurper","slurtles","tallbirds"
                               };
            string[] animalstxt = { "足迹","杀人蜂巢","牛","发情牛","蜜蜂巢","鸟","兔人","蝴蝶","秃鹫","猫熊","青蛙","大象","电羊","鼹鼠"
                                 , "猴子","企鹅","火鸡","猪人","兔子","石虾","啜食者","蜗牛","高脚鸟"
                                  };
            build(animals1,animalstxt,animals);
            string[] misc1 = { "boons", "earthquakes", "frograin", "lightning", "touchstone", "weather", "wildfires" };
            string[] misctxt = { "前辈","地震","青蛙雨","闪电","复活台","暴雨","自燃"};
            build(misc1, misctxt, zaxiangbox);
            string[] unprepared1 = { "banana", "berrybush", "cactus", "carrot", "lichen", "mushroom" };
            string[] unpreparedtxt = { "香蕉", "浆果丛", "仙人掌", "胡萝卜", "苔藓", "蘑菇" };
            build(unprepared1, unpreparedtxt, unprepared);
            string[] word = { "autumn", "summer", "spring", "winter" };
            string[] wordtxt = { "秋天", "夏天", "春天", "冬天" };
            build2(word,wordtxt,jijiebox);
        }

        private void build(string[] str, string[] str1, GroupBox gb) {
            int rx = 6;
            int ry = 23;
            int x = 1;
            for (int i = 0; i < str.Length; i++)
            {
                Label l = new Label();
                ComboBox cb = new ComboBox();
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                string[] tttt = { "无", "较少", "默认", "较多", "大量" };
                cb.Items.AddRange(tttt);
                cb.SelectedIndex = 2;//从0开始
                cb.Height = 20;
                cb.Width = 110;
                l.Height = 20;
                l.Width = 80;
                l.Left = rx;
                l.Top = ry;
                cb.Top = ry;
                cb.Left = rx + 80;
                if (x >= 4)
                {
                    ry += 30;
                    rx = 6;
                    x = 1;
                }
                else
                {
                    rx = rx + 200;
                    x++;
                }

                l.Text = str1[i];
                l.Name = str[i] + "lable";
                cb.Name = str[i];
                gb.Controls.Add(l);
                gb.Controls.Add(cb);
            }
        }
        private void build2(string[] str, string[] str1, GroupBox gb)
        {
            int rx = 6;
            int ry = 23;

            int x = 1;
            for (int i = 0; i < str.Length; i++)
            {
                Label l = new Label();
                ComboBox cb = new ComboBox();
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                string[] tttt = { "无", "很短", "默认", "短", "长", "很长", "随机" };
                cb.Items.AddRange(tttt);
                cb.SelectedIndex = 2;//从0开始
                cb.Height = 20;
                cb.Width = 110;
                l.Height = 20;
                l.Width = 80;
                l.Left = rx;
                l.Top = ry;
                cb.Top = ry;
                cb.Left = rx + 80;
                if (x >= 4)
                {
                    ry += 30;
                    rx = 6;
                    x = 1;
                }
                else
                {
                    rx = rx + 200;
                    x++;
                }

                l.Text = str1[i];
                l.Name = str[i] + "lable";
                cb.Name = str[i] ;
                gb.Controls.Add(l);
                gb.Controls.Add(cb);
            }
        }

 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lyun.me/lyun/1191"); 
            //http://www.lyun.me/lyun/1191
        }

        private void button1_Click(object sender, EventArgs e)
        {
             animalskv = "";
             resourceskv = "";
             unpreparedkv = "";
             monsterskv = "";
             misckv = "";

            GetControls(this.Controls);
            string txt = ""; 
            string an = "\r\n animals={\r\n <#k-v>\r\n},";
            string re = "\r\n resources={\r\n <#k-v>\r\n},";
            string un = "\r\n unprepared={\r\n <#k-v>\r\n},";
            string mo = "\r\n monsters={\r\n <#k-v>\r\n},";
            string mi = "\r\n misc={\r\n <#k-v>\r\n},";
            
            mi = mi.Replace("<#k-v>", misckv);
            an = an.Replace("<#k-v>",animalskv);
            un = un.Replace("<#k-v>", unpreparedkv);
            mo = mo.Replace("<#k-v>", monsterskv);         
            re = re.Replace("<#k-v>", resourceskv);
            txt =  un+ mi+an + re  + mo ;
            string txtmian = "return { \r\n override_enabled = true,\r\n preset = \"DST_CAVE\"," + txt + "\r\n}\r\n\r\n--生成于，添加洞穴相关选项\r\n--BY JearyVon\r\n--WeiBo:http://weibo.com/findlike \r\n--如有不详细的地方还请告诉我【为了更方便使用】（微博，邮箱都行）";
            string txtcave = "return { \r\n override_enabled = true," + txt + "\r\n}\r\n\r\n--生成于，添加洞穴相关选项\r\n--BY JearyVon\r\n--WeiBo:http://weibo.com/findlike \r\n--如有不详细的地方还请告诉我【为了更方便使用】（微博，邮箱都行）";
            if (checkBox1.Checked)
            { 
                try
                {
                    StreamWriter sw = File.CreateText(@"temp\DSTTools\Save_1\Slave\worldgenoverride.lua");
                    sw.Write(txtmian);
                    sw.Close();
                    StreamWriter sw2 = File.CreateText(@"temp\DSTTools\Save_1\Master\worldgenoverride.lua");
                    sw2.Write(txtcave);
                    sw2.Close();
                    MessageBox.Show("生成成功，将为你打开目录");
                    string path = @"temp\DSTTools\Save_1\";
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
                catch (Exception)
                {
                    MessageBox.Show("保存失败！");
                    throw;
                }
            }
            else {
                try
                {
                    StreamWriter sw = File.CreateText(@"temp\DSTTools\Save_1\Master\worldgenoverride.lua");
                    sw.Write(txtcave);
                    sw.Close();
                    MessageBox.Show("生成成功，将为你打开目录");
                    string path = @"temp\DSTTools\Save_1\Master\";
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
                catch (Exception)
                {
                    MessageBox.Show("保存失败！");
                    throw;
                }

            }
           

        }



        public void GetControls(Control.ControlCollection ctc)
        {
            string[] mj = { "jijiebox", "zaxiangbox", "ziyuanbox", "shiwubox", "guaiwubox", "dongwubox" };
            string[] jijiebox1 ={ "noseason", "veryshortseason", "default", "shortseason", "longseason", "verylongseason", "random" };
            Hashtable other = new Hashtable();
            string[] z={ "never", "rare", "default", "often", "always" };
            string[] wsize = { "small","medium","default","huge" };
            string[] fenzhi = { "never", "least", "default", "most" };
            string[] qijijie = { "winter", "spring", "default", "summer", "autumnorspring", "winterorsummer", "random" };
            string[] dayqi233 = { "longday", "longdusk", "default", "longnight", "noday", "nodusk", "nonight", "onlyday", "onlydusk", "onlynight" };
            string[] lightc = { "veryslow", "slow", "default", "fast", "veryfast" };
            string[] zaisheng = { "veryslow", "slow", "default", "fast", "veryfast" };
            other.Add("misc", z);
            other.Add("resourcesbox", z);
            other.Add("unprepared", z);
            other.Add("monsters", z);
            other.Add("animals", z);
            other.Add("jijiebox", jijiebox1);
            //模版= {<#k-v>}       
            foreach (Control con in ctc)
            {
                if (!con.HasChildren)
                {
                    if (con.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                       ComboBox  temp =(con as ComboBox);
                        if(temp.SelectedIndex!=2){
                            string va = temp.SelectedItem.ToString();
                            string p = temp.Parent.Name;
                 
                            string name =temp.Name;
                            string[] ts=(string[])other[p];

                            if (p == "zaxiangbox" || p == "shijiebox" )
                            {
                                ts = (string[])other["misc"];
                                if (p == "shijiebox") {
                                    if (name == "world_size")
                                    {
                                        ts = wsize;
                                    }
                                    if (name == "branching") {
                                        ts = fenzhi;
                                    }
                                    if (name == "season_start")
                                    {
                                        ts = qijijie;
                                    }
                                    if (name == "day") {
                                        ts = dayqi233;
                                    }
                                    if (name == "cavelight") {
                                        ts = lightc;
                                    }
                                    if (name == "regrowth") {
                                        ts = zaisheng;
                                    }
                                }
                            }
                            
                           string value = ts[temp.SelectedIndex];
                           switch (p) {
                               case "resourcesbox":                                
                                  resourceskv+= "\t"+name+"=\""+value+"\",\r\n";                              
                               break;
                               case "unprepared":
                               unpreparedkv += "\t" + name + "=\"" + value + "\",\r\n";                            
                               break;
                               case "monsters":
                               monsterskv += "\t" + name + "=\"" + value + "\",\r\n";                    
                                 break;
                               case "animals":
                                 animalskv += "\t" + name + "=\"" + value + "\",\r\n";                          
                               break;
                               default:
                               misckv += "\t" + name + "=\"" + value + "\",\r\n"; 
                                 break;
                           }
                          
                        }
                       
                        continue;
                    }
                }
                GetControls(con.Controls);
            }

         
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://weibo.com/findlike"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            animalskv = "";
            resourceskv = "";
            unpreparedkv = "";
            monsterskv = "";
            misckv = "";

            GetControls(this.Controls);
            string txt = "";
            string an = "\r\n animals={\r\n <#k-v>\r\n},";
            string re = "\r\n resources={\r\n <#k-v>\r\n},";
            string un = "\r\n unprepared={\r\n <#k-v>\r\n},";
            string mo = "\r\n monsters={\r\n <#k-v>\r\n},";
            string mi = "\r\n misc={\r\n <#k-v>\r\n},";

            mi = mi.Replace("<#k-v>", misckv);
            an = an.Replace("<#k-v>", animalskv);
            un = un.Replace("<#k-v>", unpreparedkv);
            mo = mo.Replace("<#k-v>", monsterskv);
            re = re.Replace("<#k-v>", resourceskv);
            txt = un + mi + an + re + mo;
           string txtmian = "return { \r\n override_enabled = true,\r\n preset = \"DST_CAVE\"," + txt + "\r\n}\r\n\r\n--生成于，添加洞穴相关选项\r\n--BY JearyVon\r\n--WeiBo:http://weibo.com/findlike \r\n--如有不详细的地方还请告诉我（微博，邮箱都行）";
           string txtcave = "return { \r\n override_enabled = true," + txt + "\r\n}\r\n\r\n--生成于，添加洞穴相关选项\r\n--BY JearyVon\r\n--WeiBo:http://weibo.com/findlike \r\n--如有不详细的地方还请告诉我（微博，邮箱都行）";
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = path + @"\Klei\DSTTools";
            if (cpath != "")
            {
                if (checkBox1.Checked)
                {
                    try
                    {
                        StreamWriter sw = File.CreateText(cpath + @"\Slave\worldgenoverride.lua");//洞穴
                        sw.Write(txtmian);
                        sw.Close();
                        StreamWriter sw2 = File.CreateText(cpath + @"\Master\worldgenoverride.lua");
                        sw2.Write(txtcave);
                        sw2.Close();
                        DialogResult dr = MessageBox.Show("帮你打开目录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start("explorer.exe", path);

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("保存失败！");
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        StreamWriter sw = File.CreateText(cpath + @"\Master\worldgenoverride.lua");
                        sw.Write(txtcave);
                        sw.Close();
                        MessageBox.Show("生成成功，将为你打开目录");
                        System.Diagnostics.Process.Start("explorer.exe", path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("保存失败！");
                        throw;
                    }

                }
           
                    DialogResult = DialogResult.OK;
                    this.Close(); 
            }
            else {
                if (checkBox1.Checked)
                {
                    try
                    {
                        SelectSavePath slp = new SelectSavePath();
                        slp.checkfile = @"\Master\worldgenoverride.lua";
                     
                            if (slp.ShowDialog() == DialogResult.OK)
                            {
                                path = slp.pathret;
                               
                            }
                            else
                            {
                                MessageBox.Show("请选择目录");
                                return;

                            }
                    
                        StreamWriter sw = File.CreateText(path + @"\Slave\worldgenoverride.lua");
                        sw.Write(txtmian);
                        sw.Close();
                        StreamWriter sw2 = File.CreateText(path + @"\Master\worldgenoverride.lua");
                        sw2.Write(txtcave);
                        sw2.Close();
                        DialogResult dr = MessageBox.Show("帮你打开目录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start("explorer.exe", path);
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("保存失败！");
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        StreamWriter sw = File.CreateText(path + @"\Master\worldgenoverride.lua");
                        sw.Write(txtcave);
                        sw.Close();
                        MessageBox.Show("生成成功，将为你打开目录");
                        System.Diagnostics.Process.Start("explorer.exe", path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("保存失败！");
                        throw;
                    }

                }
            
            }

          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void reset(Control.ControlCollection ctc) {

            foreach (Control con in ctc)
            {
                if (!con.HasChildren)
                {
                    if (con.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox temp = (con as ComboBox);
                        temp.SelectedIndex = 2;
                        continue;
                    }

                }
                GetControls(con.Controls);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("【作者懒的写】\n请自己关闭该窗口再打开。");
        }
    }
}
