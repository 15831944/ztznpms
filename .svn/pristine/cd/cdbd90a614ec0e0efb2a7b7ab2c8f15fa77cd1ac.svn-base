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

namespace ztznpms
{
    public partial class FormLogin : Form
    {

        FormMain form = new FormMain();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            string sql = "select * from db_operator";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["OperatorName"].ToString());
            }

            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("请输入密码！", "提示");
                return;
            }

            string sql = "select * from db_operator where OperatorName = '" + comboBox1.Text + "'";
            int result = Convert.ToInt32(SQLhelp.ExecuteScalar(sql, CommandType.Text));

            if(result > 0)
            {
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataRow row = dt.Rows[0];
                string a = row["Password"].ToString();
                string b = dt.Rows[0]["人员管理"].ToString();
                string c = dt.Rows[0]["项目管理"].ToString();
                string d = dt.Rows[0]["工序管理"].ToString();
                string f = dt.Rows[0]["图号查询"].ToString();
                string g = dt.Rows[0]["检验"].ToString();
                string h = dt.Rows[0]["扫码"].ToString();



                if (textBox1.Text.Trim() == a)
                {
                    form.xiangmuguanli = c;//项目管理
                    form.renyuanguanli = b;//人员管理
                    form.gongxuguanli = d;//工序管理
                    form.tuhaochaxun = f;//图号查询
                    form.jianyan = g;//检验
                    form.saoma = h;//扫码

                    MessageBox.Show("登陆成功！", "提示");
                    this.Hide();

                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("登录失败！", "提示");
                    textBox1.Text = string.Empty;
                }
            }

        }

        /// <summary>
        /// 密码重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sss = MessageBox.Show("请确认要退出本软件!", "提示", MessageBoxButtons.YesNo);
            if (sss == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
