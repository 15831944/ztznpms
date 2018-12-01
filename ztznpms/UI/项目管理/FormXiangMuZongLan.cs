using System;
using System.Data;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.项目管理
{
    public partial class FormXiangMuZongLan : Form
    {
        public string ZonglanTuhao;
        public string ZonglanMingcheng;
        public FormXiangMuZongLan()
        {
            InitializeComponent();
        }

        private void FormXiangMuZongLan_Load(object sender, EventArgs e)
        {
            DataTable dt = xin(ZonglanTuhao, ZonglanMingcheng);
            DataRow row = dt.Rows[0];
            txt_tuhao.Text = ZonglanTuhao;
            txt_mingcheng.Text = ZonglanMingcheng;
            txt_jiagong.Text = row[1].ToString();
            txt_shebei.Text = row[10].ToString();
            txt_danhao.Text = row[11].ToString();
            txt_gonglinghao.Text = row[12].ToString();
        }

        private DataTable xin(string a, string b)
        {
            string s1 = "select * from db_jihuadan where 图号='" + a + "' and 名称='" + b + "'";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            return dt;
        }

        private void FormXiangMuZongLan_Shown(object sender, EventArgs e)
        {
            string tu = ZonglanTuhao;
            string ming = ZonglanMingcheng;

            string s1 = "select * from db_gongxu where 图号='"+ tu +"' and 名称='"+ ming +"'";
            DataTable gongxu = SQLhelp.GetDataTable(s1, CommandType.Text);

            for (int i = 0; i < gongxu.Rows.Count; i++)
            {
                if (gongxu.Rows[i]["工序顺序"].ToString() == "1")
                {
                    textBox1.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "2")
                {
                    textBox2.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "3")
                {
                    textBox3.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "4")
                {
                    textBox4.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "5")
                {
                    textBox5.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "6")
                {
                    textBox6.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "7")
                {
                    textBox7.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "8")
                {
                    textBox8.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "9")
                {
                    textBox9.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "10")
                {
                    textBox10.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "11")
                {
                    textBox11.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "12")
                {
                    textBox12.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "13")
                {
                    textBox13.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "14")
                {
                    textBox14.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "15")
                {
                    textBox15.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "16")
                {
                    textBox16.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "17")
                {
                    textBox17.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "18")
                {
                    textBox18.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "19")
                {
                    textBox19.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
                if (gongxu.Rows[i]["工序顺序"].ToString() == "20")
                {
                    textBox20.Text = gx(gongxu.Rows[i]["工序顺序"].ToString());
                }
            }



            ////string str = ConfigurationManager.ConnectionStrings["mysqlserver"].ConnectionString;
            //string str1 = "Data Source=DESKTOP-ABRIFKO; Initial Catalog=db_SCB; Integrated Security=True";
            //SqlConnection conn = new SqlConnection(str1);

            //SqlCommand cmd = new SqlCommand("select 文件 from db_tuzhi where 图号= '" + ZonglanTuhao + "' and 名称='" + ZonglanMingcheng + "' ", conn);
            //conn.Open();
            //if (Convert.ToString(cmd.ExecuteScalar()) != "")
            //{
            //    this.pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])cmd.ExecuteScalar(), false));
            //}

            //conn.Close();



            //string strSql = "select 文件 from db_tuzhi where 图号= '" + ZonglanTuhao + "' and 名称='" + ZonglanMingcheng + "'";

            //DataTable dt = new DataTable();
            //try
            //{
            //    using(SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ABRIFKO; Initial Catalog=db_SCB; Integrated Security=True"))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            //        da.Fill(dt);
            //    }

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //byte[] bs = (byte[])(dt.Rows[0][0]);
            //MemoryStream myStream = new MemoryStream();

            //foreach (byte a in bs)
            //{
            //    myStream.WriteByte(a);
            //}

            //Image myImage = Image.FromStream(myStream);
            //myStream.Close();
            //this.pictureBox1.Image = myImage;
            //this.pictureBox1.Refresh();
        }

        private string gx(string v)
        {
            string text = "";

            string sql = "select * from db_gongxu where 图号='" + ZonglanTuhao + "' and 名称='"+ ZonglanMingcheng +"' and 工序顺序='" + v + "'";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            text = dt.Rows[0]["工序名称"].ToString() + ":" + "\r\n" + "负责人:" + dt.Rows[0]["负责人"].ToString() + "\r\n" + "开始时间:" + dt.Rows[0]["开始时间"].ToString() + "\r\n" + "结束时间:" + dt.Rows[0]["结束时间"].ToString() + "\r\n" + "工序内容:" + dt.Rows[0]["工序内容"].ToString();
            //text = dt.Rows[0]["工序名称"].ToString() + ":" + "\r\n" + "工序内容" + dt.Rows[0]["工序内容"].ToString();

            return text;
        }

    }
}
