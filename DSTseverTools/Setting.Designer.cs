namespace DSTseverTools
{
    partial class Setting2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting2));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jijiebox = new System.Windows.Forms.GroupBox();
            this.shijiebox = new System.Windows.Forms.GroupBox();
            this.regrowth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cavelight = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.season_start = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.branching = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.world_size = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zaxiangbox = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resourcesbox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.unprepared = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.animals = new System.Windows.Forms.GroupBox();
            this.monsters = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.shijiebox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(38, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 471);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.jijiebox);
            this.tabPage1.Controls.Add(this.shijiebox);
            this.tabPage1.Controls.Add(this.zaxiangbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "世界";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jijiebox
            // 
            this.jijiebox.Location = new System.Drawing.Point(9, 297);
            this.jijiebox.Name = "jijiebox";
            this.jijiebox.Size = new System.Drawing.Size(839, 100);
            this.jijiebox.TabIndex = 2;
            this.jijiebox.TabStop = false;
            this.jijiebox.Text = "季节";
            // 
            // shijiebox
            // 
            this.shijiebox.Controls.Add(this.regrowth);
            this.shijiebox.Controls.Add(this.label6);
            this.shijiebox.Controls.Add(this.cavelight);
            this.shijiebox.Controls.Add(this.label5);
            this.shijiebox.Controls.Add(this.day);
            this.shijiebox.Controls.Add(this.label4);
            this.shijiebox.Controls.Add(this.season_start);
            this.shijiebox.Controls.Add(this.label3);
            this.shijiebox.Controls.Add(this.branching);
            this.shijiebox.Controls.Add(this.label2);
            this.shijiebox.Controls.Add(this.world_size);
            this.shijiebox.Controls.Add(this.label1);
            this.shijiebox.Location = new System.Drawing.Point(9, 28);
            this.shijiebox.Name = "shijiebox";
            this.shijiebox.Size = new System.Drawing.Size(839, 138);
            this.shijiebox.TabIndex = 1;
            this.shijiebox.TabStop = false;
            this.shijiebox.Text = "世界";
            // 
            // regrowth
            // 
            this.regrowth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regrowth.FormattingEnabled = true;
            this.regrowth.Items.AddRange(new object[] {
            "很慢",
            "慢",
            "默认",
            "快",
            "很快"});
            this.regrowth.Location = new System.Drawing.Point(281, 75);
            this.regrowth.Name = "regrowth";
            this.regrowth.Size = new System.Drawing.Size(121, 25);
            this.regrowth.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "再生速度";
            // 
            // cavelight
            // 
            this.cavelight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cavelight.FormattingEnabled = true;
            this.cavelight.Items.AddRange(new object[] {
            "很慢",
            "慢",
            "默认",
            "快",
            "很快"});
            this.cavelight.Location = new System.Drawing.Point(75, 75);
            this.cavelight.Name = "cavelight";
            this.cavelight.Size = new System.Drawing.Size(121, 25);
            this.cavelight.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "洞穴光照";
            // 
            // day
            // 
            this.day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day.FormattingEnabled = true;
            this.day.Items.AddRange(new object[] {
            "长白天",
            "长黄昏",
            "默认",
            "长夜晚",
            "无白天",
            "无黄昏",
            "无夜晚",
            "仅白天",
            "仅黄昏",
            "仅夜晚"});
            this.day.Location = new System.Drawing.Point(681, 32);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(121, 25);
            this.day.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "昼夜长短";
            // 
            // season_start
            // 
            this.season_start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.season_start.FormattingEnabled = true;
            this.season_start.Items.AddRange(new object[] {
            "冬",
            "春",
            "默认",
            "夏",
            "秋或春",
            "冬或夏",
            "随机"});
            this.season_start.Location = new System.Drawing.Point(478, 32);
            this.season_start.Name = "season_start";
            this.season_start.Size = new System.Drawing.Size(121, 25);
            this.season_start.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "起始季节";
            // 
            // branching
            // 
            this.branching.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.branching.FormattingEnabled = true;
            this.branching.Items.AddRange(new object[] {
            "没有",
            "最少",
            "默认",
            "最多"});
            this.branching.Location = new System.Drawing.Point(281, 32);
            this.branching.Name = "branching";
            this.branching.Size = new System.Drawing.Size(121, 25);
            this.branching.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "分支";
            // 
            // world_size
            // 
            this.world_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.world_size.FormattingEnabled = true;
            this.world_size.Items.AddRange(new object[] {
            "小型",
            "中型",
            "默认",
            "大型"});
            this.world_size.Location = new System.Drawing.Point(75, 32);
            this.world_size.Name = "world_size";
            this.world_size.Size = new System.Drawing.Size(121, 25);
            this.world_size.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "世界大小";
            // 
            // zaxiangbox
            // 
            this.zaxiangbox.Location = new System.Drawing.Point(9, 172);
            this.zaxiangbox.Name = "zaxiangbox";
            this.zaxiangbox.Size = new System.Drawing.Size(839, 119);
            this.zaxiangbox.TabIndex = 0;
            this.zaxiangbox.TabStop = false;
            this.zaxiangbox.Text = "杂项";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resourcesbox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.unprepared);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(864, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "动植资源";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resourcesbox
            // 
            this.resourcesbox.Location = new System.Drawing.Point(8, 6);
            this.resourcesbox.Name = "resourcesbox";
            this.resourcesbox.Size = new System.Drawing.Size(835, 190);
            this.resourcesbox.TabIndex = 9;
            this.resourcesbox.TabStop = false;
            this.resourcesbox.Text = "资源";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(358, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "邮箱：v@vvwall.com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(326, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "如果要是有什么问题请点击这里反馈";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // unprepared
            // 
            this.unprepared.Location = new System.Drawing.Point(8, 202);
            this.unprepared.Name = "unprepared";
            this.unprepared.Size = new System.Drawing.Size(835, 133);
            this.unprepared.TabIndex = 6;
            this.unprepared.TabStop = false;
            this.unprepared.Text = "食物";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(368, 349);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(104, 17);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "一个更好用的工具";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.animals);
            this.tabPage3.Controls.Add(this.monsters);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(864, 441);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "怪物动物";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // animals
            // 
            this.animals.ForeColor = System.Drawing.Color.Black;
            this.animals.Location = new System.Drawing.Point(8, 222);
            this.animals.Name = "animals";
            this.animals.Size = new System.Drawing.Size(845, 217);
            this.animals.TabIndex = 7;
            this.animals.TabStop = false;
            this.animals.Text = "动物";
            // 
            // monsters
            // 
            this.monsters.Location = new System.Drawing.Point(8, 11);
            this.monsters.Name = "monsters";
            this.monsters.Size = new System.Drawing.Size(845, 205);
            this.monsters.TabIndex = 6;
            this.monsters.TabStop = false;
            this.monsters.Text = "怪物";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(340, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存至临时目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(536, 510);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "保存至游戏目录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.checkBox1.Location = new System.Drawing.Point(246, 516);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 21);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "配置洞穴";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Setting2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(939, 549);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Setting2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器设置[beta v0.2.6]";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.shijiebox.ResumeLayout(false);
            this.shijiebox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
      //  private System.Windows.Forms.GroupBox resourcesbox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox monsters;
        private System.Windows.Forms.GroupBox animals;
        private System.Windows.Forms.GroupBox zaxiangbox;
        private System.Windows.Forms.GroupBox unprepared;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox shijiebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox world_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox season_start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox branching;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cavelight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox regrowth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox jijiebox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox resourcesbox;
    }
}