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
    public partial class cailiaozhongliang : Form
    {
        public string gx1;
        public string gx2;
        public string gx3;
        public string gx4;
        public string gx5;
        public string gx6;
        public string gx7;
        public string gx8;
        public string gx9;
        public string gx10;
        public string gx11;
        public string gx12;
        public string gx13;
        public string gx14;
        public string gx15;
        public string gx16;
        public string gx17;
        public string gx18;
        public string gx19;
        public string gx20;
        public string gx21;
        public string gx22;
        public string gx23;
        public string gx24;
        public string gx25;

        public string cailiao1;
        public string cailiao2;
        public string cailiao3;
        public string cailiao4;
        public string cailiao5;
        public string cailiao6;
        public string cailiao7;
        public string cailiao8;
        public string cailiao9;
        public string cailiao10;

        public string zhongliang1;
        public string zhongliang2;
        public string zhongliang3;
        public string zhongliang4;
        public string zhongliang5;
        public string zhongliang6;
        public string zhongliang7;
        public string zhongliang8;
        public string zhongliang9;
        public string zhongliang10;


        double midu, w;
        public cailiaozhongliang()
        {
            InitializeComponent();
        }

        private void cailiaozhongliang_Load(object sender, EventArgs e)
        {
            textBox1.Text = gx1;
            textBox2.Text = gx2;
            textBox3.Text = gx3;
            textBox4.Text = gx4;
            textBox5.Text = gx5;
            textBox6.Text = gx6;
            textBox7.Text = gx7;
            textBox8.Text = gx8;
            textBox9.Text = gx9;
            textBox10.Text = gx10;

            comboBox1.Items.Clear();
            string sql = "select 材料 from db_cailiaoguige ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox1.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox1.Items.Add(a);
            }

            comboBox2.Items.Clear();
            string sql1 = "select 材料 from db_cailiaoguige ";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            foreach (DataRow row in dt1.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox2.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox2.Items.Add(a);
            }

            comboBox3.Items.Clear();
            string sql2 = "select 材料 from db_cailiaoguige ";
            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);

            foreach (DataRow row in dt2.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox3.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox3.Items.Add(a);
            }

            comboBox4.Items.Clear();
            string sql3 = "select 材料 from db_cailiaoguige ";
            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);

            foreach (DataRow row in dt3.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox4.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox4.Items.Add(a);
            }

            com_cailiao5.Items.Clear();
            string sql4 = "select 材料 from db_cailiaoguige ";
            DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);

            foreach (DataRow row in dt4.Rows)
            {
                string a = row["材料"].ToString();
                if (com_cailiao5.Items.Cast<object>().All(x => x.ToString() != a))
                    com_cailiao5.Items.Add(a);
            }

            com_cailiao6.Items.Clear();
            string sql5 = "select 材料 from db_cailiaoguige ";
            DataTable dt5 = SQLhelp.GetDataTable(sql5, CommandType.Text);

            foreach (DataRow row in dt5.Rows)
            {
                string a = row["材料"].ToString();
                if (com_cailiao6.Items.Cast<object>().All(x => x.ToString() != a))
                    com_cailiao6.Items.Add(a);
            }

            com_cailiao7.Items.Clear();
            string sql6 = "select 材料 from db_cailiaoguige ";
            DataTable dt6 = SQLhelp.GetDataTable(sql6, CommandType.Text);

            foreach (DataRow row in dt6.Rows)
            {
                string a = row["材料"].ToString();
                if (com_cailiao7.Items.Cast<object>().All(x => x.ToString() != a))
                    com_cailiao7.Items.Add(a);
            }

            com_cailiao8.Items.Clear();
            string sql7 = "select 材料 from db_cailiaoguige ";
            DataTable dt7 = SQLhelp.GetDataTable(sql7, CommandType.Text);

            foreach (DataRow row in dt7.Rows)
            {
                string a = row["材料"].ToString();
                if (com_cailiao8.Items.Cast<object>().All(x => x.ToString() != a))
                    com_cailiao8.Items.Add(a);
            }

            com_cailiao9.Items.Clear();
            string sql8 = "select 材料 from db_cailiaoguige ";
            DataTable dt8 = SQLhelp.GetDataTable(sql8, CommandType.Text);

            foreach (DataRow row in dt8.Rows)
            {
                string a = row["材料"].ToString();
                if (com_cailiao9.Items.Cast<object>().All(x => x.ToString() != a))
                    com_cailiao9.Items.Add(a);
            }

            com_cailiao10.Items.Clear();
            string sql9 = "select 材料 from db_cailiaoguige ";
            DataTable dt9 = SQLhelp.GetDataTable(sql9, CommandType.Text);

            foreach (DataRow row in dt9.Rows)
            {
                string a = row["材料"].ToString();
                if (com_cailiao10.Items.Cast<object>().All(x => x.ToString() != a))
                    com_cailiao10.Items.Add(a);
            }
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='"+ comboBox1.Text.Trim() +"' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if(ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox5.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox5.Items.Add(a);
                }
            }

        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox2.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox6.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox6.Items.Add(a);
                }
            }
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox3.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox7.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox7.Items.Add(a);
                }
            }
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox4.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox8.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox8.Items.Add(a);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text.Trim() != "")
            {
                B_C1.Text = ""; B_K1.Text = ""; B_G1.Text = ""; J_C1.Text = ""; Y_W1.Text = ""; Y_C1.Text = ""; Y_B1.Text = ""; C_C1.Text = ""; G_C1.Text = ""; F_C1.Text = "";

                switch (comboBox1.Text.Trim())
                {
                    case "板":
                        B_C1.Enabled = true; B_K1.Enabled = true; B_G1.Enabled = true; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "角钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = true; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "圆钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = true; Y_C1.Enabled = true; Y_B1.Enabled = true; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "圆管":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = true; Y_C1.Enabled = true; Y_B1.Enabled = true; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "槽钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = true; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "工字钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = true; F_C1.Enabled = false;
                        break;
                    case "方管":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = true;
                        break;

                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim() != "")
            {
                B_C2.Text = ""; B_K2.Text = ""; B_G2.Text = ""; J_C2.Text = ""; Y_W2.Text = ""; Y_C2.Text = ""; Y_B2.Text = ""; C_C2.Text = ""; G_C2.Text = ""; F_C2.Text = "";
                switch (comboBox2.Text.Trim())
                {
                    case "板":
                        B_C2.Enabled = true; B_K2.Enabled = true; B_G2.Enabled = true; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "角钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = true; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "圆钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = true; Y_C2.Enabled = true; Y_B2.Enabled = true; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "圆管":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = true; Y_C2.Enabled = true; Y_B2.Enabled = true; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "槽钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = true; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "工字钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = true; F_C2.Enabled = false;
                        break;
                    case "方管":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = true;
                        break;

                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Trim() != "")
            {
                B_C3.Text = ""; B_K3.Text = ""; B_G3.Text = ""; J_C3.Text = ""; Y_W3.Text = ""; Y_C3.Text = ""; Y_B3.Text = ""; C_C3.Text = ""; G_C3.Text = ""; F_C3.Text = "";
                switch (comboBox3.Text.Trim())
                {
                    case "板":
                        B_C3.Enabled = true;B_K3.Enabled = true;B_G3.Enabled = true;J_C3.Enabled = false;Y_W3.Enabled = false;Y_C3.Enabled = false;Y_B3.Enabled = false;C_C3.Enabled = false;G_C3.Enabled = false;F_C3.Enabled = false;
                        break;
                    case "角钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = true; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "圆钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = true; Y_C3.Enabled = true; Y_B3.Enabled = true; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "圆管":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = true; Y_C3.Enabled = true; Y_B3.Enabled = true; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "槽钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = true; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "工字钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = true; F_C3.Enabled = false;
                        break;
                    case "方管":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = true;
                        break;

                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text.Trim() != "")
            {
                B_C4.Text = ""; B_K4.Text = ""; B_G4.Text = ""; J_C4.Text = ""; Y_W4.Text = ""; Y_C4.Text = ""; Y_B4.Text = ""; C_C4.Text = ""; G_C4.Text = ""; F_C4.Text = "";
                switch (comboBox4.Text.Trim())
                {
                    case "板":
                        B_C4.Enabled = true; B_K4.Enabled = true; B_G4.Enabled = true; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "角钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = true; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "圆钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = true; Y_C4.Enabled = true; Y_B4.Enabled = true; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "圆管":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = true; Y_C4.Enabled = true; Y_B4.Enabled = true; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "槽钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = true; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "工字钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = true; F_C4.Enabled = false;
                        break;
                    case "方管":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = true;
                        break;

                }
            }
        }

        /// <summary>
        /// 计算重量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            zl1.Text = "";
            zl2.Text = "";
            zl3.Text = "";
            zl4.Text = "";
            zl5.Text = "";
            zl6.Text = "";
            zl7.Text = "";
            zl8.Text = "";
            zl9.Text = "";
            zl10.Text = "";

            if (comboBox1.Text.Trim() != "" && comboBox5.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox1.Text.Trim(), comboBox5.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox1.Text.Trim(), B_C1.Text.Trim(), B_K1.Text.Trim(), B_G1.Text.Trim(), J_C1.Text.Trim(), Y_W1.Text.Trim(), Y_C1.Text.Trim(), Y_B1.Text.Trim(), C_C1.Text.Trim(), G_C1.Text.Trim(), F_C1.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl1.Text = Convert.ToString(z);
            }

            if(comboBox2.Text.Trim() != "" && comboBox6.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox2.Text.Trim(), comboBox6.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox2.Text.Trim(), B_C2.Text.Trim(), B_K2.Text.Trim(), B_G2.Text.Trim(), J_C2.Text.Trim(), Y_W2.Text.Trim(), Y_C2.Text.Trim(), Y_B2.Text.Trim(), C_C2.Text.Trim(), G_C2.Text.Trim(), F_C2.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl2.Text = Convert.ToString(z);
            }

            if(comboBox3.Text.Trim() != "" && comboBox7.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox3.Text.Trim(), comboBox7.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox3.Text.Trim(), B_C3.Text.Trim(), B_K3.Text.Trim(), B_G3.Text.Trim(), J_C3.Text.Trim(), Y_W3.Text.Trim(), Y_C3.Text.Trim(), Y_B3.Text.Trim(), C_C3.Text.Trim(), G_C3.Text.Trim(), F_C3.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl3.Text = Convert.ToString(z);
            }

            if(comboBox4.Text.Trim() != "" && comboBox8.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox4.Text.Trim(), comboBox8.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox4.Text.Trim(), B_C4.Text.Trim(), B_K4.Text.Trim(), B_G4.Text.Trim(), J_C4.Text.Trim(), Y_W4.Text.Trim(), Y_C4.Text.Trim(), Y_B4.Text.Trim(), C_C4.Text.Trim(), G_C4.Text.Trim(), F_C4.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl4.Text = Convert.ToString(z);
            }

            if (com_cailiao5.Text.Trim() != "" && com_xinghao5.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(com_cailiao5.Text.Trim(), com_xinghao5.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(com_cailiao5.Text.Trim(), B_C5.Text.Trim(), B_K5.Text.Trim(), B_G5.Text.Trim(), J_C5.Text.Trim(), Y_W5.Text.Trim(), Y_C5.Text.Trim(), Y_B5.Text.Trim(), C_C5.Text.Trim(), G_C5.Text.Trim(), F_C5.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl5.Text = Convert.ToString(z);
            }

            if (com_cailiao6.Text.Trim() != "" && com_xinghao6.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(com_cailiao6.Text.Trim(), com_xinghao6.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(com_cailiao6.Text.Trim(), B_C6.Text.Trim(), B_K6.Text.Trim(), B_G6.Text.Trim(), J_C6.Text.Trim(), Y_W6.Text.Trim(), Y_C6.Text.Trim(), Y_B6.Text.Trim(), C_C6.Text.Trim(), G_C6.Text.Trim(), F_C6.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl6.Text = Convert.ToString(z);
            }

            if (com_cailiao7.Text.Trim() != "" && com_xinghao7.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(com_cailiao7.Text.Trim(), com_xinghao7.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(com_cailiao7.Text.Trim(), B_C7.Text.Trim(), B_K7.Text.Trim(), B_G7.Text.Trim(), J_C7.Text.Trim(), Y_W7.Text.Trim(), Y_C7.Text.Trim(), Y_B7.Text.Trim(), C_C7.Text.Trim(), G_C7.Text.Trim(), F_C7.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl7.Text = Convert.ToString(z);
            }

            if (com_cailiao8.Text.Trim() != "" && com_xinghao8.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(com_cailiao8.Text.Trim(), com_xinghao8.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(com_cailiao8.Text.Trim(), B_C8.Text.Trim(), B_K8.Text.Trim(), B_G8.Text.Trim(), J_C8.Text.Trim(), Y_W8.Text.Trim(), Y_C8.Text.Trim(), Y_B8.Text.Trim(), C_C8.Text.Trim(), G_C8.Text.Trim(), F_C8.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl8.Text = Convert.ToString(z);
            }

            if (com_cailiao9.Text.Trim() != "" && com_xinghao9.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(com_cailiao9.Text.Trim(), com_xinghao9.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(com_cailiao9.Text.Trim(), B_C9.Text.Trim(), B_K9.Text.Trim(), B_G9.Text.Trim(), J_C9.Text.Trim(), Y_W9.Text.Trim(), Y_C9.Text.Trim(), Y_B9.Text.Trim(), C_C9.Text.Trim(), G_C9.Text.Trim(), F_C9.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl9.Text = Convert.ToString(z);
            }

            if (com_cailiao10.Text.Trim() != "" && com_xinghao10.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(com_cailiao10.Text.Trim(), com_xinghao10.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(com_cailiao10.Text.Trim(), B_C10.Text.Trim(), B_K10.Text.Trim(), B_G10.Text.Trim(), J_C10.Text.Trim(), Y_W10.Text.Trim(), Y_C10.Text.Trim(), Y_B10.Text.Trim(), C_C10.Text.Trim(), G_C10.Text.Trim(), F_C10.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl10.Text = Convert.ToString(z);
            }
        }

        private double chaxundanzhong(string a,string b)
        {
            string sql = "select 密度单重 from db_cailiaoguige where 材料='"+ a +"' and 规格='"+ b +"'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

            if(ret != "")
            {
                midu = Math.Round(Convert.ToDouble(ret), 3);
            }
            else
            {
                midu = Convert.ToDouble(0);
            }
            return midu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            zhongliang1 = zl1.Text.Trim();
            zhongliang2 = zl2.Text.Trim();
            zhongliang3 = zl3.Text.Trim();
            zhongliang4 = zl4.Text.Trim();
            zhongliang5 = zl5.Text.Trim();
            zhongliang6 = zl6.Text.Trim();
            zhongliang7 = zl7.Text.Trim();
            zhongliang8 = zl8.Text.Trim();
            zhongliang9 = zl9.Text.Trim();
            zhongliang10 = zl10.Text.Trim();

            cailiao1 = comboBox1.Text.Trim() + comboBox5.Text.Trim();
            cailiao2 = comboBox2.Text.Trim() + comboBox6.Text.Trim();
            cailiao3 = comboBox3.Text.Trim() + comboBox7.Text.Trim();
            cailiao4 = comboBox4.Text.Trim() + comboBox8.Text.Trim();
            cailiao5 = com_cailiao5.Text.Trim() + com_xinghao5.Text.Trim();
            cailiao6 = com_cailiao6.Text.Trim() + com_xinghao6.Text.Trim();
            cailiao7 = com_cailiao7.Text.Trim() + com_xinghao7.Text.Trim();
            cailiao8 = com_cailiao8.Text.Trim() + com_xinghao8.Text.Trim();
            cailiao9 = com_cailiao9.Text.Trim() + com_xinghao9.Text.Trim();
            cailiao10 = com_cailiao10.Text.Trim() + com_xinghao10.Text.Trim();
        }

        private void com_xinghao5_Click(object sender, EventArgs e)
        {
            com_xinghao5.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + com_cailiao5.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (com_xinghao5.Items.Cast<object>().All(x => x.ToString() != a))
                        com_xinghao5.Items.Add(a);
                }
            }
        }

        private void com_xinghao6_Click(object sender, EventArgs e)
        {
            com_xinghao6.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + com_cailiao6.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (com_xinghao6.Items.Cast<object>().All(x => x.ToString() != a))
                        com_xinghao6.Items.Add(a);
                }
            }
        }

        private void com_xinghao7_Click(object sender, EventArgs e)
        {
            com_xinghao7.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + com_cailiao7.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (com_xinghao7.Items.Cast<object>().All(x => x.ToString() != a))
                        com_xinghao7.Items.Add(a);
                }
            }
        }

        private void com_xinghao8_Click(object sender, EventArgs e)
        {
            com_xinghao8.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + com_cailiao8.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (com_xinghao8.Items.Cast<object>().All(x => x.ToString() != a))
                        com_xinghao8.Items.Add(a);
                }
            }
        }

        private void com_xinghao9_Click(object sender, EventArgs e)
        {
            com_xinghao9.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + com_cailiao9.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (com_xinghao9.Items.Cast<object>().All(x => x.ToString() != a))
                        com_xinghao9.Items.Add(a);
                }
            }
        }

        private void com_xinghao10_Click(object sender, EventArgs e)
        {
            com_xinghao10.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + com_cailiao10.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (com_xinghao10.Items.Cast<object>().All(x => x.ToString() != a))
                        com_xinghao10.Items.Add(a);
                }
            }
        }

        private void com_cailiao5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cailiao5.Text.Trim() != "")
            {
                B_C5.Text = ""; B_K5.Text = ""; B_G5.Text = ""; J_C5.Text = ""; Y_W5.Text = ""; Y_C5.Text = ""; Y_B5.Text = ""; C_C5.Text = ""; G_C5.Text = ""; F_C5.Text = "";

                switch (com_cailiao5.Text.Trim())
                {
                    case "板":
                        B_C5.Enabled = true; B_K5.Enabled = true; B_G5.Enabled = true; J_C5.Enabled = false; Y_W5.Enabled = false; Y_C5.Enabled = false; Y_B5.Enabled = false; C_C5.Enabled = false; G_C5.Enabled = false; F_C5.Enabled = false;
                        break;
                    case "角钢":
                        B_C5.Enabled = false; B_K5.Enabled = false; B_G5.Enabled = false; J_C5.Enabled = true; Y_W5.Enabled = false; Y_C5.Enabled = false; Y_B5.Enabled = false; C_C5.Enabled = false; G_C5.Enabled = false; F_C5.Enabled = false;
                        break;
                    case "圆钢":
                        B_C5.Enabled = false; B_K5.Enabled = false; B_G5.Enabled = false; J_C5.Enabled = false; Y_W5.Enabled = true; Y_C5.Enabled = true; Y_B5.Enabled = true; C_C5.Enabled = false; G_C5.Enabled = false; F_C5.Enabled = false;
                        break;
                    case "圆管":
                        B_C5.Enabled = false; B_K5.Enabled = false; B_G5.Enabled = false; J_C5.Enabled = false; Y_W5.Enabled = true; Y_C5.Enabled = true; Y_B5.Enabled = true; C_C5.Enabled = false; G_C5.Enabled = false; F_C5.Enabled = false;
                        break;
                    case "槽钢":
                        B_C5.Enabled = false; B_K5.Enabled = false; B_G5.Enabled = false; J_C5.Enabled = false; Y_W5.Enabled = false; Y_C5.Enabled = false; Y_B5.Enabled = false; C_C5.Enabled = true; G_C5.Enabled = false; F_C5.Enabled = false;
                        break;
                    case "工字钢":
                        B_C5.Enabled = false; B_K5.Enabled = false; B_G5.Enabled = false; J_C5.Enabled = false; Y_W5.Enabled = false; Y_C5.Enabled = false; Y_B5.Enabled = false; C_C5.Enabled = false; G_C5.Enabled = true; F_C5.Enabled = false;
                        break;
                    case "方管":
                        B_C5.Enabled = false; B_K5.Enabled = false; B_G5.Enabled = false; J_C5.Enabled = false; Y_W5.Enabled = false; Y_C5.Enabled = false; Y_B5.Enabled = false; C_C5.Enabled = false; G_C5.Enabled = false; F_C5.Enabled = true;
                        break;

                }
            }
        }

        private void com_cailiao6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cailiao6.Text.Trim() != "")
            {
                B_C6.Text = ""; B_K6.Text = ""; B_G6.Text = ""; J_C6.Text = ""; Y_W6.Text = ""; Y_C6.Text = ""; Y_B6.Text = ""; C_C6.Text = ""; G_C6.Text = ""; F_C6.Text = "";

                switch (com_cailiao6.Text.Trim())
                {
                    case "板":
                        B_C6.Enabled = true; B_K6.Enabled = true; B_G6.Enabled = true; J_C6.Enabled = false; Y_W6.Enabled = false; Y_C6.Enabled = false; Y_B6.Enabled = false; C_C6.Enabled = false; G_C6.Enabled = false; F_C6.Enabled = false;
                        break;
                    case "角钢":
                        B_C6.Enabled = false; B_K6.Enabled = false; B_G6.Enabled = false; J_C6.Enabled = true; Y_W6.Enabled = false; Y_C6.Enabled = false; Y_B6.Enabled = false; C_C6.Enabled = false; G_C6.Enabled = false; F_C6.Enabled = false;
                        break;
                    case "圆钢":
                        B_C6.Enabled = false; B_K6.Enabled = false; B_G6.Enabled = false; J_C6.Enabled = false; Y_W6.Enabled = true; Y_C6.Enabled = true; Y_B6.Enabled = true; C_C6.Enabled = false; G_C6.Enabled = false; F_C6.Enabled = false;
                        break;
                    case "圆管":
                        B_C6.Enabled = false; B_K6.Enabled = false; B_G6.Enabled = false; J_C6.Enabled = false; Y_W6.Enabled = true; Y_C6.Enabled = true; Y_B6.Enabled = true; C_C6.Enabled = false; G_C6.Enabled = false; F_C6.Enabled = false;
                        break;
                    case "槽钢":
                        B_C6.Enabled = false; B_K6.Enabled = false; B_G6.Enabled = false; J_C6.Enabled = false; Y_W6.Enabled = false; Y_C6.Enabled = false; Y_B6.Enabled = false; C_C6.Enabled = true; G_C6.Enabled = false; F_C6.Enabled = false;
                        break;
                    case "工字钢":
                        B_C6.Enabled = false; B_K6.Enabled = false; B_G6.Enabled = false; J_C6.Enabled = false; Y_W6.Enabled = false; Y_C6.Enabled = false; Y_B6.Enabled = false; C_C6.Enabled = false; G_C6.Enabled = true; F_C6.Enabled = false;
                        break;
                    case "方管":
                        B_C6.Enabled = false; B_K6.Enabled = false; B_G6.Enabled = false; J_C6.Enabled = false; Y_W6.Enabled = false; Y_C6.Enabled = false; Y_B6.Enabled = false; C_C6.Enabled = false; G_C6.Enabled = false; F_C6.Enabled = true;
                        break;

                }
            }
        }

        private void com_cailiao7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cailiao7.Text.Trim() != "")
            {
                B_C7.Text = ""; B_K7.Text = ""; B_G7.Text = ""; J_C7.Text = ""; Y_W7.Text = ""; Y_C7.Text = ""; Y_B7.Text = ""; C_C7.Text = ""; G_C7.Text = ""; F_C7.Text = "";

                switch (com_cailiao7.Text.Trim())
                {
                    case "板":
                        B_C7.Enabled = true; B_K7.Enabled = true; B_G7.Enabled = true; J_C7.Enabled = false; Y_W7.Enabled = false; Y_C7.Enabled = false; Y_B7.Enabled = false; C_C7.Enabled = false; G_C7.Enabled = false; F_C7.Enabled = false;
                        break;
                    case "角钢":
                        B_C7.Enabled = false; B_K7.Enabled = false; B_G7.Enabled = false; J_C7.Enabled = true; Y_W7.Enabled = false; Y_C7.Enabled = false; Y_B7.Enabled = false; C_C7.Enabled = false; G_C7.Enabled = false; F_C7.Enabled = false;
                        break;
                    case "圆钢":
                        B_C7.Enabled = false; B_K7.Enabled = false; B_G7.Enabled = false; J_C7.Enabled = false; Y_W7.Enabled = true; Y_C7.Enabled = true; Y_B7.Enabled = true; C_C7.Enabled = false; G_C7.Enabled = false; F_C7.Enabled = false;
                        break;
                    case "圆管":
                        B_C7.Enabled = false; B_K7.Enabled = false; B_G7.Enabled = false; J_C7.Enabled = false; Y_W7.Enabled = true; Y_C7.Enabled = true; Y_B7.Enabled = true; C_C7.Enabled = false; G_C7.Enabled = false; F_C7.Enabled = false;
                        break;
                    case "槽钢":
                        B_C7.Enabled = false; B_K7.Enabled = false; B_G7.Enabled = false; J_C7.Enabled = false; Y_W7.Enabled = false; Y_C7.Enabled = false; Y_B7.Enabled = false; C_C7.Enabled = true; G_C7.Enabled = false; F_C7.Enabled = false;
                        break;
                    case "工字钢":
                        B_C7.Enabled = false; B_K7.Enabled = false; B_G7.Enabled = false; J_C7.Enabled = false; Y_W7.Enabled = false; Y_C7.Enabled = false; Y_B7.Enabled = false; C_C7.Enabled = false; G_C7.Enabled = true; F_C7.Enabled = false;
                        break;
                    case "方管":
                        B_C7.Enabled = false; B_K7.Enabled = false; B_G7.Enabled = false; J_C7.Enabled = false; Y_W7.Enabled = false; Y_C7.Enabled = false; Y_B7.Enabled = false; C_C7.Enabled = false; G_C7.Enabled = false; F_C7.Enabled = true;
                        break;

                }
            }
        }

        private void com_cailiao8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cailiao8.Text.Trim() != "")
            {
                B_C8.Text = ""; B_K8.Text = ""; B_G8.Text = ""; J_C8.Text = ""; Y_W8.Text = ""; Y_C8.Text = ""; Y_B8.Text = ""; C_C8.Text = ""; G_C8.Text = ""; F_C8.Text = "";

                switch (com_cailiao8.Text.Trim())
                {
                    case "板":
                        B_C8.Enabled = true; B_K8.Enabled = true; B_G8.Enabled = true; J_C8.Enabled = false; Y_W8.Enabled = false; Y_C8.Enabled = false; Y_B8.Enabled = false; C_C8.Enabled = false; G_C8.Enabled = false; F_C8.Enabled = false;
                        break;
                    case "角钢":
                        B_C8.Enabled = false; B_K8.Enabled = false; B_G8.Enabled = false; J_C8.Enabled = true; Y_W8.Enabled = false; Y_C8.Enabled = false; Y_B8.Enabled = false; C_C8.Enabled = false; G_C8.Enabled = false; F_C8.Enabled = false;
                        break;
                    case "圆钢":
                        B_C8.Enabled = false; B_K8.Enabled = false; B_G8.Enabled = false; J_C8.Enabled = false; Y_W8.Enabled = true; Y_C8.Enabled = true; Y_B8.Enabled = true; C_C8.Enabled = false; G_C8.Enabled = false; F_C8.Enabled = false;
                        break;
                    case "圆管":
                        B_C8.Enabled = false; B_K8.Enabled = false; B_G8.Enabled = false; J_C8.Enabled = false; Y_W8.Enabled = true; Y_C8.Enabled = true; Y_B8.Enabled = true; C_C8.Enabled = false; G_C8.Enabled = false; F_C8.Enabled = false;
                        break;
                    case "槽钢":
                        B_C8.Enabled = false; B_K8.Enabled = false; B_G8.Enabled = false; J_C8.Enabled = false; Y_W8.Enabled = false; Y_C8.Enabled = false; Y_B8.Enabled = false; C_C8.Enabled = true; G_C8.Enabled = false; F_C8.Enabled = false;
                        break;
                    case "工字钢":
                        B_C8.Enabled = false; B_K8.Enabled = false; B_G8.Enabled = false; J_C8.Enabled = false; Y_W8.Enabled = false; Y_C8.Enabled = false; Y_B8.Enabled = false; C_C8.Enabled = false; G_C8.Enabled = true; F_C8.Enabled = false;
                        break;
                    case "方管":
                        B_C8.Enabled = false; B_K8.Enabled = false; B_G8.Enabled = false; J_C8.Enabled = false; Y_W8.Enabled = false; Y_C8.Enabled = false; Y_B8.Enabled = false; C_C8.Enabled = false; G_C8.Enabled = false; F_C8.Enabled = true;
                        break;

                }
            }
        }

        private void com_cailiao9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cailiao9.Text.Trim() != "")
            {
                B_C9.Text = ""; B_K9.Text = ""; B_G9.Text = ""; J_C9.Text = ""; Y_W9.Text = ""; Y_C9.Text = ""; Y_B9.Text = ""; C_C9.Text = ""; G_C9.Text = ""; F_C9.Text = "";

                switch (com_cailiao9.Text.Trim())
                {
                    case "板":
                        B_C9.Enabled = true; B_K9.Enabled = true; B_G9.Enabled = true; J_C9.Enabled = false; Y_W9.Enabled = false; Y_C9.Enabled = false; Y_B9.Enabled = false; C_C9.Enabled = false; G_C9.Enabled = false; F_C9.Enabled = false;
                        break;
                    case "角钢":
                        B_C9.Enabled = false; B_K9.Enabled = false; B_G9.Enabled = false; J_C9.Enabled = true; Y_W9.Enabled = false; Y_C9.Enabled = false; Y_B9.Enabled = false; C_C9.Enabled = false; G_C9.Enabled = false; F_C9.Enabled = false;
                        break;
                    case "圆钢":
                        B_C9.Enabled = false; B_K9.Enabled = false; B_G9.Enabled = false; J_C9.Enabled = false; Y_W9.Enabled = true; Y_C9.Enabled = true; Y_B9.Enabled = true; C_C9.Enabled = false; G_C9.Enabled = false; F_C9.Enabled = false;
                        break;
                    case "圆管":
                        B_C9.Enabled = false; B_K9.Enabled = false; B_G9.Enabled = false; J_C9.Enabled = false; Y_W9.Enabled = true; Y_C9.Enabled = true; Y_B9.Enabled = true; C_C9.Enabled = false; G_C9.Enabled = false; F_C9.Enabled = false;
                        break;
                    case "槽钢":
                        B_C9.Enabled = false; B_K9.Enabled = false; B_G9.Enabled = false; J_C9.Enabled = false; Y_W9.Enabled = false; Y_C9.Enabled = false; Y_B9.Enabled = false; C_C9.Enabled = true; G_C9.Enabled = false; F_C9.Enabled = false;
                        break;
                    case "工字钢":
                        B_C9.Enabled = false; B_K9.Enabled = false; B_G9.Enabled = false; J_C9.Enabled = false; Y_W9.Enabled = false; Y_C9.Enabled = false; Y_B9.Enabled = false; C_C9.Enabled = false; G_C9.Enabled = true; F_C9.Enabled = false;
                        break;
                    case "方管":
                        B_C9.Enabled = false; B_K9.Enabled = false; B_G9.Enabled = false; J_C9.Enabled = false; Y_W9.Enabled = false; Y_C9.Enabled = false; Y_B9.Enabled = false; C_C9.Enabled = false; G_C9.Enabled = false; F_C9.Enabled = true;
                        break;

                }
            }
        }

        private void com_cailiao10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cailiao10.Text.Trim() != "")
            {
                B_C10.Text = ""; B_K10.Text = ""; B_G10.Text = ""; J_C10.Text = ""; Y_W10.Text = ""; Y_C10.Text = ""; Y_B10.Text = ""; C_C10.Text = ""; G_C10.Text = ""; F_C10.Text = "";

                switch (com_cailiao10.Text.Trim())
                {
                    case "板":
                        B_C10.Enabled = true; B_K10.Enabled = true; B_G10.Enabled = true; J_C10.Enabled = false; Y_W10.Enabled = false; Y_C10.Enabled = false; Y_B10.Enabled = false; C_C10.Enabled = false; G_C10.Enabled = false; F_C10.Enabled = false;
                        break;
                    case "角钢":
                        B_C10.Enabled = false; B_K10.Enabled = false; B_G10.Enabled = false; J_C10.Enabled = true; Y_W10.Enabled = false; Y_C10.Enabled = false; Y_B10.Enabled = false; C_C10.Enabled = false; G_C10.Enabled = false; F_C10.Enabled = false;
                        break;
                    case "圆钢":
                        B_C10.Enabled = false; B_K10.Enabled = false; B_G10.Enabled = false; J_C10.Enabled = false; Y_W10.Enabled = true; Y_C10.Enabled = true; Y_B10.Enabled = true; C_C10.Enabled = false; G_C10.Enabled = false; F_C10.Enabled = false;
                        break;
                    case "圆管":
                        B_C10.Enabled = false; B_K10.Enabled = false; B_G10.Enabled = false; J_C10.Enabled = false; Y_W10.Enabled = true; Y_C10.Enabled = true; Y_B10.Enabled = true; C_C10.Enabled = false; G_C10.Enabled = false; F_C10.Enabled = false;
                        break;
                    case "槽钢":
                        B_C10.Enabled = false; B_K10.Enabled = false; B_G10.Enabled = false; J_C10.Enabled = false; Y_W10.Enabled = false; Y_C10.Enabled = false; Y_B10.Enabled = false; C_C10.Enabled = true; G_C10.Enabled = false; F_C10.Enabled = false;
                        break;
                    case "工字钢":
                        B_C10.Enabled = false; B_K10.Enabled = false; B_G10.Enabled = false; J_C10.Enabled = false; Y_W10.Enabled = false; Y_C10.Enabled = false; Y_B10.Enabled = false; C_C10.Enabled = false; G_C10.Enabled = true; F_C10.Enabled = false;
                        break;
                    case "方管":
                        B_C10.Enabled = false; B_K10.Enabled = false; B_G10.Enabled = false; J_C10.Enabled = false; Y_W10.Enabled = false; Y_C10.Enabled = false; Y_B10.Enabled = false; C_C10.Enabled = false; G_C10.Enabled = false; F_C10.Enabled = true;
                        break;

                }
            }
        }

        private double jisuanzhongliang(string cailiao, string k1,string k2,string k3,string k4,string k5,string k6,string k7,string k8, string k9, string k10)
        {
            double a1, b1, c1, a2, a3, b3, c3, a4, a5, a6;
            if(k1 != "" && k2 != "" && k3 != "")
            {
                a1 = Convert.ToDouble(k1);
                b1 = Convert.ToDouble(k2);
                c1 = Convert.ToDouble(k3);
                w = (a1 * b1 * c1)/1000000000;
            }

            if(k4 != "")
            {
                a2 = Convert.ToDouble(k4);
                w = a2 / 1000000;
            }

            if(k5 !="" && k6 != "" && k7 != "")
            {
                a3 = Convert.ToDouble(k5);//外径
                b3 = Convert.ToDouble(k6);//长
                c3 = Convert.ToDouble(k7);//壁厚
                switch (cailiao)
                {
                    case "圆管":
                        w = (((Math.Pow((a3 / 2), 2) * 3.14) - (Math.Pow((a3 - 2 * c3) / 2, 2) * 3.14)) * b3) / 1000000000;
                        break;
                    case "圆钢":
                        w = ((Math.Pow((a3 / 2), 2) * 3.14) * b3) / 1000000000;
                        break;
                }

            }

            if(k8 != "")
            {
                a4 = Convert.ToDouble(k8);
                w = a4 / 1000000;
            }

            if(k9 != "")
            {
                a5 = Convert.ToDouble(k9);
                w = a5 / 1000000;
            }

            if(k10 != "")
            {
                a6 = Convert.ToDouble(k10);
                w = a6 / 1000000;
            }

            return w;
        }
    }
}
