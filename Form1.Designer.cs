namespace WinFormsApp1
{
    using LitJson;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class Main : Form
    {
        private string allUser = "";
        private Dictionary<string, string> userMapping = new Dictionary<string, string>();
        private IContainer components;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label3;
        private ComboBox comboBox1;
        private Label label2;
        private Button button1;
        private LinkLabel linkLabel1;

        public Main()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("请选择EVE配置目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要同步的主要角色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.textBox2.Text.Equals(string.Empty))
            {
                MessageBox.Show("请输入要被同步到的角色ID", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string str = this.userMapping[this.comboBox1.SelectedItem.ToString()];
                string path = this.textBox1.Text + "/core_char_" + str + ".dat";
                if (!File.Exists(path))
                {
                    MessageBox.Show("无法找到主角色配置文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    foreach (string str3 in this.textBox2.Text.Split(Environment.NewLine.ToCharArray()))
                    {
                        if (this.userMapping.ContainsKey(str3))
                        {
                            string str4 = this.userMapping[str3];
                            string str5 = this.textBox1.Text + "/core_char_" + str4 + ".dat";
                            if (!path.Equals(str5))
                            {
                                if (File.Exists(str5))
                                {
                                    File.Delete(str5);
                                }
                                File.Copy(path, str5);
                            }
                        }
                    }
                    MessageBox.Show("角色配置同步完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Main));
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.linkLabel1 = new LinkLabel();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.comboBox1 = new ComboBox();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x277, 0xf6);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基础配置";
            this.button1.Location = new Point(0x11c, 0xd1);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 7;
            this.button1.Text = "一键同步";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new Point(9, 0x71);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x35, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "获取全部";
            this.linkLabel1.Click += new EventHandler(this.linkLabel1_Click);
            this.textBox2.Location = new Point(0x41, 0x49);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = ScrollBars.Vertical;
            this.textBox2.Size = new Size(560, 0x7f);
            this.textBox2.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 0x4c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x3b, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "目标角色:";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(0x41, 0x2d);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(560, 20);
            this.comboBox1.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 0x31);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "主要角色:";
            this.textBox1.Location = new Point(0x41, 0x11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(560, 0x15);
            this.textBox1.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3b, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置目录:";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28f, 270);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "Main";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "混沌EVE配置一键同步器";
            base.Load += new EventHandler(this.Main_Load);
            base.Shown += new EventHandler(this.Main_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = this.allUser;
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Text = "正在读取本地角色列表,请勿乱动";
            try
            {
                foreach (string str in Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Local\CCP\EVE"))
                {
                    if (str.EndsWith("eve_sharedcache_tq_tranquility"))
                    {
                        this.textBox1.Text = str + @"\settings_Default";
                        break;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("无法自动获取游戏配置目录,请手动输入游戏配置目录" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (this.textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("无法自动获取游戏配置目录,请手动输入游戏配置目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            List<string> list = new List<string>();
            foreach (string str2 in Directory.GetFiles(this.textBox1.Text, "core_char_*.dat"))
            {
                if (Regex.IsMatch(str2, "core_char_([0-9]+).dat"))
                {
                    list.Add(Regex.Match(str2, "core_char_([0-9]+).dat").Groups[1].Value);
                }
            }
            JsonData data = JsonMapper.ToObject(Http.GetResponse("https://esi.evetech.net/latest/universe/names/?datasource=tranquility", JsonMapper.ToJson(list)));
            for (int i = 0; i < data.Count; i++)
            {
                this.allUser = this.allUser + data[i]["name"].ToString() + Environment.NewLine;
                this.comboBox1.Items.Add(data[i]["name"].ToString());
                this.userMapping.Add(data[i]["name"].ToString(), data[i]["id"].ToString());
            }
            this.comboBox1.SelectedIndex = 0;
            this.Text = "混沌EVE配置一键同步器";
        }
    }
}

