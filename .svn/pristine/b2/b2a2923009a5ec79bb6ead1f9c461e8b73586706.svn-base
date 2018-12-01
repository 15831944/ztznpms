using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.工序管理
{
    public partial class FormChengben : Form
    {

        double a1, b1, c1, r2, c2, d3, r3, c3, a4, b4, c4, d4, w;
        double w1 = 0.0, w2 = 0.0, w3 = 0.0, w4 = 0.0, w5 = 0.0, w6 = 0.0, w7 = 0.0, w8 = 0.0, w9 = 0.0, w10 = 0.0, wz = 0.0;
        public string cailiaochengben;
        public FormChengben()
        {
            InitializeComponent();
        }

        private void com_mingcheng_Click(object sender, EventArgs e)
        {
            com_mingcheng.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng.Items.Add(a);
            }
        }

        private void com_guige_Click(object sender, EventArgs e)
        {
            com_guige.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '"+ com_mingcheng.Text.Trim() +"'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige.Items.Add(a);
            }
        }

        private void FormChengben_Load(object sender, EventArgs e)
        {
            com_guige.Enabled = false;
            com_guige1.Enabled = false;
            com_guige2.Enabled = false;
            com_guige3.Enabled = false;
            com_guige4.Enabled = false;
            com_guige5.Enabled = false;
            com_guige6.Enabled = false;
            com_guige7.Enabled = false;
            com_guige8.Enabled = false;
            com_guige9.Enabled = false;

            string ss1 = "select * from db_cailiao";
            DataTable row1 = SQLhelp.GetDataTable(ss1, CommandType.Text);
            foreach (DataRow dr1 in row1.Rows)
            {
                this.comboBox1.Items.Add(dr1["材料"].ToString());
                this.comboBox2.Items.Add(dr1["材料"].ToString());
                this.comboBox3.Items.Add(dr1["材料"].ToString());
                this.comboBox4.Items.Add(dr1["材料"].ToString());
                this.comboBox5.Items.Add(dr1["材料"].ToString());
                this.comboBox6.Items.Add(dr1["材料"].ToString());
                this.comboBox7.Items.Add(dr1["材料"].ToString());
                this.comboBox8.Items.Add(dr1["材料"].ToString());
                this.comboBox9.Items.Add(dr1["材料"].ToString());
                this.comboBox10.Items.Add(dr1["材料"].ToString());
            }
            comboBox1.SelectedIndex = 3;
            comboBox2.SelectedIndex = 3;
            comboBox3.SelectedIndex = 3;
            comboBox4.SelectedIndex = 3;
            comboBox5.SelectedIndex = 3;
            comboBox6.SelectedIndex = 3;
            comboBox7.SelectedIndex = 3;
            comboBox8.SelectedIndex = 3;
            comboBox9.SelectedIndex = 3;
            comboBox10.SelectedIndex = 3;
        }

        private void com_mingcheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(com_mingcheng.Text.Trim() != "")
            {
                com_guige.Enabled = true;
            }
            else
            {
                com_guige.Enabled = false;
            }
        }

        private void com_mingcheng1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng1.Text.Trim() != "")
            {
                com_guige1.Enabled = true;
            }
            else
            {
                com_guige1.Enabled = false;
            }
        }

        private void com_mingcheng2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng2.Text.Trim() != "")
            {
                com_guige2.Enabled = true;
            }
            else
            {
                com_guige2.Enabled = false;
            }
        }

        private void com_mingcheng3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng3.Text.Trim() != "")
            {
                com_guige3.Enabled = true;
            }
            else
            {
                com_guige3.Enabled = false;
            }
        }

        private void com_mingcheng4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng4.Text.Trim() != "")
            {
                com_guige4.Enabled = true;
            }
            else
            {
                com_guige4.Enabled = false;
            }
        }

        private void com_mingcheng5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng5.Text.Trim() != "")
            {
                com_guige5.Enabled = true;
            }
            else
            {
                com_guige5.Enabled = false;
            }
        }

        private void com_mingcheng6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng6.Text.Trim() != "")
            {
                com_guige6.Enabled = true;
            }
            else
            {
                com_guige6.Enabled = false;
            }
        }

        private void com_mingcheng7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng7.Text.Trim() != "")
            {
                com_guige7.Enabled = true;
            }
            else
            {
                com_guige7.Enabled = false;
            }
        }

        /// <summary>
        /// 填入价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cailiaochengben = textBox1.Text;
        }

        private void com_mingcheng8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng8.Text.Trim() != "")
            {
                com_guige8.Enabled = true;
            }
            else
            {
                com_guige8.Enabled = false;
            }
        }

        private void com_mingcheng9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_mingcheng9.Text.Trim() != "")
            {
                com_guige9.Enabled = true;
            }
            else
            {
                com_guige9.Enabled = false;
            }
        }

        private void com_mingcheng1_Click(object sender, EventArgs e)
        {
            com_mingcheng1.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng1.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng1.Items.Add(a);
            }
        }

        private void com_mingcheng2_Click(object sender, EventArgs e)
        {
            com_mingcheng2.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng2.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng2.Items.Add(a);
            }
        }

        private void com_mingcheng3_Click(object sender, EventArgs e)
        {
            com_mingcheng3.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng3.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng3.Items.Add(a);
            }
        }

        private void com_mingcheng4_Click(object sender, EventArgs e)
        {
            com_mingcheng4.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng4.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng4.Items.Add(a);
            }
        }

        private void com_mingcheng5_Click(object sender, EventArgs e)
        {
            com_mingcheng5.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng5.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng5.Items.Add(a);
            }
        }

        private void com_mingcheng6_Click(object sender, EventArgs e)
        {
            com_mingcheng6.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng6.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng6.Items.Add(a);
            }
        }

        private void com_mingcheng7_Click(object sender, EventArgs e)
        {
            com_mingcheng7.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng7.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng7.Items.Add(a);
            }
        }

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(com_mingcheng.Text != "" && com_guige.Text != "")
            {
                w1 = WeightCal(l_C1.Text.Trim(), l_K1.Text.Trim(), l_G1.Text.Trim(), y_Z1.Text.Trim(), y_G1.Text.Trim(), y_ZB1.Text.Trim(), y_ZZ1.Text.Trim(), y_ZG1.Text.Trim(), f_C1.Text.Trim(), f_K1.Text.Trim(), f_G1.Text.Trim(), f_B1.Text.Trim(), comboBox1.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='"+ com_mingcheng.Text +"' and 规格='"+ com_guige.Text +"'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w1 = w1 * danjia;
            }

            if (com_mingcheng1.Text != "" && com_guige1.Text != "")
            {
                w2 = WeightCal(l_C2.Text.Trim(), l_K2.Text.Trim(), l_G2.Text.Trim(), y_Z2.Text.Trim(), y_G2.Text.Trim(), y_ZB2.Text.Trim(), y_ZZ2.Text.Trim(), y_ZG2.Text.Trim(), f_C2.Text.Trim(), f_K2.Text.Trim(), f_G2.Text.Trim(), f_B2.Text.Trim(), comboBox2.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng1.Text + "' and 规格='" + com_guige1.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w2 = w2 * danjia;
            }

            if (com_mingcheng2.Text != "" && com_guige2.Text != "")
            {
                w3 = WeightCal(l_C2.Text.Trim(), l_K2.Text.Trim(), l_G2.Text.Trim(), y_Z2.Text.Trim(), y_G2.Text.Trim(), y_ZB2.Text.Trim(), y_ZZ2.Text.Trim(), y_ZG2.Text.Trim(), f_C2.Text.Trim(), f_K2.Text.Trim(), f_G2.Text.Trim(), f_B2.Text.Trim(), comboBox3.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng2.Text + "' and 规格='" + com_guige2.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w3 = w3 * danjia;
            }

            if (com_mingcheng3.Text != "" && com_guige3.Text != "")
            {
                w4 = WeightCal(l_C3.Text.Trim(), l_K3.Text.Trim(), l_G3.Text.Trim(), y_Z3.Text.Trim(), y_G3.Text.Trim(), y_ZB3.Text.Trim(), y_ZZ3.Text.Trim(), y_ZG3.Text.Trim(), f_C3.Text.Trim(), f_K3.Text.Trim(), f_G3.Text.Trim(), f_B3.Text.Trim(), comboBox4.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng3.Text + "' and 规格='" + com_guige3.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w4 = w4 * danjia;
            }

            if (com_mingcheng4.Text != "" && com_guige4.Text != "")
            {
                w5 = WeightCal(l_C4.Text.Trim(), l_K4.Text.Trim(), l_G4.Text.Trim(), y_Z4.Text.Trim(), y_G4.Text.Trim(), y_ZB4.Text.Trim(), y_ZZ4.Text.Trim(), y_ZG4.Text.Trim(), f_C4.Text.Trim(), f_K4.Text.Trim(), f_G4.Text.Trim(), f_B4.Text.Trim(), comboBox5.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng4.Text + "' and 规格='" + com_guige4.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w5 = w5 * danjia;
            }

            if (com_mingcheng5.Text != "" && com_guige5.Text != "")
            {
                w6 = WeightCal(l_C5.Text.Trim(), l_K5.Text.Trim(), l_G5.Text.Trim(), y_Z5.Text.Trim(), y_G5.Text.Trim(), y_ZB5.Text.Trim(), y_ZZ5.Text.Trim(), y_ZG5.Text.Trim(), f_C5.Text.Trim(), f_K5.Text.Trim(), f_G5.Text.Trim(), f_B5.Text.Trim(), comboBox6.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng5.Text + "' and 规格='" + com_guige5.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w6 = w6 * danjia;
            }

            if (com_mingcheng6.Text != "" && com_guige6.Text != "")
            {
                w7 = WeightCal(l_C6.Text.Trim(), l_K6.Text.Trim(), l_G6.Text.Trim(), y_Z6.Text.Trim(), y_G6.Text.Trim(), y_ZB6.Text.Trim(), y_ZZ6.Text.Trim(), y_ZG6.Text.Trim(), f_C6.Text.Trim(), f_K6.Text.Trim(), f_G6.Text.Trim(), f_B6.Text.Trim(), comboBox7.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng6.Text + "' and 规格='" + com_guige6.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w7 = w7 * danjia;
            }

            if (com_mingcheng7.Text != "" && com_guige7.Text != "")
            {
                w8 = WeightCal(l_C7.Text.Trim(), l_K7.Text.Trim(), l_G7.Text.Trim(), y_Z7.Text.Trim(), y_G7.Text.Trim(), y_ZB7.Text.Trim(), y_ZZ7.Text.Trim(), y_ZG7.Text.Trim(), f_C7.Text.Trim(), f_K7.Text.Trim(), f_G7.Text.Trim(), f_B7.Text.Trim(), comboBox8.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng7.Text + "' and 规格='" + com_guige7.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w8 = w8 * danjia;
            }

            if (com_mingcheng8.Text != "" && com_guige8.Text != "")
            {
                w9 = WeightCal(l_C8.Text.Trim(), l_K8.Text.Trim(), l_G8.Text.Trim(), y_Z8.Text.Trim(), y_G8.Text.Trim(), y_ZB8.Text.Trim(), y_ZZ8.Text.Trim(), y_ZG8.Text.Trim(), f_C8.Text.Trim(), f_K8.Text.Trim(), f_G8.Text.Trim(), f_B8.Text.Trim(), comboBox9.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng8.Text + "' and 规格='" + com_guige8.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w9 = w9 * danjia;
            }

            if (com_mingcheng9.Text != "" && com_guige9.Text != "")
            {
                w10 = WeightCal(l_C9.Text.Trim(), l_K9.Text.Trim(), l_G9.Text.Trim(), y_Z9.Text.Trim(), y_G9.Text.Trim(), y_ZB9.Text.Trim(), y_ZZ9.Text.Trim(), y_ZG9.Text.Trim(), f_C9.Text.Trim(), f_K9.Text.Trim(), f_G9.Text.Trim(), f_B9.Text.Trim(), comboBox10.Text);//重量

                string sql = "select 单价 from db_cailiaofenlei where 名称='" + com_mingcheng.Text + "' and 规格='" + com_guige.Text + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                double danjia = Convert.ToDouble(ret);//单价

                w10 = w10 * danjia;
            }

            wz = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8 + w9 + w10;
            wz = Math.Round(wz, 2);
            textBox1.Text = Convert.ToString(wz);
        }

        /// <summary>
        ///   重量计算  double a1, b1, c1, r2, c2, d3, r3, c3, a4, b4, c4, d4;
        /// </summary>
        /// <param name="k1"></param>
        /// <param name="k2"></param>
        /// <param name="k3"></param>
        /// <param name="k4"></param>
        /// <param name="k5"></param>
        /// <param name="k6"></param>
        /// <param name="k7"></param>
        /// <param name="k8"></param>
        /// <param name="k9"></param>
        /// <param name="k10"></param>
        /// <param name="k11"></param>
        /// <param name="k12"></param>
        /// <returns></returns>
        private double WeightCal(string k1,string k2,string k3,string k4,string k5,string k6,string k7,string k8,string k9,string k10,string k11,string k12,string k13)
        {
            if(k1 != "" && k2 != "" && k3 != "")//长方体
            {
                a1 = Convert.ToDouble(k1);
                b1 = Convert.ToDouble(k2);
                c1 = Convert.ToDouble(k3);

                switch (k13)
                {
                    case "电木\r\n":
                        w = (a1 * b1 * c1) * 1.5 / 1000000;
                        break;
                    case "聚氨酯\r\n":
                        w = (a1 * b1 * c1) * 1 / 1000000;
                        break;
                    case "铜\r\n":
                        w = (a1 * b1 * c1) * 8.9 / 1000000;
                        break;
                    case "铁\r\n":
                        w = (a1 * b1 * c1) * 7.9 / 1000000;
                        break;
                    case "尼龙\r\n":
                        w = (a1 * b1 * c1) * 1.15 / 1000000;
                        break;
                    case "铝\r\n":
                        w = (a1 * b1 * c1) * 2.78 / 1000000;
                        break;
                }
            }

            if (k4 != "" && k5 != "")//圆柱体
            {
                r2 = Convert.ToDouble(k4);
                c2 = Convert.ToDouble(k5);

                switch (k13)
                {
                    case "电木\r\n":
                        w = (3.14 * r2 * r2 / 4 * c2) * 1.5 / 1000000;
                        break;
                    case "聚氨酯\r\n":
                        w = (3.14 * r2 * r2 / 4 * c2) * 1 / 1000000;
                        break;
                    case "铜\r\n":
                        w = (3.14 * r2 * r2 / 4 * c2) * 8.9 / 1000000;
                        break;
                    case "铁\r\n":
                        w = (3.14 * r2 * r2 / 4 * c2) * 7.9 / 1000000;
                        break;
                    case "尼龙\r\n":
                        w = (3.14 * r2 * r2 / 4 * c2) * 1.15 / 1000000;
                        break;
                    case "铝\r\n":
                        w = (3.14 * r2 * r2 / 4 * c2) * 2.78 / 1000000;
                        break;
                }
            }

            if (k6 != "" && k7 != "" && k8 != "")//圆管
            {
                d3 = Convert.ToDouble(k6);
                r3 = Convert.ToDouble(k7);
                c3 = Convert.ToDouble(k8);
            }

            if (k9 != "" && k10 != "" && k11 != "" && k12 != "")//方管
            {
                a4 = Convert.ToDouble(k9);
                b4 = Convert.ToDouble(k10);
                c4 = Convert.ToDouble(k11);
                d4 = Convert.ToDouble(k12);
            }

            return w;
        }


        private void com_mingcheng8_Click(object sender, EventArgs e)
        {
            com_mingcheng8.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng8.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng8.Items.Add(a);
            }
        }

        private void com_mingcheng9_Click(object sender, EventArgs e)
        {
            com_mingcheng9.Items.Clear();
            string sql = "select 名称 from db_cailiaofenlei ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["名称"].ToString();
                if (com_mingcheng9.Items.Cast<object>().All(x => x.ToString() != a))
                    com_mingcheng9.Items.Add(a);
            }
        }

        private void com_guige1_Click(object sender, EventArgs e)
        {
            com_guige1.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng1.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige1.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige1.Items.Add(a);
            }
        }

        private void com_guige2_Click(object sender, EventArgs e)
        {
            com_guige2.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng2.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige2.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige2.Items.Add(a);
            }
        }

        private void com_guige3_Click(object sender, EventArgs e)
        {
            com_guige3.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng3.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige3.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige3.Items.Add(a);
            }
        }

        private void com_guige4_Click(object sender, EventArgs e)
        {
            com_guige4.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng4.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige4.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige4.Items.Add(a);
            }
        }

        private void com_guige5_Click(object sender, EventArgs e)
        {
            com_guige5.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng5.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige5.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige5.Items.Add(a);
            }
        }

        private void com_guige6_Click(object sender, EventArgs e)
        {
            com_guige6.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng6.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige6.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige6.Items.Add(a);
            }
        }

        private void com_guige7_Click(object sender, EventArgs e)
        {
            com_guige7.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng7.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige7.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige7.Items.Add(a);
            }
        }

        private void com_guige8_Click(object sender, EventArgs e)
        {
            com_guige8.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng8.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige8.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige8.Items.Add(a);
            }
        }

        private void com_guige9_Click(object sender, EventArgs e)
        {
            com_guige9.Items.Clear();
            string sql = "select 规格 from db_cailiaofenlei where 名称= '" + com_mingcheng9.Text.Trim() + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["规格"].ToString();
                if (com_guige9.Items.Cast<object>().All(x => x.ToString() != a))
                    com_guige9.Items.Add(a);
            }
        }
    }
}
