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

namespace ztznpms.UI.项目管理
{
    public partial class Formxiugairibao : DevExpress.XtraEditors.XtraForm
    {
        public string xuhao;
        public string leixing;

        public string zongshuliang;
        public string danjianjiage;
        public string zongjiage;
        public Formxiugairibao()
        {
            InitializeComponent();

        }

        private void Formxiugairibao_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            string sql = "select * from db_jijiagongribao where id='" + xuhao + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            DataRow dr = dt.Rows[0];

            txtgonglinghao.Text = dr["工作令号"].ToString();
            txtxianmumingcheng.Text = dr["项目名称"].ToString();
            txtshebei.Text = dr["设备名称"].ToString();
            textEdit1.Text = dr["完成日期"].ToString();
            textEdit2.Text = dr["工种"].ToString();
            txtmingcheng.Text = dr["名称"].ToString();
            txtxinghao.Text = dr["型号"].ToString();
            txtzongshuliang.Text = dr["总数量"].ToString();
            txtzongxinchou.Text = dr["总薪酬"].ToString();
            txtdanjainxinchou.Text = dr["单件薪酬"].ToString();

            txtgonglinghao.ReadOnly = true;
            txtxianmumingcheng.ReadOnly = true;
            txtshebei.ReadOnly = true;
            textEdit1.ReadOnly = true;
            textEdit2.ReadOnly = true;
            txtmingcheng.ReadOnly = true;
            txtxinghao.ReadOnly = true;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string a = "";//记录总数量
            string b = "";//记录单件价格
            string c = "";//记录总价格
            string txt = "";//以前记录的内容
            string jilu = "";

            string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string SQL1 = "select 记录 from db_jijiagongribao where id='"+ xuhao +"' and 类型='"+ leixing +"'";
            txt = Convert.ToString(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

            if(zongshuliang != txtzongshuliang.Text)
            {
                a = time + "修改了总数量" + '(' + zongshuliang + ')';
            }
            if(danjianjiage != txtdanjainxinchou.Text)
            {
                b = time + "修改了单件薪酬" + '(' + danjianjiage + ')';
            }
            if(zongjiage != txtzongxinchou.Text)
            {
                c = time + "修改了总薪酬" + '(' + zongjiage + ')';
            }

            if (txt != "" && a != "" && b != "")
            {
                jilu = txt + '\n' + a + '\n' + b + '\n' + c;
            }
            if (txt != "" && a != "")
            {
                jilu = txt + '\n' + a + '\n' + b + c;
            }
            if (txt != "")
            {
                jilu = txt + '\n' + a + b + c;
            }

            if (a != "")
            {
                jilu = txt + a + '\n' + b + c;
            }
            if (a != "" && txt != "")
            {
                jilu = txt + '\n' + a + '\n' + b + c;
            }
            if (a != "" && txt != "" && b != "")
            {
                jilu = txt + '\n' + a + '\n' + b + '\n' + c;
            }

            if (b != "")
            {
                jilu = txt + a + b + '\n' + c;
            }
            if (b != "" && txt != "")
            {
                jilu = txt + '\n' + a + b + '\n' + c;
            }
            if (b != "" && txt != "" && a != "")
            {
                jilu = txt + '\n' + a + '\n' + b + '\n' + c;
            }

            if (c != "")
            {
                jilu = txt + a + b + c + '\n';
            }
            if (c != "" && txt != "")
            {
                jilu = txt + '\n' + a + b + c + '\n';
            }
            if (c != "" && txt != "" && a != "")
            {
                jilu = txt + '\n' + a + '\n' + b + c + '\n';
            }

            double jiage = Convert.ToDouble(txtzongxinchou.Text);
            double jiage1 = Convert.ToDouble(txtzongshuliang.Text) * Convert.ToDouble(txtdanjainxinchou.Text);
            if(jiage != jiage1)
            {
                MessageBox.Show("总薪酬计算有误！", "提示");
                return;
            }
            else
            {
                string sql = "update db_jijiagongribao set 总数量='" + txtzongshuliang.Text + "',单件薪酬='" + txtdanjainxinchou.Text + "',总薪酬='" + txtzongxinchou.Text + "',记录='" + jilu + "' where id='" + xuhao + "' and 类型='"+ leixing+"'";
                string ret = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));
                if(ret != "")
                {
                    MessageBox.Show("修改成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }

        private void txtdanjainxinchou_EditValueChanged(object sender, EventArgs e)
        {
            double shuliang = Convert.ToDouble(txtzongshuliang.Text);
            double danjia = Convert.ToDouble(txtdanjainxinchou.Text);
            double jiage = danjia * shuliang;
            txtzongxinchou.Text = jiage.ToString();
        }

        private void txtzongshuliang_EditValueChanged(object sender, EventArgs e)
        {
            //txtzongxinchou.Text = Convert.ToString(Convert.ToDouble(txtzongshuliang.Text) * Convert.ToDouble(txtdanjainxinchou.Text));
        }


    }
}