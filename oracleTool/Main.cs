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
            cx_maxcostsql.Parent = null;

            ml_awr.Parent = null;

            bak_hy.Parent = null;
            bak_bf.Parent = null;

            menuStrip1.Visible = false;
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

        #region 表空间使用率查询

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
        #endregion

        #region 最消耗CPU语句查询
        private void 最消耗CPU前十语句查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cx_maxcostsql.Parent = tabControl1;
            tabControlPages(cx_maxcostsql);
        }

        private void xhcx_Click(object sender, EventArgs e)
        {
            
            Int64 iNumber = Convert.ToInt64(numericUpDown1.Value);

            //TBS 表空间名, SUM(TOTALM) 总共大小M, SUM(USEDM) 已使用空间M, SUM(REMAINEDM) 剩余空间M
            //, ROUND(SUM(USEDM)/SUM(TOTALM)*100,4) 已使用百分比  , ROUND(SUM(REMAINEDM)/SUM(TOTALM)*100,4) 剩余百分比
            string sql = @"select * from (select v.sql_id,v.child_number, v.sql_text, v.elapsed_time, v.cpu_time,
               v.disk_reads, rank() over(order by v.cpu_time desc) elapsed_rank from v$sql v) a where elapsed_rank<=" + iNumber;
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
            dv.Sort = "elapsed_rank asc";
            dt = dv.ToTable();
            //_source.DataSource = dt;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowCount = dt.Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells["Column1"].Value =  dt.Rows[i]["elapsed_rank"].ToString();
                dataGridView2.Rows[i].Cells["Column2"].Value = dt.Rows[i]["cpu_time"].ToString() + "ms";
                dataGridView2.Rows[i].Cells["Column3"].Value = dt.Rows[i]["sql_text"].ToString();
                //dataGridView2.Rows[i].Cells["已使用空间"].Value = dt.Rows[i]["t3"].ToString() + "M";
                //dataGridView2.Rows[i].Cells["剩余空间"].Value = dt.Rows[i]["t4"].ToString() + "M";
                //dataGridView2.Rows[i].Cells["已使用百分比"].Value = dt.Rows[i]["t5"].ToString() + "%";
                //dataGridView2.Rows[i].Cells["剩余百分比"].Value = dt.Rows[i]["t6"].ToString() + "%";
                //if (Convert.ToDouble(dt.Rows[i]["t5"].ToString()) > 95.00)
                //{
                //    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //}
            }
            //dataGridView2.Sort(dataGridView2.Columns["已使用百分比"], ListSortDirection.Descending);
            //dataGridView2.AutoResizeColumns();//自动高度
        }
        #endregion

        #region aWR报告导出
        private void aWR报告导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ml_awr.Parent = tabControl1;
            tabControlPages(ml_awr);
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
        #endregion

        #region 数据备份
        private void 数据库备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bak_bf.Parent = tabControl1;
            tabControlPages(bak_bf);
        }

        private void dcwj_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = @"D:\";
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bcejwz.Text = dialog.SelectedPath;
            }
        }

        private void cxbming_Click(object sender, EventArgs e)
        {
            string sql = "select TABLE_NAME from dba_tables where owner='" + uername.ToUpper() + "'";
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
            dv.Sort = "TABLE_NAME asc";
            dt = dv.ToTable();
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.RowCount = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells["xh"].Value = i + 1;
                dataGridView3.Rows[i].Cells["ckbox"].Value =true;
                dataGridView3.Rows[i].Cells["tablename"].Value = dt.Rows[i]["TABLE_NAME"].ToString();             
            }
        }
        Process cmdExeExp = null;
        private void xpbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bcejwz.Text))
            {
                MessageBox.Show("选择备份文件夹地址");
                return;
            }
            cmdExeExp = new Process();//创建进程对象  
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"cmd.exe";//设定需要执行的命令  
            startInfo.Arguments = @"exp bdcdj_gx/gtis@orcl file = D:\bdcdj_gx.dmp  tables=(djf_dj_log,djf_dj_sj,djf_dj_sqr,djf_dj_ywxx,djt_dj_slsq,hrb_gx_json,hrb_gx_log,ktt_fw_c,ktt_fw_h,ktt_fw_ljz,ktt_fw_zrz,ktt_gzw,ktt_zdjbxx,ktt_zhjbxx,qlf_fw_fdcq_dz_xm,qlf_fw_fdcq_qfsyq,qlf_ql_cfdj,qlf_ql_dyaq,qlf_ql_dyiq,qlf_ql_hysyq,qlf_ql_jsydsyq,qlf_ql_nydsyq,qlf_ql_qtxgql,qlf_ql_tdsyq,qlf_ql_ygdj,qlf_ql_yydj,qlf_ql_zxdj,qlt_fw_fdcq_dz,qlt_fw_fdcq_yz,qlt_ql_gjzwsyq,qlt_ql_lq,zd_cflx,zd_djlx,zd_dybdclx,zd_dyfs,zd_fwjg,zd_fwlx,zd_fwxz,zd_fwyt,zd_gyfs,zd_hxjg,zd_hydb,zd_hysylxa,zd_hysylxb,zd_jzwzt,zd_lz,zd_mjdw,zd_qllx,zd_qlrlx,zd_qlrxz,zd_qlsdfs,zd_qlxz,zd_qszt,zd_sqlx,zd_wjmhdyt,zd_xmxz,zd_xmzt,zd_ygdjlx,zd_zdt,zd_zdtzm,zd_zjlx,ztt_gy_qlr) log = D:\\ExpData_bdcdj_gx.log";//“/C”表示执行完命令后马上退出  
            cmdExeExp.StartInfo = startInfo;
            try
            {
                cmdExeExp.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("请检查本地是否安装sqlplus工具!");
            }
        }

        #endregion

        private void 数据库还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bak_hy.Parent = tabControl1;
            tabControlPages(bak_hy);

        }



    }
}
