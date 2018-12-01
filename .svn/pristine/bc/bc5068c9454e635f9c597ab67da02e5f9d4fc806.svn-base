using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ztznpms.Common;
using ThoughtWorks.QRCode.Codec;
using Aspose.Words;
using Aspose.Words.Drawing;
using System.IO;

namespace ztznpms.UI.工序管理
{
    public partial class Formgongdan : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public string yonghu;
        public string bianhao;
        public string bianma;
        public string number;

        public double zongjiage = 0;
        public double zongjiage1 = 0;
        public double zongjiage2 = 0;
        public double zongjiage3 = 0;
        public double zongjiage4 = 0;
        public double zongjiage5 = 0;

        Image image;
        public Formgongdan()
        {
            InitializeComponent();
        }

        private void Formgongdan_Load(object sender, EventArgs e)
        {
            reload();

            com_paigongxingzhi.Properties.Items.Add("机修");
            com_paigongxingzhi.Properties.Items.Add("装配配焊");
            com_paigongxingzhi.Properties.Items.Add("技术更改");
            com_paigongxingzhi.Properties.Items.Add("外协返修");
            com_paigongxingzhi.Properties.Items.Add("自制返修");
            com_paigongxingzhi.Properties.Items.Add("工装夹具");
            com_paigongxingzhi.Properties.Items.Add("车间维护");


            //工序名称
            string s1 = "select * from db_gongxumingcheng";
            DataTable row = SQLhelp.GetDataTable(s1, CommandType.Text);
            foreach (DataRow dr in row.Rows)
            {
                this.comboBox1.Properties.Items.Add(dr["工序名称"].ToString());
                this.comboBox2.Properties.Items.Add(dr["工序名称"].ToString());
                this.comboBox3.Properties.Items.Add(dr["工序名称"].ToString());
                this.comboBox4.Properties.Items.Add(dr["工序名称"].ToString());
                this.comboBox5.Properties.Items.Add(dr["工序名称"].ToString());

                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;

                richTextBox1.Enabled = false;
                richTextBox2.Enabled = false;
                richTextBox3.Enabled = false;
                richTextBox4.Enabled = false;
                richTextBox5.Enabled = false;
            }

            //工序负责人
            string s11 = "select * from db_chejianrenyuan";
            DataTable cr = SQLhelp.GetDataTable(s11, CommandType.Text);

            foreach (DataRow dr in cr.Rows)
            {
                this.com_fuzeren1.Properties.Items.Add(dr["机加车间人员"].ToString());
                this.com_fuzeren2.Properties.Items.Add(dr["机加车间人员"].ToString());
                this.com_fuzeren3.Properties.Items.Add(dr["机加车间人员"].ToString());
                this.com_fuzeren4.Properties.Items.Add(dr["机加车间人员"].ToString());
                this.com_fuzeren5.Properties.Items.Add(dr["机加车间人员"].ToString());

                com_fuzeren1.Enabled = false;
                com_fuzeren2.Enabled = false;
                com_fuzeren3.Enabled = false;
                com_fuzeren4.Enabled = false;
                com_fuzeren5.Enabled = false;
            }

            txt_shuliang1.Enabled = false;
            txt_shuliang2.Enabled = false;
            txt_shuliang3.Enabled = false;
            txt_shuliang4.Enabled = false;
            txt_shuliang5.Enabled = false;

            txt_gx1.Enabled = false;
            txt_gx2.Enabled = false;
            txt_gx3.Enabled = false;
            txt_gx4.Enabled = false;
            txt_gx5.Enabled = false;

            startload();

            CodeReplay();//二维码显示
        }

        private void startload()
        {
            string s2 = "select * from db_paigong where  ID号='" + id + "'";
            string r2 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));
            if(r2 != "")
            {
                DataTable dtg = SQLhelp.GetDataTable(s2, CommandType.Text);//通过图号、名称查到db_gongxu表中的数据

                text_caizhi.Text = dtg.Rows[0]["材料"].ToString();

                for (int i = 0; i < dtg.Rows.Count; i++)
                {
                    DataRow drg = dtg.Rows[i];//拿到每一行的数据
                    if (drg["工序顺序"].ToString() == "1")
                    {
                        comboBox1.Text = drg["工序名称"].ToString();
                        richTextBox1.Text = drg["工序内容"].ToString();
                        txt_gx1.Text = drg["价格"].ToString();
                        com_fuzeren1.Text = drg["负责人"].ToString();
                        txt_shuliang1.Text = drg["数量"].ToString();
                    }
                    if (drg["工序顺序"].ToString() == "2")
                    {
                        comboBox2.Text = drg["工序名称"].ToString();
                        richTextBox2.Text = drg["工序内容"].ToString();
                        txt_gx2.Text = drg["价格"].ToString();
                        com_fuzeren2.Text = drg["负责人"].ToString();
                        txt_shuliang2.Text = drg["数量"].ToString();
                    }
                    if (drg["工序顺序"].ToString() == "3")
                    {
                        comboBox3.Text = drg["工序名称"].ToString();
                        richTextBox3.Text = drg["工序内容"].ToString();
                        txt_gx3.Text = drg["价格"].ToString();
                        com_fuzeren3.Text = drg["负责人"].ToString();
                        txt_shuliang3.Text = drg["数量"].ToString();
                    }
                    if (drg["工序顺序"].ToString() == "4")
                    {
                        comboBox4.Text = drg["工序名称"].ToString();
                        richTextBox4.Text = drg["工序内容"].ToString();
                        txt_gx4.Text = drg["价格"].ToString();
                        com_fuzeren4.Text = drg["负责人"].ToString();
                        txt_shuliang4.Text = drg["数量"].ToString();
                    }
                    if (drg["工序顺序"].ToString() == "5")
                    {
                        comboBox5.Text = drg["工序名称"].ToString();
                        richTextBox5.Text = drg["工序内容"].ToString();
                        txt_gx5.Text = drg["价格"].ToString();
                        com_fuzeren5.Text = drg["负责人"].ToString();
                        txt_shuliang5.Text = drg["数量"].ToString();
                    }
                }

                simpleButton6.Enabled = false;
            }


        }

        /// <summary>
        /// 二维码显示
        /// </summary>
        private void CodeReplay()
        {
            string a = text_tuhao.Text;//图号
            string b = text_lingjianmingcheng.Text;//名称
            string d = text_gongzuolinghao.Text;//工作令号
            string f = text_xiangmumingcheng.Text;//项目名称
            string h = id;
            string j = "派工单";

            //string dataCode = f + "\n" + d + "\n" + a + "\n" + b + "\n" + h + "\n" + j + "\n";

            string dataCode = f + "|" + d + "|" + a + "|" + b + "|" + h + "|" + j + "|";

            richTextBox6.Text = dataCode;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;


            Image image;
            string data = dataCode;
            image = qrCodeEncoder.Encode(data, Encoding.UTF8);
            pictureBox1.Size = new Size(180, 180);
            pictureBox1.Image = image;
        }
        private void reload()
        {
            string sql1 = "select * from tb_Paigongdan where id='"+ id +"'";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);
            DataRow dr1 = dt1.Rows[0];

            text_gongzuolinghao.Text = dr1["工作令号"].ToString();
            text_shebeimingcheng.Text = dr1["设备名称"].ToString();
            text_xiangmumingcheng.Text = dr1["项目名称"].ToString();
            text_lingjianmingcheng.Text = dr1["名称"].ToString();
            text_tuhao.Text = dr1["型号"].ToString();
            com_paigongxingzhi.Text = dr1["派工性质"].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "")
            {
                richTextBox1.Enabled = true;
                txt_shuliang1.Enabled = true;
                txt_gx1.Enabled = true;
                comboBox2.Enabled = true;
                com_fuzeren1.Enabled = true;
            }

            com_fuzeren1.Text = "";
            com_fuzeren1.Properties.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox1.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (com_fuzeren1.Properties.Items.Cast<object>().All(x => x.ToString() != a))
                        com_fuzeren1.Properties.Items.Add(a);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim() != "")
            {
                richTextBox2.Enabled = true;
                txt_shuliang2.Enabled = true;
                txt_gx2.Enabled = true;
                comboBox3.Enabled = true;
                com_fuzeren2.Enabled = true;
            }

            com_fuzeren2.Text = "";
            com_fuzeren2.Properties.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox2.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (com_fuzeren2.Properties.Items.Cast<object>().All(x => x.ToString() != a))
                        com_fuzeren2.Properties.Items.Add(a);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Trim() != "")
            {
                richTextBox3.Enabled = true;
                txt_shuliang3.Enabled = true;
                txt_gx3.Enabled = true;
                comboBox4.Enabled = true;
                com_fuzeren3.Enabled = true;
            }

            com_fuzeren3.Text = "";
            com_fuzeren3.Properties.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox3.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (com_fuzeren3.Properties.Items.Cast<object>().All(x => x.ToString() != a))
                        com_fuzeren3.Properties.Items.Add(a);
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text.Trim() != "")
            {
                richTextBox4.Enabled = true;
                txt_shuliang4.Enabled = true;
                txt_gx4.Enabled = true;
                comboBox5.Enabled = true;
                com_fuzeren4.Enabled = true;
            }

            com_fuzeren4.Text = "";
            com_fuzeren4.Properties.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox4.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (com_fuzeren4.Properties.Items.Cast<object>().All(x => x.ToString() != a))
                        com_fuzeren4.Properties.Items.Add(a);
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text.Trim() != "")
            {
                richTextBox5.Enabled = true;
                txt_shuliang5.Enabled = true;
                txt_gx5.Enabled = true;
                com_fuzeren5.Enabled = true;
            }

            com_fuzeren5.Text = "";
            com_fuzeren5.Properties.Items.Clear();
            string sql = "select 机加车间人员 from db_chejianrenyuan where 工序类型='" + comboBox5.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["机加车间人员"].ToString();
                    if (com_fuzeren5.Properties.Items.Cast<object>().All(x => x.ToString() != a))
                        com_fuzeren5.Properties.Items.Add(a);
                }
            }
        }

        /// <summary>
        /// 生成派工单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请添加工序！", "提示");
                return;
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("请添加工序内容！", "提示");
                return;
            }

            string time = DateTime.Now.ToString("yyyy/MM/dd");

            DataTable dt = new DataTable();

            dt.Columns.Add("设备名", typeof(string));
            dt.Columns.Add("零件名称", typeof(string));
            dt.Columns.Add("零件图号", typeof(string));
            dt.Columns.Add("派工性质", typeof(string));
            dt.Columns.Add("工令号", typeof(string));
            dt.Columns.Add("材质", typeof(string));
            dt.Columns.Add("编制人", typeof(string));
            dt.Columns.Add("PHOTO", typeof(Image));

            dt.Columns.Add("工序1", typeof(string));
            dt.Columns.Add("工序2", typeof(string));
            dt.Columns.Add("工序3", typeof(string));
            dt.Columns.Add("工序4", typeof(string));
            dt.Columns.Add("工序5", typeof(string));

            dt.Columns.Add("内容1", typeof(string));
            dt.Columns.Add("内容2", typeof(string));
            dt.Columns.Add("内容3", typeof(string));
            dt.Columns.Add("内容4", typeof(string));
            dt.Columns.Add("内容5", typeof(string));

            dt.Columns.Add("负责人1", typeof(string));
            dt.Columns.Add("负责人2", typeof(string));
            dt.Columns.Add("负责人3", typeof(string));
            dt.Columns.Add("负责人4", typeof(string));
            dt.Columns.Add("负责人5", typeof(string));

            dt.Columns.Add("价格1", typeof(string));
            dt.Columns.Add("价格2", typeof(string));
            dt.Columns.Add("价格3", typeof(string));
            dt.Columns.Add("价格4", typeof(string));
            dt.Columns.Add("价格5", typeof(string));

            dt.Columns.Add("数量1", typeof(string));
            dt.Columns.Add("数量2", typeof(string));
            dt.Columns.Add("数量3", typeof(string));
            dt.Columns.Add("数量4", typeof(string));
            dt.Columns.Add("数量5", typeof(string));

            DataRow dr = dt.NewRow();

            dr["设备名"] = text_shebeimingcheng.Text;
            dr["零件名称"] = text_lingjianmingcheng.Text;
            dr["零件图号"] = text_tuhao.Text;
            dr["派工性质"] = com_paigongxingzhi.Text;
            dr["工令号"] = text_gongzuolinghao.Text;
            dr["编制人"] = time + " " + yonghu;
            dr["材质"] = text_caizhi.Text;

            if (comboBox1.Text.Trim() != "")
            {
                dr["工序1"] = comboBox1.Text.Trim();
                dr["内容1"] = richTextBox1.Text;
                dr["负责人1"] = com_fuzeren1.Text;
                dr["价格1"] = txt_gx1.Text;
                dr["数量1"] = txt_shuliang1.Text;
            }
            if (comboBox2.Text.Trim() != "")
            {
                dr["工序2"] = comboBox2.Text.Trim();
                dr["内容2"] = richTextBox2.Text;
                dr["负责人2"] = com_fuzeren2.Text;
                dr["价格2"] = txt_gx2.Text;
                dr["数量2"] = txt_shuliang2.Text;
            }
            if (comboBox3.Text.Trim() != "")
            {
                dr["工序3"] = comboBox3.Text.Trim();
                dr["内容3"] = richTextBox3.Text;
                dr["负责人3"] = com_fuzeren3.Text;
                dr["价格3"] = txt_gx3.Text;
                dr["数量3"] = txt_shuliang3.Text;
            }
            if (comboBox4.Text.Trim() != "")
            {
                dr["工序4"] = comboBox4.Text.Trim();
                dr["内容4"] = richTextBox4.Text;
                dr["负责人4"] = com_fuzeren4.Text;
                dr["价格4"] = txt_gx4.Text;
                dr["数量4"] = txt_shuliang4.Text;
            }
            if (comboBox5.Text.Trim() != "")
            {
                dr["工序5"] = comboBox5.Text.Trim();
                dr["内容5"] = richTextBox5.Text;
                dr["负责人5"] = com_fuzeren5.Text;
                dr["价格5"] = txt_gx5.Text;
                dr["数量5"] = txt_shuliang5.Text;
            }

            dt.Rows.Add(dr);

            string tempFile = Application.StartupPath + "\\派工单.doc";
            
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            image = pictureBox1.Image;

            builder.MoveToBookmark("PHOTO");
            builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 65, 65, WrapType.Square);


            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr1 = dt.Rows[0];

            dic.Add("设备名", dr["设备名"].ToString());
            dic.Add("零件名称", dr["零件名称"].ToString());
            dic.Add("零件图号", dr["零件图号"].ToString());
            dic.Add("派工性质", dr["派工性质"].ToString());
            dic.Add("工令号", dr["工令号"].ToString());
            dic.Add("编制人", dr["编制人"].ToString());
            dic.Add("材质", dr["材质"].ToString());

            dic.Add("工序1", dr["工序1"].ToString());
            dic.Add("工序2", dr["工序2"].ToString());
            dic.Add("工序3", dr["工序3"].ToString());
            dic.Add("工序4", dr["工序4"].ToString());
            dic.Add("工序5", dr["工序5"].ToString());

            dic.Add("内容1", dr["内容1"].ToString());
            dic.Add("内容2", dr["内容2"].ToString());
            dic.Add("内容3", dr["内容3"].ToString());
            dic.Add("内容4", dr["内容4"].ToString());
            dic.Add("内容5", dr["内容5"].ToString());

            dic.Add("负责人1", dr["负责人1"].ToString());
            dic.Add("负责人2", dr["负责人2"].ToString());
            dic.Add("负责人3", dr["负责人3"].ToString());
            dic.Add("负责人4", dr["负责人4"].ToString());
            dic.Add("负责人5", dr["负责人5"].ToString());

            dic.Add("价格1", dr["价格1"].ToString());
            dic.Add("价格2", dr["价格2"].ToString());
            dic.Add("价格3", dr["价格3"].ToString());
            dic.Add("价格4", dr["价格4"].ToString());
            dic.Add("价格5", dr["价格5"].ToString());

            dic.Add("数量1", dr["数量1"].ToString());
            dic.Add("数量2", dr["数量2"].ToString());
            dic.Add("数量3", dr["数量3"].ToString());
            dic.Add("数量4", dr["数量4"].ToString());
            dic.Add("数量5", dr["数量5"].ToString());

            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }

            string str1 = text_tuhao.Text;
            if (str1.Contains("/"))
            {
                str1 = str1.Replace("/", "");
            }
            if (str1.Contains("|"))
            {
                str1 = str1.Replace("|", "");
            }
            string str2 = text_gongzuolinghao.Text;
            if (str2.Contains("/"))
            {
                str2 = str2.Replace("/", "");
            }

            string strmingcheng = text_lingjianmingcheng.Text;
            if (strmingcheng.Contains("+"))
            {
                strmingcheng = strmingcheng.Replace("+", "-");
            }
            if (strmingcheng.Contains("*"))
            {
                strmingcheng = strmingcheng.Replace("*", "-");
            }
            if (strmingcheng.Contains("（"))
            {
                strmingcheng = strmingcheng.Replace("（", "");
            }
            if (strmingcheng.Contains("）"))
            {
                strmingcheng = strmingcheng.Replace("）", "");
            }
            if (strmingcheng.Contains("_"))
            {
                strmingcheng = strmingcheng.Replace("(", "");
            }
            if (strmingcheng.Contains("\n"))
            {
                strmingcheng = strmingcheng.Replace("\n", "-");
            }

            string strshebeimingcheng = text_shebeimingcheng.Text;


            string docName = "派工单" + "-" + str2 + "-" + strshebeimingcheng + "-" + str1 + "-" + strmingcheng + ".doc";
            if (docName.Contains("\t"))
            {
                docName = docName.Replace("\t", "");
            }
            //FileInfo info1 = new FileInfo(Application.StartupPath + "\\" + docName);
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + docName);
            string fileName11 = info1.Name.ToString();

            doc.Save(info1.DirectoryName + "\\" + fileName11);
            MessageBox.Show("派工单保存到桌面成功！", "提示");
        }

        /// <summary>
        /// 保存派工单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string time1 = DateTime.Now.ToString();

            //工序1
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请先设置工序再保存！", "提示");
                return;
            }
            else
            {
                string s1 = "insert into db_paigong(项目名称,图号,名称,工作令号,编码,设备名称,零件编号,数量,工序名称,工序顺序,工序内容,价格,负责人,序号,材料,工艺制定时间,状态,料单号,ID号,派工性质) values('" + text_xiangmumingcheng.Text + "','" + text_tuhao.Text + "','" + text_lingjianmingcheng.Text + "','" + text_gongzuolinghao.Text + "','" + bianma + "','" + text_shebeimingcheng.Text + "','" + bianhao + "','" + txt_shuliang1.Text + "','" + comboBox1.Text.Trim() + "','" + 1 + "','" + richTextBox1.Text + "','" + txt_gx1.Text.Trim() + "','" + com_fuzeren1.Text.Trim() + "','" + bianhao + "','" + text_caizhi.Text + "','" + time1 + "','0','"+ number +"','"+ id + "','" + com_paigongxingzhi.Text + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                zongjiage1 = Convert.ToDouble(txt_gx1.Text.Trim()) * Convert.ToDouble(txt_shuliang1.Text.Trim());
            }

            //工序2
            if (comboBox2.Text != "")
            {
                string s1 = "insert into db_paigong(项目名称,图号,名称,工作令号,编码,设备名称,零件编号,数量,工序名称,工序顺序,工序内容,价格,负责人,序号,材料,工艺制定时间,状态,料单号,ID号,派工性质) values('" + text_xiangmumingcheng.Text + "','" + text_tuhao.Text + "','" + text_lingjianmingcheng.Text + "','" + text_gongzuolinghao.Text + "','" + bianma + "','" + text_shebeimingcheng.Text + "','" + bianhao + "','" + txt_shuliang2.Text + "','" + comboBox2.Text.Trim() + "','" + 2 + "','" + richTextBox2.Text + "','" + txt_gx2.Text.Trim() + "','" + com_fuzeren2.Text.Trim() + "','" + bianhao + "','" + text_caizhi.Text + "','" + time1 + "','0','" + number + "','" + id + "','" + com_paigongxingzhi.Text + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                zongjiage2 = Convert.ToDouble(txt_gx2.Text.Trim()) * Convert.ToDouble(txt_shuliang2.Text.Trim());
            }

            //工序3
            if (comboBox3.Text != "")
            {
                string s1 = "insert into db_paigong(项目名称,图号,名称,工作令号,编码,设备名称,零件编号,数量,工序名称,工序顺序,工序内容,价格,负责人,序号,材料,工艺制定时间,状态,料单号,ID号,派工性质) values('" + text_xiangmumingcheng.Text + "','" + text_tuhao.Text + "','" + text_lingjianmingcheng.Text + "','" + text_gongzuolinghao.Text + "','" + bianma + "','" + text_shebeimingcheng.Text + "','" + bianhao + "','" + txt_shuliang3.Text + "','" + comboBox3.Text.Trim() + "','" + 3 + "','" + richTextBox3.Text + "','" + txt_gx3.Text.Trim() + "','" + com_fuzeren3.Text.Trim() + "','" + bianhao + "','" + text_caizhi.Text + "','" + time1 + "','0','" + number + "','" + id + "','" + com_paigongxingzhi.Text + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                zongjiage3 = Convert.ToDouble(txt_gx3.Text.Trim()) * Convert.ToDouble(txt_shuliang3.Text.Trim());
            }

            //工序4
            if (comboBox4.Text != "")
            {
                string s1 = "insert into db_paigong(项目名称,图号,名称,工作令号,编码,设备名称,零件编号,数量,工序名称,工序顺序,工序内容,价格,负责人,序号,材料,工艺制定时间,状态,料单号,ID号,派工性质) values('" + text_xiangmumingcheng.Text + "','" + text_tuhao.Text + "','" + text_lingjianmingcheng.Text + "','" + text_gongzuolinghao.Text + "','" + bianma + "','" + text_shebeimingcheng.Text + "','" + bianhao + "','" + txt_shuliang4.Text + "','" + comboBox4.Text.Trim() + "','" + 4 + "','" + richTextBox4.Text + "','" + txt_gx4.Text.Trim() + "','" + com_fuzeren4.Text.Trim() + "','" + bianhao + "','" + text_caizhi.Text + "','" + time1 + "','0','" + number + "','" + id + "','" + com_paigongxingzhi.Text + "')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                zongjiage4 = Convert.ToDouble(txt_gx4.Text.Trim()) * Convert.ToDouble(txt_shuliang4.Text.Trim());
            }

            //工序5
            if (comboBox5.Text != "")
            {
                string s1 = "insert into db_paigong(项目名称,图号,名称,工作令号,编码,设备名称,零件编号,数量,工序名称,工序顺序,工序内容,价格,负责人,序号,材料,工艺制定时间,状态,料单号,ID号,派工性质) values('" + text_xiangmumingcheng.Text + "','" + text_tuhao.Text + "','" + text_lingjianmingcheng.Text + "','" + text_gongzuolinghao.Text + "','" + bianma + "','" + text_shebeimingcheng.Text + "','" + bianhao + "','" + txt_shuliang5.Text + "','" + comboBox5.Text.Trim() + "','" + 5 + "','" + richTextBox5.Text + "','" + txt_gx5.Text.Trim() + "','" + com_fuzeren5.Text.Trim() + "','" + bianhao + "','" + text_caizhi.Text + "','" + time1 + "','0','" + number + "','" + id + "','"+ com_paigongxingzhi.Text +"')";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                zongjiage5 = Convert.ToDouble(txt_gx5.Text.Trim()) * Convert.ToDouble(txt_shuliang5.Text.Trim());
            }

            zongjiage = zongjiage1 + zongjiage2 + zongjiage3 + zongjiage4 + zongjiage5;
            //更新 工序名称 到tb_Paigongdan
            string sqlgongxu = "update tb_Paigongdan set 派工性质='" + com_paigongxingzhi.Text + "',工序1='" + comboBox1.Text.Trim() + "',工序2='" + comboBox2.Text.Trim() + "',工序3='" + comboBox3.Text.Trim() + "',工序4='" + comboBox4.Text.Trim() + "',工序5='" + comboBox5.Text.Trim() + "',总价格='" + zongjiage + "' where id='" + id + "'";
            string retgongxu = Convert.ToString(SQLhelp.ExecuteNonquery1(sqlgongxu, CommandType.Text));

            //插入二维码到数据库
            byte[] imageBytes = GetImageBytes(pictureBox1.Image);
            string sqlByte = "update db_paigong set 二维码=@pic where ID号='"+ id +"'";
            string retByte = Convert.ToString(SQLhelp.ExecuteNonqueryByte(sqlByte, CommandType.Text, imageBytes));
            if (retByte != "")
            {
                MessageBox.Show("保存派工单成功！", "提示");
                //this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        //将二维码图片转化成二进制
        private byte[] GetImageBytes(Image image)
        {
            MemoryStream mstream = new MemoryStream();
            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byteData, 0, byteData.Length);
            mstream.Close();
            return byteData;
        }
    }
}