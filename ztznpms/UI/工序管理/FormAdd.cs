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

namespace ztznpms.UI.工序管理
{
    public partial class FormAdd : Form
    {
        public string tagAdd;
        public FormAddmingchen MotherForm = new FormAddmingchen();
        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            if(tagAdd == "增加工序名称")
            {
                panel1.Visible = false;
            }
            if(tagAdd == "增加人员名字")
            {
                panel1.Visible = true;
            }
        }

        /// <summary>
        /// 保存添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入要添加的工序名称!", "提示");
                return;
            }

            string s3 = "select * from db_gongxumingcheng where 工序名称='"+ textBox1.Text.Trim() +"'";
            string r3 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

            if (r3 != "")
            {
                MessageBox.Show("该工序名称已存在！", "提示");
                textBox1.Text = "";
            }
            else
            {
                string s1 = "insert into db_gongxumingcheng(工序名称,科学单价) values('" + textBox1.Text.Trim() + "', '"+ textBox3.Text.Trim() +"')";
                string r1 = Convert.ToString(SQLhelp.ExecuteNonquery(s1, CommandType.Text));
                if (r1 != "")
                {
                    MessageBox.Show("新增工序成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入要添加的人员名字！", "提示");
                return;
            }
            if(textBox4.Text.Trim() == "")
            {
                MessageBox.Show("请输入要添加的员工编号！", "提示");
                return;
            }
            if(textBox5.Text.Trim() == "")
            {
                MessageBox.Show("请输入要添加的设备名称！", "提示");
                return;
            }

            string sql1 = "select * from db_chejianrenyuan where 机加车间人员='"+ textBox2.Text.Trim() + "'  and staffNumber='"+ textBox4.Text.Trim() +"' and 设备名='"+ textBox5.Text.Trim() +"'";
            string r1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            if(r1 != "")
            {
                MessageBox.Show("该员工已存在！", "提示");
                textBox2.Text = "";

            }
            else
            {
                string sql2 = "insert into db_chejianrenyuan(机加车间人员,staffNumber,设备名) values('" + textBox2.Text.Trim() +"', '"+ textBox4.Text.Trim() +"', '"+ textBox5.Text.Trim()+"')";
                string r2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));
                if(r2 != "")
                {
                    MessageBox.Show("新增车间人员成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
