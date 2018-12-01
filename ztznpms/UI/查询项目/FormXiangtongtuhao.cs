using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.查询项目
{
    public partial class FormXiangtongtuhao : Form //DevExpress.XtraEditors.XtraForm
    {

        private string leixing;
        private string lujing;
        private string yonghu;

        public FormXiangtongtuhao()
        {
            InitializeComponent();
        }

        private void FormXiangtongtuhao_Load(object sender, EventArgs e)
        {
            com_bianzhiren.Items.Add("徐小明");
            com_bianzhiren.Items.Add("石炜");
            com_bianzhiren.Items.Add("袁天坤");
            com_bianzhiren.Items.Add("庄飞");

            FormMain frmMain = new FormMain();
            yonghu = frmMain.yonghuming;
            if (yonghu == "徐小明")
            {
                com_bianzhiren.SelectedIndex = 0;
            }
            if (yonghu == "石炜")
            {
                com_bianzhiren.SelectedIndex = 1;
            }
            if (yonghu == "袁天坤")
            {
                com_bianzhiren.SelectedIndex = 2;
            }
            if (yonghu == "庄飞")
            {
                com_bianzhiren.SelectedIndex = 3;
            }

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

            }

            ////工序负责人
            //string s11 = "select * from db_chejianrenyuan";
            //DataTable cr = SQLhelp.GetDataTable(s11, CommandType.Text);

            //foreach (DataRow dr in cr.Rows)
            //{
            //    this.comboBox21.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox22.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox23.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox24.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox25.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox26.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox27.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox28.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox29.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox30.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox31.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox32.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox33.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox34.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox35.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox36.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox37.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox38.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox39.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox40.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox41.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox42.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox43.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox44.Items.Add(dr["机加车间人员"].ToString());
            //    this.comboBox45.Items.Add(dr["机加车间人员"].ToString());
            //}

            shebeiload();
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

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void startload()
        {
            string s2 = "select * from db_gongxu1 where 图号='" + txt_tuhao.Text.Trim() + "' or 名称='"+ txt_tuhao.Text.Trim() +"'";
            DataTable dtg = SQLhelp.GetDataTable(s2, CommandType.Text);//通过图号、名称查到db_gongxu1表中的数据

            for (int i = 0; i < dtg.Rows.Count; i++)
            {
                DataRow drg = dtg.Rows[i];//拿到每一行的数据
                if (drg["工序顺序"].ToString() == "1")
                {
                    comboBox1.Text = drg["工序名称"].ToString();
                    richTextBox1.Text = drg["工序内容"].ToString();
                    txt_gx1.Text = drg["价格"].ToString();
                    richTextBox27.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "2")
                {
                    comboBox2.Text = drg["工序名称"].ToString();
                    richTextBox2.Text = drg["工序内容"].ToString();
                    txt_gx2.Text = drg["价格"].ToString();
                    richTextBox28.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "3")
                {
                    comboBox3.Text = drg["工序名称"].ToString();
                    richTextBox3.Text = drg["工序内容"].ToString();
                    txt_gx3.Text = drg["价格"].ToString();
                    richTextBox29.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "4")
                {
                    comboBox4.Text = drg["工序名称"].ToString();
                    richTextBox4.Text = drg["工序内容"].ToString();
                    txt_gx4.Text = drg["价格"].ToString();
                    richTextBox30.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "5")
                {
                    comboBox5.Text = drg["工序名称"].ToString();
                    richTextBox5.Text = drg["工序内容"].ToString();
                    txt_gx5.Text = drg["价格"].ToString();
                    richTextBox31.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "6")
                {
                    comboBox6.Text = drg["工序名称"].ToString();
                    richTextBox6.Text = drg["工序内容"].ToString();
                    txt_gx6.Text = drg["价格"].ToString();
                    richTextBox32.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "7")
                {
                    comboBox7.Text = drg["工序名称"].ToString();
                    richTextBox7.Text = drg["工序内容"].ToString();
                    txt_gx7.Text = drg["价格"].ToString();
                    richTextBox33.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "8")
                {
                    comboBox8.Text = drg["工序名称"].ToString();
                    richTextBox8.Text = drg["工序内容"].ToString();
                    txt_gx8.Text = drg["价格"].ToString();
                    richTextBox34.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "9")
                {
                    comboBox9.Text = drg["工序名称"].ToString();
                    richTextBox9.Text = drg["工序内容"].ToString();
                    txt_gx9.Text = drg["价格"].ToString();
                    richTextBox35.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "10")
                {
                    comboBox10.Text = drg["工序名称"].ToString();
                    richTextBox10.Text = drg["工序内容"].ToString();
                    txt_gx10.Text = drg["价格"].ToString();
                    richTextBox36.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "11")
                {
                    comboBox11.Text = drg["工序名称"].ToString();
                    richTextBox11.Text = drg["工序内容"].ToString();
                    txt_gx11.Text = drg["价格"].ToString();
                    richTextBox37.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "12")
                {
                    comboBox12.Text = drg["工序名称"].ToString();
                    richTextBox12.Text = drg["工序内容"].ToString();
                    txt_gx12.Text = drg["价格"].ToString();
                    richTextBox38.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "13")
                {
                    comboBox13.Text = drg["工序名称"].ToString();
                    richTextBox13.Text = drg["工序内容"].ToString();
                    txt_gx13.Text = drg["价格"].ToString();
                    richTextBox39.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "14")
                {
                    comboBox14.Text = drg["工序名称"].ToString();
                    richTextBox14.Text = drg["工序内容"].ToString();
                    txt_gx14.Text = drg["价格"].ToString();
                    richTextBox40.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "15")
                {
                    comboBox15.Text = drg["工序名称"].ToString();
                    richTextBox15.Text = drg["工序内容"].ToString();
                    txt_gx15.Text = drg["价格"].ToString();
                    richTextBox41.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "16")
                {
                    comboBox16.Text = drg["工序名称"].ToString();
                    richTextBox16.Text = drg["工序内容"].ToString();
                    txt_gx16.Text = drg["价格"].ToString();
                    richTextBox42.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "17")
                {
                    comboBox17.Text = drg["工序名称"].ToString();
                    richTextBox17.Text = drg["工序内容"].ToString();
                    txt_gx17.Text = drg["价格"].ToString();
                    richTextBox43.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "18")
                {
                    comboBox18.Text = drg["工序名称"].ToString();
                    richTextBox18.Text = drg["工序内容"].ToString();
                    txt_gx18.Text = drg["价格"].ToString();
                    richTextBox44.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "19")
                {
                    comboBox19.Text = drg["工序名称"].ToString();
                    richTextBox19.Text = drg["工序内容"].ToString();
                    txt_gx19.Text = drg["价格"].ToString();
                    richTextBox45.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "20")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    richTextBox46.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "21")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    richTextBox47.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "22")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    richTextBox48.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "23")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    richTextBox49.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "24")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    richTextBox50.Text = drg["工艺注意点"].ToString();
                }
                if (drg["工序顺序"].ToString() == "25")
                {
                    comboBox20.Text = drg["工序名称"].ToString();
                    richTextBox20.Text = drg["工序内容"].ToString();
                    txt_gx20.Text = drg["价格"].ToString();
                    richTextBox51.Text = drg["工艺注意点"].ToString();
                }

            }

            //string s1 = "select max(工序顺序) from db_gongxu1 where 图号='" + txt_tuhao.Text.Trim() + "' ";
            //string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));
            //if (r1 != "")
            //{
            //    btn_save.Enabled = false;
            //    enabled();
            //}

        }

        /// <summary>
        /// 生成工艺卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Gongyika_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txt_tuhao.Text.Trim() == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }

            string sql = "select * from db_gongxu1 where 图号='" + txt_tuhao.Text.Trim() + "' or 名称='" + txt_tuhao.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret == "")
            {
                MessageBox.Show("没有查询到相同的图纸，请检查图号或名称输入是否有误！", "提示");
                return;
            }
            else
            {
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataRow row = dt.Rows[0];

                txt_th.Text = row["图号"].ToString();
                txt_xiangmumingcheng.Text = row["项目名称"].ToString();
                txt_gonglinghao.Text = row["工作令号"].ToString();
                txt_shebei.Text = row["设备名称"].ToString();
                txt_lingjianmingcheng.Text = row["名称"].ToString();
                txt_danhao.Text = row["设备编号"].ToString();
                txt_jiagongshuliang.Text = row["数量"].ToString();
                txt_danhao.Text = row["编码"].ToString();

                startload();
            }
        }

        private void btn_Gongyika_Click_1(object sender, EventArgs e)
        {
            string timeDate1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string timeDate2 = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            DateTime a = Convert.ToDateTime(timeDate1);
            DateTime b = Convert.ToDateTime(timeDate2);

            if (b <= a)
            {
                MessageBox.Show("请重新设置交货日期", "提示");
                return;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("产品名称", typeof(string));
            dt.Columns.Add("零件名称", typeof(string));
            dt.Columns.Add("编号", typeof(string));
            dt.Columns.Add("零件图号", typeof(string));
            dt.Columns.Add("下单日期", typeof(string));
            dt.Columns.Add("交货日", typeof(string));
            //dt.Columns.Add("加工数量", typeof(string));
            dt.Columns.Add("工令号", typeof(string));

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
            //dt.Columns.Add("序号16", typeof(string));
            //dt.Columns.Add("序号17", typeof(string));
            //dt.Columns.Add("序号18", typeof(string));
            //dt.Columns.Add("序号19", typeof(string));

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
            //dt.Columns.Add("工序16", typeof(string));
            //dt.Columns.Add("工序17", typeof(string));
            //dt.Columns.Add("工序18", typeof(string));
            //dt.Columns.Add("工序19", typeof(string));

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
            //dt.Columns.Add("内容16", typeof(string));
            //dt.Columns.Add("内容17", typeof(string));
            //dt.Columns.Add("内容18", typeof(string));
            //dt.Columns.Add("内容19", typeof(string));

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

            dt.Columns.Add("编制人日期", typeof(string));

            DataRow dr = dt.NewRow();

            dr["产品名称"] = txt_shebei.Text;
            dr["零件名称"] = txt_lingjianmingcheng.Text;
            dr["编号"] = txt_danhao.Text;
            dr["零件图号"] = txt_tuhao.Text;
            dr["下单日期"] = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            dr["交货日"] = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            //dr["加工数量"] = txt_jiagongshuliang.Text;
            dr["工令号"] = txt_gonglinghao.Text;

            if (comboBox1.Text.Trim() != "")
            {
                dr["序号1"] = "1";
                dr["工序1"] = comboBox1.Text.Trim();
                dr["内容1"] = richTextBox1.Text;
                dr["负责人1"] = comboBox21.Text;
                dr["价格1"] = txt_gx1.Text;
            }
            if (comboBox2.Text.Trim() != "")
            {
                dr["序号2"] = "2";
                dr["工序2"] = comboBox2.Text.Trim();
                dr["内容2"] = richTextBox2.Text;
                dr["负责人2"] = comboBox22.Text;
                dr["价格2"] = txt_gx2.Text;
            }
            if (comboBox3.Text.Trim() != "")
            {
                dr["序号3"] = "3";
                dr["工序3"] = comboBox3.Text.Trim();
                dr["内容3"] = richTextBox3.Text;
                dr["负责人3"] = comboBox23.Text;
                dr["价格3"] = txt_gx3.Text;
            }
            if (comboBox4.Text.Trim() != "")
            {
                dr["序号4"] = "4";
                dr["工序4"] = comboBox4.Text.Trim();
                dr["内容4"] = richTextBox4.Text;
                dr["负责人4"] = comboBox24.Text;
                dr["价格4"] = txt_gx4.Text;
            }
            if (comboBox5.Text.Trim() != "")
            {
                dr["序号5"] = "5";
                dr["工序5"] = comboBox5.Text.Trim();
                dr["内容5"] = richTextBox5.Text;
                dr["负责人5"] = comboBox25.Text;
                dr["价格5"] = txt_gx5.Text;
            }
            if (comboBox6.Text.Trim() != "")
            {
                dr["序号6"] = "6";
                dr["工序6"] = comboBox6.Text.Trim();
                dr["内容6"] = richTextBox6.Text;
                dr["负责人6"] = comboBox26.Text;
                dr["价格6"] = txt_gx6.Text;
            }
            if (comboBox7.Text.Trim() != "")
            {
                dr["序号7"] = "7";
                dr["工序7"] = comboBox7.Text.Trim();
                dr["内容7"] = richTextBox7.Text;
                dr["负责人7"] = comboBox27.Text;
                dr["价格7"] = txt_gx7.Text;
            }
            if (comboBox8.Text.Trim() != "")
            {
                dr["序号8"] = "8";
                dr["工序8"] = comboBox8.Text.Trim();
                dr["内容8"] = richTextBox8.Text;
                dr["负责人8"] = comboBox28.Text;
                dr["价格8"] = txt_gx8.Text;
            }
            if (comboBox9.Text.Trim() != "")
            {
                dr["序号9"] = "9";
                dr["工序9"] = comboBox9.Text.Trim();
                dr["内容9"] = richTextBox9.Text;
                dr["负责人9"] = comboBox29.Text;
                dr["价格9"] = txt_gx9.Text;
            }
            if (comboBox10.Text.Trim() != "")
            {
                dr["序号10"] = "10";
                dr["工序10"] = comboBox10.Text.Trim();
                dr["内容10"] = richTextBox10.Text;
                dr["负责人10"] = comboBox30.Text;
                dr["价格10"] = txt_gx10.Text;
            }
            if (comboBox11.Text.Trim() != "")
            {
                dr["序号11"] = "11";
                dr["工序11"] = comboBox11.Text.Trim();
                dr["内容11"] = richTextBox11.Text;
                dr["负责人11"] = comboBox31.Text;
                dr["价格11"] = txt_gx11.Text;
            }
            if (comboBox12.Text.Trim() != "")
            {
                dr["序号12"] = "12";
                dr["工序12"] = comboBox12.Text.Trim();
                dr["内容12"] = richTextBox12.Text;
                dr["负责人12"] = comboBox32.Text;
                dr["价格12"] = txt_gx12.Text;
            }
            if (comboBox13.Text.Trim() != "")
            {
                dr["序号13"] = "13";
                dr["工序13"] = comboBox13.Text.Trim();
                dr["内容13"] = richTextBox13.Text;
                dr["负责人13"] = comboBox33.Text;
                dr["价格13"] = txt_gx13.Text;
            }
            if (comboBox14.Text.Trim() != "")
            {
                dr["序号14"] = "14";
                dr["工序14"] = comboBox14.Text.Trim();
                dr["内容14"] = richTextBox14.Text;
                dr["负责人14"] = comboBox34.Text;
                dr["价格14"] = txt_gx14.Text;
            }
            if (comboBox15.Text.Trim() != "")
            {
                dr["序号15"] = "15";
                dr["工序15"] = comboBox15.Text.Trim();
                dr["内容15"] = richTextBox15.Text;
                dr["负责人15"] = comboBox35.Text;
                dr["价格15"] = txt_gx15.Text;
            }
            //if (comboBox16.Text.Trim() != "")
            //{
            //    dr["序号16"] = "16";
            //    dr["工序16"] = comboBox16.Text.Trim();
            //    dr["内容16"] = richTextBox16.Text;
            //}
            //if (comboBox17.Text.Trim() != "")
            //{
            //    dr["序号17"] = "17";
            //    dr["工序17"] = comboBox17.Text.Trim();
            //    dr["内容17"] = richTextBox17.Text;
            //}
            //if (comboBox18.Text.Trim() != "")
            //{
            //    dr["序号18"] = "18";
            //    dr["工序18"] = comboBox18.Text.Trim();
            //    dr["内容18"] = richTextBox18.Text;
            //}
            //if (comboBox19.Text.Trim() != "")
            //{
            //    dr["序号19"] = "19";
            //    dr["工序19"] = comboBox19.Text.Trim();
            //    dr["内容19"] = richTextBox19.Text;
            //}

            string time1 = DateTime.Now.ToString("yyyy/MM/dd");
            dr["编制人日期"] = com_bianzhiren.Text.Trim() + time1;

            dt.Rows.Add(dr);

            string tempFile = Application.StartupPath + "\\工艺卡模板新.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr1 = dt.Rows[0];

            dic.Add("产品名称", dr["产品名称"].ToString());
            dic.Add("零件名称", dr["零件名称"].ToString());
            dic.Add("编号", dr["编号"].ToString());
            dic.Add("零件图号", dr["零件图号"].ToString());
            dic.Add("下单日期", dr["下单日期"].ToString());
            dic.Add("交货日", dr["交货日"].ToString());
            //dic.Add("加工数量", dr["加工数量"].ToString());
            dic.Add("工令号", dr["工令号"].ToString());

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
            //dic.Add("序号16", dr["序号16"].ToString());
            //dic.Add("序号17", dr["序号17"].ToString());
            //dic.Add("序号18", dr["序号18"].ToString());
            //dic.Add("序号19", dr["序号19"].ToString());


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
            //dic.Add("工序16", dr["工序16"].ToString());
            //dic.Add("工序17", dr["工序17"].ToString());
            //dic.Add("工序18", dr["工序18"].ToString());
            //dic.Add("工序19", dr["工序19"].ToString());

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
            //dic.Add("内容16", dr["内容16"].ToString());
            //dic.Add("内容17", dr["内容17"].ToString());
            //dic.Add("内容18", dr["内容18"].ToString());
            //dic.Add("内容19", dr["内容19"].ToString());

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

            string docName = txt_gonglinghao.Text + "-" + txt_shebei.Text + "-" + str1 + "-" + txt_lingjianmingcheng.Text + ".doc";
            //FileInfo info1 = new FileInfo(Application.StartupPath + "\\" + docName); 
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            MessageBox.Show("工艺卡保存到桌面成功！", "提示");
        }

        private void btn_open_Click_1(object sender, EventArgs e)
        {
            string sql = "select 附件名称 from db_xiangmu where 图号='" + txt_th.Text.Trim() + "' and 名称='" + txt_lingjianmingcheng.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

            if (ret != "")
            {
                string chaxun11 = "select 附件类型 from db_xiangmu where  附件名称='" + ret + "' and 图号='" + txt_th.Text.Trim() + "' and 名称='" + txt_lingjianmingcheng.Text.Trim() + "'";
                leixing = SQLhelp.ExecuteScalar(chaxun11, CommandType.Text).ToString();


                byte[] mypdffile = null;
                string sqlfujian= "select 附件 from db_xiangmu where 附件名称='" + ret + "' and 名称='" + txt_lingjianmingcheng.Text.Trim() + "' and 图号='" + txt_th.Text.Trim() + "'";
                mypdffile = SQLhelp.duqu(sqlfujian, CommandType.Text);

                //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";

                //SqlConnection con = new SqlConnection(ConStr);
                //SqlCommand cmd = new SqlCommand("", con);
                //cmd.CommandText = "select 附件 from db_xiangmu where 附件名称='" + ret + "' and 名称='" + txt_lingjianmingcheng.Text.Trim() + "' and 图号='" + txt_th.Text.Trim() + "'";
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
                    //lujing = aaaa + "\\" + b + " 和 "+ a + "和" + "." + leixing;
                    lujing = aaaa + "\\" + txt_lingjianmingcheng.Text.Trim() + "." + leixing;
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
                txt_tuzhi.Text = lujing;

                if (webBrowser1 != null && !webBrowser1.IsDisposed)
                {
                    this.webBrowser1.Navigate(txt_tuzhi.Text);
                }
            }
            else
            {
                MessageBox.Show("技术部还未上传该图纸！");
                return;
            }
        }
    }
}
