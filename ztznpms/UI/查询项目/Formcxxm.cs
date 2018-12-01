using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.查询项目;
using ztznpms.UI.项目管理;

namespace ztznpms.UI.查询项目
{
    public partial class Formcxxm : DevExpress.XtraEditors.XtraForm
    {
        private string leixing;
        private string lujing;

        public string xiangmumingcheng2;
        public string shebeimingcheng2;
        public string gongzuolinghao2;
        public string shijian2;

        public Formcxxm()
        {
            InitializeComponent();            
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
        }

        private void Formcxxm_Load(object sender, EventArgs e)
        {
            string sql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,剩余加工时间,生产检验结果,检验结果备注,检验记录表上传时间,技术更改 from db_xiangmu where 项目名称='" + xiangmumingcheng2 + "'and 设备名称='" + shebeimingcheng2 + "'and 工作令号='" + gongzuolinghao2 + "' and 时间='"+shijian2+"'";

            reload(sql);

            DrawRowIndicator(gridView1, 30);
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
        //private delegate void SetDtCallback(DataTable dt);

        //private void SetDt(DataTable dt)
        //{
        //    // InvokeRequired需要比较调用线程ID和创建线程ID
        //    // 如果它们不相同则返回true
        //    if (this.dataGridView1.InvokeRequired)
        //    {
        //        SetDtCallback d = new SetDtCallback(SetDt);
        //        this.Invoke(d, new object[] { dt });
        //    }
        //    else
        //    {
        //        this.dataGridView1.DataSource = dt;
        //    }
        //}

        private void reload(string sql)
        {
            try
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                #region
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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                        DataRow dr = dt.Rows[i];

                        string strSql1 = "select 工序顺序 from db_gongxu1 where  图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                        string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                        if (exist != "")
                        {
                            string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                            string strSql = "select * from db_gongxu1 where getdate() > 开始时间 and 图号='" + a + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                            string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                            if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                            {
                                dt.Rows[i]["目前到达工序"] = "尚未开始";
                                string SQl1 = "update db_xiangmu set 目前到达工序='尚未开始' where 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));
                            }
                            else  //开始进行项目
                            {
                                if (panduan(a) != "")//正在进行某项工序
                                {
                                    string s1 = "select max(工序顺序) from db_gongxu1 where getdate() > 开始时间 and 图号 = '" + a + "'";
                                    string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                                    int aa = Convert.ToInt32(shunxu1);
                                    string s2 = "select 工序名称 from db_gongxu1 where 工序顺序 = '" + aa + "' and 图号= '" + a + "'";
                                    string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                                    dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                                    string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                                    string SQl2 = "update db_xiangmu set 目前到达工序='" + gx_1 + "' where 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'";
                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));
                                }
                                else//工序完成，正在流转，即将进行入下一道工序
                                {
                                    string s3 = "select min(工序顺序) from db_gongxu1 where 结束时间 IS NULL and 开始时间 IS NULL  and 图号='" + a + "'";
                                    string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                                    if (shunxu2 != "")
                                    {
                                        string s4 = "select 工序名称 from db_gongxu1 where 工序顺序 ='" + shunxu2 + "' and 图号='" + a + "'";
                                        string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                        dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                        string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                        string SQl3 = "update db_xiangmu set 目前到达工序='" + gx_2 + "' where 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'";
                                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));
                                    }
                                    else
                                    {
                                        dt.Rows[i]["目前到达工序"] = "全部结束";
                                        string gx_3 = "全部结束";

                                        string SQl4 = "update db_xiangmu set 目前到达工序='" + gx_3 + "' where 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'";
                                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));
                                    }



                                }

                            }

                        }
                        else
                        {
                            dt.Rows[i]["目前到达工序"] = "";
                            //string gx_4 = "未设置";

                            string SQl5 = "update db_xiangmu set 目前到达工序=' ' where 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'";
                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                        }


                    }

                //Thread thread = (new Thread(() =>
                //{
                //    //剩余加工时间
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        //DataRow dr = hang(i);

                //        DataRow dr = dt.Rows[i];

                //        string strSql1 = "select 工序顺序 from db_gongxu1 where  图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";
                //        string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                //        if (exist != "")
                //        {
                //            string a = dr[5].ToString();//获取图号
                //                                        //string strSql = "select getdate() from db_gongxu where  工令号='" + a + "'";
                //            string strSql = "select 要求到货日期 from db_xiangmu where 图号='" + a + "'";
                //            DateTime b = Convert.ToDateTime(SQLhelp.ExecuteScalar(strSql, CommandType.Text));
                //            DateTime c = DateTime.Now;
                //            TimeSpan m = b - c;
                //            double g = m.TotalMinutes;
                //            string f = m.Days + "天" + m.Hours + "小时" + m.Minutes + "分钟";
                //            if (g < 0)   //交货日期 < 现在的时间（超过了加工的时间）1.没有加工完成 2.加工完成 
                //            {

                //                string s1 = "select max(工序顺序) from db_shunxu where 图号='" + a + "'";
                //                string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));

                //                string s2 = "select 结束时间 from db_gongxu1 where 工序顺序='" + shunxu1 + "' and 图号='" + a + "'";
                //                string shijian1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));

                //                //1.没有加工完成
                //                if (shijian1 == "")
                //                {
                //                    //计算超过的时间
                //                    TimeSpan m1 = c - b;
                //                    string shijian2 = m1.Days + "天" + m1.Hours + "小时" + m1.Minutes + "分钟";
                //                    dt.Rows[i]["剩余加工时间"] = "已超过" + shijian2 + "未完成";

                //                }
                //                //2.加工完成
                //                else
                //                {
                //                    string s3 = "select 结束时间 from db_gongxu1 where 工序顺序='" + shunxu1 + "' and 图号='" + a + "'";
                //                    DateTime shijian5 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s3, CommandType.Text));
                //                    if (shijian5 < b)
                //                    {
                //                        dt.Rows[i]["剩余加工时间"] = "全部结束";
                //                    }
                //                    else
                //                    {
                //                        DateTime shijian3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                //                        TimeSpan m3 = shijian3 - b;
                //                        string shijian4 = m3.Days + "天" + m3.Hours + "小时" + m3.Minutes + "分钟";
                //                        dt.Rows[i]["剩余加工时间"] = "超过" + shijian4 + "加工完成";
                //                    }


                //                }

                //            }
                //            else  //交货日期 > 现在的时间(还有剩余的时间可以加工)
                //            {
                //                dt.Rows[i]["剩余加工时间"] = f;
                //            }
                //        }
                //        else
                //        {
                //            dt.Rows[i]["剩余加工时间"] = "未设置";
                //        }

                //    }


                //}));

                //thread.IsBackground = true;
                //thread.Start();


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
            string sql = "select 工序名称 from db_gongxu1 where getdate()>= 开始时间 and 结束时间 IS NULL and 图号='" + a + "'";
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
            int row = dataGridView1.Rows.Count;//得到总行数    
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                string str = Convert.ToString(dataGridView1.Rows[i].Cells["剩余加工时间"].Value);//取到当前单元格的数据
                string s1 = "加工";
                string s2 = "已";
                if (str.Contains(s1))
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["剩余加工时间"]; //将单元格定位为当前单元格
                    this.dataGridView1.CurrentCell.Style.ForeColor = Color.Yellow;// 
                }
                else if (str.Contains(s2))
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["剩余加工时间"]; //将单元格定位为当前单元格
                    this.dataGridView1.CurrentCell.Style.ForeColor = Color.Red;// 
                }


            }
        }

        //刷新
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string sql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,剩余加工时间,生产检验结果,检验结果备注,检验记录表上传时间 from db_xiangmu where 项目名称='" + xiangmumingcheng2 + "'and 设备名称='" + shebeimingcheng2 + "'and 工作令号='" + gongzuolinghao2 + "' and 时间='"+ shijian2+"'";

            reload(sql);

        }
        //查询
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string s1 = "select * from db_xiangmu where 项目名称='" + xiangmumingcheng2 + "'and 设备名称='" + shebeimingcheng2 + "'and 工作令号='" + gongzuolinghao2 + "'and [名称] like '%" + toolStripTextBox1.Text.Trim() + "%' or [图号] like '%" + toolStripTextBox1.Text.Trim() + "%'";

                reload(s1);

            }
        }

        //详细工序查询
        private void 详细工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formchaxunxiangxi gx = new Formchaxunxiangxi();

            //string a = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            //string b = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            //string c = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();

            string a= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
            string b= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
            string c= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();

            gx.gxtuhao = a;
            gx.gxmingcheng1 = b;
            gx.gxxiangmumingcheng = c;
            gx.Show();
        }

        private void 查看项目图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count <= 0)//判断是否选中要删除的行
            //{
            //    MessageBox.Show("请选中行！");
            //    return;
            //}
            //string fujian = dataGridView1.CurrentRow.Cells["附件名称"].Value.ToString();
            string fujian= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["附件名称"]).ToString();

            if (fujian != "")
            {
                //string a = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
                //string b = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
                //string c = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();

                string a= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
                string b= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();

                string chaxun11 = "select 附件类型 from db_xiangmu where  附件名称='" + fujian + "' and 名称='" + b + "'and 图号='" + a + "'";
                leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                byte[] mypdffile = null;

                string sqlfujian = "select 附件 from db_xiangmu where 图号='" + a + "'and 名称='" + b + "' and  附件名称='" + fujian + "'";
                mypdffile = SQLhelp.duqu(sqlfujian, CommandType.Text);

                //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";
                ////string ConStr = "Data Source=DESKTOP-ABRIFKO; Initial Catalog=db_SCB; Integrated Security=True";

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    string a = this.dataGridView1.Rows[e.RowIndex].Cells["图号"].Value.ToString();
            //    string b = this.dataGridView1.Rows[e.RowIndex].Cells["名称"].Value.ToString();
            //    FormXiangMuZongLan aa = new FormXiangMuZongLan();
            //    aa.ZonglanTuhao = a;
            //    aa.ZonglanMingcheng = b;
            //    aa.Show();
            //}
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void 查看检验结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count <= 0)//判断是否选中要删除的行
            //{
            //    MessageBox.Show("请选中行！");
            //    return;
            //}
            //string shijian = dataGridView1.CurrentRow.Cells["检验记录表上传时间"].Value.ToString();
            string shijian= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["检验记录表上传时间"]).ToString();

            if (shijian != "")
            {
                //string a = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
                //string b = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
                //string c = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();

                string a= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
                string b= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();

                string chaxun11 = "select 检验结果附件类型 from db_xiangmu where  检验记录表上传时间='" + shijian + "' and 名称='" + b + "'and 图号='" + a + "'";
                leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                byte[] mypdffile = null;
                string sqlfujian= "select 检验结果附件 from db_xiangmu where 图号='" + a + "'and 名称='" + b + "' and  检验记录表上传时间='" + shijian + "' ";
                mypdffile = SQLhelp.duqu(sqlfujian, CommandType.Text);
                //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";

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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_RowCellStyle_1(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "附件名称")//设背景  
            {
                //int pointID = (gridView1.GetRow(e.RowHandle) as object).BgColor;  
                e.Appearance.ForeColor = Color.Blue;
            }
        }
    }
}
