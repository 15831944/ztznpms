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
    public partial class Formfenpici : DevExpress.XtraEditors.XtraForm
    {
        public string xuhao;
        public string leixing;

        public string zongshuliang;
        public string danjianjiage;
        public string zongjiage;

        public string yonghuming;

        public Formfenpici()
        {
            InitializeComponent();
        }

        private void Formfenpici_Load(object sender, EventArgs e)
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
            //textEdit2.Text = dr["工种"].ToString();
            txtmingcheng.Text = dr["名称"].ToString();
            txtxinghao.Text = dr["型号"].ToString();
            //txtzongshuliang.Text = dr["总数量"].ToString();
            //txtzongxinchou.Text = dr["总薪酬"].ToString();
            txtdanjainxinchou.Text = dr["单件薪酬"].ToString();

            txtgonglinghao.ReadOnly = true;
            txtxianmumingcheng.ReadOnly = true;
            txtshebei.ReadOnly = true;
            textEdit1.ReadOnly = true;
            //textEdit2.ReadOnly = true;
            txtmingcheng.ReadOnly = true;
            txtxinghao.ReadOnly = true;
            txtdanjainxinchou.ReadOnly = true;

            

        }


        private void txtren_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtren.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                    txtren.Text = chongxin;
                    this.txtren.SelectionStart = this.txtren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtren.Text.Substring(0, i + 1);

                    txtren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtren.SelectionStart = this.txtren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件
                }
            }
        }

        private void txtren_TextChanged(object sender, EventArgs e)
        {
            if (!txtren.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select name from db_man";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtren.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtren.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("name like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox1.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox1.Items.Add(newdtt.Rows[i]["name"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("name like'%" + txtren.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtren.Text != ""))
                {
                    listBox1.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["name"].ToString());//
                    }
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                }

            }

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtren.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                txtren.Text = chongxin;
                this.txtren.SelectionStart = this.txtren.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtren.Text.Substring(0, i + 1);

                txtren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                this.txtren.SelectionStart = this.txtren.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }

        /// <summary>
        /// 数量改变的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtzongshuliang_EditValueChanged(object sender, EventArgs e)
        {
            float shuliang = float.Parse(txtzongshuliang.Text);//输入的数量
            string sql1 = "select 审核数量 from db_jijiagongribao where id='"+ xuhao +"'";
            string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            if(ret11 == "")//没有审核数量
            {
                if(float.Parse(zongshuliang) < shuliang)
                {
                    MessageBox.Show("审核的数量不可以大于总数量！", "提示");
                }
                else
                {
                    float jiage1 = shuliang * float.Parse(danjianjiage);
                    txtzongxinchou.Text = jiage1.ToString();
                }
            }
            else
            {
                float ret1 = float.Parse(ret11);//已经审核的数量
                float keshenheshuliang = float.Parse(zongshuliang) - ret1;
                float shengyushuliang = float.Parse(zongshuliang) - (ret1 + shuliang);

                if (shengyushuliang < 0)
                {
                    MessageBox.Show("输入的数量和已经的审核的数量超过总数量！您最多可以再审核的数量为'" + keshenheshuliang + "'");
                }
                else
                {
                    float jiage2 = shuliang * float.Parse(danjianjiage);
                    txtzongxinchou.Text = jiage2.ToString();
                }
            }

            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            if(txtren.Text == "")
            {
                MessageBox.Show("请选择完成人！", "提示");
                return;
            }
            if(comgongzhong.Text.Trim() == "")
            {
                MessageBox.Show("请选择工种！", "提示");
                return;
            }

            float shuliang = float.Parse(txtzongshuliang.Text);//输入的数量

            string sql1 = "select 审核数量 from db_jijiagongribao where id='"+ xuhao +"'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1,CommandType.Text));
            if(ret1 == "")//审核数量为空
            {
                string sql2 = "update db_jijiagongribao set 审核数量='"+ shuliang +"' where id='"+ xuhao +"'";
                string ret2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));

                string sql3 = "select * from db_jijiagongribao where id='"+ xuhao +"'";
                DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
                DataRow row = dt3.Rows[0];

                string SQL1 = "insert into tb_yixianbaobiao (工作令号,项目名称,设备名称,完成日期,型号,名称,单件薪酬,总数量,工种,总薪酬,完成人,记录人,记录时间) values('" + row["工作令号"] + "','" + row["项目名称"] + "','" + row["设备名称"] + "','" + row["完成日期"] + "','" + row["型号"] + "','" + row["名称"] + "','" + row["单件薪酬"] + "','" + txtzongshuliang.Text + "','" + comgongzhong.Text.Trim() + "','" + txtzongxinchou.Text + "','" + txtren.Text.Trim() + "','" + yonghuming + "','" + time + "')";
                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery1(SQL1, CommandType.Text));
                if (RET1 != "")
                {
                    if(shuliang == float.Parse(zongshuliang))//输入数量=总数量
                    {
                        string SQL2 = "update db_jijiagongribao set 标记=1 where id='" + xuhao + "'";
                        string RET2 = Convert.ToString(SQLhelp.ExecuteNonquery(SQL2, CommandType.Text));
                        if (RET2 != "")
                        {
                            MessageBox.Show("分批确认成功！", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("分批确认成功！", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }


                }
            }
            else
            {
                float shenheshuliang = float.Parse(ret1);//已经审核的数量
                float zaicishenheshuliang = shenheshuliang + shuliang;

                string sql2 = "update db_jijiagongribao set 审核数量='" + zaicishenheshuliang + "' where id='" + xuhao + "'";
                string ret2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));

                string sql3 = "select * from db_jijiagongribao where id='" + xuhao + "'";
                DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
                DataRow row = dt3.Rows[0];

                string SQL1 = "insert into tb_yixianbaobiao (工作令号,项目名称,设备名称,完成日期,型号,名称,单件薪酬,总数量,工种,总薪酬,完成人,记录人,记录时间) values('" + row["工作令号"] + "','" + row["项目名称"] + "','" + row["设备名称"] + "','" + row["完成日期"] + "','" + row["型号"] + "','" + row["名称"] + "','" + row["单件薪酬"] + "','" + txtzongshuliang.Text + "','" + comgongzhong.Text.Trim() + "','" + txtzongxinchou.Text + "','" + txtren.Text.Trim() + "','" + yonghuming + "','" + time + "')";
                string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery1(SQL1, CommandType.Text));
                if (RET1 != "")
                {
                    if (zaicishenheshuliang == float.Parse(zongshuliang))//输入数量=总数量
                    {
                        string SQL2 = "update db_jijiagongribao set 标记=1 where id='" + xuhao + "'";
                        string RET2 = Convert.ToString(SQLhelp.ExecuteNonquery(SQL2, CommandType.Text));
                        if (RET2 != "")
                        {
                            MessageBox.Show("分批确认成功！", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("分批确认成功！", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }


                }

            }
        }

        private void txtzongshuliang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txtzongshuliang.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txtzongshuliang.Text, out oldf);

                    b2 = float.TryParse(txtzongshuliang.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void txtren_Validated(object sender, EventArgs e)
        {


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txtren.Text.Trim() == "")
            {
                MessageBox.Show("请输入完成人！", "提示");
                return;
            }
            else
            {
                string sql1 = "select 序号 from tb_operator where 用户名='" + txtren.Text.Trim() + "'";
                comgongzhong.Text = SQLhelp.ExecuteScalar2(sql1, CommandType.Text).ToString();
            }

        }


    }
}