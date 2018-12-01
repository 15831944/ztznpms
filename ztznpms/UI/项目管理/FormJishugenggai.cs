using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.工序管理;

namespace ztznpms.UI.项目管理
{
    public partial class FormJishugenggai : Form
    {
        public FormJishugenggai()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;

            //设置自动调整高度
            //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
        }


        private void FormJishugenggai_Load(object sender, EventArgs e)
        {
            reload();
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

        private void reload()
        {
            try
            {
                string sql = "select id,序号,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改 from db_jishugenggai where 技术更改='0'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                    DataRow dr = dt.Rows[i];

                    string strSql1 = "select 工序顺序 from db_gongxu11 where  项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                    string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                    if (exist != "")
                    {
                        string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                        string strSql = "select * from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号='" + a + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                        string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                        if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                        {
                            dt.Rows[i]["目前到达工序"] = "尚未开始";
                            string SQl1 = "update db_jishugenggai set 目前到达工序='尚未开始' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'";
                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

                            //Thread thread1 = new Thread(() =>
                            //{
                            //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                            //    string SQL2 = "update tb_caigouliaodan set 当前状态='尚未开始' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                            //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                            //});
                            //thread1.IsBackground = false;
                            //thread1.Start();

                        }
                        else  //开始进行项目
                        {
                            if (panduan(a) != "")//正在进行某项工序
                            {
                                string s1 = "select max(工序顺序) from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号 = '" + a + "' ";
                                string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                                int aa = Convert.ToInt32(shunxu1);
                                string s2 = "select 工序名称 from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 工序顺序 = '" + aa + "' and 图号= '" + a + "' ";
                                string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                                dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                                string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                                string SQl2 = "update db_jishugenggai set 目前到达工序='" + gx_1 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));

                                //Thread thread1 = new Thread(() =>
                                //{
                                //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                //});
                                //thread1.IsBackground = false;
                                //thread1.Start();

                            }
                            else//工序完成，正在流转，即将进行入下一道工序
                            {
                                string s3 = "select min(工序顺序) from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 结束时间 IS NULL and 开始时间 IS NULL  and 图号='" + a + "'";
                                string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                                if (shunxu2 != "")
                                {
                                    string s4 = "select 工序名称 from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 工序顺序 ='" + shunxu2 + "' and 图号='" + a + "'";
                                    string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                    dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                    string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                    string SQl3 = "update db_jishugenggai set 目前到达工序='" + gx_2 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                                    //Thread thread1 = new Thread(() =>
                                    //{

                                    //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                    //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                    //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                    //});
                                    //thread1.IsBackground = false;
                                    //thread1.Start();
                                }
                                else
                                {
                                    dt.Rows[i]["目前到达工序"] = "全部结束";
                                    string gx_3 = "全部结束";

                                    string SQl4 = "update db_jishugenggai set 目前到达工序='" + gx_3 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));


                                    //Thread thread1 = new Thread(() =>
                                    //{
                                    //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                    //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                    //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                    //});
                                    //thread1.IsBackground = false;
                                    //thread1.Start();
                                }



                            }

                        }

                    }
                    else
                    {
                        dt.Rows[i]["目前到达工序"] = "";
                        //string gx_4 = "未设置工序";

                        string SQl5 = "update db_jishugenggai set 目前到达工序=' ' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                        //Thread thread1 = new Thread(() =>
                        //{
                        //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                        //    string SQL2 = "update tb_caigouliaodan set 当前状态=' ' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                        //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                        //});
                        //thread1.IsBackground = false;
                        //thread1.Start();
                    }


                }

                //dataGridView1.DataSource = dt;

                gridControl1.DataSource = dt;

                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["附件名称"];
                //    this.dataGridView1.CurrentCell.Style.ForeColor = Color.Blue;
                //}

            }
            catch
            {

            }
            
        }

        /// <summary>
        /// 导入技术更改项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ReadDataItems();

            ThreadStart threadStart1 = new ThreadStart(InsertDrawing);

            Thread thread1 = new Thread(threadStart1);

            thread1.Start();
        }

        private void ReadDataItems()
        {
            //string sql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件类型,附件名称,时间,技术更改 from db_xiangmu where 技术更改='0'";
            string sql = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,实际采购数量,类型,要求到货日期,制造类型,附件名称,附件类型,时间,技术更改 from  tb_caigouliaodan  where 技术更改=0 or 技术更改=1";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            //this.dataGridView1.DataSource = dt;
            gridControl1.DataSource = dt;

            string sql2 = "delete from db_jishugenggai ";
            string ret2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string sql1 = "insert into db_jishugenggai(序号,项目名称,工作令号,设备名称,编码,图号,名称,单位,数量,类型,要求到货日期,制造类型,附件类型,附件名称,时间,技术更改)values('" + dr["id"].ToString() + "','" + dr["项目名称"].ToString() + "','" + dr["工作令号"].ToString() + "','" + dr["设备名称"].ToString() + "','" + dr["编码"].ToString() + "','" + dr["型号"].ToString() + "','" + dr["名称"].ToString() + "','" + dr["单位"].ToString() + "','" + dr["实际采购数量"].ToString() + "','" + dr["类型"].ToString() + "','" + dr["要求到货日期"].ToString() + "','" + dr["制造类型"].ToString() + "','" + dr["附件类型"].ToString() + "','" + dr["附件名称"].ToString() + "','" + dr["时间"].ToString() + "','" + dr["技术更改"].ToString() + "')";
                string ret1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));

            }
        }

        public void InsertDrawing()
        {
            try
            {
                string sql5 = "select * from db_jishugenggai ";
                //int count = Convert.ToInt32(ExecuteScalar(sql5, CommandType.Text));//一个自制件项目的所有零件个数
                DataTable dt = SQLhelp.GetDataTable(sql5, CommandType.Text);
                //for (int i = 1; i <= count; i++)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    //string conn = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";
                    string str = "select 附件 from tb_caigouliaodan where id='" + dr["序号"].ToString() + "' and 项目名称='"+ dr["项目名称"].ToString() +"' and 工作令号='"+ dr["工作令号"].ToString() +"' and 型号='"+ dr["图号"].ToString() +"' and 名称='"+ dr["名称"].ToString() +"'";

                    if(dr["附件名称"].ToString() != "")
                    {
                        //SqlConnection myconn = new SqlConnection(conn);
                        //SqlDataAdapter sda = new SqlDataAdapter(str, conn);
                        //DataSet myds = new DataSet();
                        //myconn.Open();
                        //sda.Fill(myds);
                        //myconn.Close();

                        DataTable dtt = SQLhelp.GetDataTable1(str, CommandType.Text);
                        //Byte[] Files = (Byte[])myds.Tables[0].Rows[0]["附件"];
                        Byte[] Files = (Byte[])dtt.Rows[0]["附件"];

                        //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";

                        //SqlConnection con = new SqlConnection(ConStr);
                        //con.Open();
                        //SqlCommand cmd = new SqlCommand("", con);
                        //cmd = con.CreateCommand();

                        string sqlcon= "update db_jishugenggai set 附件=@pic where 序号='" + dr["序号"].ToString() + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 工作令号='" + dr["工作令号"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";
                        //cmd.CommandText = "update db_jishugenggai set 附件=@pic where 序号='" + dr["序号"].ToString() + "' and 项目名称='" + dr["项目名称"].ToString() + "' and 工作令号='" + dr["工作令号"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";

                        //cmd.Parameters.Clear();
                        //cmd.Parameters.AddWithValue("@pic", Files);
                        //cmd.ExecuteNonQuery();
                        string retcon = Convert.ToString(SQLhelp.ExecuteNonqueryByte(sqlcon, CommandType.Text, Files));
                    }                    
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 未完成项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sql = "select id,序号,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改 from db_jishugenggai where 技术更改='0'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                DataRow dr = dt.Rows[i];

                string strSql1 = "select 工序顺序 from db_gongxu11 where  项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                if (exist != "")
                {
                    string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                    string strSql = "select * from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号='" + a + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                    string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                    if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                    {
                        dt.Rows[i]["目前到达工序"] = "尚未开始";
                        string SQl1 = "update db_jishugenggai set 目前到达工序='尚未开始' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

                        //Thread thread1 = new Thread(() =>
                        //{
                        //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                        //    string SQL2 = "update tb_caigouliaodan set 当前状态='尚未开始' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                        //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                        //});
                        //thread1.IsBackground = false;
                        //thread1.Start();

                    }
                    else  //开始进行项目
                    {
                        if (panduan(a) != "")//正在进行某项工序
                        {
                            string s1 = "select max(工序顺序) from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号 = '" + a + "'";
                            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                            int aa = Convert.ToInt32(shunxu1);
                            string s2 = "select 工序名称 from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 工序顺序 = '" + aa + "' and 图号= '" + a + "'";
                            string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                            dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                            string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                            string SQl2 = "update db_jishugenggai set 目前到达工序='" + gx_1 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));

                            //Thread thread1 = new Thread(() =>
                            //{
                            //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                            //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                            //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                            //});
                            //thread1.IsBackground = false;
                            //thread1.Start();

                        }
                        else//工序完成，正在流转，即将进行入下一道工序
                        {
                            string s3 = "select min(工序顺序) from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 结束时间 IS NULL and 开始时间 IS NULL  and 图号='" + a + "'";
                            string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                            if (shunxu2 != "")
                            {
                                string s4 = "select 工序名称 from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 工序顺序 ='" + shunxu2 + "' and 图号='" + a + "'";
                                string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                string SQl3 = "update db_jishugenggai set 目前到达工序='" + gx_2 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                                //Thread thread1 = new Thread(() =>
                                //{

                                //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                //});
                                //thread1.IsBackground = false;
                                //thread1.Start();
                            }
                            else
                            {
                                dt.Rows[i]["目前到达工序"] = "全部结束";
                                string gx_3 = "全部结束";

                                string SQl4 = "update db_jishugenggai set 目前到达工序='" + gx_3 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));

                                string sqll = "update db_jishugenggai set 技术更改='1' where id='" + dr["id"].ToString() + "'";
                                string rett1 = Convert.ToString(SQLhelp.ExecuteNonquery(sqll, CommandType.Text));

                                //Thread thread1 = new Thread(() =>
                                //{
                                //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                //});
                                //thread1.IsBackground = false;
                                //thread1.Start();
                            }



                        }

                    }

                }
                else
                {
                    dt.Rows[i]["目前到达工序"] = "";
                    //string gx_4 = "未设置工序";

                    string SQl5 = "update db_jishugenggai set 目前到达工序=' ' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                    //Thread thread1 = new Thread(() =>
                    //{
                    //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                    //    string SQL2 = "update tb_caigouliaodan set 当前状态=' ' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                    //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                    //});
                    //thread1.IsBackground = false;
                    //thread1.Start();
                }


            }

            //dataGridView1.DataSource = dt;
            gridControl1.DataSource = dt;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["附件名称"];
            //    this.dataGridView1.CurrentCell.Style.ForeColor = Color.Blue;
            //}

        }

        private string panduan(string a)
        {
            string sql = "select 工序名称 from db_gongxu11 where getdate()>= 开始时间 and 结束时间 IS NULL and 图号='" + a + "'";
            string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            return result;
        }
        /// <summary>
        /// 已完成项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string sql = "select id,序号,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改 from db_jishugenggai where 技术更改='1'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                DataRow dr = dt.Rows[i];

                string strSql1 = "select 工序顺序 from db_gongxu11 where  项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                if (exist != "")
                {
                    string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                    string strSql = "select * from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号='" + a + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                    string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                    if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                    {
                        dt.Rows[i]["目前到达工序"] = "尚未开始";
                        string SQl1 = "update db_jishugenggai set 目前到达工序='尚未开始' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

                        //Thread thread1 = new Thread(() =>
                        //{
                        //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                        //    string SQL2 = "update tb_caigouliaodan set 当前状态='尚未开始' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                        //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                        //});
                        //thread1.IsBackground = false;
                        //thread1.Start();

                    }
                    else  //开始进行项目
                    {
                        if (panduan(a) != "")//正在进行某项工序
                        {
                            string s1 = "select max(工序顺序) from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and getdate() > 开始时间 and 图号 = '" + a + "'";
                            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                            int aa = Convert.ToInt32(shunxu1);
                            string s2 = "select 工序名称 from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 工序顺序 = '" + aa + "' and 图号= '" + a + "'";
                            string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                            dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                            string gx_1 = "工序" + shunxu1 + ":" + mingcheng1;

                            string SQl2 = "update db_jishugenggai set 目前到达工序='" + gx_1 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));

                            //Thread thread1 = new Thread(() =>
                            //{
                            //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                            //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                            //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                            //});
                            //thread1.IsBackground = false;
                            //thread1.Start();

                        }
                        else//工序完成，正在流转，即将进行入下一道工序
                        {
                            string s3 = "select min(工序顺序) from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 结束时间 IS NULL and 开始时间 IS NULL  and 图号='" + a + "'";
                            string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                            if (shunxu2 != "")
                            {
                                string s4 = "select 工序名称 from db_gongxu11 where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 工序顺序 ='" + shunxu2 + "' and 图号='" + a + "'";
                                string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                string gx_2 = "即将进入工序" + shunxu2 + ":" + mingcheng2;

                                string SQl3 = "update db_jishugenggai set 目前到达工序='" + gx_2 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                                //Thread thread1 = new Thread(() =>
                                //{

                                //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                //});
                                //thread1.IsBackground = false;
                                //thread1.Start();
                            }
                            else
                            {
                                dt.Rows[i]["目前到达工序"] = "全部结束";
                                string gx_3 = "全部结束";

                                string SQl4 = "update db_jishugenggai set 目前到达工序='" + gx_3 + "' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));

                                string sqll = "update db_jishugenggai set 技术更改='1' where id='"+ dr["id"].ToString() +"'";
                                string rett1 = Convert.ToString(SQLhelp.ExecuteNonquery(sqll, CommandType.Text));


                                //Thread thread1 = new Thread(() =>
                                //{
                                //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //    string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                //});
                                //thread1.IsBackground = false;
                                //thread1.Start();
                            }



                        }

                    }

                }
                else
                {
                    dt.Rows[i]["目前到达工序"] = "";
                    //string gx_4 = "未设置工序";

                    string SQl5 = "update db_jishugenggai set 目前到达工序=' ' where 项目名称='" + dr["项目名称"].ToString() + "' and 设备名称='" + dr["设备名称"].ToString() + "' and 图号='" + dr["图号"].ToString() + "'and 名称='" + dr["名称"].ToString() + "'and 技术更改='0'";
                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                    //Thread thread1 = new Thread(() =>
                    //{
                    //    //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                    //    string SQL2 = "update tb_caigouliaodan set 当前状态=' ' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                    //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                    //});
                    //thread1.IsBackground = false;
                    //thread1.Start();
                }
            }

            //dataGridView1.DataSource = dt;
            gridControl1.DataSource = dt;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells["附件名称"];
            //    this.dataGridView1.CurrentCell.Style.ForeColor = Color.Blue;
            //}
        }

        /// <summary>
        /// 设置项目工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count <= 0)
            //{
            //    MessageBox.Show("请选择行！,若没数据请重新添加");
            //    return;
            //}
            FormADDgongxu add = new FormADDgongxu();

            try
            {
                //add.addxiangmuming = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
                //add.addgonglinghao = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();
                //add.addtuhao = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
                //add.addmingcheng = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
                //add.fujianName = dataGridView1.CurrentRow.Cells["附件名称"].Value.ToString();
                //add.addjishugenggai = dataGridView1.CurrentRow.Cells["技术更改"].Value.ToString();

                add.addxiangmuming = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
                add.addgonglinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
                add.addtuhao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
                add.addmingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
                add.fujianName = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["附件名称"]).ToString();
                add.addjishugenggai = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["技术更改"]).ToString();
                add.addxuhao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();

                add.flag = "技术更改";
                add.ShowDialog();


                if (add.DialogResult == DialogResult.OK)
                {

                    this.reload();

                }
            }
            catch
            {

            }
            
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

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

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string a = gridView1.GetRowCellValue(i, "id").ToString();
                string a1 = gridView1.GetRowCellValue(i, "设备编号").ToString();

                string sql = "update db_jishugenggai set 设备编号='" + a1 + "' where id ='" + a + "'";

                int r = SQLhelp.ExecuteNonquery(sql, CommandType.Text);

                MessageBox.Show("修改成功", "提示");
            }

            reload();
        }

        private void 详细工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Formxiangxigongxu gx = new Formxiangxigongxu();

            //string a = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            //string b = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            //string c = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            //string d = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();

            //string a= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["图号"]).ToString();
            //string b= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
            //string c= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            //string d= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
            string f = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();

            //gx.gxtuhao = a;
            //gx.gxmingcheng1 = b;
            //gx.gxxiangmu1 = c;
            //gx.gxshebeiming1 = d;
            gx.xuhao1 = f;
            gx.flag = "技术更改";
            gx.Show();
        }

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
            GridView View = sender as GridView;
            if (e.Column.FieldName == "附件名称")//设背景  
            {
                //int pointID = (gridView1.GetRow(e.RowHandle) as object).BgColor;  
                e.Appearance.ForeColor = Color.Blue;
            }
        }
    }
}
