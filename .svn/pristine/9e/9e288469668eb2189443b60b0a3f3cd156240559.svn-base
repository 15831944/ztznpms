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
    public partial class FormJisuanJiage : Form
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

        public string gongxu1;
        public string gongxu2;
        public string gongxu3;
        public string gongxu4;
        public string gongxu5;
        public string gongxu6;
        public string gongxu7;
        public string gongxu8;
        public string gongxu9;
        public string gongxu10;
        public string gongxu11;
        public string gongxu12;
        public string gongxu13;
        public string gongxu14;
        public string gongxu15;
        public string gongxu16;
        public string gongxu17;
        public string gongxu18;
        public string gongxu19;
        public string gongxu20;
        public string gongxu21;
        public string gongxu22;
        public string gongxu23;
        public string gongxu24;
        public string gongxu25;

        private double w;
        private double jg;
        double a1, b1, c1, r2, c2;
        public FormJisuanJiage()
        {
            InitializeComponent();
        }

        private void FormJisuanJiage_Load(object sender, EventArgs e)
        {
            string ss1 = "select * from db_cailiao";
            DataTable row1 = SQLhelp.GetDataTable(ss1, CommandType.Text);
            foreach (DataRow dr1 in row1.Rows)
            {
                this.com_cailiaocaizhi.Items.Add(dr1["材料"].ToString());
            }

            this.com_caizhi.Items.Add("0.5");
            this.com_caizhi.Items.Add("0.6");
            this.com_caizhi.Items.Add("0.7");
            this.com_caizhi.Items.Add("0.8");
            this.com_caizhi.Items.Add("0.9");
            this.com_caizhi.Items.Add("1.0");
            this.com_caizhi.Items.Add("1.1");
            this.com_caizhi.Items.Add("1.2");

            string sql = "select * from db_dangwei";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                this.dangwei1.Items.Add(row["档位"].ToString());
                this.dangwei2.Items.Add(row["档位"].ToString());
                this.dangwei3.Items.Add(row["档位"].ToString());
                this.dangwei4.Items.Add(row["档位"].ToString());
                this.dangwei5.Items.Add(row["档位"].ToString());
                this.dangwei6.Items.Add(row["档位"].ToString());
                this.dangwei7.Items.Add(row["档位"].ToString());
                this.dangwei8.Items.Add(row["档位"].ToString());
                this.dangwei9.Items.Add(row["档位"].ToString());
                this.dangwei10.Items.Add(row["档位"].ToString());
                this.dangwei11.Items.Add(row["档位"].ToString());
                this.dangwei12.Items.Add(row["档位"].ToString());
                this.dangwei13.Items.Add(row["档位"].ToString());
                this.dangwei14.Items.Add(row["档位"].ToString());
                this.dangwei15.Items.Add(row["档位"].ToString());
                this.dangwei16.Items.Add(row["档位"].ToString());
                this.dangwei17.Items.Add(row["档位"].ToString());
                this.dangwei18.Items.Add(row["档位"].ToString());
                this.dangwei19.Items.Add(row["档位"].ToString());
                this.dangwei20.Items.Add(row["档位"].ToString());
                this.dangwei21.Items.Add(row["档位"].ToString());
                this.dangwei22.Items.Add(row["档位"].ToString());
                this.dangwei23.Items.Add(row["档位"].ToString());
                this.dangwei24.Items.Add(row["档位"].ToString());
                this.dangwei25.Items.Add(row["档位"].ToString());

            } 

            textBox1.Text = gongxu1;
            textBox2.Text = gongxu2;
            textBox3.Text = gongxu3;
            textBox4.Text = gongxu4;
            textBox5.Text = gongxu5;
            textBox6.Text = gongxu6;
            textBox7.Text = gongxu7;
            textBox8.Text = gongxu8;
            textBox9.Text = gongxu9;
            textBox10.Text = gongxu10;
            textBox11.Text = gongxu11;
            textBox12.Text = gongxu12;
            textBox13.Text = gongxu13;
            textBox14.Text = gongxu14;
            textBox15.Text = gongxu15;
            textBox16.Text = gongxu16;
            textBox17.Text = gongxu17;
            textBox18.Text = gongxu18;
            textBox19.Text = gongxu19;
            textBox20.Text = gongxu20;
            textBox21.Text = gongxu21;
            textBox22.Text = gongxu22;
            textBox23.Text = gongxu23;
            textBox24.Text = gongxu24;
            textBox25.Text = gongxu25;

        }

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <param name="w">传入重量</param>
        /// <param name="p">科学单价</param>
        /// <param name="s">下拉菜单的工序名称</param>
        /// <returns></returns>
        private double jisuan(double w, double p, string s,string k1,string k2,string k3,string k4,string k5)
        {

            if(k1 != "" && k2 != "" && k3 != "")
            {
                //立方体长、宽、高
                a1 = Convert.ToDouble(k1);
                b1 = Convert.ToDouble(k2);
                c1 = Convert.ToDouble(k3);
            }

            if(k4 != "" && k5 != "")
            {
                //圆柱体直径、高
                r2 = Convert.ToDouble(k4);
                c2 = Convert.ToDouble(k5);
            }

            double jg = 0.00;
            switch (s)
            {
                case "锯":
                    jg = w * p;
                    break;
                case "剪板折弯":
                    jg = w * p;
                    break;
                case "水切割":
                    if (k1 != "" && k2 != "" && k3 != "")
                    {
                        jg = w * (p + (Math.Pow(c1, 2)) / 100);
                    }
                    if (k4 != "" && k5 != "")
                    {
                        jg = w * (p + (Math.Pow(c2, 2)) / 100);
                    }
                    //if (com_xingzhuang.Text.Trim() == "方管")
                    //{
                    //    jg = w * (p + (Math.Pow(c3, 2)) / 100);
                    //}
                    //if (com_xingzhuang.Text.Trim() == "圆管")
                    //{
                    //    jg = w * (p + (Math.Pow(c4, 2)) / 100);
                    //}
                    break;
                case "火焰切割":
                    jg = w * p;
                    break;
                //case "车铣复合":
                //    jg = (Math.Pow(w, 0.28) + 0.3) * p;
                //    break;
                case "加工中心":
                    jg = (Math.Pow(w, 0.28) + 0.3) * p;
                    break;
                case "普通铣床":
                    jg = (Math.Pow(w, 0.15)) * p;
                    break;
                case "钳":
                    jg = w * p + 4;
                    break;
                case "平磨":
                    jg = (Math.Pow(w, 0.15)) * p;
                    break;
                case "外圆磨":
                    jg = (Math.Pow(w, 0.28) + 0.3) * p;
                    break;
                case "二保焊":
                    jg = (1 / (Math.Pow(2, w)) + 0.5) * p;
                    break;

            }

            return jg;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            gx1 = txt_gx1.Text.Trim();
            gx2 = txt_gx2.Text.Trim();
            gx3 = txt_gx3.Text.Trim();
            gx4 = txt_gx4.Text.Trim();
            gx5 = txt_gx5.Text.Trim();
            gx6 = txt_gx6.Text.Trim();
            gx7 = txt_gx7.Text.Trim();
            gx8 = txt_gx8.Text.Trim();
            gx9 = txt_gx9.Text.Trim();
            gx10 = txt_gx10.Text.Trim();
            gx11 = txt_gx11.Text.Trim();
            gx12 = txt_gx12.Text.Trim();
            gx13 = txt_gx13.Text.Trim();
            gx14 = txt_gx14.Text.Trim();
            gx15 = txt_gx15.Text.Trim();
            gx16 = txt_gx16.Text.Trim();
            gx17 = txt_gx17.Text.Trim();
            gx18 = txt_gx18.Text.Trim();
            gx19 = txt_gx19.Text.Trim();
            gx20 = txt_gx20.Text.Trim();
            gx21 = txt_gx21.Text.Trim();
            gx22 = txt_gx22.Text.Trim();
            gx23 = txt_gx23.Text.Trim();
            gx24 = txt_gx24.Text.Trim();
            gx25 = txt_gx25.Text.Trim();
        }


        private string gongshi(string str, string str1, string k1, string k2, string k3, string k4, string k5)
        {

            if (k1 != "" && k2 != "" && k3 != "")
            {
                //立方体长、宽、高
                a1 = Convert.ToDouble(k1);
                b1 = Convert.ToDouble(k2);
                c1 = Convert.ToDouble(k3);
            }

            if (k4 != "" && k5 != "")
            {
                //圆柱体直径、高
                r2 = Convert.ToDouble(k4);
                c2 = Convert.ToDouble(k5);
            }

            double jg1, jg2, jg3, jg4;
            switch (str)
            {

                case "普车":
                    jg3 = Convert.ToDouble(str1);//档位
                    jg4 = (3.14 * r2 * r2 * c2 / 4 / 1000000000) * 2700;//重量
                    jg1 = 0.3 * jg4;
                    jg2 = ((3.14 * r2 * r2 / 2 + 3.14 * r2 * c2) / 100) * 0.013;
                    jg = 1.5 * jg3 + jg1 + jg2;
                    jg = Math.Round(jg, 1);
                    break;
                //case "车（异型零件）":
                //    //r2、c2  
                //    jg3 = Convert.ToDouble(str1);//档位
                //    jg4 = (3.14 * r2 * r2 * c2 / 4 / 1000000000) * 2700;//重量
                //    jg1 = 0.3 * jg4;
                //    jg2 = ((3.14 * r2 * r2 / 2 + 3.14 * r2 * c2) / 100) * 0.013;
                //    jg = jg3 + jg1 + jg2;
                //    jg = Math.Round(jg, 1);
                //    break;

                //case "车（盘类零件）":
                //    ////r2、c2
                //    //jg3 = Convert.ToDouble(str1);
                //    //jg4 = Convert.ToDouble(com_caizhi.Text);
                //    //jg1 = (r2 * c2 * 3.14 + 3.14 * (Math.Pow(r2, 2)) / 2) / 150 * 0.02;
                //    //jg2 = (Math.Pow(2, (0.5 + 10 * (jg3 - 2) / (c2 + 2 * r2)))) * ((jg3 - 2) * 2);
                //    //jg = (jg1 + jg2) * jg4;
                //    //jg = Math.Round(jg, 1);
                //    jg3 = Convert.ToDouble(str1);//档位
                //    jg4 = (3.14 * r2 * r2 * c2 / 4 / 1000000000) * 2700;//重量
                //    jg1 = 0.3 * jg4;
                //    jg2 = ((3.14 * r2 * r2 / 2 + 3.14 * r2 * c2) / 100) * 0.013;
                //    jg = jg3 + jg1 + jg2;
                //    jg = Math.Round(jg, 1);
                //    break;
                case "数车":
                    jg3 = Convert.ToDouble(str1);//档位
                    jg4 = (3.14 * r2 * r2 * c2 / 4 / 1000000000) * 2700;//重量
                    jg1 = 0.3 * jg4;
                    jg2 = ((3.14 * r2 * r2 / 2 + 3.14 * r2 * c2) / 100) * 0.013;
                    jg = 0.6 * jg3 + jg1 + jg2;
                    jg = Math.Round(jg, 1);
                    break;
                //case "数车（异型零件）":
                //    //r2、c2  
                //    jg3 = Convert.ToDouble(str1);//档位
                //    jg4 = (3.14 * r2 * r2 * c2 / 4 / 1000000000) * 2700;//重量
                //    jg1 = 0.3 * jg4;
                //    jg2 = ((3.14 * r2 * r2 / 2 + 3.14 * r2 * c2) / 100) * 0.013;
                //    jg = jg3 + jg1 + jg2;
                //    jg = Math.Round(jg, 1);
                //    break;

                //case "数车（盘类零件）":
                //    ////r2、c2
                //    //jg3 = Convert.ToDouble(str1);
                //    //jg4 = Convert.ToDouble(com_caizhi.Text);
                //    //jg1 = (r2 * c2 * 3.14 + 3.14 * (Math.Pow(r2, 2)) / 2) / 150 * 0.02;
                //    //jg2 = (Math.Pow(2, (0.5 + 10 * (jg3 - 2) / (c2 + 2 * r2)))) * ((jg3 - 2) * 2);
                //    //jg = (jg1 + jg2) * jg4;
                //    //jg = Math.Round(jg, 1);
                //    jg3 = Convert.ToDouble(str1);//档位
                //    jg4 = (3.14 * r2 * r2 * c2 / 4 / 1000000000) * 2700;//重量
                //    jg1 = 0.3 * jg4;
                //    jg2 = ((3.14 * r2 * r2 / 2 + 3.14 * r2 * c2) / 100) * 0.013;
                //    jg = jg3 + jg1 + jg2;
                //    jg = Math.Round(jg, 1);
                //    break;
                case "焊接（常规）":
                    jg1 = Convert.ToDouble(txt_hanjiezhongliang.Text);
                    jg2 = Convert.ToDouble(str1);
                    jg = jg1 * 0.3 + (jg2 - 1) * 4;
                    jg = Math.Round(jg, 1);
                    break;
                case "焊接（不锈钢）":
                    jg1 = Convert.ToDouble(txt_hanjiezhongliang.Text);
                    jg2 = Convert.ToDouble(str1);
                    jg = jg1 * 0.3 + (jg2 - 1) * 4;
                    jg = Math.Round(jg, 1);
                    break;
                case "氩弧焊":
                    //a1、b1、c1
                    jg3 = Convert.ToDouble(str1);
                    jg = (a1 + b1 + c1) * 2 / 10 * 0.1 + (jg3 - 1) * 15;
                    jg = Math.Round(jg, 1);
                    break;
                case "炮塔铣（键槽类）":
                    break;
            }
            string jgStr = Convert.ToString(jg);
            return jgStr;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            txt_gx1.Text = "";
            txt_gx2.Text = "";
            txt_gx3.Text = "";
            txt_gx4.Text = "";
            txt_gx5.Text = "";
            txt_gx6.Text = "";
            txt_gx7.Text = "";
            txt_gx8.Text = "";
            txt_gx9.Text = "";
            txt_gx10.Text = "";
            txt_gx11.Text = "";
            txt_gx12.Text = "";
            txt_gx13.Text = "";
            txt_gx14.Text = "";
            txt_gx15.Text = "";
            txt_gx16.Text = "";
            txt_gx17.Text = "";
            txt_gx18.Text = "";
            txt_gx19.Text = "";
            txt_gx20.Text = "";
            txt_gx21.Text = "";
            txt_gx22.Text = "";
            txt_gx23.Text = "";
            txt_gx24.Text = "";
            txt_gx25.Text = "";


            //计算价格
            //将价格写入对应的工序控件
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    string rs1 = jiage(textBox1.Text.Trim());//科学单价
                    //查询到的工序有科学单价
                    if (rs1 != "")
                    {
                        double p1 = Convert.ToDouble(rs1);//将查询到的科学单价转成double类型
                        w = CalWeight(l_C1.Text.Trim(), l_K1.Text.Trim(), l_G1.Text.Trim(), y_Z1.Text.Trim(), y_G1.Text.Trim(), y_ZB1.Text.Trim(), y_ZZ1.Text.Trim(), y_ZG1.Text.Trim(), f_C1.Text.Trim(), f_K1.Text.Trim(), f_G1.Text.Trim(), f_B1.Text.Trim());
                        p1 = Math.Round(jisuan(w, p1, textBox1.Text.Trim(),l_C1.Text.Trim(),l_K1.Text.Trim(),l_G1.Text.Trim(),y_Z1.Text.Trim(),y_G1.Text.Trim()), 1);//公式计算价格
                        txt_gx1.Text = Convert.ToString(p1);
                    }
                    else//没有科学单价
                    {
                        if (dangwei1.Text != "")
                        {
                            txt_gx1.Text = gongshi(textBox1.Text, dangwei1.Text, l_C1.Text.Trim(), l_K1.Text.Trim(), l_G1.Text.Trim(), y_Z1.Text.Trim(), y_G1.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位1！", "提示");
                            return;
                        }

                    }

                }

                if (textBox2.Text.Trim() != "")
                {
                    string rs2 = jiage(textBox2.Text.Trim());
                    if (rs2 != "")
                    {
                        double p2 = Convert.ToDouble(rs2);
                        w = CalWeight(l_C2.Text.Trim(), l_K2.Text.Trim(), l_G2.Text.Trim(), y_Z2.Text.Trim(), y_G2.Text.Trim(), y_ZB2.Text.Trim(), y_ZZ2.Text.Trim(), y_ZG2.Text.Trim(), f_C2.Text.Trim(), f_K2.Text.Trim(), f_G2.Text.Trim(), f_B2.Text.Trim());
                        p2 = Math.Round(jisuan(w, p2, textBox2.Text.Trim(), l_C2.Text.Trim(), l_K2.Text.Trim(), l_G2.Text.Trim(), y_Z2.Text.Trim(), y_G2.Text.Trim()), 1);//公式计算价格
                        txt_gx2.Text = Convert.ToString(p2);
                    }
                    else//没有科学单价
                    {
                        if (dangwei2.Text != "")
                        {
                            txt_gx2.Text = gongshi(textBox2.Text, dangwei2.Text, l_C2.Text.Trim(), l_K2.Text.Trim(), l_G2.Text.Trim(), y_Z2.Text.Trim(), y_G2.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位2！", "提示");
                            return;
                        }
                    }
                }

                if (textBox3.Text.Trim() != "")
                {
                    string rs3 = jiage(textBox3.Text.Trim());
                    if (rs3 != "")
                    {
                        double p3 = Convert.ToDouble(rs3);
                        w = CalWeight(l_C3.Text.Trim(), l_K3.Text.Trim(), l_G3.Text.Trim(), y_Z3.Text.Trim(), y_G3.Text.Trim(), y_ZB3.Text.Trim(), y_ZZ3.Text.Trim(), y_ZG3.Text.Trim(), f_C3.Text.Trim(), f_K3.Text.Trim(), f_G3.Text.Trim(), f_B3.Text.Trim());
                        p3 = Math.Round(jisuan(w, p3, textBox3.Text.Trim(), l_C3.Text.Trim(), l_K3.Text.Trim(), l_G3.Text.Trim(), y_Z3.Text.Trim(), y_G3.Text.Trim()), 1);
                        txt_gx3.Text = Convert.ToString(p3);
                    }
                    else//没有科学单价
                    {
                        if (dangwei3.Text != "")
                        {
                            txt_gx3.Text = gongshi(textBox3.Text, dangwei3.Text, l_C3.Text.Trim(), l_K3.Text.Trim(), l_G3.Text.Trim(), y_Z3.Text.Trim(), y_G3.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位3！", "提示");
                            return;
                        }
                    }
                }

                if (textBox4.Text.Trim() != "")
                {
                    string rs4 = jiage(textBox4.Text.Trim());
                    if (rs4 != "")
                    {
                        double p4 = Convert.ToDouble(rs4);
                        w = CalWeight(l_C4.Text.Trim(), l_K4.Text.Trim(), l_G4.Text.Trim(), y_Z4.Text.Trim(), y_G4.Text.Trim(), y_ZB4.Text.Trim(), y_ZZ4.Text.Trim(), y_ZG4.Text.Trim(), f_C4.Text.Trim(), f_K4.Text.Trim(), f_G4.Text.Trim(), f_B4.Text.Trim());
                        p4 = Math.Round(jisuan(w, p4, textBox4.Text.Trim(), l_C4.Text.Trim(), l_K4.Text.Trim(), l_G4.Text.Trim(), y_Z4.Text.Trim(), y_G4.Text.Trim()), 1);
                        txt_gx4.Text = Convert.ToString(p4);
                    }
                    else//没有科学单价
                    {
                        if (dangwei4.Text != "")
                        {
                            txt_gx4.Text = gongshi(textBox4.Text, dangwei4.Text, l_C4.Text.Trim(), l_K4.Text.Trim(), l_G4.Text.Trim(), y_Z4.Text.Trim(), y_G4.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位4！", "提示");
                            return;
                        }
                    }
                }

                if (textBox5.Text.Trim() != "")
                {
                    string rs5 = jiage(textBox5.Text.Trim());
                    if (rs5 != "")
                    {
                        double p5 = Convert.ToDouble(rs5);
                        w = CalWeight(l_C5.Text.Trim(), l_K5.Text.Trim(), l_G5.Text.Trim(), y_Z5.Text.Trim(), y_G5.Text.Trim(), y_ZB5.Text.Trim(), y_ZZ5.Text.Trim(), y_ZG5.Text.Trim(), f_C5.Text.Trim(), f_K5.Text.Trim(), f_G5.Text.Trim(), f_B5.Text.Trim());
                        p5 = Math.Round(jisuan(w, p5, textBox5.Text.Trim(), l_C5.Text.Trim(), l_K5.Text.Trim(), l_G5.Text.Trim(), y_Z5.Text.Trim(), y_G5.Text.Trim()), 1);
                        txt_gx5.Text = Convert.ToString(p5);
                    }
                    else//没有科学单价
                    {
                        if (dangwei5.Text != "")
                        {
                            txt_gx5.Text = gongshi(textBox5.Text, dangwei5.Text, l_C5.Text.Trim(), l_K5.Text.Trim(), l_G5.Text.Trim(), y_Z5.Text.Trim(), y_G5.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位5！", "提示");
                            return;
                        }
                    }
                }

                if (textBox6.Text.Trim() != "")
                {
                    string rs6 = jiage(textBox6.Text.Trim());
                    if (rs6 != "")
                    {
                        double p6 = Convert.ToDouble(rs6);
                        w = CalWeight(l_C6.Text.Trim(), l_K6.Text.Trim(), l_G6.Text.Trim(), y_Z6.Text.Trim(), y_G6.Text.Trim(), y_ZB6.Text.Trim(), y_ZZ6.Text.Trim(), y_ZG6.Text.Trim(), f_C6.Text.Trim(), f_K6.Text.Trim(), f_G6.Text.Trim(), f_B6.Text.Trim());
                        p6 = Math.Round(jisuan(w, p6, textBox6.Text.Trim(), l_C6.Text.Trim(), l_K6.Text.Trim(), l_G6.Text.Trim(), y_Z6.Text.Trim(), y_G6.Text.Trim()), 1);
                        txt_gx6.Text = Convert.ToString(p6);
                    }
                    else//没有科学单价
                    {
                        if (dangwei6.Text != "")
                        {
                            txt_gx6.Text = gongshi(textBox6.Text, dangwei6.Text, l_C6.Text.Trim(), l_K6.Text.Trim(), l_G6.Text.Trim(), y_Z6.Text.Trim(), y_G6.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位6！", "提示");
                            return;
                        }
                    }
                }

                if (textBox7.Text.Trim() != "")
                {
                    string rs7 = jiage(textBox7.Text.Trim());
                    if (rs7 != "")
                    {
                        double p7 = Convert.ToDouble(rs7);
                        w = CalWeight(l_C7.Text.Trim(), l_K7.Text.Trim(), l_G7.Text.Trim(), y_Z7.Text.Trim(), y_G7.Text.Trim(), y_ZB7.Text.Trim(), y_ZZ7.Text.Trim(), y_ZG7.Text.Trim(), f_C7.Text.Trim(), f_K7.Text.Trim(), f_G7.Text.Trim(), f_B7.Text.Trim());
                        p7 = Math.Round(jisuan(w, p7, textBox7.Text.Trim(), l_C7.Text.Trim(), l_K7.Text.Trim(), l_G7.Text.Trim(), y_Z7.Text.Trim(), y_G7.Text.Trim()), 1);
                        txt_gx7.Text = Convert.ToString(p7);
                    }
                    else//没有科学单价
                    {
                        if (dangwei7.Text != "")
                        {
                            txt_gx7.Text = gongshi(textBox7.Text, dangwei7.Text, l_C7.Text.Trim(), l_K7.Text.Trim(), l_G7.Text.Trim(), y_Z7.Text.Trim(), y_G7.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位7！", "提示");
                            return;
                        }
                    }
                }

                if (textBox8.Text.Trim() != "")
                {
                    string rs8 = jiage(textBox8.Text.Trim());
                    if (rs8 != "")
                    {
                        double p8 = Convert.ToDouble(rs8);
                        w = CalWeight(l_C8.Text.Trim(), l_K8.Text.Trim(), l_G8.Text.Trim(), y_Z8.Text.Trim(), y_G8.Text.Trim(), y_ZB8.Text.Trim(), y_ZZ8.Text.Trim(), y_ZG8.Text.Trim(), f_C8.Text.Trim(), f_K8.Text.Trim(), f_G8.Text.Trim(), f_B8.Text.Trim());
                        p8 = Math.Round(jisuan(w, p8, textBox8.Text.Trim(), l_C8.Text.Trim(), l_K8.Text.Trim(), l_G8.Text.Trim(), y_Z8.Text.Trim(), y_G8.Text.Trim()), 1);
                        txt_gx8.Text = Convert.ToString(p8);
                    }
                    else//没有科学单价
                    {
                        if (dangwei8.Text != "")
                        {
                            txt_gx8.Text = gongshi(textBox8.Text, dangwei8.Text, l_C8.Text.Trim(), l_K8.Text.Trim(), l_G8.Text.Trim(), y_Z8.Text.Trim(), y_G8.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位8！", "提示");
                            return;
                        }
                    }
                }

                if (textBox9.Text.Trim() != "")
                {
                    string rs9 = jiage(textBox9.Text.Trim());
                    if (rs9 != "")
                    {
                        double p9 = Convert.ToDouble(rs9);
                        w = CalWeight(l_C9.Text.Trim(), l_K9.Text.Trim(), l_G9.Text.Trim(), y_Z9.Text.Trim(), y_G9.Text.Trim(), y_ZB9.Text.Trim(), y_ZZ9.Text.Trim(), y_ZG9.Text.Trim(), f_C9.Text.Trim(), f_K9.Text.Trim(), f_G9.Text.Trim(), f_B9.Text.Trim());
                        p9 = Math.Round(jisuan(w, p9, textBox9.Text.Trim(), l_C9.Text.Trim(), l_K9.Text.Trim(), l_G9.Text.Trim(), y_Z9.Text.Trim(), y_G9.Text.Trim()), 1);
                        txt_gx9.Text = Convert.ToString(p9);
                    }
                    else//没有科学单价
                    {
                        if (dangwei9.Text != "")
                        {
                            txt_gx9.Text = gongshi(textBox9.Text, dangwei9.Text, l_C9.Text.Trim(), l_K9.Text.Trim(), l_G9.Text.Trim(), y_Z9.Text.Trim(), y_G9.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位9！", "提示");
                            return;
                        }
                    }
                }

                if (textBox10.Text.Trim() != "")
                {
                    string rs10 = jiage(textBox10.Text.Trim());
                    if (rs10 != "")
                    {
                        double p10 = Convert.ToDouble(rs10);
                        w = CalWeight(l_C10.Text.Trim(), l_K10.Text.Trim(), l_G10.Text.Trim(), y_Z10.Text.Trim(), y_G10.Text.Trim(), y_ZB10.Text.Trim(), y_ZZ10.Text.Trim(), y_ZG10.Text.Trim(), f_C10.Text.Trim(), f_K10.Text.Trim(), f_G10.Text.Trim(), f_B10.Text.Trim());
                        p10 = Math.Round(jisuan(w, p10, textBox10.Text.Trim(), l_C10.Text.Trim(), l_K10.Text.Trim(), l_G10.Text.Trim(), y_Z10.Text.Trim(), y_G10.Text.Trim()), 1);
                        txt_gx10.Text = Convert.ToString(p10);
                    }
                    else//没有科学单价
                    {
                        if (dangwei10.Text != "")
                        {
                            txt_gx10.Text = gongshi(textBox10.Text, dangwei10.Text, l_C10.Text.Trim(), l_K10.Text.Trim(), l_G10.Text.Trim(), y_Z10.Text.Trim(), y_G10.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位10！", "提示");
                            return;
                        }
                    }
                }

                if (textBox11.Text.Trim() != "")
                {
                    string rs11 = jiage(textBox11.Text.Trim());
                    if (rs11 != "")
                    {
                        double p11 = Convert.ToDouble(rs11);
                        w = CalWeight(l_C11.Text.Trim(), l_K11.Text.Trim(), l_G11.Text.Trim(), y_Z11.Text.Trim(), y_G11.Text.Trim(), y_ZB11.Text.Trim(), y_ZZ11.Text.Trim(), y_ZG11.Text.Trim(), f_C11.Text.Trim(), f_K11.Text.Trim(), f_G11.Text.Trim(), f_B11.Text.Trim());
                        p11 = Math.Round(jisuan(w, p11, textBox11.Text.Trim(), l_C11.Text.Trim(), l_K11.Text.Trim(), l_G11.Text.Trim(), y_Z11.Text.Trim(), y_G11.Text.Trim()), 1);
                        txt_gx11.Text = Convert.ToString(p11);
                    }
                    else//没有科学单价
                    {
                        if (dangwei11.Text != "")
                        {
                            txt_gx11.Text = gongshi(textBox11.Text, dangwei11.Text, l_C11.Text.Trim(), l_K11.Text.Trim(), l_G11.Text.Trim(), y_Z11.Text.Trim(), y_G11.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位11！", "提示");
                            return;
                        }
                    }
                }

                if (textBox12.Text.Trim() != "")
                {
                    string rs12 = jiage(textBox12.Text.Trim());
                    if (rs12 != "")
                    {
                        double p12 = Convert.ToDouble(rs12);
                        w = CalWeight(l_C12.Text.Trim(), l_K12.Text.Trim(), l_G12.Text.Trim(), y_Z12.Text.Trim(), y_G12.Text.Trim(), y_ZB12.Text.Trim(), y_ZZ12.Text.Trim(), y_ZG12.Text.Trim(), f_C12.Text.Trim(), f_K12.Text.Trim(), f_G12.Text.Trim(), f_B12.Text.Trim());
                        p12 = Math.Round(jisuan(w, p12, textBox12.Text.Trim(), l_C12.Text.Trim(), l_K12.Text.Trim(), l_G12.Text.Trim(), y_Z12.Text.Trim(), y_G12.Text.Trim()), 1);
                        txt_gx12.Text = Convert.ToString(p12);
                    }
                    else//没有科学单价
                    {
                        if (dangwei12.Text != "")
                        {
                            txt_gx12.Text = gongshi(textBox12.Text, dangwei12.Text, l_C12.Text.Trim(), l_K12.Text.Trim(), l_G12.Text.Trim(), y_Z12.Text.Trim(), y_G12.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位12！", "提示");
                            return;
                        }
                    }
                }

                if (textBox13.Text.Trim() != "")
                {
                    string rs13 = jiage(textBox13.Text.Trim());
                    if (rs13 != "")
                    {
                        double p13 = Convert.ToDouble(rs13);
                        w = CalWeight(l_C13.Text.Trim(), l_K13.Text.Trim(), l_G13.Text.Trim(), y_Z13.Text.Trim(), y_G13.Text.Trim(), y_ZB13.Text.Trim(), y_ZZ13.Text.Trim(), y_ZG13.Text.Trim(), f_C13.Text.Trim(), f_K13.Text.Trim(), f_G13.Text.Trim(), f_B13.Text.Trim());
                        p13 = Math.Round(jisuan(w, p13, textBox13.Text.Trim(), l_C13.Text.Trim(), l_K13.Text.Trim(), l_G13.Text.Trim(), y_Z13.Text.Trim(), y_G13.Text.Trim()), 1);
                        txt_gx13.Text = Convert.ToString(p13);
                    }
                    else//没有科学单价
                    {
                        if (dangwei13.Text != "")
                        {
                            txt_gx13.Text = gongshi(textBox13.Text, dangwei13.Text, l_C13.Text.Trim(), l_K13.Text.Trim(), l_G13.Text.Trim(), y_Z13.Text.Trim(), y_G13.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位13！", "提示");
                            return;
                        }
                    }
                }

                if (textBox14.Text.Trim() != "")
                {
                    string rs14 = jiage(textBox14.Text.Trim());
                    if (rs14 != "")
                    {
                        double p14 = Convert.ToDouble(rs14);
                        w = CalWeight(l_C14.Text.Trim(), l_K14.Text.Trim(), l_G14.Text.Trim(), y_Z14.Text.Trim(), y_G14.Text.Trim(), y_ZB14.Text.Trim(), y_ZZ14.Text.Trim(), y_ZG14.Text.Trim(), f_C14.Text.Trim(), f_K14.Text.Trim(), f_G14.Text.Trim(), f_B14.Text.Trim());
                        p14 = Math.Round(jisuan(w, p14, textBox14.Text.Trim(), l_C14.Text.Trim(), l_K14.Text.Trim(), l_G14.Text.Trim(), y_Z14.Text.Trim(), y_G14.Text.Trim()), 1);
                        txt_gx14.Text = Convert.ToString(p14);
                    }
                    else//没有科学单价
                    {
                        if (dangwei14.Text != "")
                        {
                            txt_gx14.Text = gongshi(textBox14.Text, dangwei14.Text, l_C14.Text.Trim(), l_K14.Text.Trim(), l_G14.Text.Trim(), y_Z14.Text.Trim(), y_G14.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位14！", "提示");
                            return;
                        }
                    }
                }

                if (textBox15.Text.Trim() != "")
                {
                    string rs15 = jiage(textBox15.Text.Trim());
                    if (rs15 != "")
                    {
                        double p15 = Convert.ToDouble(rs15);
                        w = CalWeight(l_C15.Text.Trim(), l_K15.Text.Trim(), l_G15.Text.Trim(), y_Z15.Text.Trim(), y_G15.Text.Trim(), y_ZB15.Text.Trim(), y_ZZ15.Text.Trim(), y_ZG15.Text.Trim(), f_C15.Text.Trim(), f_K15.Text.Trim(), f_G15.Text.Trim(), f_B15.Text.Trim());
                        p15 = Math.Round(jisuan(w, p15, textBox15.Text.Trim(), l_C15.Text.Trim(), l_K15.Text.Trim(), l_G15.Text.Trim(), y_Z15.Text.Trim(), y_G15.Text.Trim()), 1);
                        txt_gx15.Text = Convert.ToString(p15);
                    }
                    else//没有科学单价
                    {
                        if (dangwei15.Text != "")
                        {
                            txt_gx15.Text = gongshi(textBox15.Text, dangwei15.Text, l_C15.Text.Trim(), l_K15.Text.Trim(), l_G15.Text.Trim(), y_Z15.Text.Trim(), y_G15.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位15！", "提示");
                            return;
                        }
                    }
                }

                if (textBox16.Text.Trim() != "")
                {
                    string rs16 = jiage(textBox16.Text.Trim());
                    if (rs16 != "")
                    {
                        double p16 = Convert.ToDouble(rs16);
                        w = CalWeight(l_C16.Text.Trim(), l_K16.Text.Trim(), l_G16.Text.Trim(), y_Z16.Text.Trim(), y_G16.Text.Trim(), y_ZB16.Text.Trim(), y_ZZ16.Text.Trim(), y_ZG16.Text.Trim(), f_C16.Text.Trim(), f_K16.Text.Trim(), f_G16.Text.Trim(), f_B16.Text.Trim());
                        p16 = Math.Round(jisuan(w, p16, textBox16.Text.Trim(), l_C16.Text.Trim(), l_K16.Text.Trim(), l_G16.Text.Trim(), y_Z16.Text.Trim(), y_G16.Text.Trim()), 1);
                        txt_gx16.Text = Convert.ToString(p16);
                    }
                    else//没有科学单价
                    {
                        if (dangwei16.Text != "")
                        {
                            txt_gx16.Text = gongshi(textBox16.Text, dangwei16.Text, l_C16.Text.Trim(), l_K16.Text.Trim(), l_G16.Text.Trim(), y_Z16.Text.Trim(), y_G16.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位16！", "提示");
                            return;
                        }
                    }
                }

                if (textBox17.Text.Trim() != "")
                {
                    string rs17 = jiage(textBox17.Text.Trim());
                    if (rs17 != "")
                    {
                        double p17 = Convert.ToDouble(rs17);
                        w = CalWeight(l_C17.Text.Trim(), l_K17.Text.Trim(), l_G17.Text.Trim(), y_Z17.Text.Trim(), y_G17.Text.Trim(), y_ZB17.Text.Trim(), y_ZZ17.Text.Trim(), y_ZG17.Text.Trim(), f_C17.Text.Trim(), f_K17.Text.Trim(), f_G17.Text.Trim(), f_B17.Text.Trim());
                        p17 = Math.Round(jisuan(w, p17, textBox17.Text.Trim(), l_C17.Text.Trim(), l_K17.Text.Trim(), l_G17.Text.Trim(), y_Z17.Text.Trim(), y_G17.Text.Trim()), 1);
                        txt_gx17.Text = Convert.ToString(p17);
                    }
                    else//没有科学单价
                    {
                        if (dangwei17.Text != "")
                        {
                            txt_gx17.Text = gongshi(textBox17.Text, dangwei17.Text, l_C17.Text.Trim(), l_K17.Text.Trim(), l_G17.Text.Trim(), y_Z17.Text.Trim(), y_G17.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位17！", "提示");
                            return;
                        }
                    }
                }

                if (textBox18.Text.Trim() != "")
                {
                    string rs18 = jiage(textBox18.Text.Trim());
                    if (rs18 != "")
                    {
                        double p18 = Convert.ToDouble(rs18);
                        w = CalWeight(l_C18.Text.Trim(), l_K18.Text.Trim(), l_G18.Text.Trim(), y_Z18.Text.Trim(), y_G18.Text.Trim(), y_ZB18.Text.Trim(), y_ZZ18.Text.Trim(), y_ZG18.Text.Trim(), f_C18.Text.Trim(), f_K18.Text.Trim(), f_G18.Text.Trim(), f_B18.Text.Trim());
                        p18 = Math.Round(jisuan(w, p18, textBox18.Text.Trim(), l_C18.Text.Trim(), l_K18.Text.Trim(), l_G18.Text.Trim(), y_Z18.Text.Trim(), y_G18.Text.Trim()), 1);
                        txt_gx18.Text = Convert.ToString(p18);
                    }
                    else//没有科学单价
                    {
                        if (dangwei18.Text != "")
                        {
                            txt_gx18.Text = gongshi(textBox18.Text, dangwei18.Text, l_C18.Text.Trim(), l_K18.Text.Trim(), l_G18.Text.Trim(), y_Z18.Text.Trim(), y_G18.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位18！", "提示");
                            return;
                        }
                    }
                }

                if (textBox19.Text.Trim() != "")
                {
                    string rs19 = jiage(textBox19.Text.Trim());
                    if (rs19 != "")
                    {
                        double p19 = Convert.ToDouble(rs19);
                        w = CalWeight(l_C19.Text.Trim(), l_K19.Text.Trim(), l_G19.Text.Trim(), y_Z19.Text.Trim(), y_G19.Text.Trim(), y_ZB19.Text.Trim(), y_ZZ19.Text.Trim(), y_ZG19.Text.Trim(), f_C19.Text.Trim(), f_K19.Text.Trim(), f_G19.Text.Trim(), f_B19.Text.Trim());
                        p19 = Math.Round(jisuan(w, p19, textBox19.Text.Trim(), l_C19.Text.Trim(), l_K19.Text.Trim(), l_G19.Text.Trim(), y_Z19.Text.Trim(), y_G19.Text.Trim()), 1);
                        txt_gx19.Text = Convert.ToString(p19);
                    }
                    else//没有科学单价
                    {
                        if (dangwei19.Text != "")
                        {
                            txt_gx19.Text = gongshi(textBox19.Text, dangwei19.Text, l_C19.Text.Trim(), l_K19.Text.Trim(), l_G19.Text.Trim(), y_Z19.Text.Trim(), y_G19.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位19！", "提示");
                            return;
                        }
                    }
                }

                if (textBox20.Text.Trim() != "")
                {
                    string rs20 = jiage(textBox20.Text.Trim());
                    if (rs20 != "")
                    {
                        double p20 = Convert.ToDouble(rs20);
                        w = CalWeight(l_C20.Text.Trim(), l_K20.Text.Trim(), l_G20.Text.Trim(), y_Z20.Text.Trim(), y_G20.Text.Trim(), y_ZB20.Text.Trim(), y_ZZ20.Text.Trim(), y_ZG20.Text.Trim(), f_C20.Text.Trim(), f_K20.Text.Trim(), f_G20.Text.Trim(), f_B20.Text.Trim());
                        p20 = Math.Round(jisuan(w, p20, textBox20.Text.Trim(), l_C20.Text.Trim(), l_K20.Text.Trim(), l_G20.Text.Trim(), y_Z20.Text.Trim(), y_G20.Text.Trim()), 1);
                        txt_gx20.Text = Convert.ToString(p20);
                    }
                    else//没有科学单价
                    {
                        if (dangwei20.Text != "")
                        {
                            txt_gx20.Text = gongshi(textBox20.Text, dangwei20.Text, l_C20.Text.Trim(), l_K20.Text.Trim(), l_G20.Text.Trim(), y_Z20.Text.Trim(), y_G20.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位20！", "提示");
                            return;
                        }
                    }
                }

                if (textBox21.Text.Trim() != "")
                {
                    string rs21 = jiage(textBox21.Text.Trim());
                    if (rs21 != "")
                    {
                        double p21 = Convert.ToDouble(rs21);
                        w = CalWeight(l_C21.Text.Trim(), l_K21.Text.Trim(), l_G21.Text.Trim(), y_Z21.Text.Trim(), y_G21.Text.Trim(), y_ZB21.Text.Trim(), y_ZZ21.Text.Trim(), y_ZG21.Text.Trim(), f_C21.Text.Trim(), f_K21.Text.Trim(), f_G21.Text.Trim(), f_B21.Text.Trim());
                        p21 = Math.Round(jisuan(w, p21, textBox21.Text.Trim(), l_C21.Text.Trim(), l_K21.Text.Trim(), l_G21.Text.Trim(), y_Z21.Text.Trim(), y_G21.Text.Trim()), 1);
                        txt_gx21.Text = Convert.ToString(p21);
                    }
                    else//没有科学单价
                    {
                        if (dangwei21.Text != "")
                        {
                            txt_gx21.Text = gongshi(textBox21.Text, dangwei21.Text, l_C21.Text.Trim(), l_K21.Text.Trim(), l_G21.Text.Trim(), y_Z21.Text.Trim(), y_G21.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位21！", "提示");
                            return;
                        }
                    }
                }

                if (textBox22.Text.Trim() != "")
                {
                    string rs22 = jiage(textBox22.Text.Trim());
                    if (rs22 != "")
                    {
                        double p22 = Convert.ToDouble(rs22);
                        w = CalWeight(l_C22.Text.Trim(), l_K22.Text.Trim(), l_G22.Text.Trim(), y_Z22.Text.Trim(), y_G22.Text.Trim(), y_ZB22.Text.Trim(), y_ZZ22.Text.Trim(), y_ZG22.Text.Trim(), f_C22.Text.Trim(), f_K22.Text.Trim(), f_G22.Text.Trim(), f_B22.Text.Trim());
                        p22 = Math.Round(jisuan(w, p22, textBox22.Text.Trim(), l_C22.Text.Trim(), l_K22.Text.Trim(), l_G22.Text.Trim(), y_Z22.Text.Trim(), y_G22.Text.Trim()), 1);
                        txt_gx22.Text = Convert.ToString(p22);
                    }
                    else//没有科学单价
                    {
                        if (dangwei22.Text != "")
                        {
                            txt_gx22.Text = gongshi(textBox22.Text, dangwei22.Text, l_C22.Text.Trim(), l_K22.Text.Trim(), l_G22.Text.Trim(), y_Z22.Text.Trim(), y_G22.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位22！", "提示");
                            return;
                        }
                    }
                }

                if (textBox23.Text.Trim() != "")
                {
                    string rs23 = jiage(textBox23.Text.Trim());
                    if (rs23 != "")
                    {
                        double p23 = Convert.ToDouble(rs23);
                        w = CalWeight(l_C23.Text.Trim(), l_K23.Text.Trim(), l_G23.Text.Trim(), y_Z23.Text.Trim(), y_G23.Text.Trim(), y_ZB23.Text.Trim(), y_ZZ23.Text.Trim(), y_ZG23.Text.Trim(), f_C23.Text.Trim(), f_K23.Text.Trim(), f_G23.Text.Trim(), f_B23.Text.Trim());
                        p23 = Math.Round(jisuan(w, p23, textBox23.Text.Trim(), l_C23.Text.Trim(), l_K23.Text.Trim(), l_G23.Text.Trim(), y_Z23.Text.Trim(), y_G23.Text.Trim()), 1);
                        txt_gx23.Text = Convert.ToString(p23);
                    }
                    else//没有科学单价
                    {
                        if (dangwei23.Text != "")
                        {
                            txt_gx23.Text = gongshi(textBox23.Text, dangwei23.Text, l_C23.Text.Trim(), l_K23.Text.Trim(), l_G23.Text.Trim(), y_Z23.Text.Trim(), y_G23.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位23！", "提示");
                            return;
                        }
                    }
                }

                if (textBox24.Text.Trim() != "")
                {
                    string rs24 = jiage(textBox24.Text.Trim());
                    if (rs24 != "")
                    {
                        double p24 = Convert.ToDouble(rs24);
                        w = CalWeight(l_C24.Text.Trim(), l_K24.Text.Trim(), l_G24.Text.Trim(), y_Z24.Text.Trim(), y_G24.Text.Trim(), y_ZB24.Text.Trim(), y_ZZ24.Text.Trim(), y_ZG24.Text.Trim(), f_C24.Text.Trim(), f_K24.Text.Trim(), f_G24.Text.Trim(), f_B24.Text.Trim());
                        p24 = Math.Round(jisuan(w, p24, textBox24.Text.Trim(), l_C24.Text.Trim(), l_K24.Text.Trim(), l_G24.Text.Trim(), y_Z24.Text.Trim(), y_G24.Text.Trim()), 1);
                        txt_gx24.Text = Convert.ToString(p24);
                    }
                    else//没有科学单价
                    {
                        if (dangwei24.Text != "")
                        {
                            txt_gx24.Text = gongshi(textBox24.Text, dangwei24.Text, l_C24.Text.Trim(), l_K24.Text.Trim(), l_G24.Text.Trim(), y_Z24.Text.Trim(), y_G24.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位24！", "提示");
                            return;
                        }
                    }
                }

                if (textBox25.Text.Trim() != "")
                {
                    string rs25 = jiage(textBox25.Text.Trim());
                    if (rs25 != "")
                    {
                        double p25 = Convert.ToDouble(rs25);
                        w = CalWeight(l_C25.Text.Trim(), l_K25.Text.Trim(), l_G25.Text.Trim(), y_Z25.Text.Trim(), y_G25.Text.Trim(), y_ZB25.Text.Trim(), y_ZZ25.Text.Trim(), y_ZG25.Text.Trim(), f_C25.Text.Trim(), f_K25.Text.Trim(), f_G25.Text.Trim(), f_B25.Text.Trim());
                        p25 = Math.Round(jisuan(w, p25, textBox25.Text.Trim(), l_C25.Text.Trim(), l_K25.Text.Trim(), l_G25.Text.Trim(), y_Z25.Text.Trim(), y_G25.Text.Trim()), 1);
                        txt_gx25.Text = Convert.ToString(p25);
                    }
                    else//没有科学单价
                    {
                        if (dangwei25.Text != "")
                        {
                            txt_gx25.Text = gongshi(textBox25.Text, dangwei25.Text, l_C25.Text.Trim(), l_K25.Text.Trim(), l_G25.Text.Trim(), y_Z25.Text.Trim(), y_G25.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("请输入档位25！", "提示");
                            return;
                        }
                    }
                }

                if (txt_gx1.Text == "0")
                    txt_gx1.Text = "";
                if (txt_gx2.Text == "0")
                    txt_gx2.Text = "";
                if (txt_gx3.Text == "0")
                    txt_gx3.Text = "";
                if (txt_gx4.Text == "0")
                    txt_gx4.Text = "";
                if (txt_gx5.Text == "0")
                    txt_gx5.Text = "";
                if (txt_gx6.Text == "0")
                    txt_gx6.Text = "";
                if (txt_gx7.Text == "0")
                    txt_gx7.Text = "";
                if (txt_gx8.Text == "0")
                    txt_gx8.Text = "";
                if (txt_gx9.Text == "0")
                    txt_gx9.Text = "";
                if (txt_gx10.Text == "0")
                    txt_gx10.Text = "";
                if (txt_gx11.Text == "0")
                    txt_gx11.Text = "";
                if (txt_gx12.Text == "0")
                    txt_gx12.Text = "";
                if (txt_gx13.Text == "0")
                    txt_gx13.Text = "";
                if (txt_gx14.Text == "0")
                    txt_gx14.Text = "";
                if (txt_gx15.Text == "0")
                    txt_gx15.Text = "";
                if (txt_gx16.Text == "0")
                    txt_gx16.Text = "";
                if (txt_gx17.Text == "0")
                    txt_gx17.Text = "";
                if (txt_gx18.Text == "0")
                    txt_gx18.Text = "";
                if (txt_gx19.Text == "0")
                    txt_gx19.Text = "";
                if (txt_gx20.Text == "0")
                    txt_gx20.Text = "";
                if (txt_gx21.Text == "0")
                    txt_gx21.Text = "";
                if (txt_gx22.Text == "0")
                    txt_gx22.Text = "";
                if (txt_gx23.Text == "0")
                    txt_gx23.Text = "";
                if (txt_gx24.Text == "0")
                    txt_gx24.Text = "";
                if (txt_gx25.Text == "0")
                    txt_gx25.Text = "";

            }
            catch
            {

            }
        }

        /// <summary>
        /// 查询科学单价
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string jiage(string str)
        {
            string s = "select 科学单价 from db_gongxumingcheng where 工序名称='" + str + "'";
            string r = Convert.ToString(SQLhelp.ExecuteScalar(s, CommandType.Text));
            return r;
        }
        /// <summary>
        /// 计算重量
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
        private double CalWeight(string k1,string k2,string k3,string k4,string k5,string k6,string k7,string k8,string k9,string k10,string k11,string k12)
        {
            //获取零件的长、宽、高等
            if (k1 != "" && k2 != "" && k3 != "")
            {
                //立方体长、宽、高
                double a1 = Convert.ToDouble(k1);
                double b1 = Convert.ToDouble(k2);
                double c1 = Convert.ToDouble(k3);

                switch (com_cailiaocaizhi.Text.Trim())
                {
                    case "铁":
                        w = (a1 * b1 * c1) * 7.9 / 1000000;
                        break;
                    case "电木":
                        w = (a1 * b1 * c1) * 1.5 / 1000000;
                        break;
                    case "聚氨酯":
                        w = (a1 * b1 * c1) * 1.0 / 1000000;
                        break;
                    case "铜":
                        w = (a1 * b1 * c1) * 8.9 / 1000000;
                        break;
                    case "尼龙":
                        w = (a1 * b1 * c1) * 1.15 / 1000000;
                        break;
                    case "铝":
                        w = (a1 * b1 * c1) * 2.78 / 1000000;
                        break;
                }
            }

            if (k4 != "" && k5 != "")
            {
                //圆柱体直径、高
                double r2 = Convert.ToDouble(k4);
                double c2 = Convert.ToDouble(k5);

                switch (com_cailiaocaizhi.Text.Trim())
                {
                    case "铁":
                        w = (3.14 * r2 * r2 / 4 * c2) * 7.9 / 1000000;
                        break;
                    case "电木":
                        w = (3.14 * r2 * r2 / 4 * c2) * 1.5 / 1000000;
                        break;
                    case "聚氨酯":
                        w = (3.14 * r2 * r2 / 4 * c2) * 1.0 / 1000000;
                        break;
                    case "铜":
                        w = (3.14 * r2 * r2 / 4 * c2) * 8.9 / 1000000;
                        break;
                    case "尼龙":
                        w = (3.14 * r2 * r2 / 4 * c2) * 1.15 / 1000000;
                        break;
                    case "铝":
                        w = (3.14 * r2 * r2 / 4 * c2) * 2.78 / 1000000;
                        break;
                }
            }

            if (k6 != "" && k7 != "" && k8 != "" && k9 != "")
            {
                //方管长、宽、高、壁厚
                double a3 = Convert.ToDouble(k6);
                double b3 = Convert.ToDouble(k7);
                double c3 = Convert.ToDouble(k8);
                double d3 = Convert.ToDouble(k9);
            }

            if (k10 != "" && k11 != "" && k12 != "")
            {
                //圆管直径、高、壁厚
                double r4 = Convert.ToDouble(k10);
                double c4 = Convert.ToDouble(k11);
                double d4 = Convert.ToDouble(k12);
            }

            return w;
        } 
    }
}
