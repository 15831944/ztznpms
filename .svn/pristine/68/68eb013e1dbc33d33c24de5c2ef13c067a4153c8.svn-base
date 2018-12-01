using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.查询项目;
using ztznpms.UI.项目管理;

namespace ztznpms.UI.二维码
{
    public partial class FormSaoma : Form
    {
        //Office2007Form   
        //this.EnableGlass = false;
        public SerialPort sp1 = new SerialPort("COM3", 115200, Parity.None);
        private string lujing;
        private string leixing;
        private string gxid;
        public FormSaoma()
        {

            InitializeComponent();
            //事件注册
            sp1.DataReceived += ReceiveData;

        }

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {

            System.Threading.Thread.Sleep(100);
            byte[] m_recvBytes = new byte[sp1.BytesToRead];//定义缓冲区大小
            int result = sp1.Read(m_recvBytes, 0, m_recvBytes.Length);//从串口读取数据
            if (result <= 0)
                return;
            string str1 = Encoding.GetEncoding("UTF-8").GetString(m_recvBytes, 0, m_recvBytes.Length);//对数据进行转换
            this.Invoke
                (
                new EventHandler(
                    delegate
                    {
                        txt_xiangmumingcheng.Text = "";
                        txt_tuhao.Text = "";
                        txt_shebeiming.Text = "";
                        txt_mingcheng.Text = "";
                        txt_gonglinghao.Text = "";
                        combox_peopel.Text = "";
                        gx_ming.Text = "";
                        gx_shunxu.Text = "";
                        txt_Starttime.Text = "";
                        txt_Endtime.Text = "";
                        txt_caozuoren.Text = "";
                        combox_peopel.Text = "";
                        richTextBox2.Text = "";
                        richTextBox3.Text = "";

                        //调用委托，将值传给文本框
                        //string[] sArray = str1.Split(new char[] { '|' });
                        string[] sArray = str1.Split(new char[2] { '\r', '\n' });

                        System.Windows.Forms.Application.DoEvents();
                        Thread.Sleep(1000);

                        try
                        {
                            txt_xiangmumingcheng.Text = sArray[0];//项目名称
                            txt_gonglinghao.Text = sArray[1];//工作令号
                            //txt_shebeiming.Text = sArray[2];//设备名称
                            txt_tuhao.Text = sArray[2];//图号
                            txt_mingcheng.Text = sArray[3];//名称
                            gxid = sArray[4];//id序号标志
                            comb_gxzhuangtai.SelectedIndex = 0;
                            //System.Windows.Forms.Application.DoEvents();
                            //Thread.Sleep(1000);


                            string ssql = "select * from db_gongxu1 where 项目名称='" + txt_xiangmumingcheng.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "' and 序号='"+ gxid+"'";
                            DataTable dtt = SQLhelp.GetDataTable(ssql, CommandType.Text);

                            DataRow roww = dtt.Rows[0];
                            //txt_gonglinghao.Text = roww["工令号"].ToString();
                            txt_shebeiming.Text = roww["设备名称"].ToString();
                            txt_shuliang.Text = roww["数量"].ToString();


                            string sql1 = "select min(工序顺序) from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and 开始时间 is null and 序号='" + gxid + "'";//查询开始时间为空
                            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                            if (ret1 == "")//开始时间都不为空
                            {
                                //1、都结束了
                                string sql = "select max(工序顺序) from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and 序号='" + gxid + "'";
                                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));//最大工序

                                string sql2 = "select 结束时间 from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and 工序顺序='" + ret + "' and 序号='" + gxid + "'";
                                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));
                                if (ret2 != "")
                                {
                                    MessageBox.Show("该项目工序已经全部结束！", "提示");

                                    Formchaxunxiangxi form = new Formchaxunxiangxi();

                                    form.gxtuhao = txt_tuhao.Text;
                                    form.gxmingcheng1 = txt_mingcheng.Text;
                                    form.Show();
                                }
                                //2、还剩下最后一道工序没有结束
                                else
                                {
                                    string sql3 = "select * from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and  工序顺序='" + ret + "' and 序号='" + gxid + "'";
                                    DataTable dt = SQLhelp.GetDataTable(sql3, CommandType.Text);

                                    DataRow row = dt.Rows[0];

                                    txt_caozuoren.Text = row["负责人"].ToString();
                                    if(row["实际操作人"].ToString() == "")
                                    {
                                        combox_peopel.Text = txt_caozuoren.Text;
                                    }
                                    else
                                    {
                                        combox_peopel.Text = row["实际操作人"].ToString();
                                    }

                                    gx_jiage.Text = row["价格"].ToString();
                                    gx_ming.Text = row["工序名称"].ToString();
                                    gx_shunxu.Text = row["工序顺序"].ToString();
                                    txt_Starttime.Text = row["开始时间"].ToString();
                                    txt_Endtime.Text = row["结束时间"].ToString();
                                    richTextBox1.Text = row["工序内容"].ToString();
                                    richTextBox3.Text = row["工艺注意点"].ToString();

                                    panel1.Visible = true;

                                    if (txt_Starttime.Text == "" && txt_Endtime.Text == "")
                                    {
                                        btn_SZend.Enabled = false;
                                        btn_SZstart.Enabled = true;
                                    }
                                    if (txt_Starttime.Text != "" && txt_Endtime.Text == "")
                                    {
                                        btn_SZstart.Enabled = false;
                                        btn_SZend.Enabled = true;
                                    }

                                    btn_BC.Enabled = false;

                                }

                            }
                            else//查到开始时间有为空的
                            {
                                if (ret1 == "1")//查到开始时间为null的工序顺序为"1"时，表示该工序还未开始
                                {

                                    string sql3 = "select * from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and  工序顺序='" + 1 + "' and 序号='" + gxid + "'";
                                    DataTable dt = SQLhelp.GetDataTable(sql3, CommandType.Text);

                                    DataRow row = dt.Rows[0];

                                    txt_caozuoren.Text = row["负责人"].ToString();
                                    if (row["实际操作人"].ToString() == "")
                                    {
                                        combox_peopel.Text = txt_caozuoren.Text;
                                    }
                                    else
                                    {
                                        combox_peopel.Text = row["实际操作人"].ToString();
                                    }
                                    gx_jiage.Text = row["价格"].ToString();
                                    gx_ming.Text = row["工序名称"].ToString();
                                    gx_shunxu.Text = row["工序顺序"].ToString();
                                    txt_Starttime.Text = row["开始时间"].ToString();
                                    txt_Endtime.Text = row["结束时间"].ToString();
                                    richTextBox1.Text = row["工序内容"].ToString();
                                    richTextBox3.Text = row["工艺注意点"].ToString();

                                    panel1.Visible = false;

                                    if (txt_Starttime.Text == "" && txt_Endtime.Text == "")
                                    {
                                        btn_SZend.Enabled = false;
                                        btn_SZstart.Enabled = true;
                                    }
                                    if (txt_Starttime.Text != "" && txt_Endtime.Text == "")
                                    {
                                        btn_SZstart.Enabled = false;
                                        btn_SZend.Enabled = true;
                                    }

                                    btn_BC.Enabled = false;

                                }
                                else//最小顺序不为1，即工序已经开始,再判断上一道工序是否结束
                                {
                                    int shunxu1 = Convert.ToInt32(ret1);
                                    int shunxu2 = shunxu1 - 1;
                                    string sql4 = "select 结束时间 from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and  工序顺序='" + shunxu2 + "' and 序号='" + gxid + "'";
                                    string ret4 = Convert.ToString(SQLhelp.ExecuteScalar(sql4, CommandType.Text));

                                    if (ret4 != "")//上一道工序结束
                                    {

                                        string sql5 = "select * from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and  工序顺序='" + shunxu1 + "' and 序号='" + gxid + "'";
                                        DataTable dt = SQLhelp.GetDataTable(sql5, CommandType.Text);

                                        DataRow row = dt.Rows[0];

                                        txt_caozuoren.Text = row["负责人"].ToString();
                                        if (row["实际操作人"].ToString() == "")
                                        {
                                            combox_peopel.Text = txt_caozuoren.Text;
                                        }
                                        else
                                        {
                                            combox_peopel.Text = row["实际操作人"].ToString();
                                        }
                                        gx_jiage.Text = row["价格"].ToString();
                                        gx_ming.Text = row["工序名称"].ToString();
                                        gx_shunxu.Text = row["工序顺序"].ToString();
                                        txt_Starttime.Text = row["开始时间"].ToString();
                                        txt_Endtime.Text = row["结束时间"].ToString();
                                        richTextBox1.Text = row["工序内容"].ToString();
                                        richTextBox3.Text = row["工艺注意点"].ToString();

                                        panel1.Visible = false;

                                        if (txt_Starttime.Text == "" && txt_Endtime.Text == "")
                                        {
                                            btn_SZend.Enabled = false;
                                            btn_SZstart.Enabled = true;
                                        }
                                        if (txt_Starttime.Text != "" && txt_Endtime.Text == "")
                                        {
                                            btn_SZstart.Enabled = false;
                                            btn_SZend.Enabled = true;
                                        }

                                        btn_BC.Enabled = false;

                                    }
                                    else//上一道工序没有结束
                                    {

                                        string sql6 = "select * from db_gongxu1 where 图号 = '" + txt_tuhao.Text + "' and 名称 = '" + txt_mingcheng.Text + "' and 项目名称 = '" + txt_xiangmumingcheng.Text + "' and  工序顺序='" + shunxu2 + "' and 序号='" + gxid + "'";
                                        DataTable dt = SQLhelp.GetDataTable(sql6, CommandType.Text);

                                        DataRow row = dt.Rows[0];

                                        txt_caozuoren.Text = row["负责人"].ToString();
                                        if (row["实际操作人"].ToString() == "")
                                        {
                                            combox_peopel.Text = txt_caozuoren.Text;
                                        }
                                        else
                                        {
                                            combox_peopel.Text = row["实际操作人"].ToString();
                                        }
                                        gx_jiage.Text = row["价格"].ToString();
                                        gx_ming.Text = row["工序名称"].ToString();
                                        gx_shunxu.Text = row["工序顺序"].ToString();
                                        txt_Starttime.Text = row["开始时间"].ToString();
                                        txt_Endtime.Text = row["结束时间"].ToString();
                                        richTextBox1.Text = row["工序内容"].ToString();
                                        richTextBox3.Text = row["工艺注意点"].ToString();

                                        panel1.Visible = true;

                                        if (txt_Starttime.Text == "" && txt_Endtime.Text == "")
                                        {
                                            btn_SZend.Enabled = false;
                                            btn_SZstart.Enabled = true;
                                        }
                                        if (txt_Starttime.Text != "" && txt_Endtime.Text == "")
                                        {
                                            btn_SZstart.Enabled = false;
                                            btn_SZend.Enabled = true;
                                        }

                                        btn_BC.Enabled = false;
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }


                        sp1.DiscardInBuffer();
                    }
                    )
                    );

            //int n = sp1.BytesToRead;
            //byte[] buf = new byte[n];
            //sp1.Read(buf, 0, n);
            //string str = Encoding.GetEncoding("UTF-8").GetString(buf);
            //this.Invoke
            //    (
            //    new EventHandler(
            //        delegate
            //        {


            //            //string str1 = Encoding.GetEncodings("UTF-8").
            //            //string[] sArray = str.Split(new char[2] { '\r', '\n' });
            //            string[] sArray = str.Split(new char[] { '|' });

            //            System.Windows.Forms.Application.DoEvents();
            //            Thread.Sleep(1000);

            //            try
            //            {
            //                txt_jiagong.Text = sArray[0];//加工单位
            //                txt_tuhao.Text = sArray[1];//图号
            //                txt_mingcheng.Text = sArray[2];//名称


            //                System.Windows.Forms.Application.DoEvents();
            //                Thread.Sleep(1000);


        }

        private void FormSaoma_Load(object sender, EventArgs e)
        {

            if (txt_Starttime.Text == "" && txt_Endtime.Text == "")
            {
                btn_SZend.Enabled = false;
                btn_SZstart.Enabled = true;
            }
            //if (txt_Starttime.Text != "" && txt_Endtime.Text == "")
            //{
            //    btn_SZstart.Enabled = false;
            //    btn_SZend.Enabled = true;
            //}

            btn_BC.Enabled = false;

            if (txt_xiangmumingcheng.Text == "" || txt_mingcheng.Text == "" || txt_tuhao.Text == "" || txt_shebeiming.Text == "" || txt_gonglinghao.Text == "")
            {
                btn_SZstart.Enabled = false;
            }

            //string s1 = "select * from db_chejianrenyuan";
            //DataTable cr = SQLhelp.GetDataTable(s1, CommandType.Text);

            //foreach (DataRow dr in cr.Rows)
            //{
            //    this.combox_peopel.Items.Add(dr["机加车间人员"].ToString());
            //}

            combox_peopel.Items.Clear();
            string sql1 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            foreach (DataRow row in dt1.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (combox_peopel.Items.Cast<object>().All(x => x.ToString() != a))
                    combox_peopel.Items.Add(a);
            }

            comb_gxzhuangtai.Items.Add("当前工序结束");
            comb_gxzhuangtai.Items.Add("暂停");
            comb_gxzhuangtai.SelectedIndex = 0;

            try
            {
                sp1.Open();
            }
            catch
            {
                MessageBox.Show("请检查扫码枪是否已连接上PC端？", "提示");
                //this.Close();
            }

        }

        private string panduan(string a,string b,string c)
        {
            string sql = "select 工序名称 from db_gongxu1 where getdate()>= 开始时间 and 结束时间 IS NULL and 项目名称='" + b + "' and 设备名称='" + c + "' and 图号='" + a + "' and 序号='" + gxid + "'";
            string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            return result;
        }
        private void btn_QX_Click_1(object sender, EventArgs e)
        {
            this.Close();
            if (sp1.IsOpen)
            {
                sp1.Close();
            }
        }


        private void FormSaoma_FormClosed(object sender, FormClosedEventArgs e)
        {
            //webBrowser1.Dispose();

            if (sp1.IsOpen)
            {
                sp1.Close();
            }
        }

        #region 打开webBrowser
        //bool live = true;


        //System.Threading.Timer t = new System.Threading.Timer(
        //    m => this.Invoke((Action)delegate
        //    {
        //        if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
        //        {
        //            webBrowser1.Stop();//终止掉
        //                    }
        //    }), null, 100, System.Threading.Timeout.Infinite);//30秒检测


        //webBrowser1.ProgressChanged += delegate { live = true; };
        //System.Threading.Timer t = new System.Threading.Timer(
        //    m => this.Invoke((Action)delegate
        //    {
        //        //还没加载完，并且连续30秒没有进度增加了。
        //        if (!live && webBrowser1.ReadyState != WebBrowserReadyState.Complete) webBrowser1.Stop();//终止掉
        //        live = false;//检查过就设置为false，如果下一次进入循环，还是false表明进度没增加，可以考虑结束打开了
        //    }), null, 0, 1000);//30秒检测，我们不检查是否结束了。而是判断是否仍然在尝试打开，这样如果网速慢就不至于错判
        #endregion

        private void btn_Open_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (sp1.IsOpen)
                {
                    MessageBox.Show("端口打开成功！");
                }
                else
                {
                    sp1.Open();
                }
            }

            catch
            {
                MessageBox.Show("请先连接扫码枪！");
                return;
            }
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            if (sp1.IsOpen)
            {
                sp1.Close();
                MessageBox.Show("端口关闭！");
            }
            else
            {
                MessageBox.Show("端口还没打开！");
            }
        }

        /// <summary>
        /// 打开图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string SQL1 = "select 附件名称 from db_xiangmu where 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "'";
                string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                if (ret1 != "")
                {
                    string chaxun11 = "select 附件类型 from db_xiangmu where  附件名称='" + ret1 + "' and 名称='" + txt_mingcheng.Text + "'and 图号='" + txt_tuhao.Text + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                    byte[] mypdffile = null;
                    string sqlfujian= "select 附件 from db_xiangmu where 图号='" + txt_tuhao.Text + "'and 名称='" + txt_mingcheng.Text + "' and  附件名称='" + ret1 + "' ";
                    mypdffile = SQLhelp.duqu(sqlfujian, CommandType.Text);

                    //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";

                    //SqlConnection con = new SqlConnection(ConStr);
                    //SqlCommand cmd = new SqlCommand("", con);
                    //cmd.CommandText = "select 附件 from db_xiangmu where 图号='" + txt_tuhao.Text + "'and 名称='" + txt_mingcheng.Text + "' and  附件名称='" + ret1 + "' ";
                    //con.Open();

                    //SqlDataReader dr = cmd.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    mypdffile = (byte[])dr.GetValue(0);
                    //}
                    //con.Close();
                    //this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        string aaaa = System.Environment.CurrentDirectory;
                        lujing = aaaa + "\\" + txt_mingcheng.Text + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();
                    }
                    catch
                    {

                    }
                    this.Cursor = Cursors.Default;

                    //打开图纸PDF
                    //System.Diagnostics.Process.Start(lujing);
                    txt_lujin.Text = lujing;


                    if (webBrowser1 != null && !webBrowser1.IsDisposed)
                    {
                        this.webBrowser1.Navigate(txt_lujin.Text);
                    }


                }
                else
                {
                    MessageBox.Show("技术部还未上传该图纸！");
                    return;
                }
            }
            catch
            {

            }
        }

        private void btn_SZstart_Click_1(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            txt_Starttime.Text = Convert.ToString(time);
            btn_BC.Enabled = true;
        }

        private void btn_SZend_Click_1(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            txt_Endtime.Text = Convert.ToString(time);
            btn_BC.Enabled = true;
        }

        private void comb_gxzhuangtai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comb_gxzhuangtai.Text.Trim() == "当前工序结束")
            {
                richTextBox2.Enabled = false;
            }
            if (comb_gxzhuangtai.Text.Trim() == "暂停")
            {
                richTextBox2.Enabled = true;
            }
        }

        private void comb_gxzhuangtai_TextChanged_1(object sender, EventArgs e)
        {
            if (comb_gxzhuangtai.Text.Trim() == "当前工序结束")
            {
                btn_SZend.Enabled = true;
                richTextBox2.Text = "";
            }
            if (comb_gxzhuangtai.Text.Trim() == "暂停")
            {
                btn_SZend.Enabled = false;
                txt_Endtime.Text = "";
                btn_BC.Enabled = true;
            }
        }

        private void btn_BC_Click(object sender, EventArgs e)
        {
            DialogResult RSS = MessageBox.Show(this, "确定要提交吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:

                    if (txt_Endtime.Text == "" && comb_gxzhuangtai.Text == "当前工序结束")
                    {
                        string sql1 = "update db_gongxu1 set 开始时间='" + txt_Starttime.Text + "',实际操作人='" + combox_peopel.Text.Trim() + "' where 项目名称='" + txt_xiangmumingcheng.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "' and 工序顺序='" + gx_shunxu.Text + "' and 序号='" + gxid + "'";
                        string ret1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));
                        if (ret1 != "")
                        {
                            MessageBox.Show("开始时间记录成功!", "提示");

                            btn_BC.Enabled = false;
                            btn_SZstart.Enabled = false;

                            #region 更新db_xiangmu 和tb_caigouliaodan 当前状态

                            string sql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,剩余加工时间,生产检验结果,检验结果备注,检验记录表上传时间 from db_xiangmu where 项目名称='" + txt_xiangmumingcheng.Text + "'and 设备名称='" + txt_shebeiming.Text + "'and 工作令号='" + txt_gonglinghao.Text + "' and 序号='" + gxid + "'";
                            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                            //Thread thread = (new Thread(new ThreadStart(() =>
                            //{

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                                DataRow dr = dt.Rows[i];

                                string strSql1 = "select 工序顺序 from db_gongxu1 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                                if (exist != "")
                                {
                                    string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                                    string strSql = "select * from db_gongxu1 where getdate() > 开始时间 and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                                    string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                                    if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                                    {
                                        dt.Rows[i]["目前到达工序"] = "尚未开始";
                                        string SQl1 = "update db_xiangmu set 目前到达工序='尚未开始' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

        /* 更新项目管理中的自制件的当前状态 */
                                        ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                        //string SQL2 = "update tb_caigouliaodan set 当前状态='尚未开始' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                        //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));


                                    }
                                    else  //开始进行项目
                                    {
                                        if (panduan(a, dr["项目名称"].ToString(), dr["设备名称"].ToString()) != "")//正在进行某项工序
                                        {
                                            string s1 = "select max(工序顺序) from db_gongxu1 where getdate() > 开始时间 and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号 = '" + a + "' and 序号='"+ gxid +"'";
                                            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                                            int aa = Convert.ToInt32(shunxu1);
                                            string s2 = "select 工序名称 from db_gongxu1 where 工序顺序 = '" + aa + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号= '" + a + "' and 序号='" + gxid + "'";
                                            string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                                            dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                                            string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                                            string SQl2 = "update db_xiangmu set 目前到达工序='" + gx_1 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));


                                            ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                            //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                            //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                                        }
                                        else//工序完成，正在流转，即将进行入下一道工序
                                        {
                                            string s3 = "select min(工序顺序) from db_gongxu1 where 结束时间 IS NULL and 开始时间 IS NULL  and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";
                                            string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                                            if (shunxu2 != "")
                                            {
                                                string s4 = "select 工序名称 from db_gongxu1 where 工序顺序 ='" + shunxu2 + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";
                                                string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                                dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                                string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                                string SQl3 = "update db_xiangmu set 目前到达工序='" + gx_2 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));


                                                ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                            }
                                            else
                                            {
                                                dt.Rows[i]["目前到达工序"] = "全部结束";
                                                string gx_3 = "全部结束";

                                                string SQl4 = "update db_xiangmu set 目前到达工序='" + gx_3 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));


                                                ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                            }



                                        }

                                    }

                                }
                                else
                                {
                                    dt.Rows[i]["目前到达工序"] = "未设置工序";
                                    string gx_4 = "未设置工序";

                                    string SQl5 = "update db_xiangmu set 目前到达工序='" + gx_4 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                                }


                            }

                            #endregion

                            Formchaxunxiangxi form = new Formchaxunxiangxi();

                            form.gxtuhao = txt_tuhao.Text;
                            form.gxmingcheng1 = txt_mingcheng.Text;
                            form.Show();

                        }
                        else
                        {
                            MessageBox.Show("开始时间记录取消!", "提示");
                        }
                    }
                    if (txt_Starttime.Text != "")
                    {
                        if (txt_Endtime.Text != "" && comb_gxzhuangtai.Text.Trim() == "当前工序结束")
                        {
                            if (MessageBox.Show("请再三确认是否已完成本人所负责的工序，此次提交工序结束时间只有一次机会！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {

                                string sql = "update db_gongxu1 set 开始时间='" + txt_Starttime.Text + "', 结束时间='" + txt_Endtime.Text + "', 实际操作人='" + combox_peopel.Text.Trim() + "' where 项目名称='" + txt_xiangmumingcheng.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "' and 工序顺序='" + gx_shunxu.Text + "' and 序号='" + gxid + "'";
                                string ret = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));
                                if (ret != "")
                                {
                                    MessageBox.Show("结束时间记录成功!", "提示");
                                    //if (sp1.IsOpen)
                                    //{
                                    //    sp1.Close();
                                    //}

                                    btn_BC.Enabled = false;
                                    btn_SZstart.Enabled = false;
                                    btn_SZend.Enabled = false;

                                    #region 更新db_xiangmu 和tb_caigouliaodan 当前状态

                                    string sql1 = "select id,项目名称,工作令号,设备名称,编码,图号,名称,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,剩余加工时间,生产检验结果,检验结果备注,检验记录表上传时间 from db_xiangmu where 项目名称='" + txt_xiangmumingcheng.Text + "'and 设备名称='" + txt_shebeiming.Text + "'and 工作令号='" + txt_gonglinghao.Text + "' and 序号='" + gxid + "'";
                                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                                    //Thread thread = (new Thread(new ThreadStart(() =>
                                    //{

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                                        DataRow dr = dt.Rows[i];

                                        string strSql1 = "select 工序顺序 from db_gongxu1 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and  图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                                        string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                                        if (exist != "")
                                        {
                                            string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                                            string strSql = "select * from db_gongxu1 where getdate() > 开始时间 and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                                            string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                                            if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                                            {
                                                dt.Rows[i]["目前到达工序"] = "尚未开始";
                                                string SQl1 = "update db_xiangmu set 目前到达工序='尚未开始' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));


                                                ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                //string SQL2 = "update tb_caigouliaodan set 当前状态='尚未开始' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));


                                            }
                                            else  //开始进行项目
                                            {
                                                if (panduan(a, dr["项目名称"].ToString(), dr["设备名称"].ToString()) != "")//正在进行某项工序
                                                {
                                                    string s1 = "select max(工序顺序) from db_gongxu1 where getdate() > 开始时间 and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号 = '" + a + "' and 序号='" + gxid + "'";
                                                    string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                                                    int aa = Convert.ToInt32(shunxu1);
                                                    string s2 = "select 工序名称 from db_gongxu1 where 工序顺序 = '" + aa + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号= '" + a + "' and 序号='" + gxid + "'";
                                                    string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                                                    dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                                                    string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                                                    string SQl2 = "update db_xiangmu set 目前到达工序='" + gx_1 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));


                                                    ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                    //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                    //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                                                }
                                                else//工序完成，正在流转，即将进行入下一道工序
                                                {
                                                    string s3 = "select min(工序顺序) from db_gongxu1 where 结束时间 IS NULL and 开始时间 IS NULL  and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";
                                                    string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                                                    if (shunxu2 != "")
                                                    {
                                                        string s4 = "select 工序名称 from db_gongxu1 where 工序顺序 ='" + shunxu2 + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";
                                                        string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                                        dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                                        string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                                        string SQl3 = "update db_xiangmu set 目前到达工序='" + gx_2 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                                                        ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                        //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                        //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                                    }
                                                    else
                                                    {
                                                        dt.Rows[i]["目前到达工序"] = "全部结束";
                                                        string gx_3 = "全部结束";

                                                        string SQl4 = "update db_xiangmu set 目前到达工序='" + gx_3 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));

                                                        ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                        //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                        //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                                    }



                                                }

                                            }

                                        }
                                        else
                                        {
                                            dt.Rows[i]["目前到达工序"] = "未设置工序";
                                            string gx_4 = "未设置工序";

                                            string SQl5 = "update db_xiangmu set 目前到达工序='" + gx_4 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                                        }


                                    }

                                    #endregion

                                    Formchaxunxiangxi form = new Formchaxunxiangxi();

                                    form.gxtuhao = txt_tuhao.Text;
                                    form.gxmingcheng1 = txt_mingcheng.Text;
                                    form.Show();
                                }
                                else
                                {
                                    MessageBox.Show("结束时间记录取消!", "提示");
                                }
                            }

                            btn_BC.Enabled = false;
                            btn_SZstart.Enabled = false;
                            btn_SZend.Enabled = false;
                        }

                        //暂停工序
                        if (txt_Endtime.Text == "" && comb_gxzhuangtai.Text.Trim() == "暂停")
                        {
                            btn_SZend.Enabled = false;
                            string str = "工序暂停了——>暂停原因：" + richTextBox2.Text;
                            if (richTextBox2.Text.Trim() == "")
                            {
                                MessageBox.Show("请填写工序暂停原因!", "提示");
                                return;
                            }
                            string sql = "update db_gongxu1 set 开始时间='" + txt_Starttime.Text + "', 实际操作人='" + combox_peopel.Text.Trim() + "' , 备注='" + str + "' where 项目名称='" + txt_xiangmumingcheng.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "' and 工序顺序='" + gx_shunxu.Text + "' and 序号='" + gxid + "'";// 结束时间='" + txt_Endtime.Text + "',
                            string ret = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));
                            if (ret != "")
                            {
                                MessageBox.Show("暂停工序成功!", "提示");
                                //if (sp1.IsOpen)
                                //{
                                //    sp1.Close();
                                //}

                                btn_BC.Enabled = false;
                                btn_SZstart.Enabled = false;
                                btn_SZend.Enabled = false;

                                #region 更新db_xiangmu 和tb_caigouliaodan 当前状态

                                string sql1 = "select id,项目名称,工作令号,设备名称,编码,图号,名称,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,剩余加工时间,生产检验结果,检验结果备注,检验记录表上传时间 from db_xiangmu where 项目名称='" + txt_xiangmumingcheng.Text + "'and 设备名称='" + txt_shebeiming.Text + "'and 工作令号='" + txt_gonglinghao.Text + "' and 序号='" + gxid + "'";
                                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                                //Thread thread = (new Thread(new ThreadStart(() =>
                                //{

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                                    DataRow dr = dt.Rows[i];

                                    string strSql1 = "select 工序顺序 from db_gongxu1 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                                    string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                                    if (exist != "")
                                    {
                                        string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                                        string strSql = "select * from db_gongxu1 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号='" + a + "' and 序号='" + gxid + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                                        string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                                        if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                                        {
                                            dt.Rows[i]["目前到达工序"] = "尚未开始";
                                            string SQl1 = "update db_xiangmu set 目前到达工序='尚未开始' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));


                                            ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                            //string SQL2 = "update tb_caigouliaodan set 当前状态='尚未开始' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                            //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));


                                        }
                                        else  //开始进行项目
                                        {
                                            if (panduan(a, dr["项目名称"].ToString(), dr["设备名称"].ToString()) != "")//正在进行某项工序
                                            {
                                                string s1 = "select max(工序顺序) from db_gongxu1 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号 = '" + a + "' and 序号='" + gxid + "'";
                                                string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                                                int aa = Convert.ToInt32(shunxu1);
                                                string s2 = "select 工序名称 from db_gongxu1 where 工序顺序 = '" + aa + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号= '" + a + "' and 序号='" + gxid + "'";
                                                string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                                                dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                                                string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                                                string SQl2 = "update db_xiangmu set 目前到达工序='" + gx_1 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));


                                                ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' id='"+ gxid +"'";
                                                //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                                            }
                                            else//工序完成，正在流转，即将进行入下一道工序
                                            {
                                                string s3 = "select min(工序顺序) from db_gongxu1 where 结束时间 IS NULL and 开始时间 IS NULL  and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";
                                                string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                                                if (shunxu2 != "")
                                                {
                                                    string s4 = "select 工序名称 from db_gongxu1 where 工序顺序 ='" + shunxu2 + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + a + "' and 序号='" + gxid + "'";
                                                    string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                                    dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                                    string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                                    string SQl3 = "update db_xiangmu set 目前到达工序='" + gx_2 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                                                    ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                    //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                    //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                                }
                                                else
                                                {
                                                    dt.Rows[i]["目前到达工序"] = "全部结束";
                                                    string gx_3 = "全部结束";

                                                    string SQl4 = "update db_xiangmu set 目前到达工序='" + gx_3 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));

                                                    ////对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                                    //string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + txt_xiangmumingcheng.Text + "' and 设备名称='" + txt_shebeiming.Text + "' and id='"+ gxid +"'";
                                                    //string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                                }



                                            }

                                        }

                                    }
                                    else
                                    {
                                        dt.Rows[i]["目前到达工序"] = "未设置工序";
                                        string gx_4 = "未设置工序";

                                        string SQl5 = "update db_xiangmu set 目前到达工序='" + gx_4 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "' and 序号='" + gxid + "'";
                                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                                    }


                                }

                                #endregion

                                Formchaxunxiangxi form = new Formchaxunxiangxi();

                                form.gxtuhao = txt_tuhao.Text;
                                form.gxmingcheng1 = txt_mingcheng.Text;
                                form.Show();
                            }
                            else
                            {
                                MessageBox.Show("暂停工序取消!", "提示");
                            }

                        }


                    }

                    break;
                case DialogResult.No:
                    break;
            }

        }

        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (this.tabControl1.SelectedIndex)
        //    {
        //        case 0:
        //            MessageBox.Show("tabPage1 is Selected");
        //            break;
        //        case 1:
        //            MessageBox.Show("tabPage2 is Selected");
        //            break;
        //    }
        //}
    }
}
