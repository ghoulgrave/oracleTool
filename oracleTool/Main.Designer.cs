﻿namespace oracleTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sure = new System.Windows.Forms.Button();
            this.database = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.passwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.welcome = new System.Windows.Forms.TabPage();
            this.about = new System.Windows.Forms.TabPage();
            this.关闭当前页面 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mhelp = new System.Windows.Forms.TabPage();
            this.helpText = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排查问题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试按钮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.welcome.SuspendLayout();
            this.about.SuspendLayout();
            this.关闭当前页面.SuspendLayout();
            this.mhelp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.welcome);
            this.tabControl1.Controls.Add(this.about);
            this.tabControl1.Controls.Add(this.mhelp);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 499);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 12F);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基础环境配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.sure);
            this.panel1.Controls.Add(this.database);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.passwd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(102, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 411);
            this.panel1.TabIndex = 4;
            // 
            // sure
            // 
            this.sure.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sure.Location = new System.Drawing.Point(95, 275);
            this.sure.Name = "sure";
            this.sure.Size = new System.Drawing.Size(75, 23);
            this.sure.TabIndex = 1;
            this.sure.Text = "确认";
            this.sure.UseVisualStyleBackColor = true;
            this.sure.Click += new System.EventHandler(this.sure_Click);
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(153, 182);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(373, 26);
            this.database.TabIndex = 3;
            // 
            // exit
            // 
            this.exit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.exit.Location = new System.Drawing.Point(411, 275);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "退出";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(153, 137);
            this.passwd.Name = "passwd";
            this.passwd.PasswordChar = '*';
            this.passwd.Size = new System.Drawing.Size(373, 26);
            this.passwd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "密　码:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(153, 90);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(373, 26);
            this.username.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据库:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcome
            // 
            this.welcome.Controls.Add(this.button1);
            this.welcome.Location = new System.Drawing.Point(4, 22);
            this.welcome.Name = "welcome";
            this.welcome.Padding = new System.Windows.Forms.Padding(3);
            this.welcome.Size = new System.Drawing.Size(776, 473);
            this.welcome.TabIndex = 1;
            this.welcome.Text = "欢迎";
            this.welcome.UseVisualStyleBackColor = true;
            // 
            // about
            // 
            this.about.ContextMenuStrip = this.关闭当前页面;
            this.about.Controls.Add(this.richTextBox1);
            this.about.Location = new System.Drawing.Point(4, 22);
            this.about.Name = "about";
            this.about.Padding = new System.Windows.Forms.Padding(3);
            this.about.Size = new System.Drawing.Size(776, 473);
            this.about.TabIndex = 2;
            this.about.Text = "关于";
            this.about.UseVisualStyleBackColor = true;
            // 
            // 关闭当前页面
            // 
            this.关闭当前页面.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭页面ToolStripMenuItem});
            this.关闭当前页面.Name = "关闭当前页面";
            this.关闭当前页面.Size = new System.Drawing.Size(145, 30);
            this.关闭当前页面.Opening += new System.ComponentModel.CancelEventHandler(this.关闭当前页面_Opening);
            // 
            // 关闭页面ToolStripMenuItem
            // 
            this.关闭页面ToolStripMenuItem.Name = "关闭页面ToolStripMenuItem";
            this.关闭页面ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.关闭页面ToolStripMenuItem.Text = "关闭页面";
            this.关闭页面ToolStripMenuItem.Click += new System.EventHandler(this.关闭页面ToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.ContextMenuStrip = this.关闭当前页面;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(759, 460);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "1.我想告诉你的是：这个工具是海老板智慧的结晶。有事可以找海老板咨询。\n2.工具你可以用；有意见你可以提、有需求你可以讲，但是你要准备喷我们，你会死的很难看。";
            this.richTextBox1.ZoomFactor = 1.5F;
            // 
            // mhelp
            // 
            this.mhelp.ContextMenuStrip = this.关闭当前页面;
            this.mhelp.Controls.Add(this.helpText);
            this.mhelp.Location = new System.Drawing.Point(4, 22);
            this.mhelp.Name = "mhelp";
            this.mhelp.Padding = new System.Windows.Forms.Padding(3);
            this.mhelp.Size = new System.Drawing.Size(776, 473);
            this.mhelp.TabIndex = 3;
            this.mhelp.Text = "使用帮助";
            this.mhelp.UseVisualStyleBackColor = true;
            // 
            // helpText
            // 
            this.helpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpText.ContextMenuStrip = this.关闭当前页面;
            this.helpText.Location = new System.Drawing.Point(4, 7);
            this.helpText.Name = "helpText";
            this.helpText.Size = new System.Drawing.Size(772, 466);
            this.helpText.TabIndex = 0;
            this.helpText.Text = "测试";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 21);
            this.toolStripStatusLabel1.Text = "V0.0.0.1D";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(15, 21);
            this.toolStripStatusLabel2.Text = " ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.备份ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.排查问题ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.使用帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.测试按钮ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 备份ToolStripMenuItem
            // 
            this.备份ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能1ToolStripMenuItem,
            this.功能2ToolStripMenuItem});
            this.备份ToolStripMenuItem.Name = "备份ToolStripMenuItem";
            this.备份ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.备份ToolStripMenuItem.Text = "备份";
            // 
            // 功能1ToolStripMenuItem
            // 
            this.功能1ToolStripMenuItem.Name = "功能1ToolStripMenuItem";
            this.功能1ToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.功能1ToolStripMenuItem.Text = "功能1";
            // 
            // 功能2ToolStripMenuItem
            // 
            this.功能2ToolStripMenuItem.Name = "功能2ToolStripMenuItem";
            this.功能2ToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.功能2ToolStripMenuItem.Text = "功能2";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 排查问题ToolStripMenuItem
            // 
            this.排查问题ToolStripMenuItem.Name = "排查问题ToolStripMenuItem";
            this.排查问题ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.排查问题ToolStripMenuItem.Text = "排查问题";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 使用帮助ToolStripMenuItem
            // 
            this.使用帮助ToolStripMenuItem.Name = "使用帮助ToolStripMenuItem";
            this.使用帮助ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.使用帮助ToolStripMenuItem.Text = "使用帮助";
            this.使用帮助ToolStripMenuItem.Click += new System.EventHandler(this.使用帮助ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 测试按钮ToolStripMenuItem
            // 
            this.测试按钮ToolStripMenuItem.Name = "测试按钮ToolStripMenuItem";
            this.测试按钮ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.测试按钮ToolStripMenuItem.Text = "测试按钮";
            this.测试按钮ToolStripMenuItem.Click += new System.EventHandler(this.测试按钮ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(119, 30);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.closeToolStripMenuItem.Text = "close";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "welcome";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "一个oracle的小工具";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.welcome.ResumeLayout(false);
            this.about.ResumeLayout(false);
            this.关闭当前页面.ResumeLayout(false);
            this.mhelp.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage welcome;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 备份ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排查问题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试按钮ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button sure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TabPage about;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ContextMenuStrip 关闭当前页面;
        private System.Windows.Forms.ToolStripMenuItem 关闭页面ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabPage mhelp;
        private System.Windows.Forms.RichTextBox helpText;
        private System.Windows.Forms.Button button1;
    }
}
