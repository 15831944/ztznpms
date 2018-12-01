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

namespace ztznpms.UI.人员管理
{
    public partial class FormAddPeople : Form
    { 
        public string tag;
        public string operatorname;

        //public FormPeople MotherForm = new FormPeople();


        public FormAddPeople()
        {
            InitializeComponent();
        }

        private void FormAddPeople_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            if(tag == "add")
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                rbtn_renyuan.Checked = false;
                rbtn_xiangmu.Checked = false;
                rbtn_gongxu.Checked = false;
                rbtn_ckxm.Checked = false;
                rbtn_ckgx.Checked = false;
                rbnt_sm.Checked = false;
                rbtn_thcx.Checked = false;
                rbtn_jy.Checked = false;
            }
            if(tag == "update")
            {
                textBox1.ReadOnly = true;
                textBox1.Text = operatorname;
            }
        }

        /// <summary>
        /// 保存增加的人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {

            int aa = 0;//人员管理
            int bb = 0;//项目管理
            int cc = 0;//工序管理
            int dd = 0;//查看项目
            int ff = 0;//查看工序
            int gg = 0;//图号查询
            int hh = 0;//检验
            int ii = 0;//扫码

            if (tag == "add")
            {


                if (rbtn_renyuan.Checked == true)
                {
                    aa = 1;
                }
                if(rbtn_xiangmu.Checked == true)
                {
                    bb = 1;
                }
                if(rbtn_gongxu.Checked == true)
                {
                    cc = 1;
                }
                if(rbtn_ckxm.Checked == true)
                {
                    dd = 1;
                }
                if(rbtn_ckgx.Checked == true)
                {
                    ff = 1;
                }
                if(rbnt_sm.Checked == true)
                {
                    ii = 1;
                }
                if(rbtn_jy.Checked == true)
                {
                    hh = 1;
                }
                if(rbtn_thcx.Checked == true)
                {
                    gg = 1;
                }

                if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    MessageBox.Show("用户名不允许为空！", "提示");
                    return;
                }
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("操作密码不允许为空！", "提示");
                    return;
                }
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次输入的密码不一致", "提示");
                    return;
                }
                else
                {
                    string sql = "select * from db_operator where OperatorName = '" + textBox1.Text.Trim() + "'";
                    string result = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
                    if (result != "")
                    {
                        MessageBox.Show("该用户名已存在！", "提示");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        rbtn_renyuan.Checked = false;
                        rbtn_ckgx.Checked = false;
                        rbtn_ckxm.Checked = false;
                        rbtn_gongxu.Checked = false;
                        rbtn_xiangmu.Checked = false;
                        rbtn_thcx.Checked = false;
                        rbtn_jy.Checked = false;
                        rbnt_sm.Checked = false;
                        return;
                    }
                    else
                    {
                        string sql1 = "insert into db_operator(OperatorName,Password,人员管理,项目管理,工序管理,图号查询,检验,查看项目,查看工序,扫码) values('" + textBox1.Text.Trim() + "', '" + textBox2.Text + "', '" + aa + "', '" + bb + "', '" + cc + "', '"+ gg +"','"+ hh +"','" + dd + "', '" + ff + "','"+ ii +"')";
                        int result1 = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));

                        if(result1 > 0)
                        {
                            MessageBox.Show("增加用户成功！", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("保存失败！", "提示");
                        }
                    }
                }

            }
            

            if(tag == "update")
            {
                if(rbtn_renyuan.Checked == true)
                {
                    aa = 1;
                }
                if (rbtn_xiangmu.Checked == true)
                {
                    bb = 1;
                }
                if (rbtn_gongxu.Checked == true)
                {
                    cc = 1;
                }
                if (rbtn_ckxm.Checked == true)
                {
                    dd = 1;
                }
                if (rbtn_ckgx.Checked == true)
                {
                    ff = 1;
                }
                if (rbnt_sm.Checked == true)
                {
                    ii = 1;
                }
                if (rbtn_jy.Checked == true)
                {
                    hh = 1;
                }
                if (rbtn_thcx.Checked == true)
                {
                    gg = 1;
                }

                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("操作密码不允许为空!", "提示");
                    return;
                }
                if(textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次输入的密码不一致!", "提示");
                    return;
                }
                else
                {
                    string sql3 = "update db_operator set Password = '" + textBox2.Text + "', 人员管理='" + aa + "', 项目管理='" + bb + "',工序管理='"+ cc +"', 查看项目='"+ dd +"',查看工序='"+ ff +"',图号查询='"+ gg +"',检验='"+ hh +"',扫码='"+ ii +"' where OperatorName = '" + textBox1.Text.Trim() + "'";
                    int result2 = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql3, CommandType.Text));

                    if(result2 > 0)
                    {
                        MessageBox.Show("修改成功！", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("修改失败！", "提示");
                    }
                }
            }

        }

        /// <summary>
        /// 取消保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
