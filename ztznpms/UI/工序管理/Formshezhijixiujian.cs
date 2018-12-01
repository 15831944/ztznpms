using Aspose.Words;
using Aspose.Words.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ztznpms.Common;
using ztznpms.UI.二维码;
using ztznpms.UI.人员管理;
using 项目管理系统.个人管理;

namespace ztznpms.UI.工序管理
{
    public partial class Formshezhijixiujian : Form
    {
        string leixinglx;

        public string leixing;
        public string dingweiNumber;

        public string addxiangmuming;
        public string addgonglinghao;
        public string addtuhao;
        public string addmingcheng;
        public string xuhao;
        public string addyujiaoshijian;

        public string yonghu;
        Image image;

        string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;

        string Time1 = "08:00:00";
        string Time2 = "11:30:00";
        string Time3 = "12:30:00";
        string Time4 = "17:30:00";

        TimeSpan T1 = TimeSpan.Parse("08:00:00");
        TimeSpan T2 = TimeSpan.Parse("11:30:00");
        TimeSpan T3 = TimeSpan.Parse("12:30:00");
        TimeSpan T4 = TimeSpan.Parse("17:30:00");

        string shijian1 = "08:00:00";//上班
        string shijian2 = "12:00:00";//开始休息----4小时
        string shijian3 = "13:00:00";//结束休息
        string shijian4 = "17:30:00";//开始休息----4.5小时
        string shijian5 = "18:00:00";//结束休息
        string shijian6 = "20:00:00";//下班    -----2小时------>一共10.5小时

        string shijian7 = "23:30:00";
        string shijian8 = "00:30:00";

        //TimeSpan S1 = TimeSpan.Parse("08:00:00");
        //TimeSpan S2 = TimeSpan.Parse("12:00:00");
        //TimeSpan S3 = TimeSpan.Parse("13:00:00");
        //TimeSpan S4 = TimeSpan.Parse("17:30:00");
        //TimeSpan S5 = TimeSpan.Parse("18:00:00");
        //TimeSpan S6 = TimeSpan.Parse("20:00:00");

        //int taa5;
        DataTable dt;

        DataTable dtcailiao;

        public string shijian;

        public Formshezhijixiujian()
        {
            InitializeComponent();
        }

        private void Formshezhijixiujian_Load(object sender, EventArgs e)
        {
            DrawRowIndicator(gridView1, 30);

            dt = new DataTable();
            dt.Columns.Add("项目名称");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("图号");
            dt.Columns.Add("名称");
            dt.Columns.Add("原编号");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("材料名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");

            dtcailiao = new DataTable();
            dtcailiao.Columns.Add("项目名称");
            dtcailiao.Columns.Add("工作令号");
            dtcailiao.Columns.Add("设备名称");
            dtcailiao.Columns.Add("图号");
            dtcailiao.Columns.Add("名称");
            dtcailiao.Columns.Add("原编号");
            dtcailiao.Columns.Add("编码");
            dtcailiao.Columns.Add("型号");
            dtcailiao.Columns.Add("材料名称");
            dtcailiao.Columns.Add("单位");
            dtcailiao.Columns.Add("数量");

            if (leixing == "机修件零件")
            {
                com_bianzhiren.Items.Add("徐小明");
                com_bianzhiren.Items.Add("石炜");
                com_bianzhiren.Items.Add("袁天坤");


                DataTable a = xin(addtuhao, addmingcheng, addxiangmuming, addgonglinghao);
                DataRow b = a.Rows[0];
                txt_tuhao.Text = addtuhao;//加工内容
                txt_jiagong.Text = b[3].ToString();//客户名称
                txt_mingcheng.Text = b[4].ToString();//工件名称
                txt_gonglinghao.Text = b[8].ToString();//接单编号
                txt_danhao.Text = b[2].ToString();//部门

                DateTime qqq = Convert.ToDateTime(b[13]);
                txt_xiadanriqi.Text = qqq.ToString("yyyy.MM.dd");
                //txt_xiadanriqi.Text = DateTime.Now.ToString("yyyy.MM.dd"); //下单日期

                txt_jiaohuoriqi.Text = b[9].ToString();//交货日期
                txt_jiagongshuliang.Text = b[7].ToString();//加工数量

                //string ss1 = "select * from db_cailiao";
                //DataTable row1 = SQLhelp.GetDataTable(ss1, CommandType.Text);
                //foreach (DataRow dr1 in row1.Rows)
                //{
                //    this.com_cailiaocaizhi.Items.Add(dr1["材料"].ToString());
                //}

                //工序名称
                string s1 = "select * from db_gongxumingcheng";
                DataTable row = SQLhelp.GetDataTable(s1, CommandType.Text);
                foreach (DataRow dr in row.Rows)
                {
                    this.comboBox1.Items.Add(dr["工序名称"].ToString());
                    this.comboBox2.Items.Add(dr["工序名称"].ToString());
                    this.comboBox3.Items.Add(dr["工序名称"].ToString());
                    this.comboBox4.Items.Add(dr["工序名称"].ToString());
                    this.comboBox5.Items.Add(dr["工序名称"].ToString());
                    this.comboBox7.Items.Add(dr["工序名称"].ToString());
                    this.comboBox6.Items.Add(dr["工序名称"].ToString());
                    this.comboBox8.Items.Add(dr["工序名称"].ToString());
                    this.comboBox9.Items.Add(dr["工序名称"].ToString());
                    this.comboBox13.Items.Add(dr["工序名称"].ToString());
                    this.comboBox11.Items.Add(dr["工序名称"].ToString());
                    this.comboBox15.Items.Add(dr["工序名称"].ToString());
                    this.comboBox10.Items.Add(dr["工序名称"].ToString());
                    this.comboBox14.Items.Add(dr["工序名称"].ToString());
                    this.comboBox12.Items.Add(dr["工序名称"].ToString());
                    this.comboBox16.Items.Add(dr["工序名称"].ToString());
                    this.comboBox17.Items.Add(dr["工序名称"].ToString());
                    this.comboBox19.Items.Add(dr["工序名称"].ToString());
                    this.comboBox18.Items.Add(dr["工序名称"].ToString());
                    this.comboBox20.Items.Add(dr["工序名称"].ToString());
                    this.comboBox46.Items.Add(dr["工序名称"].ToString());
                    this.comboBox47.Items.Add(dr["工序名称"].ToString());
                    this.comboBox48.Items.Add(dr["工序名称"].ToString());
                    this.comboBox49.Items.Add(dr["工序名称"].ToString());
                    this.comboBox50.Items.Add(dr["工序名称"].ToString());

                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;
                    comboBox7.Enabled = false;
                    comboBox6.Enabled = false;
                    comboBox8.Enabled = false;
                    comboBox9.Enabled = false;
                    comboBox13.Enabled = false;
                    comboBox11.Enabled = false;
                    comboBox15.Enabled = false;
                    comboBox10.Enabled = false;
                    comboBox14.Enabled = false;
                    comboBox12.Enabled = false;
                    comboBox16.Enabled = false;
                    comboBox17.Enabled = false;
                    comboBox19.Enabled = false;
                    comboBox18.Enabled = false;
                    comboBox20.Enabled = false;
                    comboBox46.Enabled = false;
                    comboBox47.Enabled = false;
                    comboBox48.Enabled = false;
                    comboBox49.Enabled = false;
                    comboBox50.Enabled = false;

                    richTextBox1.Enabled = false;
                    richTextBox9.Enabled = false;
                    richTextBox10.Enabled = false;
                    richTextBox11.Enabled = false;
                    richTextBox12.Enabled = false;
                    richTextBox13.Enabled = false;
                    richTextBox14.Enabled = false;
                    richTextBox15.Enabled = false;
                    richTextBox16.Enabled = false;
                    richTextBox17.Enabled = false;
                    richTextBox18.Enabled = false;
                    richTextBox19.Enabled = false;
                    richTextBox2.Enabled = false;
                    richTextBox20.Enabled = false;
                    richTextBox3.Enabled = false;
                    richTextBox4.Enabled = false;
                    richTextBox5.Enabled = false;
                    richTextBox6.Enabled = false;
                    richTextBox7.Enabled = false;
                    richTextBox8.Enabled = false;
                    richTextBox22.Enabled = false;
                    richTextBox23.Enabled = false;
                    richTextBox24.Enabled = false;
                    richTextBox25.Enabled = false;
                    richTextBox26.Enabled = false;

                    richTextBox27.Enabled = false;
                    richTextBox28.Enabled = false;
                    richTextBox29.Enabled = false;
                    richTextBox30.Enabled = false;
                    richTextBox31.Enabled = false;
                    richTextBox32.Enabled = false;
                    richTextBox33.Enabled = false;
                    richTextBox34.Enabled = false;
                    richTextBox35.Enabled = false;
                    richTextBox36.Enabled = false;
                    richTextBox37.Enabled = false;
                    richTextBox38.Enabled = false;
                    richTextBox39.Enabled = false;
                    richTextBox40.Enabled = false;
                    richTextBox41.Enabled = false;
                    richTextBox42.Enabled = false;
                    richTextBox43.Enabled = false;
                    richTextBox44.Enabled = false;
                    richTextBox45.Enabled = false;
                    richTextBox46.Enabled = false;
                    richTextBox47.Enabled = false;
                    richTextBox48.Enabled = false;
                    richTextBox49.Enabled = false;
                    richTextBox50.Enabled = false;
                    richTextBox51.Enabled = false;
                }

                //工序负责人
                string s11 = "select * from db_chejianrenyuan";
                DataTable cr = SQLhelp.GetDataTable(s11, CommandType.Text);

                foreach (DataRow dr in cr.Rows)
                {
                    this.comboBox21.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox22.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox23.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox24.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox25.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox26.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox27.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox28.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox29.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox30.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox31.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox32.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox33.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox34.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox35.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox36.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox37.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox38.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox39.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox40.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox41.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox42.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox43.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox44.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox45.Items.Add(dr["机加车间人员"].ToString());

                    comboBox21.Enabled = false;
                    comboBox22.Enabled = false;
                    comboBox23.Enabled = false;
                    comboBox24.Enabled = false;
                    comboBox25.Enabled = false;
                    comboBox26.Enabled = false;
                    comboBox27.Enabled = false;
                    comboBox28.Enabled = false;
                    comboBox29.Enabled = false;
                    comboBox30.Enabled = false;
                    comboBox31.Enabled = false;
                    comboBox32.Enabled = false;
                    comboBox33.Enabled = false;
                    comboBox34.Enabled = false;
                    comboBox35.Enabled = false;
                    comboBox36.Enabled = false;
                    comboBox37.Enabled = false;
                    comboBox38.Enabled = false;
                    comboBox39.Enabled = false;
                    comboBox40.Enabled = false;
                    comboBox41.Enabled = false;
                    comboBox42.Enabled = false;
                    comboBox43.Enabled = false;
                    comboBox44.Enabled = false;
                    comboBox45.Enabled = false;

                    shebei1.Enabled = false;
                    shebei2.Enabled = false;
                    shebei3.Enabled = false;
                    shebei4.Enabled = false;
                    shebei5.Enabled = false;
                    shebei6.Enabled = false;
                    shebei7.Enabled = false;
                    shebei8.Enabled = false;
                    shebei9.Enabled = false;
                    shebei10.Enabled = false;
                    shebei11.Enabled = false;
                    shebei12.Enabled = false;
                    shebei13.Enabled = false;
                    shebei14.Enabled = false;
                    shebei15.Enabled = false;
                    shebei16.Enabled = false;
                    shebei17.Enabled = false;
                    shebei18.Enabled = false;
                    shebei19.Enabled = false;
                    shebei20.Enabled = false;
                    shebei21.Enabled = false;
                    shebei22.Enabled = false;
                    shebei23.Enabled = false;
                    shebei24.Enabled = false;
                    shebei25.Enabled = false;
                }

                startload();

                CodeReplay();//二维码显示

                shebeiload();
            }

            if(leixing == "机修件组件")
            {
                com_bianzhiren.Items.Add("徐小明");
                com_bianzhiren.Items.Add("石炜");
                com_bianzhiren.Items.Add("袁天坤");

                DataTable a = xin1(xuhao);
                DataRow b = a.Rows[0];
                txt_tuhao.Text = b[8].ToString();//加工内容
                txt_jiagong.Text = b[7].ToString();//客户名称
                txt_mingcheng.Text = b[9].ToString();//工件名称
                txt_gonglinghao.Text = b[5].ToString();//接单编号
                txt_danhao.Text = b[1].ToString();//部门

                DateTime qqq = Convert.ToDateTime(b[3]);
                txt_xiadanriqi.Text = qqq.ToString("yyyy.MM.dd");
                //txt_xiadanriqi.Text = DateTime.Now.ToString("yyyy.MM.dd"); //下单日期

                string sql1 = "select 预交时间 from tb_caigouliaodan where id='"+ dingweiNumber +"'";
                string ret1 = Convert.ToString(SQLhelp.ExecuteScalar1(sql1, CommandType.Text));
                if(ret1 != "")
                {
                    txt_jiaohuoriqi.Text = ret1;//交货日期
                }

                txt_jiagongshuliang.Text = b[11].ToString();//加工数量

                //string ss1 = "select * from db_cailiao";
                //DataTable row1 = SQLhelp.GetDataTable(ss1, CommandType.Text);
                //foreach (DataRow dr1 in row1.Rows)
                //{
                //    this.com_cailiaocaizhi.Items.Add(dr1["材料"].ToString());
                //}

                //工序名称
                string s1 = "select * from db_gongxumingcheng";
                DataTable row = SQLhelp.GetDataTable(s1, CommandType.Text);
                foreach (DataRow dr in row.Rows)
                {
                    this.comboBox1.Items.Add(dr["工序名称"].ToString());
                    this.comboBox2.Items.Add(dr["工序名称"].ToString());
                    this.comboBox3.Items.Add(dr["工序名称"].ToString());
                    this.comboBox4.Items.Add(dr["工序名称"].ToString());
                    this.comboBox5.Items.Add(dr["工序名称"].ToString());
                    this.comboBox7.Items.Add(dr["工序名称"].ToString());
                    this.comboBox6.Items.Add(dr["工序名称"].ToString());
                    this.comboBox8.Items.Add(dr["工序名称"].ToString());
                    this.comboBox9.Items.Add(dr["工序名称"].ToString());
                    this.comboBox13.Items.Add(dr["工序名称"].ToString());
                    this.comboBox11.Items.Add(dr["工序名称"].ToString());
                    this.comboBox15.Items.Add(dr["工序名称"].ToString());
                    this.comboBox10.Items.Add(dr["工序名称"].ToString());
                    this.comboBox14.Items.Add(dr["工序名称"].ToString());
                    this.comboBox12.Items.Add(dr["工序名称"].ToString());
                    this.comboBox16.Items.Add(dr["工序名称"].ToString());
                    this.comboBox17.Items.Add(dr["工序名称"].ToString());
                    this.comboBox19.Items.Add(dr["工序名称"].ToString());
                    this.comboBox18.Items.Add(dr["工序名称"].ToString());
                    this.comboBox20.Items.Add(dr["工序名称"].ToString());
                    this.comboBox46.Items.Add(dr["工序名称"].ToString());
                    this.comboBox47.Items.Add(dr["工序名称"].ToString());
                    this.comboBox48.Items.Add(dr["工序名称"].ToString());
                    this.comboBox49.Items.Add(dr["工序名称"].ToString());
                    this.comboBox50.Items.Add(dr["工序名称"].ToString());

                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;
                    comboBox7.Enabled = false;
                    comboBox6.Enabled = false;
                    comboBox8.Enabled = false;
                    comboBox9.Enabled = false;
                    comboBox13.Enabled = false;
                    comboBox11.Enabled = false;
                    comboBox15.Enabled = false;
                    comboBox10.Enabled = false;
                    comboBox14.Enabled = false;
                    comboBox12.Enabled = false;
                    comboBox16.Enabled = false;
                    comboBox17.Enabled = false;
                    comboBox19.Enabled = false;
                    comboBox18.Enabled = false;
                    comboBox20.Enabled = false;
                    comboBox46.Enabled = false;
                    comboBox47.Enabled = false;
                    comboBox48.Enabled = false;
                    comboBox49.Enabled = false;
                    comboBox50.Enabled = false;

                    richTextBox1.Enabled = false;
                    richTextBox9.Enabled = false;
                    richTextBox10.Enabled = false;
                    richTextBox11.Enabled = false;
                    richTextBox12.Enabled = false;
                    richTextBox13.Enabled = false;
                    richTextBox14.Enabled = false;
                    richTextBox15.Enabled = false;
                    richTextBox16.Enabled = false;
                    richTextBox17.Enabled = false;
                    richTextBox18.Enabled = false;
                    richTextBox19.Enabled = false;
                    richTextBox2.Enabled = false;
                    richTextBox20.Enabled = false;
                    richTextBox3.Enabled = false;
                    richTextBox4.Enabled = false;
                    richTextBox5.Enabled = false;
                    richTextBox6.Enabled = false;
                    richTextBox7.Enabled = false;
                    richTextBox8.Enabled = false;
                    richTextBox22.Enabled = false;
                    richTextBox23.Enabled = false;
                    richTextBox24.Enabled = false;
                    richTextBox25.Enabled = false;
                    richTextBox26.Enabled = false;

                    richTextBox27.Enabled = false;
                    richTextBox28.Enabled = false;
                    richTextBox29.Enabled = false;
                    richTextBox30.Enabled = false;
                    richTextBox31.Enabled = false;
                    richTextBox32.Enabled = false;
                    richTextBox33.Enabled = false;
                    richTextBox34.Enabled = false;
                    richTextBox35.Enabled = false;
                    richTextBox36.Enabled = false;
                    richTextBox37.Enabled = false;
                    richTextBox38.Enabled = false;
                    richTextBox39.Enabled = false;
                    richTextBox40.Enabled = false;
                    richTextBox41.Enabled = false;
                    richTextBox42.Enabled = false;
                    richTextBox43.Enabled = false;
                    richTextBox44.Enabled = false;
                    richTextBox45.Enabled = false;
                    richTextBox46.Enabled = false;
                    richTextBox47.Enabled = false;
                    richTextBox48.Enabled = false;
                    richTextBox49.Enabled = false;
                    richTextBox50.Enabled = false;
                    richTextBox51.Enabled = false;
                }

                //工序负责人
                string s11 = "select * from db_chejianrenyuan";
                DataTable cr = SQLhelp.GetDataTable(s11, CommandType.Text);

                foreach (DataRow dr in cr.Rows)
                {
                    this.comboBox21.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox22.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox23.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox24.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox25.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox26.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox27.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox28.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox29.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox30.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox31.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox32.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox33.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox34.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox35.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox36.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox37.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox38.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox39.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox40.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox41.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox42.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox43.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox44.Items.Add(dr["机加车间人员"].ToString());
                    this.comboBox45.Items.Add(dr["机加车间人员"].ToString());

                    comboBox21.Enabled = false;
                    comboBox22.Enabled = false;
                    comboBox23.Enabled = false;
                    comboBox24.Enabled = false;
                    comboBox25.Enabled = false;
                    comboBox26.Enabled = false;
                    comboBox27.Enabled = false;
                    comboBox28.Enabled = false;
                    comboBox29.Enabled = false;
                    comboBox30.Enabled = false;
                    comboBox31.Enabled = false;
                    comboBox32.Enabled = false;
                    comboBox33.Enabled = false;
                    comboBox34.Enabled = false;
                    comboBox35.Enabled = false;
                    comboBox36.Enabled = false;
                    comboBox37.Enabled = false;
                    comboBox38.Enabled = false;
                    comboBox39.Enabled = false;
                    comboBox40.Enabled = false;
                    comboBox41.Enabled = false;
                    comboBox42.Enabled = false;
                    comboBox43.Enabled = false;
                    comboBox44.Enabled = false;
                    comboBox45.Enabled = false;

                    shebei1.Enabled = false;
                    shebei2.Enabled = false;
                    shebei3.Enabled = false;
                    shebei4.Enabled = false;
                    shebei5.Enabled = false;
                    shebei6.Enabled = false;
                    shebei7.Enabled = false;
                    shebei8.Enabled = false;
                    shebei9.Enabled = false;
                    shebei10.Enabled = false;
                    shebei11.Enabled = false;
                    shebei12.Enabled = false;
                    shebei13.Enabled = false;
                    shebei14.Enabled = false;
                    shebei15.Enabled = false;
                    shebei16.Enabled = false;
                    shebei17.Enabled = false;
                    shebei18.Enabled = false;
                    shebei19.Enabled = false;
                    shebei20.Enabled = false;
                    shebei21.Enabled = false;
                    shebei22.Enabled = false;
                    shebei23.Enabled = false;
                    shebei24.Enabled = false;
                    shebei25.Enabled = false;
                }

                startload();

                CodeReplay();//二维码显示

                shebeiload();
            }
            
        }
        public void DrawRowIndicator(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
        {
            gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            if (width != 0)
            {
                if (width != 0)
                {
                    gv.IndicatorWidth = width;
                }
                else
                {
                    gv.IndicatorWidth = 30;
                }
            }
            else
            {
                gv.IndicatorWidth = 30;
            }

        }
        private void shebeiload()
        {
            comboBox21.Items.Clear();
            string sql1 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            foreach (DataRow row in dt1.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox21.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox21.Items.Add(a);
            }

            comboBox22.Items.Clear();
            string sql2 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);

            foreach (DataRow row in dt2.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox22.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox22.Items.Add(a);
            }

            comboBox23.Items.Clear();
            string sql3 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);

            foreach (DataRow row in dt3.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox23.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox23.Items.Add(a);
            }

            comboBox24.Items.Clear();
            string sql4 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);

            foreach (DataRow row in dt4.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox24.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox24.Items.Add(a);
            }

            comboBox25.Items.Clear();
            string sql5 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt5 = SQLhelp.GetDataTable(sql5, CommandType.Text);

            foreach (DataRow row in dt5.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox25.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox25.Items.Add(a);
            }

            comboBox26.Items.Clear();
            string sql6 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt6 = SQLhelp.GetDataTable(sql6, CommandType.Text);

            foreach (DataRow row in dt6.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox26.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox26.Items.Add(a);
            }

            comboBox27.Items.Clear();
            string sql7 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt7 = SQLhelp.GetDataTable(sql7, CommandType.Text);

            foreach (DataRow row in dt7.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox27.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox27.Items.Add(a);
            }

            comboBox28.Items.Clear();
            string sql8 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt8 = SQLhelp.GetDataTable(sql8, CommandType.Text);

            foreach (DataRow row in dt8.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox28.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox28.Items.Add(a);
            }

            comboBox29.Items.Clear();
            string sql9 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt9 = SQLhelp.GetDataTable(sql9, CommandType.Text);

            foreach (DataRow row in dt9.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox29.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox29.Items.Add(a);
            }


            comboBox30.Items.Clear();
            string sql10 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt10 = SQLhelp.GetDataTable(sql10, CommandType.Text);

            foreach (DataRow row in dt10.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox30.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox30.Items.Add(a);
            }

            comboBox31.Items.Clear();
            string sql11 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt11 = SQLhelp.GetDataTable(sql11, CommandType.Text);

            foreach (DataRow row in dt11.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox31.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox31.Items.Add(a);
            }

            comboBox32.Items.Clear();
            string sql12 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt12 = SQLhelp.GetDataTable(sql12, CommandType.Text);

            foreach (DataRow row in dt12.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox32.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox32.Items.Add(a);
            }

            comboBox33.Items.Clear();
            string sql13 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt13 = SQLhelp.GetDataTable(sql13, CommandType.Text);

            foreach (DataRow row in dt13.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox33.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox33.Items.Add(a);
            }

            comboBox34.Items.Clear();
            string sql14 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt14 = SQLhelp.GetDataTable(sql14, CommandType.Text);

            foreach (DataRow row in dt14.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox34.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox34.Items.Add(a);
            }

            comboBox35.Items.Clear();
            string sql15 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt15 = SQLhelp.GetDataTable(sql15, CommandType.Text);

            foreach (DataRow row in dt15.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox35.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox35.Items.Add(a);
            }

            comboBox36.Items.Clear();
            string sql16 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt16 = SQLhelp.GetDataTable(sql16, CommandType.Text);

            foreach (DataRow row in dt16.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox36.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox36.Items.Add(a);
            }

            comboBox37.Items.Clear();
            string sql17 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt17 = SQLhelp.GetDataTable(sql17, CommandType.Text);

            foreach (DataRow row in dt17.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox37.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox37.Items.Add(a);
            }

            comboBox38.Items.Clear();
            string sql18 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt18 = SQLhelp.GetDataTable(sql18, CommandType.Text);

            foreach (DataRow row in dt18.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox38.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox38.Items.Add(a);
            }

            comboBox39.Items.Clear();
            string sql19 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt19 = SQLhelp.GetDataTable(sql19, CommandType.Text);

            foreach (DataRow row in dt19.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox39.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox39.Items.Add(a);
            }

            comboBox40.Items.Clear();
            string sql20 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt20 = SQLhelp.GetDataTable(sql20, CommandType.Text);

            foreach (DataRow row in dt20.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox40.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox40.Items.Add(a);
            }

            comboBox41.Items.Clear();
            string sql21 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt21 = SQLhelp.GetDataTable(sql21, CommandType.Text);

            foreach (DataRow row in dt21.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox41.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox41.Items.Add(a);
            }

            comboBox42.Items.Clear();
            string sql22 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt22 = SQLhelp.GetDataTable(sql22, CommandType.Text);

            foreach (DataRow row in dt22.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox42.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox42.Items.Add(a);
            }

            comboBox43.Items.Clear();
            string sql23 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt23 = SQLhelp.GetDataTable(sql23, CommandType.Text);

            foreach (DataRow row in dt23.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox43.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox43.Items.Add(a);
            }

            comboBox44.Items.Clear();
            string sql24 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt24 = SQLhelp.GetDataTable(sql24, CommandType.Text);

            foreach (DataRow row in dt24.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox44.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox44.Items.Add(a);
            }

            comboBox45.Items.Clear();
            string sql25 = "select 机加车间人员 from db_chejianrenyuan";
            DataTable dt25 = SQLhelp.GetDataTable(sql25, CommandType.Text);

            foreach (DataRow row in dt25.Rows)
            {
                string a = row["机加车间人员"].ToString();
                if (comboBox45.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox45.Items.Add(a);
            }
        }

        private DataTable xin(string a, string b, string c, string d)
        {
            DataTable dt = new DataTable();

            string s1 = "select * from db_jixiujian where 加工内容='" + a + "' and 工件名称='" + b + "' and 客户名称='" + c + "' and 接单编号='" + d + "' ";
            dt = SQLhelp.GetDataTable(s1, CommandType.Text);

            return dt;
        }

        private DataTable xin1(string a)
        {
            DataTable dt = new DataTable();

            string s1 = "select id,设备名称,申购人,收到料单日期,附件名称,工作令号,定位,项目名称,型号,名称,料单类型,实际采购数量,序号 from tb_caigouliaodan where id='"+ a +"'";
            dt = SQLhelp.GetDataTable1(s1, CommandType.Text);

            return dt;
        }

        private void startload()
        {
            string s2 = "select * from db_gongxu111 where 序号='"+ xuhao +"'";
            DataTable dtg = SQLhelp.GetDataTable(s2, CommandType.Text);//通过图号、名称查到db_gongxu表中的数据

            for (int i = 0; i < dtg.Rows.Count; i++)
            {
                DataRow drg = dtg.Rows[i];//拿到每一行的数据
                if (drg["工序顺序"].ToString() == "1")
                {
                    comboBox1.Text = drg["工序名称"].ToString();
                    richTextBox1.Text = drg["工序内容"].ToString();
                    txt_gx1.Text = drg["价格"].ToString();
                    comboBox21.Text = drg["负责人"].ToString();
                    //textBox14.Text = drg["材料"].ToString();
                    //textBox34.Text = drg["重量"].ToString();
                    richTextBox27.Text = drg["工艺注意点"].ToString();
                    shebei1.Text = drg["工序设备"].ToString();
                    txt_shuliang1.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "2")
                {
                    comboBox2.Text = drg["工序名称"].ToString();
                    richTextBox2.Text = drg["工序内容"].ToString();
                    txt_gx2.Text = drg["价格"].ToString();
                    comboBox22.Text = drg["负责人"].ToString();
                    //textBox7.Text = drg["材料"].ToString();
                    //textBox27.Text = drg["重量"].ToString();
                    richTextBox28.Text = drg["工艺注意点"].ToString();
                    shebei2.Text = drg["工序设备"].ToString();
                    txt_shuliang2.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "3")
                {
                    comboBox3.Text = drg["工序名称"].ToString();
                    richTextBox3.Text = drg["工序内容"].ToString();
                    txt_gx3.Text = drg["价格"].ToString();
                    comboBox23.Text = drg["负责人"].ToString();
                    //textBox10.Text = drg["材料"].ToString();
                    //textBox30.Text = drg["重量"].ToString();
                    richTextBox29.Text = drg["工艺注意点"].ToString();
                    shebei3.Text = drg["工序设备"].ToString();
                    txt_shuliang3.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "4")
                {
                    comboBox4.Text = drg["工序名称"].ToString();
                    richTextBox4.Text = drg["工序内容"].ToString();
                    txt_gx4.Text = drg["价格"].ToString();
                    comboBox24.Text = drg["负责人"].ToString();
                    //textBox3.Text = drg["材料"].ToString();
                    //textBox2.Text = drg["重量"].ToString();
                    richTextBox30.Text = drg["工艺注意点"].ToString();
                    shebei4.Text = drg["工序设备"].ToString();
                    txt_shuliang4.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "5")
                {
                    comboBox5.Text = drg["工序名称"].ToString();
                    richTextBox5.Text = drg["工序内容"].ToString();
                    txt_gx5.Text = drg["价格"].ToString();
                    comboBox25.Text = drg["负责人"].ToString();
                    richTextBox31.Text = drg["工艺注意点"].ToString();
                    shebei5.Text = drg["工序设备"].ToString();
                    txt_shuliang5.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "6")
                {
                    comboBox6.Text = drg["工序名称"].ToString();
                    richTextBox6.Text = drg["工序内容"].ToString();
                    txt_gx6.Text = drg["价格"].ToString();
                    comboBox26.Text = drg["负责人"].ToString();
                    richTextBox32.Text = drg["工艺注意点"].ToString();
                    shebei6.Text = drg["工序设备"].ToString();
                    txt_shuliang6.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "7")
                {
                    comboBox7.Text = drg["工序名称"].ToString();
                    richTextBox7.Text = drg["工序内容"].ToString();
                    txt_gx7.Text = drg["价格"].ToString();
                    comboBox27.Text = drg["负责人"].ToString();
                    richTextBox33.Text = drg["工艺注意点"].ToString();
                    shebei7.Text = drg["工序设备"].ToString();
                    txt_shuliang7.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "8")
                {
                    comboBox8.Text = drg["工序名称"].ToString();
                    richTextBox8.Text = drg["工序内容"].ToString();
                    txt_gx8.Text = drg["价格"].ToString();
                    comboBox28.Text = drg["负责人"].ToString();
                    richTextBox34.Text = drg["工艺注意点"].ToString();
                    shebei8.Text = drg["工序设备"].ToString();
                    txt_shuliang8.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "9")
                {
                    comboBox9.Text = drg["工序名称"].ToString();
                    richTextBox9.Text = drg["工序内容"].ToString();
                    txt_gx9.Text = drg["价格"].ToString();
                    comboBox29.Text = drg["负责人"].ToString();
                    richTextBox35.Text = drg["工艺注意点"].ToString();
                    shebei9.Text = drg["工序设备"].ToString();
                    txt_shuliang9.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "10")
                {
                    comboBox10.Text = drg["工序名称"].ToString();
                    richTextBox10.Text = drg["工序内容"].ToString();
                    txt_gx10.Text = drg["价格"].ToString();
                    comboBox30.Text = drg["负责人"].ToString();
                    richTextBox36.Text = drg["工艺注意点"].ToString();
                    shebei10.Text = drg["工序设备"].ToString();
                    txt_shuliang10.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "11")
                {
                    comboBox11.Text = drg["工序名称"].ToString();
                    richTextBox11.Text = drg["工序内容"].ToString();
                    txt_gx11.Text = drg["价格"].ToString();
                    comboBox31.Text = drg["负责人"].ToString();
                    richTextBox37.Text = drg["工艺注意点"].ToString();
                    shebei11.Text = drg["工序设备"].ToString();
                    txt_shuliang11.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "12")
                {
                    comboBox12.Text = drg["工序名称"].ToString();
                    richTextBox12.Text = drg["工序内容"].ToString();
                    txt_gx12.Text = drg["价格"].ToString();
                    comboBox32.Text = drg["负责人"].ToString();
                    richTextBox38.Text = drg["工艺注意点"].ToString();
                    shebei12.Text = drg["工序设备"].ToString();
                    txt_shuliang12.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "13")
                {
                    comboBox13.Text = drg["工序名称"].ToString();
                    richTextBox13.Text = drg["工序内容"].ToString();
                    txt_gx13.Text = drg["价格"].ToString();
                    comboBox33.Text = drg["负责人"].ToString();
                    richTextBox39.Text = drg["工艺注意点"].ToString();
                    shebei13.Text = drg["工序设备"].ToString();
                    txt_shuliang13.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "14")
                {
                    comboBox14.Text = drg["工序名称"].ToString();
                    richTextBox14.Text = drg["工序内容"].ToString();
                    txt_gx14.Text = drg["价格"].ToString();
                    comboBox34.Text = drg["负责人"].ToString();
                    richTextBox40.Text = drg["工艺注意点"].ToString();
                    shebei14.Text = drg["工序设备"].ToString();
                    txt_shuliang14.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "15")
                {
                    comboBox15.Text = drg["工序名称"].ToString();
                    richTextBox15.Text = drg["工序内容"].ToString();
                    txt_gx15.Text = drg["价格"].ToString();
                    comboBox35.Text = drg["负责人"].ToString();
                    richTextBox41.Text = drg["工艺注意点"].ToString();
                    shebei15.Text = drg["工序设备"].ToString();
                    txt_shuliang15.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "16")
                {
                    comboBox16.Text = drg["工序名称"].ToString();
                    richTextBox16.Text = drg["工序内容"].ToString();
                    txt_gx16.Text = drg["价格"].ToString();
                    comboBox36.Text = drg["负责人"].ToString();
                    richTextBox42.Text = drg["工艺注意点"].ToString();
                    shebei16.Text = drg["工序设备"].ToString();
                    txt_shuliang16.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "17")
                {
                    comboBox17.Text = drg["工序名称"].ToString();
                    richTextBox17.Text = drg["工序内容"].ToString();
                    txt_gx17.Text = drg["价格"].ToString();
                    comboBox37.Text = drg["负责人"].ToString();
                    richTextBox43.Text = drg["工艺注意点"].ToString();
                    shebei17.Text = drg["工序设备"].ToString();
                    txt_shuliang17.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "18")
                {
                    comboBox18.Text = drg["工序名称"].ToString();
                    richTextBox18.Text = drg["工序内容"].ToString();
                    txt_gx18.Text = drg["价格"].ToString();
                    comboBox38.Text = drg["负责人"].ToString();
                    richTextBox44.Text = drg["工艺注意点"].ToString();
                    shebei18.Text = drg["工序设备"].ToString();
                    txt_shuliang18.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "19")
                {
                    comboBox19.Text = drg["工序名称"].ToString();
                    richTextBox19.Text = drg["工序内容"].ToString();
                    txt_gx19.Text = drg["价格"].ToString();
                    comboBox39.Text = drg["负责人"].ToString();
                    richTextBox45.Text = drg["工艺注意点"].ToString();
                    shebei19.Text = drg["工序设备"].ToString();
                    txt_shuliang19.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "20")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    comboBox40.Text = drg["负责人"].ToString();
                    richTextBox46.Text = drg["工艺注意点"].ToString();
                    shebei20.Text = drg["工序设备"].ToString();
                    txt_shuliang20.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "21")
                {
                    comboBox46.Text = drg["工序名称"].ToString();
                    richTextBox22.Text = drg["工序内容"].ToString();
                    txt_gx21.Text = drg["价格"].ToString();
                    comboBox41.Text = drg["负责人"].ToString();
                    richTextBox47.Text = drg["工艺注意点"].ToString();
                    shebei21.Text = drg["工序设备"].ToString();
                    txt_shuliang21.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "22")
                {
                    comboBox47.Text = drg["工序名称"].ToString();
                    richTextBox23.Text = drg["工序内容"].ToString();
                    txt_gx22.Text = drg["价格"].ToString();
                    comboBox42.Text = drg["负责人"].ToString();
                    richTextBox48.Text = drg["工艺注意点"].ToString();
                    shebei22.Text = drg["工序设备"].ToString();
                    txt_shuliang22.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "23")
                {
                    comboBox48.Text = drg["工序名称"].ToString();
                    richTextBox24.Text = drg["工序内容"].ToString();
                    txt_gx23.Text = drg["价格"].ToString();
                    comboBox43.Text = drg["负责人"].ToString();
                    richTextBox49.Text = drg["工艺注意点"].ToString();
                    shebei23.Text = drg["工序设备"].ToString();
                    txt_shuliang23.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "24")
                {
                    comboBox49.Text = drg["工序名称"].ToString();
                    richTextBox25.Text = drg["工序内容"].ToString();
                    txt_gx24.Text = drg["价格"].ToString();
                    comboBox44.Text = drg["负责人"].ToString();
                    richTextBox50.Text = drg["工艺注意点"].ToString();
                    shebei24.Text = drg["工序设备"].ToString();
                    txt_shuliang24.Text = drg["机修件数量"].ToString();
                }
                if (drg["工序顺序"].ToString() == "25")
                {
                    comboBox50.Text = drg["工序名称"].ToString();
                    richTextBox26.Text = drg["工序内容"].ToString();
                    txt_gx25.Text = drg["价格"].ToString();
                    comboBox45.Text = drg["负责人"].ToString();
                    richTextBox51.Text = drg["工艺注意点"].ToString();
                    shebei25.Text = drg["工序设备"].ToString();
                    txt_shuliang25.Text = drg["机修件数量"].ToString();
                }

            }

            string s1 = "select max(工序顺序) from db_gongxu111 where 序号='"+ xuhao +"'";
            string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
            if (r1 != "")
            {
                btn_Save.Enabled = false;
                enabled();
            }

            if(leixing == "机修件零件")
            {
                string SQL1 = "select * from db_caigoucailiao where 序号='" + xuhao + "' and 料单类型='机修件零件' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "'";
                DataTable dt = SQLhelp.GetDataTable(SQL1, CommandType.Text);
                this.gridControl1.DataSource = dt;
            }
            if(leixing == "机修件组件")
            {
                string SQL1 = "select * from db_caigoucailiao where 组件定位='" + dingweiNumber + "' and 料单类型='机修件组件' and 图号='"+ txt_tuhao.Text +"' and 名称='"+ txt_mingcheng.Text +"'";
                DataTable dt = SQLhelp.GetDataTable(SQL1, CommandType.Text);
                this.gridControl1.DataSource = dt;
            }

        }

        private void enabled()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox7.Enabled = false;
            comboBox6.Enabled = false;
            comboBox8.Enabled = false;
            comboBox9.Enabled = false;
            comboBox13.Enabled = false;
            comboBox11.Enabled = false;
            comboBox15.Enabled = false;
            comboBox10.Enabled = false;
            comboBox14.Enabled = false;
            comboBox12.Enabled = false;
            comboBox16.Enabled = false;
            comboBox17.Enabled = false;
            comboBox19.Enabled = false;
            comboBox18.Enabled = false;
            comboBox20.Enabled = false;
            comboBox46.Enabled = false;
            comboBox47.Enabled = false;
            comboBox48.Enabled = false;
            comboBox49.Enabled = false;
            comboBox50.Enabled = false;

            richTextBox1.Enabled = false;
            richTextBox9.Enabled = false;
            richTextBox10.Enabled = false;
            richTextBox11.Enabled = false;
            richTextBox12.Enabled = false;
            richTextBox13.Enabled = false;
            richTextBox14.Enabled = false;
            richTextBox15.Enabled = false;
            richTextBox16.Enabled = false;
            richTextBox17.Enabled = false;
            richTextBox18.Enabled = false;
            richTextBox19.Enabled = false;
            richTextBox2.Enabled = false;
            richTextBox20.Enabled = false;
            richTextBox3.Enabled = false;
            richTextBox4.Enabled = false;
            richTextBox5.Enabled = false;
            richTextBox6.Enabled = false;
            richTextBox7.Enabled = false;
            richTextBox8.Enabled = false;
            richTextBox22.Enabled = false;
            richTextBox23.Enabled = false;
            richTextBox24.Enabled = false;
            richTextBox25.Enabled = false;
            richTextBox26.Enabled = false;

            richTextBox27.Enabled = false;
            richTextBox28.Enabled = false;
            richTextBox29.Enabled = false;
            richTextBox30.Enabled = false;
            richTextBox31.Enabled = false;
            richTextBox32.Enabled = false;
            richTextBox33.Enabled = false;
            richTextBox34.Enabled = false;
            richTextBox35.Enabled = false;
            richTextBox36.Enabled = false;
            richTextBox37.Enabled = false;
            richTextBox38.Enabled = false;
            richTextBox39.Enabled = false;
            richTextBox40.Enabled = false;
            richTextBox41.Enabled = false;
            richTextBox42.Enabled = false;
            richTextBox43.Enabled = false;
            richTextBox44.Enabled = false;
            richTextBox45.Enabled = false;
            richTextBox46.Enabled = false;
            richTextBox47.Enabled = false;
            richTextBox48.Enabled = false;
            richTextBox49.Enabled = false;
            richTextBox50.Enabled = false;
            richTextBox51.Enabled = false;

            txt_gx1.Enabled = false;
            txt_gx2.Enabled = false;
            txt_gx3.Enabled = false;
            txt_gx4.Enabled = false;
            txt_gx5.Enabled = false;
            txt_gx6.Enabled = false;
            txt_gx7.Enabled = false;
            txt_gx8.Enabled = false;
            txt_gx9.Enabled = false;
            txt_gx10.Enabled = false;
            txt_gx11.Enabled = false;
            txt_gx12.Enabled = false;
            txt_gx13.Enabled = false;
            txt_gx14.Enabled = false;
            txt_gx15.Enabled = false;
            txt_gx16.Enabled = false;
            txt_gx17.Enabled = false;
            txt_gx18.Enabled = false;
            txt_gx19.Enabled = false;
            txt_gx20.Enabled = false;
            txt_gx21.Enabled = false;
            txt_gx22.Enabled = false;
            txt_gx23.Enabled = false;
            txt_gx24.Enabled = false;
            txt_gx25.Enabled = false;

            comboBox21.Enabled = false;
            comboBox22.Enabled = false;
            comboBox23.Enabled = false;
            comboBox24.Enabled = false;
            comboBox25.Enabled = false;
            comboBox26.Enabled = false;
            comboBox27.Enabled = false;
            comboBox28.Enabled = false;
            comboBox29.Enabled = false;
            comboBox30.Enabled = false;
            comboBox31.Enabled = false;
            comboBox32.Enabled = false;
            comboBox33.Enabled = false;
            comboBox34.Enabled = false;
            comboBox35.Enabled = false;
            comboBox36.Enabled = false;
            comboBox37.Enabled = false;
            comboBox38.Enabled = false;
            comboBox39.Enabled = false;
            comboBox40.Enabled = false;
            comboBox41.Enabled = false;
            comboBox42.Enabled = false;
            comboBox43.Enabled = false;
            comboBox44.Enabled = false;
            comboBox45.Enabled = false;

            txt_shuliang1.Enabled = false;
            txt_shuliang2.Enabled = false;
            txt_shuliang3.Enabled = false;
            txt_shuliang4.Enabled = false;
            txt_shuliang5.Enabled = false;
            txt_shuliang6.Enabled = false;
            txt_shuliang7.Enabled = false;
            txt_shuliang8.Enabled = false;
            txt_shuliang9.Enabled = false;
            txt_shuliang10.Enabled = false;
            txt_shuliang11.Enabled = false;
            txt_shuliang12.Enabled = false;
            txt_shuliang13.Enabled = false;
            txt_shuliang14.Enabled = false;
            txt_shuliang15.Enabled = false;
            txt_shuliang16.Enabled = false;
            txt_shuliang17.Enabled = false;
            txt_shuliang18.Enabled = false;
            txt_shuliang19.Enabled = false;
            txt_shuliang20.Enabled = false;
            txt_shuliang21.Enabled = false;
            txt_shuliang22.Enabled = false;
            txt_shuliang23.Enabled = false;
            txt_shuliang24.Enabled = false;
            txt_shuliang25.Enabled = false;

            shebei1.Enabled = false;
            shebei2.Enabled = false;
            shebei3.Enabled = false;
            shebei4.Enabled = false;
            shebei5.Enabled = false;
            shebei6.Enabled = false;
            shebei7.Enabled = false;
            shebei8.Enabled = false;
            shebei9.Enabled = false;
            shebei10.Enabled = false;
            shebei11.Enabled = false;
            shebei12.Enabled = false;
            shebei13.Enabled = false;
            shebei14.Enabled = false;
            shebei15.Enabled = false;
            shebei16.Enabled = false;
            shebei17.Enabled = false;
            shebei18.Enabled = false;
            shebei19.Enabled = false;
            shebei20.Enabled = false;
            shebei21.Enabled = false;
            shebei22.Enabled = false;
            shebei23.Enabled = false;
            shebei24.Enabled = false;
            shebei25.Enabled = false;

        }

        /// <summary>
        /// 二维码显示
        /// </summary>
        private void CodeReplay()
        {
            if(leixing == "机修件零件")
            {
                string a = addtuhao;//加工内容
                string b = addmingcheng;//工件名称
                string d = txt_gonglinghao.Text;//接单编号
                string f = txt_jiagong.Text;//客户名称
                string h = xuhao;//序号

                //string dataCode = f + "\n" + d + "\n" + a + "\n" + b + "\n" + h + "\n";

                string dataCode = f + "|" + d + "|" + a + "|" + b + "|" + h + "|";

                richTextBox21.Text = dataCode;

                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;


                Image image;
                string data = dataCode;
                image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                pictureBox1.Size = new Size(186, 186);
                pictureBox1.Image = image;
            }
            if(leixing == "机修件组件")
            {

                string a = txt_tuhao.Text;//加工内容
                string b = txt_mingcheng.Text;//工件名称
                string d = txt_gonglinghao.Text;//接单编号
                string f = txt_jiagong.Text;//客户名称
                string h = xuhao;//序号

                //string dataCode = f + "\n" + d + "\n" + a + "\n" + b + "\n" + h + "\n";

                string dataCode = f + "|" + d + "|" + a + "|" + b + "|" + h + "|";

                richTextBox21.Text = dataCode;

                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;


                Image image;
                string data = dataCode;
                image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                pictureBox1.Size = new Size(186, 186);
                pictureBox1.Image = image;
            }

        }


        private byte[] GetImageBytes(Image image)
        {
            MemoryStream mstream = new MemoryStream();
            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byteData, 0, byteData.Length);
            mstream.Close();
            return byteData;
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(pictureBox1.Image, Convert.ToInt32(t_X.Text.Trim()), Convert.ToInt32(t_Y.Text.Trim()), Convert.ToInt32(t_gao.Text.Trim()), Convert.ToInt32(t_kuan.Text.Trim()));
        }



        /// <summary>
        /// 成本价格计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //FormChengben form = new FormChengben();
            //form.ShowDialog();
            //if (form.DialogResult == DialogResult.OK)
            //{
            //    textBox1.Text = form.cailiaochengben;
            //}
        }



        #region 价格数字输入


        //private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

        //        e.Handled = true;

        //    //小数点的处理。

        //    if ((int)e.KeyChar == 46)                           //小数点

        //    {

        //        if (textBox34.Text.Length <= 0)

        //            e.Handled = true;   //小数点不能在第一位

        //        else

        //        {

        //            float f;

        //            float oldf;

        //            bool b1 = false, b2 = false;

        //            b1 = float.TryParse(textBox34.Text, out oldf);

        //            b2 = float.TryParse(textBox34.Text + e.KeyChar.ToString(), out f);

        //            if (b2 == false)

        //            {

        //                if (b1 == true)

        //                    e.Handled = true;

        //                else

        //                    e.Handled = false;

        //            }

        //        }

        //    }
        //}

        //private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

        //        e.Handled = true;

        //    //小数点的处理。

        //    if ((int)e.KeyChar == 46)                           //小数点

        //    {

        //        if (textBox27.Text.Length <= 0)

        //            e.Handled = true;   //小数点不能在第一位

        //        else

        //        {

        //            float f;

        //            float oldf;

        //            bool b1 = false, b2 = false;

        //            b1 = float.TryParse(textBox27.Text, out oldf);

        //            b2 = float.TryParse(textBox27.Text + e.KeyChar.ToString(), out f);

        //            if (b2 == false)

        //            {

        //                if (b1 == true)

        //                    e.Handled = true;

        //                else

        //                    e.Handled = false;

        //            }

        //        }

        //    }
        //}

        //private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

        //        e.Handled = true;

        //    //小数点的处理。

        //    if ((int)e.KeyChar == 46)                           //小数点

        //    {

        //        if (textBox30.Text.Length <= 0)

        //            e.Handled = true;   //小数点不能在第一位

        //        else

        //        {

        //            float f;

        //            float oldf;

        //            bool b1 = false, b2 = false;

        //            b1 = float.TryParse(textBox30.Text, out oldf);

        //            b2 = float.TryParse(textBox30.Text + e.KeyChar.ToString(), out f);

        //            if (b2 == false)

        //            {

        //                if (b1 == true)

        //                    e.Handled = true;

        //                else

        //                    e.Handled = false;

        //            }

        //        }

        //    }
        //}

        //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

        //        e.Handled = true;

        //    //小数点的处理。

        //    if ((int)e.KeyChar == 46)                           //小数点

        //    {

        //        if (textBox2.Text.Length <= 0)

        //            e.Handled = true;   //小数点不能在第一位

        //        else

        //        {

        //            float f;

        //            float oldf;

        //            bool b1 = false, b2 = false;

        //            b1 = float.TryParse(textBox2.Text, out oldf);

        //            b2 = float.TryParse(textBox2.Text + e.KeyChar.ToString(), out f);

        //            if (b2 == false)

        //            {

        //                if (b1 == true)

        //                    e.Handled = true;

        //                else

        //                    e.Handled = false;

        //            }

        //        }

        //    }
        //}

        private void txt_gx1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx1.Text, out oldf);

                    b2 = float.TryParse(txt_gx1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx2.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx2.Text, out oldf);

                    b2 = float.TryParse(txt_gx2.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx3.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx3.Text, out oldf);

                    b2 = float.TryParse(txt_gx3.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx4.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx4.Text, out oldf);

                    b2 = float.TryParse(txt_gx4.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx5.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx5.Text, out oldf);

                    b2 = float.TryParse(txt_gx5.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx6.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx6.Text, out oldf);

                    b2 = float.TryParse(txt_gx6.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx7_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx7.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx7.Text, out oldf);

                    b2 = float.TryParse(txt_gx7.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx8_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx8.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx8.Text, out oldf);

                    b2 = float.TryParse(txt_gx8.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx9_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx9.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx9.Text, out oldf);

                    b2 = float.TryParse(txt_gx9.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx10_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx10.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx10.Text, out oldf);

                    b2 = float.TryParse(txt_gx10.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx11_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx11.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx11.Text, out oldf);

                    b2 = float.TryParse(txt_gx11.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx12_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx12.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx12.Text, out oldf);

                    b2 = float.TryParse(txt_gx12.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx13_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx13.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx13.Text, out oldf);

                    b2 = float.TryParse(txt_gx13.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx14_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx14.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx14.Text, out oldf);

                    b2 = float.TryParse(txt_gx14.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx15_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx15.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx15.Text, out oldf);

                    b2 = float.TryParse(txt_gx15.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx16_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx16.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx16.Text, out oldf);

                    b2 = float.TryParse(txt_gx16.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx17_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx17.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx17.Text, out oldf);

                    b2 = float.TryParse(txt_gx17.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx18_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx18.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx18.Text, out oldf);

                    b2 = float.TryParse(txt_gx18.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx19_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx19.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx19.Text, out oldf);

                    b2 = float.TryParse(txt_gx19.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx20_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx20.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx20.Text, out oldf);

                    b2 = float.TryParse(txt_gx20.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx21.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx21.Text, out oldf);

                    b2 = float.TryParse(txt_gx21.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx22.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx22.Text, out oldf);

                    b2 = float.TryParse(txt_gx22.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx23.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx23.Text, out oldf);

                    b2 = float.TryParse(txt_gx23.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx24.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx24.Text, out oldf);

                    b2 = float.TryParse(txt_gx24.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_gx25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_gx25.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_gx25.Text, out oldf);

                    b2 = float.TryParse(txt_gx25.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        #endregion



        /// <summary>
        /// 返回设备的类型--数控与非数控
        /// </summary>
        /// <param name="shebei"></param>
        /// <returns></returns>
        private string panduanshebi(string shebei)
        {
            string sqlstr = "select identification from db_chejianrenyuan where 设备名='" + shebei + "'";//查询设备对应的是否为数控设备
            string retstr = Convert.ToString(SQLhelp.ExecuteScalar(sqlstr, CommandType.Text));

            return retstr;
        }

        /// <summary>
        /// 数控设备排产----24小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan1(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {
            DateTime time1 = DateTime.Now;//现在的当前时间（日期+时分秒）

            //当前时分秒--time1time
            //当前时间日期---time1date1

            string sql1 = "select 设定开始时间 from db_Paichan where 工序设备='" + shebei + "'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            #region 设备空闲中

            if (ret1 == "")//设备空闲中的时候，根据前面的datetimepicker的value值算
            {
                //算总的工时
                double price = Convert.ToDouble(jiage);
                price = price * (Convert.ToInt32(shuliang));
                double t = (double)price / 27;
                double flag = t / 21.5;
                int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);
                //DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);
                //if(time >= time1)
                //{
                //    picker1.Value = time;
                //    picker2.Value = time.AddHours(t);
                //}
                //if(time1 >= time)
                //{
                //    picker1.Value = time1;
                //    picker2.Value = time1.AddHours(t);
                //}

                //中午休息时间：12:00-13:00  -----4.5
                //下午休息     17:30-18:00   ----5.5
                //午夜休息     23:30-00:30   ----

                //当前设置工序的时间 < 12:00:00
                int ta1 = shijian2.CompareTo(time1time);

                if (ta1 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                    TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                    if (t >= ta2.TotalHours)//上午没有加工完成
                    {
                        double t1 = t - 21.5 * at - ta2.TotalHours;
                        if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                        }

                        if (4.5 < t1 && t1 <= 10)//午夜完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                        }
                        if (10 < t1 && t1 <= 21.5)//第二天上午完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t);
                    }
                }

                //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                int ta3 = time1time.CompareTo(shijian2);
                int ta4 = shijian3.CompareTo(time1time);

                if (ta4 == 1 && ta3 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    picker1.Value = Convert.ToDateTime(strtimexiawu);

                    if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                    }
                    if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                    {
                        picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                    }
                    if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                    {
                        picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                    }
                }

                //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                int ta5 = time1time.CompareTo(shijian3);
                int ta6 = shijian4.CompareTo(time1time);

                if (ta5 == 1 && ta6 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    picker1.Value = strtime;
                    TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                    if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                    {
                        if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                        }
                        if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                        }
                        if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                        }
                    }
                    else//下午加工完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                    }

                }

                //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                int ta7 = time1time.CompareTo(shijian4);
                int ta8 = shijian5.CompareTo(time1time);

                if (ta7 == 1 && ta8 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    picker1.Value = strtimewuye;
                    if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                    {
                        picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                    }
                    if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                    {
                        picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                    }
                    if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                    }
                }

                //当前设置工序的时间 18:00:00< 时间 < 
                int ta9 = time1time.CompareTo(shijian5);
                if (ta9 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                    picker1.Value = strtime;
                    TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                    double tsheng = t - 21.5 * at - t1.TotalHours;
                    if (tsheng >= 0)
                    {
                        if (tsheng <= 11.5)
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                        }
                        if (11.5 < tsheng && tsheng <= 16)
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                        }
                        if (16 < tsheng && tsheng <= 21.5)
                        {
                            picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                    }
                }

                #region 死方法
                //#region 工时小于等于1天的工时 t<=21.5

                //if (0 < t && t < 21.5)
                //{
                //    //当前设置工序的时间 < 12:00:00
                //    int ta1 = shijian2.CompareTo(time1time);

                //    if (ta1 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                //        TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                //        if(t >= ta2.TotalHours)//上午没有加工完成
                //        {
                //            double t1 = t - ta2.TotalHours;
                //            if(t1 > 0 && t1 <= 4.5)//下午加工完成不了
                //            {
                //                picker2.Value = strtimexiawu.AddHours(t1);
                //            }

                //            if (4.5 < t1 && t1 <= 10)//午夜完成
                //            {
                //                picker2.Value = strtimewuye.AddHours(t1 - 4.5);
                //            }
                //            if(10 < t1 && t1 <= 21.5)//第二天上午完成
                //            {
                //                picker2.Value = strtimediertian.AddDays(1).AddHours(t1 - 10);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //    }

                //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                //    int ta3 = time1time.CompareTo(shijian2);
                //    int ta4 = shijian3.CompareTo(time1time);

                //    if(ta4 == 1 && ta3 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                //        if(0 < t && t <= 4.5)//下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddHours(t);
                //        }
                //        if(4.5 < t && t <= 10)//午夜完成
                //        {
                //            picker2.Value = strtimewuye.AddHours(t - 4.5);
                //        }
                //        if(10 < t && t <= 21.5)//第二天完成
                //        {
                //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 10);
                //        }
                //    }

                //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                //    int ta5 = time1time.CompareTo(shijian3);
                //    int ta6 = shijian4.CompareTo(time1time);

                //    if(ta5 == 1 && ta6 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        picker1.Value = strtime;
                //        TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                //        if(t >= t1.TotalHours)//下午没有加工完成
                //        {
                //            if((t-t1.TotalHours) <= 5.5)//午夜之前可以完成
                //            {
                //                picker2.Value = strtimewuye.AddHours(t - t1.TotalHours);
                //            }
                //            if(5.5 < (t-t1.TotalHours) && (t - t1.TotalHours) <= 17)//第二天上午完成
                //            {
                //                picker2.Value = strtimediertian.AddDays(1).AddHours(t - t1.TotalHours - 5.5);
                //            }
                //            if(17 < (t-t1.TotalHours) && (t-t1.TotalHours) <= 21.5)//第二天下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t - t1.TotalHours - 17);
                //            }
                //        }
                //        else//下午加工完成
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }

                //    }

                //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                //    int ta7 = time1time.CompareTo(shijian4);
                //    int ta8 = shijian5.CompareTo(time1time);

                //    if(ta7 == 1 && ta8 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        picker1.Value = strtimewuye;
                //        if(0 < t && t <= 5.5)//午夜前完成
                //        {
                //            picker2.Value = strtimewuye.AddHours(t);
                //        }
                //        if(5.5 < t && t <= 17)//第二天上午完成
                //        {
                //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 5.5);
                //        }
                //        if(17 < t && t <= 21.5)//第二天下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 17);
                //        }
                //    }

                //    //当前设置工序的时间 18:00:00< 时间 < 
                //    int ta9 = time1time.CompareTo(shijian5);
                //    if(ta9 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                //        picker1.Value = strtime;
                //        TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                //        double tsheng = t - t1.TotalHours;
                //        if(tsheng >= 0)
                //        {
                //            if(tsheng <= 11.5)
                //            {
                //                picker2.Value = strtimediertian.AddDays(1).AddHours(tsheng);
                //            }
                //            if(11.5 < tsheng && tsheng <= 16)
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tsheng - 11.5);
                //            }
                //            if(16 < tsheng && tsheng <= 21.5)
                //            {
                //                picker2.Value = strtimewuye.AddDays(1).AddHours(tsheng - 16);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //    }

                //}

                //#endregion

                //#region 工时大于1天小于2天  21.5<t<=43

                //if (21.5 < t && t < 43)
                //{
                //    //当前设置工序的时间 < 12:00:00
                //    int ta1 = shijian2.CompareTo(time1time);

                //    if (ta1 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                //        TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                //        if (t >= ta2.TotalHours)//上午没有加工完成
                //        {
                //            double t1 = t - 21.5 - ta2.TotalHours;
                //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                //            }

                //            if (4.5 < t1 && t1 <= 10)//午夜完成
                //            {
                //                picker2.Value = strtimewuye.AddDays(1).AddHours(t1 - 4.5);
                //            }
                //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                //            {
                //                picker2.Value = strtimediertian.AddDays(2).AddHours(t1 - 10);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t);
                //        }
                //    }

                //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                //    int ta3 = time1time.CompareTo(shijian2);
                //    int ta4 = shijian3.CompareTo(time1time);

                //    if (ta4 == 1 && ta3 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                //        if (0 < t - 21.5 && t - 21.5 <= 4.5)//下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 21.5);
                //        }
                //        if (4.5 < t - 21.5 && t - 21.5 <= 10)//午夜完成
                //        {
                //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - 4.5);
                //        }
                //        if (10 < t - 21.5 && t - 21.5 <= 21.5)//第二天完成
                //        {
                //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 10);
                //        }
                //    }

                //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                //    int ta5 = time1time.CompareTo(shijian3);
                //    int ta6 = shijian4.CompareTo(time1time);

                //    if (ta5 == 1 && ta6 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        picker1.Value = strtime;
                //        TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                //        if (t - 21.5 >= t1.TotalHours)//下午没有加工完成
                //        {
                //            if ((t - 21.5 - t1.TotalHours) <= 5.5)//午夜之前可以完成
                //            {
                //                picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - t1.TotalHours);
                //            }
                //            if (5.5 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 17)//第二天上午完成
                //            {
                //                picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 5.5);
                //            }
                //            if (17 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 21.5)//第二天下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 17);
                //            }
                //        }
                //        else//下午加工完成
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 21.5);
                //        }

                //    }

                //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                //    int ta7 = time1time.CompareTo(shijian4);
                //    int ta8 = shijian5.CompareTo(time1time);

                //    if (ta7 == 1 && ta8 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        picker1.Value = strtimewuye;
                //        if (0 < t - 21.5 && t - 21.5 <= 5.5)//午夜前完成
                //        {
                //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5);
                //        }
                //        if (5.5 < t - 21.5 && t - 21.5 <= 17)//第二天上午完成
                //        {
                //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 5.5);
                //        }
                //        if (17 < t - 21.5 && t - 21.5 <= 21.5)//第二天下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - 17);
                //        }
                //    }

                //    //当前设置工序的时间 18:00:00< 时间 < 
                //    int ta9 = time1time.CompareTo(shijian5);
                //    if (ta9 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                //        picker1.Value = strtime;
                //        TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                //        double tsheng = t - 21.5 - t1.TotalHours;
                //        if (tsheng >= 0)
                //        {
                //            if (tsheng <= 11.5)
                //            {
                //                picker2.Value = strtimediertian.AddDays(2).AddHours(tsheng);
                //            }
                //            if (11.5 < tsheng && tsheng <= 16)
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tsheng - 11.5);
                //            }
                //            if (16 < tsheng && tsheng <= 21.5)
                //            {
                //                picker2.Value = strtimewuye.AddDays(2).AddHours(tsheng - 16);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 21.5);
                //        }
                //    }
                //}

                //#endregion
                #endregion

            }

            #endregion

            #region 设备不空闲
            else
            {
                string sql2 = "select max(设定开始时间) from db_Paichan where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select 设定结束时间 from db_Paichan where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束事假，结束时间就是当前时间
                DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                //ret3是最后一个设定结束时间

                if (ret3 < time1)//设备的任务都完成了，最后一个设定结束时间小于现在的时间---(空闲中)
                {

                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);

                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 21.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);


                    //当前设置工序的时间 < 12:00:00
                    int ta1 = shijian2.CompareTo(time1time);

                    if (ta1 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                        TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                        if (t >= ta2.TotalHours)//上午没有加工完成
                        {
                            double t1 = t - 21.5 * at - ta2.TotalHours;
                            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                            }

                            if (4.5 < t1 && t1 <= 10)//午夜完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                            }
                            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t);
                        }
                    }

                    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                    int ta3 = time1time.CompareTo(shijian2);
                    int ta4 = shijian3.CompareTo(time1time);

                    if (ta4 == 1 && ta3 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        picker1.Value = Convert.ToDateTime(strtimexiawu);

                        if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                        }
                        if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                        }
                        if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                        }
                    }

                    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                    int ta5 = time1time.CompareTo(shijian3);
                    int ta6 = shijian4.CompareTo(time1time);

                    if (ta5 == 1 && ta6 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        picker1.Value = strtime;
                        TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                        if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                        {
                            if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                            }
                            if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                            }
                            if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                            }
                        }
                        else//下午加工完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                        }

                    }

                    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                    int ta7 = time1time.CompareTo(shijian4);
                    int ta8 = shijian5.CompareTo(time1time);

                    if (ta7 == 1 && ta8 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        picker1.Value = strtimewuye;
                        if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                        {
                            picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                        }
                        if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                        {
                            picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                        }
                        if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                        }
                    }

                    //当前设置工序的时间 18:00:00< 时间 < 
                    int ta9 = time1time.CompareTo(shijian5);
                    if (ta9 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                        picker1.Value = strtime;
                        TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                        double tsheng = t - 21.5 * at - t1.TotalHours;
                        if (tsheng >= 0)
                        {
                            if (tsheng <= 11.5)
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                            }
                            if (11.5 < tsheng && tsheng <= 16)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                            }
                            if (16 < tsheng && tsheng <= 21.5)
                            {
                                picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 21.5 * at);
                        }
                    }

                    #region 死方法
                    //#region 工时小于等于1天的工时 t<=21.5

                    //if (0 < t && t < 21.5)
                    //{
                    //    //当前设置工序的时间 < 12:00:00
                    //    int ta1 = shijian2.CompareTo(time1time);

                    //    if (ta1 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                    //        TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                    //        if (t >= ta2.TotalHours)//上午没有加工完成
                    //        {
                    //            double t1 = t - ta2.TotalHours;
                    //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                    //            {
                    //                picker2.Value = strtimexiawu.AddHours(t1);
                    //            }

                    //            if (4.5 < t1 && t1 <= 10)//午夜完成
                    //            {
                    //                picker2.Value = strtimewuye.AddHours(t1 - 4.5);
                    //            }
                    //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                    //            {
                    //                picker2.Value = strtimediertian.AddDays(1).AddHours(t1 - 10);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //    }

                    //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                    //    int ta3 = time1time.CompareTo(shijian2);
                    //    int ta4 = shijian3.CompareTo(time1time);

                    //    if (ta4 == 1 && ta3 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                    //        if (0 < t && t <= 4.5)//下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddHours(t);
                    //        }
                    //        if (4.5 < t && t <= 10)//午夜完成
                    //        {
                    //            picker2.Value = strtimewuye.AddHours(t - 4.5);
                    //        }
                    //        if (10 < t && t <= 21.5)//第二天完成
                    //        {
                    //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 10);
                    //        }
                    //    }

                    //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                    //    int ta5 = time1time.CompareTo(shijian3);
                    //    int ta6 = shijian4.CompareTo(time1time);

                    //    if (ta5 == 1 && ta6 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        picker1.Value = strtime;
                    //        TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                    //        if (t >= t1.TotalHours)//下午没有加工完成
                    //        {
                    //            if ((t - t1.TotalHours) <= 5.5)//午夜之前可以完成
                    //            {
                    //                picker2.Value = strtimewuye.AddHours(t - t1.TotalHours);
                    //            }
                    //            if (5.5 < (t - t1.TotalHours) && (t - t1.TotalHours) <= 17)//第二天上午完成
                    //            {
                    //                picker2.Value = strtimediertian.AddDays(1).AddHours(t - t1.TotalHours - 5.5);
                    //            }
                    //            if (17 < (t - t1.TotalHours) && (t - t1.TotalHours) <= 21.5)//第二天下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t - t1.TotalHours - 17);
                    //            }
                    //        }
                    //        else//下午加工完成
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }

                    //    }

                    //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                    //    int ta7 = time1time.CompareTo(shijian4);
                    //    int ta8 = shijian5.CompareTo(time1time);

                    //    if (ta7 == 1 && ta8 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        picker1.Value = strtimewuye;
                    //        if (0 < t && t <= 5.5)//午夜前完成
                    //        {
                    //            picker2.Value = strtimewuye.AddHours(t);
                    //        }
                    //        if (5.5 < t && t <= 17)//第二天上午完成
                    //        {
                    //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 5.5);
                    //        }
                    //        if (17 < t && t <= 21.5)//第二天下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 17);
                    //        }
                    //    }

                    //    //当前设置工序的时间 18:00:00< 时间 < 
                    //    int ta9 = time1time.CompareTo(shijian5);
                    //    if (ta9 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                    //        picker1.Value = strtime;
                    //        TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                    //        double tsheng = t - t1.TotalHours;
                    //        if (tsheng >= 0)
                    //        {
                    //            if (tsheng <= 11.5)
                    //            {
                    //                picker2.Value = strtimediertian.AddDays(1).AddHours(tsheng);
                    //            }
                    //            if (11.5 < tsheng && tsheng <= 16)
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tsheng - 11.5);
                    //            }
                    //            if (16 < tsheng && tsheng <= 21.5)
                    //            {
                    //                picker2.Value = strtimewuye.AddDays(1).AddHours(tsheng - 16);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //    }

                    //}

                    //#endregion

                    //#region 工时大于1天小于2天  21.5<t<=43

                    //if (21.5 < t && t < 43)
                    //{
                    //    //当前设置工序的时间 < 12:00:00
                    //    int ta1 = shijian2.CompareTo(time1time);

                    //    if (ta1 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                    //        TimeSpan ta2 = strtimeshangwu - strtime;//上午加工的时间
                    //        if (t >= ta2.TotalHours)//上午没有加工完成
                    //        {
                    //            double t1 = t - 21.5 - ta2.TotalHours;
                    //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                    //            }

                    //            if (4.5 < t1 && t1 <= 10)//午夜完成
                    //            {
                    //                picker2.Value = strtimewuye.AddDays(1).AddHours(t1 - 4.5);
                    //            }
                    //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                    //            {
                    //                picker2.Value = strtimediertian.AddDays(2).AddHours(t1 - 10);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t);
                    //        }
                    //    }

                    //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                    //    int ta3 = time1time.CompareTo(shijian2);
                    //    int ta4 = shijian3.CompareTo(time1time);

                    //    if (ta4 == 1 && ta3 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                    //        if (0 < t - 21.5 && t - 21.5 <= 4.5)//下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 21.5);
                    //        }
                    //        if (4.5 < t - 21.5 && t - 21.5 <= 10)//午夜完成
                    //        {
                    //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - 4.5);
                    //        }
                    //        if (10 < t - 21.5 && t - 21.5 <= 21.5)//第二天完成
                    //        {
                    //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 10);
                    //        }
                    //    }

                    //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                    //    int ta5 = time1time.CompareTo(shijian3);
                    //    int ta6 = shijian4.CompareTo(time1time);

                    //    if (ta5 == 1 && ta6 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        picker1.Value = strtime;
                    //        TimeSpan t1 = strtime1 - strtime;//下午加工的时间
                    //        if (t - 21.5 >= t1.TotalHours)//下午没有加工完成
                    //        {
                    //            if ((t - 21.5 - t1.TotalHours) <= 5.5)//午夜之前可以完成
                    //            {
                    //                picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - t1.TotalHours);
                    //            }
                    //            if (5.5 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 17)//第二天上午完成
                    //            {
                    //                picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 5.5);
                    //            }
                    //            if (17 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 21.5)//第二天下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 17);
                    //            }
                    //        }
                    //        else//下午加工完成
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 21.5);
                    //        }

                    //    }

                    //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                    //    int ta7 = time1time.CompareTo(shijian4);
                    //    int ta8 = shijian5.CompareTo(time1time);

                    //    if (ta7 == 1 && ta8 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        picker1.Value = strtimewuye;
                    //        if (0 < t - 21.5 && t - 21.5 <= 5.5)//午夜前完成
                    //        {
                    //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5);
                    //        }
                    //        if (5.5 < t - 21.5 && t - 21.5 <= 17)//第二天上午完成
                    //        {
                    //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 5.5);
                    //        }
                    //        if (17 < t - 21.5 && t - 21.5 <= 21.5)//第二天下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - 17);
                    //        }
                    //    }

                    //    //当前设置工序的时间 18:00:00< 时间 < 
                    //    int ta9 = time1time.CompareTo(shijian5);
                    //    if (ta9 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时分秒
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                    //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                    //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                    //        picker1.Value = strtime;
                    //        TimeSpan t1 = strtime2 - strtime;//午夜加工的时间
                    //        double tsheng = t - 21.5 - t1.TotalHours;
                    //        if (tsheng >= 0)
                    //        {
                    //            if (tsheng <= 11.5)
                    //            {
                    //                picker2.Value = strtimediertian.AddDays(2).AddHours(tsheng);
                    //            }
                    //            if (11.5 < tsheng && tsheng <= 16)
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tsheng - 11.5);
                    //            }
                    //            if (16 < tsheng && tsheng <= 21.5)
                    //            {
                    //                picker2.Value = strtimewuye.AddDays(2).AddHours(tsheng - 16);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 21.5);
                    //        }
                    //    }
                    //}

                    //#endregion
                    #endregion


                }
                else//设定的结束时间大于现在的时间（排产排到后面）------ret3 > time1(设定的结束时间大于当前时间)
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);

                    string ret3date = ret3.ToString("yyyy/MM/dd");
                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 21.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                    if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
                    {

                        //当前设置工序的时间 < 12:00:00
                        int ta1 = shijian2.CompareTo(time1time);

                        if (ta1 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30


                            TimeSpan ta2 = strtimeshangwu - ret3;//上午加工的时间
                            if (t >= ta2.TotalHours)//上午没有加工完成
                            {
                                double t1 = t - 21.5 * at - ta2.TotalHours;
                                if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                                }

                                if (4.5 < t1 && t1 <= 10)//午夜完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                                }
                                if (10 < t1 && t1 <= 21.5)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t);
                            }
                        }

                        //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        int ta3 = time1time.CompareTo(shijian2);
                        int ta4 = shijian3.CompareTo(time1time);

                        if (ta4 == 1 && ta3 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            picker1.Value = Convert.ToDateTime(strtimexiawu);

                            if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                            }
                            if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                            }
                        }

                        //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        int ta5 = time1time.CompareTo(shijian3);
                        int ta6 = shijian4.CompareTo(time1time);

                        if (ta5 == 1 && ta6 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            picker1.Value = ret3;
                            TimeSpan t1 = strtime1 - ret3;//下午加工的时间
                            if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                            {
                                if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                                }
                                if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                                }
                                if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                                }
                            }
                            else//下午加工完成
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 21.5 * at);
                            }

                        }

                        //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        int ta7 = time1time.CompareTo(shijian4);
                        int ta8 = shijian5.CompareTo(time1time);

                        if (ta7 == 1 && ta8 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            picker1.Value = strtimewuye;
                            if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                            }
                            if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                            }
                        }

                        //当前设置工序的时间 18:00:00< 时间 < 
                        int ta9 = time1time.CompareTo(shijian5);
                        if (ta9 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                            DateTime strtime2 = Convert.ToDateTime(ret3date + " " + shijian7);//日期+23:30

                            picker1.Value = ret3;
                            TimeSpan t1 = strtime2 - ret3;//午夜加工的时间
                            double tsheng = t - 21.5 * at - t1.TotalHours;
                            if (tsheng >= 0)
                            {
                                if (tsheng <= 11.5)
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                                }
                                if (11.5 < tsheng && tsheng <= 16)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                                }
                                if (16 < tsheng && tsheng <= 21.5)
                                {
                                    picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 21.5 * at);
                            }
                        }

                        #region 死方法
                        //#region 工时小于等于1天的工时 t<=21.5

                        //if (0 < t && t < 21.5)
                        //{
                        //    //当前设置工序的时间 < 12:00:00
                        //    int ta1 = shijian2.CompareTo(time1time);

                        //    if (ta1 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30


                        //        TimeSpan ta2 = strtimeshangwu - ret3;//上午加工的时间
                        //        if (t >= ta2.TotalHours)//上午没有加工完成
                        //        {
                        //            double t1 = t - ta2.TotalHours;
                        //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(t1);
                        //            }

                        //            if (4.5 < t1 && t1 <= 10)//午夜完成
                        //            {
                        //                picker2.Value = strtimewuye.AddHours(t1 - 4.5);
                        //            }
                        //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(1).AddHours(t1 - 10);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);
                        //        }
                        //    }

                        //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        //    int ta3 = time1time.CompareTo(shijian2);
                        //    int ta4 = shijian3.CompareTo(time1time);

                        //    if (ta4 == 1 && ta3 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                        //        if (0 < t && t <= 4.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddHours(t);
                        //        }
                        //        if (4.5 < t && t <= 10)//午夜完成
                        //        {
                        //            picker2.Value = strtimewuye.AddHours(t - 4.5);
                        //        }
                        //        if (10 < t && t <= 21.5)//第二天完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 10);
                        //        }
                        //    }

                        //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        //    int ta5 = time1time.CompareTo(shijian3);
                        //    int ta6 = shijian4.CompareTo(time1time);

                        //    if (ta5 == 1 && ta6 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        picker1.Value = ret3;
                        //        TimeSpan t1 = strtime1 - ret3;//下午加工的时间
                        //        if (t >= t1.TotalHours)//下午没有加工完成
                        //        {
                        //            if ((t - t1.TotalHours) <= 5.5)//午夜之前可以完成
                        //            {
                        //                picker2.Value = strtimewuye.AddHours(t - t1.TotalHours);
                        //            }
                        //            if (5.5 < (t - t1.TotalHours) && (t - t1.TotalHours) <= 17)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(1).AddHours(t - t1.TotalHours - 5.5);
                        //            }
                        //            if (17 < (t - t1.TotalHours) && (t - t1.TotalHours) <= 21.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t - t1.TotalHours - 17);
                        //            }
                        //        }
                        //        else//下午加工完成
                        //        {
                        //            picker2.Value = ret3.AddHours(t);
                        //        }

                        //    }

                        //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        //    int ta7 = time1time.CompareTo(shijian4);
                        //    int ta8 = shijian5.CompareTo(time1time);

                        //    if (ta7 == 1 && ta8 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        picker1.Value = strtimewuye;
                        //        if (0 < t && t <= 5.5)//午夜前完成
                        //        {
                        //            picker2.Value = strtimewuye.AddHours(t);
                        //        }
                        //        if (5.5 < t && t <= 17)//第二天上午完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 5.5);
                        //        }
                        //        if (17 < t && t <= 21.5)//第二天下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 17);
                        //        }
                        //    }

                        //    //当前设置工序的时间 18:00:00< 时间 < 
                        //    int ta9 = time1time.CompareTo(shijian5);
                        //    if (ta9 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + shijian7);//日期+23:30

                        //        picker1.Value = ret3;
                        //        TimeSpan t1 = strtime2 - ret3;//午夜加工的时间
                        //        double tsheng = t - t1.TotalHours;
                        //        if (tsheng >= 0)
                        //        {
                        //            if (tsheng <= 11.5)
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(1).AddHours(tsheng);
                        //            }
                        //            if (11.5 < tsheng && tsheng <= 16)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tsheng - 11.5);
                        //            }
                        //            if (16 < tsheng && tsheng <= 21.5)
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(1).AddHours(tsheng - 16);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);
                        //        }
                        //    }

                        //}

                        //#endregion

                        //#region 工时大于1天小于2天  21.5<t<=43

                        //if (21.5 < t && t < 43)
                        //{
                        //    //当前设置工序的时间 < 12:00:00
                        //    int ta1 = shijian2.CompareTo(time1time);

                        //    if (ta1 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30


                        //        TimeSpan ta2 = strtimeshangwu - ret3;//上午加工的时间
                        //        if (t >= ta2.TotalHours)//上午没有加工完成
                        //        {
                        //            double t1 = t - 21.5 - ta2.TotalHours;
                        //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                        //            }

                        //            if (4.5 < t1 && t1 <= 10)//午夜完成
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(1).AddHours(t1 - 4.5);
                        //            }
                        //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(2).AddHours(t1 - 10);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t);
                        //        }
                        //    }

                        //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        //    int ta3 = time1time.CompareTo(shijian2);
                        //    int ta4 = shijian3.CompareTo(time1time);

                        //    if (ta4 == 1 && ta3 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                        //        if (0 < t - 21.5 && t - 21.5 <= 4.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 21.5);
                        //        }
                        //        if (4.5 < t - 21.5 && t - 21.5 <= 10)//午夜完成
                        //        {
                        //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - 4.5);
                        //        }
                        //        if (10 < t - 21.5 && t - 21.5 <= 21.5)//第二天完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 10);
                        //        }
                        //    }

                        //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        //    int ta5 = time1time.CompareTo(shijian3);
                        //    int ta6 = shijian4.CompareTo(time1time);

                        //    if (ta5 == 1 && ta6 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        picker1.Value = ret3;
                        //        TimeSpan t1 = strtime1 - ret3;//下午加工的时间
                        //        if (t - 21.5 >= t1.TotalHours)//下午没有加工完成
                        //        {
                        //            if ((t - 21.5 - t1.TotalHours) <= 5.5)//午夜之前可以完成
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - t1.TotalHours);
                        //            }
                        //            if (5.5 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 17)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 5.5);
                        //            }
                        //            if (17 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 21.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 17);
                        //            }
                        //        }
                        //        else//下午加工完成
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 21.5);
                        //        }

                        //    }

                        //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        //    int ta7 = time1time.CompareTo(shijian4);
                        //    int ta8 = shijian5.CompareTo(time1time);

                        //    if (ta7 == 1 && ta8 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        picker1.Value = strtimewuye;
                        //        if (0 < t - 21.5 && t - 21.5 <= 5.5)//午夜前完成
                        //        {
                        //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5);
                        //        }
                        //        if (5.5 < t - 21.5 && t - 21.5 <= 17)//第二天上午完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 5.5);
                        //        }
                        //        if (17 < t - 21.5 && t - 21.5 <= 21.5)//第二天下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - 17);
                        //        }
                        //    }

                        //    //当前设置工序的时间 18:00:00< 时间 < 
                        //    int ta9 = time1time.CompareTo(shijian5);
                        //    if (ta9 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(ret3date + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(ret3date + " " + shijian8);//日期+00:30

                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + shijian7);//日期+23:30

                        //        picker1.Value = ret3;
                        //        TimeSpan t1 = strtime2 - ret3;//午夜加工的时间
                        //        double tsheng = t - 21.5 - t1.TotalHours;
                        //        if (tsheng >= 0)
                        //        {
                        //            if (tsheng <= 11.5)
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(2).AddHours(tsheng);
                        //            }
                        //            if (11.5 < tsheng && tsheng <= 16)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tsheng - 11.5);
                        //            }
                        //            if (16 < tsheng && tsheng <= 21.5)
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(2).AddHours(tsheng - 16);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 21.5);
                        //        }
                        //    }
                        //}

                        //#endregion
                        #endregion
                    }
                    else//-----------------ret3 < datetimepicker(用time1date和time1time)----time
                    {

                        //当前设置工序的时间 < 12:00:00
                        int ta1 = shijian2.CompareTo(time1time);

                        if (ta1 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            picker1.Value = Convert.ToDateTime(time);
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                            TimeSpan ta2 = strtimeshangwu - time;//上午加工的时间
                            if (t >= ta2.TotalHours)//上午没有加工完成
                            {
                                double t1 = t - 21.5 * at - ta2.TotalHours;
                                if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);
                                }

                                if (4.5 < t1 && t1 <= 10)//午夜完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t1 - 4.5);
                                }
                                if (10 < t1 && t1 <= 21.5)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t1 - 10);
                                }
                            }
                            else
                            {
                                picker2.Value = time.AddDays(at).AddHours(t);
                            }
                        }

                        //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        int ta3 = time1time.CompareTo(shijian2);
                        int ta4 = shijian3.CompareTo(time1time);

                        if (ta4 == 1 && ta3 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            picker1.Value = Convert.ToDateTime(strtimexiawu);

                            if (0 < t - 21.5 * at && t - 21.5 * at <= 4.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (4.5 < t - 21.5 * at && t - 21.5 * at <= 10)//午夜完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - 4.5);
                            }
                            if (10 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 10);
                            }
                        }

                        //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        int ta5 = time1time.CompareTo(shijian3);
                        int ta6 = shijian4.CompareTo(time1time);

                        if (ta5 == 1 && ta6 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            picker1.Value = time;
                            TimeSpan t1 = strtime1 - time;//下午加工的时间
                            if (t - 21.5 * at >= t1.TotalHours)//下午没有加工完成
                            {
                                if ((t - 21.5 * at - t1.TotalHours) <= 5.5)//午夜之前可以完成
                                {
                                    picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at - t1.TotalHours);
                                }
                                if (5.5 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 17)//第二天上午完成
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 5.5);
                                }
                                if (17 < (t - 21.5 * at - t1.TotalHours) && (t - 21.5 * at - t1.TotalHours) <= 21.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - t1.TotalHours - 17);
                                }
                            }
                            else//下午加工完成
                            {
                                picker2.Value = time.AddDays(at).AddHours(t - 21.5 * at);
                            }

                        }

                        //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        int ta7 = time1time.CompareTo(shijian4);
                        int ta8 = shijian5.CompareTo(time1time);

                        if (ta7 == 1 && ta8 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            picker1.Value = strtimewuye;
                            if (0 < t - 21.5 * at && t - 21.5 * at <= 5.5)//午夜前完成
                            {
                                picker2.Value = strtimewuye.AddDays(at).AddHours(t - 21.5 * at);
                            }
                            if (5.5 < t - 21.5 * at && t - 21.5 * at <= 17)//第二天上午完成
                            {
                                picker2.Value = strtimediertian.AddDays(at + 1).AddHours(t - 21.5 * at - 5.5);
                            }
                            if (17 < t - 21.5 * at && t - 21.5 * at <= 21.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - 21.5 * at - 17);
                            }
                        }

                        //当前设置工序的时间 18:00:00< 时间 < 
                        int ta9 = time1time.CompareTo(shijian5);
                        if (ta9 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                            DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                            picker1.Value = time;
                            TimeSpan t1 = strtime2 - time;//午夜加工的时间
                            double tsheng = t - 21.5 * at - t1.TotalHours;
                            if (tsheng >= 0)
                            {
                                if (tsheng <= 11.5)
                                {
                                    picker2.Value = strtimediertian.AddDays(at + 1).AddHours(tsheng);
                                }
                                if (11.5 < tsheng && tsheng <= 16)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(tsheng - 11.5);
                                }
                                if (16 < tsheng && tsheng <= 21.5)
                                {
                                    picker2.Value = strtimewuye.AddDays(at + 1).AddHours(tsheng - 16);
                                }
                            }
                            else
                            {
                                picker2.Value = time.AddDays(at).AddHours(t - 21.5 * at);
                            }
                        }

                        #region 死方法
                        //#region 工时小于等于1天的工时 t<=21.5

                        //if (0 < t && t < 21.5)
                        //{
                        //    //当前设置工序的时间 < 12:00:00
                        //    int ta1 = shijian2.CompareTo(time1time);

                        //    if (ta1 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        picker1.Value = Convert.ToDateTime(time);
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                        //        TimeSpan ta2 = strtimeshangwu - time;//上午加工的时间
                        //        if (t >= ta2.TotalHours)//上午没有加工完成
                        //        {
                        //            double t1 = t - ta2.TotalHours;
                        //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(t1);
                        //            }

                        //            if (4.5 < t1 && t1 <= 10)//午夜完成
                        //            {
                        //                picker2.Value = strtimewuye.AddHours(t1 - 4.5);
                        //            }
                        //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(1).AddHours(t1 - 10);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddHours(t);
                        //        }
                        //    }

                        //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        //    int ta3 = time1time.CompareTo(shijian2);
                        //    int ta4 = shijian3.CompareTo(time1time);

                        //    if (ta4 == 1 && ta3 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                        //        if (0 < t && t <= 4.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddHours(t);
                        //        }
                        //        if (4.5 < t && t <= 10)//午夜完成
                        //        {
                        //            picker2.Value = strtimewuye.AddHours(t - 4.5);
                        //        }
                        //        if (10 < t && t <= 21.5)//第二天完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 10);
                        //        }
                        //    }

                        //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        //    int ta5 = time1time.CompareTo(shijian3);
                        //    int ta6 = shijian4.CompareTo(time1time);

                        //    if (ta5 == 1 && ta6 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        picker1.Value = time;
                        //        TimeSpan t1 = strtime1 - time;//下午加工的时间
                        //        if (t >= t1.TotalHours)//下午没有加工完成
                        //        {
                        //            if ((t - t1.TotalHours) <= 5.5)//午夜之前可以完成
                        //            {
                        //                picker2.Value = strtimewuye.AddHours(t - t1.TotalHours);
                        //            }
                        //            if (5.5 < (t - t1.TotalHours) && (t - t1.TotalHours) <= 17)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(1).AddHours(t - t1.TotalHours - 5.5);
                        //            }
                        //            if (17 < (t - t1.TotalHours) && (t - t1.TotalHours) <= 21.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t - t1.TotalHours - 17);
                        //            }
                        //        }
                        //        else//下午加工完成
                        //        {
                        //            picker2.Value = time.AddHours(t);
                        //        }

                        //    }

                        //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        //    int ta7 = time1time.CompareTo(shijian4);
                        //    int ta8 = shijian5.CompareTo(time1time);

                        //    if (ta7 == 1 && ta8 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        picker1.Value = strtimewuye;
                        //        if (0 < t && t <= 5.5)//午夜前完成
                        //        {
                        //            picker2.Value = strtimewuye.AddHours(t);
                        //        }
                        //        if (5.5 < t && t <= 17)//第二天上午完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(1).AddHours(t - 5.5);
                        //        }
                        //        if (17 < t && t <= 21.5)//第二天下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 17);
                        //        }
                        //    }

                        //    //当前设置工序的时间 18:00:00< 时间 < 
                        //    int ta9 = time1time.CompareTo(shijian5);
                        //    if (ta9 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                        //        picker1.Value = time;
                        //        TimeSpan t1 = strtime2 - time;//午夜加工的时间
                        //        double tsheng = t - t1.TotalHours;
                        //        if (tsheng >= 0)
                        //        {
                        //            if (tsheng <= 11.5)
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(1).AddHours(tsheng);
                        //            }
                        //            if (11.5 < tsheng && tsheng <= 16)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tsheng - 11.5);
                        //            }
                        //            if (16 < tsheng && tsheng <= 21.5)
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(1).AddHours(tsheng - 16);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddHours(t);
                        //        }
                        //    }

                        //}

                        //#endregion

                        //#region 工时大于1天小于2天  21.5<t<=43

                        //if (21.5 < t && t < 43)
                        //{
                        //    //当前设置工序的时间 < 12:00:00
                        //    int ta1 = shijian2.CompareTo(time1time);

                        //    if (ta1 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        picker1.Value = Convert.ToDateTime(time);
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30


                        //        TimeSpan ta2 = strtimeshangwu - time;//上午加工的时间
                        //        if (t >= ta2.TotalHours)//上午没有加工完成
                        //        {
                        //            double t1 = t - 21.5 - ta2.TotalHours;
                        //            if (t1 > 0 && t1 <= 4.5)//下午加工完成不了
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                        //            }

                        //            if (4.5 < t1 && t1 <= 10)//午夜完成
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(1).AddHours(t1 - 4.5);
                        //            }
                        //            if (10 < t1 && t1 <= 21.5)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(2).AddHours(t1 - 10);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddDays(1).AddHours(t);
                        //        }
                        //    }

                        //    //当前设置工序的时间 12:00:00< 时间 < 13:00:00
                        //    int ta3 = time1time.CompareTo(shijian2);
                        //    int ta4 = shijian3.CompareTo(time1time);

                        //    if (ta4 == 1 && ta3 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        picker1.Value = Convert.ToDateTime(strtimexiawu);

                        //        if (0 < t - 21.5 && t - 21.5 <= 4.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 21.5);
                        //        }
                        //        if (4.5 < t - 21.5 && t - 21.5 <= 10)//午夜完成
                        //        {
                        //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - 4.5);
                        //        }
                        //        if (10 < t - 21.5 && t - 21.5 <= 21.5)//第二天完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 10);
                        //        }
                        //    }

                        //    //当前设置工序的时间 13:00:00< 时间 < 17:30:00
                        //    int ta5 = time1time.CompareTo(shijian3);
                        //    int ta6 = shijian4.CompareTo(time1time);

                        //    if (ta5 == 1 && ta6 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        picker1.Value = time;
                        //        TimeSpan t1 = strtime1 - time;//下午加工的时间
                        //        if (t - 21.5 >= t1.TotalHours)//下午没有加工完成
                        //        {
                        //            if ((t - 21.5 - t1.TotalHours) <= 5.5)//午夜之前可以完成
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5 - t1.TotalHours);
                        //            }
                        //            if (5.5 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 17)//第二天上午完成
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 5.5);
                        //            }
                        //            if (17 < (t - 21.5 - t1.TotalHours) && (t - 21.5 - t1.TotalHours) <= 21.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - t1.TotalHours - 17);
                        //            }
                        //        }
                        //        else//下午加工完成
                        //        {
                        //            picker2.Value = time.AddDays(1).AddHours(t - 21.5);
                        //        }

                        //    }

                        //    //当前设置工序的时间 17:30:00< 时间 < 18:00:00
                        //    int ta7 = time1time.CompareTo(shijian4);
                        //    int ta8 = shijian5.CompareTo(time1time);

                        //    if (ta7 == 1 && ta8 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        picker1.Value = strtimewuye;
                        //        if (0 < t - 21.5 && t - 21.5 <= 5.5)//午夜前完成
                        //        {
                        //            picker2.Value = strtimewuye.AddDays(1).AddHours(t - 21.5);
                        //        }
                        //        if (5.5 < t - 21.5 && t - 21.5 <= 17)//第二天上午完成
                        //        {
                        //            picker2.Value = strtimediertian.AddDays(2).AddHours(t - 21.5 - 5.5);
                        //        }
                        //        if (17 < t - 21.5 && t - 21.5 <= 21.5)//第二天下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 21.5 - 17);
                        //        }
                        //    }

                        //    //当前设置工序的时间 18:00:00< 时间 < 
                        //    int ta9 = time1time.CompareTo(shijian5);
                        //    if (ta9 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时分秒
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian4);//当前日期+17:30
                        //        DateTime strtimeshangwu = Convert.ToDateTime(time1date1 + " " + shijian2);//当前日期+12:00:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtimediertian = Convert.ToDateTime(time1date1 + " " + shijian8);//日期+00:30

                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + shijian7);//日期+23:30

                        //        picker1.Value = time;
                        //        TimeSpan t1 = strtime2 - time;//午夜加工的时间
                        //        double tsheng = t - 21.5 - t1.TotalHours;
                        //        if (tsheng >= 0)
                        //        {
                        //            if (tsheng <= 11.5)
                        //            {
                        //                picker2.Value = strtimediertian.AddDays(2).AddHours(tsheng);
                        //            }
                        //            if (11.5 < tsheng && tsheng <= 16)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tsheng - 11.5);
                        //            }
                        //            if (16 < tsheng && tsheng <= 21.5)
                        //            {
                        //                picker2.Value = strtimewuye.AddDays(2).AddHours(tsheng - 16);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddDays(1).AddHours(t - 21.5);
                        //        }
                        //    }
                        //}

                        //#endregion
                        #endregion
                    }

                }

            }

            #endregion
        }

        /// <summary>
        /// 非数控设备排产----8小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {

            DateTime time1 = DateTime.Now;//现在的当前时间（日期+时分秒）

            string sql1 = "select 设定开始时间 from db_Paichan where 工序设备='" + shebei + "'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            #region 设备空闲中
            if (ret1 == "")//现在这个设备空闲中
            {
                //算总的工时
                double price = Convert.ToDouble(jiage);
                price = price * (Convert.ToInt32(shuliang));
                double t = (double)price / 27;
                double aa = t / 8.5;
                int a = Convert.ToInt32(aa.ToString().Split(char.Parse("."))[0]);

                //总的一天的工时
                TimeSpan thourshangwu = T2 - T1;//上午的时间差
                TimeSpan thourxiawu = T4 - T3;//下午的时间差
                //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
                //gongshi = Math.Round(gongshi, 2);


                int ta1 = Time1.CompareTo(time1time);

                if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    int ta2 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

                    if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                    {

                        double t1 = t - 8.5 * a - thourshangwu.TotalHours;//剩余加工时间下午完成
                        if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                        {
                            picker2.Value = strtimexiawu.AddDays(a + 1).AddHours(t1);
                        }
                    }
                    else//时间小于11:20（第三天早上完成）
                    {
                        picker2.Value = strtime.AddDays(a + 1).AddHours(t - 8.5 * a);
                    }

                }

                int ta3 = time1time.CompareTo(Time1);
                int ta4 = Time2.CompareTo(time1time);
                if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                    int ta5 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

                    if (ta5 == 1 || ta5 == 0)//时间大于11:20
                    {
                        TimeSpan tcha = Time22 - strtime;
                        double t1 = t - 8.5 * a - tcha.TotalHours;//剩余加工的时间
                        if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                        {
                            picker2.Value = strtimexiawu.AddDays(a - 1).AddHours(t1);
                        }
                        else//大于下午的时间差 && 小于第二天的上午的时间差
                        {
                            double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                            picker2.Value = strtime1.AddDays(a + 1).AddHours(tsheng);
                        }
                    }
                    else//16.几 小时的工时
                    {
                        picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    }
                }

                int ta6 = time1time.CompareTo(Time2);
                int ta7 = Time3.CompareTo(time1time);

                if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                    int ta8 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);

                    if (ta8 == 1 || ta8 == 0)//时间大于17:30
                    {

                        double t1 = t - 8.5 * a - thourxiawu.TotalHours;
                        if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                        {
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                            picker2.Value = strtime1.AddDays(a + 1).AddHours(t1);
                        }
                        //大于2天小于等于3天 最多到第三天的上午结束
                    }
                    else//时间小于17:30
                    {
                        picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    }
                }

                int ta9 = time1time.CompareTo(Time3);
                int ta10 = Time4.CompareTo(time1time);

                if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    picker1.Value = Convert.ToDateTime(strtime);
                    //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                    DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                    int ta11 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);

                    if (ta11 == 1 || ta11 == 0)
                    {
                        TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                        double ttzhi = t - 8.5 * a - tzhi.TotalHours;//剩余加工的时间
                        if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                        {
                            picker2.Value = strtime1.AddDays(a).AddHours(ttzhi);
                        }
                        else//大于上午的时间
                        {
                            double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                            picker2.Value = strtime2.AddDays(a + 1).AddHours(ttzhi);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    }

                }

                int ta12 = time1time.CompareTo(Time4);

                if (ta12 == 1)//第二天做
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    int ta13 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

                    if (ta13 == 1 || ta13 == 0)//时间大于11:20
                    {

                        double t1 = t - 8.5 * a - thourshangwu.TotalHours;
                        if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                        {
                            picker2.Value = strtimexiawu.AddDays(a + 1).AddHours(t1);
                        }
                    }
                    else//时间小于11:20
                    {
                        picker2.Value = strtime.AddDays(a + 1).AddHours(t);
                    }
                }

                #region 死方法
                //    #region 工时小于等于一天的工时 <=8.5小时

                //    if (t <= gongshi)//总工时小于一天的工时(一天之内可以完成的)
                //{
                //    //    A.CompareTo(B)
                //    //    A<B -----返回  -1
                //    //    A=B -----返回   0
                //    //    A>B -----返回   1
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30

                //        int ta2 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1)//时间大于11:30  
                //        {

                //            double t1 = t - thourshangwu.TotalHours;//t1是剩余加工时间
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddHours(t1);
                //            }
                //            //不可能大于下午的时间差（从8点开始到5:30正好8个工时）
                //        }
                //        else//时间小于11:30
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:30
                //    {

                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:30

                //        TimeSpan a = Time22 - strtime;//上午加工的时间
                //        if(t >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                //        {
                //            //taa5 = strtimexiawu.AddHours(t - a.TotalHours).ToString("HH:mm:ss").CompareTo(Time4);
                //            double tt = t - a.TotalHours;//剩余加工的时间
                //            if(tt >= thourxiawu.TotalHours)//第二天上午做完
                //            {
                //                picker2.Value = strtime1.AddDays(1).AddHours(tt - thourxiawu.TotalHours);
                //            }
                //            else//下午做完
                //            {
                //                picker2.Value = strtimexiawu.AddHours(tt);
                //            }

                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }

                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:30 小于12:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:30:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        //int ta8 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                //        double t1 = t - thourxiawu.TotalHours;//下午工作的时间
                //        if(t1 > 0)
                //        {
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第二天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(1).AddHours(t1);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }

                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " "+ Time3);//日期+12:30
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        //int ta11 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);
                //        TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //        if (t > tzhi.TotalHours)
                //        {

                //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                //                picker2.Value = strtime2.AddDays(1).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1 )//第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30

                //        //int ta13 = strtime.AddDays(1).AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                //        double t1 = t - thourshangwu.TotalHours;//上午加工的时间
                //        if(t1 > 0)
                //        {
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                //            }
                //            //工时最多8个小时（第二天的8点做到17:50）
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t);
                //        }
                //    }

                //}

                //#endregion

                //#region 工时大于一天的工时 && 小于两天的工时

                //if (1.0 < flag && flag <= 2.0)
                //{

                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1 )//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30

                //        int ta2 = strtime.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time2);//与下一天的11:20比较

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20  
                //        {

                //            double t1 = t - 8.5 - thourshangwu.TotalHours;//第二天剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                //            }
                //            //剩余加工的时间一定小于等于下午的工时（8<t<=16）
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 8.5);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time2);//下一天的结束时间与11:20比较

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 8.5 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//如果下午能够加工完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间(第三天上午加工完成)
                //                picker2.Value = strtime1.AddDays(2).AddHours(tsheng);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 8.5);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time4);//相当于工时是8.几小时

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 8.5 - thourxiawu.TotalHours;//剩余的第三天上午做完（相当于第二天下午做不完）
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于等于第三天上午的时间差（8<t<=16）
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(2).AddHours(t1);
                //            }
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 8.5);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1  && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        string aql = strtime.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss");
                //        int ta11 = aql.CompareTo(Time4);//相当于8.5小时工时

                //        if (ta11 == 1 || ta11 == 0)//第二天下午做不完
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//第二天下午工作的时间
                //            double ttzhi = t - 8.5 - tzhi.TotalHours;//剩余加工的时间（第三天做）
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（第三天下午做完）
                //                if (tttzhi <= thourxiawu.TotalHours)//小于下午加工的时间
                //                {
                //                    picker2.Value = strtime2.AddDays(2).AddHours(ttzhi);
                //                }

                //            }
                //        }//第二天下午做完
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 8.5);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1 )//第二天开始做、需要到第三天才完成(设置工序的时间大于17:50 -----> 即工艺员加班)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);//第二天8:00开始做
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(2).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20 //第三天下午做完
                //        {

                //            double t1 = t - 8.5 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于等于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20 //第三天上午做完
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 8.5);
                //        }
                //    }

                //}

                //#endregion

                //#region 工时大于两天 小于等于三天

                //if (2.0 < flag && flag <= 3.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1 )//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 17 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(3).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 17 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(3).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 17 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(3).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(3).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 17 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(3).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于三天小于四天

                //if (3.0 < flag && flag <= 4.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(3).AddHours(t - 25.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 25.5 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(3).AddHours(t - 25.5);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(3).AddHours(t - 25.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(4).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(3).AddHours(t - 25.5);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(3).AddHours(t - 25.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 25.5 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(4).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(3).AddHours(t - 25.5);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(3).AddHours(t - 25.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 25.5 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(4).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(4).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(3).AddHours(t - 25.5);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(4).AddHours(t - 25.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 17 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(4).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(4).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于四天小于五天

                //if (4.0 < flag && flag <= 5.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(4).AddHours(t - 34).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 34 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(4).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(4).AddHours(t - 34);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(4).AddHours(t - 34).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 34 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(4).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(5).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(4).AddHours(t - 34);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(4).AddHours(t - 34).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 34 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(5).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(4).AddHours(t - 34);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(4).AddHours(t - 34).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 34 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(5).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(5).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(4).AddHours(t - 34);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(5).AddHours(t - 34).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 34 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(5).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(5).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于五天小于六天

                //if (5.0 < flag && flag <= 6.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(5).AddHours(t - 42.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 42.5 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(5).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(5).AddHours(t - 42.5);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(5).AddHours(t - 42.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 42.5 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(5).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(6).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(5).AddHours(t - 42.5);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(5).AddHours(t - 42.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 42.5 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(6).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(5).AddHours(t - 42.5);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(5).AddHours(t - 42.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 42.5 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(6).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(6).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(5).AddHours(t - 42.5);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(6).AddHours(t - 42.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 42.5 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(6).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(6).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于六天小于七天

                //if (6.0 < flag && flag <= 7.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(6).AddHours(t - 51).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 51 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(6).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(6).AddHours(t - 51);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(6).AddHours(t - 51).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 51 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(6).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(7).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(6).AddHours(t - 51);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(6).AddHours(t - 51).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 51 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(7).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(6).AddHours(t - 51);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(6).AddHours(t - 51).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 51 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(7).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(7).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(6).AddHours(t - 51);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(7).AddHours(t - 51).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 51 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(7).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(7).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于七天小于八天

                //if (7.0 < flag && flag <= 8.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(7).AddHours(t - 59.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 59.5 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(7).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(7).AddHours(t - 59.5);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(7).AddHours(t - 59.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 59.5 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(7).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(8).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(7).AddHours(t - 59.5);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(7).AddHours(t - 51).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 59.5 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(8).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(7).AddHours(t - 59.5);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(7).AddHours(t - 59.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 59.5 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(8).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(8).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(7).AddHours(t - 59.5);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(8).AddHours(t - 59.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 59.5 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(8).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(8).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于八天小于九天

                //if (8.0 < flag && flag <= 9.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(8).AddHours(t - 68).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 68 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(8).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(8).AddHours(t - 68);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(8).AddHours(t - 68).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 68 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(8).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(9).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(8).AddHours(t - 68);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(8).AddHours(t - 68).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 68 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(9).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(8).AddHours(t - 68);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(8).AddHours(t - 68).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 68 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(9).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(9).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(8).AddHours(t - 68);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(9).AddHours(t - 68).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 68 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(9).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(9).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于九天小于十天

                //if (9.0 < flag && flag <= 10.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(9).AddHours(t - 76.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 76.5 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(9).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(9).AddHours(t - 76.5);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(9).AddHours(t - 76.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 76.5 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(9).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(10).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(9).AddHours(t - 76.5);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(9).AddHours(t - 76.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 76.5 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(10).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(9).AddHours(t - 76.5);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(9).AddHours(t - 76.5).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 76.5 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(10).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(10).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(9).AddHours(t - 76.5);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(10).AddHours(t - 76.5).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 76.5 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(10).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(10).AddHours(t);
                //        }
                //    }
                //}

                //#endregion

                //#region 工时大于十天小于十一天

                //if (10.0 < flag && flag <= 11.0)
                //{
                //    int ta1 = Time1.CompareTo(time1time);

                //    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta2 = strtime.AddDays(10).AddHours(t - 85).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                //        {

                //            double t1 = t - 85 - thourshangwu.TotalHours;//剩余加工时间下午完成
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(10).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20（第三天早上完成）
                //        {
                //            picker2.Value = strtime.AddDays(10).AddHours(t - 85);
                //        }

                //    }

                //    int ta3 = time1time.CompareTo(Time1);
                //    int ta4 = Time2.CompareTo(time1time);
                //    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                //        int ta5 = strtime.AddDays(10).AddHours(t - 85).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                //        {
                //            TimeSpan tcha = Time22 - strtime;
                //            double t1 = t - 85 - tcha.TotalHours;//剩余加工的时间
                //            if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(9).AddHours(t1);
                //            }
                //            else//大于下午的时间差 && 小于第二天的上午的时间差
                //            {
                //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                //                picker2.Value = strtime1.AddDays(11).AddHours(tsheng);
                //            }
                //        }
                //        else//16.几 小时的工时
                //        {
                //            picker2.Value = strtime.AddDays(10).AddHours(t - 85);
                //        }
                //    }

                //    int ta6 = time1time.CompareTo(Time2);
                //    int ta7 = Time3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                //        int ta8 = strtime.AddDays(10).AddHours(t - 85).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                //        {

                //            double t1 = t - 85 - thourxiawu.TotalHours;
                //            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                //            {
                //                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //                picker2.Value = strtime1.AddDays(11).AddHours(t1);
                //            }
                //            //大于2天小于等于3天 最多到第三天的上午结束
                //        }
                //        else//时间小于17:30
                //        {
                //            picker2.Value = strtime.AddDays(10).AddHours(t - 85);
                //        }
                //    }

                //    int ta9 = time1time.CompareTo(Time3);
                //    int ta10 = Time4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                //        int ta11 = strtime.AddDays(10).AddHours(t - 85).ToString("HH:mm:ss").CompareTo(Time4);

                //        if (ta11 == 1 || ta11 == 0)
                //        {
                //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //            double ttzhi = t - 85 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                //            {
                //                picker2.Value = strtime1.AddDays(10).AddHours(ttzhi);
                //            }
                //            else//大于上午的时间
                //            {
                //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                //                picker2.Value = strtime2.AddDays(11).AddHours(ttzhi);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(10).AddHours(t - 85);
                //        }

                //    }

                //    int ta12 = time1time.CompareTo(Time4);

                //    if (ta12 == 1)//第二天做
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                //        int ta13 = strtime.AddDays(11).AddHours(t - 85).ToString("HH:mm:ss").CompareTo(Time2);

                //        if (ta13 == 1 || ta13 == 0)//时间大于11:20
                //        {

                //            double t1 = t - 85 - thourshangwu.TotalHours;
                //            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                //            {
                //                picker2.Value = strtimexiawu.AddDays(11).AddHours(t1);
                //            }
                //        }
                //        else//时间小于11:20
                //        {
                //            picker2.Value = strtime.AddDays(11).AddHours(t);
                //        }
                //    }
                //}

                //#endregion
                #endregion

            }
            #endregion

            #region 设备不空闲
            else//设备不空闲的时候
            {
                string sql2 = "select max(设定开始时间) from db_Paichan where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select 设定结束时间 from db_Paichan where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束时间，结束时间就是当前时间
                DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间
                if (ret3 < time1)//设定结束时间 < 现在的时间 （最大的结束时间小于现在的时间也就是没有任务了）---空闲了
                {

                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 8.5;
                    int a = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                    //总的一天的工时
                    TimeSpan thourshangwu = T2 - T1;//上午的时间差
                    TimeSpan thourxiawu = T4 - T3;//下午的时间差
                    //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
                    //gongshi = Math.Round(gongshi, 2);

                    int ta1 = Time1.CompareTo(time1time);

                    if (ta1 == 1)//当前时间小于8:00 (Time1>time1time)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        int ta2 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);//与下一天的11:20比较

                        if (ta2 == 1 || ta2 == 0)//时间大于11:20  
                        {

                            double t1 = t - 8.5 * a - thourshangwu.TotalHours;//第二天剩余加工的时间
                            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                            {
                                picker2.Value = strtimexiawu.AddDays(a).AddHours(t1);
                            }
                            //剩余加工的时间一定小于等于下午的工时（8<t<=16）
                        }
                        else//时间小于11:20
                        {
                            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                        }

                    }

                    int ta3 = time1time.CompareTo(Time1);
                    int ta4 = Time2.CompareTo(time1time);
                    if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        int ta5 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);//下一天的结束时间与11:20比较

                        if (ta5 == 1 || ta5 == 0)//时间大于11:20
                        {
                            TimeSpan tcha = Time22 - strtime;
                            double t1 = t - 8.5 * a - tcha.TotalHours;//剩余加工的时间
                            if (t1 <= thourxiawu.TotalHours)//如果下午能够加工完成
                            {
                                picker2.Value = strtimexiawu.AddDays(a).AddHours(t1);
                            }
                            else//大于下午的时间差 && 小于第二天的上午的时间差
                            {
                                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间(第三天上午加工完成)
                                picker2.Value = strtime1.AddDays(a + 1).AddHours(tsheng);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                        }
                    }

                    int ta6 = time1time.CompareTo(Time2);
                    int ta7 = Time3.CompareTo(time1time);

                    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                        int ta8 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);//相当于工时是8.几小时

                        if (ta8 == 1 || ta8 == 0)//时间大于17:30
                        {

                            double t1 = t - 8.5 * a - thourxiawu.TotalHours;//剩余的第三天上午做完（相当于第二天下午做不完）
                            if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于等于第三天上午的时间差（8<t<=16）
                            {
                                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                                picker2.Value = strtime1.AddDays(a + 1).AddHours(t1);
                            }
                        }
                        else//时间小于17:30
                        {
                            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                        }
                    }

                    int ta9 = time1time.CompareTo(Time3);
                    int ta10 = Time4.CompareTo(time1time);

                    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        picker1.Value = Convert.ToDateTime(strtime);
                        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                        string aql = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss");
                        int ta11 = aql.CompareTo(Time4);//相当于8.5小时工时

                        if (ta11 == 1 || ta11 == 0)//第二天下午做不完
                        {
                            TimeSpan tzhi = Time44 - strtime;//第二天下午工作的时间
                            double ttzhi = t - 8.5 * a - tzhi.TotalHours;//剩余加工的时间（第三天做）
                            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                            {
                                picker2.Value = strtime1.AddDays(a + 1).AddHours(ttzhi);
                            }
                            else//大于上午的时间
                            {
                                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（第三天下午做完）
                                if (tttzhi <= thourxiawu.TotalHours)//小于下午加工的时间
                                {
                                    picker2.Value = strtime2.AddDays(a + 1).AddHours(ttzhi);
                                }

                            }
                        }//第二天下午做完
                        else
                        {
                            picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                        }

                    }

                    int ta12 = time1time.CompareTo(Time4);

                    if (ta12 == 1)//第二天开始做、需要到第三天才完成(设置工序的时间大于17:50 -----> 即工艺员加班)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime).AddDays(1);//第二天8:00开始做
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        int ta13 = strtime.AddDays(a + 1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

                        if (ta13 == 1 || ta13 == 0)//时间大于11:20 //第三天下午做完
                        {

                            double t1 = t - 8.5 * a - thourshangwu.TotalHours;
                            if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于等于下午的时间差
                            {
                                picker2.Value = strtimexiawu.AddDays(a + 1).AddHours(t1);
                            }
                        }
                        else//时间小于11:20 //第三天上午做完
                        {
                            picker2.Value = strtime.AddDays(a + 1).AddHours(t - 8.5 * a);
                        }
                    }

                    #region 死方法
                    //#region 工时小于等于一天的工时 <=8.5小时

                    //if (flag <= 1.0)//总工时小于一天的工时(一天之内可以完成的)
                    //    {
                    //        //    A.CompareTo(B)
                    //        //    A<B -----返回  -1
                    //        //    A=B -----返回   0
                    //        //    A>B -----返回   1
                    //        int ta1 = Time1.CompareTo(time1time);

                    //        if (ta1 == 1 )//当前时间小于8:00 (Time1>time1time)
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            int ta2 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                    //            if (ta2 == 1)//时间大于11:20  
                    //            {

                    //                double t1 = t - thourshangwu.TotalHours;//t1是剩余加工时间
                    //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                    //                {
                    //                    picker2.Value = strtimexiawu.AddHours(t1);
                    //                }
                    //                //不可能大于下午的时间差（从8点开始到5:30正好8个工时）
                    //            }
                    //            else//时间小于11:20
                    //            {
                    //                picker2.Value = strtime.AddHours(t);
                    //            }

                    //        }

                    //        int ta3 = time1time.CompareTo(Time1);
                    //        int ta4 = Time2.CompareTo(time1time);
                    //        if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                    //        {

                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                    //            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                    //            TimeSpan a = strtime2 - strtime;
                    //            if (strtime.AddHours(t) > strtime2)//大于17:30
                    //            {
                    //                taa5 = strtime.AddDays(1).AddHours(t - a.TotalHours).ToString("HH:mm:ss").CompareTo(Time2);
                    //            }
                    //            else
                    //            {
                    //                taa5 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);
                    //            }


                    //            if (taa5 == 1 || taa5 == 0)//时间大于11:20
                    //            {
                    //                TimeSpan tcha = Time22 - strtime;
                    //                double t1 = t - tcha.TotalHours;//剩余加工的时间
                    //                if (t1 <= thourxiawu.TotalHours)
                    //                {
                    //                    picker2.Value = strtimexiawu.AddHours(t1);
                    //                }
                    //                else//大于下午的时间差 && 小于第二天的上午的时间差
                    //                {
                    //                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                    //                    picker2.Value = strtime1.AddDays(1).AddHours(tsheng);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                picker2.Value = strtime.AddHours(t);
                    //            }
                    //        }

                    //        int ta6 = time1time.CompareTo(Time2);
                    //        int ta7 = Time3.CompareTo(time1time);

                    //        if (ta6 == 1  && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                    //            //int ta8 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);
                    //            double t1 = t - thourxiawu.TotalHours;
                    //            if (t1 > 0)//时间大于17:30
                    //            {

                    //                if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第二天上午的时间差
                    //                {
                    //                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //                    picker2.Value = strtime1.AddDays(1).AddHours(t1);
                    //                }
                    //            }
                    //            else//时间小于17:30
                    //            {
                    //                picker2.Value = strtime.AddHours(t);
                    //            }
                    //        }

                    //        int ta9 = time1time.CompareTo(Time3);
                    //        int ta10 = Time4.CompareTo(time1time);

                    //        if (ta9 == 1  && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                    //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                    //            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:50

                    //            //int ta11 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);
                    //            TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                    //            if (t > tzhi.TotalHours)//加工时间大于下午时间差
                    //            {

                    //                double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                    //                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                    //                {
                    //                    picker2.Value = strtime1.AddDays(1).AddHours(ttzhi);
                    //                }
                    //                else//大于上午的时间
                    //                {
                    //                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                    //                    picker2.Value = strtime2.AddDays(1).AddHours(ttzhi);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                picker2.Value = strtime.AddHours(t);
                    //            }

                    //        }

                    //        int ta12 = time1time.CompareTo(Time4);

                    //        if (ta12 == 1 )//第二天做(设置工序的时间大于17:50 -----> 即工艺员加班)
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            //int ta13 = strtime.AddDays(1).AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                    //            double t1 = t - thourshangwu.TotalHours;
                    //            if (t1 > 0)//时间大于11:20
                    //            {

                    //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);
                    //                }
                    //                //工时最多8个小时（第二天的8点做到17:50）

                    //            }
                    //            else//时间小于11:20
                    //            {
                    //                picker2.Value = strtime.AddDays(1).AddHours(t);
                    //            }
                    //        }

                    //    }

                    //    #endregion

                    //    #region 工时大于一天的工时 && 小于两天的工时

                    //    if (1.0 < flag && flag <= 2.0)
                    //    {

                    //        int ta1 = Time1.CompareTo(time1time);

                    //        if (ta1 == 1 )//当前时间小于8:00 (Time1>time1time)
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            int ta2 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);//与下一天的11:20比较

                    //            if (ta2 == 1 || ta2 ==0)//时间大于11:20  
                    //            {

                    //                double t1 = t - 8.5 * a - thourshangwu.TotalHours;//第二天剩余加工的时间
                    //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(a).AddHours(t1);
                    //                }
                    //                //剩余加工的时间一定小于等于下午的工时（8<t<=16）
                    //            }
                    //            else//时间小于11:20
                    //            {
                    //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    //            }

                    //        }

                    //        int ta3 = time1time.CompareTo(Time1);
                    //        int ta4 = Time2.CompareTo(time1time);
                    //        if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                    //            int ta5 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);//下一天的结束时间与11:20比较

                    //            if (ta5 == 1 || ta5 == 0)//时间大于11:20
                    //            {
                    //                TimeSpan tcha = Time22 - strtime;
                    //                double t1 = t - 8.5 * a - tcha.TotalHours;//剩余加工的时间
                    //                if (t1 <= thourxiawu.TotalHours)//如果下午能够加工完成
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(a).AddHours(t1);
                    //                }
                    //                else//大于下午的时间差 && 小于第二天的上午的时间差
                    //                {
                    //                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间(第三天上午加工完成)
                    //                    picker2.Value = strtime1.AddDays(a+1).AddHours(tsheng);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    //            }
                    //        }

                    //        int ta6 = time1time.CompareTo(Time2);
                    //        int ta7 = Time3.CompareTo(time1time);

                    //        if (ta6 == 1  && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                    //            int ta8 = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time4);//相当于工时是8.几小时

                    //            if (ta8 == 1 || ta8 == 0)//时间大于17:30
                    //            {

                    //                double t1 = t - 8.5 * a - thourxiawu.TotalHours;//剩余的第三天上午做完（相当于第二天下午做不完）
                    //                if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于等于第三天上午的时间差（8<t<=16）
                    //                {
                    //                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //                    picker2.Value = strtime1.AddDays(a+1).AddHours(t1);
                    //                }
                    //            }
                    //            else//时间小于17:30
                    //            {
                    //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    //            }
                    //        }

                    //        int ta9 = time1time.CompareTo(Time3);
                    //        int ta10 = Time4.CompareTo(time1time);

                    //        if (ta9 == 1  && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1+ " " + Time3);//日期+12:50
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                    //            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                    //            string aql = strtime.AddDays(a).AddHours(t - 8.5 * a).ToString("HH:mm:ss");
                    //            int ta11 = aql.CompareTo(Time4);//相当于8.5小时工时

                    //            if (ta11 == 1 || ta11 == 0)//第二天下午做不完
                    //            {
                    //                TimeSpan tzhi = Time44 - strtime;//第二天下午工作的时间
                    //                double ttzhi = t - 8.5 * a - tzhi.TotalHours;//剩余加工的时间（第三天做）
                    //                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                    //                {
                    //                    picker2.Value = strtime1.AddDays(a+1).AddHours(ttzhi);
                    //                }
                    //                else//大于上午的时间
                    //                {
                    //                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（第三天下午做完）
                    //                    if (tttzhi <= thourxiawu.TotalHours)//小于下午加工的时间
                    //                    {
                    //                        picker2.Value = strtime2.AddDays(a+1).AddHours(ttzhi);
                    //                    }

                    //                }
                    //            }//第二天下午做完
                    //            else
                    //            {
                    //                picker2.Value = strtime.AddDays(a).AddHours(t - 8.5 * a);
                    //            }

                    //        }

                    //        int ta12 = time1time.CompareTo(Time4);

                    //        if (ta12 == 1 )//第二天开始做、需要到第三天才完成(设置工序的时间大于17:50 -----> 即工艺员加班)
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            picker1.Value = Convert.ToDateTime(strtime).AddDays(1);//第二天8:00开始做
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            int ta13 = strtime.AddDays(a+1).AddHours(t - 8.5 * a).ToString("HH:mm:ss").CompareTo(Time2);

                    //            if (ta13 == 1 || ta13 == 0)//时间大于11:20 //第三天下午做完
                    //            {

                    //                double t1 = t - 8.5 * a - thourshangwu.TotalHours;
                    //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于等于下午的时间差
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(a+1).AddHours(t1);
                    //                }
                    //            }
                    //            else//时间小于11:20 //第三天上午做完
                    //            {
                    //                picker2.Value = strtime.AddDays(a+1).AddHours(t - 8.5 * a);
                    //            }
                    //        }

                    //    }

                    //    #endregion

                    //    #region 工时大于两天 小于等于三天

                    //    if (2.0 < flag && flag <= 3.0)
                    //    {
                    //        int ta1 = Time1.CompareTo(time1time);

                    //        if (ta1 == 1 )//当前时间小于8:00 (Time1>time1time)
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            int ta2 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                    //            if (ta2 == 1 || ta2 == 0)//时间大于11:20 （第三天下午完成）
                    //            {

                    //                double t1 = t - 17 - thourshangwu.TotalHours;//剩余加工时间下午完成
                    //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);
                    //                }
                    //            }
                    //            else//时间小于11:20（第三天早上完成）
                    //            {
                    //                picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                    //            }

                    //        }

                    //        int ta3 = time1time.CompareTo(Time1);
                    //        int ta4 = Time2.CompareTo(time1time);
                    //        if ((ta3 == 1 || ta3 == 0) && (ta4 == 1 || ta4 == 0))//当前时间大于8:00 小于11:20
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期+8:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                    //            int ta5 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                    //            if (ta5 == 1 || ta5 == 0)//时间大于11:20
                    //            {
                    //                TimeSpan tcha = Time22 - strtime;
                    //                double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                    //                if (t1 <= thourxiawu.TotalHours)//第三天下午可以加工完
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);
                    //                }
                    //                else//大于下午的时间差 && 小于第二天的上午的时间差
                    //                {
                    //                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                    //                    picker2.Value = strtime1.AddDays(3).AddHours(tsheng);
                    //                }
                    //            }
                    //            else//16.几 小时的工时
                    //            {
                    //                picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                    //            }
                    //        }

                    //        int ta6 = time1time.CompareTo(Time2);
                    //        int ta7 = Time3.CompareTo(time1time);

                    //        if (ta6 == 1  && (ta7 == 1 || ta7 == 0))//当前时间大于11:20 小于12:50
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time3);//当前日期+12:50:00
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time4);//日期+17:30:00

                    //            int ta8 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time4);

                    //            if (ta8 == 1 || ta8 == 0)//时间大于17:30
                    //            {

                    //                double t1 = t - 17 - thourxiawu.TotalHours;
                    //                if (t1 <= thourshangwu.TotalHours)//剩余加工时间小于第三天上午的时间差
                    //                {
                    //                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //                    picker2.Value = strtime1.AddDays(3).AddHours(t1);
                    //                }
                    //                //大于2天小于等于3天 最多到第三天的上午结束
                    //            }
                    //            else//时间小于17:30
                    //            {
                    //                picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                    //            }
                    //        }

                    //        int ta9 = time1time.CompareTo(Time3);
                    //        int ta10 = Time4.CompareTo(time1time);

                    //        if (ta9 == 1 && (ta10 == 1 || ta10 == 0))//当前时间大于12:50 小于17:30
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //            picker1.Value = Convert.ToDateTime(strtime);
                    //            //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                    //            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                    //            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                    //            int ta11 = strtime.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time4);

                    //            if (ta11 == 1 || ta11 == 0)
                    //            {
                    //                TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                    //                double ttzhi = t - 17 - tzhi.TotalHours;//剩余加工的时间
                    //                if (ttzhi <= thourshangwu.TotalHours)//如果小于第三天上午的工时
                    //                {
                    //                    picker2.Value = strtime1.AddDays(3).AddHours(ttzhi);
                    //                }
                    //                else//大于上午的时间
                    //                {
                    //                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间（下午完成）
                    //                    picker2.Value = strtime2.AddDays(3).AddHours(ttzhi);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                picker2.Value = strtime.AddDays(2).AddHours(t - 17);
                    //            }

                    //        }

                    //        int ta12 = time1time.CompareTo(Time4);

                    //        if (ta12 == 1)//第二天做
                    //        {
                    //            DateTime strtime = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                    //            picker1.Value = Convert.ToDateTime(strtime).AddDays(1);
                    //            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                    //            int ta13 = strtime.AddDays(3).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                    //            if (ta13 == 1 || ta13 == 0)//时间大于11:20
                    //            {

                    //                double t1 = t - 16 - thourshangwu.TotalHours;
                    //                if (t1 <= thourxiawu.TotalHours)//剩余加工时间小于下午的时间差
                    //                {
                    //                    picker2.Value = strtimexiawu.AddDays(3).AddHours(t1);
                    //                }
                    //            }
                    //            else//时间小于11:20
                    //            {
                    //                picker2.Value = strtime.AddDays(3).AddHours(t);
                    //            }
                    //        }
                    //    }
                    //#endregion
                    #endregion

                }
                else//(设定结束时间 > 现在的时间（用设定结束时间算）)----将设定结束时间当做现在时间算  ret3---结束时间
                {
                    //DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
                    {

                        string ret3date = ret3.ToString("yyyy/MM/dd");
                        string ret3time = ret3.ToString("HH:mm:dd");
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 8.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        //总的一天的工时
                        TimeSpan thourshangwu = T2 - T1;//上午的时间差
                        TimeSpan thourxiawu = T4 - T3;//下午的时间差
                                                      //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
                                                      //gongshi = Math.Round(gongshi, 2);

                        //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //8:00 <= ret3 <= 11:20
                        int ta1 = ret3time.CompareTo(Time1);
                        int ta11 = Time2.CompareTo(ret3time);

                        //12:50 <= ret3 <= 17:30
                        int ta111 = ret3time.CompareTo(Time3);
                        int ta1111 = Time4.CompareTo(ret3time);

                        int tb1 = Time2.CompareTo(ret3time);
                        int tb11 = ret3time.CompareTo("12:00:00");

                        if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                            DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:30:00                                
                            DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:30

                            picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                            int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                            if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                            {
                                TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                                double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                                else//大于上午的时间
                                {
                                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                                    picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime2.AddDays(at).AddHours(t);// + 0.2);
                            }
                        }

                        if (ta1 == -1)//ret3 <= 8:00----上午工作
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                                                                                           //DateTime strtime2 =     Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                            picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                            DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                            int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                            if (b1 == 1 || b1 == 0)//时间大于11:20
                            {
                                TimeSpan tcha = Time22 - strtime1;
                                double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
                                if (t1 <= thourxiawu.TotalHours)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
                                }
                                else//大于下午的时间差 && 小于第二天的上午的时间差
                                {
                                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime1.AddDays(at).AddHours(t);// + 0.2);
                            }
                        }

                        if ((ta1 == 1 || ta1 == 0) && (ta11 == 1 || ta11 == 0))//上午工作
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                                                                                           //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                            picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                            DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                            int b1 = ret3.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time2);

                            if (b1 == 1 || b1 == 0)//时间大于11:20
                            {
                                TimeSpan tcha = Time22 - ret3;
                                double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
                                if (t1 <= thourxiawu.TotalHours)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
                                }
                                else//大于下午的时间差 && 小于第二天的上午的时间差
                                {
                                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 8.5 * at);// + 0.2);
                            }
                        }

                        if ((ta111 == 1 || ta111 == 0) && (ta1111 == 1 || ta1111 == 0))//下午工作
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                                                                     //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                            DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50:00                                
                            DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:50

                            int b2 = ret3.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time4);

                            if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                            {
                                TimeSpan tzhi = Time44 - ret3;//下午工作的时间
                                double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                                else//大于上午的时间
                                {
                                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                                    picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 8.5 * at);
                            }
                        }

                        #region 死方法

                        //#region 工时小于等于一天的工时 <=8小时

                        //if (t <= gongshi)//总工时小于一天的工时(一天之内可以完成的)
                        //{
                        //    //    A.CompareTo(B)
                        //    //    A<B -----返回  -1
                        //    //    A=B -----返回   0
                        //    //    A>B -----返回   1

                        //    //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //    //8:00 <= ret3 <= 11:30
                        //    int ta1 = ret3time.CompareTo(Time1);
                        //    int ta11 = Time2.CompareTo(ret3time);

                        //    //12:50 <= ret3 <= 17:30
                        //    int ta111 = ret3time.CompareTo(Time3);
                        //    int ta1111 = Time4.CompareTo(ret3time);

                        //    int tb1 = Time2.CompareTo(ret3time);
                        //    int tb11 = ret3time.CompareTo("12:00:00");

                        //    if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " "+ Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:30:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                        //        int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                        //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime2.AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if (ta1 == -1)//ret3 <= 8:00----上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                        //        int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - strtime1;
                        //            double t1 = t - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(1).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime1.AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta1 == 1 || ta1 == 0) && (ta11 == 1 || ta11 == 0))//上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                        //                                                                       //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                        //        int b1 = ret3.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1 || b1 == 0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - ret3;
                        //            double t1 = t - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(1).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta111 == 1 || ta111 == 0) && (ta1111 == 1 || ta1111 == 0))//下午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:50

                        //        int b2 = ret3.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - ret3;//下午工作的时间
                        //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);// + 0.2);
                        //        }
                        //    }


                        //}

                        //#endregion

                        //#region 工时大于一天的工时 && 小于两天的工时

                        //if (1.0 < flag && flag <= 2.0)
                        //{

                        //    //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //    //8:00 <= ret3 <= 11:20
                        //    int ta1 = ret3time.CompareTo(Time1);
                        //    int ta11 = Time2.CompareTo(ret3time);

                        //    //12:50 <= ret3 <= 17:30
                        //    int ta111 = ret3time.CompareTo(Time3);
                        //    int ta1111 = Time4.CompareTo(ret3time);

                        //    int tb1 = Time2.CompareTo(ret3time);
                        //    int tb11 = ret3time.CompareTo("12:00:00");

                        //    if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:30:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                        //        int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                        //            double ttzhi = t - 8.5 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime2.AddDays(1).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if (ta1 == -1)//ret3 <= 8:00----上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                        //                                                                       //DateTime strtime2 =     Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                        //        int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1 || b1 == 0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - strtime1;
                        //            double t1 = t - 8.5 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta1 == 1 || ta1 == 0) && (ta11 == 1 || ta11 == 0))//上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                        //                                                                       //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                        //        int b1 = ret3.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1 || b1==0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - ret3;
                        //            double t1 = t - 8.5 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 8.5);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta111 == 1 || ta111 == 0)&& (ta1111 == 1 || ta1111 == 0))//下午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:50

                        //        int b2 = ret3.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1||b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - ret3;//下午工作的时间
                        //            double ttzhi = t - 8.5 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 8.5);
                        //        }
                        //    }

                        //}

                        //#endregion

                        //#region 工时大于两天 小于等于三天

                        //if (2.0 < flag && flag <= 3.0)
                        //{
                        //    //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //    //8:00 <= ret3 <= 11:20
                        //    int ta1 = ret3time.CompareTo(Time1);
                        //    int ta11 = Time2.CompareTo(ret3time);

                        //    //12:50 <= ret3 <= 17:30
                        //    int ta111 = ret3time.CompareTo(Time3);
                        //    int ta1111 = Time4.CompareTo(ret3time);

                        //    int tb1 = Time2.CompareTo(ret3time);//datetimepicker的时间小于11:30
                        //    int tb11 = ret3time.CompareTo("12:00:00");

                        //    if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:30:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                        //        int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                        //            double ttzhi = t - 17 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime2.AddDays(1).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if (ta1 == -1)//ret3 <= 8:00----上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                        //                                                                       //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:30

                        //        int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1)//时间大于11:30
                        //        {
                        //            TimeSpan tcha = Time22 - strtime1;
                        //            double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta1 == 1 || ta1 == 0) && (ta11 == 0 || ta11 == 1))//上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//当前日期 + 8:00:00
                        //                                                                       //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + Time2);//日期+11:20

                        //        int b1 = ret3.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);

                        //        //TimeSpan a = strtime2 - strtime;
                        //        //if (strtime.AddHours(t) > strtime2)//大于17:30
                        //        //{
                        //        //    taa5 = strtime.AddDays(1).AddHours(t - a.TotalHours).ToString("HH:mm:ss").CompareTo(Time2);
                        //        //}
                        //        //else
                        //        //{
                        //        //    taa5 = strtime.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);
                        //        //}


                        //        if (b1 == 1 || b1 == 0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - ret3;
                        //            double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(3).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(2).AddHours(t - 17);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta111 ==0 || ta111 == 1) &&(ta1111 == 0 || ta1111 == 1))//下午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(ret3);//.AddHours(0.2);
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(ret3date + " " + Time3);//日期+12:50:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + Time4);//日期 + 17:50

                        //        int b2 = ret3.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1|| b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - ret3;//下午工作的时间
                        //            double ttzhi = t - 17 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(3).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(2).AddHours(t - 17);
                        //        }
                        //    }
                        //}

                        //#endregion
                        #endregion
                    }

                    if (ret3 < time)//-----------------ret3 < datetimepicker(用time1date和time1time)----time
                    {
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 8.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        //总的一天的工时
                        TimeSpan thourshangwu = T2 - T1;//上午的时间差
                        TimeSpan thourxiawu = T4 - T3;//下午的时间差
                                                      //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
                                                      //gongshi = Math.Round(gongshi, 2);

                        //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //8:00 <= ret3 <= 11:20
                        int ta1 = time1time.CompareTo(Time1);
                        int ta11 = Time2.CompareTo(time1time);

                        //12:50 <= ret3 <= 17:30
                        int ta111 = time1time.CompareTo(Time3);
                        int ta1111 = Time4.CompareTo(time1time);


                        int tb1 = Time2.CompareTo(time1time);
                        int tb11 = time1time.CompareTo("12:00:00");

                        //int tb2 = Time3.CompareTo(time1time);
                        //int tb22 = ("13:00:00").CompareTo(time1time);


                        if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30:00                                
                            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                            picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                            int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                            if (b2 == 1)//加工时间大于下午时间差
                            {
                                TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                                double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                                else//大于上午的时间
                                {
                                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                                    picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime2.AddDays(at).AddHours(t);// + 0.2);
                            }
                        }

                        if (ta1 == -1)//ret3 <= 8:00----上午工作
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                                                                                             //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                            picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                            int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                            if (b1 == 1)//时间大于11:20
                            {
                                TimeSpan tcha = Time22 - strtime1;
                                double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
                                if (t1 <= thourxiawu.TotalHours)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
                                }
                                else//大于下午的时间差 && 小于第二天的上午的时间差
                                {
                                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime1.AddDays(at).AddHours(t);// + 0.2);
                            }
                        }


                        if ((ta1 == 0 || ta1 == 1) && (ta11 == 0 || ta11 == 1))//上午工作
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                                                                                             //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                            picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                            int b1 = time.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time2);


                            if (b1 == 1 || b1 == 0)//时间大于11:20
                            {
                                TimeSpan tcha = Time22 - time;
                                double t1 = t - 8.5 * at - tcha.TotalHours;//剩余加工的时间
                                if (t1 <= thourxiawu.TotalHours)
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(t1);// + 0.2);
                                }
                                else//大于下午的时间差 && 小于第二天的上午的时间差
                                {
                                    double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tsheng);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = time.AddDays(at).AddHours(t - 8.5 * at);// + 0.2);
                            }
                        }

                        if ((ta111 == 0 || ta111 == 1) && (ta1111 == 0 || ta1111 == 1))//下午工作
                        {
                            //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                                                                     //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                            DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:50

                            int b2 = time.AddDays(at).AddHours(t - 8.5 * at).ToString("HH:mm:ss").CompareTo(Time4);

                            if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                            {
                                TimeSpan tzhi = Time44 - time;//下午工作的时间
                                double ttzhi = t - 8.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                                else//大于上午的时间
                                {
                                    double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                                    picker2.Value = strtime2.AddDays(at + 1).AddHours(ttzhi);// + 0.2);
                                }
                            }
                            else
                            {
                                picker2.Value = time.AddDays(at).AddHours(t - 8.5 * at);
                            }
                        }

                        #region 死方法
                        //#region 工时小于等于一天的工时 <=8小时

                        //if (t <= gongshi)//总工时小于一天的工时(一天之内可以完成的)
                        //{
                        //    //    A.CompareTo(B)
                        //    //    A<B -----返回  -1
                        //    //    A=B -----返回   0
                        //    //    A>B -----返回   1

                        //    //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //    //8:00 <= ret3 <= 11:30
                        //    int ta1 = time1time.CompareTo(Time1);
                        //    int ta11 = Time2.CompareTo(time1time);

                        //    //12:30 <= ret3 <= 17:30
                        //    int ta111 = time1time.CompareTo(Time3);
                        //    int ta1111 = Time4.CompareTo(time1time);

                        //    int tb1 = Time2.CompareTo(time1time);
                        //    int tb11 = time1time.CompareTo("12:00:00");

                        //    //int tb2 = Time3.CompareTo(time1time);
                        //    //int tb22 = ("13:00:00").CompareTo(time1time);


                        //    if(tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                        //        int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                        //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime2.AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if(ta1 == -1)//ret3 <= 8:00----上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        //        int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - strtime1;
                        //            double t1 = t - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(1).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime1.AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta1 == 1 || ta1 == 0) && (ta11 == 1 || ta11 == 0))//上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        //        int b1 = time.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1 || b1 == 0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - time;
                        //            double t1 = t - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(1).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta111 == 1 || ta111 == 0) && (ta1111 == 1 || ta11 == 0))//下午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:50

                        //        int b2 = time.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - time;//下午工作的时间
                        //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(1).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddHours(t);// + 0.2);
                        //        }
                        //    }


                        //}

                        //#endregion

                        //#region 工时大于一天的工时 && 小于两天的工时

                        //if (1.0 < flag && flag <= 2.0)
                        //{

                        //    //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //    //8:00 <= ret3 <= 11:20
                        //    int ta1 = time1time.CompareTo(Time1);
                        //    int ta11 = Time2.CompareTo(time1time);

                        //    //12:50 <= ret3 <= 17:30
                        //    int ta111 = time1time.CompareTo(Time3);
                        //    int ta1111 = Time4.CompareTo(time1time);


                        //    int tb1 = Time2.CompareTo(time1time);
                        //    int tb11 = time1time.CompareTo("12:00:00");

                        //    //int tb2 = Time3.CompareTo(time1time);
                        //    //int tb22 = ("13:00:00").CompareTo(time1time);


                        //    if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                        //        int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                        //            double ttzhi = t - 8.5 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime2.AddDays(1).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if (ta1 == -1)//ret3 <= 8:00----上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        //        int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - strtime1;
                        //            double t1 = t - 8.5 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t);// + 0.2);
                        //        }
                        //    }


                        //    if ((ta1 == 0 || ta1 == 1) && (ta11 == 0 || ta11 == 1))//上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        //        int b1 = time.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time2);


                        //        if (b1 == 1 || b1 == 0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - time;
                        //            double t1 = t - 8.5 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddDays(1).AddHours(t - 8.5);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta111 == 0 || ta111 == 1) && (ta1111 == 0 || ta1111 == 1))//下午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:50

                        //        int b2 = time.AddDays(1).AddHours(t - 8.5).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - time;//下午工作的时间
                        //            double ttzhi = t - 8.5 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddDays(1).AddHours(t - 8.5);
                        //        }
                        //    }

                        //}

                        //#endregion

                        //#region 工时大于两天 小于等于三天

                        //if (2.0 < flag && flag <= 3.0)
                        //{
                        //    //结束时间---ret3范围[8:00 <= ret3 <= 11:20 && 12:50 <= ret3 <= 17:30]

                        //    //8:00 <= ret3 <= 11:20
                        //    int ta1 = time1time.CompareTo(Time1);
                        //    int ta11 = Time2.CompareTo(time1time);

                        //    //12:50 <= ret3 <= 17:30
                        //    int ta111 = time1time.CompareTo(Time3);
                        //    int ta1111 = Time4.CompareTo(time1time);

                        //    int tb1 = Time2.CompareTo(time1time);
                        //    int tb11 = time1time.CompareTo("12:00:00");

                        //    //int tb2 = Time3.CompareTo(time1time);
                        //    //int tb22 = ("13:00:00").CompareTo(time1time);


                        //    if (tb1 == -1 && tb11 == -1)//---ret3在11:30和12：00之间
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:30:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime2);//.AddHours(0.2);
                        //        int b2 = strtime2.AddHours(t).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - strtime2;//下午工作的时间
                        //            double ttzhi = t - 17 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(3).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime2.AddDays(2).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if (ta1 == -1)//ret3 <= 8:00----上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 =   Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(strtime1);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        //        int b1 = strtime1.AddHours(t).ToString("HH:mm:ss").CompareTo(Time2);

                        //        if (b1 == 1)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - strtime1;
                        //            double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(3).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta1 == 0 || ta1 == 1) && (ta11 == 0 || ta11 == 1))//上午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//当前日期 + 8:00:00
                        //                                                                         //DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time4);//当前日期 + 17:30:00
                        //        picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + Time2);//日期+11:20

                        //        int b1 = time.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time2);


                        //        if (b1 == 1 || b1 == 0)//时间大于11:20
                        //        {
                        //            TimeSpan tcha = Time22 - time;
                        //            double t1 = t - 17 - tcha.TotalHours;//剩余加工的时间
                        //            if (t1 <= thourxiawu.TotalHours)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t1);// + 0.2);
                        //            }
                        //            else//大于下午的时间差 && 小于第二天的上午的时间差
                        //            {
                        //                double tsheng = t1 - thourxiawu.TotalHours;//剩余的时间
                        //                picker2.Value = strtime1.AddDays(3).AddHours(tsheng);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddDays(2).AddHours(t - 17);// + 0.2);
                        //        }
                        //    }

                        //    if ((ta111 == 0 || ta111 == 1) && (ta1111 == 0 || ta1111 == 1))//下午工作
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(time);//.AddHours(0.2);
                        //        //DateTime strtimexiawu = Convert.ToDateTime(time1date1 + Time3);//日期+12:50
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + Time1);//日期+8:00:00
                        //        DateTime strtime2 = Convert.ToDateTime(time1date1 + " " + Time3);//日期+12:50:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + Time4);//日期 + 17:50

                        //        int b2 = time.AddDays(2).AddHours(t - 17).ToString("HH:mm:ss").CompareTo(Time4);

                        //        if (b2 == 1 || b2 == 0)//加工时间大于下午时间差
                        //        {
                        //            TimeSpan tzhi = Time44 - time;//下午工作的时间
                        //            double ttzhi = t - 16 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= thourshangwu.TotalHours)//如果小于上午的工时
                        //            {
                        //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi);// + 0.2);
                        //            }
                        //            else//大于上午的时间
                        //            {
                        //                double tttzhi = ttzhi - thourshangwu.TotalHours;//剩余加工时间
                        //                picker2.Value = strtime2.AddDays(3).AddHours(ttzhi);// + 0.2);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = time.AddDays(2).AddHours(t - 17);
                        //        }
                        //    }
                        //}

                        //#endregion
                        #endregion
                    }


                }

            }
            #endregion
        }

        /// <summary>
        /// 数控设备排产-----12小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan2(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {
            DateTime time1 = DateTime.Now;//日期+时分秒（当前）

            string sql1 = "select 设定开始时间 from db_Paichan where 工序设备='" + shebei + "'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            #region 设备空闲中
            if (ret1 == "")//设备空闲中
            {
                //算总的工时
                double price = Convert.ToDouble(jiage);
                price = price * (Convert.ToInt32(shuliang));
                double t = (double)price / 27;
                double flag = t / 10.5;
                int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                //上午4小时、下午4.5小时、晚上2小时
                //总的一天的工时
                //TimeSpan thourshangwu = T2 - T1;//上午的时间差
                //TimeSpan thourxiawu = T4 - T3;//下午的时间差
                //double gongshi = thourshangwu.TotalHours + thourxiawu.TotalHours;
                //gongshi = Math.Round(gongshi, 2);
                //double gongshi = 10.5;

                //string shijian1 = "08:00:00";//上班
                //string shijian2 = "12:00:00";//开始休息----4小时

                //string shijian3 = "13:00:00";//结束休息
                //string shijian4 = "17:30:00";//开始休息----4.5小时

                //string shijian5 = "18:00:00";//结束休息
                //string shijian6 = "20:00:00";//下班---------2小时------>一共10.5小时

                int ta1 = shijian1.CompareTo(time1time);

                if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                    {
                        picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                    }

                }

                //当前时间大于8:00 小于12:00
                int ta3 = time1time.CompareTo(shijian1);
                int ta4 = shijian2.CompareTo(time1time);
                if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                {

                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    TimeSpan a = Time22 - strtime;//上午加工的时间
                    if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    {

                        double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                        if (tt <= 4)//下午做完
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                        }
                        if (4 < tt && tt <= 6.5)//晚上做完
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                        }
                        if (tt >= 6.5)//第二天上午做完
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                int ta6 = time1time.CompareTo(shijian2);
                int ta7 = shijian3.CompareTo(time1time);

                if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)//下午完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (10.5 * at + 4 < t && t <= 10.5 * at + 6.5)//晚上完成
                    {
                        picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (10.5 * at + 6.5 < t && t <= 10.5 * at + 10.5)//第二天上午完成
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                    }

                }

                //当前时间大于13:00 小于17:30
                int ta9 = time1time.CompareTo(shijian3);
                int ta10 = shijian4.CompareTo(time1time);

                if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                    DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                    TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                    if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                    {

                        double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                        if (ttzhi <= 2)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                        }
                        if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                        }
                        if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                        }

                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }

                }

                //当前时间大于17:30 小于18:00
                int ta12 = time1time.CompareTo(shijian4);
                int ta13 = shijian5.CompareTo(time1time);

                if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                    }
                    if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                    }

                }

                //当前时间大于18:00 小于20:00
                int ta14 = time1time.CompareTo(shijian5);
                int ta15 = shijian6.CompareTo(time1time);

                if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                    if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                    {
                        double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                        if (t2 <= 4)//第二天上午可以完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                        }
                        if (4 < t && t <= 8.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                        }
                        if (8.5 < t && t <= 10.5)//第二天晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于20:00
                //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                int ta16 = time1time.CompareTo(shijian6);

                if (ta16 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1.Value = strtime1.AddDays(1);

                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                    {
                        picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                    }
                }

                #region 死方法
                //#region 工时小于等于一天的工时

                //if (flag <= 1.0)//一天之内可以完成
                //{
                //    int ta1 = shijian1.CompareTo(time1time);

                //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                //        if (0 < t && t <= 4)//上午完成
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //        if (4 < t && t <= 8.5)//下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddHours(t - 4);
                //        }
                //        if (8.5 < t && t <= 10.5)//晚上完成
                //        {
                //            picker2.Value = strtimewanshang.AddHours(t - 8.5);
                //        }

                //    }

                //    //当前时间大于8:00 小于12:00
                //    int ta3 = time1time.CompareTo(shijian1);
                //    int ta4 = shijian2.CompareTo(time1time);
                //    if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                //    {

                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                //        TimeSpan a = Time22 - strtime;//上午加工的时间
                //        if (t >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                //        {

                //            double tt = t - a.TotalHours;//剩余加工的时间
                //            if (tt <= 4)//下午做完
                //            {
                //                picker2.Value = strtimexiawu.AddHours(tt);
                //            }
                //            if (4 < tt && tt <= 6.5)//晚上做完
                //            {
                //                picker2.Value = strtimewanshang.AddHours(tt - 4);
                //            }
                //            if (tt >= 6.5)//第二天上午做完
                //            {
                //                picker2.Value = strtime1.AddDays(1).AddHours(tt - 6.5);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //    }

                //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                //    int ta6 = time1time.CompareTo(shijian2);
                //    int ta7 = shijian3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                //        if (0 < t && t <= 4)//下午完成
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //        if (4 < t && t <= 6.5)//晚上完成
                //        {
                //            picker2.Value = strtimewanshang.AddHours(t - 4);
                //        }
                //        if (6.5 < t && t <= 10.5)//第二天上午完成
                //        {
                //            picker2.Value = strtime1.AddDays(1).AddHours(t - 6.5);
                //        }

                //    }

                //    //当前时间大于13:00 小于17:30
                //    int ta9 = time1time.CompareTo(shijian3);
                //    int ta10 = shijian4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                //        TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                //        if (t > tzhi.TotalHours)
                //        {

                //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= 2)//晚上完成
                //            {
                //                picker2.Value = strtimewanshang.AddHours(ttzhi);
                //            }
                //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                //            {
                //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi - 2);
                //            }
                //            if (6 < ttzhi && ttzhi <= 10.5)
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(ttzhi - 6);
                //            }

                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }

                //    }

                //    //当前时间大于17:30 小于18:00
                //    int ta12 = time1time.CompareTo(shijian4);
                //    int ta13 = shijian5.CompareTo(time1time);

                //    if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                //        if (0 < t && t <= 2)//晚上完成
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //        if (2 < t && t <= 6)//第二天上午完成
                //        {
                //            picker2.Value = strtime1.AddDays(1).AddHours(t - 2);
                //        }
                //        if (6 < t && t < 10.5)//第二天下午做完
                //        {
                //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 6);
                //        }

                //    }

                //    //当前时间大于18:00 小于20:00
                //    int ta14 = time1time.CompareTo(shijian5);
                //    int ta15 = shijian6.CompareTo(time1time);

                //    if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                //        TimeSpan t1 = strtimewuye - strtime;//晚上加工的时间
                //        if (t >= t1.TotalHours)//晚上不能加工完成
                //        {
                //            double t2 = t - t1.TotalHours;//剩余加工的时间
                //            if (t2 <= 4)//第二天上午可以完成
                //            {
                //                picker2.Value = strtime1.AddDays(1).AddHours(t2);
                //            }
                //            if (4 < t && t <= 8.5)//第二天下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t2 - 4);
                //            }
                //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                //            {
                //                picker2.Value = strtimewanshang.AddDays(1).AddHours(t2 - 8.5);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddHours(t);
                //        }
                //    }

                //    //当前时间大于20:00
                //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                //    int ta16 = time1time.CompareTo(shijian6);

                //    if (ta16 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                //        picker1.Value = strtime1.AddDays(1);

                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                //        if (0 < t && t <= 4)
                //        {
                //            picker2.Value = strtime1.AddDays(1).AddHours(t);
                //        }
                //        if (4 < t && t <= 8.5)
                //        {
                //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 4);
                //        }
                //        if (8.5 < t && t <= 10.5)
                //        {
                //            picker2.Value = strtimewansahng.AddDays(1).AddHours(t - 8.5);
                //        }
                //    }


                //}

                //#endregion

                //#region 工时大于一天的工时小于两天的工时  10.5<t<=21

                //if (1.0 < flag && flag <= 2.0)
                //{
                //    int ta1 = shijian1.CompareTo(time1time);

                //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                //        if (10.5 < t && t <= 14.5)//上午完成
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                //        }
                //        if (14.5 < t && t <= 19)//下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 14.5);
                //        }
                //        if (19 < t && t <= 21)//晚上完成
                //        {
                //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 19);
                //        }

                //    }

                //    //当前时间大于8:00 小于12:00
                //    int ta3 = time1time.CompareTo(shijian1);
                //    int ta4 = shijian2.CompareTo(time1time);
                //    if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                //    {

                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                //        TimeSpan a = Time22.AddDays(1) - strtime.AddDays(1);//上午加工的时间
                //        if (t - 10.5 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                //        {

                //            double tt = t - 10.5 - a.TotalHours;//剩余加工的时间
                //            if (tt <= 4)//下午做完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tt);
                //            }
                //            if (4 < tt && tt <= 6.5)//晚上做完
                //            {
                //                picker2.Value = strtimewanshang.AddDays(1).AddHours(tt - 4);
                //            }
                //            if (tt >= 6.5)//第二天上午做完
                //            {
                //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                //        }
                //    }

                //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                //    int ta6 = time1time.CompareTo(shijian2);
                //    int ta7 = shijian3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                //        if (10.5 < t && t <= 14.5)//下午完成
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                //        }
                //        if (14.5 < t && t <= 17)//晚上完成
                //        {
                //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 14.5);
                //        }
                //        if (17 < t && t <= 21)//第二天上午完成
                //        {
                //            picker2.Value = strtime1.AddDays(2).AddHours(t - 17);
                //        }

                //    }

                //    //当前时间大于13:00 小于17:30
                //    int ta9 = time1time.CompareTo(shijian3);
                //    int ta10 = shijian4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + shijian3);//日期+12:30
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                //        TimeSpan tzhi = Time44.AddDays(1) - strtime.AddDays(1);//下午工作的时间
                //        if (t - 10.5 > tzhi.TotalHours)//第二天下午做不完
                //        {

                //            double ttzhi = t - 10.5 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= 2)//晚上完成
                //            {
                //                picker2.Value = strtimewanshang.AddDays(1).AddHours(ttzhi);
                //            }
                //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                //            {
                //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi - 2);
                //            }
                //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(ttzhi - 6);
                //            }

                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                //        }

                //    }

                //    //当前时间大于17:30 小于18:00
                //    int ta12 = time1time.CompareTo(shijian4);
                //    int ta13 = shijian5.CompareTo(time1time);

                //    if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                //        if (10.5 < t && t <= 12.5)//晚上完成
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                //        }
                //        if (12.5 < t && t <= 16.5)//第二天上午完成
                //        {
                //            picker2.Value = strtime1.AddDays(2).AddHours(t - 12.5);
                //        }
                //        if (16.5 < t && t <= 21)//第二天下午做完
                //        {
                //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 16.5);
                //        }

                //    }

                //    //当前时间大于18:00 小于20:00
                //    int ta14 = time1time.CompareTo(shijian5);
                //    int ta15 = shijian6.CompareTo(time1time);

                //    if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                //        TimeSpan t1 = strtimewuye.AddDays(1) - strtime.AddDays(1);//晚上加工的时间
                //        if (t - 10.5 >= t1.TotalHours)//晚上不能加工完成
                //        {
                //            double t2 = t - 10.5 - t1.TotalHours;//剩余加工的时间
                //            if (t2 <= 4)//第二天上午可以完成
                //            {
                //                picker2.Value = strtime1.AddDays(2).AddHours(t2);
                //            }
                //            if (4 < t && t <= 8.5)//第二天下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t2 - 4);
                //            }
                //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                //            {
                //                picker2.Value = strtimewanshang.AddDays(2).AddHours(t2 - 8.5);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                //        }
                //    }

                //    //当前时间大于20:00
                //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                //    int ta16 = time1time.CompareTo(shijian6);

                //    if (ta16 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                //        picker1.Value = strtime1.AddDays(1);

                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                //        if (10.5 < t && t <= 14.5)
                //        {
                //            picker2.Value = strtime1.AddDays(2).AddHours(t - 10.5);
                //        }
                //        if (14.5 < t && t <= 19)
                //        {
                //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 14.5);
                //        }
                //        if (19 < t && t <= 21)
                //        {
                //            picker2.Value = strtimewansahng.AddDays(2).AddHours(t - 19);
                //        }
                //    }

                //}

                //#endregion

                //#region 工时大于两天小于等于三天  21<t<=31.5

                //if (2.0 < flag && flag <= 3.0)
                //{
                //    int ta1 = shijian1.CompareTo(time1time);

                //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                //        if (21 < t && t <= 25)//上午完成
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                //        }
                //        if (25 < t && t <= 29.5)//下午完成
                //        {
                //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 25);
                //        }
                //        if (29.5 < t && t <= 31.5)//晚上完成
                //        {
                //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 29.5);
                //        }

                //    }

                //    //当前时间大于8:00 小于12:00
                //    int ta3 = time1time.CompareTo(shijian1);
                //    int ta4 = shijian2.CompareTo(time1time);
                //    if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                //    {

                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                //        TimeSpan a = Time22.AddDays(2) - strtime.AddDays(2);//上午加工的时间
                //        if (t - 21 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                //        {

                //            double tt = t - 21 - a.TotalHours;//剩余加工的时间
                //            if (tt <= 4)//下午做完
                //            {
                //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tt);
                //            }
                //            if (4 < tt && tt <= 6.5)//晚上做完
                //            {
                //                picker2.Value = strtimewanshang.AddDays(2).AddHours(tt - 4);
                //            }
                //            if (tt >= 6.5)//第二天上午做完
                //            {
                //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 10.5);
                //        }
                //    }

                //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                //    int ta6 = time1time.CompareTo(shijian2);
                //    int ta7 = shijian3.CompareTo(time1time);

                //    if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                //        if (21 < t && t <= 25)//下午完成
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                //        }
                //        if (25 < t && t <= 27.5)//晚上完成
                //        {
                //            picker2.Value = strtimewanshang.AddDays(2).AddHours(t - 25);
                //        }
                //        if (27.5 < t && t <= 31.5)//第二天上午完成
                //        {
                //            picker2.Value = strtime1.AddDays(3).AddHours(t - 27.5);
                //        }

                //    }

                //    //当前时间大于13:00 小于17:30
                //    int ta9 = time1time.CompareTo(shijian3);
                //    int ta10 = shijian4.CompareTo(time1time);

                //    if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + shijian3);//日期+12:30
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                //        TimeSpan tzhi = Time44.AddDays(2) - strtime.AddDays(2);//下午工作的时间
                //        if (t - 21 > tzhi.TotalHours)//第二天下午做不完
                //        {

                //            double ttzhi = t - 21 - tzhi.TotalHours;//剩余加工的时间
                //            if (ttzhi <= 2)//晚上完成
                //            {
                //                picker2.Value = strtimewanshang.AddDays(2).AddHours(ttzhi);
                //            }
                //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                //            {
                //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi - 2);
                //            }
                //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(3).AddHours(ttzhi - 6);
                //            }

                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                //        }

                //    }

                //    //当前时间大于17:30 小于18:00
                //    int ta12 = time1time.CompareTo(shijian4);
                //    int ta13 = shijian5.CompareTo(time1time);

                //    if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                //        if (21 < t && t <= 23)//晚上完成
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                //        }
                //        if (23 < t && t <= 27)//第二天上午完成
                //        {
                //            picker2.Value = strtime1.AddDays(3).AddHours(t - 23);
                //        }
                //        if (27 < t && t <= 31.5)//第二天下午做完
                //        {
                //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 27);
                //        }

                //    }

                //    //当前时间大于18:00 小于20:00
                //    int ta14 = time1time.CompareTo(shijian5);
                //    int ta15 = shijian6.CompareTo(time1time);

                //    if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                //        picker1.Value = Convert.ToDateTime(strtime);
                //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                //        TimeSpan t1 = strtimewuye.AddDays(2) - strtime.AddDays(2);//晚上加工的时间
                //        if (t - 21 >= t1.TotalHours)//晚上不能加工完成
                //        {
                //            double t2 = t - 21 - t1.TotalHours;//剩余加工的时间
                //            if (t2 <= 4)//第二天上午可以完成
                //            {
                //                picker2.Value = strtime1.AddDays(3).AddHours(t2);
                //            }
                //            if (4 < t && t <= 8.5)//第二天下午完成
                //            {
                //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t2 - 4);
                //            }
                //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                //            {
                //                picker2.Value = strtimewanshang.AddDays(3).AddHours(t2 - 8.5);
                //            }
                //        }
                //        else
                //        {
                //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                //        }
                //    }

                //    //当前时间大于20:00
                //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                //    int ta16 = time1time.CompareTo(shijian6);

                //    if (ta16 == 1)
                //    {
                //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                //        picker1.Value = strtime1.AddDays(1);

                //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                //        if (21 < t && t <= 25)
                //        {
                //            picker2.Value = strtime1.AddDays(3).AddHours(t - 21);
                //        }
                //        if (25 < t && t <= 29.5)
                //        {
                //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 25);
                //        }
                //        if (29.5 < t && t <= 31.5)
                //        {
                //            picker2.Value = strtimewansahng.AddDays(3).AddHours(t - 29.5);
                //        }
                //    }
                //}

                //#endregion

                #endregion
            }
            #endregion

            #region 设备不空闲
            else
            {
                string sql2 = "select max(设定开始时间) from db_Paichan where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select 设定结束时间 from db_Paichan where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束事假，结束时间就是当前时间
                DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                if (ret3 < time1)//设定结束时间 < 现在的时间 （最大的结束时间小于现在的时间也就是没有任务了）---空闲了
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 10.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                    int ta1 = shijian1.CompareTo(time1time);

                    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于8:00 小于12:00
                    int ta3 = time1time.CompareTo(shijian1);
                    int ta4 = shijian2.CompareTo(time1time);
                    if (ta3 == 1 && ta4 == 1)
                    {

                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                        if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        {

                            double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                            if (tt <= 4)//下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                            }
                            if (4 < tt && tt <= 6.5)//晚上做完
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                            }
                            if (tt >= 6.5)//第二天上午做完
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    int ta6 = time1time.CompareTo(shijian2);
                    int ta7 = shijian3.CompareTo(time1time);

                    if (ta6 == 1 && ta7 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于13:00 小于17:30
                    int ta9 = time1time.CompareTo(shijian3);
                    int ta10 = shijian4.CompareTo(time1time);

                    if (ta9 == 1 && ta10 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                        TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                        if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                        {

                            double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                            if (ttzhi <= 2)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                            }
                            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                            }
                            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                            }

                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }

                    }

                    //当前时间大于17:30 小于18:00
                    int ta12 = time1time.CompareTo(shijian4);
                    int ta13 = shijian5.CompareTo(time1time);

                    if (ta12 == 1 && ta13 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                        }
                        if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                        }

                    }

                    //当前时间大于18:00 小于20:00
                    int ta14 = time1time.CompareTo(shijian5);
                    int ta15 = shijian6.CompareTo(time1time);

                    if (ta14 == 1 && ta15 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                        if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                        {
                            double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                            if (t2 <= 4)//第二天上午可以完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                            }
                            if (4 < t && t <= 8.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                            }
                            if (8.5 < t && t <= 10.5)//第二天晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于20:00
                    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    int ta16 = time1time.CompareTo(shijian6);

                    if (ta16 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1.Value = strtime1.AddDays(1);

                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                        {
                            picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                        }
                    }


                    #region 死方法
                    //#region 工时小于等于一天的工时

                    //if (flag <= 1.0)//一天之内可以完成
                    //{
                    //    int ta1 = shijian1.CompareTo(time1time);

                    //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    //        if (0 < t && t <= 4)//上午完成
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //        if (4 < t && t <= 8.5)//下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddHours(t - 4);
                    //        }
                    //        if (8.5 < t && t <= 10.5)//晚上完成
                    //        {
                    //            picker2.Value = strtimewanshang.AddHours(t - 8.5);
                    //        }

                    //    }

                    //    //当前时间大于8:00 小于12:00
                    //    int ta3 = time1time.CompareTo(shijian1);
                    //    int ta4 = shijian2.CompareTo(time1time);
                    //    if (ta3 == 1 && ta4 == 1)
                    //    {

                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    //        TimeSpan a = Time22 - strtime;//上午加工的时间
                    //        if (t >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    //        {

                    //            double tt = t - a.TotalHours;//剩余加工的时间
                    //            if (tt <= 4)//下午做完
                    //            {
                    //                picker2.Value = strtimexiawu.AddHours(tt);
                    //            }
                    //            if (4 < tt && tt <= 6.5)//晚上做完
                    //            {
                    //                picker2.Value = strtimewanshang.AddHours(tt - 4);
                    //            }
                    //            if (tt >= 6.5)//第二天上午做完
                    //            {
                    //                picker2.Value = strtime1.AddDays(1).AddHours(tt - 6.5);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //    }

                    //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    //    int ta6 = time1time.CompareTo(shijian2);
                    //    int ta7 = shijian3.CompareTo(time1time);

                    //    if (ta6 == 1 && ta7 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    //        if (0 < t && t <= 4)//下午完成
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //        if (4 < t && t <= 6.5)//晚上完成
                    //        {
                    //            picker2.Value = strtimewanshang.AddHours(t - 4);
                    //        }
                    //        if (6.5 < t && t <= 10.5)//第二天上午完成
                    //        {
                    //            picker2.Value = strtime1.AddDays(1).AddHours(t - 6.5);
                    //        }

                    //    }

                    //    //当前时间大于13:00 小于17:30
                    //    int ta9 = time1time.CompareTo(shijian3);
                    //    int ta10 = shijian4.CompareTo(time1time);

                    //    if (ta9 == 1 && ta10 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                    //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                    //        TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                    //        if (t > tzhi.TotalHours)
                    //        {

                    //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                    //            if (ttzhi <= 2)//晚上完成
                    //            {
                    //                picker2.Value = strtimewanshang.AddHours(ttzhi);
                    //            }
                    //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                    //            {
                    //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi - 2);
                    //            }
                    //            if (6 < ttzhi && ttzhi <= 10.5)
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(1).AddHours(ttzhi - 6);
                    //            }

                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }

                    //    }

                    //    //当前时间大于17:30 小于18:00
                    //    int ta12 = time1time.CompareTo(shijian4);
                    //    int ta13 = shijian5.CompareTo(time1time);

                    //    if (ta12 == 1 && ta13 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    //        if (0 < t && t <= 2)//晚上完成
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //        if (2 < t && t <= 6)//第二天上午完成
                    //        {
                    //            picker2.Value = strtime1.AddDays(1).AddHours(t - 2);
                    //        }
                    //        if (6 < t && t < 10.5)//第二天下午做完
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 6);
                    //        }

                    //    }

                    //    //当前时间大于18:00 小于20:00
                    //    int ta14 = time1time.CompareTo(shijian5);
                    //    int ta15 = shijian6.CompareTo(time1time);

                    //    if (ta14 == 1 && ta15 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    //        TimeSpan t1 = strtimewuye - strtime;//晚上加工的时间
                    //        if (t >= t1.TotalHours)//晚上不能加工完成
                    //        {
                    //            double t2 = t - t1.TotalHours;//剩余加工的时间
                    //            if (t2 <= 4)//第二天上午可以完成
                    //            {
                    //                picker2.Value = strtime1.AddDays(1).AddHours(t2);
                    //            }
                    //            if (4 < t && t <= 8.5)//第二天下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t2 - 4);
                    //            }
                    //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(1).AddHours(t2 - 8.5);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddHours(t);
                    //        }
                    //    }

                    //    //当前时间大于20:00
                    //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    //    int ta16 = time1time.CompareTo(shijian6);

                    //    if (ta16 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    //        picker1.Value = strtime1.AddDays(1);

                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    //        if (0 < t && t <= 4)
                    //        {
                    //            picker2.Value = strtime1.AddDays(1).AddHours(t);
                    //        }
                    //        if (4 < t && t <= 8.5)
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 4);
                    //        }
                    //        if (8.5 < t && t <= 10.5)
                    //        {
                    //            picker2.Value = strtimewansahng.AddDays(1).AddHours(t - 8.5);
                    //        }
                    //    }


                    //}

                    //#endregion

                    //#region 工时大于一天的工时小于两天的工时  10.5<t<=21

                    //if (1.0 < flag && flag <= 2.0)
                    //{
                    //    int ta1 = shijian1.CompareTo(time1time);

                    //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    //        if (10.5 < t && t <= 14.5)//上午完成
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                    //        }
                    //        if (14.5 < t && t <= 19)//下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 14.5);
                    //        }
                    //        if (19 < t && t <= 21)//晚上完成
                    //        {
                    //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 19);
                    //        }

                    //    }

                    //    //当前时间大于8:00 小于12:00
                    //    int ta3 = time1time.CompareTo(shijian1);
                    //    int ta4 = shijian2.CompareTo(time1time);
                    //    if (ta3 == 1 && ta4 == 1)
                    //    {

                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    //        TimeSpan a = Time22.AddDays(1) - strtime.AddDays(1);//上午加工的时间
                    //        if (t - 10.5 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    //        {

                    //            double tt = t - 10.5 - a.TotalHours;//剩余加工的时间
                    //            if (tt <= 4)//下午做完
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tt);
                    //            }
                    //            if (4 < tt && tt <= 6.5)//晚上做完
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(1).AddHours(tt - 4);
                    //            }
                    //            if (tt >= 6.5)//第二天上午做完
                    //            {
                    //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                    //        }
                    //    }

                    //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    //    int ta6 = time1time.CompareTo(shijian2);
                    //    int ta7 = shijian3.CompareTo(time1time);

                    //    if (ta6 == 1 && ta7 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    //        if (10.5 < t && t <= 14.5)//下午完成
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                    //        }
                    //        if (14.5 < t && t <= 17)//晚上完成
                    //        {
                    //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 14.5);
                    //        }
                    //        if (17 < t && t <= 21)//第二天上午完成
                    //        {
                    //            picker2.Value = strtime1.AddDays(2).AddHours(t - 17);
                    //        }

                    //    }

                    //    //当前时间大于13:00 小于17:30
                    //    int ta9 = time1time.CompareTo(shijian3);
                    //    int ta10 = shijian4.CompareTo(time1time);

                    //    if (ta9 == 1 && ta10 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                    //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                    //        TimeSpan tzhi = Time44.AddDays(1) - strtime.AddDays(1);//下午工作的时间
                    //        if (t - 10.5 > tzhi.TotalHours)//第二天下午做不完
                    //        {

                    //            double ttzhi = t - 10.5 - tzhi.TotalHours;//剩余加工的时间
                    //            if (ttzhi <= 2)//晚上完成
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(1).AddHours(ttzhi);
                    //            }
                    //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                    //            {
                    //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi - 2);
                    //            }
                    //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(2).AddHours(ttzhi - 6);
                    //            }

                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                    //        }

                    //    }

                    //    //当前时间大于17:30 小于18:00
                    //    int ta12 = time1time.CompareTo(shijian4);
                    //    int ta13 = shijian5.CompareTo(time1time);

                    //    if (ta12 == 1 && ta13 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    //        if (10.5 < t && t <= 12.5)//晚上完成
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                    //        }
                    //        if (12.5 < t && t <= 16.5)//第二天上午完成
                    //        {
                    //            picker2.Value = strtime1.AddDays(2).AddHours(t - 12.5);
                    //        }
                    //        if (16.5 < t && t <= 21)//第二天下午做完
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 16.5);
                    //        }

                    //    }

                    //    //当前时间大于18:00 小于20:00
                    //    int ta14 = time1time.CompareTo(shijian5);
                    //    int ta15 = shijian6.CompareTo(time1time);

                    //    if (ta14 == 1 && ta15 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    //        TimeSpan t1 = strtimewuye.AddDays(1) - strtime.AddDays(1);//晚上加工的时间
                    //        if (t - 10.5 >= t1.TotalHours)//晚上不能加工完成
                    //        {
                    //            double t2 = t - 10.5 - t1.TotalHours;//剩余加工的时间
                    //            if (t2 <= 4)//第二天上午可以完成
                    //            {
                    //                picker2.Value = strtime1.AddDays(2).AddHours(t2);
                    //            }
                    //            if (4 < t && t <= 8.5)//第二天下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t2 - 4);
                    //            }
                    //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(2).AddHours(t2 - 8.5);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                    //        }
                    //    }

                    //    //当前时间大于20:00
                    //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    //    int ta16 = time1time.CompareTo(shijian6);

                    //    if (ta16 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    //        picker1.Value = strtime1.AddDays(1);

                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    //        if (10.5 < t && t <= 14.5)
                    //        {
                    //            picker2.Value = strtime1.AddDays(2).AddHours(t - 10.5);
                    //        }
                    //        if (14.5 < t && t <= 19)
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 14.5);
                    //        }
                    //        if (19 < t && t <= 21)
                    //        {
                    //            picker2.Value = strtimewansahng.AddDays(2).AddHours(t - 19);
                    //        }
                    //    }

                    //}

                    //#endregion

                    //#region 工时大于两天小于等于三天  21<t<=31.5

                    //if (2.0 < flag && flag <= 3.0)
                    //{
                    //    int ta1 = shijian1.CompareTo(time1time);

                    //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    //        if (21 < t && t <= 25)//上午完成
                    //        {
                    //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                    //        }
                    //        if (25 < t && t <= 29.5)//下午完成
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 25);
                    //        }
                    //        if (29.5 < t && t <= 31.5)//晚上完成
                    //        {
                    //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 29.5);
                    //        }

                    //    }

                    //    //当前时间大于8:00 小于12:00
                    //    int ta3 = time1time.CompareTo(shijian1);
                    //    int ta4 = shijian2.CompareTo(time1time);
                    //    if (ta3 == 1 && ta4 == 1)
                    //    {

                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    //        TimeSpan a = Time22.AddDays(2) - strtime.AddDays(2);//上午加工的时间
                    //        if (t - 21 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    //        {

                    //            double tt = t - 21 - a.TotalHours;//剩余加工的时间
                    //            if (tt <= 4)//下午做完
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tt);
                    //            }
                    //            if (4 < tt && tt <= 6.5)//晚上做完
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(2).AddHours(tt - 4);
                    //            }
                    //            if (tt >= 6.5)//第二天上午做完
                    //            {
                    //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(2).AddHours(t - 10.5);
                    //        }
                    //    }

                    //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    //    int ta6 = time1time.CompareTo(shijian2);
                    //    int ta7 = shijian3.CompareTo(time1time);

                    //    if (ta6 == 1 && ta7 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    //        if (21 < t && t <= 25)//下午完成
                    //        {
                    //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                    //        }
                    //        if (25 < t && t <= 27.5)//晚上完成
                    //        {
                    //            picker2.Value = strtimewanshang.AddDays(2).AddHours(t - 25);
                    //        }
                    //        if (27.5 < t && t <= 31.5)//第二天上午完成
                    //        {
                    //            picker2.Value = strtime1.AddDays(3).AddHours(t - 27.5);
                    //        }

                    //    }

                    //    //当前时间大于13:00 小于17:30
                    //    int ta9 = time1time.CompareTo(shijian3);
                    //    int ta10 = shijian4.CompareTo(time1time);

                    //    if (ta9 == 1 && ta10 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                    //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                    //        TimeSpan tzhi = Time44.AddDays(2) - strtime.AddDays(2);//下午工作的时间
                    //        if (t - 21 > tzhi.TotalHours)//第二天下午做不完
                    //        {

                    //            double ttzhi = t - 21 - tzhi.TotalHours;//剩余加工的时间
                    //            if (ttzhi <= 2)//晚上完成
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(2).AddHours(ttzhi);
                    //            }
                    //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                    //            {
                    //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi - 2);
                    //            }
                    //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(3).AddHours(ttzhi - 6);
                    //            }

                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                    //        }

                    //    }

                    //    //当前时间大于17:30 小于18:00
                    //    int ta12 = time1time.CompareTo(shijian4);
                    //    int ta13 = shijian5.CompareTo(time1time);

                    //    if (ta12 == 1 && ta13 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    //        if (21 < t && t <= 23)//晚上完成
                    //        {
                    //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                    //        }
                    //        if (23 < t && t <= 27)//第二天上午完成
                    //        {
                    //            picker2.Value = strtime1.AddDays(3).AddHours(t - 23);
                    //        }
                    //        if (27 < t && t <= 31.5)//第二天下午做完
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 27);
                    //        }

                    //    }

                    //    //当前时间大于18:00 小于20:00
                    //    int ta14 = time1time.CompareTo(shijian5);
                    //    int ta15 = shijian6.CompareTo(time1time);

                    //    if (ta14 == 1 && ta15 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    //        picker1.Value = Convert.ToDateTime(strtime);
                    //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    //        TimeSpan t1 = strtimewuye.AddDays(2) - strtime.AddDays(2);//晚上加工的时间
                    //        if (t - 21 >= t1.TotalHours)//晚上不能加工完成
                    //        {
                    //            double t2 = t - 21 - t1.TotalHours;//剩余加工的时间
                    //            if (t2 <= 4)//第二天上午可以完成
                    //            {
                    //                picker2.Value = strtime1.AddDays(3).AddHours(t2);
                    //            }
                    //            if (4 < t && t <= 8.5)//第二天下午完成
                    //            {
                    //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t2 - 4);
                    //            }
                    //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                    //            {
                    //                picker2.Value = strtimewanshang.AddDays(3).AddHours(t2 - 8.5);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                    //        }
                    //    }

                    //    //当前时间大于20:00
                    //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    //    int ta16 = time1time.CompareTo(shijian6);

                    //    if (ta16 == 1)
                    //    {
                    //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    //        picker1.Value = strtime1.AddDays(1);

                    //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    //        if (21 < t && t <= 25)
                    //        {
                    //            picker2.Value = strtime1.AddDays(3).AddHours(t - 21);
                    //        }
                    //        if (25 < t && t <= 29.5)
                    //        {
                    //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 25);
                    //        }
                    //        if (29.5 < t && t <= 31.5)
                    //        {
                    //            picker2.Value = strtimewansahng.AddDays(3).AddHours(t - 29.5);
                    //        }
                    //    }
                    //}

                    //#endregion
                    #endregion

                }
                else//(设定结束时间 > 现在的时间（用设定结束时间算）)----将设定结束时间当做现在时间算  ret3---结束时间
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
                    {

                        string ret3date = ret3.ToString("yyyy/MM/dd");
                        string ret3time = ret3.ToString("HH:mm:ss");
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 10.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        int ta1 = shijian1.CompareTo(time1time);

                        if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - ret3.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+12:30
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00                                
                            DateTime Time44 = Convert.ToDateTime(ret3date + " " + shijian4);//日期 + 17:30

                            TimeSpan tzhi = Time44.AddDays(at) - ret3.AddDays(at);//下午工作的时间
                            if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                            {

                                double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= 2)//晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - ret3.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t && t <= 8.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t && t <= 10.5)//第二天晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1.Value = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }

                        #region 死方法
                        //#region 工时小于等于一天的工时

                        //if (flag <= 1.0)//一天之内可以完成
                        //{
                        //    int ta1 = shijian1.CompareTo(ret3time);

                        //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                        //        if (0 < t && t <= 4)//上午完成
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //        if (4 < t && t <= 8.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddHours(t - 4);
                        //        }
                        //        if (8.5 < t && t <= 10.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddHours(t - 8.5);
                        //        }

                        //    }

                        //    //当前时间大于8:00 小于12:00
                        //    int ta3 = ret3time.CompareTo(shijian1);
                        //    int ta4 = shijian2.CompareTo(ret3time);
                        //    if (ta3 == 1 && ta4 == 1)
                        //    {

                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                        //        TimeSpan a = Time22 - ret3;//上午加工的时间
                        //        if (t >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        //        {

                        //            double tt = t - a.TotalHours;//剩余加工的时间
                        //            if (tt <= 4)//下午做完
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(tt);
                        //            }
                        //            if (4 < tt && tt <= 6.5)//晚上做完
                        //            {
                        //                picker2.Value = strtimewanshang.AddHours(tt - 4);
                        //            }
                        //            if (tt >= 6.5)//第二天上午做完
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(tt - 6.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);
                        //        }
                        //    }

                        //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        //    int ta6 = ret3time.CompareTo(shijian2);
                        //    int ta7 = shijian3.CompareTo(ret3time);

                        //    if (ta6 == 1 && ta7 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                        //        if (0 < t && t <= 4)//下午完成
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //        if (4 < t && t <= 6.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddHours(t - 4);
                        //        }
                        //        if (6.5 < t && t <= 10.5)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t - 6.5);
                        //        }

                        //    }

                        //    //当前时间大于13:00 小于17:30
                        //    int ta9 = ret3time.CompareTo(shijian3);
                        //    int ta10 = shijian4.CompareTo(ret3time);

                        //    if (ta9 == 1 && ta10 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+12:30
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + shijian4);//日期 + 17:30

                        //        TimeSpan tzhi = Time44 - ret3;//下午工作的时间
                        //        if (t > tzhi.TotalHours)
                        //        {

                        //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= 2)//晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddHours(ttzhi);
                        //            }
                        //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi - 2);
                        //            }
                        //            if (6 < ttzhi && ttzhi <= 10.5)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(ttzhi - 6);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);
                        //        }

                        //    }

                        //    //当前时间大于17:30 小于18:00
                        //    int ta12 = ret3time.CompareTo(shijian4);
                        //    int ta13 = shijian5.CompareTo(ret3time);

                        //    if (ta12 == 1 && ta13 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                        //        if (0 < t && t <= 2)//晚上完成
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //        if (2 < t && t <= 6)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t - 2);
                        //        }
                        //        if (6 < t && t < 10.5)//第二天下午做完
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 6);
                        //        }

                        //    }

                        //    //当前时间大于18:00 小于20:00
                        //    int ta14 = ret3time.CompareTo(shijian5);
                        //    int ta15 = shijian6.CompareTo(ret3time);

                        //    if (ta14 == 1 && ta15 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                        //        TimeSpan t1 = strtimewuye - ret3;//晚上加工的时间
                        //        if (t >= t1.TotalHours)//晚上不能加工完成
                        //        {
                        //            double t2 = t - t1.TotalHours;//剩余加工的时间
                        //            if (t2 <= 4)//第二天上午可以完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(t2);
                        //            }
                        //            if (4 < t && t <= 8.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t2 - 4);
                        //            }
                        //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(1).AddHours(t2 - 8.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddHours(t);
                        //        }
                        //    }

                        //    //当前时间大于20:00
                        //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        //    int ta16 = ret3time.CompareTo(shijian6);

                        //    if (ta16 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = strtime1.AddDays(1);

                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                        //        DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                        //        if (0 < t && t <= 4)
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t);
                        //        }
                        //        if (4 < t && t <= 8.5)
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 4);
                        //        }
                        //        if (8.5 < t && t <= 10.5)
                        //        {
                        //            picker2.Value = strtimewansahng.AddDays(1).AddHours(t - 8.5);
                        //        }
                        //    }


                        //}

                        //#endregion

                        //#region 工时大于一天的工时小于两天的工时  10.5<t<=21

                        //if (1.0 < flag && flag <= 2.0)
                        //{
                        //    int ta1 = shijian1.CompareTo(time1time);

                        //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                        //        if (10.5 < t && t <= 14.5)//上午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //        if (14.5 < t && t <= 19)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 14.5);
                        //        }
                        //        if (19 < t && t <= 21)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 19);
                        //        }

                        //    }

                        //    //当前时间大于8:00 小于12:00
                        //    int ta3 = time1time.CompareTo(shijian1);
                        //    int ta4 = shijian2.CompareTo(time1time);
                        //    if (ta3 == 1 && ta4 == 1)
                        //    {

                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                        //        TimeSpan a = Time22.AddDays(1) - ret3.AddDays(1);//上午加工的时间
                        //        if (t - 10.5 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        //        {

                        //            double tt = t - 10.5 - a.TotalHours;//剩余加工的时间
                        //            if (tt <= 4)//下午做完
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tt);
                        //            }
                        //            if (4 < tt && tt <= 6.5)//晚上做完
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(1).AddHours(tt - 4);
                        //            }
                        //            if (tt >= 6.5)//第二天上午做完
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //    }

                        //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        //    int ta6 = time1time.CompareTo(shijian2);
                        //    int ta7 = shijian3.CompareTo(time1time);

                        //    if (ta6 == 1 && ta7 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                        //        if (10.5 < t && t <= 14.5)//下午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //        if (14.5 < t && t <= 17)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 14.5);
                        //        }
                        //        if (17 < t && t <= 21)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t - 17);
                        //        }

                        //    }

                        //    //当前时间大于13:00 小于17:30
                        //    int ta9 = time1time.CompareTo(shijian3);
                        //    int ta10 = shijian4.CompareTo(time1time);

                        //    if (ta9 == 1 && ta10 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+12:30
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + shijian4);//日期 + 17:30

                        //        TimeSpan tzhi = Time44.AddDays(1) - ret3.AddDays(1);//下午工作的时间
                        //        if (t - 10.5 > tzhi.TotalHours)//第二天下午做不完
                        //        {

                        //            double ttzhi = t - 10.5 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= 2)//晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(1).AddHours(ttzhi);
                        //            }
                        //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi - 2);
                        //            }
                        //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(ttzhi - 6);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 10.5);
                        //        }

                        //    }

                        //    //当前时间大于17:30 小于18:00
                        //    int ta12 = time1time.CompareTo(shijian4);
                        //    int ta13 = shijian5.CompareTo(time1time);

                        //    if (ta12 == 1 && ta13 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                        //        if (10.5 < t && t <= 12.5)//晚上完成
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //        if (12.5 < t && t <= 16.5)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t - 12.5);
                        //        }
                        //        if (16.5 < t && t <= 21)//第二天下午做完
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 16.5);
                        //        }

                        //    }

                        //    //当前时间大于18:00 小于20:00
                        //    int ta14 = time1time.CompareTo(shijian5);
                        //    int ta15 = shijian6.CompareTo(time1time);

                        //    if (ta14 == 1 && ta15 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                        //        TimeSpan t1 = strtimewuye.AddDays(1) - ret3.AddDays(1);//晚上加工的时间
                        //        if (t - 10.5 >= t1.TotalHours)//晚上不能加工完成
                        //        {
                        //            double t2 = t - 10.5 - t1.TotalHours;//剩余加工的时间
                        //            if (t2 <= 4)//第二天上午可以完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(t2);
                        //            }
                        //            if (4 < t && t <= 8.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t2 - 4);
                        //            }
                        //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(2).AddHours(t2 - 8.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //    }

                        //    //当前时间大于20:00
                        //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        //    int ta16 = time1time.CompareTo(shijian6);

                        //    if (ta16 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = strtime1.AddDays(1);

                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                        //        DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                        //        if (10.5 < t && t <= 14.5)
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t - 10.5);
                        //        }
                        //        if (14.5 < t && t <= 19)
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 14.5);
                        //        }
                        //        if (19 < t && t <= 21)
                        //        {
                        //            picker2.Value = strtimewansahng.AddDays(2).AddHours(t - 19);
                        //        }
                        //    }

                        //}

                        //#endregion

                        //#region 工时大于两天小于等于三天  21<t<=31.5

                        //if (2.0 < flag && flag <= 3.0)
                        //{
                        //    int ta1 = shijian1.CompareTo(time1time);

                        //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                        //        if (21 < t && t <= 25)//上午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //        if (25 < t && t <= 29.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 25);
                        //        }
                        //        if (29.5 < t && t <= 31.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 29.5);
                        //        }

                        //    }

                        //    //当前时间大于8:00 小于12:00
                        //    int ta3 = time1time.CompareTo(shijian1);
                        //    int ta4 = shijian2.CompareTo(time1time);
                        //    if (ta3 == 1 && ta4 == 1)
                        //    {

                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                        //        DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                        //        TimeSpan a = Time22.AddDays(2) - ret3.AddDays(2);//上午加工的时间
                        //        if (t - 21 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        //        {

                        //            double tt = t - 21 - a.TotalHours;//剩余加工的时间
                        //            if (tt <= 4)//下午做完
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tt);
                        //            }
                        //            if (4 < tt && tt <= 6.5)//晚上做完
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(2).AddHours(tt - 4);
                        //            }
                        //            if (tt >= 6.5)//第二天上午做完
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(2).AddHours(t - 10.5);
                        //        }
                        //    }

                        //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        //    int ta6 = time1time.CompareTo(shijian2);
                        //    int ta7 = shijian3.CompareTo(time1time);

                        //    if (ta6 == 1 && ta7 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                        //        if (21 < t && t <= 25)//下午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //        if (25 < t && t <= 27.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(2).AddHours(t - 25);
                        //        }
                        //        if (27.5 < t && t <= 31.5)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(3).AddHours(t - 27.5);
                        //        }

                        //    }

                        //    //当前时间大于13:00 小于17:30
                        //    int ta9 = time1time.CompareTo(shijian3);
                        //    int ta10 = shijian4.CompareTo(time1time);

                        //    if (ta9 == 1 && ta10 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+12:30
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00                                
                        //        DateTime Time44 = Convert.ToDateTime(ret3date + " " + shijian4);//日期 + 17:30

                        //        TimeSpan tzhi = Time44.AddDays(2) - ret3.AddDays(2);//下午工作的时间
                        //        if (t - 21 > tzhi.TotalHours)//第二天下午做不完
                        //        {

                        //            double ttzhi = t - 21 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= 2)//晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(2).AddHours(ttzhi);
                        //            }
                        //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi - 2);
                        //            }
                        //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(3).AddHours(ttzhi - 6);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(2).AddHours(t - 21);
                        //        }

                        //    }

                        //    //当前时间大于17:30 小于18:00
                        //    int ta12 = time1time.CompareTo(shijian4);
                        //    int ta13 = shijian5.CompareTo(time1time);

                        //    if (ta12 == 1 && ta13 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                        //        if (21 < t && t <= 23)//晚上完成
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //        if (23 < t && t <= 27)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(3).AddHours(t - 23);
                        //        }
                        //        if (27 < t && t <= 31.5)//第二天下午做完
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 27);
                        //        }

                        //    }

                        //    //当前时间大于18:00 小于20:00
                        //    int ta14 = time1time.CompareTo(shijian5);
                        //    int ta15 = shijian6.CompareTo(time1time);

                        //    if (ta14 == 1 && ta15 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = Convert.ToDateTime(ret3);
                        //        DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                        //        TimeSpan t1 = strtimewuye.AddDays(2) - ret3.AddDays(2);//晚上加工的时间
                        //        if (t - 21 >= t1.TotalHours)//晚上不能加工完成
                        //        {
                        //            double t2 = t - 21 - t1.TotalHours;//剩余加工的时间
                        //            if (t2 <= 4)//第二天上午可以完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(3).AddHours(t2);
                        //            }
                        //            if (4 < t && t <= 8.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t2 - 4);
                        //            }
                        //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(3).AddHours(t2 - 8.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = ret3.AddDays(2).AddHours(t - 21);
                        //        }
                        //    }

                        //    //当前时间大于20:00
                        //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        //    int ta16 = time1time.CompareTo(shijian6);

                        //    if (ta16 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = strtime1.AddDays(1);

                        //        DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                        //        DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                        //        if (21 < t && t <= 25)
                        //        {
                        //            picker2.Value = strtime1.AddDays(3).AddHours(t - 21);
                        //        }
                        //        if (25 < t && t <= 29.5)
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 25);
                        //        }
                        //        if (29.5 < t && t <= 31.5)
                        //        {
                        //            picker2.Value = strtimewansahng.AddDays(3).AddHours(t - 29.5);
                        //        }
                        //    }
                        //}

                        //#endregion
                        #endregion
                    }
                    else//-----------------ret3 < datetimepicker(用time1date和time1time)----time
                    {
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 10.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        int ta1 = shijian1.CompareTo(time1time);

                        if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                            TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                            if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                            {

                                double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= 2)//晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 10.5 * at + 2)//晚上完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t && t <= 8.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t && t <= 10.5)//第二天晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1.Value = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }

                        #region 死方法

                        //#region 工时小于等于一天的工时

                        ////算总的工时
                        //double price = Convert.ToDouble(jiage);
                        //price = price * (Convert.ToInt32(shuliang));
                        //double t = (double)price / 27;
                        //double flag = t / 10.5;

                        //if (flag <= 1.0)//一天之内可以完成
                        //{
                        //    int ta1 = shijian1.CompareTo(time1time);

                        //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        //        if (0 < t && t <= 4)//上午完成
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //        if (4 < t && t <= 8.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddHours(t - 4);
                        //        }
                        //        if (8.5 < t && t <= 10.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddHours(t - 8.5);
                        //        }

                        //    }

                        //    //当前时间大于8:00 小于12:00
                        //    int ta3 = time1time.CompareTo(shijian1);
                        //    int ta4 = shijian2.CompareTo(time1time);
                        //    if (ta3 == 1 && ta4 == 1)
                        //    {

                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        //        TimeSpan a = Time22 - strtime;//上午加工的时间
                        //        if (t >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        //        {

                        //            double tt = t - a.TotalHours;//剩余加工的时间
                        //            if (tt <= 4)//下午做完
                        //            {
                        //                picker2.Value = strtimexiawu.AddHours(tt);
                        //            }
                        //            if (4 < tt && tt <= 6.5)//晚上做完
                        //            {
                        //                picker2.Value = strtimewanshang.AddHours(tt - 4);
                        //            }
                        //            if (tt >= 6.5)//第二天上午做完
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(tt - 6.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //    }

                        //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        //    int ta6 = time1time.CompareTo(shijian2);
                        //    int ta7 = shijian3.CompareTo(time1time);

                        //    if (ta6 == 1 && ta7 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        //        if (0 < t && t <= 4)//下午完成
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //        if (4 < t && t <= 6.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddHours(t - 4);
                        //        }
                        //        if (6.5 < t && t <= 10.5)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t - 6.5);
                        //        }

                        //    }

                        //    //当前时间大于13:00 小于17:30
                        //    int ta9 = time1time.CompareTo(shijian3);
                        //    int ta10 = shijian4.CompareTo(time1time);

                        //    if (ta9 == 1 && ta10 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " "+ shijian3);//日期+12:30
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                        //        picker1.Value = Convert.ToDateTime(strtime);

                        //        TimeSpan tzhi = Time44 - strtime;//下午工作的时间
                        //        if (t > tzhi.TotalHours)
                        //        {

                        //            double ttzhi = t - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= 2)//晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddHours(ttzhi);
                        //            }
                        //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(ttzhi - 2);
                        //            }
                        //            if (6 < ttzhi && ttzhi <= 10.5)
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(ttzhi - 6);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }

                        //    }

                        //    //当前时间大于17:30 小于18:00
                        //    int ta12 = time1time.CompareTo(shijian4);
                        //    int ta13 = shijian5.CompareTo(time1time);

                        //    if (ta12 == 1 && ta13 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        //        if (0 < t && t <= 2)//晚上完成
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //        if (2 < t && t <= 6)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t - 2);
                        //        }
                        //        if (6 < t && t < 10.5)//第二天下午做完
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 6);
                        //        }

                        //    }

                        //    //当前时间大于18:00 小于20:00
                        //    int ta14 = time1time.CompareTo(shijian5);
                        //    int ta15 = shijian6.CompareTo(time1time);

                        //    if (ta14 == 1 && ta15 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        //        TimeSpan t1 = strtimewuye - strtime;//晚上加工的时间
                        //        if (t >= t1.TotalHours)//晚上不能加工完成
                        //        {
                        //            double t2 = t - t1.TotalHours;//剩余加工的时间
                        //            if (t2 <= 4)//第二天上午可以完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(1).AddHours(t2);
                        //            }
                        //            if (4 < t && t <= 8.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(t2 - 4);
                        //            }
                        //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(1).AddHours(t2 - 8.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddHours(t);
                        //        }
                        //    }

                        //    //当前时间大于20:00
                        //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        //    int ta16 = time1time.CompareTo(shijian6);

                        //    if (ta16 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = strtime1.AddDays(1);

                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        //        if (0 < t && t <= 4)
                        //        {
                        //            picker2.Value = strtime1.AddDays(1).AddHours(t);
                        //        }
                        //        if (4 < t && t <= 8.5)
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 4);
                        //        }
                        //        if (8.5 < t && t <= 10.5)
                        //        {
                        //            picker2.Value = strtimewansahng.AddDays(1).AddHours(t - 8.5);
                        //        }
                        //    }


                        //}

                        //#endregion

                        //#region 工时大于一天的工时小于两天的工时  10.5<t<=21

                        //if (1.0 < flag && flag <= 2.0)
                        //{
                        //    int ta1 = shijian1.CompareTo(time1time);

                        //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        //        if (10.5 < t && t <= 14.5)//上午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //        if (14.5 < t && t <= 19)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(1).AddHours(t - 14.5);
                        //        }
                        //        if (19 < t && t <= 21)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 19);
                        //        }

                        //    }

                        //    //当前时间大于8:00 小于12:00
                        //    int ta3 = time1time.CompareTo(shijian1);
                        //    int ta4 = shijian2.CompareTo(time1time);
                        //    if (ta3 == 1 && ta4 == 1)
                        //    {

                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        //        TimeSpan a = Time22.AddDays(1) - strtime.AddDays(1);//上午加工的时间
                        //        if (t - 10.5 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        //        {

                        //            double tt = t - 10.5 - a.TotalHours;//剩余加工的时间
                        //            if (tt <= 4)//下午做完
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(1).AddHours(tt);
                        //            }
                        //            if (4 < tt && tt <= 6.5)//晚上做完
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(1).AddHours(tt - 4);
                        //            }
                        //            if (tt >= 6.5)//第二天上午做完
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //    }

                        //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        //    int ta6 = time1time.CompareTo(shijian2);
                        //    int ta7 = shijian3.CompareTo(time1time);

                        //    if (ta6 == 1 && ta7 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        //        if (10.5 < t && t <= 14.5)//下午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //        if (14.5 < t && t <= 17)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 14.5);
                        //        }
                        //        if (17 < t && t <= 21)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t - 17);
                        //        }

                        //    }

                        //    //当前时间大于13:00 小于17:30
                        //    int ta9 = time1time.CompareTo(shijian3);
                        //    int ta10 = shijian4.CompareTo(time1time);

                        //    if (ta9 == 1 && ta10 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                        //        TimeSpan tzhi = Time44.AddDays(1) - strtime.AddDays(1);//下午工作的时间
                        //        if (t - 10.5 > tzhi.TotalHours)//第二天下午做不完
                        //        {

                        //            double ttzhi = t - 10.5 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= 2)//晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(1).AddHours(ttzhi);
                        //            }
                        //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(ttzhi - 2);
                        //            }
                        //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(ttzhi - 6);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }

                        //    }

                        //    //当前时间大于17:30 小于18:00
                        //    int ta12 = time1time.CompareTo(shijian4);
                        //    int ta13 = shijian5.CompareTo(time1time);

                        //    if (ta12 == 1 && ta13 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        //        if (10.5 < t && t <= 12.5)//晚上完成
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //        if (12.5 < t && t <= 16.5)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t - 12.5);
                        //        }
                        //        if (16.5 < t && t <= 21)//第二天下午做完
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 16.5);
                        //        }

                        //    }

                        //    //当前时间大于18:00 小于20:00
                        //    int ta14 = time1time.CompareTo(shijian5);
                        //    int ta15 = shijian6.CompareTo(time1time);

                        //    if (ta14 == 1 && ta15 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        //        TimeSpan t1 = strtimewuye.AddDays(1) - strtime.AddDays(1);//晚上加工的时间
                        //        if (t - 10.5 >= t1.TotalHours)//晚上不能加工完成
                        //        {
                        //            double t2 = t - 10.5 - t1.TotalHours;//剩余加工的时间
                        //            if (t2 <= 4)//第二天上午可以完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(t2);
                        //            }
                        //            if (4 < t && t <= 8.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(t2 - 4);
                        //            }
                        //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(2).AddHours(t2 - 8.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddDays(1).AddHours(t - 10.5);
                        //        }
                        //    }

                        //    //当前时间大于20:00
                        //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        //    int ta16 = time1time.CompareTo(shijian6);

                        //    if (ta16 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = strtime1.AddDays(1);

                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        //        if (10.5 < t && t <= 14.5)
                        //        {
                        //            picker2.Value = strtime1.AddDays(2).AddHours(t - 10.5);
                        //        }
                        //        if (14.5 < t && t <= 19)
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 14.5);
                        //        }
                        //        if (19 < t && t <= 21)
                        //        {
                        //            picker2.Value = strtimewansahng.AddDays(2).AddHours(t - 19);
                        //        }
                        //    }

                        //}

                        //#endregion

                        //#region 工时大于两天小于等于三天  21<t<=31.5

                        //if (2.0 < flag && flag <= 3.0)
                        //{
                        //    int ta1 = shijian1.CompareTo(time1time);

                        //    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        //        if (21 < t && t <= 25)//上午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //        if (25 < t && t <= 29.5)//下午完成
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(2).AddHours(t - 25);
                        //        }
                        //        if (29.5 < t && t <= 31.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(1).AddHours(t - 29.5);
                        //        }

                        //    }

                        //    //当前时间大于8:00 小于12:00
                        //    int ta3 = time1time.CompareTo(shijian1);
                        //    int ta4 = shijian2.CompareTo(time1time);
                        //    if (ta3 == 1 && ta4 == 1)
                        //    {

                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        //        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        //        TimeSpan a = Time22.AddDays(2) - strtime.AddDays(2);//上午加工的时间
                        //        if (t - 21 >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        //        {

                        //            double tt = t - 21 - a.TotalHours;//剩余加工的时间
                        //            if (tt <= 4)//下午做完
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(2).AddHours(tt);
                        //            }
                        //            if (4 < tt && tt <= 6.5)//晚上做完
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(2).AddHours(tt - 4);
                        //            }
                        //            if (tt >= 6.5)//第二天上午做完
                        //            {
                        //                picker2.Value = strtime1.AddDays(2).AddHours(tt - 6.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 10.5);
                        //        }
                        //    }

                        //    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        //    int ta6 = time1time.CompareTo(shijian2);
                        //    int ta7 = shijian3.CompareTo(time1time);

                        //    if (ta6 == 1 && ta7 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        //        if (21 < t && t <= 25)//下午完成
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //        if (25 < t && t <= 27.5)//晚上完成
                        //        {
                        //            picker2.Value = strtimewanshang.AddDays(2).AddHours(t - 25);
                        //        }
                        //        if (27.5 < t && t <= 31.5)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(3).AddHours(t - 27.5);
                        //        }

                        //    }

                        //    //当前时间大于13:00 小于17:30
                        //    int ta9 = time1time.CompareTo(shijian3);
                        //    int ta10 = shijian4.CompareTo(time1time);

                        //    if (ta9 == 1 && ta10 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                        //        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                        //        TimeSpan tzhi = Time44.AddDays(2) - strtime.AddDays(2);//下午工作的时间
                        //        if (t - 21 > tzhi.TotalHours)//第二天下午做不完
                        //        {

                        //            double ttzhi = t - 21 - tzhi.TotalHours;//剩余加工的时间
                        //            if (ttzhi <= 2)//晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(2).AddHours(ttzhi);
                        //            }
                        //            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(3).AddHours(ttzhi - 2);
                        //            }
                        //            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(3).AddHours(ttzhi - 6);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }

                        //    }

                        //    //当前时间大于17:30 小于18:00
                        //    int ta12 = time1time.CompareTo(shijian4);
                        //    int ta13 = shijian5.CompareTo(time1time);

                        //    if (ta12 == 1 && ta13 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        //        if (21 < t && t <= 23)//晚上完成
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //        if (23 < t && t <= 27)//第二天上午完成
                        //        {
                        //            picker2.Value = strtime1.AddDays(3).AddHours(t - 23);
                        //        }
                        //        if (27 < t && t <= 31.5)//第二天下午做完
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 27);
                        //        }

                        //    }

                        //    //当前时间大于18:00 小于20:00
                        //    int ta14 = time1time.CompareTo(shijian5);
                        //    int ta15 = shijian6.CompareTo(time1time);

                        //    if (ta14 == 1 && ta15 == 1)
                        //    {
                        //        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = Convert.ToDateTime(strtime);
                        //        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        //        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        //        TimeSpan t1 = strtimewuye.AddDays(2) - strtime.AddDays(2);//晚上加工的时间
                        //        if (t - 21 >= t1.TotalHours)//晚上不能加工完成
                        //        {
                        //            double t2 = t - 21 - t1.TotalHours;//剩余加工的时间
                        //            if (t2 <= 4)//第二天上午可以完成
                        //            {
                        //                picker2.Value = strtime1.AddDays(3).AddHours(t2);
                        //            }
                        //            if (4 < t && t <= 8.5)//第二天下午完成
                        //            {
                        //                picker2.Value = strtimexiawu.AddDays(3).AddHours(t2 - 4);
                        //            }
                        //            if (8.5 < t && t <= 10.5)//第二天晚上完成
                        //            {
                        //                picker2.Value = strtimewanshang.AddDays(3).AddHours(t2 - 8.5);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            picker2.Value = strtime.AddDays(2).AddHours(t - 21);
                        //        }
                        //    }

                        //    //当前时间大于20:00
                        //    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        //    int ta16 = time1time.CompareTo(shijian6);

                        //    if (ta16 == 1)
                        //    {
                        //        //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                        //        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        //        picker1.Value = strtime1.AddDays(1);

                        //        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        //        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        //        if (21 < t && t <= 25)
                        //        {
                        //            picker2.Value = strtime1.AddDays(3).AddHours(t - 21);
                        //        }
                        //        if (25 < t && t <= 29.5)
                        //        {
                        //            picker2.Value = strtimexiawu.AddDays(3).AddHours(t - 25);
                        //        }
                        //        if (29.5 < t && t <= 31.5)
                        //        {
                        //            picker2.Value = strtimewansahng.AddDays(3).AddHours(t - 29.5);
                        //        }
                        //    }
                        //}

                        //#endregion
                        #endregion
                    }
                }

            }
            #endregion
        }

        private void shuaxin()
        {
            //dateTimePicker1.Text = "";
            //dateTimePicker2.Text = "";
            //dateTimePicker3.Text = "";
            //dateTimePicker4.Text = "";
            //dateTimePicker5.Text = "";
            //dateTimePicker6.Text = "";
            //dateTimePicker7.Text = "";
            //dateTimePicker8.Text = "";
            //dateTimePicker9.Text = "";
            //dateTimePicker10.Text = "";
            //dateTimePicker11.Text = "";
            //dateTimePicker12.Text = "";
            //dateTimePicker13.Text = "";
            //dateTimePicker14.Text = "";
            //dateTimePicker15.Text = "";
            //dateTimePicker16.Text = "";
            //dateTimePicker17.Text = "";
            //dateTimePicker18.Text = "";
            //dateTimePicker19.Text = "";
            //dateTimePicker20.Text = "";
            //dateTimePicker21.Text = "";
            //dateTimePicker22.Text = "";
            //dateTimePicker23.Text = "";
            //dateTimePicker24.Text = "";
            //dateTimePicker25.Text = "";
            //dateTimePicker26.Text = "";
            //dateTimePicker27.Text = "";
            //dateTimePicker28.Text = "";
            //dateTimePicker29.Text = "";
            //dateTimePicker30.Text = "";
            //dateTimePicker31.Text = "";
            //dateTimePicker32.Text = "";
            //dateTimePicker33.Text = "";
            //dateTimePicker34.Text = "";
            //dateTimePicker35.Text = "";
            //dateTimePicker36.Text = "";
            //dateTimePicker37.Text = "";
            //dateTimePicker38.Text = "";
            //dateTimePicker39.Text = "";
            //dateTimePicker40.Text = "";
            //dateTimePicker41.Text = "";
            //dateTimePicker42.Text = "";
            //dateTimePicker43.Text = "";
            //dateTimePicker44.Text = "";
            //dateTimePicker45.Text = "";
            //dateTimePicker46.Text = "";
            //dateTimePicker47.Text = "";
            //dateTimePicker48.Text = "";
            //dateTimePicker49.Text = "";
            //dateTimePicker50.Text = "";

        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            //try
            //{
            //    #region 排产

            //    shuaxin();

            //    string time1time = DateTime.Now.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //    string time1date1 = DateTime.Now.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                                            //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //    if (shebei1.Text.Trim() == "")
            //    {
            //        MessageBox.Show("请添加工序！", "提示");
            //        return;
            //    }


            //    if (shebei1.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei1.Text.Trim());//判断设备
            //        if (flagShebei == "24")
            //        {
            //            paichan1(time1time, time1date1, shebei1.Text.Trim(), txt_gx1.Text.Trim(), txt_shuliang1.Text.Trim(), dateTimePicker1, dateTimePicker2);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(time1time, time1date1, shebei1.Text.Trim(), txt_gx1.Text.Trim(), txt_shuliang1.Text.Trim(), dateTimePicker1, dateTimePicker2);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(time1time, time1date1, shebei1.Text.Trim(), txt_gx1.Text.Trim(), txt_shuliang1.Text.Trim(), dateTimePicker1, dateTimePicker2);
            //        }
            //    }

            //    if (shebei2.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei2.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker2.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei2.Text.Trim(), txt_gx2.Text.Trim(), txt_shuliang2.Text.Trim(), dateTimePicker3, dateTimePicker4);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei2.Text.Trim(), txt_gx2.Text.Trim(), txt_shuliang2.Text.Trim(), dateTimePicker3, dateTimePicker4);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei2.Text.Trim(), txt_gx2.Text.Trim(), txt_shuliang2.Text.Trim(), dateTimePicker3, dateTimePicker4);
            //        }

            //    }

            //    if (shebei3.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei3.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker4.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei3.Text.Trim(), txt_gx3.Text.Trim(), txt_shuliang3.Text.Trim(), dateTimePicker5, dateTimePicker6);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei3.Text.Trim(), txt_gx3.Text.Trim(), txt_shuliang3.Text.Trim(), dateTimePicker5, dateTimePicker6);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei3.Text.Trim(), txt_gx3.Text.Trim(), txt_shuliang3.Text.Trim(), dateTimePicker5, dateTimePicker6);
            //        }


            //    }

            //    if (shebei4.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei4.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker6.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei4.Text.Trim(), txt_gx4.Text.Trim(), txt_shuliang4.Text.Trim(), dateTimePicker7, dateTimePicker8);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei4.Text.Trim(), txt_gx4.Text.Trim(), txt_shuliang4.Text.Trim(), dateTimePicker7, dateTimePicker8);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei4.Text.Trim(), txt_gx4.Text.Trim(), txt_shuliang4.Text.Trim(), dateTimePicker7, dateTimePicker8);
            //        }

            //    }

            //    if (shebei5.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei5.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker8.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei5.Text.Trim(), txt_gx5.Text.Trim(), txt_shuliang5.Text.Trim(), dateTimePicker9, dateTimePicker10);
            //        }

            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei5.Text.Trim(), txt_gx5.Text.Trim(), txt_shuliang5.Text.Trim(), dateTimePicker9, dateTimePicker10);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei5.Text.Trim(), txt_gx5.Text.Trim(), txt_shuliang5.Text.Trim(), dateTimePicker9, dateTimePicker10);
            //        }

            //    }

            //    if (shebei6.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei6.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker10.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei6.Text.Trim(), txt_gx6.Text.Trim(), txt_shuliang6.Text.Trim(), dateTimePicker11, dateTimePicker12);
            //        }

            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei6.Text.Trim(), txt_gx6.Text.Trim(), txt_shuliang6.Text.Trim(), dateTimePicker11, dateTimePicker12);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei6.Text.Trim(), txt_gx6.Text.Trim(), txt_shuliang6.Text.Trim(), dateTimePicker11, dateTimePicker12);
            //        }

            //    }

            //    if (shebei7.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei7.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker12.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei7.Text.Trim(), txt_gx7.Text.Trim(), txt_shuliang7.Text.Trim(), dateTimePicker13, dateTimePicker14);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei7.Text.Trim(), txt_gx7.Text.Trim(), txt_shuliang7.Text.Trim(), dateTimePicker13, dateTimePicker14);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei7.Text.Trim(), txt_gx7.Text.Trim(), txt_shuliang7.Text.Trim(), dateTimePicker13, dateTimePicker14);
            //        }

            //    }

            //    if (shebei8.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei8.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker14.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei8.Text.Trim(), txt_gx8.Text.Trim(), txt_shuliang8.Text.Trim(), dateTimePicker15, dateTimePicker16);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei8.Text.Trim(), txt_gx8.Text.Trim(), txt_shuliang8.Text.Trim(), dateTimePicker15, dateTimePicker16);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei8.Text.Trim(), txt_gx8.Text.Trim(), txt_shuliang8.Text.Trim(), dateTimePicker15, dateTimePicker16);
            //        }

            //    }

            //    if (shebei9.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei9.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker16.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei9.Text.Trim(), txt_gx9.Text.Trim(), txt_shuliang9.Text.Trim(), dateTimePicker17, dateTimePicker18);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei9.Text.Trim(), txt_gx9.Text.Trim(), txt_shuliang9.Text.Trim(), dateTimePicker17, dateTimePicker18);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei9.Text.Trim(), txt_gx9.Text.Trim(), txt_shuliang9.Text.Trim(), dateTimePicker17, dateTimePicker18);
            //        }

            //    }

            //    if (shebei10.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei10.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker18.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei10.Text.Trim(), txt_gx10.Text.Trim(), txt_shuliang10.Text.Trim(), dateTimePicker19, dateTimePicker20);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei10.Text.Trim(), txt_gx10.Text.Trim(), txt_shuliang10.Text.Trim(), dateTimePicker19, dateTimePicker20);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei10.Text.Trim(), txt_gx10.Text.Trim(), txt_shuliang10.Text.Trim(), dateTimePicker19, dateTimePicker20);
            //        }

            //    }

            //    if (shebei11.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei11.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker20.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei11.Text.Trim(), txt_gx11.Text.Trim(), txt_shuliang11.Text.Trim(), dateTimePicker21, dateTimePicker22);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei11.Text.Trim(), txt_gx11.Text.Trim(), txt_shuliang11.Text.Trim(), dateTimePicker21, dateTimePicker22);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei11.Text.Trim(), txt_gx11.Text.Trim(), txt_shuliang11.Text.Trim(), dateTimePicker21, dateTimePicker22);
            //        }

            //    }

            //    if (shebei12.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei12.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker22.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei12.Text.Trim(), txt_gx12.Text.Trim(), txt_shuliang12.Text.Trim(), dateTimePicker23, dateTimePicker24);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei12.Text.Trim(), txt_gx12.Text.Trim(), txt_shuliang12.Text.Trim(), dateTimePicker23, dateTimePicker24);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei12.Text.Trim(), txt_gx12.Text.Trim(), txt_shuliang12.Text.Trim(), dateTimePicker23, dateTimePicker24);
            //        }

            //    }

            //    if (shebei13.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei13.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker24.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei13.Text.Trim(), txt_gx13.Text.Trim(), txt_shuliang13.Text.Trim(), dateTimePicker25, dateTimePicker26);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei13.Text.Trim(), txt_gx13.Text.Trim(), txt_shuliang13.Text.Trim(), dateTimePicker25, dateTimePicker26);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei13.Text.Trim(), txt_gx13.Text.Trim(), txt_shuliang13.Text.Trim(), dateTimePicker25, dateTimePicker26);
            //        }

            //    }

            //    if (shebei14.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei14.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker26.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei14.Text.Trim(), txt_gx14.Text.Trim(), txt_shuliang14.Text.Trim(), dateTimePicker27, dateTimePicker28);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei14.Text.Trim(), txt_gx14.Text.Trim(), txt_shuliang14.Text.Trim(), dateTimePicker27, dateTimePicker28);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei14.Text.Trim(), txt_gx14.Text.Trim(), txt_shuliang14.Text.Trim(), dateTimePicker27, dateTimePicker28);
            //        }

            //    }

            //    if (shebei15.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei15.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker28.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei15.Text.Trim(), txt_gx15.Text.Trim(), txt_shuliang15.Text.Trim(), dateTimePicker29, dateTimePicker30);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei15.Text.Trim(), txt_gx15.Text.Trim(), txt_shuliang15.Text.Trim(), dateTimePicker29, dateTimePicker30);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei15.Text.Trim(), txt_gx15.Text.Trim(), txt_shuliang15.Text.Trim(), dateTimePicker29, dateTimePicker30);
            //        }
            //    }

            //    if (shebei16.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei16.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker30.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei16.Text.Trim(), txt_gx16.Text.Trim(), txt_shuliang16.Text.Trim(), dateTimePicker31, dateTimePicker32);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei16.Text.Trim(), txt_gx16.Text.Trim(), txt_shuliang16.Text.Trim(), dateTimePicker31, dateTimePicker32);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei16.Text.Trim(), txt_gx16.Text.Trim(), txt_shuliang16.Text.Trim(), dateTimePicker31, dateTimePicker32);
            //        }

            //    }

            //    if (shebei17.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei17.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker32.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei17.Text.Trim(), txt_gx17.Text.Trim(), txt_shuliang17.Text.Trim(), dateTimePicker33, dateTimePicker34);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei17.Text.Trim(), txt_gx17.Text.Trim(), txt_shuliang17.Text.Trim(), dateTimePicker33, dateTimePicker34);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei17.Text.Trim(), txt_gx17.Text.Trim(), txt_shuliang17.Text.Trim(), dateTimePicker33, dateTimePicker34);
            //        }

            //    }

            //    if (shebei18.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei18.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker34.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei18.Text.Trim(), txt_gx18.Text.Trim(), txt_shuliang18.Text.Trim(), dateTimePicker35, dateTimePicker36);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei18.Text.Trim(), txt_gx18.Text.Trim(), txt_shuliang18.Text.Trim(), dateTimePicker35, dateTimePicker36);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei18.Text.Trim(), txt_gx18.Text.Trim(), txt_shuliang18.Text.Trim(), dateTimePicker35, dateTimePicker36);
            //        }

            //    }

            //    if (shebei19.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei19.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker36.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei19.Text.Trim(), txt_gx19.Text.Trim(), txt_shuliang19.Text.Trim(), dateTimePicker37, dateTimePicker38);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei19.Text.Trim(), txt_gx19.Text.Trim(), txt_shuliang19.Text.Trim(), dateTimePicker37, dateTimePicker38);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei19.Text.Trim(), txt_gx19.Text.Trim(), txt_shuliang19.Text.Trim(), dateTimePicker37, dateTimePicker38);
            //        }
            //    }

            //    if (shebei20.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei20.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker38.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei20.Text.Trim(), txt_gx20.Text.Trim(), txt_shuliang20.Text.Trim(), dateTimePicker39, dateTimePicker40);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei20.Text.Trim(), txt_gx20.Text.Trim(), txt_shuliang20.Text.Trim(), dateTimePicker39, dateTimePicker40);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei20.Text.Trim(), txt_gx20.Text.Trim(), txt_shuliang20.Text.Trim(), dateTimePicker39, dateTimePicker40);
            //        }

            //    }

            //    if (shebei21.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei21.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker40.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei21.Text.Trim(), txt_gx21.Text.Trim(), txt_shuliang21.Text.Trim(), dateTimePicker41, dateTimePicker42);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei21.Text.Trim(), txt_gx21.Text.Trim(), txt_shuliang21.Text.Trim(), dateTimePicker41, dateTimePicker42);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei21.Text.Trim(), txt_gx21.Text.Trim(), txt_shuliang21.Text.Trim(), dateTimePicker41, dateTimePicker42);
            //        }
            //    }

            //    if (shebei22.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei22.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker42.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei22.Text.Trim(), txt_gx22.Text.Trim(), txt_shuliang22.Text.Trim(), dateTimePicker43, dateTimePicker44);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei22.Text.Trim(), txt_gx22.Text.Trim(), txt_shuliang22.Text.Trim(), dateTimePicker43, dateTimePicker44);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei22.Text.Trim(), txt_gx22.Text.Trim(), txt_shuliang22.Text.Trim(), dateTimePicker43, dateTimePicker44);
            //        }
            //    }

            //    if (shebei23.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei23.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker44.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei23.Text.Trim(), txt_gx23.Text.Trim(), txt_shuliang23.Text.Trim(), dateTimePicker45, dateTimePicker46);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei23.Text.Trim(), txt_gx23.Text.Trim(), txt_shuliang23.Text.Trim(), dateTimePicker45, dateTimePicker46);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei23.Text.Trim(), txt_gx23.Text.Trim(), txt_shuliang23.Text.Trim(), dateTimePicker45, dateTimePicker46);
            //        }
            //    }

            //    if (shebei24.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei24.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker46.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei24.Text.Trim(), txt_gx24.Text.Trim(), txt_shuliang24.Text.Trim(), dateTimePicker47, dateTimePicker48);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei24.Text.Trim(), txt_gx24.Text.Trim(), txt_shuliang24.Text.Trim(), dateTimePicker47, dateTimePicker48);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei24.Text.Trim(), txt_gx24.Text.Trim(), txt_shuliang24.Text.Trim(), dateTimePicker47, dateTimePicker48);
            //        }
            //    }

            //    if (shebei25.Text.Trim() != "")
            //    {
            //        string flagShebei = panduanshebi(shebei25.Text.Trim());//判断设备

            //        DateTime da = dateTimePicker48.Value;
            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串

            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期
            //                                               //string str1 = time1.ToString("yyyy/MM/dd HH:mm");

            //        if (flagShebei == "24")
            //        {
            //            paichan1(da1, da2, shebei25.Text.Trim(), txt_gx25.Text.Trim(), txt_shuliang25.Text.Trim(), dateTimePicker49, dateTimePicker50);
            //        }
            //        if (flagShebei == "8")
            //        {
            //            paichan(da1, da2, shebei25.Text.Trim(), txt_gx25.Text.Trim(), txt_shuliang25.Text.Trim(), dateTimePicker49, dateTimePicker50);
            //        }
            //        if (flagShebei == "12")
            //        {
            //            paichan2(da1, da2, shebei25.Text.Trim(), txt_gx25.Text.Trim(), txt_shuliang25.Text.Trim(), dateTimePicker49, dateTimePicker50);
            //        }
            //    }
            //    #endregion
            //}
            //catch
            //{
            //    MessageBox.Show("请检查价格、数量是否输入完全", "提示");
            //}

            

        }

        private void btn_Print_Click_1(object sender, EventArgs e)
        {
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = printDocument1;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch
                {   //停止打印
                    printDocument1.PrintController.OnEndPrint(printDocument1, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            cailiaozhongliang form = new cailiaozhongliang();
            form.gx1 = comboBox1.Text.Trim();
            form.gx2 = comboBox2.Text.Trim();
            form.gx3 = comboBox3.Text.Trim();
            form.gx4 = comboBox4.Text.Trim();
            form.gx5 = comboBox5.Text.Trim();
            form.gx6 = comboBox6.Text.Trim();
            form.gx7 = comboBox7.Text.Trim();
            form.gx8 = comboBox8.Text.Trim();
            form.gx9 = comboBox9.Text.Trim();
            form.gx10 = comboBox10.Text.Trim();
            form.gx11 = comboBox11.Text.Trim();
            form.gx12 = comboBox12.Text.Trim();
            form.gx13 = comboBox13.Text.Trim();
            form.gx14 = comboBox14.Text.Trim();
            form.gx15 = comboBox15.Text.Trim();
            form.gx16 = comboBox16.Text.Trim();
            form.gx17 = comboBox17.Text.Trim();
            form.gx18 = comboBox18.Text.Trim();
            form.gx19 = comboBox19.Text.Trim();
            form.gx20 = comboBox20.Text.Trim();
            form.gx21 = comboBox46.Text.Trim();
            form.gx22 = comboBox47.Text.Trim();
            form.gx23 = comboBox48.Text.Trim();
            form.gx24 = comboBox49.Text.Trim();
            form.gx25 = comboBox50.Text.Trim();

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                //textBox14.Text = form.cailiao1;
                //textBox34.Text = form.zhongliang1;
                //textBox7.Text = form.cailiao2;
                //textBox27.Text = form.zhongliang2;
                //textBox10.Text = form.cailiao3;
                //textBox30.Text = form.zhongliang3;
                //textBox3.Text = form.cailiao4;
                //textBox2.Text = form.zhongliang4;
                //txt_cailiao5.Text = form.cailiao5;
                //txt_zhongliang5.Text = form.zhongliang5;
                //txt_cailiao6.Text = form.zhongliang6;
                //txt_zhongliang6.Text = form.zhongliang6;
                //txt_cailiao7.Text = form.cailiao7;
                //txt_zhongliang7.Text = form.zhongliang7;
                //txt_cailiao8.Text = form.cailiao8;
                //txt_zhongliang8.Text = form.zhongliang8;
                //txt_cailiao9.Text = form.cailiao9;
                //txt_zhongliang9.Text = form.zhongliang9;
                //txt_cailiao10.Text = form.cailiao10;
                //txt_zhongliang10.Text = form.zhongliang10;
            }
        }

        private void btn_Gongyika_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请添加工序！", "提示");
                return;
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("请添加工序内容！", "提示");
                return;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("产品名称", typeof(string));
            dt.Columns.Add("零件名称", typeof(string));
            dt.Columns.Add("零件图号", typeof(string));
            dt.Columns.Add("下单日期", typeof(string));
            dt.Columns.Add("交货日", typeof(string));
            dt.Columns.Add("工令号", typeof(string));
            dt.Columns.Add("材质", typeof(string));

            dt.Columns.Add("序号1", typeof(string));
            dt.Columns.Add("序号2", typeof(string));
            dt.Columns.Add("序号3", typeof(string));
            dt.Columns.Add("序号4", typeof(string));
            dt.Columns.Add("序号5", typeof(string));
            dt.Columns.Add("序号6", typeof(string));
            dt.Columns.Add("序号7", typeof(string));
            dt.Columns.Add("序号8", typeof(string));
            dt.Columns.Add("序号9", typeof(string));
            dt.Columns.Add("序号10", typeof(string));
            dt.Columns.Add("序号11", typeof(string));
            dt.Columns.Add("序号12", typeof(string));
            dt.Columns.Add("序号13", typeof(string));
            dt.Columns.Add("序号14", typeof(string));
            dt.Columns.Add("序号15", typeof(string));
            dt.Columns.Add("序号16", typeof(string));
            dt.Columns.Add("序号17", typeof(string));
            dt.Columns.Add("序号18", typeof(string));
            dt.Columns.Add("序号19", typeof(string));
            dt.Columns.Add("序号20", typeof(string));
            dt.Columns.Add("序号21", typeof(string));
            dt.Columns.Add("序号22", typeof(string));
            dt.Columns.Add("序号23", typeof(string));
            dt.Columns.Add("序号24", typeof(string));
            dt.Columns.Add("序号25", typeof(string));

            dt.Columns.Add("工序1", typeof(string));
            dt.Columns.Add("工序2", typeof(string));
            dt.Columns.Add("工序3", typeof(string));
            dt.Columns.Add("工序4", typeof(string));
            dt.Columns.Add("工序5", typeof(string));
            dt.Columns.Add("工序6", typeof(string));
            dt.Columns.Add("工序7", typeof(string));
            dt.Columns.Add("工序8", typeof(string));
            dt.Columns.Add("工序9", typeof(string));
            dt.Columns.Add("工序10", typeof(string));
            dt.Columns.Add("工序11", typeof(string));
            dt.Columns.Add("工序12", typeof(string));
            dt.Columns.Add("工序13", typeof(string));
            dt.Columns.Add("工序14", typeof(string));
            dt.Columns.Add("工序15", typeof(string));
            dt.Columns.Add("工序16", typeof(string));
            dt.Columns.Add("工序17", typeof(string));
            dt.Columns.Add("工序18", typeof(string));
            dt.Columns.Add("工序19", typeof(string));
            dt.Columns.Add("工序20", typeof(string));
            dt.Columns.Add("工序21", typeof(string));
            dt.Columns.Add("工序22", typeof(string));
            dt.Columns.Add("工序23", typeof(string));
            dt.Columns.Add("工序24", typeof(string));
            dt.Columns.Add("工序25", typeof(string));

            dt.Columns.Add("内容1", typeof(string));
            dt.Columns.Add("内容2", typeof(string));
            dt.Columns.Add("内容3", typeof(string));
            dt.Columns.Add("内容4", typeof(string));
            dt.Columns.Add("内容5", typeof(string));
            dt.Columns.Add("内容6", typeof(string));
            dt.Columns.Add("内容7", typeof(string));
            dt.Columns.Add("内容8", typeof(string));
            dt.Columns.Add("内容9", typeof(string));
            dt.Columns.Add("内容10", typeof(string));
            dt.Columns.Add("内容11", typeof(string));
            dt.Columns.Add("内容12", typeof(string));
            dt.Columns.Add("内容13", typeof(string));
            dt.Columns.Add("内容14", typeof(string));
            dt.Columns.Add("内容15", typeof(string));
            dt.Columns.Add("内容16", typeof(string));
            dt.Columns.Add("内容17", typeof(string));
            dt.Columns.Add("内容18", typeof(string));
            dt.Columns.Add("内容19", typeof(string));
            dt.Columns.Add("内容20", typeof(string));
            dt.Columns.Add("内容21", typeof(string));
            dt.Columns.Add("内容22", typeof(string));
            dt.Columns.Add("内容23", typeof(string));
            dt.Columns.Add("内容24", typeof(string));
            dt.Columns.Add("内容25", typeof(string));

            dt.Columns.Add("负责人1", typeof(string));
            dt.Columns.Add("负责人2", typeof(string));
            dt.Columns.Add("负责人3", typeof(string));
            dt.Columns.Add("负责人4", typeof(string));
            dt.Columns.Add("负责人5", typeof(string));
            dt.Columns.Add("负责人6", typeof(string));
            dt.Columns.Add("负责人7", typeof(string));
            dt.Columns.Add("负责人8", typeof(string));
            dt.Columns.Add("负责人9", typeof(string));
            dt.Columns.Add("负责人10", typeof(string));
            dt.Columns.Add("负责人11", typeof(string));
            dt.Columns.Add("负责人12", typeof(string));
            dt.Columns.Add("负责人13", typeof(string));
            dt.Columns.Add("负责人14", typeof(string));
            dt.Columns.Add("负责人15", typeof(string));
            dt.Columns.Add("负责人16", typeof(string));
            dt.Columns.Add("负责人17", typeof(string));
            dt.Columns.Add("负责人18", typeof(string));
            dt.Columns.Add("负责人19", typeof(string));
            dt.Columns.Add("负责人20", typeof(string));
            dt.Columns.Add("负责人21", typeof(string));
            dt.Columns.Add("负责人22", typeof(string));
            dt.Columns.Add("负责人23", typeof(string));
            dt.Columns.Add("负责人24", typeof(string));
            dt.Columns.Add("负责人25", typeof(string));

            dt.Columns.Add("价格1", typeof(string));
            dt.Columns.Add("价格2", typeof(string));
            dt.Columns.Add("价格3", typeof(string));
            dt.Columns.Add("价格4", typeof(string));
            dt.Columns.Add("价格5", typeof(string));
            dt.Columns.Add("价格6", typeof(string));
            dt.Columns.Add("价格7", typeof(string));
            dt.Columns.Add("价格8", typeof(string));
            dt.Columns.Add("价格9", typeof(string));
            dt.Columns.Add("价格10", typeof(string));
            dt.Columns.Add("价格11", typeof(string));
            dt.Columns.Add("价格12", typeof(string));
            dt.Columns.Add("价格13", typeof(string));
            dt.Columns.Add("价格14", typeof(string));
            dt.Columns.Add("价格15", typeof(string));
            dt.Columns.Add("价格16", typeof(string));
            dt.Columns.Add("价格17", typeof(string));
            dt.Columns.Add("价格18", typeof(string));
            dt.Columns.Add("价格19", typeof(string));
            dt.Columns.Add("价格20", typeof(string));
            dt.Columns.Add("价格21", typeof(string));
            dt.Columns.Add("价格22", typeof(string));
            dt.Columns.Add("价格23", typeof(string));
            dt.Columns.Add("价格24", typeof(string));
            dt.Columns.Add("价格25", typeof(string));

            dt.Columns.Add("数量1", typeof(string));
            dt.Columns.Add("数量2", typeof(string));
            dt.Columns.Add("数量3", typeof(string));
            dt.Columns.Add("数量4", typeof(string));
            dt.Columns.Add("数量5", typeof(string));
            dt.Columns.Add("数量6", typeof(string));
            dt.Columns.Add("数量7", typeof(string));
            dt.Columns.Add("数量8", typeof(string));
            dt.Columns.Add("数量9", typeof(string));
            dt.Columns.Add("数量10", typeof(string));
            dt.Columns.Add("数量11", typeof(string));
            dt.Columns.Add("数量12", typeof(string));
            dt.Columns.Add("数量13", typeof(string));
            dt.Columns.Add("数量14", typeof(string));
            dt.Columns.Add("数量15", typeof(string));
            dt.Columns.Add("数量16", typeof(string));
            dt.Columns.Add("数量17", typeof(string));
            dt.Columns.Add("数量18", typeof(string));
            dt.Columns.Add("数量19", typeof(string));
            dt.Columns.Add("数量20", typeof(string));
            dt.Columns.Add("数量21", typeof(string));
            dt.Columns.Add("数量22", typeof(string));
            dt.Columns.Add("数量23", typeof(string));
            dt.Columns.Add("数量24", typeof(string));
            dt.Columns.Add("数量25", typeof(string));

            dt.Columns.Add("工艺1", typeof(string));
            dt.Columns.Add("工艺2", typeof(string));
            dt.Columns.Add("工艺3", typeof(string));
            dt.Columns.Add("工艺4", typeof(string));
            dt.Columns.Add("工艺5", typeof(string));
            dt.Columns.Add("工艺6", typeof(string));
            dt.Columns.Add("工艺7", typeof(string));
            dt.Columns.Add("工艺8", typeof(string));
            dt.Columns.Add("工艺9", typeof(string));
            dt.Columns.Add("工艺10", typeof(string));
            dt.Columns.Add("工艺11", typeof(string));
            dt.Columns.Add("工艺12", typeof(string));
            dt.Columns.Add("工艺13", typeof(string));
            dt.Columns.Add("工艺14", typeof(string));
            dt.Columns.Add("工艺15", typeof(string));
            dt.Columns.Add("工艺16", typeof(string));
            dt.Columns.Add("工艺17", typeof(string));
            dt.Columns.Add("工艺18", typeof(string));
            dt.Columns.Add("工艺19", typeof(string));
            dt.Columns.Add("工艺20", typeof(string));
            dt.Columns.Add("工艺21", typeof(string));
            dt.Columns.Add("工艺22", typeof(string));
            dt.Columns.Add("工艺23", typeof(string));
            dt.Columns.Add("工艺24", typeof(string));
            dt.Columns.Add("工艺25", typeof(string));

            dt.Columns.Add("编制人日期", typeof(string));
            dt.Columns.Add("PHOTO", typeof(Image));

            DataRow dr = dt.NewRow();

            //if (textBox14.Text.Trim() == "")
            //{
            //    s1 = "";
            //}
            //else
            //{
            //    s1 = "①" + textBox14.Text.Trim();
            //}
            //if (textBox7.Text.Trim() == "")
            //{
            //    s2 = "";
            //}
            //else
            //{
            //    s2 = " ②" + textBox7.Text.Trim() + "\r\n";
            //}
            //if (textBox10.Text.Trim() == "")
            //{
            //    s3 = "";
            //}
            //else
            //{
            //    s3 = " ③" + textBox10.Text.Trim();
            //}
            //if (textBox3.Text.Trim() == "")
            //{
            //    s4 = "";
            //}
            //else
            //{
            //    s4 = " ④" + textBox3.Text.Trim() + "\r\n";
            //}
            //if (txt_cailiao5.Text.Trim() == "")
            //{
            //    s5 = "";
            //}
            //else
            //{
            //    s5 = " ⑤" + txt_cailiao5.Text.Trim();
            //}
            //if (txt_cailiao6.Text.Trim() == "")
            //{
            //    s6 = "";
            //}
            //else
            //{
            //    s6 = " ⑥" + txt_cailiao6.Text.Trim() + "\r\n";
            //}
            //if (txt_cailiao7.Text.Trim() == "")
            //{
            //    s7 = "";
            //}
            //else
            //{
            //    s7 = " ⑦" + txt_cailiao7.Text.Trim();
            //}
            //if (txt_cailiao8.Text.Trim() == "")
            //{
            //    s8 = "";
            //}
            //else
            //{
            //    s8 = " ⑧" + txt_cailiao8.Text.Trim() + "\r\n";
            //}
            //if (txt_cailiao9.Text.Trim() == "")
            //{
            //    s9 = "";
            //}
            //else
            //{
            //    s9 = " ⑨" + txt_cailiao9.Text.Trim();
            //}
            //if (txt_cailiao10.Text.Trim() == "")
            //{
            //    s10 = "";
            //}
            //else
            //{
            //    s10 = " ⑩" + txt_cailiao10.Text.Trim();
            //}

            dr["产品名称"] = txt_jiagong.Text + txt_danhao.Text;
            dr["零件名称"] = txt_mingcheng.Text;
            dr["零件图号"] = txt_tuhao.Text;
            dr["下单日期"] = txt_xiadanriqi.Text;
            dr["交货日"] = txt_jiaohuoriqi.Text;
            dr["工令号"] = txt_gonglinghao.Text;
            dr["材质"] = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10;

            if (comboBox1.Text.Trim() != "")
            {
                dr["序号1"] = "1";
                dr["工序1"] = comboBox1.Text.Trim();
                dr["内容1"] = richTextBox1.Text;
                dr["负责人1"] = comboBox21.Text;
                dr["价格1"] = txt_gx1.Text;
                dr["工艺1"] = richTextBox27.Text;
                dr["数量1"] = txt_shuliang1.Text;
            }
            if (comboBox2.Text.Trim() != "")
            {
                dr["序号2"] = "2";
                dr["工序2"] = comboBox2.Text.Trim();
                dr["内容2"] = richTextBox2.Text;
                dr["负责人2"] = comboBox22.Text;
                dr["价格2"] = txt_gx2.Text;
                dr["工艺2"] = richTextBox28.Text;
                dr["数量2"] = txt_shuliang2.Text;
            }
            if (comboBox3.Text.Trim() != "")
            {
                dr["序号3"] = "3";
                dr["工序3"] = comboBox3.Text.Trim();
                dr["内容3"] = richTextBox3.Text;
                dr["负责人3"] = comboBox23.Text;
                dr["价格3"] = txt_gx3.Text;
                dr["工艺3"] = richTextBox29.Text;
                dr["数量3"] = txt_shuliang3.Text;
            }
            if (comboBox4.Text.Trim() != "")
            {
                dr["序号4"] = "4";
                dr["工序4"] = comboBox4.Text.Trim();
                dr["内容4"] = richTextBox4.Text;
                dr["负责人4"] = comboBox24.Text;
                dr["价格4"] = txt_gx4.Text;
                dr["工艺4"] = richTextBox30.Text;
                dr["数量4"] = txt_shuliang4.Text;
            }
            if (comboBox5.Text.Trim() != "")
            {
                dr["序号5"] = "5";
                dr["工序5"] = comboBox5.Text.Trim();
                dr["内容5"] = richTextBox5.Text;
                dr["负责人5"] = comboBox25.Text;
                dr["价格5"] = txt_gx5.Text;
                dr["工艺5"] = richTextBox31.Text;
                dr["数量5"] = txt_shuliang5.Text;
            }
            if (comboBox6.Text.Trim() != "")
            {
                dr["序号6"] = "6";
                dr["工序6"] = comboBox6.Text.Trim();
                dr["内容6"] = richTextBox6.Text;
                dr["负责人6"] = comboBox26.Text;
                dr["价格6"] = txt_gx6.Text;
                dr["工艺6"] = richTextBox32.Text;
                dr["数量6"] = txt_shuliang6.Text;
            }
            if (comboBox7.Text.Trim() != "")
            {
                dr["序号7"] = "7";
                dr["工序7"] = comboBox7.Text.Trim();
                dr["内容7"] = richTextBox7.Text;
                dr["负责人7"] = comboBox27.Text;
                dr["价格7"] = txt_gx7.Text;
                dr["工艺7"] = richTextBox33.Text;
                dr["数量7"] = txt_shuliang7.Text;
            }
            if (comboBox8.Text.Trim() != "")
            {
                dr["序号8"] = "8";
                dr["工序8"] = comboBox8.Text.Trim();
                dr["内容8"] = richTextBox8.Text;
                dr["负责人8"] = comboBox28.Text;
                dr["价格8"] = txt_gx8.Text;
                dr["工艺8"] = richTextBox34.Text;
                dr["数量8"] = txt_shuliang8.Text;
            }
            if (comboBox9.Text.Trim() != "")
            {
                dr["序号9"] = "9";
                dr["工序9"] = comboBox9.Text.Trim();
                dr["内容9"] = richTextBox9.Text;
                dr["负责人9"] = comboBox29.Text;
                dr["价格9"] = txt_gx9.Text;
                dr["工艺9"] = richTextBox35.Text;
                dr["数量9"] = txt_shuliang9.Text;
            }
            if (comboBox10.Text.Trim() != "")
            {
                dr["序号10"] = "10";
                dr["工序10"] = comboBox10.Text.Trim();
                dr["内容10"] = richTextBox10.Text;
                dr["负责人10"] = comboBox30.Text;
                dr["价格10"] = txt_gx10.Text;
                dr["工艺10"] = richTextBox36.Text;
                dr["数量10"] = txt_shuliang10.Text;
            }
            if (comboBox11.Text.Trim() != "")
            {
                dr["序号11"] = "11";
                dr["工序11"] = comboBox11.Text.Trim();
                dr["内容11"] = richTextBox11.Text;
                dr["负责人11"] = comboBox31.Text;
                dr["价格11"] = txt_gx11.Text;
                dr["工艺11"] = richTextBox37.Text;
                dr["数量11"] = txt_shuliang11.Text;
            }
            if (comboBox12.Text.Trim() != "")
            {
                dr["序号12"] = "12";
                dr["工序12"] = comboBox12.Text.Trim();
                dr["内容12"] = richTextBox12.Text;
                dr["负责人12"] = comboBox32.Text;
                dr["价格12"] = txt_gx12.Text;
                dr["工艺12"] = richTextBox38.Text;
                dr["数量12"] = txt_shuliang12.Text;
            }
            if (comboBox13.Text.Trim() != "")
            {
                dr["序号13"] = "13";
                dr["工序13"] = comboBox13.Text.Trim();
                dr["内容13"] = richTextBox13.Text;
                dr["负责人13"] = comboBox33.Text;
                dr["价格13"] = txt_gx13.Text;
                dr["工艺13"] = richTextBox39.Text;
                dr["数量13"] = txt_shuliang13.Text;
            }
            if (comboBox14.Text.Trim() != "")
            {
                dr["序号14"] = "14";
                dr["工序14"] = comboBox14.Text.Trim();
                dr["内容14"] = richTextBox14.Text;
                dr["负责人14"] = comboBox34.Text;
                dr["价格14"] = txt_gx14.Text;
                dr["工艺14"] = richTextBox40.Text;
                dr["数量14"] = txt_shuliang14.Text;
            }
            if (comboBox15.Text.Trim() != "")
            {
                dr["序号15"] = "15";
                dr["工序15"] = comboBox15.Text.Trim();
                dr["内容15"] = richTextBox15.Text;
                dr["负责人15"] = comboBox35.Text;
                dr["价格15"] = txt_gx15.Text;
                dr["工艺15"] = richTextBox41.Text;
                dr["数量15"] = txt_shuliang15.Text;
            }
            if (comboBox16.Text.Trim() != "")
            {
                dr["序号16"] = "16";
                dr["工序16"] = comboBox16.Text.Trim();
                dr["内容16"] = richTextBox16.Text;
                dr["负责人16"] = comboBox36.Text;
                dr["价格16"] = txt_gx16.Text;
                dr["工艺16"] = richTextBox42.Text;
                dr["数量16"] = txt_shuliang16.Text;
            }
            if (comboBox17.Text.Trim() != "")
            {
                dr["序号17"] = "17";
                dr["工序17"] = comboBox17.Text.Trim();
                dr["内容17"] = richTextBox17.Text;
                dr["负责人17"] = comboBox37.Text;
                dr["价格17"] = txt_gx17.Text;
                dr["工艺17"] = richTextBox43.Text;
                dr["数量17"] = txt_shuliang17.Text;
            }
            if (comboBox18.Text.Trim() != "")
            {
                dr["序号18"] = "18";
                dr["工序18"] = comboBox18.Text.Trim();
                dr["内容18"] = richTextBox18.Text;
                dr["负责人18"] = comboBox38.Text;
                dr["价格18"] = txt_gx18.Text;
                dr["工艺18"] = richTextBox44.Text;
                dr["数量18"] = txt_shuliang18.Text;
            }
            if (comboBox19.Text.Trim() != "")
            {
                dr["序号19"] = "19";
                dr["工序19"] = comboBox19.Text.Trim();
                dr["内容19"] = richTextBox19.Text;
                dr["负责人19"] = comboBox39.Text;
                dr["价格19"] = txt_gx19.Text;
                dr["工艺19"] = richTextBox45.Text;
                dr["数量19"] = txt_shuliang19.Text;
            }
            if (comboBox20.Text.Trim() != "")
            {
                dr["序号20"] = "20";
                dr["工序20"] = comboBox20.Text.Trim();
                dr["内容20"] = richTextBox20.Text;
                dr["负责人20"] = comboBox40.Text;
                dr["价格20"] = txt_gx20.Text;
                dr["工艺20"] = richTextBox46.Text;
                dr["数量20"] = txt_shuliang20.Text;
            }
            if (comboBox21.Text.Trim() != "")
            {
                dr["序号21"] = "21";
                dr["工序21"] = comboBox21.Text.Trim();
                dr["内容21"] = richTextBox22.Text;
                dr["负责人21"] = comboBox41.Text;
                dr["价格21"] = txt_gx21.Text;
                dr["工艺21"] = richTextBox47.Text;
                dr["数量21"] = txt_shuliang21.Text;
            }
            if (comboBox22.Text.Trim() != "")
            {
                dr["序号22"] = "22";
                dr["工序22"] = comboBox22.Text.Trim();
                dr["内容22"] = richTextBox23.Text;
                dr["负责人22"] = comboBox42.Text;
                dr["价格22"] = txt_gx22.Text;
                dr["工艺22"] = richTextBox48.Text;
                dr["数量22"] = txt_shuliang22.Text;
            }
            if (comboBox23.Text.Trim() != "")
            {
                dr["序号23"] = "23";
                dr["工序23"] = comboBox23.Text.Trim();
                dr["内容23"] = richTextBox24.Text;
                dr["负责人23"] = comboBox43.Text;
                dr["价格23"] = txt_gx23.Text;
                dr["工艺23"] = richTextBox49.Text;
                dr["数量23"] = txt_shuliang23.Text;
            }
            if (comboBox24.Text.Trim() != "")
            {
                dr["序号24"] = "24";
                dr["工序24"] = comboBox24.Text.Trim();
                dr["内容24"] = richTextBox25.Text;
                dr["负责人24"] = comboBox44.Text;
                dr["价格24"] = txt_gx24.Text;
                dr["工艺24"] = richTextBox50.Text;
                dr["数量24"] = txt_shuliang24.Text;
            }
            if (comboBox25.Text.Trim() != "")
            {
                dr["序号25"] = "25";
                dr["工序25"] = comboBox25.Text.Trim();
                dr["内容25"] = richTextBox26.Text;
                dr["负责人25"] = comboBox45.Text;
                dr["价格25"] = txt_gx25.Text;
                dr["工艺25"] = richTextBox51.Text;
                dr["数量25"] = txt_shuliang25.Text;
            }

            string time1 = DateTime.Now.ToString("yyyy.MM.dd");
            dr["编制人日期"] = com_bianzhiren.Text.Trim() + time1;

            dt.Rows.Add(dr);

            string tempFile = Application.StartupPath + "\\工艺卡模板新.doc";

            //string tempFile = "../../bin/resouce/工艺卡模板新.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            image = pictureBox1.Image;

            builder.MoveToBookmark("PHOTO");
            builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 65, 65, WrapType.Square);


            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr1 = dt.Rows[0];

            dic.Add("产品名称", dr["产品名称"].ToString());
            dic.Add("零件名称", dr["零件名称"].ToString());
            dic.Add("零件图号", dr["零件图号"].ToString());
            dic.Add("下单日期", dr["下单日期"].ToString());
            dic.Add("交货日", dr["交货日"].ToString());
            dic.Add("工令号", dr["工令号"].ToString());
            dic.Add("材质", dr["材质"].ToString());

            dic.Add("序号1", dr["序号1"].ToString());
            dic.Add("序号2", dr["序号2"].ToString());
            dic.Add("序号3", dr["序号3"].ToString());
            dic.Add("序号4", dr["序号4"].ToString());
            dic.Add("序号5", dr["序号5"].ToString());
            dic.Add("序号6", dr["序号6"].ToString());
            dic.Add("序号7", dr["序号7"].ToString());
            dic.Add("序号8", dr["序号8"].ToString());
            dic.Add("序号9", dr["序号9"].ToString());
            dic.Add("序号10", dr["序号10"].ToString());
            dic.Add("序号11", dr["序号11"].ToString());
            dic.Add("序号12", dr["序号12"].ToString());
            dic.Add("序号13", dr["序号13"].ToString());
            dic.Add("序号14", dr["序号14"].ToString());
            dic.Add("序号15", dr["序号15"].ToString());
            dic.Add("序号16", dr["序号16"].ToString());
            dic.Add("序号17", dr["序号17"].ToString());
            dic.Add("序号18", dr["序号18"].ToString());
            dic.Add("序号19", dr["序号19"].ToString());
            dic.Add("序号20", dr["序号20"].ToString());
            dic.Add("序号21", dr["序号21"].ToString());
            dic.Add("序号22", dr["序号22"].ToString());
            dic.Add("序号23", dr["序号23"].ToString());
            dic.Add("序号24", dr["序号24"].ToString());
            dic.Add("序号25", dr["序号25"].ToString());

            dic.Add("工序1", dr["工序1"].ToString());
            dic.Add("工序2", dr["工序2"].ToString());
            dic.Add("工序3", dr["工序3"].ToString());
            dic.Add("工序4", dr["工序4"].ToString());
            dic.Add("工序5", dr["工序5"].ToString());
            dic.Add("工序6", dr["工序6"].ToString());
            dic.Add("工序7", dr["工序7"].ToString());
            dic.Add("工序8", dr["工序8"].ToString());
            dic.Add("工序9", dr["工序9"].ToString());
            dic.Add("工序10", dr["工序10"].ToString());
            dic.Add("工序11", dr["工序11"].ToString());
            dic.Add("工序12", dr["工序12"].ToString());
            dic.Add("工序13", dr["工序13"].ToString());
            dic.Add("工序14", dr["工序14"].ToString());
            dic.Add("工序15", dr["工序15"].ToString());
            dic.Add("工序16", dr["工序16"].ToString());
            dic.Add("工序17", dr["工序17"].ToString());
            dic.Add("工序18", dr["工序18"].ToString());
            dic.Add("工序19", dr["工序19"].ToString());
            dic.Add("工序20", dr["工序20"].ToString());
            dic.Add("工序21", dr["工序21"].ToString());
            dic.Add("工序22", dr["工序22"].ToString());
            dic.Add("工序23", dr["工序23"].ToString());
            dic.Add("工序24", dr["工序24"].ToString());
            dic.Add("工序25", dr["工序25"].ToString());

            dic.Add("内容1", dr["内容1"].ToString());
            dic.Add("内容2", dr["内容2"].ToString());
            dic.Add("内容3", dr["内容3"].ToString());
            dic.Add("内容4", dr["内容4"].ToString());
            dic.Add("内容5", dr["内容5"].ToString());
            dic.Add("内容6", dr["内容6"].ToString());
            dic.Add("内容7", dr["内容7"].ToString());
            dic.Add("内容8", dr["内容8"].ToString());
            dic.Add("内容9", dr["内容9"].ToString());
            dic.Add("内容10", dr["内容10"].ToString());
            dic.Add("内容11", dr["内容11"].ToString());
            dic.Add("内容12", dr["内容12"].ToString());
            dic.Add("内容13", dr["内容13"].ToString());
            dic.Add("内容14", dr["内容14"].ToString());
            dic.Add("内容15", dr["内容15"].ToString());
            dic.Add("内容16", dr["内容16"].ToString());
            dic.Add("内容17", dr["内容17"].ToString());
            dic.Add("内容18", dr["内容18"].ToString());
            dic.Add("内容19", dr["内容19"].ToString());
            dic.Add("内容20", dr["内容20"].ToString());
            dic.Add("内容21", dr["内容21"].ToString());
            dic.Add("内容22", dr["内容22"].ToString());
            dic.Add("内容23", dr["内容23"].ToString());
            dic.Add("内容24", dr["内容24"].ToString());
            dic.Add("内容25", dr["内容25"].ToString());

            dic.Add("负责人1", dr["负责人1"].ToString());
            dic.Add("负责人2", dr["负责人2"].ToString());
            dic.Add("负责人3", dr["负责人3"].ToString());
            dic.Add("负责人4", dr["负责人4"].ToString());
            dic.Add("负责人5", dr["负责人5"].ToString());
            dic.Add("负责人6", dr["负责人6"].ToString());
            dic.Add("负责人7", dr["负责人7"].ToString());
            dic.Add("负责人8", dr["负责人8"].ToString());
            dic.Add("负责人9", dr["负责人9"].ToString());
            dic.Add("负责人10", dr["负责人10"].ToString());
            dic.Add("负责人11", dr["负责人11"].ToString());
            dic.Add("负责人12", dr["负责人12"].ToString());
            dic.Add("负责人13", dr["负责人13"].ToString());
            dic.Add("负责人14", dr["负责人14"].ToString());
            dic.Add("负责人15", dr["负责人15"].ToString());
            dic.Add("负责人16", dr["负责人16"].ToString());
            dic.Add("负责人17", dr["负责人17"].ToString());
            dic.Add("负责人18", dr["负责人18"].ToString());
            dic.Add("负责人19", dr["负责人19"].ToString());
            dic.Add("负责人20", dr["负责人20"].ToString());
            dic.Add("负责人21", dr["负责人21"].ToString());
            dic.Add("负责人22", dr["负责人22"].ToString());
            dic.Add("负责人23", dr["负责人23"].ToString());
            dic.Add("负责人24", dr["负责人24"].ToString());
            dic.Add("负责人25", dr["负责人25"].ToString());

            dic.Add("价格1", dr["价格1"].ToString());
            dic.Add("价格2", dr["价格2"].ToString());
            dic.Add("价格3", dr["价格3"].ToString());
            dic.Add("价格4", dr["价格4"].ToString());
            dic.Add("价格5", dr["价格5"].ToString());
            dic.Add("价格6", dr["价格6"].ToString());
            dic.Add("价格7", dr["价格7"].ToString());
            dic.Add("价格8", dr["价格8"].ToString());
            dic.Add("价格9", dr["价格9"].ToString());
            dic.Add("价格10", dr["价格10"].ToString());
            dic.Add("价格11", dr["价格11"].ToString());
            dic.Add("价格12", dr["价格12"].ToString());
            dic.Add("价格13", dr["价格13"].ToString());
            dic.Add("价格14", dr["价格14"].ToString());
            dic.Add("价格15", dr["价格15"].ToString());
            dic.Add("价格16", dr["价格16"].ToString());
            dic.Add("价格17", dr["价格17"].ToString());
            dic.Add("价格18", dr["价格18"].ToString());
            dic.Add("价格19", dr["价格19"].ToString());
            dic.Add("价格20", dr["价格20"].ToString());
            dic.Add("价格21", dr["价格21"].ToString());
            dic.Add("价格22", dr["价格22"].ToString());
            dic.Add("价格23", dr["价格23"].ToString());
            dic.Add("价格24", dr["价格24"].ToString());
            dic.Add("价格25", dr["价格25"].ToString());

            dic.Add("数量1", dr["数量1"].ToString());
            dic.Add("数量2", dr["数量2"].ToString());
            dic.Add("数量3", dr["数量3"].ToString());
            dic.Add("数量4", dr["数量4"].ToString());
            dic.Add("数量5", dr["数量5"].ToString());
            dic.Add("数量6", dr["数量6"].ToString());
            dic.Add("数量7", dr["数量7"].ToString());
            dic.Add("数量8", dr["数量8"].ToString());
            dic.Add("数量9", dr["数量9"].ToString());
            dic.Add("数量10", dr["数量10"].ToString());
            dic.Add("数量11", dr["数量11"].ToString());
            dic.Add("数量12", dr["数量12"].ToString());
            dic.Add("数量13", dr["数量13"].ToString());
            dic.Add("数量14", dr["数量14"].ToString());
            dic.Add("数量15", dr["数量15"].ToString());
            dic.Add("数量16", dr["数量16"].ToString());
            dic.Add("数量17", dr["数量17"].ToString());
            dic.Add("数量18", dr["数量18"].ToString());
            dic.Add("数量19", dr["数量19"].ToString());
            dic.Add("数量20", dr["数量20"].ToString());
            dic.Add("数量21", dr["数量21"].ToString());
            dic.Add("数量22", dr["数量22"].ToString());
            dic.Add("数量23", dr["数量23"].ToString());
            dic.Add("数量24", dr["数量24"].ToString());
            dic.Add("数量25", dr["数量25"].ToString());


            dic.Add("工艺1", dr["工艺1"].ToString());
            dic.Add("工艺2", dr["工艺2"].ToString());
            dic.Add("工艺3", dr["工艺3"].ToString());
            dic.Add("工艺4", dr["工艺4"].ToString());
            dic.Add("工艺5", dr["工艺5"].ToString());
            dic.Add("工艺6", dr["工艺6"].ToString());
            dic.Add("工艺7", dr["工艺7"].ToString());
            dic.Add("工艺8", dr["工艺8"].ToString());
            dic.Add("工艺9", dr["工艺9"].ToString());
            dic.Add("工艺10", dr["工艺10"].ToString());
            dic.Add("工艺11", dr["工艺11"].ToString());
            dic.Add("工艺12", dr["工艺12"].ToString());
            dic.Add("工艺13", dr["工艺13"].ToString());
            dic.Add("工艺14", dr["工艺14"].ToString());
            dic.Add("工艺15", dr["工艺15"].ToString());
            dic.Add("工艺16", dr["工艺16"].ToString());
            dic.Add("工艺17", dr["工艺17"].ToString());
            dic.Add("工艺18", dr["工艺18"].ToString());
            dic.Add("工艺19", dr["工艺19"].ToString());
            dic.Add("工艺20", dr["工艺20"].ToString());
            dic.Add("工艺21", dr["工艺21"].ToString());
            dic.Add("工艺22", dr["工艺22"].ToString());
            dic.Add("工艺23", dr["工艺23"].ToString());
            dic.Add("工艺24", dr["工艺24"].ToString());
            dic.Add("工艺25", dr["工艺25"].ToString());

            dic.Add("编制人日期", dr["编制人日期"].ToString());


            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }

            string str1 = txt_tuhao.Text;
            //string timeKa = DateTime.Now.ToString("yyyy/MM/dd");
            if (str1.Contains("/"))
            {
                str1 = str1.Replace("/", "");
            }
            if (str1.Contains("*"))
            {
                str1 = str1.Replace("*", "-");
            }
            if (str1.Contains("?"))
            {
                str1 = str1.Replace("?", "-");
            }
            string str2 = txt_gonglinghao.Text;
            if (str2.Contains("/"))
            {
                str2 = str2.Replace("/", "");
            }
            if (str2.Contains("#"))
            {
                str2 = str2.Replace("#", "-");
            }

            string strmingcheng = txt_mingcheng.Text;
            if (strmingcheng.Contains("+"))
            {
                strmingcheng = strmingcheng.Replace("+", "-");
            }
            if (strmingcheng.Contains("*"))
            {
                strmingcheng = strmingcheng.Replace("*", "-");
            }
            if (strmingcheng.Contains("（"))
            {
                strmingcheng = strmingcheng.Replace("（", "");
            }
            if (strmingcheng.Contains("）"))
            {
                strmingcheng = strmingcheng.Replace("）", "");
            }
            if (strmingcheng.Contains("_"))
            {
                strmingcheng = strmingcheng.Replace("(", "");
            }
            if (strmingcheng.Contains("\n"))
            {
                strmingcheng = strmingcheng.Replace("\n", "-");
            }

            string docName = str2 + "-" + txt_jiagong.Text + txt_danhao.Text + "-" + str1 + "-" + strmingcheng + ".doc";
            //FileInfo info1 = new FileInfo(Application.StartupPath + "\\" + docName);
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            MessageBox.Show("工艺卡保存到桌面成功！", "提示");
        }


        /// <summary>
        /// 保存工序设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            string time1 = DateTime.Now.ToString();

            if (shebei1.Text.Trim() == "")
            {
                MessageBox.Show("请选择设备名称！", "提示");
                return;
            }


            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["数量"].ToString() == "")
                    {
                        MessageBox.Show("请填写第" + (i + 1) + "行的重量！", "提示");
                        return;
                    }
                }
            }

            if (leixing == "机修件组件")
            {
                DateTime timedaohuo = DateTime.Now.AddDays(5);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (dr["型号"].ToString().Contains("|"))
                    {
                        string[] a = dr["型号"].ToString().Split('|');
                        string a1 = a[0];
                        string a2 = a[1];

                        leixinglx = a[1];
                    }
                    else
                    {
                        leixinglx = dr["型号"].ToString();
                    }

                    double zongzhongliang = Convert.ToDouble(dr["数量"]) * Convert.ToDouble(txt_jiagongshuliang.Text);

                    string sql = "insert into db_caigoucailiao(项目名称,工作令号,设备名称,图号,名称,材料名称,型号,编码,单位,数量,总重量,时间,编写人,类型,要求到货日期,序号,time,料单类型,组件定位) values('" + txt_jiagong.Text + "','" + txt_gonglinghao.Text + "','" + txt_danhao.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + dr["材料名称"] + "','" + dr["型号"] + "','" + dr["编码"] + "','" + dr["单位"] + "','" + dr["数量"] + "','" + zongzhongliang + "','" + time1 + "','" + yonghu + "','" + leixinglx + "','" + timedaohuo + "','" + xuhao + "','" + shijian + "','机修件组件','" + dingweiNumber + "')";
                    SQLhelp.ExecuteNonquery(sql, CommandType.Text);
                }
            }

            if (leixing == "机修件零件")
            {
                DateTime timedaohuo = DateTime.Now.AddDays(5);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (dr["型号"].ToString().Contains("|"))
                    {
                        string[] a = dr["型号"].ToString().Split('|');
                        string a1 = a[0];
                        string a2 = a[1];

                        leixinglx = a[1];
                    }
                    else
                    {
                        leixinglx = dr["型号"].ToString();
                    }
                    double zongzhongliang = Convert.ToDouble(dr["数量"]) * Convert.ToDouble(txt_jiagongshuliang.Text);

                    string sql = "insert into db_caigoucailiao(项目名称,工作令号,设备名称,图号,名称,材料名称,型号,编码,单位,数量,总重量,时间,编写人,类型,要求到货日期,序号,料单类型) values('" + txt_jiagong.Text + "','" + txt_gonglinghao.Text + "','" + txt_danhao.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + dr["材料名称"] + "','" + dr["型号"] + "','" + dr["编码"] + "','" + dr["单位"] + "','" + dr["数量"] + "','" + zongzhongliang + "','" + time1 + "','" + yonghu + "','" + leixinglx + "','" + timedaohuo + "','" + xuhao + "','机修件零件')";
                    SQLhelp.ExecuteNonquery(sql, CommandType.Text);
                }
            }
            //if (dateTimePicker1.Text == dateTimePicker2.Text)
            //{
            //    MessageBox.Show("请检查第一道工序排产时间!", "提示");
            //    return;
            //}

            //if (textBox14.Text.Trim() == "" || textBox34.Text.Trim() == "")
            //{
            //    MessageBox.Show("请输入自制件的材料以及重量！", "提示");
            //    return;
            //}

            //if (textBox14.Text.Trim() == "")
            //{
            //    textBox14.Text = "无";
            //    textBox34.Text = "0";
            //}
            //if (textBox7.Text.Trim() == "")
            //{
            //    textBox7.Text = "无";
            //    textBox27.Text = "0";
            //}
            //if (textBox10.Text.Trim() == "")
            //{
            //    textBox10.Text = "无";
            //    textBox30.Text = "0";
            //}
            //if (textBox3.Text.Trim() == "")
            //{
            //    textBox3.Text = "无";
            //    textBox2.Text = "0";
            //}
            //if (txt_cailiao5.Text.Trim() == "")
            //{
            //    txt_cailiao5.Text = "无";
            //    txt_zhongliang5.Text = "0";
            //}
            //if (txt_cailiao6.Text.Trim() == "")
            //{
            //    txt_cailiao6.Text = "无";
            //    txt_zhongliang6.Text = "0";
            //}
            //if (txt_cailiao7.Text.Trim() == "")
            //{
            //    txt_cailiao7.Text = "无";
            //    txt_zhongliang7.Text = "0";
            //}
            //if (txt_cailiao8.Text.Trim() == "")
            //{
            //    txt_cailiao8.Text = "无";
            //    txt_zhongliang8.Text = "0";
            //}
            //if (txt_cailiao9.Text.Trim() == "")
            //{
            //    txt_cailiao9.Text = "无";
            //    txt_zhongliang9.Text = "0";
            //}
            //if (txt_cailiao10.Text.Trim() == "")
            //{
            //    txt_cailiao10.Text = "无";
            //    txt_zhongliang10.Text = "0";
            //}

            if (comboBox1.Text != "")
            {
                if (txt_shuliang1.Text.Trim() == "" || txt_gx1.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第1道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox2.Text != "")
            {

                if (txt_shuliang2.Text.Trim() == "" || txt_gx2.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第2道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox3.Text != "")
            {

                if (txt_shuliang3.Text.Trim() == "" || txt_gx3.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第3道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox4.Text != "")
            {

                if (txt_shuliang4.Text.Trim() == "" || txt_gx4.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第4道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox5.Text != "")
            {

                if (txt_shuliang5.Text.Trim() == "" || txt_gx5.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第5道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox6.Text != "")
            {

                if (txt_shuliang6.Text.Trim() == "" || txt_gx6.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第6道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox7.Text != "")
            {

                if (txt_shuliang7.Text.Trim() == "" || txt_gx7.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第7道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox8.Text != "")
            {

                if (txt_shuliang8.Text.Trim() == "" || txt_gx8.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第8道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox9.Text != "")
            {

                if (txt_shuliang9.Text.Trim() == "" || txt_gx9.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第9道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox10.Text != "")
            {

                if (txt_shuliang10.Text.Trim() == "" || txt_gx10.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第10道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox11.Text != "")
            {

                if (txt_shuliang11.Text.Trim() == "" || txt_gx11.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第11道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox12.Text != "")
            {

                if (txt_shuliang12.Text.Trim() == "" || txt_gx12.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第12道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox13.Text != "")
            {

                if (txt_shuliang13.Text.Trim() == "" || txt_gx13.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第13道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox14.Text != "")
            {

                if (txt_shuliang14.Text.Trim() == "" || txt_gx14.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第14道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox15.Text != "")
            {

                if (txt_shuliang15.Text.Trim() == "" || txt_gx15.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第15道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox16.Text != "")
            {

                if (txt_shuliang16.Text.Trim() == "" || txt_gx16.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第16道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox17.Text != "")
            {

                if (txt_shuliang17.Text.Trim() == "" || txt_gx17.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第17道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox18.Text != "")
            {

                if (txt_shuliang18.Text.Trim() == "" || txt_gx18.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第18道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox19.Text != "")
            {

                if (txt_shuliang19.Text.Trim() == "" || txt_gx19.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第19道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox20.Text != "")
            {

                if (txt_shuliang20.Text.Trim() == "" || txt_gx20.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第20道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox46.Text != "")
            {

                if (txt_shuliang21.Text.Trim() == "" || txt_gx21.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第21道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox47.Text != "")
            {

                if (txt_shuliang22.Text.Trim() == "" || txt_gx22.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第22道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox48.Text != "")
            {

                if (txt_shuliang23.Text.Trim() == "" || txt_gx23.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第23道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox49.Text != "")
            {

                if (txt_shuliang24.Text.Trim() == "" || txt_gx24.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第24道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }
            if (comboBox50.Text != "")
            {

                if (txt_shuliang25.Text.Trim() == "" || txt_gx25.Text.Trim() == "")
                {
                    MessageBox.Show("请检查第25道工序数量和价格是否未填写！", "提示");
                    return;
                }
            }

            //工序1
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请先设置工序再保存！", "提示");
                return;
            }
            else
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang1.Text + "','" + comboBox1.Text.Trim() + "','" + 1 + "','" + richTextBox1.Text + "','" + txt_gx1.Text.Trim() + "','" + comboBox21.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox27.Text + "','" + shebei1.Text + "','0','显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox1.Text + "','" + 1 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang1.Text + "','" + txt_gx1.Text.Trim() + "','" + xuhao + "', '" + shebei1.Text + "', '" + 1 + "', '" + comboBox1.Text.Trim() + "','" + time1 + "','" + comboBox21.Text.Trim() + "','" + txt_mingcheng.Text + "','"+ leixing +"','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序2
            if (comboBox2.Text != "")
            {
              
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang2.Text + "','" + comboBox2.Text.Trim() + "','" + 2 + "','" + richTextBox2.Text + "','" + txt_gx2.Text.Trim() + "','" + comboBox22.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox28.Text + "','" + shebei2.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox2.Text + "','" + 2 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang2.Text + "','" + txt_gx2.Text.Trim() + "','" + xuhao + "', '" + shebei2.Text + "', '" + 2 + "', '" + comboBox2.Text.Trim() + "','" + time1 + "','" + comboBox22.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序3
            if (comboBox3.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang3.Text + "','" + comboBox3.Text.Trim() + "','" + 3 + "','" + richTextBox3.Text + "','" + txt_gx3.Text.Trim() + "','" + comboBox23.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox29.Text + "','" + shebei3.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox3.Text + "','" + 3 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang3.Text + "','" + txt_gx3.Text.Trim() + "','" + xuhao + "', '" + shebei3.Text + "', '" + 3 + "', '" + comboBox3.Text.Trim() + "','" + time1 + "','" + comboBox23.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序4
            if (comboBox4.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang4.Text + "','" + comboBox4.Text.Trim() + "','" + 4 + "','" + richTextBox4.Text + "','" + txt_gx4.Text.Trim() + "','" + comboBox24.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox30.Text + "','" + shebei4.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox4.Text + "','" + 4 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang4.Text + "','" + txt_gx4.Text.Trim() + "','" + xuhao + "', '" + shebei4.Text + "', '" + 4 + "', '" + comboBox4.Text.Trim() + "','" + time1 + "','" + comboBox24.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序5
            if (comboBox5.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang5.Text + "','" + comboBox5.Text.Trim() + "','" + 5 + "','" + richTextBox5.Text + "','" + txt_gx5.Text.Trim() + "','" + comboBox25.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox31.Text + "','" + shebei5.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox5.Text + "','" + 5 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang5.Text + "','" + txt_gx5.Text.Trim() + "','" + xuhao + "', '" + shebei5.Text + "', '" + 5 + "', '" + comboBox5.Text.Trim() + "','" + time1 + "','" + comboBox25.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序6
            if (comboBox6.Text != "")
            {
               
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang6.Text + "','" + comboBox6.Text.Trim() + "','" + 6 + "','" + richTextBox6.Text + "','" + txt_gx6.Text.Trim() + "','" + comboBox26.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox32.Text + "','" + shebei6.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox6.Text + "','" + 6 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang6.Text + "','" + txt_gx6.Text.Trim() + "','" + xuhao + "', '" + shebei6.Text + "', '" + 6 + "', '" + comboBox6.Text.Trim() + "','" + time1 + "','" + comboBox26.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序7
            if (comboBox7.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang7.Text + "','" + comboBox7.Text.Trim() + "','" + 7 + "','" + richTextBox7.Text + "','" + txt_gx7.Text.Trim() + "','" + comboBox27.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox33.Text + "','" + shebei7.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox7.Text + "','" + 7 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang7.Text + "','" + txt_gx7.Text.Trim() + "','" + xuhao + "', '" + shebei7.Text + "', '" + 7 + "', '" + comboBox7.Text.Trim() + "','" + time1 + "','" + comboBox27.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序8
            if (comboBox8.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang8.Text + "','" + comboBox8.Text.Trim() + "','" + 8 + "','" + richTextBox8.Text + "','" + txt_gx8.Text.Trim() + "','" + comboBox28.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox34.Text + "','" + shebei8.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox8.Text + "','" + 8 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang8.Text + "','" + txt_gx8.Text.Trim() + "','" + xuhao + "', '" + shebei8.Text + "', '" + 8 + "', '" + comboBox8.Text.Trim() + "','" + time1 + "','" + comboBox28.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序9
            if (comboBox9.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang9.Text + "','" + comboBox9.Text.Trim() + "','" + 9 + "','" + richTextBox9.Text + "','" + txt_gx9.Text.Trim() + "','" + comboBox29.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox35.Text + "','" + shebei9.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox9.Text + "','" + 9 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text +  "','" + txt_shuliang9.Text + "','" + txt_gx9.Text.Trim() + "','" + xuhao + "', '" + shebei9.Text + "', '" + 9 + "', '" + comboBox9.Text.Trim() + "','" + time1 + "','" + comboBox29.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序10
            if (comboBox10.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang10.Text + "','" + comboBox10.Text.Trim() + "','" + 10 + "','" + richTextBox10.Text + "','" + txt_gx10.Text.Trim() + "','" + comboBox30.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox36.Text + "','" + shebei10.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox10.Text + "','" + 10 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang10.Text + "','" + txt_gx10.Text.Trim() + "','" + xuhao + "', '" + shebei10.Text + "', '" + 10 + "', '" + comboBox10.Text.Trim() + "','" + time1 + "','" + comboBox30.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序11
            if (comboBox11.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang11.Text + "','" + comboBox11.Text.Trim() + "','" + 11 + "','" + richTextBox11.Text + "','" + txt_gx11.Text.Trim() + "','" + comboBox31.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox37.Text + "','" + shebei11.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox11.Text + "','" + 11 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang11.Text + "','" + txt_gx11.Text.Trim() + "','" + xuhao + "', '" + shebei11.Text + "', '" + 11 + "', '" + comboBox11.Text.Trim() + "','" + time1 + "','" + comboBox31.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序12
            if (comboBox12.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang12.Text + "','" + comboBox12.Text.Trim() + "','" + 12 + "','" + richTextBox12.Text + "','" + txt_gx12.Text.Trim() + "','" + comboBox32.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox38.Text + "','" + shebei12.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox12.Text + "','" + 12 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang12.Text + "','" + txt_gx12.Text.Trim() + "','" + xuhao + "', '" + shebei12.Text + "', '" + 12 + "', '" + comboBox12.Text.Trim() + "','" + time1 + "','" + comboBox32.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序13
            if (comboBox13.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang13.Text + "','" + comboBox13.Text.Trim() + "','" + 13 + "','" + richTextBox13.Text + "','" + txt_gx13.Text.Trim() + "','" + comboBox33.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox39.Text + "','" + shebei13.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox13.Text + "','" + 13 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang13.Text + "','" + txt_gx13.Text.Trim() + "','" + xuhao + "', '" + shebei13.Text + "', '" + 13 + "', '" + comboBox13.Text.Trim() + "','" + time1 + "','" + comboBox33.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);

            }

            //工序14
            if (comboBox14.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang14.Text + "','" + comboBox14.Text.Trim() + "','" + 14 + "','" + richTextBox14.Text + "','" + txt_gx14.Text.Trim() + "','" + comboBox34.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox40.Text + "','" + shebei14.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox14.Text + "','" + 14 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang14.Text + "','" + txt_gx14.Text.Trim() + "','" + xuhao + "', '" + shebei14.Text + "', '" + 14 + "', '" + comboBox14.Text.Trim() + "','" + time1 + "','" + comboBox34.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序15
            if (comboBox15.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang15.Text + "','" + comboBox15.Text.Trim() + "','" + 15 + "','" + richTextBox15.Text + "','" + txt_gx15.Text.Trim() + "','" + comboBox35.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox41.Text + "','" + shebei15.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox15.Text + "','" + 15 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang15.Text + "','" + txt_gx15.Text.Trim() + "','" + xuhao + "', '" + shebei15.Text + "', '" + 15 + "', '" + comboBox15.Text.Trim() + "','" + time1 + "','" + comboBox35.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序16
            if (comboBox16.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang16.Text + "','" + comboBox16.Text.Trim() + "','" + 16 + "','" + richTextBox16.Text + "','" + txt_gx16.Text.Trim() + "','" + comboBox36.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox42.Text + "','" + shebei16.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox16.Text + "','" + 16 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang16.Text + "','" + txt_gx16.Text.Trim() + "','" + xuhao + "', '" + shebei16.Text + "', '" + 16 + "', '" + comboBox16.Text.Trim() + "','" + time1 + "','" + comboBox36.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序17
            if (comboBox17.Text != "")
            {
               
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang17.Text + "','" + comboBox17.Text.Trim() + "','" + 17 + "','" + richTextBox17.Text + "','" + txt_gx17.Text.Trim() + "','" + comboBox37.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox43.Text + "','" + shebei17.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox17.Text + "','" + 17 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang17.Text + "','" + txt_gx17.Text.Trim() + "','" + xuhao + "', '" + shebei17.Text + "', '" + 17 + "', '" + comboBox17.Text.Trim() + "','" + time1 + "','" + comboBox37.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序18
            if (comboBox18.Text != "")
            {
               
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang18.Text + "','" + comboBox18.Text.Trim() + "','" + 18 + "','" + richTextBox18.Text + "','" + txt_gx18.Text.Trim() + "','" + comboBox38.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox44.Text + "','" + shebei18.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox18.Text + "','" + 18 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang18.Text + "','" + txt_gx18.Text.Trim() + "','" + xuhao + "', '" + shebei18.Text + "', '" + 18 + "', '" + comboBox18.Text.Trim() + "','" + time1 + "','" + comboBox38.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序19
            if (comboBox19.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang19.Text + "','" + comboBox19.Text.Trim() + "','" + 19 + "','" + richTextBox19.Text + "','" + txt_gx19.Text.Trim() + "','" + comboBox39.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox45.Text + "','" + shebei19.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox19.Text + "','" + 19 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang19.Text + "','" + txt_gx19.Text.Trim() + "','" + xuhao + "', '" + shebei19.Text + "', '" + 19 + "', '" + comboBox19.Text.Trim() + "','" + time1 + "','" + comboBox39.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序20
            if (comboBox20.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang20.Text + "','" + comboBox20.Text.Trim() + "','" + 20 + "','" + richTextBox20.Text + "','" + txt_gx20.Text.Trim() + "','" + comboBox40.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox46.Text + "','" + shebei20.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox20.Text + "','" + 20 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang20.Text + "','" + txt_gx20.Text.Trim() + "','" + xuhao + "', '" + shebei20.Text + "', '" + 20 + "', '" + comboBox20.Text.Trim() + "','" + time1 + "','" + comboBox40.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序21
            if (comboBox46.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang21.Text + "','" + comboBox46.Text.Trim() + "','" + 21 + "','" + richTextBox22.Text + "','" + txt_gx21.Text.Trim() + "','" + comboBox41.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox47.Text + "','" + shebei21.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox46.Text + "','" + 21 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang21.Text + "','" + txt_gx21.Text.Trim() + "','" + xuhao + "', '" + shebei21.Text + "', '" + 21 + "', '" + comboBox46.Text.Trim() + "','" + time1 + "','" + comboBox41.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序22
            if (comboBox47.Text != "")
            {
              
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang22.Text + "','" + comboBox47.Text.Trim() + "','" + 22 + "','" + richTextBox23.Text + "','" + txt_gx22.Text.Trim() + "','" + comboBox42.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox48.Text + "','" + shebei22.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox47.Text + "','" + 22 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang22.Text + "','" + txt_gx22.Text.Trim() + "','" + xuhao + "', '" + shebei22.Text + "', '" + 22 + "', '" + comboBox47.Text.Trim() + "','" + time1 + "','" + comboBox42.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序23
            if (comboBox48.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang23.Text + "','" + comboBox48.Text.Trim() + "','" + 23 + "','" + richTextBox24.Text + "','" + txt_gx23.Text.Trim() + "','" + comboBox43.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox49.Text + "','" + shebei23.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox48.Text + "','" + 23 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang23.Text + "','" + txt_gx23.Text.Trim() + "','" + xuhao + "', '" + shebei23.Text + "', '" + 23 + "', '" + comboBox48.Text.Trim() + "','" + time1 + "','" + comboBox43.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序24
            if (comboBox49.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang24.Text + "','" + comboBox49.Text.Trim() + "','" + 24 + "','" + richTextBox25.Text + "','" + txt_gx24.Text.Trim() + "','" + comboBox44.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox50.Text + "','" + shebei24.Text + "','0','不显示','" + leixing + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox49.Text + "','" + 24 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang24.Text + "','" + txt_gx24.Text.Trim() + "','" + xuhao + "', '" + shebei24.Text + "', '" + 24 + "', '" + comboBox49.Text.Trim() + "','" + time1 + "','" + comboBox44.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian + "')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            //工序25
            if (comboBox50.Text != "")
            {
                string s1 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,部门,序号,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_jiagong.Text + "','" + txt_tuhao.Text + "','" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shuliang25.Text + "','" + comboBox50.Text.Trim() + "','" + 25 + "','" + richTextBox26.Text + "','" + txt_gx25.Text.Trim() + "','" + comboBox45.Text.Trim() + "','" + txt_danhao.Text.Trim() + "','" + xuhao + "','" + time1 + "','" + richTextBox51.Text + "','" + shebei25.Text + "','0','不显示','"+ leixing +"')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                string s2 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_jiagong.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "','" + txt_gonglinghao.Text + "','" + comboBox50.Text + "','" + 25 + "','" + xuhao + "')";
                int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                string s3 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + " ','" + txt_gonglinghao.Text + "','" + txt_jiagong.Text + "','" + txt_shuliang25.Text + "','"+ txt_gx25.Text.Trim()+"','" + xuhao + "', '" + shebei25.Text + "', '" + 25 + "', '" + comboBox50.Text.Trim() + "','" + time1 + "','" + comboBox45.Text.Trim() + "','" + txt_mingcheng.Text + "','" + leixing + "','" + addyujiaoshijian+"')";
                int r3 = SQLhelp.ExecuteNonquery(s3, CommandType.Text);
            }

            if(leixing == "机修件零件")
            {
                string sqlgongxu = "update db_jixiujian set 工序1='" + comboBox1.Text.Trim() + "',工序2='" + comboBox2.Text.Trim() + "',工序3='" + comboBox3.Text.Trim() + "',工序4='" + comboBox4.Text.Trim() + "',工序5='" + comboBox5.Text.Trim() + "',工序6='" + comboBox6.Text.Trim() + "',工序7='" + comboBox7.Text.Trim() + "',工序8='" + comboBox8.Text.Trim() + "',工序9='" + comboBox9.Text.Trim() + "',工序10='" + comboBox10.Text.Trim() + "',工序11='" + comboBox11.Text.Trim() + "',工序12='" + comboBox12.Text.Trim() + "',工序13='" + comboBox13.Text.Trim() + "',工序14='" + comboBox14.Text.Trim() + "',工序15='" + comboBox15.Text.Trim() + "',工序16='" + comboBox16.Text.Trim() + "',工序17='" + comboBox17.Text.Trim() + "',工序18='" + comboBox18.Text.Trim() + "',工序19='" + comboBox19.Text.Trim() + "',工序20='" + comboBox20.Text.Trim() + "',工序21='" + comboBox46.Text.Trim() + "',工序22='" + comboBox47.Text.Trim() + "',工序23='" + comboBox48.Text.Trim() + "',工序24='" + comboBox49.Text.Trim() + "',工序25='" + comboBox50.Text.Trim() + "',目前到达工序='已编工艺，即将进入排产' where 序号='" + xuhao + "'";
                string retgongxu = Convert.ToString(SQLhelp.ExecuteNonquery(sqlgongxu, CommandType.Text));
            }


            string sqlliaodan = "update tb_caigouliaodan set 当前状态='已编工艺，即将进入排产' where id='" + xuhao + "'";
            SQLhelp.ExecuteNonquery1(sqlliaodan, CommandType.Text);

            //插入二维码到数据库
            byte[] imageBytes = GetImageBytes(pictureBox1.Image);
            string sqlByte = "update db_gongxu111 set 二维码=@pic where 接单编号='" + addgonglinghao + "' and 工件名称='" + addmingcheng + "'";// and 序号='" + xuhao + "'";
            string retByte = Convert.ToString(SQLhelp.ExecuteNonqueryByte(sqlByte, CommandType.Text, imageBytes));
            if (retByte != "")
            {
                MessageBox.Show("项目设置成功！", "提示");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            //string a = txt_tuhao.Text.Trim();
            string b = txt_mingcheng.Text.Trim();

            string sql = "select id,客户名称,部门,工件名称,加工内容,接单编号,机修件数量,工序名称,价格,工序顺序,工序内容,负责人 from db_gongxu111 where 工件名称='" + b + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret == "")
            {
                MessageBox.Show("该自制零部件还没有已设置的工序", "提示");
                return;
            }
            else//以前做过此类型的工序
            {
                Formjixiujiantizhigongxu form = new Formjixiujiantizhigongxu();
                form.gongjianmingcheng = b;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    comboBox1.Text = form.a1;
                    richTextBox1.Text = form.b1;
                    txt_gx1.Text = form.c1;
                    comboBox21.Text = form.d1;
                    richTextBox27.Text = form.h1;
                    //textBox14.Text = form.f1;
                    //textBox34.Text = form.g1;

                    comboBox2.Text = form.a2;
                    richTextBox2.Text = form.b2;
                    txt_gx2.Text = form.c2;
                    comboBox22.Text = form.d2;
                    richTextBox28.Text = form.h2;
                    //textBox7.Text = form.f2;
                    //textBox27.Text = form.g2;

                    comboBox3.Text = form.a3;
                    richTextBox3.Text = form.b3;
                    txt_gx3.Text = form.c3;
                    comboBox23.Text = form.d3;
                    richTextBox29.Text = form.h3;
                    //textBox10.Text = form.f3;
                    //textBox30.Text = form.g3;

                    comboBox4.Text = form.a4;
                    richTextBox4.Text = form.b4;
                    txt_gx4.Text = form.c4;
                    comboBox24.Text = form.d4;
                    richTextBox30.Text = form.h4;
                    //textBox3.Text = form.f4;
                    //textBox2.Text = form.g4;

                    comboBox5.Text = form.a5;
                    richTextBox5.Text = form.b5;
                    txt_gx5.Text = form.c5;
                    comboBox25.Text = form.d5;
                    richTextBox31.Text = form.h5;

                    comboBox6.Text = form.a6;
                    richTextBox6.Text = form.b6;
                    txt_gx6.Text = form.c6;
                    comboBox26.Text = form.d6;
                    richTextBox32.Text = form.h6;

                    comboBox7.Text = form.a7;
                    richTextBox7.Text = form.b7;
                    txt_gx7.Text = form.c7;
                    comboBox27.Text = form.d7;
                    richTextBox33.Text = form.h7;

                    comboBox8.Text = form.a8;
                    richTextBox8.Text = form.b8;
                    txt_gx8.Text = form.c8;
                    comboBox28.Text = form.d8;
                    richTextBox34.Text = form.h8;

                    comboBox9.Text = form.a9;
                    richTextBox9.Text = form.b9;
                    txt_gx9.Text = form.c9;
                    comboBox29.Text = form.d9;
                    richTextBox35.Text = form.h9;

                    comboBox10.Text = form.a10;
                    richTextBox10.Text = form.b10;
                    txt_gx10.Text = form.c10;
                    comboBox30.Text = form.d10;
                    richTextBox36.Text = form.h10;

                    comboBox11.Text = form.a11;
                    richTextBox11.Text = form.b11;
                    txt_gx11.Text = form.c11;
                    comboBox31.Text = form.d11;
                    richTextBox37.Text = form.h11;

                    comboBox12.Text = form.a12;
                    richTextBox12.Text = form.b12;
                    txt_gx12.Text = form.c12;
                    comboBox32.Text = form.d12;
                    richTextBox38.Text = form.h12;

                    comboBox13.Text = form.a13;
                    richTextBox13.Text = form.b13;
                    txt_gx13.Text = form.c13;
                    comboBox33.Text = form.d13;
                    richTextBox39.Text = form.h13;

                    comboBox14.Text = form.a14;
                    richTextBox14.Text = form.b14;
                    txt_gx14.Text = form.c14;
                    comboBox34.Text = form.d14;
                    richTextBox40.Text = form.h14;

                    comboBox15.Text = form.a15;
                    richTextBox15.Text = form.b15;
                    txt_gx15.Text = form.c15;
                    comboBox35.Text = form.d15;
                    richTextBox41.Text = form.h15;

                    comboBox16.Text = form.a16;
                    richTextBox16.Text = form.b16;
                    txt_gx16.Text = form.c16;
                    comboBox36.Text = form.d16;
                    richTextBox42.Text = form.h16;

                    comboBox17.Text = form.a17;
                    richTextBox17.Text = form.b17;
                    txt_gx17.Text = form.c17;
                    comboBox37.Text = form.d17;
                    richTextBox43.Text = form.h17;

                    comboBox18.Text = form.a18;
                    richTextBox18.Text = form.b18;
                    txt_gx18.Text = form.c18;
                    comboBox38.Text = form.d18;
                    richTextBox44.Text = form.h18;

                    comboBox19.Text = form.a19;
                    richTextBox19.Text = form.b19;
                    txt_gx19.Text = form.c19;
                    comboBox39.Text = form.d19;
                    richTextBox45.Text = form.h19;

                    comboBox20.Text = form.a20;
                    richTextBox20.Text = form.b20;
                    txt_gx20.Text = form.c20;
                    comboBox40.Text = form.d20;
                    richTextBox46.Text = form.h20;

                    comboBox46.Text = form.a21;
                    richTextBox22.Text = form.b21;
                    txt_gx21.Text = form.c21;
                    comboBox41.Text = form.d21;
                    richTextBox47.Text = form.h21;

                    comboBox47.Text = form.a22;
                    richTextBox23.Text = form.b22;
                    txt_gx22.Text = form.c22;
                    comboBox42.Text = form.d22;
                    richTextBox48.Text = form.h22;

                    comboBox48.Text = form.a23;
                    richTextBox24.Text = form.b23;
                    txt_gx23.Text = form.c23;
                    comboBox43.Text = form.d23;
                    richTextBox49.Text = form.h23;

                    comboBox49.Text = form.a24;
                    richTextBox25.Text = form.b24;
                    txt_gx24.Text = form.c24;
                    comboBox44.Text = form.d24;
                    richTextBox50.Text = form.h24;

                    comboBox50.Text = form.a25;
                    richTextBox26.Text = form.b25;
                    txt_gx25.Text = form.c25;
                    comboBox45.Text = form.d25;
                    richTextBox51.Text = form.h25;

                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #region comboBox1-comboBox25设置
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "")
            {
                richTextBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox21.Enabled = true;
                richTextBox27.Enabled = true;
                shebei1.Enabled = true;
            }
            comboBox21.Text = "";
            comboBox21.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox1.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox21.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox21.Items.Add(a);
                    comboBox21.SelectedIndex = 0;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim() != "")
            {
                richTextBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox22.Enabled = true;
                richTextBox28.Enabled = true;
                shebei2.Enabled = true;
            }
            comboBox22.Text = "";
            comboBox22.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox2.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox22.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox22.Items.Add(a);
                    comboBox22.SelectedIndex = 0;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.Text.Trim() != "")
            {
                richTextBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox23.Enabled = true;
                richTextBox29.Enabled = true;
                shebei3.Enabled = true;
            }
            comboBox23.Text = "";
            comboBox23.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox3.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox23.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox23.Items.Add(a);
                    comboBox23.SelectedIndex = 0;
                }
            }
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox4.Text.Trim() != "")
            {
                richTextBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox24.Enabled = true;
                richTextBox30.Enabled = true;
                shebei4.Enabled = true;
            }
            comboBox24.Text = "";
            comboBox24.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox4.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox24.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox24.Items.Add(a);
                    comboBox24.SelectedIndex = 0;
                }
            }
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox5.Text.Trim() != "")
            {
                richTextBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox25.Enabled = true;
                richTextBox31.Enabled = true;
                shebei5.Enabled = true;
            }
            comboBox25.Text = "";
            comboBox25.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox5.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox25.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox25.Items.Add(a);
                    comboBox25.SelectedIndex = 0;
                }
            }
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox6.Text.Trim() != "")
            {
                richTextBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox26.Enabled = true;
                richTextBox32.Enabled = true;
                shebei6.Enabled = true;
            }
            comboBox26.Text = "";
            comboBox26.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox6.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox26.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox26.Items.Add(a);
                    comboBox26.SelectedIndex = 0;
                }
            }
        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox7.Text.Trim() != "")
            {
                richTextBox7.Enabled = true;
                comboBox8.Enabled = true;
                comboBox27.Enabled = true;
                richTextBox33.Enabled = true;
                shebei7.Enabled = true;
            }
            comboBox27.Text = "";
            comboBox27.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox7.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox27.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox27.Items.Add(a);
                    comboBox27.SelectedIndex = 0;
                }
            }
        }

        private void comboBox8_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox8.Text.Trim() != "")
            {
                richTextBox8.Enabled = true;
                comboBox9.Enabled = true;
                comboBox28.Enabled = true;
                richTextBox34.Enabled = true;
                shebei8.Enabled = true;
            }
            comboBox28.Text = "";
            comboBox28.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox8.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox28.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox28.Items.Add(a);
                    comboBox28.SelectedIndex = 0;
                }
            }
        }

        private void comboBox9_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox9.Text.Trim() != "")
            {
                richTextBox9.Enabled = true;
                comboBox10.Enabled = true;
                comboBox29.Enabled = true;
                richTextBox35.Enabled = true;
                shebei9.Enabled = true;
            }
            comboBox29.Text = "";
            comboBox29.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox9.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox29.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox29.Items.Add(a);
                    comboBox29.SelectedIndex = 0;
                }
            }
        }

        private void comboBox10_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox10.Text.Trim() != "")
            {
                richTextBox10.Enabled = true;
                comboBox11.Enabled = true;
                comboBox30.Enabled = true;
                richTextBox36.Enabled = true;
                shebei10.Enabled = true;
            }
            comboBox30.Text = "";
            comboBox30.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox10.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox30.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox30.Items.Add(a);
                    comboBox30.SelectedIndex = 0;
                }
            }
        }

        private void comboBox11_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox11.Text.Trim() != "")
            {
                richTextBox11.Enabled = true;
                comboBox12.Enabled = true;
                comboBox31.Enabled = true;
                richTextBox37.Enabled = true;
                shebei11.Enabled = true;
            }
            comboBox31.Text = "";
            comboBox31.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox11.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox31.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox31.Items.Add(a);
                    comboBox31.SelectedIndex = 0;
                }
            }
        }

        private void comboBox12_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox12.Text.Trim() != "")
            {
                richTextBox12.Enabled = true;
                comboBox13.Enabled = true;
                comboBox32.Enabled = true;
                richTextBox38.Enabled = true;
                shebei12.Enabled = true;
            }
            comboBox32.Text = "";
            comboBox32.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox12.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox32.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox32.Items.Add(a);
                    comboBox32.SelectedIndex = 0;
                }
            }
        }

        private void comboBox13_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox13.Text.Trim() != "")
            {
                richTextBox13.Enabled = true;
                comboBox14.Enabled = true;
                comboBox33.Enabled = true;
                richTextBox39.Enabled = true;
                shebei13.Enabled = true;
            }
            comboBox33.Text = "";
            comboBox33.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox13.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox33.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox33.Items.Add(a);
                    comboBox33.SelectedIndex = 0;
                }
            }
        }

        private void comboBox14_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox14.Text.Trim() != "")
            {
                richTextBox14.Enabled = true;
                comboBox15.Enabled = true;
                comboBox34.Enabled = true;
                richTextBox40.Enabled = true;
                shebei14.Enabled = true;
            }
            comboBox34.Text = "";
            comboBox34.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox14.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox34.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox34.Items.Add(a);
                    comboBox34.SelectedIndex = 0;
                }
            }
        }

        private void comboBox15_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox15.Text.Trim() != "")
            {
                richTextBox15.Enabled = true;
                comboBox16.Enabled = true;
                comboBox35.Enabled = true;
                richTextBox41.Enabled = true;
                shebei15.Enabled = true;
            }
            comboBox35.Text = "";
            comboBox35.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox15.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox35.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox35.Items.Add(a);
                    comboBox35.SelectedIndex = 0;
                }
            }
        }

        private void comboBox16_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox16.Text.Trim() != "")
            {
                richTextBox16.Enabled = true;
                comboBox17.Enabled = true;
                comboBox36.Enabled = true;
                richTextBox42.Enabled = true;
                shebei16.Enabled = true;
            }
            comboBox36.Text = "";
            comboBox36.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox16.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox36.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox36.Items.Add(a);
                    comboBox36.SelectedIndex = 0;
                }
            }
        }

        private void comboBox17_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox17.Text.Trim() != "")
            {
                richTextBox17.Enabled = true;
                comboBox18.Enabled = true;
                comboBox37.Enabled = true;
                richTextBox43.Enabled = true;
                shebei17.Enabled = true;
            }
            comboBox37.Text = "";
            comboBox37.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox17.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox37.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox37.Items.Add(a);
                    comboBox37.SelectedIndex = 0;
                }
            }
        }

        private void comboBox18_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox18.Text.Trim() != "")
            {
                richTextBox18.Enabled = true;
                comboBox19.Enabled = true;
                comboBox38.Enabled = true;
                richTextBox44.Enabled = true;
                shebei18.Enabled = true;
            }
            comboBox38.Text = "";
            comboBox38.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox18.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox38.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox38.Items.Add(a);
                    comboBox38.SelectedIndex = 0;
                }
            }
        }

        private void comboBox19_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox19.Text.Trim() != "")
            {
                richTextBox19.Enabled = true;
                comboBox20.Enabled = true;
                comboBox39.Enabled = true;
                richTextBox45.Enabled = true;
                shebei19.Enabled = true;
            }
            comboBox39.Text = "";
            comboBox39.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox19.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox39.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox39.Items.Add(a);
                    comboBox39.SelectedIndex = 0;
                }
            }
        }

        private void comboBox20_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox20.Text.Trim() != "")
            {
                richTextBox20.Enabled = true;
                comboBox40.Enabled = true;
                comboBox46.Enabled = true;
                richTextBox46.Enabled = true;
                shebei20.Enabled = true;
            }
            comboBox40.Text = "";
            comboBox40.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox20.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox40.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox40.Items.Add(a);
                    comboBox40.SelectedIndex = 0;
                }
            }
        }

        private void comboBox46_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox46.Text.Trim() != "")
            {
                richTextBox22.Enabled = true;
                comboBox41.Enabled = true;
                comboBox47.Enabled = true;
                richTextBox47.Enabled = true;
                shebei21.Enabled = true;
            }
            comboBox41.Text = "";
            comboBox41.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox46.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox41.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox41.Items.Add(a);
                    comboBox41.SelectedIndex = 0;
                }
            }
        }

        private void comboBox47_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox47.Text.Trim() != "")
            {
                richTextBox23.Enabled = true;
                comboBox42.Enabled = true;
                comboBox48.Enabled = true;
                richTextBox48.Enabled = true;
                shebei22.Enabled = true;
            }
            comboBox42.Text = "";
            comboBox42.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox47.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox42.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox42.Items.Add(a);
                    comboBox42.SelectedIndex = 0;
                }
            }
        }

        private void comboBox48_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox48.Text.Trim() != "")
            {
                richTextBox24.Enabled = true;
                comboBox43.Enabled = true;
                comboBox49.Enabled = true;
                richTextBox49.Enabled = true;
                shebei23.Enabled = true;
            }
            comboBox43.Text = "";
            comboBox43.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox48.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox43.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox43.Items.Add(a);
                    comboBox43.SelectedIndex = 0;
                }
            }
        }
        private void comboBox49_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox49.Text.Trim() != "")
            {
                richTextBox25.Enabled = true;
                comboBox44.Enabled = true;
                comboBox50.Enabled = true;
                richTextBox50.Enabled = true;
                shebei24.Enabled = true;
            }
            comboBox44.Text = "";
            comboBox44.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox49.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox44.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox44.Items.Add(a);
                    comboBox44.SelectedIndex = 0;
                }
            }
        }

        private void comboBox50_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox50.Text.Trim() != "")
            {
                richTextBox26.Enabled = true;
                comboBox45.Enabled = true;
                richTextBox51.Enabled = true;
                shebei25.Enabled = true;
            }
            comboBox45.Text = "";
            comboBox45.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox50.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (comboBox45.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox45.Items.Add(a);
                    comboBox45.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region 设备comboBox设置
        private void shebei1_Click_1(object sender, EventArgs e)
        {
            shebei1.Text = "";
            shebei1.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox21.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei1.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei1.Items.Add(a);
                    shebei1.SelectedIndex = 0;
                }
            }
        }

        private void shebei2_Click_1(object sender, EventArgs e)
        {
            shebei2.Text = "";
            shebei2.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox22.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei2.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei2.Items.Add(a);
                    shebei2.SelectedIndex = 0;
                }
            }
        }

        private void shebei3_Click_1(object sender, EventArgs e)
        {
            shebei3.Text = "";
            shebei3.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox23.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei3.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei3.Items.Add(a);
                    shebei3.SelectedIndex = 0;
                }
            }
        }

        private void shebei4_Click_1(object sender, EventArgs e)
        {
            shebei4.Text = "";
            shebei4.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox24.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei4.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei4.Items.Add(a);
                    shebei4.SelectedIndex = 0;
                }
            }
        }

        private void shebei5_Click_1(object sender, EventArgs e)
        {
            shebei5.Text = "";
            shebei5.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox25.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei5.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei5.Items.Add(a);
                    shebei5.SelectedIndex = 0;
                }
            }
        }

        private void shebei6_Click_1(object sender, EventArgs e)
        {
            shebei6.Text = "";
            shebei6.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox26.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei6.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei6.Items.Add(a);
                    shebei6.SelectedIndex = 0;
                }
            }
        }

        private void shebei7_Click_1(object sender, EventArgs e)
        {
            shebei7.Text = "";
            shebei7.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox27.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei7.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei7.Items.Add(a);
                    shebei7.SelectedIndex = 0;
                }
            }
        }

        private void shebei8_Click_1(object sender, EventArgs e)
        {
            shebei8.Text = "";
            shebei8.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox28.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei8.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei8.Items.Add(a);
                    shebei8.SelectedIndex = 0;
                }
            }
        }

        private void shebei9_Click_1(object sender, EventArgs e)
        {
            shebei9.Text = "";
            shebei9.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox29.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei9.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei9.Items.Add(a);
                    shebei9.SelectedIndex = 0;
                }
            }
        }

        private void shebei10_Click_1(object sender, EventArgs e)
        {
            shebei10.Text = "";
            shebei10.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox30.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei10.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei10.Items.Add(a);
                    shebei10.SelectedIndex = 0;
                }
            }
        }

        private void shebei11_Click_1(object sender, EventArgs e)
        {
            shebei11.Text = "";
            shebei11.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox31.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei11.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei11.Items.Add(a);
                    shebei11.SelectedIndex = 0;
                }
            }
        }

        private void shebei12_Click_1(object sender, EventArgs e)
        {
            shebei12.Text = "";
            shebei12.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox32.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei12.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei12.Items.Add(a);
                    shebei12.SelectedIndex = 0;
                }
            }
        }

        private void shebei13_Click_1(object sender, EventArgs e)
        {
            shebei13.Text = "";
            shebei13.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox33.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei13.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei13.Items.Add(a);
                    shebei13.SelectedIndex = 0;
                }
            }
        }

        private void shebei14_Click_1(object sender, EventArgs e)
        {
            shebei14.Text = "";
            shebei14.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox34.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei14.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei14.Items.Add(a);
                    shebei14.SelectedIndex = 0;
                }
            }
        }

        private void shebei15_Click_1(object sender, EventArgs e)
        {
            shebei15.Text = "";
            shebei15.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox35.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei15.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei15.Items.Add(a);
                    shebei15.SelectedIndex = 0;
                }
            }
        }

        private void shebei16_Click_1(object sender, EventArgs e)
        {
            shebei16.Text = "";
            shebei16.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox36.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei16.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei16.Items.Add(a);
                    shebei16.SelectedIndex = 0;
                }
            }
        }

        private void shebei17_Click_1(object sender, EventArgs e)
        {
            shebei17.Text = "";
            shebei17.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox37.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei17.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei17.Items.Add(a);
                    shebei17.SelectedIndex = 0;
                }
            }
        }

        private void shebei18_Click_1(object sender, EventArgs e)
        {
            shebei18.Text = "";
            shebei18.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox38.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei18.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei18.Items.Add(a);
                    shebei18.SelectedIndex = 0;
                }
            }
        }

        private void shebei19_Click_1(object sender, EventArgs e)
        {
            shebei19.Text = "";
            shebei19.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox39.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei19.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei19.Items.Add(a);
                    shebei19.SelectedIndex = 0;
                }
            }
        }

        private void shebei20_Click_1(object sender, EventArgs e)
        {
            shebei20.Text = "";
            shebei20.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox40.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei20.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei20.Items.Add(a);
                    shebei20.SelectedIndex = 0;
                }
            }
        }

        private void shebei21_Click_1(object sender, EventArgs e)
        {
            shebei21.Text = "";
            shebei21.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox41.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei21.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei21.Items.Add(a);
                    shebei21.SelectedIndex = 0;
                }
            }
        }

        private void shebei22_Click_1(object sender, EventArgs e)
        {
            shebei22.Text = "";
            shebei22.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox42.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei22.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei22.Items.Add(a);
                    shebei22.SelectedIndex = 0;
                }
            }
        }

        private void shebei23_Click_1(object sender, EventArgs e)
        {
            shebei23.Text = "";
            shebei23.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox43.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei23.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei23.Items.Add(a);
                    shebei23.SelectedIndex = 0;
                }
            }
        }

        private void txt_shuliang1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang1.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang2.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang2.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang2.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang3.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang3.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang3.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang4.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang4.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang4.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang5.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang5.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang5.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang6.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang6.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang6.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang7.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang7.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang7.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang8.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang8.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang8.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang9.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang9.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang9.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang10.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang10.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang10.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang11.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang11.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang11.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang12.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang12.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang12.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang13.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang13.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang13.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang14.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang14.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang14.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang15.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang15.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang15.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang16.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang16.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang16.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang17.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang17.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang17.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang18.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang18.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang18.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang19.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang19.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang19.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frerpcreat form1 = new Frerpcreat();
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {

                string sql = "select * from tb_xinerp where 新编号='" + form1.wuzi + "'";
                DataTable dtt = SQLhelp.GetDataTable1(sql, CommandType.Text);
                DataRow dr1 = dt.NewRow();

                dr1["项目名称"] = txt_jiagong.Text;
                dr1["工作令号"] = txt_gonglinghao.Text;
                dr1["设备名称"] = txt_danhao.Text;
                dr1["图号"] = txt_tuhao.Text;
                dr1["名称"] = txt_mingcheng.Text;
                dr1["原编号"] = dtt.Rows[0]["新编号"];
                dr1["编码"] = dtt.Rows[0]["新编号"];
                dr1["材料名称"] = dtt.Rows[0]["三级"]; //通过索引赋值
                dr1["型号"] = dtt.Rows[0]["四级"];
                dr1["单位"] = dtt.Rows[0]["单位"];
                dt.Rows.Add(dr1);
                gridControl1.DataSource = dt;

            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 新增材料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(btn_Save.Enabled == false)
            {
                if (leixing == "机修件零件")
                {
                    string ret = "";
                    DateTime timedaohuo = DateTime.Now.AddDays(5);

                    int[] a = gridView1.GetSelectedRows();

                    foreach (int i in a)
                    {
                        string shuliang = gridView1.GetRowCellValue(i, "数量").ToString();
                        if (shuliang == "")
                        {
                            MessageBox.Show("请填写第" + (i + 1) + "材料的数量或重量！", "提示");
                            return;
                        }
                    }

                    foreach (int i in a)
                    {
                        string lei;
                        string xinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                        string xiangmu = gridView1.GetRowCellValue(i, "项目名称").ToString();
                        string linghao = gridView1.GetRowCellValue(i, "工作令号").ToString();
                        string shebeiming = gridView1.GetRowCellValue(i, "设备名称").ToString();
                        string tuhao = gridView1.GetRowCellValue(i, "图号").ToString();
                        string mingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                        string cailiaoming = gridView1.GetRowCellValue(i, "材料名称").ToString();
                        string bianma = gridView1.GetRowCellValue(i, "编码").ToString();
                        string danwei = gridView1.GetRowCellValue(i, "单位").ToString();
                        string shuliang = gridView1.GetRowCellValue(i, "数量").ToString();

                        if (xinghao.Contains("|"))
                        {
                            string[] b = xinghao.Split('|');
                            lei = b[1];
                        }
                        else
                        {
                            lei = xinghao;
                        }

                        double zongzhongliang = Convert.ToDouble(shuliang) * Convert.ToDouble(txt_jiagongshuliang.Text);

                        string sql = "insert into db_caigoucailiao(项目名称,工作令号,设备名称,图号,名称,材料名称,型号,编码,单位,数量,总重量,时间,编写人,类型,要求到货日期,序号,料单类型) values('" + xiangmu + "','" + linghao + "','" + shebeiming + "','" + tuhao + "','" + mingcheng + "','" + cailiaoming + "','" + xinghao + "','" + bianma + "','" + danwei + "','" + shuliang + "','" + zongzhongliang + "','" + DateTime.Now + "','" + yonghu + "','" + lei + "','" + timedaohuo + "','" + xuhao + "','机修件零件')";
                        ret = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

                    }
                    if(ret != "")
                    {
                        MessageBox.Show("新增零件材料成功！", "提示");
                        this.Close();
                    }

                }
                if (leixing == "机修件组件")
                {
                    string ret = "";
                    DateTime timedaohuo = DateTime.Now.AddDays(5);

                    int[] a = gridView1.GetSelectedRows();

                    foreach (int i in a)
                    {
                        string shuliang = gridView1.GetRowCellValue(i, "数量").ToString();
                        if (shuliang == "")
                        {
                            MessageBox.Show("请填写第" + (i + 1) + "材料的数量或重量！", "提示");
                            return;
                        }
                    }

                    foreach (int i in a)
                    {
                        string lei;
                        string xinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                        string xiangmu = gridView1.GetRowCellValue(i, "项目名称").ToString();
                        string linghao = gridView1.GetRowCellValue(i, "工作令号").ToString();
                        string shebeiming = gridView1.GetRowCellValue(i, "设备名称").ToString();
                        string tuhao = gridView1.GetRowCellValue(i, "图号").ToString();
                        string mingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                        string cailiaoming = gridView1.GetRowCellValue(i, "材料名称").ToString();
                        string bianma = gridView1.GetRowCellValue(i, "编码").ToString();
                        string danwei = gridView1.GetRowCellValue(i, "单位").ToString();
                        string shuliang = gridView1.GetRowCellValue(i, "数量").ToString();

                        if (xinghao.Contains("|"))
                        {
                            string[] b = xinghao.Split('|');
                            lei = b[1];
                        }
                        else
                        {
                            lei = xinghao;
                        }

                        double zongzhongliang = Convert.ToDouble(shuliang) * Convert.ToDouble(txt_jiagongshuliang.Text);

                        string sql = "insert into db_caigoucailiao(项目名称,工作令号,设备名称,图号,名称,材料名称,型号,编码,单位,数量,总重量,时间,编写人,类型,要求到货日期,序号,time,料单类型,组件定位) values('" + xiangmu + "','" + linghao + "','" + shebeiming + "','" + tuhao + "','" + mingcheng + "','" + cailiaoming + "','" + xinghao + "','" + bianma + "','" + danwei + "','" + shuliang + "','" + zongzhongliang + "','" + DateTime.Now + "','" + yonghu + "','" + lei + "','" + timedaohuo + "','" + xuhao + "','" + shijian + "','机修件组件','" + dingweiNumber + "')";
                        ret = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

                    }
                    if(ret != "")
                    {
                        MessageBox.Show("新增组件材料成功！", "提示");
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("不可新增材料！", "提示");
                return;
            }
            
        }

        private void 清空材料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            dtcailiao.Rows.Clear();
        }

        private void 查询材料ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = txt_tuhao.Text.Trim();
            string b = txt_mingcheng.Text.Trim();

            string sql = "SELECT 图号,名称,材料名称,型号,编码,单位,数量 FROM db_caigoucailiao where 图号='" + a + "' and 名称='" + b + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret == "")
            {
                MessageBox.Show("该自制零部件还没有已设置的工序", "提示");
                return;
            }
            else//以前做过此类型的工序
            {
                Formchaxuncailiao form = new Formchaxuncailiao();
                form.tuhao = a;
                form.mingcheng = b;
                form.gongzuolinghao = txt_gonglinghao.Text;
                form.xiangmumincgheng = txt_jiagong.Text;
                form.shebeiming = txt_danhao.Text;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    dtcailiao = form.dt;
                    dt.Merge(dtcailiao, true, MissingSchemaAction.Ignore);
                    gridControl1.DataSource = dt;
                }
            }

        }

        private void txt_shuliang20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang20.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang20.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang20.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang21.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang21.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang21.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang22.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang22.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang22.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang23.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang23.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang23.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang24.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang24.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang24.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txt_shuliang25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_shuliang25.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_shuliang25.Text, out oldf);

                    b2 = float.TryParse(txt_shuliang25.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void shebei24_Click_1(object sender, EventArgs e)
        {
            shebei24.Text = "";
            shebei24.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox44.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei24.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei24.Items.Add(a);
                    shebei24.SelectedIndex = 0;
                }
            }
        }

        private void shebei25_Click_1(object sender, EventArgs e)
        {
            shebei25.Text = "";
            shebei25.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + comboBox45.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (shebei25.Items.Cast<object>().All(x => x.ToString() != a))
                        shebei25.Items.Add(a);
                    shebei25.SelectedIndex = 0;
                }
            }
        }

        #endregion

        /// <summary>
        /// 人工价格计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            #region 老公式
            //FormJisuanJiage form = new FormJisuanJiage();
            //form.gongxu1 = comboBox1.Text.Trim();
            //form.gongxu2 = comboBox2.Text.Trim();
            //form.gongxu3 = comboBox3.Text.Trim();
            //form.gongxu4 = comboBox4.Text.Trim();
            //form.gongxu5 = comboBox5.Text.Trim();
            //form.gongxu6 = comboBox6.Text.Trim();
            //form.gongxu7 = comboBox7.Text.Trim();
            //form.gongxu8 = comboBox8.Text.Trim();
            //form.gongxu9 = comboBox9.Text.Trim();
            //form.gongxu10 = comboBox10.Text.Trim();
            //form.gongxu11 = comboBox11.Text.Trim();
            //form.gongxu12 = comboBox12.Text.Trim();
            //form.gongxu13 = comboBox13.Text.Trim();
            //form.gongxu14 = comboBox14.Text.Trim();
            //form.gongxu15 = comboBox15.Text.Trim();
            //form.gongxu16 = comboBox16.Text.Trim();
            //form.gongxu17 = comboBox17.Text.Trim();
            //form.gongxu18 = comboBox18.Text.Trim();
            //form.gongxu19 = comboBox19.Text.Trim();
            //form.gongxu20 = comboBox20.Text.Trim();
            //form.gongxu21 = comboBox46.Text.Trim();
            //form.gongxu22 = comboBox47.Text.Trim();
            //form.gongxu23 = comboBox48.Text.Trim();
            //form.gongxu24 = comboBox49.Text.Trim();
            //form.gongxu25 = comboBox50.Text.Trim();
            //form.ShowDialog();

            //if (form.DialogResult == DialogResult.OK)
            //{
            //    txt_gx1.Text = form.gx1;
            //    txt_gx2.Text = form.gx2;
            //    txt_gx3.Text = form.gx3;
            //    txt_gx4.Text = form.gx4;
            //    txt_gx5.Text = form.gx5;
            //    txt_gx6.Text = form.gx6;
            //    txt_gx7.Text = form.gx7;
            //    txt_gx8.Text = form.gx8;
            //    txt_gx9.Text = form.gx9;
            //    txt_gx10.Text = form.gx10;
            //    txt_gx11.Text = form.gx11;
            //    txt_gx12.Text = form.gx12;
            //    txt_gx13.Text = form.gx13;
            //    txt_gx14.Text = form.gx14;
            //    txt_gx15.Text = form.gx15;
            //    txt_gx16.Text = form.gx16;
            //    txt_gx17.Text = form.gx17;
            //    txt_gx18.Text = form.gx18;
            //    txt_gx19.Text = form.gx19;
            //    txt_gx20.Text = form.gx20;
            //    txt_gx21.Text = form.gx21;
            //    txt_gx22.Text = form.gx22;
            //    txt_gx23.Text = form.gx23;
            //    txt_gx24.Text = form.gx24;
            //    txt_gx25.Text = form.gx25;
            //}
            #endregion

            Formgongshi form = new Formgongshi();
            form.Show();
        }

    }
}
