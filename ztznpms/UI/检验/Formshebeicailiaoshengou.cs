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

namespace ztznpms.UI.检验
{
    public partial class Formshebeicailiaoshengou : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public string gonglinghao;
        public string shebeimingcheng;
        public string shijian;

        public string xuhaocailiao;

        public string liaodanleiixng;

        public string dingweishu;
        
        public Formshebeicailiaoshengou()
        {
            InitializeComponent();
        }

        private void Formshebeicailiaoshengou_Load(object sender, EventArgs e)
        {
            reload();
            DrawRowIndicator(gridView1, 40);
        }

        private void reload()
        {
            if(liaodanleiixng == "机修件零件")
            {
                string sql = "select * from db_caigoucailiao where 序号='"+ xuhaocailiao +"' and 料单类型='" + liaodanleiixng + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                gridControl1.DataSource = dt;
            }
            if(liaodanleiixng == "机修件组件")
            {

                string sql = "select * from db_caigoucailiao where 组件定位='" + dingweishu + "' and 料单类型='" + liaodanleiixng + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                gridControl1.DataSource = dt;
            }
            if(liaodanleiixng == "项目")
            {
                string sql = "select * from db_caigoucailiao where 工作令号='" + gonglinghao + "' and 设备名称='" + shebeimingcheng + "' and time='" + shijian + "' and 料单类型='" + liaodanleiixng + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                gridControl1.DataSource = dt;
            }

        }


        private void 采购申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(liaodanleiixng == "机修件零件")
            {
                int[] a = gridView1.GetSelectedRows();
                foreach (int i in a)
                {
                    DataRow dr = this.gridView1.GetDataRow(i);//遍历每行
                    string str1 = Convert.ToString(dr["申购情况"]);//当前行数量
                    if (str1 == "已经申购")
                    {
                        MessageBox.Show("第" + (i + 1) + "行已经申购原材料！", "提示");
                        return;
                    }
                }

                DataTable dt = new DataTable();
                DataTable biaoge = new DataTable();

                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("项目名称", typeof(string));
                dt.Columns.Add("设备名称", typeof(string));
                dt.Columns.Add("工作令号", typeof(string));
                dt.Columns.Add("图号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("材料名称", typeof(string));
                dt.Columns.Add("型号", typeof(string));
                dt.Columns.Add("编码", typeof(string));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("数量", typeof(float));
                dt.Columns.Add("类型", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                dt.Columns.Add("要求到货日期", typeof(DateTime));

                string[] b = new string[a.Length];

                foreach (int i in a)
                {

                    DataRow dr = dt.NewRow();

                    string id = gridView1.GetRowCellValue(i, "id").ToString();
                    string caigouxiangmuming = gridView1.GetRowCellValue(i, "项目名称").ToString();
                    string caigoushebeiming = gridView1.GetRowCellValue(i, "设备名称").ToString();
                    string caigougongzuolinghao = gridView1.GetRowCellValue(i, "工作令号").ToString();
                    string caigoutuhao = gridView1.GetRowCellValue(i, "图号").ToString();
                    string caigoumingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                    string caigoucailiaoming = gridView1.GetRowCellValue(i, "材料名称").ToString();
                    string caigouxinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                    string caigoubianma = gridView1.GetRowCellValue(i, "编码").ToString();
                    string caigoudanwei = gridView1.GetRowCellValue(i, "单位").ToString();
                    string caigoushuliang = gridView1.GetRowCellValue(i, "总重量").ToString();
                    string caigouleixing = gridView1.GetRowCellValue(i, "类型").ToString();
                    string caigoubeizhu = gridView1.GetRowCellValue(i, "备注").ToString();
                    string caigouriqi = gridView1.GetRowCellValue(i, "要求到货日期").ToString();

                    dr["id"] = id;
                    dr["项目名称"] = caigouxiangmuming;
                    dr["设备名称"] = caigoushebeiming;
                    dr["工作令号"] = caigougongzuolinghao;
                    dr["图号"] = caigoutuhao;
                    dr["名称"] = caigoumingcheng;
                    dr["材料名称"] = caigoucailiaoming;
                    dr["型号"] = caigouxinghao;
                    dr["编码"] = caigoubianma;
                    dr["单位"] = caigoudanwei;
                    dr["数量"] = caigoushuliang;
                    dr["类型"] = caigouleixing;
                    dr["备注"] = caigoubeizhu;
                    dr["要求到货日期"] = caigouriqi;

                    dt.Rows.Add(dr);

                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    b[i] = dr["id"].ToString();
                }

                List<string> list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)//遍历数组成员
                {
                    if (dt.Rows[i]["编码"].ToString() != "")
                    {
                        if (list.IndexOf(dt.Rows[i]["编码"].ToString()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                            list.Add(dt.Rows[i]["编码"].ToString());
                    }
                }

                biaoge.Columns.Add("项目名称", typeof(string));
                biaoge.Columns.Add("设备名称", typeof(string));
                biaoge.Columns.Add("工作令号", typeof(string));
                biaoge.Columns.Add("图号", typeof(string));
                biaoge.Columns.Add("名称", typeof(string));
                biaoge.Columns.Add("材料名称", typeof(string));
                biaoge.Columns.Add("型号", typeof(string));
                biaoge.Columns.Add("编码", typeof(string));
                biaoge.Columns.Add("单位", typeof(string));
                biaoge.Columns.Add("数量", typeof(float));
                biaoge.Columns.Add("类型", typeof(string));
                biaoge.Columns.Add("备注", typeof(string));
                biaoge.Columns.Add("要求到货日期", typeof(DateTime));

                for (int i = 0; i < list.Count; i++)//遍历数组成员
                {
                    //string sql = "select sum(数量) from db_caigoucailiao where 编码='" + list[i] + "' and time='"+ shijian +"' and 设备名称='"+ shebeimingcheng +"'";
                    //string shuliangSum = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                    string sql1 = "select * from db_caigoucailiao where 编码='" + list[i] + "' and 序号='" + xuhaocailiao + "' and 设备名称='" + shebeimingcheng + "' and 料单类型='" + liaodanleiixng + "'";
                    DataTable shuju = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    DataRow row = biaoge.NewRow();


                    row["项目名称"] = shuju.Rows[0]["项目名称"].ToString();
                    row["设备名称"] = shuju.Rows[0]["设备名称"].ToString();
                    row["工作令号"] = shuju.Rows[0]["工作令号"].ToString();
                    row["材料名称"] = shuju.Rows[0]["材料名称"].ToString();
                    row["型号"] = shuju.Rows[0]["型号"].ToString();
                    row["编码"] = shuju.Rows[0]["编码"].ToString();
                    row["单位"] = shuju.Rows[0]["单位"].ToString();
                    row["类型"] = shuju.Rows[0]["类型"].ToString();
                    row["要求到货日期"] = DateTime.Now.AddDays(5);

                    biaoge.Rows.Add(row);
                }

                for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
                {
                    double shulaing = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (biaoge.Rows[i]["编码"].ToString() == dt.Rows[j]["编码"].ToString())
                        {
                            shulaing += Convert.ToDouble(dt.Rows[j]["数量"]);
                        }

                    }

                    biaoge.Rows[i]["数量"] = shulaing;
                }


                Formcaigoushenqing form = new Formcaigoushenqing();
                form.dt = biaoge;
                form.array = b;
                form.yonghuming = yonghu;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    foreach (string id in b)
                    {
                        string sql = "update db_caigoucailiao set 申购情况='已经申购' where id='" + id + "'";
                        SQLhelp.ExecuteNonquery(sql, CommandType.Text);
                    }
                }
            }


            if(liaodanleiixng == "机修件组件")
            {
                int[] a = gridView1.GetSelectedRows();

                foreach (int i in a)
                {
                    DataRow dr = this.gridView1.GetDataRow(i);//遍历每行
                    string str1 = Convert.ToString(dr["申购情况"]);//当前行数量
                    if (str1 == "已经申购")
                    {
                        MessageBox.Show("第" + (i + 1) + "行已经申购原材料！", "提示");
                        return;
                    }
                }

                DataTable dt = new DataTable();
                DataTable biaoge = new DataTable();

                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("项目名称", typeof(string));
                dt.Columns.Add("设备名称", typeof(string));
                dt.Columns.Add("工作令号", typeof(string));
                dt.Columns.Add("图号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("材料名称", typeof(string));
                dt.Columns.Add("型号", typeof(string));
                dt.Columns.Add("编码", typeof(string));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("数量", typeof(float));
                dt.Columns.Add("类型", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                dt.Columns.Add("要求到货日期", typeof(DateTime));
                dt.Columns.Add("time", typeof(DateTime));
                dt.Columns.Add("组件定位", typeof(string));

                string[] b = new string[a.Length];

                foreach (int i in a)
                {

                    DataRow dr = dt.NewRow();

                    string id = gridView1.GetRowCellValue(i, "id").ToString();
                    string caigouxiangmuming = gridView1.GetRowCellValue(i, "项目名称").ToString();
                    string caigoushebeiming = gridView1.GetRowCellValue(i, "设备名称").ToString();
                    string caigougongzuolinghao = gridView1.GetRowCellValue(i, "工作令号").ToString();
                    string caigoutuhao = gridView1.GetRowCellValue(i, "图号").ToString();
                    string caigoumingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                    string caigoucailiaoming = gridView1.GetRowCellValue(i, "材料名称").ToString();
                    string caigouxinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                    string caigoubianma = gridView1.GetRowCellValue(i, "编码").ToString();
                    string caigoudanwei = gridView1.GetRowCellValue(i, "单位").ToString();
                    string caigoushuliang = gridView1.GetRowCellValue(i, "总重量").ToString();
                    string caigouleixing = gridView1.GetRowCellValue(i, "类型").ToString();
                    string caigoubeizhu = gridView1.GetRowCellValue(i, "备注").ToString();
                    string caigouriqi = gridView1.GetRowCellValue(i, "要求到货日期").ToString();
                    string caigoutime = gridView1.GetRowCellValue(i, "time").ToString();
                    string caigoudingwei = gridView1.GetRowCellValue(i, "组件定位").ToString();

                    dr["id"] = id;
                    dr["项目名称"] = caigouxiangmuming;
                    dr["设备名称"] = caigoushebeiming;
                    dr["工作令号"] = caigougongzuolinghao;
                    dr["图号"] = caigoutuhao;
                    dr["名称"] = caigoumingcheng;
                    dr["材料名称"] = caigoucailiaoming;
                    dr["型号"] = caigouxinghao;
                    dr["编码"] = caigoubianma;
                    dr["单位"] = caigoudanwei;
                    dr["数量"] = caigoushuliang;
                    dr["类型"] = caigouleixing;
                    dr["备注"] = caigoubeizhu;
                    dr["要求到货日期"] = caigouriqi;
                    dr["time"] = caigoutime;
                    dr["组件定位"] = caigoudingwei;

                    dt.Rows.Add(dr);

                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    b[i] = dr["id"].ToString();
                }

                List<string> list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)//遍历数组成员
                {
                    if (dt.Rows[i]["编码"].ToString() != "")
                    {
                        if (list.IndexOf(dt.Rows[i]["编码"].ToString()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                            list.Add(dt.Rows[i]["编码"].ToString());
                    }
                }

                biaoge.Columns.Add("项目名称", typeof(string));
                biaoge.Columns.Add("设备名称", typeof(string));
                biaoge.Columns.Add("工作令号", typeof(string));
                biaoge.Columns.Add("图号", typeof(string));
                biaoge.Columns.Add("名称", typeof(string));
                biaoge.Columns.Add("材料名称", typeof(string));
                biaoge.Columns.Add("型号", typeof(string));
                biaoge.Columns.Add("编码", typeof(string));
                biaoge.Columns.Add("单位", typeof(string));
                biaoge.Columns.Add("数量", typeof(float));
                biaoge.Columns.Add("类型", typeof(string));
                biaoge.Columns.Add("备注", typeof(string));
                biaoge.Columns.Add("要求到货日期", typeof(DateTime));
                biaoge.Columns.Add("time", typeof(DateTime));
                biaoge.Columns.Add("组件定位", typeof(string));

                for (int i = 0; i < list.Count; i++)//遍历数组成员
                {

                    string sql1 = "select * from db_caigoucailiao where 编码='" + list[i] + "' and 设备名称='" + shebeimingcheng + "' and 料单类型='" + liaodanleiixng + "' and 组件定位='"+ dingweishu +"'";
                    DataTable shuju = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    DataRow row = biaoge.NewRow();


                    row["项目名称"] = shuju.Rows[0]["项目名称"].ToString();
                    row["设备名称"] = shuju.Rows[0]["设备名称"].ToString();
                    row["工作令号"] = shuju.Rows[0]["工作令号"].ToString();
                    row["材料名称"] = shuju.Rows[0]["材料名称"].ToString();
                    row["型号"] = shuju.Rows[0]["型号"].ToString();
                    row["编码"] = shuju.Rows[0]["编码"].ToString();
                    row["单位"] = shuju.Rows[0]["单位"].ToString();
                    row["类型"] = shuju.Rows[0]["类型"].ToString();
                    row["time"] = shuju.Rows[0]["time"].ToString();
                    row["要求到货日期"] = DateTime.Now.AddDays(5);

                    biaoge.Rows.Add(row);
                }

                for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
                {
                    double shulaing = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (biaoge.Rows[i]["编码"].ToString() == dt.Rows[j]["编码"].ToString())
                        {
                            shulaing += Convert.ToDouble(dt.Rows[j]["数量"]);
                        }

                    }

                    biaoge.Rows[i]["数量"] = shulaing;
                }


                Formcaigoushenqing form = new Formcaigoushenqing();
                form.dt = biaoge;
                form.array = b;
                form.yonghuming = yonghu;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    foreach (string id in b)
                    {
                        string sql = "update db_caigoucailiao set 申购情况='已经申购' where id='" + id + "'";
                        SQLhelp.ExecuteNonquery(sql, CommandType.Text);
                    }
                }
            }
            
            if(liaodanleiixng == "项目")
            {
                int[] a = gridView1.GetSelectedRows();
                foreach (int i in a)
                {
                    DataRow dr = this.gridView1.GetDataRow(i);//遍历每行
                    string str1 = Convert.ToString(dr["申购情况"]);//当前行数量
                    if (str1 == "已经申购")
                    {
                        MessageBox.Show("第" + (i + 1) + "行已经申购原材料！", "提示");
                        return;
                    }
                }

                DataTable dt = new DataTable();
                DataTable biaoge = new DataTable();

                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("项目名称", typeof(string));
                dt.Columns.Add("设备名称", typeof(string));
                dt.Columns.Add("工作令号", typeof(string));
                dt.Columns.Add("图号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("材料名称", typeof(string));
                dt.Columns.Add("型号", typeof(string));
                dt.Columns.Add("编码", typeof(string));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("数量", typeof(float));
                dt.Columns.Add("类型", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                dt.Columns.Add("要求到货日期", typeof(DateTime));
                dt.Columns.Add("time", typeof(DateTime));

                string[] b = new string[a.Length];

                foreach (int i in a)
                {

                    DataRow dr = dt.NewRow();

                    string id = gridView1.GetRowCellValue(i, "id").ToString();
                    string caigouxiangmuming = gridView1.GetRowCellValue(i, "项目名称").ToString();
                    string caigoushebeiming = gridView1.GetRowCellValue(i, "设备名称").ToString();
                    string caigougongzuolinghao = gridView1.GetRowCellValue(i, "工作令号").ToString();
                    string caigoutuhao = gridView1.GetRowCellValue(i, "图号").ToString();
                    string caigoumingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                    string caigoucailiaoming = gridView1.GetRowCellValue(i, "材料名称").ToString();
                    string caigouxinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                    string caigoubianma = gridView1.GetRowCellValue(i, "编码").ToString();
                    string caigoudanwei = gridView1.GetRowCellValue(i, "单位").ToString();
                    string caigoushuliang = gridView1.GetRowCellValue(i, "总重量").ToString();
                    string caigouleixing = gridView1.GetRowCellValue(i, "类型").ToString();
                    string caigoubeizhu = gridView1.GetRowCellValue(i, "备注").ToString();
                    string caigouriqi = gridView1.GetRowCellValue(i, "要求到货日期").ToString();
                    string caigoutime = gridView1.GetRowCellValue(i, "time").ToString();

                    dr["id"] = id;
                    dr["项目名称"] = caigouxiangmuming;
                    dr["设备名称"] = caigoushebeiming;
                    dr["工作令号"] = caigougongzuolinghao;
                    dr["图号"] = caigoutuhao;
                    dr["名称"] = caigoumingcheng;
                    dr["材料名称"] = caigoucailiaoming;
                    dr["型号"] = caigouxinghao;
                    dr["编码"] = caigoubianma;
                    dr["单位"] = caigoudanwei;
                    dr["数量"] = caigoushuliang;
                    dr["类型"] = caigouleixing;
                    dr["备注"] = caigoubeizhu;
                    dr["要求到货日期"] = caigouriqi;
                    dr["time"] = caigoutime;

                    dt.Rows.Add(dr);

                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    b[i] = dr["id"].ToString();
                }

                List<string> list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)//遍历数组成员
                {
                    if (dt.Rows[i]["编码"].ToString() != "")
                    {
                        if (list.IndexOf(dt.Rows[i]["编码"].ToString()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                            list.Add(dt.Rows[i]["编码"].ToString());
                    }
                }

                biaoge.Columns.Add("项目名称", typeof(string));
                biaoge.Columns.Add("设备名称", typeof(string));
                biaoge.Columns.Add("工作令号", typeof(string));
                biaoge.Columns.Add("图号", typeof(string));
                biaoge.Columns.Add("名称", typeof(string));
                biaoge.Columns.Add("材料名称", typeof(string));
                biaoge.Columns.Add("型号", typeof(string));
                biaoge.Columns.Add("编码", typeof(string));
                biaoge.Columns.Add("单位", typeof(string));
                biaoge.Columns.Add("数量", typeof(float));
                biaoge.Columns.Add("类型", typeof(string));
                biaoge.Columns.Add("备注", typeof(string));
                biaoge.Columns.Add("要求到货日期", typeof(DateTime));
                biaoge.Columns.Add("time", typeof(DateTime));

                for (int i = 0; i < list.Count; i++)//遍历数组成员
                {
                    //string sql = "select sum(数量) from db_caigoucailiao where 编码='" + list[i] + "' and time='"+ shijian +"' and 设备名称='"+ shebeimingcheng +"'";
                    //string shuliangSum = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                    string sql1 = "select * from db_caigoucailiao where 编码='" + list[i] + "' and time='" + shijian + "' and 设备名称='" + shebeimingcheng + "' and 料单类型='" + liaodanleiixng + "'";
                    DataTable shuju = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    DataRow row = biaoge.NewRow();


                    row["项目名称"] = shuju.Rows[0]["项目名称"].ToString();
                    row["设备名称"] = shuju.Rows[0]["设备名称"].ToString();
                    row["工作令号"] = shuju.Rows[0]["工作令号"].ToString();
                    row["材料名称"] = shuju.Rows[0]["材料名称"].ToString();
                    row["型号"] = shuju.Rows[0]["型号"].ToString();
                    row["编码"] = shuju.Rows[0]["编码"].ToString();
                    row["单位"] = shuju.Rows[0]["单位"].ToString();
                    row["类型"] = shuju.Rows[0]["类型"].ToString();
                    row["time"] = shuju.Rows[0]["time"].ToString();
                    row["要求到货日期"] = DateTime.Now.AddDays(5);

                    biaoge.Rows.Add(row);
                }

                for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
                {
                    double shulaing = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (biaoge.Rows[i]["编码"].ToString() == dt.Rows[j]["编码"].ToString())
                        {
                            shulaing += Convert.ToDouble(dt.Rows[j]["数量"]);
                        }

                    }

                    biaoge.Rows[i]["数量"] = shulaing;
                }


                Formcaigoushenqing form = new Formcaigoushenqing();
                form.dt = biaoge;
                form.array = b;
                form.yonghuming = yonghu;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    foreach (string id in b)
                    {
                        string sql = "update db_caigoucailiao set 申购情况='已经申购' where id='" + id + "'";
                        SQLhelp.ExecuteNonquery(sql, CommandType.Text);
                    }
                }
            }

           

        }
        public void DrawRowIndicator(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
        {
            gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            if (width != 0)
            {
                if (width != 0)
                {
                    gv.IndicatorWidth = width;
                }
                else
                {
                    gv.IndicatorWidth = 30;
                }
            }
            else
            {
                gv.IndicatorWidth = 30;
            }

        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}