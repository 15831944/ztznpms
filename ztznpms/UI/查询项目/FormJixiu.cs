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
using ztznpms.UI.检验;

namespace ztznpms.UI.查询项目
{
    public partial class FormJixiu : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public string gongzuolinghao;
        public string shebeimingcheng;
        public FormJixiu()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
        }


        private void FormJixiu_Load(object sender, EventArgs e)
        {
           
            reload();
            DrawRowIndicator(gridView1, 50);
        }

        private void reload()
        {
            string sql1 = "select id,序号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间 from db_jixiujian where 完成='未完成'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow dr = dt.Rows[i];

                string strSql1 = "select 工序顺序 from db_gongxu111 where  序号='" + dr["序号"] + "' ";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                if (exist != "")
                {
                    string a = dr[5].ToString();//i=0时，获取db_total表中第一行项目的工令号
                    string strSql = "select * from db_gongxu111 where 序号='" + dr["序号"] + "'and getdate() > 开始时间 ";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                    string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                    if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                    {

                        dt.Rows[i]["目前到达工序"] = "工艺已编写,待排产";
                        string SQl1 = "update db_jixiujian set 目前到达工序='工艺已编写,待排产' where id='" + dr["id"].ToString() + "'";
                        string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl1, CommandType.Text));

                    }
                    else  //开始进行项目
                    {
                        if (panduan(dr["序号"].ToString()) != "")//正在进行某项工序
                        {

                            string s1 = "select max(工序顺序) from db_gongxu111 where 序号='" + dr["序号"] + "' and getdate() > 开始时间 ";
                            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                            int aa = Convert.ToInt32(shunxu1);
                            string s2 = "select 工序名称 from db_gongxu111 where 序号='" + dr["序号"] + "' and 工序顺序 = '" + aa + "'";
                            string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                            dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1 + " 已开始";
                            string gx_1 = "工序" + shunxu1 + ":" + mingcheng1 + " 已开始";

                            string SQl2 = "update db_jixiujian set 目前到达工序='" + gx_1 + "' where id='" + dr["id"] + "'";
                            string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl2, CommandType.Text));

                        }
                        else//工序完成，正在流转，即将进行入下一道工序
                        {
                            string s3 = "select min(工序顺序) from db_gongxu111 where 序号='" + dr["序号"] + "' and 结束时间 IS NULL and 开始时间 IS NULL";
                            string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                            if (shunxu2 != "")
                            {
                                string shunxu22 = (Convert.ToInt32(shunxu2) - 1).ToString();

                                string s4 = "select 工序名称 from db_gongxu111 where 序号='" + dr["序号"] + "' and 工序顺序 ='" + shunxu22 + "'";
                                string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                dt.Rows[i]["目前到达工序"] = "工序" + shunxu22 + ":" + mingcheng2 + " 已结束";

                                string gx_2 = "工序" + shunxu22 + ":" + mingcheng2 + " 已结束";


                                string SQl3 = "update db_jixiujian set 目前到达工序='" + gx_2 + "' where id='" + dr["id"].ToString() + "'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl3, CommandType.Text));

                            }
                            else
                            {
                                dt.Rows[i]["目前到达工序"] = "工序结束待检验";
                                string gx_3 = "工序结束待检验";

                                string SQl4 = "update db_jixiujian set 目前到达工序='" + gx_3 + "' where id='" + dr["id"].ToString() + "'";
                                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl4, CommandType.Text));

                            }



                        }

                    }

                }
                else
                {
                    dt.Rows[i]["目前到达工序"] = "";

                    string SQl5 = "update db_jixiujian set 目前到达工序=' ' where  id='" + dr["id"].ToString() + "'";
                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery(SQl5, CommandType.Text));

                }


            }


            gridControl1.DataSource = dt;
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

        /// <summary>
        /// 导入机修件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //string sql1 = "select id,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成 from tb_caigouliaodan where 加工单位备注='自制' and 项目名称 IS NULL and 工作令号 IS NULL";
            string sql11 = "select id,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成 from tb_caigouliaodan where 加工单位备注='自制' and 机修件数量 is  not null";

            DataTable dt11 =SQLhelp.GetDataTable1(sql11, CommandType.Text);

            string sql3 = "delete from db_jixiujian ";
            string ret2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql3, CommandType.Text));


            for (int i = 0; i < dt11.Rows.Count; i++)
            {
                DataRow dr = dt11.Rows[i];

                string sql2 = "insert into db_jixiujian(客户名称,部门,序号,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成)values('" + dr["客户名称"] + "','" + dr["部门"].ToString() + "','" + dr["id"].ToString() + "','" + dr["工件名称"].ToString() + "','" + dr["加工内容"].ToString() + "','" + dr["计量单位"].ToString() + "','" + dr["机修件数量"].ToString() + "','" + dr["接单编号"].ToString() + "','" + dr["预交时间"].ToString() + "','" + dr["联系人"].ToString() + "','" + dr["责任人"].ToString() + "','" + dr["加工单位备注"].ToString() + "','" + dr["接单日期"].ToString() + "','" + dr["完成"].ToString() + "')";
                string ret1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));

                #region 导入工序
                //string sql5 = "select * from db_gongxu111 where 序号='" + dr["id"].ToString() + "'";
                //string ret5 = Convert.ToString(SQLhelp.ExecuteScalar(sql5, CommandType.Text));

                //if (ret5 != string.Empty)
                //{
                //    DataTable dt1 = SQLhelp.GetDataTable(sql5, CommandType.Text);

                //    if (dt1.Rows.Count == 1)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 2)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 3)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 4)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 5)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 6)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 7)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 8)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 9)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 10)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 11)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 12)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 13)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 14)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "' where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 15)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 16)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 17)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 18)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 19)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 20)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 21)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 22)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 23)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序23 ='" + dt1.Rows[22]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 24)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }
                //    if (dt1.Rows.Count == 25)
                //    {
                //        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "', 工序25 ='" + dt1.Rows[24]["工序名称"].ToString() + "'  where 序号='" + dr["id"].ToString() + "'";
                //        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                //    }

                //}
                #endregion
            }

            gongxucharu();

            string sqlstr1 = "select * from db_jixiujian";
            DataTable dtstr1 = SQLhelp.GetDataTable(sqlstr1, CommandType.Text);

            for (int i = 0; i < dtstr1.Rows.Count; i++)
            {
                string sqlstr2 = "update db_jixiujian set 目前到达工序='全部结束' where 完成='完成'";
                SQLhelp.ExecuteNonquery(sqlstr2, CommandType.Text);
            }

            gridControl1.DataSource = dt11;


           
        }

        private void gongxucharu()
        {
            string sql = "select * from db_jixiujian";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string sql1 = "select 工序名称 from db_gongxu111 where 序号='" + dr["序号"] + "'";
                string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                if (ret1 != "")
                {
                    DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt1.Rows.Count == 1)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 2)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 3)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 4)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 5)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 6)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 7)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 8)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 9)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 10)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 11)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 12)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 13)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 14)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 15)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 16)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 17)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 18)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 19)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 20)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 21)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 22)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 23)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序23 ='" + dt1.Rows[22]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 24)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 25)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "', 工序25 ='" + dt1.Rows[24]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                }
            }
        }

        /// <summary>
        /// 未完成项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sql1 = "select id,序号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间 from db_jixiujian where 完成='未完成'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //this.dataGridView1.DataSource = dt;
            //this.dataGridView1.Columns["id"].Visible = false;
            gridControl1.DataSource = dt;
        }

        /// <summary>
        /// 已完成项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string sql1 = "select id,序号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,目前到达工序,生产检验结果,检验结果备注,检验记录表上传时间 from db_jixiujian where 完成='完成'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //this.dataGridView1.DataSource = dt;
            //this.dataGridView1.Columns["id"].Visible = false;
            gridControl1.DataSource = dt;
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
        /// 设置项目
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

            Formshezhijixiujian add = new Formshezhijixiujian();
            //add.addxiangmuming = dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString();
            //add.addgonglinghao = dataGridView1.CurrentRow.Cells["接单编号"].Value.ToString();
            //add.addtuhao = dataGridView1.CurrentRow.Cells["加工内容"].Value.ToString();
            //add.addmingcheng = dataGridView1.CurrentRow.Cells["工件名称"].Value.ToString();
            //add.xuhao = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();

            add.addxiangmuming= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["客户名称"]).ToString();
            add.addgonglinghao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["接单编号"]).ToString();
            add.addtuhao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["加工内容"]).ToString();
            add.addmingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工件名称"]).ToString();
            add.xuhao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();
            add.addyujiaoshijian= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["预交时间"]).ToString();
            add.yonghu = yonghu;
            add.leixing = "机修件零件";

            add.ShowDialog();

            if (add.DialogResult == DialogResult.OK)
            {

                this.reload();

            }
        }

        

        private string panduan(string a)
        {
            string sql = "select 工序名称 from db_gongxu111 where getdate()>= 开始时间 and 结束时间 IS NULL and 序号='" + a + "' ";
            string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            return result;
        }

        /// <summary>
        /// 详细工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 详细工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormXiangxiJixiu gx = new FormXiangxiJixiu();

            //string a = dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString();
            //string b = dataGridView1.CurrentRow.Cells["工件名称"].Value.ToString();
            //string c = dataGridView1.CurrentRow.Cells["加工内容"].Value.ToString();
            //string d = dataGridView1.CurrentRow.Cells["接单编号"].Value.ToString();
            //string f = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();

            string a= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["客户名称"]).ToString();
            string b= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工件名称"]).ToString();
            string c= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["加工内容"]).ToString();
            string d= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["接单编号"]).ToString();
            string f= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();
            gx.gxkehuming = a;
            gx.gxmingcheng = b;
            gx.gxneirong = c;
            gx.gxjiedanbianhao = d;
            gx.gxxuhao = f;
            gx.Show();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl1.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void 采购申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formshebeicailiaoshengou form = new Formshebeicailiaoshengou();
            form.yonghu = yonghu;
            //form.shijian = shijian11;
            gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["接单编号"]).ToString();
            shebeimingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["客户名称"]).ToString();
            form.xuhaocailiao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["序号"]).ToString();
            form.gonglinghao = gongzuolinghao;
            form.shebeimingcheng = shebeimingcheng;
            form.liaodanleiixng = "机修件零件";
            form.ShowDialog();
        }
    }
}
