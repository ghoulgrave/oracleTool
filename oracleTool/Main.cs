using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oracleTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            welcome.Parent = null;
            about.Parent = null;
            mhelp.Parent = null;
            menuStrip1.Visible = false;
        }
        private void 测试按钮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //测试按钮
            //            测试方法
            MessageBox.Show(username.Text);
            
        }

        private void sure_Click(object sender, EventArgs e)
        {
            String uername = username.Text;
            String pass = passwd.Text;
            String dataBase = database.Text;
            //测试连接

            //连接成功之后在下边栏显示用户和数据库地址
            toolStripStatusLabel2.Text = uername + "@" + dataBase ;

            tabPage1.Parent = null;
            welcome.Parent = tabControl1;
            this.WindowState = FormWindowState.Maximized;
            menuStrip1.Visible = true;

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Parent = tabControl1;
            tabControlPages(about);
        }

        //控件名
        private string kjName = "";
        private void 关闭页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (kjName) {
                case "helpText": mhelp.Parent = null; break;
                case "richTextBox1": about.Parent = null; break;
                default: break;
            }
            tabControl1.SelectedTab = welcome;
        }

        private void 关闭当前页面_Opening(object sender, CancelEventArgs e)
        {
            string whichcontrol_name = (sender as ContextMenuStrip).SourceControl.Name;
            kjName = whichcontrol_name;
        }

        private void 使用帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mhelp.Parent = tabControl1;
            tabControlPages(mhelp);
        }
        //true ++
        //false -- 
        private void tabControlPages(TabPage p) {
            var cons = tabControl1.TabPages;
            foreach(var contrls in cons){
                if (contrls.Equals(p))
                {
                     tabControl1.SelectedTab = p;
                
                }
            }
        }
    }
}
