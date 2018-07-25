using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace oracleTool
{
    public partial class MainForm : Form
    {
        public static OracleConnection CONN = null;
        public static string dataBase = null;
        public static string uername = null;
        public static string pass = null;


        public MainForm()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            welcome.Parent = null;
            about.Parent = null;
            mhelp.Parent = null;

            cx_bkjsyl.Parent = null;
            cx_bkjszwz.Parent = null;
            cx_maxcostsql.Parent = null;

            ml_awr.Parent = null;

            bak_hy.Parent = null;
            bak_bf.Parent = null;

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
            uername = username.Text;
            pass = passwd.Text;
            dataBase = database.Text;
            //测试连接

            if (String.IsNullOrEmpty(uername) || String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(dataBase))
            {
                label4.Text = "数据库登录信息不全,无法登录";
                label4.ForeColor = Color.Red;
                return;
            }
            CONN = getConn();
            try
            {
                CONN.Open();
                //string strComm = "select bh from bdc_xm where ROWNUM =1";
                //OracleCommand comm = new OracleCommand(strComm, conn);
                //string dd = (string)comm.ExecuteScalar();
                //CONN.Close();
                //连接成功之后在下边栏显示用户和数据库地址
                toolStripStatusLabel2.Text = "数据库信息 : " + uername + "@" + dataBase;
                tabPage1.Parent = null;
                welcome.Parent = tabControl1;
                //this.WindowState = FormWindowState.Maximized;
                menuStrip1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                label4.Text = "登录失败,请确认你的登录信息";
                label4.ForeColor = Color.Red;
            }

        }

        private OracleConnection getConn()
        {
            if (CONN == null)
            {
                CONN = new OracleConnection("data source=" + dataBase + ";User Id=" + uername + ";Password=" + pass + ";");
            }
            return CONN;
        }


        private void exit_Click(object sender, EventArgs e)
        {
            if (CONN != null)
            {
                try
                {
                    CONN.Close();
                }
                catch (Exception)
                {
                }

            }
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
            switch (kjName)
            {
                case "helpText": mhelp.Parent = null; break;
                case "richTextBox1": about.Parent = null; break;
                case "cx_bkjsyl": cx_bkjsyl.Parent = null; break;
                case "ml_awr": ml_awr.Parent = null; break;
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
        private void tabControlPages(TabPage p)
        {
            var cons = tabControl1.TabPages;
            foreach (var contrls in cons)
            {
                if (contrls.Equals(p))
                {
                    tabControl1.SelectedTab = p;

                }
            }
        }

        private void 表空间使用率查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cx_bkjsyl.Parent = tabControl1;
            tabControlPages(cx_bkjsyl);
            
        }

        private void bkjcx_Click(object sender, EventArgs e)
        {
            //TBS 表空间名, SUM(TOTALM) 总共大小M, SUM(USEDM) 已使用空间M, SUM(REMAINEDM) 剩余空间M
            //, ROUND(SUM(USEDM)/SUM(TOTALM)*100,4) 已使用百分比  , ROUND(SUM(REMAINEDM)/SUM(TOTALM)*100,4) 剩余百分比
            string sql = "SELECT TBS t1, SUM(TOTALM) t2, SUM(USEDM) t3, SUM(REMAINEDM) t4, ROUND(SUM(USEDM)/SUM(TOTALM)*100,4) t5 "
                  + " , ROUND(SUM(REMAINEDM)/SUM(TOTALM)*100,4) t6 FROM( "
                  + " SELECT B.FILE_ID ID, B.TABLESPACE_NAME TBS, B.FILE_NAME NAME, B.BYTES/1024/1024 TOTALM, (B.BYTES-SUM(NVL(A.BYTES,0)))/1024/1024 USEDM "
                  + " , SUM(NVL(A.BYTES,0)/1024/1024) REMAINEDM, SUM(NVL(A.BYTES,0)/(B.BYTES)*100), (100 - (SUM(NVL(A.BYTES,0))/(B.BYTES)*100)) "
                  + " FROM DBA_FREE_SPACE A,DBA_DATA_FILES B WHERE A.FILE_ID = B.FILE_ID GROUP BY B.TABLESPACE_NAME,B.FILE_NAME,B.FILE_ID,B.BYTES "
                  + " ORDER BY B.TABLESPACE_NAME ) GROUP BY TBS ";
            DataTable dt = null;
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = CONN;
                cmd.CommandText = sql;
                OracleDataAdapter ada = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                dt = ds.Tables[0];
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "t5 desc";
            dt = dv.ToTable();
            //_source.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowCount = dt.Rows.Count;
            //dataGridView1.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["index"].Value = i + 1;
                dataGridView1.Rows[i].Cells["表空间名"].Value = dt.Rows[i]["t1"].ToString();
                dataGridView1.Rows[i].Cells["总共大小"].Value = dt.Rows[i]["t2"].ToString() + "M";
                dataGridView1.Rows[i].Cells["已使用空间"].Value = dt.Rows[i]["t3"].ToString() + "M";
                dataGridView1.Rows[i].Cells["剩余空间"].Value = dt.Rows[i]["t4"].ToString() + "M";
                dataGridView1.Rows[i].Cells["已使用百分比"].Value = dt.Rows[i]["t5"].ToString() + "%";
                dataGridView1.Rows[i].Cells["剩余百分比"].Value = dt.Rows[i]["t6"].ToString() + "%";
                if (Convert.ToDouble(dt.Rows[i]["t5"].ToString()) > 95.00)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            //dataGridView1.Sort(dataGridView1.Columns["已使用百分比"], ListSortDirection.Descending);
        }

        private void 表空间所在位置查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cx_bkjszwz.Parent = tabControl1;
            tabControlPages(cx_bkjszwz);
        }

        private void 最消耗CPU前十语句查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cx_maxcostsql.Parent = tabControl1;
            tabControlPages(cx_maxcostsql);
        }

        private void aWR报告导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ml_awr.Parent = tabControl1;
            tabControlPages(ml_awr);
        }

        private void 数据库备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bak_bf.Parent = tabControl1;
            tabControlPages(bak_bf);

        }

        private void 数据库还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bak_hy.Parent = tabControl1;
            tabControlPages(bak_hy);

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            string tableSpaceName = dataGridView1.Rows[index].Cells["表空间名"].Value.ToString();//读取id  
            if (!String.IsNullOrEmpty(tableSpaceName))
            {
                string sql_base = "select t.file_name from DBA_DATA_FILES t WHERE T.TABLESPACE_NAME='" + tableSpaceName + "'";
                DataTable dt = null;
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = CONN;
                    cmd.CommandText = sql_base;
                    OracleDataAdapter ada = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    dt = ds.Tables[0];
                }
                string str = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += dt.Rows[i]["file_name"].ToString() + "\n";
                }
                Form mess = new MessageForm(str, tableSpaceName);
                mess.ShowDialog();
            }
        }

        Process cmdExe = null;
        private void srartCmd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmdEdit.Text))
            {
                MessageBox.Show("选择需要执行的sql文件!");
                return;
            }
            if (String.IsNullOrEmpty(sysPass.Text))
            {
                MessageBox.Show("此功能需要sys用户密码!");
                return;
            }

            cmdExe = new Process();//创建进程对象  
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"sqlplus.exe";//设定需要执行的命令  
            startInfo.Arguments = @"-s sys/gtis@" + database.Text + " as sysdba @" + cmdEdit.Text;//“/C”表示执行完命令后马上退出  
            cmdExe.StartInfo = startInfo;
            try
            {
                cmdExe.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("请检查本地是否安装sqlplus工具!");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdExe != null)
                {
                    cmdExe.Kill();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "sql文件(awrrpt.sql)|awrrpt.sql";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cmdEdit.Text = dialog.FileName;
            }
        }


    }
}
