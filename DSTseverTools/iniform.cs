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

namespace DSTseverTools
{
    public partial class iniform : Form
    {
        string inifile = "";
        public string cpath = "";
        public iniform()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                linkkey.Enabled = true;
                iptxt.Enabled = true;
            }
            else {
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                linkkey.Enabled = false;
                iptxt.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @".\temp\DSTTools\Save_1\";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);        
            }
            IniFiles ini = new IniFiles(path + "cluster.ini");
            //预设的一些

            if (checkBox1.Checked)
            {
                creatini(ini, true, true);
            }
            else {
                creatini(ini, false, false);
            }

            MessageBox.Show("生成成功了\n等全部配置完之后把Save_1整个文件夹复制到我的文档/klei/DSTTools中");
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        //主服务器
        private void creatzhu(IniFiles ini)
        {
            ini.WriteString("NETWORK", "server_port", textBox3.Text == "10999" ? "10999" : textBox3.Text);
            ini.WriteString("SHARD", "is_master", "true");
            changecode(ini);
        }
        //从服
        private void creatcong(IniFiles ini)
        {
            ini.WriteString("NETWORK", "server_port", textBox5.Text == "11000" ? "11000" : textBox3.Text);
            ini.WriteString("STEAM", "master_server_port", "27017");
            ini.WriteString("STEAM", "authentication_port", "8767");
            ini.WriteString("SHARD", "is_master", "false");
            ini.WriteString("SHARD", "name", "Slave");          
            ini.WriteString("SHARD", "master_ip", iptxt.Text == "" ? "127.0.0.1" : iptxt.Text);
            changecode(ini);
      
        }
        //编码转换
        private void changecode(IniFiles ini)
        {
            try {
                string FileName = ini.FileName;
                StreamReader sr = new StreamReader(FileName, Encoding.Default);
                string temp = sr.ReadToEnd();
                sr.Close();
                File.Delete(FileName);
                // Encoding.Convert();
                UTF8Encoding utf8 = new UTF8Encoding(false);
                StreamWriter sw = new StreamWriter(FileName, false, utf8);
                sw.Write(temp);
                sw.Close();
            }
            catch {
                MessageBox.Show("抱歉，读写文件失败，请重试");
            }
        }
        private void creatini(IniFiles ini,Boolean i,Boolean e) {

            string pcname = Environment.UserName;
            ini.WriteString("MISC", "console_enabled", "true");
            ini.WriteString("MISC", "autocompiler_enabled", "false");
            ini.WriteString("NETWORK", "cluster_name", textBox1.Text == "" ? "go " + pcname + "`s world" : textBox1.Text);
            ini.WriteString("NETWORK", "cluster_description", textBox2.Text == "" ? "let`s play game by vvwall.com" : textBox2.Text);

            ini.WriteString("NETWORK", "cluster_password", textBox4.Text);
            ini.WriteString("GAMEPLAY", "max_players", playernum.Value.ToString());
            if (pvp.SelectedItem.ToString() == "开")
            {
                ini.WriteString("GAMEPLAY", "pvp", "true");
            }
            else
            {
                ini.WriteString("GAMEPLAY", "pvp", "false");
            }
            if (mode.SelectedItem.ToString() == "")
            {
                ini.WriteString("GAMEPLAY", "game_mode", "survival");
            }
            if (mode.SelectedItem.ToString() == "无尽模式")
            {
                ini.WriteString("GAMEPLAY", "game_mode", "endless");
            }
            if (mode.SelectedItem.ToString() == "生存模式")
            {
                ini.WriteString("GAMEPLAY", "game_mode", "survival");
            }
            if (mode.SelectedItem.ToString() == "荒野模式")
            {
                ini.WriteString("GAMEPLAY", "game_mode", "wilderness");
            }
            //类别、合作、社交、疯狂、竞争

            switch (type.SelectedItem.ToString())
            {
                case "合作":
                    ini.WriteString("NETWORK", "server_intention", "cooperative");
                    break;
                case "社交":
                    ini.WriteString("NETWORK", "server_intention", "social");
                    break;
                case "疯狂":
                    ini.WriteString("NETWORK", "server_intention", "madness");
                    break;
                case "竞争":
                    ini.WriteString("NETWORK", "server_intention", "competitive");
                    break;
            }
            switch (type.SelectedItem.ToString())
            {
                case "合作":
                    ini.WriteString("NETWORK", "cluster_intention", "cooperative");
                    break;
                case "社交":
                    ini.WriteString("NETWORK", "cluster_intention", "social");
                    break;
                case "疯狂":
                    ini.WriteString("NETWORK", "cluster_intention", "madness");
                    break;
                case "竞争":
                    ini.WriteString("NETWORK", "cluster_intention", "competitive");
                    break;
            }
            // 快照
            if (kuaizhao.SelectedItem.ToString() == "开")
            {
                ini.WriteString("GAMEPLAY", "enable_snapshots", "true");
            }
            else {
                ini.WriteString("GAMEPLAY", "enable_snapshots", "false");
            }
            //自动保存
            if (autosave.SelectedItem.ToString() == "关")
            {
                ini.WriteString("GAMEPLAY", "enable_autosaver", "false");
            }
            else
            {
                ini.WriteString("GAMEPLAY", "enable_autosaver", "true");
            }
            if (steamcom.SelectedItem.ToString() == "开")
            {
                if (steamtxt.Text.Length>0)
                {
                    MessageBox.Show(steamtxt.Text);
                    ini.WriteString("STEAM", "steam_group_id", steamtxt.Text);
                    ini.WriteString("STEAM", " steam_group_admins", steamtxt.Text);
                    if (onlygoupch.Checked)
                    {
                        ini.WriteString("STEAM", "steam_group_only", "true");
                    }
                    else
                    {
                        ini.WriteString("STEAM", "steam_group_only", "false");
                    }
                }
                else { 
                
                }

            }
            //投票踢人
            if (tiren.SelectedItem.ToString() == "关")
            {
                ini.WriteString("GAMEPLAY", "enable_vote_kick", "false");
            }
            else
            {
                ini.WriteString("GAMEPLAY", "enable_vote_kick", "true");
            }
            //自动暂停
            if (zanting.SelectedItem.ToString() == "关")
            {
                ini.WriteString("GAMEPLAY", "pause_when_empty", "false");
            }
            else
            {
                ini.WriteString("GAMEPLAY", "pause_when_empty", "true");
            }
            ini.WriteString("NETWORK", "connection_timeout", "8000");
            if (offlinemode.Checked)
            {
                ini.WriteString("NETWORK", "lan_only_cluster", "true");
                ini.WriteString("NETWORK", "offline_server", "true");
            }
            else {
                ini.WriteString("NETWORK", "lan_only_cluster", "false");
                ini.WriteString("NETWORK", "offline_server", "false");
            }

            if (i)
            {
                ini.WriteString("SHARD", "shard_enabled", "true");
                ini.WriteString("SHARD", "cluster_key", linkkey.Text == "" ? "yourkey" : linkkey.Text);
                ini.WriteString("SHARD", "master_port", textBox6.Text == "" ? "11200" : textBox6.Text);
                ini.WriteString("SHARD", "master_ip", iptxt.Text == "" ? "127.0.0.1" : iptxt.Text);
                String pathtemp = Path.GetDirectoryName(ini.FileName);
                    //从服务器
                    IniFiles inicong = new IniFiles(pathtemp + @"\Slave\server.ini");
                    creatcong(inicong);
            
                    //主服务器

                    IniFiles inizhu = new IniFiles(pathtemp + @"\Master\server.ini");
                    creatzhu(inizhu);

            }
            else {
                ini.WriteString("SHARD", "shard_enabled", "false");
                ini.WriteString("SHARD", "cluster_key", linkkey.Text == "" ? "yourkey" : linkkey.Text);
                ini.WriteString("SHARD", "master_port", textBox6.Text == "" ? "11200" : textBox6.Text);
                ini.WriteString("SHARD", "master_ip", iptxt.Text == "" ? "127.0.0.1" : iptxt.Text);
            
            }
            changecode(ini);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("iexplore.exe", "http://www.baidu.com");
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog op = new OpenFileDialog();
            
            //op.DefaultExt = ".ini|.INI";
            op.Filter = "Settings.ini|Settings.ini|ini配置文件|*.ini";
            if (op.ShowDialog() == DialogResult.OK) {
                inifile = op.FileName;
                StreamReader rf = File.OpenText(inifile);
                string txt = rf.ReadToEnd();
                rf.Close();

                loadini(inifile);
               // MessageBox.Show(inifile);

            }
        }
        private void loadini(string inifile){

            IniFiles ini = new IniFiles(inifile);
           textBox1.Text= ini.ReadString("NETWORK", "default_server_name","");
           textBox2.Text = ini.ReadString("NETWORK", "default_server_description", "");
           textBox3.Text = ini.ReadString("NETWORK", "server_port", "") == "" ? "10999" : ini.ReadString("NETWORK", "server_port", "");
           textBox4.Text = ini.ReadString("NETWORK", "server_password","");
           playernum.Value = decimal.Parse(ini.ReadString("NETWORK", "max_players", ""));
           MessageBox.Show("作者比较懒没写剩下的配置\n如需修改\n请自己手动修改啊");
           System.Diagnostics.Process.Start("explorer.exe",inifile);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 保存到游戏目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //预设的一些
            path = path + @"\Klei\DSTTools\Cluster_1\";
            if (cpath != "")
            {
                path = cpath + @"\";
            }
            else {

                SelectSavePath slp = new SelectSavePath();
                slp.checkfile = @"\cluster.ini";

                if (slp.ShowDialog() == DialogResult.OK)
                {
                    path = slp.pathret;

                }
                else
                {
                    MessageBox.Show("请选择目录");
                    return;

                }
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            IniFiles ini = new IniFiles(path + "cluster.ini");
            //预设的一些

            if (checkBox1.Checked)
            {
                creatini(ini, true, true);
            }
            else
            {
                creatini(ini, false, false);
            }

            MessageBox.Show("生成成功了\n已经放置到游戏目录");
            if (cpath != "")
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }

        private void iniform_Load(object sender, EventArgs e)
        {
            foreach (Control i in groupBox2.Controls) {
                if (i.GetType().ToString() == "System.Windows.Forms.ComboBox") {
                    ComboBox temp = (i as ComboBox);
                    temp.SelectedIndex = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (steamcom.SelectedItem.ToString() == "开")
            {

                label20.Visible = true;
                steamtxt.Visible = true;
                onlygoupch.Visible = true;
            }
            else {
                label20.Visible = false;
                steamtxt.Visible = false;
                onlygoupch.Visible = false;
            
            }
        }
    }
}
