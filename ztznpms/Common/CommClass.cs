using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using ztznpms.DAL;
using ztznpms.CusControl;

namespace ztznpms.Common
{
    class CommClass
    {
        private static SqlDataAdapter sda = null;
        public DataTable GetDataTable(string strTableName, string strWhere)
        {
            DataOperate dataOper = new DataOperate();
            string strSql = "Select * From " + strTableName + " " + strWhere;
            try
            {
                sda = new SqlDataAdapter(strSql, dataOper.Conn);
                new SqlCommandBuilder(sda);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }
        public bool Commit(BindingSource bs)  //与方法AddDataGridViewRow公用一个dt内存表
        {
            //因DataGridView控件无外部编辑动作，所以无需使用dgv.EndEdit()方法
            DataTable dt = bs.DataSource as DataTable;
            try
            {
                if (sda.Update(dt) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                return false;
            }
        }
        public bool Commit(DataGridView dgv, BindingSource bs)  //与方法AddDataGridViewRow公用一个dt内存表
        {
            dgv.EndEdit();
            bs.EndEdit();
            DataTable dt = bs.DataSource as DataTable;
            //因DataGridView控件无外部编辑动作，所以无需使用dgv.EndEdit()方法
            try
            {
                if (sda.Update(dt) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                return false;
            }
        }

//public bool jiancha()
//{
//    DataOperate dataOper = new DataOperate();
//    string strSql = "select * from tb_time where machine='"+加工中心+"'";
//    try
//    {
//        sda = new SqlDataAdapter(strSql, dataOper.Conn);
//        new SqlCommandBuilder(sda);
//        DataTable dt = new DataTable();
//        sda.Fill(dt);
//        return dt;
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.Message, "软件提示");
//        throw ex;
//    }
//}


public void ShowDialogForm(Type typeForm, string strTag, Form formParent)
        {
            Form form = Activator.CreateInstance(typeForm) as Form;
            form.Tag = strTag;
            form.Owner = formParent;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        public void ShowDialogForm(Type typeForm,  CTextBox ctx, Form formParent)
        {
            Form form = Activator.CreateInstance(typeForm) as Form;
            form.Tag = ctx;
            form.Owner = formParent;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        public void ShowFormByMdiParent(Type typeForm, Form formMdiParent)
        {
            Form form = Activator.CreateInstance(typeForm) as Form;
            form.MdiParent = formMdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        /// <summary>
        /// 生成各种数据表的代码字段的值
        /// </summary>
        /// <param name="strTableName">数据表名</param>
        /// <param name="strHeader">各种代码头</param>
        /// <param name="intLength">代码可变动部分的长度</param>
        /// <returns></returns>
        public string BuildCode(string strTableName, string strWhere, string strCodeColumn, string strHeader, int intLength)
        {
            DataOperate dataOper = new DataOperate();
            string strSql = "Select Max(" + strCodeColumn + ") From " + strTableName + " " + strWhere;
            try
            {
                string strMaxCode = dataOper.GetSingleObject(strSql) as string;
                if (String.IsNullOrEmpty(strMaxCode))
                {
                    strMaxCode = strHeader + FormatString(intLength);
                }
                string strMaxSeqNum = strMaxCode.Substring(strHeader.Length);
                return strHeader + (Convert.ToInt32(strMaxSeqNum) + 1).ToString(FormatString(intLength));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        /// <summary>
        /// 格式化具有流水性质的编号
        /// </summary>
        /// <param name="intLength"></param>
        /// <returns></returns>
        public string FormatString(int intLength)
        {
            string strFormat = String.Empty;
            for (int i = 0; i < intLength; i++)
            {
                strFormat = strFormat + "0";
            }
            return strFormat;
        }

        /// <summary>
        /// 控制可编辑控件的键盘输入，该方法限定控件只可以接收表示非负十进制数的字符
        /// </summary>
        /// <param name="e">为 KeyPress 事件提供数据</param>
        /// <param name="con">可编辑文本控件</param>
        public void InputNumeric(KeyPressEventArgs e, Control con)
        {
            //在可编辑控件的Text属性为空的情况下，不允许输入".字符"
            if (String.IsNullOrEmpty(con.Text) && e.KeyChar.ToString() == ".")
            {
                //把Handled设为true，取消KeyPress事件，防止控件处理按键
                e.Handled = true;
            }

            //可编辑控件不允许输入多个"."字符
            if (con.Text.Contains(".") && e.KeyChar.ToString() == ".")
            {
                e.Handled = true;
            }

            //在可编辑控件中，只可以输入“数字字符”、".字符" 、"字符"(删除键对应的字符)
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "")
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 控制可编辑控件的键盘输入，该方法限定控件只可以接收表示非负整数的字符
        /// </summary>
        /// <param name="e">为 KeyPress 事件提供数据</param>
        public void InputInteger(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "")
            {
                //把Handled设为true，取消KeyPress事件，防止控件处理按键
                e.Handled = true;
            }
        }

        public void SetFocus(KeyEventArgs e, Control con)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con.Focus();
            }
        }

        public DataGridViewRow AddDataGridViewRow(DataGridView dgv, BindingSource bs)
        {
            DataTable dt = bs.DataSource as DataTable;
            DataRow dr = dt.NewRow();
            try
            {
                dt.Rows.Add(dr);
                bs.DataSource = dt;
                dgv.DataSource = bs;
                int intRowIndex = dgv.RowCount-1 ;
                return dgv.Rows[intRowIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }

        }
        public DataRow AddDataRow( BindingSource bs)
        {
            DataTable dt = bs.DataSource as DataTable;
            DataRow dr = dt.NewRow();
            try
            {
                dt.Rows.Add(dr);
                return dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        /// <summary>
        /// 清空DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView控件</param>
        public void DataGridViewReset(DataGridView dgv)
        {
            if (dgv.DataSource != null)
            {
                //若DataGridView绑定的数据源为DataTable
                if (dgv.DataSource.GetType() == typeof(DataTable))
                {
                    DataTable dt = dgv.DataSource as DataTable;
                    dt.Clear();
                }

                //若DataGridView绑定的数据源为BindingSource
                if (dgv.DataSource.GetType() == typeof(BindingSource))
                {
                    BindingSource bs = dgv.DataSource as BindingSource;
                    DataTable dt = bs.DataSource as DataTable;
                    dt.Clear();
                }
            }
        }

        /// <summary>
        /// 通过Image得到字节数组
        /// </summary>
        /// <param name="img">Image对象的引用</param>
        /// <returns>字节数组</returns>
        public byte[] GetBytesByImage(Image img)
        {
            try
            {
                MemoryStream ms = new MemoryStream(); //实例化内存流
                new BinaryFormatter().Serialize(ms, img); //将对象图形序列化为给定流
                return ms.GetBuffer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        /// <summary>
        /// 将二进制数据转换为image图像
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>image图像的引用</returns>
        public Image GetImageByBytes(byte[] buffer)
        {
            try
            {
                //通过字节数组的到内存流
                MemoryStream ms = new MemoryStream(buffer);
                return new BinaryFormatter().Deserialize(ms) as Image;  //通过反序列化技术还原image图像
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }


        public bool GetCheckedValue(string strFlag)
        {
            if (strFlag == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetFlagValue(CheckState check)
        {
            if (check == CheckState.Checked)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// ListBox控件绑定到数据源
        /// </summary>
        /// <param name="cbx"></param>
        /// <param name="strValueColumn"></param>
        /// <param name="strDisplayColumn"></param>
        /// <param name="strSql"></param>
        /// <param name="strTableName"></param>
        public void ListBoxBindDataSource(ListBox lbx, string strValueColumn, string strDisplayColumn, string strSql, string strTableName)
        {
            DataOperate dataOper = new DataOperate();
            try
            {
                lbx.BeginUpdate();
                lbx.DataSource = dataOper.GetDataTable(strSql, strTableName);
                lbx.DisplayMember = strDisplayColumn;
                lbx.ValueMember = strValueColumn;
                lbx.EndUpdate();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "软件提示");
                throw e;
            }
        }

        /// <summary>
        /// 判断数据表中记录的主键值是否存在外键约束
        /// </summary>
        /// <param name="strPrimaryTable">主键表</param>
        /// <param name="strPrimaryValue">数据表中某条记录主键的值</param>
        /// <returns></returns>
        public bool IsExistConstraint(string strPrimaryTable, string strPrimaryValue)
        {
            DataOperate dataOper = new DataOperate();
            bool booIsExist = false;
            string strSql = null;
            string strForeignColumn = null;
            string strForeignTable = null;
            SqlDataReader sdr = null;
            try
            {
                //创建SqlParameter对象，并赋值
                SqlParameter param = new SqlParameter("@PrimaryTable", SqlDbType.VarChar);
                param.Value = strPrimaryTable;
                //创建泛型
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(param);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters = parameters.ToArray();
                //通过存储过程得到外键表的相关数据
                DataTable dt = dataOper.GetDataTable("P_QueryForeignConstraint", inputParameters);

                //循环这些相关数据
                foreach (DataRow dr in dt.Rows)
                {
                    strForeignTable = dr["ForeignTable"].ToString();
                    strForeignColumn = dr["ForeignColumn"].ToString();
                    strSql = "Select " + strForeignColumn + " From " + strForeignTable + " Where " + strForeignColumn + " = '" + strPrimaryValue + "'";
                    sdr = dataOper.GetDataReader(strSql);

                    if (sdr.HasRows)
                    {
                        booIsExist = true;
                        sdr.Close();
                        //跳出循环
                        break;
                    }

                    sdr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }

            return booIsExist;
        }


        public bool IsExistExpressBillCode(string strExpressBillCode,string strBillTypeCode)
        {
            DataOperate dataOper = new DataOperate();
            try
            {
                //创建泛型
                List<SqlParameter> parameters = new List<SqlParameter>();
                //创建SqlParameter对象，并赋值
                SqlParameter paramExpressBillCode = new SqlParameter("@ExpressBillCode", SqlDbType.VarChar);
                paramExpressBillCode.Value = strExpressBillCode;
                parameters.Add(paramExpressBillCode);
                //---
                SqlParameter paramBillTypeCode = new SqlParameter("@BillTypeCode", SqlDbType.VarChar);
                paramBillTypeCode.Value = strBillTypeCode;
                parameters.Add(paramBillTypeCode);
                //把泛型中的元素复制到数组中
                SqlParameter[] inputParameters = parameters.ToArray();
                DataTable dt = dataOper.GetDataTable("P_IsExistExpressBillCode", inputParameters);
                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }
    }
}