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
    public partial class Formcharugongxu : Form
    {

        public string xiangmumingcheng2;
        public string tuhao2;
        public string mingcheng2;
        public string gonglinghao2;
        public string shunxu2;
        public string shebeiming2;
        public string shuliang2;
        public string xuhao;

        public string tag;

        public string flag2;

        public string leixingmingcheng;

        string shijian1 = "08:00:00";//上班
        string shijian2 = "12:00:00";//开始休息----4小时
        string shijian3 = "13:00:00";//结束休息
        string shijian4 = "17:30:00";//开始休息----4.5小时
        string shijian5 = "18:00:00";//结束休息
        string shijian6 = "20:00:00";//下班    -----2小时------>一共10.5小时
        public Formcharugongxu()
        {
            InitializeComponent();
        }

        private void Formcharugongxu_Load(object sender, EventArgs e)
        {
            string s1 = "select * from db_chejianrenyuan";
            DataTable cr = SQLhelp.GetDataTable(s1, CommandType.Text);

            foreach (DataRow dr in cr.Rows)
            {
                //this.com_fuzeren.Items.Add(dr["机加车间人员"].ToString());

                string a = dr["机加车间人员"].ToString();
                if (com_fuzeren.Items.Cast<object>().All(x => x.ToString() != a))
                    com_fuzeren.Items.Add(a);
            }
          

            string s2 = "select * from db_gongxumingcheng";
            DataTable cr2 = SQLhelp.GetDataTable(s2, CommandType.Text);

            foreach (DataRow dr in cr2.Rows)
            {
                this.com_mingcheng.Items.Add(dr["工序名称"].ToString());
            }

            txt_xiangmumingcheng.Text = xiangmumingcheng2;
            txt_tuhao.Text = tuhao2;
            txt_mingcheng.Text = mingcheng2;
            txt_gonglinghao.Text = gonglinghao2;
            txt_shunxu.Text = shunxu2;
            txt_shebeiming.Text = shebeiming2;
            txt_shuliang.Text = shuliang2;

            //com_mingcheng.Enabled = false;
            //com_fuzeren.Enabled = false;
            btn_save.Enabled = false;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(flag2 == "自制加工")
            {
                DateTime time1 = DateTime.Now;
                string time2 = Convert.ToString(time1);

                if (com_mingcheng.Text.Trim() == "")
                {
                    MessageBox.Show("请输入工序名称！", "提示");
                    return;
                }
                if (com_shebeiming.Text.Trim() == "")
                {
                    MessageBox.Show("请选择设备！", "提示");
                    return;
                }
                if (txt_jiage.Text == "")
                {
                    txt_jiage.Text = "0";
                }
                //if (com_fuzeren.Text.Trim() == "")
                //{
                //    MessageBox.Show("请输入负责人！", "提示");
                //    return;
                //}
                //if (txt_neirong.Text == "")
                //{
                //    MessageBox.Show("请输入工序内容！", "提示");
                //    return;
                //}
                //if (txt_jiage.Text == "")
                //{
                //    MessageBox.Show("请输入工序价格!", "提示");
                //    return;
                //}

                if (tag == "选择")
                {
                    string charugongxu = time2 + "插入了工序";

                    string s5 = "update db_shunxu set 工序顺序 = 工序顺序 + 1 where 序号 = '" + xuhao + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                    string r5 = Convert.ToString(SQLhelp.ExecuteNonquery(s5, CommandType.Text));

                    string s6 = "insert into db_shunxu(项目名称,设备名称,图号,名称,工序名称,工序顺序,序号) values('"+ txt_xiangmumingcheng.Text +"','"+ txt_shebeiming.Text +"','" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + com_mingcheng.Text + "', '" + textBox1.Text + "','"+ xuhao +"')";
                    string r6 = Convert.ToString(SQLhelp.ExecuteNonquery(s6, CommandType.Text));

                    if(com_shebeiming.Text.Trim() != "")
                    {
                        string str1 = "update db_Paichan set 工序顺序=工序顺序+1 where 序号='" + xuhao + "' and 工序顺序 >='" + txt_shunxu.Text + "'";
                        SQLhelp.ExecuteNonquery(str1, CommandType.Text);

                        string str11 = "select 交货日期 from db_xiangmu where 序号='" + xuhao + "'";
                        string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(str11, CommandType.Text));

                        string str2 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_xiangmumingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text + "','" + txt_shuliang.Text + "','" + txt_jiage.Text + "','" + xuhao + "','" + com_shebeiming.Text + "','" + textBox1.Text + "','" + com_mingcheng.Text + "','" + time1 + "','"+ com_fuzeren.Text +"','" + txt_mingcheng.Text + "','项目','" + ret11 + "')";
                        SQLhelp.ExecuteNonquery(str2, CommandType.Text);
                    }

                    string s1 = "update db_gongxu1 set 工序顺序 = 工序顺序 + 1 where 序号 = '" + xuhao + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                    int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                    //插入的工序为第一道工序
                    if(textBox1.Text.Trim() == "1")
                    {
                        string s2 = "insert into db_gongxu1(项目名称,图号,名称,工作令号,设备名称,数量,工序名称,工序顺序,工序内容,负责人,标记,价格,序号,材料,重量,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text.Trim() + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + textBox1.Text + "', '" + txt_neirong.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu + "','" + txt_jiage.Text + "','" + xuhao + "','" + txt_cailiao.Text + "','" + txt_zhongliang.Text + "','"+ time1 +"','" + txt_zhuyidian.Text + "','" + com_shebeiming.Text + "','0','显示','"+ leixingmingcheng +"')";
                        int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                        string s3 = "update db_gongxu1 set label='不显示' where 序号='"+ xuhao +"' and 工序顺序 > '"+ txt_shunxu.Text +"'";
                        SQLhelp.ExecuteNonquery(s3, CommandType.Text);


                        string ss5 = "select 工序名称,工序顺序 from db_gongxu1 where 序号='" + xuhao + "' order by 工序顺序 asc";
                        DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);
                        for (int i = 0; i < dt5.Rows.Count; i++)
                        {
                            DataRow dr = dt5.Rows[i];
                            string gongxu1 = "工序" + (i + 1).ToString();
                            string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao + "'";
                            SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                        }

                        if (r2 > 0)
                        {
                            MessageBox.Show("插入工序成功!", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("插入工序失败！", "提示");
                        }
                    }
                    //插入的工序不是第一道工序
                    if(textBox1.Text.Trim() != "1")
                    {
                        string s2 = "insert into db_gongxu1(项目名称,图号,名称,工作令号,设备名称,数量,工序名称,工序顺序,工序内容,负责人,标记,价格,序号,材料,重量,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text.Trim() + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + textBox1.Text + "', '" + txt_neirong.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu + "','" + txt_jiage.Text + "','" + xuhao + "','" + txt_cailiao.Text + "','" + txt_zhongliang.Text + "','"+ time1 +"','" + txt_zhuyidian.Text + "','" + com_shebeiming.Text + "','0','不显示','"+ leixingmingcheng +"')";
                        int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                        string ss5 = "select 工序名称,工序顺序 from db_gongxu1 where 序号='" + xuhao + "' order by 工序顺序 asc";
                        DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);
                        for (int i = 0; i < dt5.Rows.Count; i++)
                        {
                            DataRow dr = dt5.Rows[i];
                            string gongxu1 = "工序" + (i + 1).ToString();
                            string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao + "'";
                            SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                        }

                        if (r2 > 0)
                        {
                            MessageBox.Show("插入工序成功!", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("插入工序失败！", "提示");
                        }
                    }

                }

                if (tag == "最后")
                {
                    string charugongxu2 = time2 + "插入了工序";

                    string s3 = "select max(工序顺序)from db_gongxu1 where 图号 = '" + tuhao2 + "' and 序号='"+ xuhao +"'";
                    int r3 = Convert.ToInt32(SQLhelp.ExecuteScalar(s3, CommandType.Text));
                    int gongxushunxu = r3 + 1;

                    string s7 = "insert into db_shunxu(项目名称,设备名称,图号,名称,工序名称,工序顺序,序号) values('" + txt_xiangmumingcheng.Text + "','" + txt_shebeiming.Text + "','" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + com_mingcheng.Text + "', '" + gongxushunxu + "','"+ xuhao +"')";
                    string r7 = Convert.ToString(SQLhelp.ExecuteNonquery(s7, CommandType.Text));

                    if (com_shebeiming.Text.Trim() != "")
                    {
                        string str11 = "select 交货日期 from db_xiangmu where 序号='" + xuhao + "'";
                        string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(str11, CommandType.Text));

                        string str2 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_xiangmumingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text + "','" + txt_shuliang.Text + "','" + txt_jiage.Text + "','" + xuhao + "','" + com_shebeiming.Text + "','" + gongxushunxu + "','" + com_mingcheng.Text + "','" + time1 + "','" + com_fuzeren.Text + "','" + txt_mingcheng.Text + "','项目','" + ret11 + "')";
                        SQLhelp.ExecuteNonquery(str2, CommandType.Text);
                    }


                    string s4 = "insert into db_gongxu1(项目名称,图号,名称,工作令号,设备名称,数量,工序名称,工序顺序,工序内容,负责人,标记,价格,序号,材料,重量,工艺制定时间,工艺注意点,工序设备,状态,label,类型) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text.Trim() + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + gongxushunxu + "', '" + txt_neirong.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu2 + "','" + txt_jiage.Text + "','"+ xuhao +"','"+ txt_cailiao.Text +"','"+ txt_zhongliang.Text +"','"+ time1 +"','"+ txt_zhuyidian.Text +"','"+ com_shebeiming.Text +"','0','不显示','"+ leixingmingcheng +"')";
                    int r4 = SQLhelp.ExecuteNonquery(s4, CommandType.Text);

                    string s5 = "select 工序名称,工序顺序 from db_gongxu1 where 序号='"+ xuhao + "' order by 工序顺序 asc";
                    DataTable dt5 = SQLhelp.GetDataTable(s5, CommandType.Text);
                    for (int i = 0; i < dt5.Rows.Count; i++)
                    {
                        DataRow dr = dt5.Rows[i];
                        string gongxu1 = "工序" + (i + 1).ToString();
                        string s6 = "update db_xiangmu set  "+ gongxu1 +" = '"+ dr["工序名称"]+"' where 序号='"+ xuhao +"'";
                        SQLhelp.ExecuteNonquery(s6, CommandType.Text);
                    }

                    if (r4 > 0)
                    {
                        MessageBox.Show("插入工序成功！", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("插入工序失败！", "提示");
                    }
                }

                string SQL1 = "select * from db_gongxu1 where 序号='" + xuhao + "' order by 工序顺序 asc";
                DataTable table = SQLhelp.GetDataTable(SQL1, CommandType.Text);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow dr = table.Rows[i];

                    string gongxstr = dr["工序名称"].ToString() + dr["结束时间"].ToString();
                    string SQL2 = "update db_xiangmu set 工序" + (i + 1) + "='" + gongxstr + "' where 序号='" + xuhao + "'";
                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                }

                string SQL3 = "select max(工序顺序) from db_gongxu1 where 序号='" + xuhao + "'";
                string RET3 = Convert.ToString(SQLhelp.ExecuteScalar(SQL3, CommandType.Text));
                if (RET3 != "")
                {
                    int shun3 = Convert.ToInt32(RET3);
                    for (int i = shun3 + 1; i <= 25; i++)
                    {
                        string SQL13 = "update db_xiangmu set 工序" + i + "=NULL where 序号='" + xuhao + "'";
                        SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                    }

                }
                else//全删除了
                {
                    for (int i = 1; i <= 25; i++)
                    {
                        string SQL13 = "update db_xiangmu set 工序" + i + "=NULL where 序号='" + xuhao + "'";
                        SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                    }

                }

            }
            if(flag2 == "技术更改")
            {
                DateTime time1 = DateTime.Now;
                string time2 = Convert.ToString(time1);

                if (com_mingcheng.Text.Trim() == "")
                {
                    MessageBox.Show("请输入工序名称！", "提示");
                    return;
                }
                //if (com_fuzeren.Text.Trim() == "")
                //{
                //    MessageBox.Show("请输入工序负责人！", "提示");
                //    return;
                //}
                //if (txt_neirong.Text == "")
                //{
                //    MessageBox.Show("请输入工序内容！", "提示");
                //    return;
                //}
                //if (txt_jiage.Text == "")
                //{
                //    MessageBox.Show("请输入工序价格!", "提示");
                //    return;
                //}

                if (tag == "选择")
                {
                    string charugongxu = time2 + "插入了工序";

                    string s5 = "update db_shunxu11 set 工序顺序 = 工序顺序 + 1 where 序号='"+ xuhao +"' and 图号 = '" + txt_tuhao.Text + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                    string r5 = Convert.ToString(SQLhelp.ExecuteNonquery(s5, CommandType.Text));

                    string s6 = "insert into db_shunxu11(项目名称,设备名称,图号,名称,工序名称,工序顺序,序号) values('" + txt_xiangmumingcheng.Text + "','" + txt_shebeiming.Text + "','" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + com_mingcheng.Text + "', '" + textBox1.Text + "','"+ xuhao +"')";
                    string r6 = Convert.ToString(SQLhelp.ExecuteNonquery(s6, CommandType.Text));

                    if (com_shebeiming.Text.Trim() != "")
                    {
                        string str1 = "update db_Paichan set 工序顺序=工序顺序+1 where 序号='" + xuhao + "' and 工序顺序 >='" + txt_shunxu.Text + "'";
                        SQLhelp.ExecuteNonquery(str1, CommandType.Text);

                        string str11 = "select 交货日期 from db_xiangmu where 序号='" + xuhao + "'";
                        string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(str11, CommandType.Text));

                        string str2 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_xiangmumingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text + "','" + txt_shuliang.Text + "','" + txt_jiage.Text + "','" + xuhao + "','" + com_shebeiming.Text + "','" + textBox1.Text + "','" + com_mingcheng.Text + "','" + time1 + "','" + com_fuzeren.Text + "','" + txt_mingcheng.Text + "','技术更改','" + ret11 + "')";
                        SQLhelp.ExecuteNonquery(str2, CommandType.Text);
                    }

                    string s1 = "update db_gongxu11 set 工序顺序 = 工序顺序 + 1 where 序号='"+ xuhao +"' and 名称 = '" + txt_mingcheng.Text + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                    int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                    //插入的工序为第一道工序
                    if (textBox1.Text.Trim() == "1")
                    {
                        string s2 = "insert into db_gongxu11(项目名称,图号,名称,工作令号,设备名称,数量,工序名称,工序顺序,工序内容,负责人,标记,价格,序号,材料,重量,工艺制定时间,工艺注意点,工序设备,状态,label) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text.Trim() + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + textBox1.Text + "', '" + txt_neirong.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu + "','" + txt_jiage.Text + "','" + xuhao + "','" + txt_cailiao.Text + "','" + txt_zhongliang.Text + "','"+ time1 +"','" + txt_zhuyidian.Text + "','" + com_shebeiming.Text + "','0','显示')";
                        int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                        string s3 = "update db_gongxu11 set label='不显示' where 序号='" + xuhao + "' and 工序顺序 > '" + txt_shunxu.Text + "'";
                        SQLhelp.ExecuteNonquery(s3, CommandType.Text);

                        string ss5 = "select 工序名称,工序顺序 from db_gongxu11 where 序号='" + xuhao + "' order by 工序顺序 asc";
                        DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);
                        for (int i = 0; i < dt5.Rows.Count; i++)
                        {
                            DataRow dr = dt5.Rows[i];
                            string gongxu1 = "工序" + (i + 1).ToString();
                            string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao + "'";
                            SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                        }

                        if (r2 > 0)
                        {
                            MessageBox.Show("插入工序成功!", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("插入工序失败！", "提示");
                        }
                    }
                    //插入的工序不是第一道工序
                    if (textBox1.Text.Trim() != "1")
                    {
                        string s2 = "insert into db_gongxu11(项目名称,图号,名称,工作令号,设备名称,数量,工序名称,工序顺序,工序内容,负责人,标记,价格,序号,材料,重量,工艺制定时间,工艺注意点,工序设备,状态,label) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text.Trim() + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + textBox1.Text + "', '" + txt_neirong.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu + "','" + txt_jiage.Text + "','" + xuhao + "','" + txt_cailiao.Text + "','" + txt_zhongliang.Text + "','"+ time1 +"','" + txt_zhuyidian.Text + "','" + com_shebeiming.Text + "','0','不显示')";
                        int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                        string ss5 = "select 工序名称,工序顺序 from db_gongxu11 where 序号='" + xuhao + "' order by 工序顺序 asc";
                        DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);
                        for (int i = 0; i < dt5.Rows.Count; i++)
                        {
                            DataRow dr = dt5.Rows[i];
                            string gongxu1 = "工序" + (i + 1).ToString();
                            string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao + "'";
                            SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                        }

                        if (r2 > 0)
                        {
                            MessageBox.Show("插入工序成功!", "提示");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("插入工序失败！", "提示");
                        }
                    }
                }

                if (tag == "最后")
                {
                    string charugongxu2 = time2 + "插入了工序";

                    string s3 = "select max(工序顺序)from db_gongxu11 where 序号='"+ xuhao +"' and 图号 = '" + tuhao2 + "'";
                    int r3 = Convert.ToInt32(SQLhelp.ExecuteScalar(s3, CommandType.Text));
                    int gongxushunxu = r3 + 1;

                    string s7 = "insert into db_shunxu11(项目名称,设备名称,图号,名称,工序名称,工序顺序,序号) values('" + txt_xiangmumingcheng.Text + "','" + txt_shebeiming.Text + "','" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + com_mingcheng.Text + "', '" + gongxushunxu + "','"+ xuhao +"')";
                    string r7 = Convert.ToString(SQLhelp.ExecuteNonquery(s7, CommandType.Text));


                    if (com_shebeiming.Text.Trim() != "")
                    {
                        string str11 = "select 交货日期 from db_xiangmu where 序号='" + xuhao + "'";
                        string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(str11, CommandType.Text));

                        string str2 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_xiangmumingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text + "','" + txt_shuliang.Text + "','" + txt_jiage.Text + "','" + xuhao + "','" + com_shebeiming.Text + "','" + gongxushunxu + "','" + com_mingcheng.Text + "','" + time1 + "','" + com_fuzeren.Text + "','" + txt_mingcheng.Text + "','项目','" + ret11 + "')";
                        SQLhelp.ExecuteNonquery(str2, CommandType.Text);
                    }


                    string s4 = "insert into db_gongxu11(项目名称,图号,名称,工作令号,设备名称,数量,工序名称,工序顺序,工序内容,负责人,标记,价格,序号,材料,重量,工艺制定时间,工艺注意点,工序设备,状态,label) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shebeiming.Text.Trim() + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + gongxushunxu + "', '" + txt_neirong.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu2 + "','" + txt_jiage.Text + "','"+ xuhao +"','"+ txt_cailiao.Text +"','"+ txt_zhongliang.Text +"','"+ time1 +"','"+ txt_zhuyidian.Text +"','"+ com_shebeiming.Text +"','0','不显示')";
                    int r4 = SQLhelp.ExecuteNonquery(s4, CommandType.Text);

                    string ss5 = "select 工序名称,工序顺序 from db_gongxu11 where 序号='" + xuhao + "' order by 工序顺序 asc";
                    DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);
                    for (int i = 0; i < dt5.Rows.Count; i++)
                    {
                        DataRow dr = dt5.Rows[i];
                        string gongxu1 = "工序" + (i + 1).ToString();
                        string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao + "'";
                        SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                    }

                    if (r4 > 0)
                    {
                        MessageBox.Show("插入工序成功！", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("插入工序失败！", "提示");
                    }
                }
            }
            

        }

        /// <summary>
        /// 选择插入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_xuanze1_CheckedChanged(object sender, EventArgs e)
        {
            if(rbt_xuanze1.Checked == true)
            {
                textBox1.Text = "";
                btn_save.Enabled = true;
            }
            int a = Convert.ToInt32(txt_shunxu.Text);//当前的工序顺序
            //a=1,2,3,4...
            
                int b = a;//选择插入时，插入的工序为当前顺序
                string c = Convert.ToString(b);
                textBox1.Text = c;

            tag = "选择";
        }

        /// <summary>
        /// 插入到最后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_zuihou_CheckedChanged(object sender, EventArgs e)
        {
            if(rbt_zuihou.Checked == true)
            {
                textBox1.Text = "";
                btn_save.Enabled = true;
            }

            tag = "最后";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void com_shebeiming_Click(object sender, EventArgs e)
        {
            com_shebeiming.Text = "";
            com_shebeiming.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + com_fuzeren.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (com_shebeiming.Items.Cast<object>().All(x => x.ToString() != a))
                        com_shebeiming.Items.Add(a);
                    com_shebeiming.SelectedIndex = 0;
                }
            }
        }



        /// <summary>
        /// 数控设备排产-----12小时制
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        private void paichan2(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTimePicker picker1, DateTimePicker picker2)
        {
            DateTime time1 = DateTime.Now;//日期+时分秒（当前）

            string sql1 = "select 设定开始时间 from db_gongxu1 where 工序设备='" + shebei + "'";
            string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            #region 设备空闲中
            if (ret1 == "")//设备空闲中
            {
                //算总的工时
                double price = Convert.ToDouble(jiage);
                price = price * (Convert.ToInt32(shuliang));
                double t = (double)price / 27;
                double flag = t / 10.5;
                int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);


                int ta1 = shijian1.CompareTo(time1time);

                if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                    {
                        picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                    {
                        picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                    }

                }

                //当前时间大于8:00 小于12:00
                int ta3 = time1time.CompareTo(shijian1);
                int ta4 = shijian2.CompareTo(time1time);
                if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                {

                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    TimeSpan a = Time22 - strtime;//上午加工的时间
                    if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    {

                        double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                        if (tt <= 4)//下午做完
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                        }
                        if (4 < tt && tt <= 6.5)//晚上做完
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                        }
                        if (tt >= 6.5)//第二天上午做完
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                int ta6 = time1time.CompareTo(shijian2);
                int ta7 = shijian3.CompareTo(time1time);

                if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)//下午完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (10.5 * at + 4 < t && t <= 10.5 * at + 6.5)//晚上完成
                    {
                        picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (10.5 * at + 6.5 < t && t <= 10.5 * at + 10.5)//第二天上午完成
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                    }

                }

                //当前时间大于13:00 小于17:30
                int ta9 = time1time.CompareTo(shijian3);
                int ta10 = shijian4.CompareTo(time1time);

                if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                    DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                    TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                    if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                    {

                        double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                        if (ttzhi <= 2)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                        }
                        if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                        }
                        if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                        }

                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }

                }

                //当前时间大于17:30 小于18:00
                int ta12 = time1time.CompareTo(shijian4);
                int ta13 = shijian5.CompareTo(time1time);

                if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                    }
                    if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                    }

                }

                //当前时间大于18:00 小于20:00
                int ta14 = time1time.CompareTo(shijian5);
                int ta15 = shijian6.CompareTo(time1time);

                if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1.Value = Convert.ToDateTime(strtime);
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                    if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                    {
                        double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                        if (t2 <= 4)//第二天上午可以完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                        }
                        if (4 < t && t <= 8.5)//第二天下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                        }
                        if (8.5 < t && t <= 10.5)//第二天晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                        }
                    }
                    else
                    {
                        picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于20:00
                //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                int ta16 = time1time.CompareTo(shijian6);

                if (ta16 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1.Value = strtime1.AddDays(1);

                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)
                    {
                        picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                    {
                        picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                    {
                        picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                    }
                }


            }
            #endregion

            #region 设备不空闲
            else
            {
                string sql2 = "select max(设定开始时间) from db_gongxu1 where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select 设定结束时间 from db_gongxu1 where 工序设备='" + shebei + "' and 设定开始时间='" + ret2 + "'";//最大的设定开始时间对应的结束事假，结束时间就是当前时间
                DateTime ret3 = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                if (ret3 < time1)//设定结束时间 < 现在的时间 （最大的结束时间小于现在的时间也就是没有任务了）---空闲了
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    //算总的工时
                    double price = Convert.ToDouble(jiage);
                    price = price * (Convert.ToInt32(shuliang));
                    double t = (double)price / 27;
                    double flag = t / 10.5;
                    int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                    int ta1 = shijian1.CompareTo(time1time);

                    if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                        {
                            picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于8:00 小于12:00
                    int ta3 = time1time.CompareTo(shijian1);
                    int ta4 = shijian2.CompareTo(time1time);
                    if (ta3 == 1 && ta4 == 1)
                    {

                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                        if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        {

                            double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                            if (tt <= 4)//下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                            }
                            if (4 < tt && tt <= 6.5)//晚上做完
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                            }
                            if (tt >= 6.5)//第二天上午做完
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    int ta6 = time1time.CompareTo(shijian2);
                    int ta7 = shijian3.CompareTo(time1time);

                    if (ta6 == 1 && ta7 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于13:00 小于17:30
                    int ta9 = time1time.CompareTo(shijian3);
                    int ta10 = shijian4.CompareTo(time1time);

                    if (ta9 == 1 && ta10 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                        DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                        TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                        if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                        {

                            double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                            if (ttzhi <= 2)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                            }
                            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                            }
                            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                            }

                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }

                    }

                    //当前时间大于17:30 小于18:00
                    int ta12 = time1time.CompareTo(shijian4);
                    int ta13 = shijian5.CompareTo(time1time);

                    if (ta12 == 1 && ta13 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                        }
                        if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                        }

                    }

                    //当前时间大于18:00 小于20:00
                    int ta14 = time1time.CompareTo(shijian5);
                    int ta15 = shijian6.CompareTo(time1time);

                    if (ta14 == 1 && ta15 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1.Value = Convert.ToDateTime(strtime);
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                        if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                        {
                            double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                            if (t2 <= 4)//第二天上午可以完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                            }
                            if (4 < t && t <= 8.5)//第二天下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                            }
                            if (8.5 < t && t <= 10.5)//第二天晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                            }
                        }
                        else
                        {
                            picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于20:00
                    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    int ta16 = time1time.CompareTo(shijian6);

                    if (ta16 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1.Value = strtime1.AddDays(1);

                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)
                        {
                            picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                        {
                            picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                        {
                            picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                        }
                    }


                }
                else//(设定结束时间 > 现在的时间（用设定结束时间算）)----将设定结束时间当做现在时间算  ret3---结束时间
                {
                    DateTime time = Convert.ToDateTime(time1date1 + " " + time1time);//time:工序1是当前时间 工序2-25是前面的时间

                    if (ret3 >= time)//---------ret3 > datetimepicker(用ret3date1和ret3time)
                    {

                        string ret3date = ret3.ToString("yyyy/MM/dd");
                        string ret3time = ret3.ToString("HH:mm:ss");
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 10.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        int ta1 = shijian1.CompareTo(time1time);

                        if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - ret3.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+12:30
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00                                
                            DateTime Time44 = Convert.ToDateTime(ret3date + " " + shijian4);//日期 + 17:30

                            TimeSpan tzhi = Time44.AddDays(at) - ret3.AddDays(at);//下午工作的时间
                            if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                            {

                                double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= 2)//晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1.Value = Convert.ToDateTime(ret3);
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - ret3.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t && t <= 8.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t && t <= 10.5)//第二天晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2.Value = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1.Value = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }


                       
                    }
                    else//-----------------ret3 < datetimepicker(用time1date和time1time)----time
                    {
                        //算总的工时
                        double price = Convert.ToDouble(jiage);
                        price = price * (Convert.ToInt32(shuliang));
                        double t = (double)price / 27;
                        double flag = t / 10.5;
                        int at = Convert.ToInt32(flag.ToString().Split(char.Parse("."))[0]);

                        int ta1 = shijian1.CompareTo(time1time);

                        if (ta1 == 1 || ta1 == 0)//当前时间小于8:00 (Time1>time1time)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2.Value = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2.Value = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+12:30
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00                                
                            DateTime Time44 = Convert.ToDateTime(time1date1 + " " + shijian4);//日期 + 17:30

                            TimeSpan tzhi = Time44.AddDays(at) - strtime.AddDays(at);//下午工作的时间
                            if (t - 10.5 * at > tzhi.TotalHours)//第二天下午做不完
                            {

                                double ttzhi = t - 10.5 * at - tzhi.TotalHours;//剩余加工的时间
                                if (ttzhi <= 2)//晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 10.5 * at + 2)//晚上完成
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1.Value = Convert.ToDateTime(strtime);
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2.Value = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t && t <= 8.5)//第二天下午完成
                                {
                                    picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t && t <= 10.5)//第二天晚上完成
                                {
                                    picker2.Value = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2.Value = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1.Value = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2.Value = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2.Value = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2.Value = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }


                    }
                }

            }
            #endregion
        }
    }
}
