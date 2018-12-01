using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.项目管理
{
    public partial class FormSxsj : Form
    {

        public string name;
        public string lieming;
        public FormSxsj()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FormSxsj_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from db_jihuadan where " + lieming + " = '" + name + "'";

                reload(sql);
                Colorset();
            }
            catch
            {
                ;
            }

        }

        private void reload(string sql)
        {

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            dt.Columns.Add("目前到达工序");
            dt.Columns.Add("剩余加工时间");

            //计算时间差额
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //string sql = "select * from db_jihuadan";

                //DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataRow dr = dt.Rows[i];

                //DataRow dr = hang(i);

                string s1 = "select 要求完成 from db_jihuadan where  工令号='" + dr["工令号"].ToString() + "'";
                string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                if (r1 != "")
                {
                    DateTime time1 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                    DateTime time2 = DateTime.Now;
                    TimeSpan time3 = time1 - time2;
                    double time4 = time3.TotalDays;
                    int time5 = Convert.ToInt32(time4);
                    dt.Rows[i]["时间差额"] = time5;

                    string genxin = "update db_jihuadan set 时间差额='" + time5 + "' where  工令号='" + dr["工令号"].ToString() + "'";
                    int genxin1 = SQLhelp.ExecuteNonquery(genxin, CommandType.Text);
                }
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow dr = hang(i);//i=0时，查询db_total表中的第一行项目登记的信息

                DataRow dr = dt.Rows[i];

                string strSql1 = "select 工序顺序 from db_gongxu where  图号='" + dr["图号"].ToString() + "'";//从工序表db_gongxu中查询出工令号代表的项目工序顺序
                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                if (exist != "")
                {
                    string a = dr[4].ToString();//i=0时，获取db_total表中第一行项目的工令号
                    string strSql = "select * from db_gongxu where getdate() > 开始时间 and 图号='" + a + "'";//查询工令号a对应的开始时间 < 现在now的时间(有数据证明这个项目已经开始了)
                    string b = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));//获取开始时间

                    if (b == "")//查出数据为空，代表项目才到制定阶段，没有开始进入工序
                    {
                        dt.Rows[i]["目前到达工序"] = "尚未开始";
                    }
                    else  //开始进行项目
                    {
                        if (panduan(a) != "")//正在进行某项工序
                        {
                            string s1 = "select max(工序顺序) from db_gongxu where getdate() > 开始时间 and 图号 = '" + a + "'";
                            string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                            int aa = Convert.ToInt32(shunxu1);
                            string s2 = "select 工序名称 from db_gongxu where 工序顺序 = '" + aa + "' and 图号= '" + a + "'";
                            string mingcheng1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                            dt.Rows[i]["目前到达工序"] = "工序" + shunxu1 + ":" + mingcheng1;
                        }
                        else//工序完成，正在流转，即将进行入下一道工序
                        {
                            string s3 = "select min(工序顺序) from db_gongxu where 结束时间 IS NULL and 开始时间 IS NULL  and 图号='" + a + "'";
                            string shunxu2 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                            if (shunxu2 != "")
                            {
                                string s4 = "select 工序名称 from db_gongxu where 工序顺序 ='" + shunxu2 + "' and 图号='" + a + "'";
                                string mingcheng2 = Convert.ToString(SQLhelp.ExecuteScalar(s4, CommandType.Text));
                                dt.Rows[i]["目前到达工序"] = "即将进入工序" + shunxu2 + ":" + mingcheng2;
                            }
                            else
                            {
                                dt.Rows[i]["目前到达工序"] = "全部结束";
                            }



                        }

                    }

                }
                else
                {
                    dt.Rows[i]["目前到达工序"] = "未设置";

                }


            }

            //剩余加工时间
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow dr = hang(i);

                DataRow dr = dt.Rows[i];

                string strSql1 = "select 工序顺序 from db_gongxu where  图号='" + dr["图号"].ToString() + "'";
                string exist = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));//判断是否设置了工序
                if (exist != "")
                {
                    string a = dr[4].ToString();//获取工令号
                    //string strSql = "select getdate() from db_gongxu where  工令号='" + a + "'";
                    string strSql = "select 要求完成 from db_jihuadan where 图号='" + a + "'";
                    DateTime b = Convert.ToDateTime(SQLhelp.ExecuteScalar(strSql, CommandType.Text));
                    DateTime c = DateTime.Now;
                    TimeSpan m = b - c;
                    double g = m.TotalMinutes;
                    string f = m.Days + "天" + m.Hours + "小时" + m.Minutes + "分钟";
                    if (g < 0)   //交货日期 < 现在的时间（超过了加工的时间）1.没有加工完成 2.加工完成 
                    {
                        ////dttotal.Rows[i]["剩余加工时间"] = "全部结束";
                        //dttotal.Rows[i]["序号"] = i + 1;
                        //string s1 = "select max(实际结束时间) from db_gongxu where 工令号='" + a + "'";
                        //DateTime jiagongshijian = Convert.ToDateTime(SQLhelp.ExecuteScalar(s1, CommandType.Text));
                        //if(jiagongshijian < )
                        //{

                        //}

                        string s1 = "select max(工序顺序) from db_shunxu where 图号='" + a + "'";
                        string shunxu1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));

                        string s2 = "select 结束时间 from db_gongxu where 工序顺序='" + shunxu1 + "' and 图号='" + a + "'";
                        string shijian1 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));

                        //1.没有加工完成
                        if (shijian1 == "")
                        {
                            //计算超过的时间
                            TimeSpan m1 = c - b;
                            string shijian2 = m1.Days + "天" + m1.Hours + "小时" + m1.Minutes + "分钟";
                            dt.Rows[i]["剩余加工时间"] = "已超过" + shijian2 + "未完成";

                        }
                        //2.加工完成
                        else
                        {
                            string s3 = "select 结束时间 from db_gongxu where 工序顺序='" + shunxu1 + "' and 图号='" + a + "'";
                            DateTime shijian5 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s3, CommandType.Text));
                            if (shijian5 < b)
                            {
                                dt.Rows[i]["剩余加工时间"] = "全部结束";
                            }
                            else
                            {
                                DateTime shijian3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(s2, CommandType.Text));
                                TimeSpan m3 = shijian3 - b;
                                string shijian4 = m3.Days + "天" + m3.Hours + "小时" + m3.Minutes + "分钟";
                                dt.Rows[i]["剩余加工时间"] = "超过" + shijian4 + "加工完成";
                            }


                        }

                    }
                    else  //交货日期 > 现在的时间(还有剩余的时间可以加工)
                    {
                        dt.Rows[i]["剩余加工时间"] = f;
                        //dttotal.Rows[i]["序号"] = i + 1;
                    }
                }
                else
                {
                    dt.Rows[i]["剩余加工时间"] = "未设置";
                    //dttotal.Rows[i]["序号"] = i + 1;
                }

            }



            //表插入后面的列

            dt.Columns.Add("工序1");
            dt.Columns.Add("工序2");
            dt.Columns.Add("工序3");
            dt.Columns.Add("工序4");
            dt.Columns.Add("工序5");
            dt.Columns.Add("工序6");
            dt.Columns.Add("工序7");
            dt.Columns.Add("工序8");
            dt.Columns.Add("工序9");
            dt.Columns.Add("工序10");

            dt.Columns.Add("工序11");
            dt.Columns.Add("工序12");
            dt.Columns.Add("工序13");
            dt.Columns.Add("工序14");
            dt.Columns.Add("工序15");
            dt.Columns.Add("工序16");
            dt.Columns.Add("工序17");
            dt.Columns.Add("工序18");
            dt.Columns.Add("工序19");
            dt.Columns.Add("工序20");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drtotal = dt.Rows[i];
                string a = drtotal[4].ToString();
                //查工序表中工序号为指定工令的工序
                DataTable dtgongxu = jvti(a);
                for (int j = 0; j < dtgongxu.Rows.Count; j++)
                {
                    DataRow drgx = dtgongxu.Rows[j];
                    if (drgx["工序顺序"].ToString() == "1")
                    {
                        drtotal["工序1"] = drgx["工序名称"];

                    }
                    if (drgx["工序顺序"].ToString() == "2")
                    {
                        drtotal["工序2"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "3")
                    {
                        drtotal["工序3"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "4")
                    {
                        drtotal["工序4"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "5")
                    {
                        drtotal["工序5"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "6")
                    {
                        drtotal["工序6"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "7")
                    {
                        drtotal["工序7"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "8")
                    {
                        drtotal["工序8"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "9")
                    {
                        drtotal["工序9"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "10")
                    {
                        drtotal["工序10"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "11")
                    {
                        drtotal["工序11"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "12")
                    {
                        drtotal["工序12"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "13")
                    {
                        drtotal["工序13"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "14")
                    {
                        drtotal["工序14"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "15")
                    {
                        drtotal["工序15"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "16")
                    {
                        drtotal["工序16"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "17")
                    {
                        drtotal["工序17"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "18")
                    {
                        drtotal["工序18"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "19")
                    {
                        drtotal["工序19"] = drgx["工序名称"];
                    }
                    if (drgx["工序顺序"].ToString() == "20")
                    {
                        drtotal["工序20"] = drgx["工序名称"];
                    }


                }
            }

            this.dataGridView1.DataSource = dt;
            dataGridView1.Columns["目前到达工序"].Width = 150;
            dataGridView1.Columns["剩余加工时间"].Width = 200;

            //dataGridView样式
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
        }

        private string panduan(string a)
        {
            string sql = "select 工序名称 from db_gongxu where getdate()>= 开始时间 and 结束时间 IS NULL and 图号='" + a + "'";
            string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            return result;
        }

        private DataTable jvti(string a)
        {
            string s1 = "select * from db_gongxu where 图号='" + a + "'";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            return dt;
        }

        private void Colorset()
        {
            int row = dataGridView1.Rows.Count;//得到总行数    
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                string str = Convert.ToString(dataGridView1.Rows[i].Cells[19].Value);//取到当前单元格的数据
                string s1 = "加工";
                string s2 = "已";
                if (str.Contains(s1))
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells[19]; //将单元格定位为当前单元格
                    this.dataGridView1.CurrentCell.Style.BackColor = Color.Yellow;// 
                }
                else if (str.Contains(s2))
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells[19]; //将单元格定位为当前单元格
                    this.dataGridView1.CurrentCell.Style.BackColor = Color.Red;// 
                }


            }
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
    }
}
