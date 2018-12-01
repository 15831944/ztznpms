using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.工序管理;
using ztznpms.UI.查询项目;
using ztznpms.UI.检验;

namespace ztznpms.UI.项目管理
{
    public partial class FormZiZhiqingdan : Form
    {
        public string yonghu;

        private string leixing;
        private string lujing;

        public string xiangmumingcheng1;
        public string shebeimingcheng1;
        public string gongzuolinghao1;
        public string shijian1;

        //GridPrinter gridPrinter;

        string sqlsql;
        public FormZiZhiqingdan()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            //this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();

        }
        
        //private delegate void SetDtCallback(DataTable dt);
        //private void SetDT(DataTable dt)
        //{
        //    // InvokeRequired需要比较调用线程ID和创建线程ID
        //    // 如果它们不相同则返回true
        //    if (this.InvokeRequired)
        //    {
        //        SetDtCallback d = new SetDtCallback(SetDT);
        //        this.Invoke(d, new object[] { dt });
        //    }
        //    else
        //    {
        //        this.dataGridView1.DataSource = dt;
        //    }
        //}


        private void FormZiZhiqingdan_Load(object sender, EventArgs e)
        {

            reload();
            DrawRowIndicator(gridView1, 50);
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
        private void reload()
        {
            try
            {

                if(xiangmumingcheng1 != "")
                {
                     sqlsql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改,序号,交货日期 from db_xiangmu where 项目名称='" + xiangmumingcheng1 + "'and 设备名称='" + shebeimingcheng1 + "'and 工作令号='" + gongzuolinghao1 + "' and 时间='" + shijian1 + "'";
                }
                if(xiangmumingcheng1 == "")
                {
                     sqlsql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改,序号,交货日期 from db_xiangmu where 设备名称='" + shebeimingcheng1 + "'and 工作令号='" + gongzuolinghao1 + "' and 时间='" + shijian1 + "'";
                }

                DataTable dt = SQLhelp.GetDataTable(sqlsql, CommandType.Text);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    string sqll = "select 技术更改 from db_xiangmu where 项目名称='" + xiangmumingcheng1 + "'and 设备名称='" + shebeimingcheng1 + "'and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";
                    string rett = Convert.ToString(SQLhelp.ExecuteScalar(sqll, CommandType.Text));

                    if (rett != "")
                    {
                        if (rett == "0" || rett == "1")
                        {
                            dr["技术更改"] = 0;
                        }
                    }
                }


                #region 计算时间差额
                ////计算时间差额
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    //string sql = "select * from db_jihuadan";

                //    //DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                //    DataRow dr = dt.Rows[i];

                //    //DataRow dr = hang(i);

                //    string s1 = "select 要求完成 from db_jihuadan where  工令号='" + dr["工令号"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "'and 图号='" + dr["图号"].ToString() + "'";
                //    string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                //    if (r1 != "")
                //    {
                //        DateTime time1 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                //        DateTime time11 = Convert.ToDateTime(time1.AddDays(1).AddSeconds(-1));

                //        DateTime time2 = DateTime.Now;
                //        TimeSpan time3 = time11 - time2;
                //        double time4 = time3.TotalDays;
                //        int time5 = Convert.ToInt32(time4);
                //        dt.Rows[i]["时间差额"] = time5;

                //        string genxin = "update db_jihuadan set 时间差额='" + time5 + "' where  工令号='" + dr["工令号"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "'and 图号='" + dr["图号"].ToString() + "'";
                //        int genxin1 = SQLhelp.ExecuteNonquery(genxin, CommandType.Text);
                //    }
                //}
                #endregion

                //Thread thread = new Thread(() =>
                //{

                #region 目前到达工序

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                //    DataRow dr = dt.Rows[i];

                //    string strSql1 = "select 工序顺序 from db_gongxu1 where 序号='" + dr["序号"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                //    string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                //    if (exist != "")
                //    {
                //        //string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                //        string strSql = "select * from db_gongxu1 where getdate() > 开始时间 and 序号='" + dr["序号"].ToString() + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                //        string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                //        if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                //        {
                //            dt.Rows[i]["目前到达工序"] = "工艺已编写,待排产";
                //            string SQl1 = "update db_xiangmu set 目前到达工序='工艺已编写,待排产' where 序号='" + dr["序号"].ToString() + "'";
                //            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

                //            //Thread thread1 = new Thread(() =>
                //            //{
                //            //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                //            //        string SQL2 = "update tb_caigouliaodan set 当前状态=' ' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                //            //        string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                //            //});
                //            //thread1.IsBackground = false;
                //            //thread1.Start();

                //        }
                //        else  //开始进行项目
                //        {
                            //if (panduan(dr["序号"].ToString()) != "")//正在进行某项工序
                //            {
                //                string s1 = "select max(工序顺序) from db_gongxu1 where getdate() > 开始时间 and 序号='" + dr["序号"].ToString() + "'";
                //                string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                //                int aa = Convert.ToInt32(shunxu1);
                //                string s2 = "select 工序名称 from db_gongxu1 where 工序顺序 = '" + aa + "' and 序号='" + dr["序号"].ToString() + "'";
                //                string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                //                dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1 + " 已开始";
                //                string gx_1 = "工序" + shunxu1 + ":" + mingcheng1 + " 已开始";

                //                string SQl2 = "update db_xiangmu set 目前到达工序='" + gx_1 + "' where 序号='" + dr["序号"].ToString() + "'";
                //                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));

                //                //Thread thread1 = new Thread(() =>
                //                //{
                //                //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                //                //        string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                //                //        string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                //                //});
                //                //thread1.IsBackground = false;
                //                //thread1.Start();

                //            }
                //            else//工序完成，正在流转，即将进行入下一道工序
                //            {
                //                string s3 = "select min(工序顺序) from db_gongxu1 where 结束时间 IS NULL and 开始时间 IS NULL and 序号='" + dr["序号"].ToString() + "'";
                //                string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                //                if (shunxu2 != "")
                //                {
                //                    string shunxu22 = (Convert.ToInt32(shunxu2) - 1).ToString();

                //                    string s4 = "select 工序名称 from db_gongxu1 where and 工序顺序 ='" + shunxu22 + "' and 序号='" + dr["序号"].ToString() + "'";
                //                    string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                //                    dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu22 + ":" + mingcheng2 + " 已结束";

                //                    string gx_2 = "即将进入工序" + shunxu22 + ":" + mingcheng2 + " 已结束";

                //                    string SQl3 = "update db_xiangmu set 目前到达工序='" + gx_2 + "' where 序号='" + dr["序号"].ToString() + "'";
                //                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                //                    //Thread thread1 = new Thread(() =>
                //                    //{

                //                    //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                //                    //        string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                //                    //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                //                    //});
                //                    //thread1.IsBackground = false;
                //                    //thread1.Start();
                //                }
                //                else
                //                {
                //                    dt.Rows[i]["目前到达工序"] = "工序结束待检验";
                //                    string gx_3 = "工序结束待检验";

                //                    string SQl4 = "update db_xiangmu set 目前到达工序='" + gx_3 + "' where  序号='" + dr["序号"].ToString() + "'";
                //                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));


                //                    //Thread thread1 = new Thread(() =>
                //                    //{
                //                    //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                //                    //        string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                //                    //        string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                //                    //});
                //                    //thread1.IsBackground = false;
                //                    //thread1.Start();
                //                }



                //            }

                //        }

                //    }
                //    else
                //    {
                //        dt.Rows[i]["目前到达工序"] = "";

                //        string SQl5 = "update db_xiangmu set 目前到达工序=' ' where 序号='" + dr["序号"].ToString() + "'";
                //        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                //        //Thread thread1 = new Thread(() =>
                //        //{
                //        //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                //        //    string SQL2 = "update tb_caigouliaodan set 当前状态=' ' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                //        //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                //        //});
                //        //thread1.IsBackground = false;
                //        //thread1.Start();
                //    }


                //}

                #endregion


                //});
                //thread.IsBackground = false;
                //thread.Start();

                //System.Threading.Thread.Sleep(1000);
                //剩余加工时间
                //Thread thread2 = new Thread(() =>
                //{
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    //DataRow dr = hang(i);

                //    DataRow dr = dt.Rows[i];

                //    string strSql1 = "select 工序顺序 from db_gongxu1 where  图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";
                //    string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                //    if (exist != "")
                //    {
                //        string a = dr[5].ToString();//获取图号
                //                                    //string strSql = "select getdate() from db_gongxu where  工令号='" + a + "'";
                //        string strSql = "select 要求到货日期 from db_xiangmu where 图号='" + a + "'";
                //        DateTime b = Convert.ToDateTime(SQLhelp.ExecuteScalar(strSql, CommandType.Text));
                //        DateTime c = DateTime.Now;
                //        TimeSpan m = b - c;
                //        double g = m.TotalMinutes;
                //        string f = m.Days + "天" + m.Hours + "小时" + m.Minutes + "分钟";
                //        if (g < 0)   //交货日期 < 现在的时间（超过了加工的时间）1.没有加工完成 2.加工完成 
                //        {

                //            string s1 = "select max(工序顺序) from db_shunxu where 图号='" + a + "'";
                //            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));

                //            string s2 = "select 结束时间 from db_gongxu1 where 工序顺序='" + shunxu1 + "' and 图号='" + a + "'";
                //            string shijian1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));

                //            //1.没有加工完成
                //            if (shijian1 == "")
                //            {
                //                //计算超过的时间
                //                TimeSpan m1 = c - b;
                //                string shijian2 = m1.Days + "天" + m1.Hours + "小时" + m1.Minutes + "分钟";
                //                dt.Rows[i]["剩余加工时间"] = "已超过" + shijian2 + "未完成";
                //            }
                //            //2.加工完成
                //            else
                //            {
                //                string s3 = "select 结束时间 from db_gongxu1 where 工序顺序='" + shunxu1 + "' and 图号='" + a + "'";
                //                DateTime shijian5 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s3, CommandType.Text));
                //                if (shijian5 < b)
                //                {
                //                    dt.Rows[i]["剩余加工时间"] = "全部结束";
                //                }
                //                else
                //                {
                //                    DateTime shijian3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                //                    TimeSpan m3 = shijian3 - b;
                //                    string shijian4 = m3.Days + "天" + m3.Hours + "小时" + m3.Minutes + "分钟";
                //                    dt.Rows[i]["剩余加工时间"] = "超过" + shijian4 + "加工完成";
                //                }


                //            }

                //        }
                //        else  //交货日期 > 现在的时间(还有剩余的时间可以加工)
                //        {
                //            dt.Rows[i]["剩余加工时间"] = f;
                //        }
                //    }
                //    else
                //    {
                //        dt.Rows[i]["剩余加工时间"] = "未设置工序";
                //    }

                //}
                //});
                //thread2.IsBackground = false;
                //thread2.Start();

                ////表插入后面的列

                //dt.Columns.Add("工序1");
                //dt.Columns.Add("工序2");
                //dt.Columns.Add("工序3");
                //dt.Columns.Add("工序4");
                //dt.Columns.Add("工序5");
                //dt.Columns.Add("工序6");
                //dt.Columns.Add("工序7");
                //dt.Columns.Add("工序8");
                //dt.Columns.Add("工序9");
                //dt.Columns.Add("工序10");

                //dt.Columns.Add("工序11");
                //dt.Columns.Add("工序12");
                //dt.Columns.Add("工序13");
                //dt.Columns.Add("工序14");
                //dt.Columns.Add("工序15");
                //dt.Columns.Add("工序16");
                //dt.Columns.Add("工序17");
                //dt.Columns.Add("工序18");
                //dt.Columns.Add("工序19");
                //dt.Columns.Add("工序20");

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    DataRow drtotal = dt.Rows[i];
                //    string a = drtotal[5].ToString();//图号
                //    string b = drtotal[6].ToString();//名称
                //                                     //查工序表中工序号为指定工令的工序
                //    DataTable dtgongxu = jvti(a, b);//指定图号、名称查询工序表当中数据
                //    for (int j = 0; j < dtgongxu.Rows.Count; j++)
                //    {
                //        DataRow drgx = dtgongxu.Rows[j];
                //        if (drgx["工序顺序"].ToString() == "1")
                //        {
                //            drtotal["工序1"] = drgx["工序名称"];

                //        }
                //        if (drgx["工序顺序"].ToString() == "2")
                //        {
                //            drtotal["工序2"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "3")
                //        {
                //            drtotal["工序3"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "4")
                //        {
                //            drtotal["工序4"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "5")
                //        {
                //            drtotal["工序5"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "6")
                //        {
                //            drtotal["工序6"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "7")
                //        {
                //            drtotal["工序7"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "8")
                //        {
                //            drtotal["工序8"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "9")
                //        {
                //            drtotal["工序9"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "10")
                //        {
                //            drtotal["工序10"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "11")
                //        {
                //            drtotal["工序11"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "12")
                //        {
                //            drtotal["工序12"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "13")
                //        {
                //            drtotal["工序13"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "14")
                //        {
                //            drtotal["工序14"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "15")
                //        {
                //            drtotal["工序15"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "16")
                //        {
                //            drtotal["工序16"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "17")
                //        {
                //            drtotal["工序17"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "18")
                //        {
                //            drtotal["工序18"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "19")
                //        {
                //            drtotal["工序19"] = drgx["工序名称"];
                //        }
                //        if (drgx["工序顺序"].ToString() == "20")
                //        {
                //            drtotal["工序20"] = drgx["工序名称"];
                //        }


                //    }
                //}

                //this.dataGridView1.DataSource = dt;
                gridControl1.DataSource = dt;

                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["附件名称"];
                //    this.dataGridView1.CurrentCell.Style.ForeColor = Color.Blue;
                //}

                //Colorset();
            }
            catch
            {

            }

        }


        private string panduan(string a)
        {
            string sql = "select 工序名称 from db_gongxu1 where getdate()>= 开始时间 and 结束时间 IS NULL and 序号='" + a + "'";
            string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            return result;
        }

        private DataTable jvti(string a, string b)
        {
            string s1 = "select * from db_gongxu1 where 图号='" + a + "' and 名称='" + b + "'";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            return dt;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                System.Drawing.Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
        private void Colorset()
        {
            //int row = dataGridView1.Rows.Count;//得到总行数    
            //for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            //{
            //    string str = Convert.ToString(dataGridView1.Rows[i].Cells["剩余加工时间"].Value);//取到当前单元格的数据
            //    string s1 = "加工";
            //    string s2 = "已";
            //    if (str.Contains(s1))
            //    {
            //        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["剩余加工时间"]; //将单元格定位为当前单元格
            //        this.dataGridView1.CurrentCell.Style.ForeColor = Color.Green;// 
            //    }
            //    else if (str.Contains(s2))
            //    {
            //        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["剩余加工时间"]; //将单元格定位为当前单元格
            //        this.dataGridView1.CurrentCell.Style.ForeColor = Color.Red;// 
            //    }


            //}
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        /// <summary>
        /// 设置项目工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            FormADDgongxu add = new FormADDgongxu();

            add.addxiangmuming= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            add.addgonglinghao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
            add.addshebeimingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
            add.addtuhao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
            add.addmingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
            add.addxuhao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();
            add.fujianName= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["附件名称"]).ToString();
            add.addjiaohuoriqi = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["交货日期"]).ToString();
            add.yonghu = yonghu;
            add.shijian111 = shijian1;

            add.flag = "自制加工";
            add.Show();

            if (add.DialogResult == DialogResult.OK)
            {
                this.reload();
            }
        }

        /// <summary>
        /// 增加项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormZengjiaxiangmu add = new FormZengjiaxiangmu();

            add.ming = xiangmumingcheng1;
            add.ling = gongzuolinghao1;
            add.cheng = shebeimingcheng1;

            add.ShowDialog();

            if (add.DialogResult == DialogResult.OK)
            {

                this.reload();

            }
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //switch (RSS)
            //{
            //    case DialogResult.Yes:
            //        for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
            //        {
            //            int ID = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
            //            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);

            //            string s1 = "select 图号 from db_xiangmu where id='" + ID.ToString() + "'";
            //            string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));

            //            string s2 = "select 名称 from db_xiangmu where id='" + ID.ToString() + "'";
            //            string r2 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));

            //            string s3 = "select 设备名称 from db_xiangmu where id='" + ID.ToString() + "'";
            //            string r3 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

            //            string ss3 = "select 项目名称 from db_xiangmu where id='" + ID.ToString() + "'";
            //            string rr3 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

            //            string sql = "delete from db_xiangmu where id='" + ID.ToString() + "' ";
            //            int s = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

            //            string s4 = "delete from db_gongxu1 where 图号='" + r1 + "' and 名称='" + r2 + "' and 设备名称='" + r3 + "' and 项目名称='"+ rr3+"'";
            //            int r4 = Convert.ToInt32(SQLhelp.ExecuteNonquery(s4, CommandType.Text));

            //            string s5 = "delete from db_shunxu where 图号='" + r1 + "' and 名称='" + r2 + "'  and 设备名称='" + r3 + "' and 项目名称='" + rr3 + "'";
            //            int r5 = Convert.ToInt32(SQLhelp.ExecuteNonquery(s5, CommandType.Text));

            //        }
            //        MessageBox.Show("成功删除选中行数据！", "提示");
            //        break;
            //    case DialogResult.No:
            //        MessageBox.Show("删除数据失败！", "提示");
            //        break;
            //}

            //reload();
        }

        private void 详细工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formxiangxigongxu gx = new Formxiangxigongxu();

            //string a = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            //string b = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            //string c = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            //string d = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();


            //string a = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
            //string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
            //string c = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            //string d = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();

            string f = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();

            //gx.gxtuhao = a;
            //gx.gxmingcheng1 = b;
            //gx.gxxiangmu1 = c;
            //gx.gxshebeiming1 = d;
            gx.xuhao1 = f;
            gx.flag = "自制加工";
            gx.Show();

        }

        /// <summary>
        /// 查看图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string fujian = dataGridView1.CurrentRow.Cells["附件名称"].Value.ToString();
                string fujian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["附件名称"]).ToString();
                if (fujian != "")
                {
                    string a = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
                    string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
                    //string c = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();


                    string chaxun11 = "select 附件类型 from db_xiangmu where  附件名称='" + fujian + "' and 名称='" + b + "'and 图号='" + a + "'";
                    leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                    byte[] mypdffile = null;
                    //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";
                    string consql= "select 附件 from db_xiangmu where 图号='" + a + "'and 名称='" + b + "' and  附件名称='" + fujian + "' ";
                    mypdffile = SQLhelp.duqu(consql, CommandType.Text);

                    //SqlConnection con = new SqlConnection(ConStr);
                    //SqlCommand cmd = new SqlCommand("", con);
                    //cmd.CommandText = "select 附件 from db_xiangmu where 图号='" + a + "'and 名称='" + b + "' and  附件名称='" + fujian + "' ";
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
                        //Random ran = new Random();
                        //int RandKey = ran.Next(0, 999999999);
                        //string suijishu = RandKey.ToString();
                        string aaaa = System.Environment.CurrentDirectory;
                        //lujing = aaaa + "\\" + b + " 和 "+ a + "和" + "." + leixing;
                        lujing = aaaa + "\\" + b + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();
                    }
                    catch
                    {

                    }
                    this.Cursor = Cursors.Default;

                    System.Diagnostics.Process.Start(lujing);

                }
                if (fujian == "")
                {
                    MessageBox.Show("技术部还未上传该图纸！");
                    return;
                }
            }
            catch
            {

            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FormXiangtongtuhao form = new FormXiangtongtuhao();
            form.ShowDialog();
        }

        private void FormZiZhiqingdan_Shown(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查看检验结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查看检验结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count <= 0)//判断是否选中要删除的行
            //{
            //    MessageBox.Show("请选中行！");
            //    return;
            //}
            //string shijian = dataGridView1.CurrentRow.Cells["检验记录表上传时间"].Value.ToString();
            string shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["检验记录表上传时间"]).ToString();
            if (shijian != "")
            {
                string a = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
                string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
                //string c = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();


                string chaxun11 = "select 检验结果附件类型 from db_xiangmu where  检验记录表上传时间='" + shijian + "' and 名称='" + b + "'and 图号='" + a + "'";
                leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                byte[] mypdffile = null;
                //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";
                string consql= "select 检验结果附件 from db_xiangmu where 图号='" + a + "'and 名称='" + b + "' and  检验记录表上传时间='" + shijian + "' ";
                mypdffile = SQLhelp.duqu(consql, CommandType.Text);

                //SqlConnection con = new SqlConnection(ConStr);
                //SqlCommand cmd = new SqlCommand("", con);
                //cmd.CommandText = "select 检验结果附件 from db_xiangmu where 图号='" + a + "'and 名称='" + b + "' and  检验记录表上传时间='" + shijian + "' ";
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
                    //Random ran = new Random();
                    //int RandKey = ran.Next(0, 999999999);
                    //string suijishu = RandKey.ToString();
                    string aaaa = System.Environment.CurrentDirectory;
                    //lujing = aaaa + "\\" + b + " 和 "+ a + "和" + "." + leixing;
                    lujing = aaaa + "\\" + b + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                }
                catch
                {

                }
                this.Cursor = Cursors.Default;

                System.Diagnostics.Process.Start(lujing);

            }
            if (shijian == "")
            {
                MessageBox.Show("检验员还未上传检验记录表！");
                return;
            }
        }

        /// <summary>
        /// 修改编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //int r = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    string b = dataGridView1.Rows[i].Cells["工作令号"].EditedFormattedValue.ToString();
            //    string b1 = dataGridView1.Rows[i].Cells["项目名称"].EditedFormattedValue.ToString();
            //    string b2 = dataGridView1.Rows[i].Cells["设备名称"].EditedFormattedValue.ToString();
            //    string b3 = dataGridView1.Rows[i].Cells["时间"].EditedFormattedValue.ToString();
            //    //string b4 = dataGridView1.Rows[i].Cells["id"].EditedFormattedValue.ToString();
            //    string b5 = dataGridView1.Rows[i].Cells["编码"].EditedFormattedValue.ToString();


            //    string sql = "update db_xiangmu set 编码='" + b5 + "' where 项目名称 ='" + b1 + "' and 设备名称='" + b2 + "' and 项目名称='" + b1 + "' and 工作令号='" + b + "' and 时间='" + b3 + "'";

            //    r = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

            //}

            string sql = "update db_xiangmu set 设备编号='"+ txt_bianma.Text.Trim() +"' where 项目名称='"+ xiangmumingcheng1 +"' and 设备名称='"+ shebeimingcheng1 +"' and 工作令号='"+ gongzuolinghao1 +"' and 时间='"+ shijian1 +"'";
            int ret = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

            if (ret > 0)
            {
                MessageBox.Show("设备编号修改成功！", "提示");
                reload();
            }
            else
            {
                MessageBox.Show("修改失败！", "提示");
            }


        }


        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            //string a = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            //string b = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            //string c = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            //string d = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();

            //string sql = "select * from db_gongxu1 where 图号='" + a + "' and 名称='" + b + "'";
            //string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            //if (ret == "")
            //{
            //    MessageBox.Show("该自制零部件还没有已设置的工序", "提示");
            //    return;
            //}
            //else//以前做过此类型的工序
            //{
            //    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            //}
        }

        //private void toolStripButton6_Click_1(object sender, EventArgs e)
        //{
        //    printPreviewDialog1.Document = this.printDocument1; //设置预览文档
        //    printPreviewDialog1.UseAntiAlias = false; //设置UseAntiAlias属性为true，开启防锯齿功能
        //    printPreviewDialog1.ShowDialog();//使用ShowDialog方法，显示预览窗口
        //}

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    if (gridPrinter == null)
        //    {
        //        gridPrinter = new GridPrinter(dataGridView1, printDocument1, true, true, "报表", dataGridView1.DefaultCellStyle.Font, Color.Black, true);
        //    }

        //    bool more = gridPrinter.DrawDataGridView(e.Graphics);
        //    if (more == true)
        //        e.HasMorePages = true;
        //}

        //private void toolStripButton7_Click(object sender, EventArgs e)
        //{
        //    //设置printDialog控件的Document属性，设置操作文档
        //    printDialog1.Document = this.printDocument1;
        //    //启用"打印到文件"复选框
        //    printDialog1.AllowPrintToFile = true;
        //    //显示“当前项”按钮
        //    printDialog1.AllowCurrentPage = true;
        //    //启用"选择按钮"
        //    printDialog1.AllowSelection = true;
        //    //启用"页"按钮
        //    printDialog1.AllowSomePages = true;
        //    DialogResult result = printDialog1.ShowDialog();

        //    // If the result is OK then print the document.
        //    if (result == DialogResult.OK)
        //    {
        //        printDocument1.Print();
        //    }
        //}

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            if (e.Column.FieldName == "附件名称")//设背景  
            {
                //int pointID = (gridView1.GetRow(e.RowHandle) as object).BgColor;  
                e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            Formshebeicailiaoshengou form = new Formshebeicailiaoshengou();
            form.yonghu = yonghu;
            form.shijian = shijian1;
            form.gonglinghao = gongzuolinghao1;
            form.shebeimingcheng = shebeimingcheng1;
            form.liaodanleiixng = "项目";
            form.ShowDialog();
        }
    }

    #region 打印
    /*
    //新建一个GridPrinter类
    /// <summary>
    /// DataGridView打印类
    /// </summary>
    public class GridPrinter
    {
        // the grid to print
        private DataGridView dataGridView;

        // the PrintDocument
        private PrintDocument printDocument;

        // center printout?
        private bool centerOnPage;

        // has a title?
        private bool hasTitle;

        // title
        private string title;

        // font
        private Font titleFont;

        // title color
        private Color titleColor;

        // use paging?
        private bool paging;

        // row printing
        static int currentRow;

        // page printing
        static int pageNumber;

        // page width
        private int pageWidth;

        // page height
        private int pageHeight;

        // left margin
        private int leftMargin;

        // top margin
        private int topMargin;

        // right margin
        private int rightMargin;

        // bottom margin
        private int bottomMargin;

        // y location placeholder
        private float currentY;

        // grid sizes
        private float rowHeaderHeight;
        private List<float> rowsHeight;
        private List<float> columnsWidth;
        private float dataGridViewWidth;

        // column stop points
        private List<int[]> mColumnPoints;
        private List<float> mColumnPointsWidth;
        private int mColumnPoint;

        public GridPrinter(DataGridView objDataGridView, PrintDocument objPrintDocument, bool bCenterOnPage, bool bHasTitle, string sTitle, Font objTitleFont, Color objTitleColor, bool bPaging)
        {
            dataGridView = objDataGridView;
            printDocument = objPrintDocument;
            centerOnPage = bCenterOnPage;
            hasTitle = bHasTitle;
            title = sTitle;
            titleFont = objTitleFont;
            titleColor = objTitleColor;
            paging = bPaging;

            pageNumber = 0;

            rowsHeight = new List<float>();
            columnsWidth = new List<float>();

            mColumnPoints = new List<int[]>();
            mColumnPointsWidth = new List<float>();

            if (!printDocument.DefaultPageSettings.Landscape)
            {
                pageWidth = printDocument.DefaultPageSettings.PaperSize.Width;
                pageHeight = printDocument.DefaultPageSettings.PaperSize.Height;
            }
            else
            {
                pageHeight = printDocument.DefaultPageSettings.PaperSize.Width;
                pageWidth = printDocument.DefaultPageSettings.PaperSize.Height;
            }

            leftMargin = printDocument.DefaultPageSettings.Margins.Left;
            topMargin = printDocument.DefaultPageSettings.Margins.Top;
            rightMargin = printDocument.DefaultPageSettings.Margins.Right;
            bottomMargin = printDocument.DefaultPageSettings.Margins.Bottom;

            currentRow = 0;
        }

        // calculate printing metrics
        private void Calculate(Graphics g)
        {
            if (pageNumber == 0)
            {
                SizeF tmpSize = new SizeF();
                Font tmpFont;
                float tmpWidth;

                dataGridViewWidth = 0;
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    tmpFont = dataGridView.ColumnHeadersDefaultCellStyle.Font;
                    if (tmpFont == null)
                        tmpFont = dataGridView.DefaultCellStyle.Font;

                    tmpSize = g.MeasureString(dataGridView.Columns[i].HeaderText, tmpFont);
                    tmpWidth = tmpSize.Width;
                    rowHeaderHeight = tmpSize.Height;

                    for (int j = 0; j < dataGridView.Rows.Count; j++)
                    {
                        tmpFont = dataGridView.Rows[j].DefaultCellStyle.Font;
                        if (tmpFont == null)
                            tmpFont = dataGridView.DefaultCellStyle.Font;

                        tmpSize = g.MeasureString("Anything", tmpFont);
                        rowsHeight.Add(tmpSize.Height);

                        tmpSize = g.MeasureString(dataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), tmpFont);
                        if (tmpSize.Width > tmpWidth)
                            tmpWidth = tmpSize.Width;
                    }
                    if (dataGridView.Columns[i].Visible)
                        dataGridViewWidth += tmpWidth;
                    columnsWidth.Add(tmpWidth);
                }

                int k;

                int mStartPoint = 0;
                for (k = 0; k < dataGridView.Columns.Count; k++)
                    if (dataGridView.Columns[k].Visible)
                    {
                        mStartPoint = k;
                        break;
                    }

                int mEndPoint = dataGridView.Columns.Count;
                for (k = dataGridView.Columns.Count - 1; k >= 0; k--)
                    if (dataGridView.Columns[k].Visible)
                    {
                        mEndPoint = k + 1;
                        break;
                    }

                float mTempWidth = dataGridViewWidth;
                float mTempPrintArea = (float)pageWidth - (float)leftMargin - (float)rightMargin;

                if (dataGridViewWidth > mTempPrintArea)
                {
                    mTempWidth = 0.0F;
                    for (k = 0; k < dataGridView.Columns.Count; k++)
                    {
                        if (dataGridView.Columns[k].Visible)
                        {
                            mTempWidth += columnsWidth[k];
                            if (mTempWidth > mTempPrintArea)
                            {
                                mTempWidth -= columnsWidth[k];
                                mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                                mColumnPointsWidth.Add(mTempWidth);
                                mStartPoint = k;
                                mTempWidth = columnsWidth[k];
                            }
                        }
                        mEndPoint = k + 1;
                    }
                }

                mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                mColumnPointsWidth.Add(mTempWidth);
                mColumnPoint = 0;
            }
        }

        // header printing
        private void DrawHeader(Graphics g)
        {
            currentY = (float)topMargin;

            if (paging)
            {
                pageNumber++;
                string PageString = "Page " + pageNumber.ToString();

                StringFormat PageStringFormat = new StringFormat();
                PageStringFormat.Trimming = StringTrimming.Word;
                PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                PageStringFormat.Alignment = StringAlignment.Far;

                Font PageStringFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);

                RectangleF PageStringRectangle = new RectangleF((float)leftMargin, currentY, (float)pageWidth - (float)rightMargin - (float)leftMargin, g.MeasureString(PageString, PageStringFont).Height);

                g.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PageStringFormat);

                currentY += g.MeasureString(PageString, PageStringFont).Height;
            }

            if (hasTitle)
            {
                StringFormat TitleFormat = new StringFormat();
                TitleFormat.Trimming = StringTrimming.Word;
                TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                if (centerOnPage)
                    TitleFormat.Alignment = StringAlignment.Center;
                else
                    TitleFormat.Alignment = StringAlignment.Near;

                RectangleF TitleRectangle = new RectangleF((float)leftMargin, currentY, (float)pageWidth - (float)rightMargin - (float)leftMargin, g.MeasureString(title, titleFont).Height);

                g.DrawString(title, titleFont, new SolidBrush(titleColor), TitleRectangle, TitleFormat);

                currentY += g.MeasureString(title, titleFont).Height;
            }

            float CurrentX = (float)leftMargin;
            if (centerOnPage)
                CurrentX += (((float)pageWidth - (float)rightMargin - (float)leftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

            Color HeaderForeColor = dataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
            if (HeaderForeColor.IsEmpty)
                HeaderForeColor = dataGridView.DefaultCellStyle.ForeColor;
            SolidBrush HeaderForeBrush = new SolidBrush(HeaderForeColor);

            Color HeaderBackColor = dataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            if (HeaderBackColor.IsEmpty)
                HeaderBackColor = dataGridView.DefaultCellStyle.BackColor;
            SolidBrush HeaderBackBrush = new SolidBrush(HeaderBackColor);

            Pen TheLinePen = new Pen(dataGridView.GridColor, 1);

            Font HeaderFont = dataGridView.ColumnHeadersDefaultCellStyle.Font;
            if (HeaderFont == null)
                HeaderFont = dataGridView.DefaultCellStyle.Font;

            RectangleF HeaderBounds = new RectangleF(CurrentX, currentY, mColumnPointsWidth[mColumnPoint], rowHeaderHeight);
            g.FillRectangle(HeaderBackBrush, HeaderBounds);

            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            RectangleF CellBounds;
            float ColumnWidth;
            for (int i = (int)mColumnPoints[mColumnPoint].GetValue(0); i < (int)mColumnPoints[mColumnPoint].GetValue(1); i++)
            {
                if (!dataGridView.Columns[i].Visible) continue;

                ColumnWidth = columnsWidth[i];

                if (dataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right"))
                    CellFormat.Alignment = StringAlignment.Far;
                else if (dataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center"))
                    CellFormat.Alignment = StringAlignment.Center;
                else
                    CellFormat.Alignment = StringAlignment.Near;

                CellBounds = new RectangleF(CurrentX, currentY, ColumnWidth, rowHeaderHeight);

                g.DrawString(dataGridView.Columns[i].HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat);

                if (dataGridView.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                    g.DrawRectangle(TheLinePen, CurrentX, currentY, ColumnWidth, rowHeaderHeight);

                CurrentX += ColumnWidth;
            }

            currentY += rowHeaderHeight;
        }

        // common row printing function
        private bool DrawRows(Graphics g)
        {
            Pen TheLinePen = new Pen(dataGridView.GridColor, 1);

            Font RowFont;
            Color RowForeColor;
            Color RowBackColor;
            SolidBrush RowForeBrush;
            SolidBrush RowBackBrush;
            SolidBrush RowAlternatingBackBrush;

            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

            RectangleF RowBounds;
            float CurrentX;
            float ColumnWidth;
            while (currentRow < dataGridView.Rows.Count)
            {
                if (dataGridView.Rows[currentRow].Visible)
                {
                    RowFont = dataGridView.Rows[currentRow].DefaultCellStyle.Font;
                    if (RowFont == null)
                        RowFont = dataGridView.DefaultCellStyle.Font;

                    RowForeColor = dataGridView.Rows[currentRow].DefaultCellStyle.ForeColor;
                    if (RowForeColor.IsEmpty)
                        RowForeColor = dataGridView.DefaultCellStyle.ForeColor;
                    RowForeBrush = new SolidBrush(RowForeColor);

                    RowBackColor = dataGridView.Rows[currentRow].DefaultCellStyle.BackColor;
                    if (RowBackColor.IsEmpty)
                    {
                        RowBackBrush = new SolidBrush(dataGridView.DefaultCellStyle.BackColor);
                        RowAlternatingBackBrush = new SolidBrush(dataGridView.AlternatingRowsDefaultCellStyle.BackColor);
                    }
                    else
                    {
                        RowBackBrush = new SolidBrush(RowBackColor);
                        RowAlternatingBackBrush = new SolidBrush(RowBackColor);
                    }

                    CurrentX = (float)leftMargin;
                    if (centerOnPage)
                        CurrentX += (((float)pageWidth - (float)rightMargin - (float)leftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

                    RowBounds = new RectangleF(CurrentX, currentY, mColumnPointsWidth[mColumnPoint], rowsHeight[currentRow]);

                    if (currentRow % 2 == 0)
                        g.FillRectangle(RowBackBrush, RowBounds);
                    else
                        g.FillRectangle(RowAlternatingBackBrush, RowBounds);

                    for (int CurrentCell = (int)mColumnPoints[mColumnPoint].GetValue(0); CurrentCell < (int)mColumnPoints[mColumnPoint].GetValue(1); CurrentCell++)
                    {
                        if (!dataGridView.Columns[CurrentCell].Visible) continue;

                        if (dataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Right"))
                            CellFormat.Alignment = StringAlignment.Far;
                        else if (dataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Center"))
                            CellFormat.Alignment = StringAlignment.Center;
                        else
                            CellFormat.Alignment = StringAlignment.Near;

                        ColumnWidth = columnsWidth[CurrentCell];
                        RectangleF CellBounds = new RectangleF(CurrentX, currentY, ColumnWidth, rowsHeight[currentRow]);

                        g.DrawString(dataGridView.Rows[currentRow].Cells[CurrentCell].EditedFormattedValue.ToString(), RowFont, RowForeBrush, CellBounds, CellFormat);

                        if (dataGridView.CellBorderStyle != DataGridViewCellBorderStyle.None)
                            g.DrawRectangle(TheLinePen, CurrentX, currentY, ColumnWidth, rowsHeight[currentRow]);

                        CurrentX += ColumnWidth;
                    }
                    currentY += rowsHeight[currentRow];

                    if ((int)currentY > (pageHeight - topMargin - bottomMargin))
                    {
                        currentRow++;
                        return true;
                    }
                }
                currentRow++;
            }

            currentRow = 0;
            mColumnPoint++;

            if (mColumnPoint == mColumnPoints.Count)
            {
                mColumnPoint = 0;
                return false;
            }
            else
                return true;
        }


        // the main grid printing method
        public bool DrawDataGridView(Graphics g)
        {
            try
            {
                Calculate(g);
                DrawHeader(g);
                bool bContinue = DrawRows(g);
                return bContinue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        */
    #endregion
}

