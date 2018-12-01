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

namespace ztznpms.UI.项目管理
{
    public partial class FormXiangmuXiangxi : Form
    {
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string gongzuolinghao;
        public string shijian;

        string sqlsql;
        public FormXiangmuXiangxi()
        {
            InitializeComponent();
            //dataGridView样式
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
        }


        private void FormXiangmuXiangxi_Load(object sender, EventArgs e)
        {

            ReadDataItems();


            ThreadStart threadStart1 = new ThreadStart(InsertDrawing);

            Thread thread1 = new Thread(threadStart1);

            thread1.Start();

            gongxu();
        }

        private void gongxu()
        {
            if (xiangmumingcheng != "")
            {
                sqlsql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改,序号,交货日期 from db_xiangmu where 项目名称='" + xiangmumingcheng + "'and 设备名称='" + shebeimingcheng + "'and 工作令号='" + gongzuolinghao + "' and 时间='" + shijian + "'";
            }
            if (xiangmumingcheng == "")
            {
                sqlsql = "select id,项目名称,工作令号,设备名称,编码,图号,名称,设备编号,单位,数量,类型,要求到货日期,制造类型,附件名称,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间,技术更改,序号,交货日期 from db_xiangmu where 设备名称='" + shebeimingcheng + "'and 工作令号='" + gongzuolinghao + "' and 时间='" + shijian + "'";
            }

            DataTable dt = SQLhelp.GetDataTable(sqlsql, CommandType.Text);

            #region 目前到达工序

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                DataRow dr = dt.Rows[i];

                string strSql1 = "select 工序顺序 from db_gongxu1 where 序号='" + dr["序号"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                if (exist != "")
                {
                    //string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                    string strSql = "select * from db_gongxu1 where getdate() > 开始时间 and 序号='" + dr["序号"].ToString() + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                    string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                    if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                    {
                        dt.Rows[i]["目前到达工序"] = "已编工艺，即将进入排产";
                        string SQl1 = "update db_xiangmu set 目前到达工序='已编工艺，即将进入排产' where 序号='" + dr["序号"].ToString() + "'";
                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

                        //Thread thread1 = new Thread(() =>
                        //{
                        //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                        //        string SQL2 = "update tb_caigouliaodan set 当前状态=' ' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                        //        string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));

                        //});
                        //thread1.IsBackground = false;
                        //thread1.Start();

                    }
                    else  //开始进行项目
                    {
                        if (panduan(dr["序号"].ToString()) != "")//正在进行某项工序
                        {
                            string s1 = "select max(工序顺序) from db_gongxu1 where getdate() > 开始时间 and 序号='" + dr["序号"].ToString() + "'";
                            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                            int aa = Convert.ToInt32(shunxu1);
                            string s2 = "select 工序名称 from db_gongxu1 where 工序顺序 = '" + aa + "' and 序号='" + dr["序号"].ToString() + "'";
                            string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                            dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1 + " 已开始";
                            string gx_1 = "工序" + shunxu1 + ":" + mingcheng1 + " 已开始";

                            string SQl2 = "update db_xiangmu set 目前到达工序='" + gx_1 + "' where 序号='" + dr["序号"].ToString() + "'";
                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));

                            //Thread thread1 = new Thread(() =>
                            //{
                            //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                            //        string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_1 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                            //        string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                            //});
                            //thread1.IsBackground = false;
                            //thread1.Start();

                        }
                        else//工序完成，正在流转，即将进行入下一道工序
                        {
                            string s3 = "select min(工序顺序) from db_gongxu1 where 结束时间 IS NULL and 开始时间 IS NULL and 序号='" + dr["序号"].ToString() + "'";
                            string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                            if (shunxu2 != "")
                            {
                                string shunxu22 = (Convert.ToInt32(shunxu2) - 1).ToString();

                                string s4 = "select 工序名称 from db_gongxu1 where and 工序顺序 ='" + shunxu22 + "' and 序号='" + dr["序号"].ToString() + "'";
                                string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu22 + ":" + mingcheng2 + " 已结束";

                                string gx_2 = "即将进入工序" + shunxu22 + ":" + mingcheng2 + " 已结束";

                                string SQl3 = "update db_xiangmu set 目前到达工序='" + gx_2 + "' where 序号='" + dr["序号"].ToString() + "'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                                //Thread thread1 = new Thread(() =>
                                //{

                                //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //        string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_2 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //    string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
                                //});
                                //thread1.IsBackground = false;
                                //thread1.Start();
                            }
                            else
                            {
                                dt.Rows[i]["目前到达工序"] = "工序结束待检验";
                                string gx_3 = "工序结束待检验";

                                string SQl4 = "update db_xiangmu set 目前到达工序='" + gx_3 + "' where  序号='" + dr["序号"].ToString() + "'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));


                                //Thread thread1 = new Thread(() =>
                                //{
                                //        //对接项目管理软件中tb_caigouliaodan数据表的"制造类型='自制零部件'"的料单
                                //        string SQL2 = "update tb_caigouliaodan set 当前状态='" + gx_3 + "' where 型号='" + dr["图号"].ToString() + "' and 名称='" + dr["名称"].ToString() + "' and 制造类型='自制零部件' and 项目名称='" + xiangmumingcheng1 + "' and 设备名称='" + shebeimingcheng1 + "'";
                                //        string RET2 = Convert.ToString(ExecuteNonquery(SQL2, CommandType.Text));
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

                    string SQl5 = "update db_xiangmu set 目前到达工序=' ' where 序号='" + dr["序号"].ToString() + "'";
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

            #endregion
        }

        private string panduan(string a)
        {
            string sql = "select 工序名称 from db_gongxu1 where getdate()>= 开始时间 and 结束时间 IS NULL and 序号='" + a + "'";
            string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            return result;
        }
        public void ReadDataItems()
        {
            string sql = "select id,项目名称,工作令号,设备名称,编码,型号,名称,单位,实际采购数量,类型,要求到货日期,制造类型,附件类型,附件名称,时间,技术更改,生产部确认,序号 from tb_caigouliaodan where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件' and 时间='"+ shijian +"'";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;

            string sql2 = "delete from db_xiangmu where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'and 制造类型='自制零部件' and 时间='"+ shijian +"'";
            string ret2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string SQL1 = "select 交货日期 from tb_xiangmu where 工作令号='"+ dr["工作令号"]+"'";
                string RET1 = Convert.ToString(SQLhelp.ExecuteScalar1(SQL1, CommandType.Text));

                string sql1 = "insert into db_xiangmu(项目名称,工作令号,设备名称,编码,图号,名称,单位,数量,类型,要求到货日期,制造类型,附件类型,附件名称,时间,技术更改,序号,生产部确认,交货日期,number1)values('" + xiangmumingcheng + "','" + dr["工作令号"].ToString() + "','" + dr["设备名称"].ToString() + "','" + dr["编码"].ToString() + "','" + dr["型号"].ToString() + "','" + dr["名称"].ToString() + "','" + dr["单位"].ToString() + "','" + dr["实际采购数量"].ToString() + "','" + dr["类型"].ToString() + "','" + dr["要求到货日期"].ToString() + "','" + dr["制造类型"].ToString() + "','" + dr["附件类型"].ToString() + "','" + dr["附件名称"].ToString() + "','"+ dr["时间"].ToString()+ "','" + dr["技术更改"].ToString() + "','"+ dr["id"].ToString() +"','"+ dr["生产部确认"].ToString()+"','"+ RET1+"','"+ dr["序号"].ToString()+"')";
                string ret1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));

                //从db_gongxu1中查找是否有工序设置了？
                string sql3 = "select 工序名称 from db_gongxu1 where 序号='" + dr["id"].ToString() + "'";
                string ret3 = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                if (ret3 != "")//db_gongxu1有工序设置好了
                {
                    DataTable dt1 = SQLhelp.GetDataTable(sql3, CommandType.Text);


                    if(dt1.Rows.Count == 1)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if(dt1.Rows.Count == 2)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 3)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 4)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 5)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 6)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 7)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 8)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 9)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 10)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 11)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 12)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 13)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 14)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 15)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 16)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 17)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 18)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 19)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 20)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 21)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 22)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 23)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序23 ='" + dt1.Rows[22]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 24)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 25)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "', 工序25 ='" + dt1.Rows[24]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                }

            }
        }

        public void InsertDrawing()
        {
            try
            {
                string sql5 = "select * from tb_caigouliaodan where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件' and 时间='"+ shijian +"'";
                //int count = Convert.ToInt32(ExecuteScalar(sql5, CommandType.Text));//一个自制件项目的所有零件个数
                DataTable dt =SQLhelp.GetDataTable1(sql5, CommandType.Text);
                //for (int i = 1; i <= count; i++)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    //string conn = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";
                    string str = "select 附件 from tb_caigouliaodan where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件' and 时间='" + shijian + "' and 附件名称='" + dr["附件名称"].ToString() + "'";
                    DataTable dtt = SQLhelp.GetDataTable1(str, CommandType.Text);

                    //SqlConnection myconn = new SqlConnection(conn);
                    //SqlDataAdapter sda = new SqlDataAdapter(str, conn);
                    //DataSet myds = new DataSet();
                    //myconn.Open();
                    //sda.Fill(myds);
                    //myconn.Close();
                    //Byte[] Files = (Byte[])myds.Tables[0].Rows[0]["附件"];
                    Byte[] Files = (Byte[])dtt.Rows[0]["附件"];

                    //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";
                    string ConStr= "update db_xiangmu set 附件=@pic where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件' and 时间='" + shijian + "' and 附件名称='" + dr["附件名称"].ToString() + "'";
                    string ConRet = Convert.ToString(SQLhelp.ExecuteNonqueryByte(ConStr, CommandType.Text, Files));
                    //SqlConnection con = new SqlConnection(ConStr);
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand("", con);
                    //cmd = con.CreateCommand();

                    //cmd.CommandText = "update db_xiangmu set 附件=@pic where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件' and 时间='"+ shijian+"' and 附件名称='" + dr["附件名称"].ToString() + "'";

                    //cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@pic", Files);
                    //cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
            
        }

        ////插入图纸
        //string sql3 = "select 附件 from tb_caigouliaodan where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件'";
        //DataTable dt3 = GetDataTable(sql3, CommandType.Text);

        //for (int i = 0; i < dt3.Rows.Count; i++)
        //{
        //    DataRow dr3 = dt3.Rows[i];

        //    string sql4 = "update db_xiangmu set 附件='" + dr3["附件"].ToString() + "' where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 制造类型='自制零部件'";
        //    string ret4 = Convert.ToString(ExecuteNonquery(sql4, CommandType.Text));

        //}

        //String sql = "select * from picture where [id]=2";
        //string str = "server=DA5A491B3F7544B;database=study;uid=sa;pwd=liyi123";
        //SqlConnection con = new SqlConnection(str);
        //con.Open();
        //SqlCommand cmd = new SqlCommand(sql, con);
        //SqlDataReader sdr = cmd.ExecuteReader();
        //if (sdr.HasRows)
        //{
        //    sdr.Read();
        //    byte[] bytes = (byte[])sdr["pic"];
        //    MemoryStream ms = new MemoryStream(bytes);
        //    Image image = Image.FromStream(ms);
        //    pictureBox1.Image = image;
        //}
        //sdr.Close();
        //con.Close();

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
    }
}
