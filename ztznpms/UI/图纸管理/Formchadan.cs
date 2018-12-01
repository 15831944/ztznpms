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
using ztznpms.UI.二维码;

namespace ztznpms.UI.图纸管理
{
    public partial class Formchadan : DevExpress.XtraEditors.XtraForm
    {
        DateTime drtime1;
        DateTime drtime2;

        DateTime dateTime;

        DateTime timeNow = DateTime.Now;
        string time1time;
        string time1date1;

        private const string shijian1 = "08:00:00";//上班
        private const string shijian2 = "12:00:00";//开始休息----4小时
        private const string shijian3 = "13:00:00";//结束休息
        private const string shijian4 = "17:30:00";//开始休息----4.5小时
        private const string shijian5 = "18:00:00";//结束休息
        private const string shijian6 = "20:00:00";//下班    -----2小时------>一共10.5小时

        string shijian7 = "23:30:00";
        string shijian8 = "00:30:00";

        private FormProcess progressForm = new FormProcess();
        // 代理定义，可以在Invoke时传入相应的参数
        private delegate void funHandle(int nValue);
        private funHandle myHandle = null;

        public Formchadan()
        {
            InitializeComponent();
        }

        private void reload()
        {
            DateTime timeNow = DateTime.Now;
            string strSQL = "select * from db_Paichan where 实际开始时间 IS NULL and 工序设备!='' and 价格!=0 order by 交货日期 asc";//and 设定开始时间 < 设定结束时间
            DataTable dt = SQLhelp.GetDataTable(strSQL, CommandType.Text);

            gridControl1.DataSource = dt;
        }

        private void Formchadan_Load(object sender, EventArgs e)
        {
            ////设置复选框
            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            time1time = timeNow.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
            time1date1 = timeNow.ToString("yyyy/MM/dd");//截取到的当前的日期

            reload();

            DrawRowIndicator(gridView1, 50);
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            int rowindex = a[0];
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string gongxushebei = gridView1.GetRowCellValue(i, "工序设备").ToString();
                string gongxushunxu = gridView1.GetRowCellValue(i, "工序顺序").ToString();
                string gongxuxuhao = gridView1.GetRowCellValue(i, "序号").ToString();
                string gongxushuliang = gridView1.GetRowCellValue(i, "数量").ToString();
                string gongxujiage = gridView1.GetRowCellValue(i, "价格").ToString();


                string sql1 = "update db_Paichan set 设定开始时间=NULL,设定结束时间=NULL where id='" + id + "' ";
                SQLhelp.ExecuteNonquery(sql1, CommandType.Text);

                string leixing = panduanshebi(gongxushebei);
                if (leixing == "12")
                {

                    if (gongxushunxu == "1")//工序为1使用的是当前时间比较
                    {
                        string str = "select max(设定结束时间) from db_Paichan where 工序设备='" + gongxushebei + "'";
                        string r = Convert.ToString(SQLhelp.ExecuteScalar(str, CommandType.Text));
                        if (r != "")
                        {
                            DateTime de = Convert.ToDateTime(r);
                            string de1 = de.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                            string de2 = de.ToString("yyyy/MM/dd");//截取到的当前的日期
                            if (de < timeNow)
                            {
                                var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);

                                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            }
                            else
                            {
                                var result = paichanNowtime(de1, de2, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);

                                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            }
                        }
                        else
                        {

                            var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);

                            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        }

                    }
                    else//工序不为1，使用的是上一道工序的设定结束时间
                    {
                        #region 老方法

                        //string str1 = "select 工序设备 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(gongxushunxu) - 1) + "'";
                        //string r1 = Convert.ToString(SQLhelp.ExecuteScalar(str1, CommandType.Text));

                        //if (r1 != "")
                        //{
                        //    string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + gongxuxuhao+ "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(gongxushunxu) - 1) + "'";
                        //    DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                        //    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                        //    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                        //    string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + gongxushebei + "'";
                        //    string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                        //    if (RETtime != "")
                        //    {
                        //        dateTime = Convert.ToDateTime(RETtime);
                        //    }
                        //    else
                        //    {
                        //        dateTime = DateTime.Now;
                        //    }
                        //    if (dateTime < da)
                        //    {
                        //        if (da < timeNow)
                        //        {

                        //            var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //        }
                        //        else
                        //        {

                        //            var result = paichanNowtime(da1, da2, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (dateTime < timeNow)
                        //        {

                        //            var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //        }
                        //        else
                        //        {

                        //            var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //        }
                        //    }




                        //}
                        //else
                        //{
                        //    string str2 = "select 工序设备 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(gongxushunxu) - 2) + "'";
                        //    string r2 = Convert.ToString(SQLhelp.ExecuteScalar(str2, CommandType.Text));
                        //    if (r2 != "")
                        //    {
                        //        string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(gongxushunxu) - 2) + "'";
                        //        DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                        //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                        //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                        //        string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + gongxushebei + "'";
                        //        string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                        //        if (RETtime != "")
                        //        {
                        //            dateTime = Convert.ToDateTime(RETtime);
                        //        }
                        //        else
                        //        {
                        //            dateTime = DateTime.Now;
                        //        }
                        //        if (dateTime < da)
                        //        {
                        //            if (da < timeNow)
                        //            {

                        //                var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //            }
                        //            else
                        //            {

                        //                var result = paichanNowtime(da1, da2, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            if (dateTime < timeNow)
                        //            {

                        //                var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //            }
                        //            else
                        //            {

                        //                var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //            }
                        //        }


                        //    }
                        //    else
                        //    {
                        //        string str3 = "select 工序设备 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(gongxushunxu) - 3) + "'";
                        //        string r3 = Convert.ToString(SQLhelp.ExecuteScalar(str3, CommandType.Text));
                        //        if (r3 != "")
                        //        {
                        //            string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(gongxushunxu) - 3) + "'";
                        //            DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                        //            string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                        //            string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                        //            string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + gongxushebei + "'";
                        //            string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                        //            if (RETtime != "")
                        //            {
                        //                dateTime = Convert.ToDateTime(RETtime);
                        //            }
                        //            else
                        //            {
                        //                dateTime = DateTime.Now;
                        //            }
                        //            if (dateTime < da)
                        //            {
                        //                if (da < timeNow)
                        //                {

                        //                    var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //                }
                        //                else
                        //                {

                        //                    var result = paichanNowtime(da1, da2, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //                }
                        //            }
                        //            else
                        //            {
                        //                if (dateTime < timeNow)
                        //                {

                        //                    var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //                }
                        //                else
                        //                {

                        //                    var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                        //                }
                        //            }
                        //        }
                        //    }
                        //}

                        #endregion

                        GongXuShunXuXuanZe(gongxuxuhao, gongxushunxu, gongxushebei, gongxujiage, gongxushuliang);
                    }

                }
            }

            reload();
            this.gridView1.FocusedRowHandle = rowindex;
        }

        private void GongXuShunXuXuanZe(string gongxuxuhao,string gongxushunxu,string gongxushebei,string gongxujiage,string gongxushuliang)
        {
            string shunxusql1 = "select max(工序顺序) from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序 < " + Convert.ToInt32(gongxushunxu) + " and 工序设备 IS NOT NULL";
            string shunxuret1 = Convert.ToString(SQLhelp.ExecuteScalar(shunxusql1, CommandType.Text));//最大工序顺序且工序顺序不为空

            string str3 = "select 工序设备 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + shunxuret1 + "'";
            string r3 = Convert.ToString(SQLhelp.ExecuteScalar(str3, CommandType.Text));
            if (r3 != "")
            {
                string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + gongxuxuhao + "' and 工序顺序='" + shunxuret1 + "'";
                DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + gongxushebei + "'";
                string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                if (RETtime != "")
                {
                    dateTime = Convert.ToDateTime(RETtime);
                }
                else
                {
                    dateTime = DateTime.Now;
                }
                if (dateTime < da)
                {
                    if (da < timeNow)
                    {

                        var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                    }
                    else
                    {

                        var result = paichanNowtime(da1, da2, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                    }
                }
                else
                {
                    if (dateTime < timeNow)
                    {

                        var result = paichanNowtime(time1time, time1date1, gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                    }
                    else
                    {

                        var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), gongxushebei, gongxujiage, gongxushuliang, drtime1, drtime2);
                        string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + gongxuxuhao + "' and 工序顺序='" + gongxushunxu + "'";
                        SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                    }
                }
            }
        }

        /// <summary>
        /// 线程函数中调用的函数
        /// </summary>
        private void ShowProgressBar()
        {
            myHandle = new funHandle(progressForm.SetProgressValue);
            progressForm.ShowDialog();
        }

        /// <summary>
        /// 线程函数，用于处理调用
        /// </summary>
        private void ThreadFun()
        {
            MethodInvoker mi = new MethodInvoker(ShowProgressBar);
            this.BeginInvoke(mi);

            System.Threading.Thread.Sleep(1000); // sleep to show window

            for (int i = 0; i < 1000; ++i)
            {
                System.Threading.Thread.Sleep(5);
                // 这里直接调用代理
                this.Invoke(this.myHandle, new object[] { (i / 10) });
            }
        }


        /// <summary>
        /// 全部重新排产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //// 启动线程
            //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadFun));
            //thread.Start();

            #region 全部重新排产

            DateTime timeNow = DateTime.Now;

            string time1time = timeNow.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
            string time1date1 = timeNow.ToString("yyyy/MM/dd");//截取到的当前的日期

            string sql1 = "update db_Paichan set 设定开始时间=NULL,设定结束时间=NULL where 实际开始时间 IS NULL ";
            SQLhelp.ExecuteNonquery(sql1, CommandType.Text);

            string sql2 = "select * from db_Paichan where 工序设备 IS NOT NULL and 设定开始时间 IS NULL and 设定结束时间 IS NULL and 实际开始时间 IS NULL and 价格 !=0 order by 交货日期 asc ";
            string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));
            if (ret2 != "")
            {
                DataTable dt = SQLhelp.GetDataTable(sql2, CommandType.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string leixing = panduanshebi(dr["工序设备"].ToString());
                    if (leixing == "12")
                    {

                        if (dr["工序顺序"].ToString() == "1")//工序为1使用的是当前时间比较
                        {
                            string str = "select max(设定结束时间) from db_Paichan where 工序设备='" + dr["工序设备"] + "'";
                            string r = Convert.ToString(SQLhelp.ExecuteScalar(str, CommandType.Text));
                            if (r != "")
                            {
                                DateTime de = Convert.ToDateTime(r);
                                string de1 = de.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                                string de2 = de.ToString("yyyy/MM/dd");//截取到的当前的日期
                                if (de < timeNow)
                                {
                                    var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);

                                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                                }
                                else
                                {
                                    var result = paichanNowtime(de1, de2, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);

                                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                                }
                            }
                            else
                            {

                                var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);

                                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            }

                        }
                        else//工序不为1，使用的是上一道工序的设定结束时间
                        {
                            GongXuShunXuXuanZe(dr["序号"].ToString(), dr["工序顺序"].ToString(), dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString());

                            #region 老方法

                            //string str1 = "select 工序设备 from db_Paichan where 序号='" + dr["序号"] + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(dr["工序顺序"].ToString()) - 1) + "'";
                            //string r1 = Convert.ToString(SQLhelp.ExecuteScalar(str1, CommandType.Text));

                            //if (r1 != "")
                            //{
                            //    string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + dr["序号"] + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(dr["工序顺序"].ToString()) - 1) + "'";
                            //    DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                            //    string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                            //    string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                            //    string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + dr["工序设备"] + "'";
                            //    string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                            //    if (RETtime != "")
                            //    {
                            //        dateTime = Convert.ToDateTime(RETtime);
                            //    }
                            //    else
                            //    {
                            //        dateTime = DateTime.Now;
                            //    }
                            //    if (dateTime < da)
                            //    {
                            //        if (da < timeNow)
                            //        {

                            //            var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //        }
                            //        else
                            //        {

                            //            var result = paichanNowtime(da1, da2, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (dateTime < timeNow)
                            //        {

                            //            var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //        }
                            //        else
                            //        {

                            //            var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //            string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //            SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //        }
                            //    }




                            //}
                            //else
                            //{
                            //    string str2 = "select 工序设备 from db_Paichan where 序号='" + dr["序号"] + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(dr["工序顺序"].ToString()) - 2) + "'";
                            //    string r2 = Convert.ToString(SQLhelp.ExecuteScalar(str2, CommandType.Text));
                            //    if (r2 != "")
                            //    {
                            //        string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + dr["序号"] + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(dr["工序顺序"].ToString()) - 2) + "'";
                            //        DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                            //        string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                            //        string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                            //        string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + dr["工序设备"] + "'";
                            //        string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                            //        if (RETtime != "")
                            //        {
                            //            dateTime = Convert.ToDateTime(RETtime);
                            //        }
                            //        else
                            //        {
                            //            dateTime = DateTime.Now;
                            //        }
                            //        if (dateTime < da)
                            //        {
                            //            if (da < timeNow)
                            //            {

                            //                var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //            }
                            //            else
                            //            {

                            //                var result = paichanNowtime(da1, da2, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (dateTime < timeNow)
                            //            {

                            //                var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //            }
                            //            else
                            //            {

                            //                var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //            }
                            //        }


                            //    }
                            //    else
                            //    {
                            //        string str3 = "select 工序设备 from db_Paichan where 序号='" + dr["序号"] + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(dr["工序顺序"].ToString()) - 3) + "'";
                            //        string r3 = Convert.ToString(SQLhelp.ExecuteScalar(str3, CommandType.Text));
                            //        if (r3 != "")
                            //        {
                            //            string SQL1 = "select 设定结束时间 from db_Paichan where 序号='" + dr["序号"] + "' and 工序顺序='" + Convert.ToInt32(Convert.ToInt32(dr["工序顺序"].ToString()) - 3) + "'";
                            //            DateTime da = Convert.ToDateTime(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));

                            //            string da1 = da.ToString("HH:mm:ss");//当前时间（时分秒）---- 字符串
                            //            string da2 = da.ToString("yyyy/MM/dd");//截取到的当前的日期

                            //            string SQLtime = "select max(设定结束时间) from db_Paichan where 工序设备='" + dr["工序设备"] + "'";
                            //            string RETtime = Convert.ToString(SQLhelp.ExecuteScalar(SQLtime, CommandType.Text));
                            //            if (RETtime != "")
                            //            {
                            //                dateTime = Convert.ToDateTime(RETtime);
                            //            }
                            //            else
                            //            {
                            //                dateTime = DateTime.Now;
                            //            }
                            //            if (dateTime < da)
                            //            {
                            //                if (da < timeNow)
                            //                {

                            //                    var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //                }
                            //                else
                            //                {

                            //                    var result = paichanNowtime(da1, da2, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //                }
                            //            }
                            //            else
                            //            {
                            //                if (dateTime < timeNow)
                            //                {

                            //                    var result = paichanNowtime(time1time, time1date1, dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //                }
                            //                else
                            //                {

                            //                    var result = paichanNowtime(dateTime.ToString("HH:mm:ss"), dateTime.ToString("yyyy/MM/dd"), dr["工序设备"].ToString(), dr["价格"].ToString(), dr["数量"].ToString(), drtime1, drtime2);
                            //                    string SQL2 = "update db_Paichan set 设定开始时间='" + result.Item1 + "',设定结束时间='" + result.Item2 + "' where 序号='" + dr["序号"] + "' and 工序顺序='" + dr["工序顺序"] + "'";
                            //                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                            //                }
                            //            }
                            //        }
                            //    }
                            //}

                            #endregion
                        }

                    }
                }
            }
            #endregion

            reload();

        }

        /// <summary>
        /// 返回设备的类型--数控与非数控
        /// </summary>
        /// <param name="shebei"></param>
        /// <returns></returns>
        private string panduanshebi(string shebei)
        {
            string sqlstr = "select identification from db_chejianrenyuan where 设备名='" + shebei + "'";//查询设备对应的是否为数控设备
            string retstr = Convert.ToString(SQLhelp.ExecuteScalar(sqlstr, CommandType.Text));

            return retstr;
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
        private static Tuple<DateTime,DateTime> paichan2(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTime picker1, DateTime picker2)
        {
            //picker1 = DateTime.Now;
            //picker2 = DateTime.Now;

            DateTime time1 = DateTime.Now;//日期+时分秒（当前）

            string sql1 = "select 设定结束时间 from db_Pai1 where 工序设备='" + shebei + "'";
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
                    picker1 = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                    if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                    {
                        picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                    {
                        picker2 = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                    {
                        picker2 = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                    }

                }

                //当前时间大于8:00 小于12:00
                int ta3 = time1time.CompareTo(shijian1);
                int ta4 = shijian2.CompareTo(time1time);
                if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
                {

                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                    picker1 = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                    DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                    TimeSpan a = Time22 - strtime;//上午加工的时间
                    if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                    {

                        double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                        if (tt <= 4)//下午做完
                        {
                            picker2 = strtimexiawu.AddDays(at).AddHours(tt);
                        }
                        if (4 < tt && tt <= 6.5)//晚上做完
                        {
                            picker2 = strtimewanshang.AddDays(at).AddHours(tt - 4);
                        }
                        if (tt >= 6.5)//第二天上午做完
                        {
                            picker2 = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                        }
                    }
                    else
                    {
                        picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                int ta6 = time1time.CompareTo(shijian2);
                int ta7 = shijian3.CompareTo(time1time);

                if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                    picker1 = Convert.ToDateTime(strtime);
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)//下午完成
                    {
                        picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (10.5 * at + 4 < t && t <= 10.5 * at + 6.5)//晚上完成
                    {
                        picker2 = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                    }
                    if (10.5 * at + 6.5 < t && t <= 10.5 * at + 10.5)//第二天上午完成
                    {
                        picker2 = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                    }

                }

                //当前时间大于13:00 小于17:30
                int ta9 = time1time.CompareTo(shijian3);
                int ta10 = shijian4.CompareTo(time1time);

                if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    picker1 = Convert.ToDateTime(strtime);
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
                            picker2 = strtimewanshang.AddDays(at).AddHours(ttzhi);
                        }
                        if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                        {
                            picker2 = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                        }
                        if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                        {
                            picker2 = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                        }

                    }
                    else
                    {
                        picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }

                }

                //当前时间大于17:30 小于18:00
                int ta12 = time1time.CompareTo(shijian4);
                int ta13 = shijian5.CompareTo(time1time);

                if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                    picker1 = Convert.ToDateTime(strtime);
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                    if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                    {
                        picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                    if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                    {
                        picker2 = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                    }
                    if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                    {
                        picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                    }

                }

                //当前时间大于18:00 小于20:00
                int ta14 = time1time.CompareTo(shijian5);
                int ta15 = shijian6.CompareTo(time1time);

                if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1 = Convert.ToDateTime(strtime);
                    DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                    DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                    TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                    if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                    {
                        double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                        if (t2 <= 4)//第二天上午可以完成
                        {
                            picker2 = strtime1.AddDays(at + 1).AddHours(t2);
                        }
                        if (4 < t2 && t2 <= 8.5)//第二天下午完成
                        {
                            picker2 = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                        }
                        if (8.5 < t2 && t2 <= 10.5)//第二天晚上完成
                        {
                            picker2 = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                        }
                    }
                    else
                    {
                        picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                    }
                }

                //当前时间大于20:00
                //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                int ta16 = time1time.CompareTo(shijian6);

                if (ta16 == 1)
                {
                    DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                    DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                    picker1 = strtime1.AddDays(1);

                    DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                    DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                    if (10.5 * at < t && t <= 10.5 * at + 4)
                    {
                        picker2 = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                    }
                    if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                    {
                        picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                    }
                    if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                    {
                        picker2 = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                    }
                }

              
            }
            #endregion

            #region 设备不空闲
            else
            {
                //string sql2 = "select max(设定开始时间) from db_Pai1 where 工序设备='" + shebei + "'";//查询该设备的最大设定的开始时间
                //string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql3 = "select max(设定结束时间) from db_Pai1 where 工序设备='" + shebei + "'";//最大的设定开始时间对应的结束事假，结束时间就是当前时间
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
                        picker1 = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                        {
                            picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                        {
                            picker2 = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                        {
                            picker2 = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于8:00 小于12:00
                    int ta3 = time1time.CompareTo(shijian1);
                    int ta4 = shijian2.CompareTo(time1time);
                    if (ta3 == 1 && ta4 == 1)
                    {

                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                        picker1 = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                        DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                        TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                        if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                        {

                            double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                            if (tt <= 4)//下午做完
                            {
                                picker2 = strtimexiawu.AddDays(at).AddHours(tt);
                            }
                            if (4 < tt && tt <= 6.5)//晚上做完
                            {
                                picker2 = strtimewanshang.AddDays(at).AddHours(tt - 4);
                            }
                            if (tt >= 6.5)//第二天上午做完
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                            }
                        }
                        else
                        {
                            picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                    int ta6 = time1time.CompareTo(shijian2);
                    int ta7 = shijian3.CompareTo(time1time);

                    if (ta6 == 1 && ta7 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                        picker1 = Convert.ToDateTime(strtime);
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                        {
                            picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                        {
                            picker2 = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                        }
                        if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                        {
                            picker2 = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                        }

                    }

                    //当前时间大于13:00 小于17:30
                    int ta9 = time1time.CompareTo(shijian3);
                    int ta10 = shijian4.CompareTo(time1time);

                    if (ta9 == 1 && ta10 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        picker1 = Convert.ToDateTime(strtime);
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
                                picker2 = strtimewanshang.AddDays(at).AddHours(ttzhi);
                            }
                            if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                            }
                            if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                            {
                                picker2 = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                            }

                        }
                        else
                        {
                            picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }

                    }

                    //当前时间大于17:30 小于18:00
                    int ta12 = time1time.CompareTo(shijian4);
                    int ta13 = shijian5.CompareTo(time1time);

                    if (ta12 == 1 && ta13 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                        picker1 = Convert.ToDateTime(strtime);
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                        if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                        {
                            picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                        if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                        {
                            picker2 = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                        }
                        if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                        {
                            picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                        }

                    }

                    //当前时间大于18:00 小于20:00
                    int ta14 = time1time.CompareTo(shijian5);
                    int ta15 = shijian6.CompareTo(time1time);

                    if (ta14 == 1 && ta15 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1 = Convert.ToDateTime(strtime);
                        DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                        DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                        TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                        if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                        {
                            double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                            if (t2 <= 4)//第二天上午可以完成
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t2);
                            }
                            if (4 < t2 && t2 <= 8.5)//第二天下午完成
                            {
                                picker2 = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                            }
                            if (8.5 < t2 && t2 <= 10.5)//第二天晚上完成
                            {
                                picker2 = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                            }
                        }
                        else
                        {
                            picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                        }
                    }

                    //当前时间大于20:00
                    //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                    int ta16 = time1time.CompareTo(shijian6);

                    if (ta16 == 1)
                    {
                        DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                        DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                        picker1 = strtime1.AddDays(1);

                        DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                        DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                        if (10.5 * at < t && t <= 4 + 10.5 * at)
                        {
                            picker2 = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                        }
                        if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                        {
                            picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                        }
                        if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                        {
                            picker2 = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
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
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2 = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2 = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期 + 8:00:00
                            picker1 = Convert.ToDateTime(ret3);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(ret3date + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - ret3.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2 = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2 = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2 = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2 = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00:00
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2 = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            picker1 = Convert.ToDateTime(ret3);
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
                                    picker2 = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2 = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2 = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2 = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(ret3date + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//日期+8:00
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1 = Convert.ToDateTime(ret3);
                            DateTime strtimewuye = Convert.ToDateTime(ret3date + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - ret3.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2 = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t2 && t2 <= 8.5)//第二天下午完成
                                {
                                    picker2 = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t2 && t2 <= 10.5)//第二天晚上完成
                                {
                                    picker2 = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2 = ret3.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(ret3date + " " + shijian1);//当前日期+8:00
                            picker1 = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(ret3date + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(ret3date + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2 = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
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
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                            {
                                picker2 = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                            {
                                picker2 = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于8:00 小于12:00
                        int ta3 = time1time.CompareTo(shijian1);
                        int ta4 = shijian2.CompareTo(time1time);
                        if (ta3 == 1 && ta4 == 1)
                        {

                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                            DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                            TimeSpan a = Time22.AddDays(at) - strtime.AddDays(at);//上午加工的时间
                            if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                            {

                                double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                                if (tt <= 4)//下午做完
                                {
                                    picker2 = strtimexiawu.AddDays(at).AddHours(tt);
                                }
                                if (4 < tt && tt <= 6.5)//晚上做完
                                {
                                    picker2 = strtimewanshang.AddDays(at).AddHours(tt - 4);
                                }
                                if (tt >= 6.5)//第二天上午做完
                                {
                                    picker2 = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                                }
                            }
                            else
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
                        int ta6 = time1time.CompareTo(shijian2);
                        int ta7 = shijian3.CompareTo(time1time);

                        if (ta6 == 1 && ta7 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)//下午完成
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 6.5 + 10.5 * at)//晚上完成
                            {
                                picker2 = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                            }
                            if (6.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天上午完成
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                            }

                        }

                        //当前时间大于13:00 小于17:30
                        int ta9 = time1time.CompareTo(shijian3);
                        int ta10 = shijian4.CompareTo(time1time);

                        if (ta9 == 1 && ta10 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            picker1 = Convert.ToDateTime(strtime);
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
                                    picker2 = strtimewanshang.AddDays(at).AddHours(ttzhi);
                                }
                                if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                                {
                                    picker2 = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                                }
                                if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                                {
                                    picker2 = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                                }

                            }
                            else
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }

                        }

                        //当前时间大于17:30 小于18:00
                        int ta12 = time1time.CompareTo(shijian4);
                        int ta13 = shijian5.CompareTo(time1time);

                        if (ta12 == 1 && ta13 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                            if (10.5 * at < t && t <= 10.5 * at + 2)//晚上完成
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                            if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                            }
                            if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                            {
                                picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                            }

                        }

                        //当前时间大于18:00 小于20:00
                        int ta14 = time1time.CompareTo(shijian5);
                        int ta15 = shijian6.CompareTo(time1time);

                        if (ta14 == 1 && ta15 == 1)
                        {
                            DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1 = Convert.ToDateTime(strtime);
                            DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                            DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                            TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                            if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                            {
                                double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                                if (t2 <= 4)//第二天上午可以完成
                                {
                                    picker2 = strtime1.AddDays(at + 1).AddHours(t2);
                                }
                                if (4 < t2 && t2 <= 8.5)//第二天下午完成
                                {
                                    picker2 = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                                }
                                if (8.5 < t2 && t2 <= 10.5)//第二天晚上完成
                                {
                                    picker2 = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                                }
                            }
                            else
                            {
                                picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                            }
                        }

                        //当前时间大于20:00
                        //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
                        int ta16 = time1time.CompareTo(shijian6);

                        if (ta16 == 1)
                        {
                            //DateTime strtime = Convert.ToDateTime(ret3date + " " + time1time);//当前日期+时间
                            DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                            picker1 = strtime1.AddDays(1);

                            DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                            DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                            if (10.5 * at < t && t <= 4 + 10.5 * at)
                            {
                                picker2 = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                            }
                            if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                            {
                                picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                            }
                            if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                            {
                                picker2 = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                            }
                        }


                    }
                }

            }
            #endregion

            var tuple = new Tuple<DateTime, DateTime>(picker1, picker2);
            return tuple;
        }

        /// <summary>
        /// 使用当前时间
        /// </summary>
        /// <param name="time1time"></param>
        /// <param name="time1date1"></param>
        /// <param name="shebei"></param>
        /// <param name="jiage"></param>
        /// <param name="shuliang"></param>
        /// <param name="picker1"></param>
        /// <param name="picker2"></param>
        /// <returns></returns>
        private static Tuple<DateTime, DateTime> paichanNowtime(string time1time, string time1date1, string shebei, string jiage, string shuliang, DateTime picker1, DateTime picker2)
        {
            #region 设备空闲中 使用当前时间
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
                picker1 = Convert.ToDateTime(strtime);
                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00

                if (10.5 * at < t && t <= 4 + 10.5 * at)//上午完成
                {
                    picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                }
                if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)//下午完成
                {
                    picker2 = strtimexiawu.AddDays(at).AddHours(t - (4 + 10.5 * at));
                }
                if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//晚上完成
                {
                    picker2 = strtimewanshang.AddDays(at).AddHours(t - (8.5 + 10.5 * at));
                }

            }

            //当前时间大于8:00 小于12:00
            int ta3 = time1time.CompareTo(shijian1);
            int ta4 = shijian2.CompareTo(time1time);
            if (ta3 == 1 && (ta4 == 1 || ta4 == 0))
            {

                DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期 + 8:00:00
                picker1 = Convert.ToDateTime(strtime);
                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00
                DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期 + 17:30:00

                DateTime Time22 = Convert.ToDateTime(time1date1 + " " + shijian2);//日期+12:00

                TimeSpan a = Time22 - strtime;//上午加工的时间
                if (t - 10.5 * at >= a.TotalHours)//总的时间大于上午的时间(下午完成或者第二天上午完成)
                {

                    double tt = t - 10.5 * at - a.TotalHours;//剩余加工的时间
                    if (tt <= 4)//下午做完
                    {
                        picker2 = strtimexiawu.AddDays(at).AddHours(tt);
                    }
                    if (4 < tt && tt <= 6.5)//晚上做完
                    {
                        picker2 = strtimewanshang.AddDays(at).AddHours(tt - 4);
                    }
                    if (tt >= 6.5)//第二天上午做完
                    {
                        picker2 = strtime1.AddDays(at + 1).AddHours(tt - 6.5);
                    }
                }
                else
                {
                    picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                }
            }

            //当前时间大于12:00  小于13:00 -----> (13:00之后开始工作)
            int ta6 = time1time.CompareTo(shijian2);
            int ta7 = shijian3.CompareTo(time1time);

            if (ta6 == 1 && (ta7 == 1 || ta7 == 0))
            {
                DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00:00
                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00:00
                picker1 = Convert.ToDateTime(strtime);
                DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00:00

                if (10.5 * at < t && t <= 10.5 * at + 4)//下午完成
                {
                    picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                }
                if (10.5 * at + 4 < t && t <= 10.5 * at + 6.5)//晚上完成
                {
                    picker2 = strtimewanshang.AddDays(at).AddHours(t - (4 + 10.5 * at));
                }
                if (10.5 * at + 6.5 < t && t <= 10.5 * at + 10.5)//第二天上午完成
                {
                    picker2 = strtime1.AddDays(at + 1).AddHours(t - (6.5 + 10.5 * at));
                }

            }

            //当前时间大于13:00 小于17:30
            int ta9 = time1time.CompareTo(shijian3);
            int ta10 = shijian4.CompareTo(time1time);

            if (ta9 == 1 && (ta10 == 1 || ta10 == 0))
            {
                DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                picker1 = Convert.ToDateTime(strtime);
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
                        picker2 = strtimewanshang.AddDays(at).AddHours(ttzhi);
                    }
                    if (2 < ttzhi && ttzhi <= 6)//第二天上午完成
                    {
                        picker2 = strtime1.AddDays(at + 1).AddHours(ttzhi - 2);
                    }
                    if (6 < ttzhi && ttzhi <= 10.5)//下午完成
                    {
                        picker2 = strtimexiawu.AddDays(at + 1).AddHours(ttzhi - 6);
                    }

                }
                else
                {
                    picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                }

            }

            //当前时间大于17:30 小于18:00
            int ta12 = time1time.CompareTo(shijian4);
            int ta13 = shijian5.CompareTo(time1time);

            if (ta12 == 1 && (ta13 == 1 || ta13 == 0))
            {
                DateTime strtime = Convert.ToDateTime(time1date1 + " " + shijian5);//日期+18:00
                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//日期+8:00
                picker1 = Convert.ToDateTime(strtime);
                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//日期+13:00

                if (10.5 * at < t && t <= 2 + 10.5 * at)//晚上完成
                {
                    picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                }
                if (2 + 10.5 * at < t && t <= 6 + 10.5 * at)//第二天上午完成
                {
                    picker2 = strtime1.AddDays(at + 1).AddHours(t - (2 + 10.5 * at));
                }
                if (6 + 10.5 * at < t && t <= 10.5 + 10.5 * at)//第二天下午做完
                {
                    picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (6 + 10.5 * at));
                }

            }

            //当前时间大于18:00 小于20:00
            int ta14 = time1time.CompareTo(shijian5);
            int ta15 = shijian6.CompareTo(time1time);

            if (ta14 == 1 && (ta15 == 1 || ta15 == 0))
            {
                DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                picker1 = Convert.ToDateTime(strtime);
                DateTime strtimewuye = Convert.ToDateTime(time1date1 + " " + shijian6);//当前日期+20:00
                DateTime strtimewanshang = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00
                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00

                TimeSpan t1 = strtimewuye.AddDays(at) - strtime.AddDays(at);//晚上加工的时间
                if (t - 10.5 * at >= t1.TotalHours)//晚上不能加工完成
                {
                    double t2 = t - 10.5 * at - t1.TotalHours;//剩余加工的时间
                    if (t2 <= 4)//第二天上午可以完成
                    {
                        picker2 = strtime1.AddDays(at + 1).AddHours(t2);
                    }
                    if (4 < t2 && t2 <= 8.5)//第二天下午完成
                    {
                        picker2 = strtimexiawu.AddDays(at + 1).AddHours(t2 - 4);
                    }
                    if (8.5 < t2 && t2 <= 10.5)//第二天晚上完成
                    {
                        picker2 = strtimewanshang.AddDays(at + 1).AddHours(t2 - 8.5);
                    }
                }
                else
                {
                    picker2 = strtime.AddDays(at).AddHours(t - 10.5 * at);
                }
            }

            //当前时间大于20:00
            //第二天做(设置工序的时间大于17:30 -----> 即工艺员加班)
            int ta16 = time1time.CompareTo(shijian6);

            if (ta16 == 1)
            {
                DateTime strtime = Convert.ToDateTime(time1date1 + " " + time1time);//当前日期+时间
                DateTime strtime1 = Convert.ToDateTime(time1date1 + " " + shijian1);//当前日期+8:00
                picker1 = strtime1.AddDays(1);

                DateTime strtimexiawu = Convert.ToDateTime(time1date1 + " " + shijian3);//当前日期+13:00
                DateTime strtimewansahng = Convert.ToDateTime(time1date1 + " " + shijian5);//当前日期+18:00

                if (10.5 * at < t && t <= 10.5 * at + 4)
                {
                    picker2 = strtime1.AddDays(at + 1).AddHours(t - 10.5 * at);
                }
                if (4 + 10.5 * at < t && t <= 8.5 + 10.5 * at)
                {
                    picker2 = strtimexiawu.AddDays(at + 1).AddHours(t - (4 + 10.5 * at));
                }
                if (8.5 + 10.5 * at < t && t <= 10.5 + 10.5 * at)
                {
                    picker2 = strtimewansahng.AddDays(at + 1).AddHours(t - (8.5 + 10.5 * at));
                }
                


            }
            #endregion

            var tuple = new Tuple<DateTime, DateTime>(picker1, picker2);
            return tuple;
        }

        /// <summary>
        /// 插单排产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string gongxushebei = gridView1.GetRowCellValue(i, "工序设备").ToString();
                string gongxushunxu = gridView1.GetRowCellValue(i, "工序顺序").ToString();
                string gongxuxuhao = gridView1.GetRowCellValue(i, "序号").ToString();
                string gongxushuliang = gridView1.GetRowCellValue(i, "数量").ToString();
                string gongxujiage = gridView1.GetRowCellValue(i, "价格").ToString();
            }
        }
    }
}