using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ztznpms.DAL;
using ztznpms.Common;

namespace ztznpms.CusControl
{

    //自定义控件CTextBox扩展自TextBox
    public partial class CTextBox : TextBox
    {
        bool isMoving = false;//定义一个bool型变量，表示鼠标按下标记
        Point offset;//声明一个Point类型引用，表示光标位置
        int intWidth;//定义一个整形变量，表示控件的宽度
        //控件的构造器
        public CTextBox()
        {
            InitializeComponent();
        }
        //定义一个方法，作为自定义控件CTextBox的鼠标按下事件的绑定方法
        private void CTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;//表示鼠标按下
            offset = new Point(e.X, e.Y);//创建光标位置对象
            intWidth = this.Width;//获取控件的初始宽度值
        }
        private string m_IsFlag;
        //定义一个属性，用于表示当前控件是否为单据编号控件
        public string IsFlag
        {
            get
            { return m_IsFlag; }
            set
            { m_IsFlag = value; }
        }


        private Form m_FormParent;
        public Form FormParent
        {
            get
            {
                return m_FormParent;
            }
            set
            {
                m_FormParent = value;
            }
        }

        private int m_ControlId;
        public int ControlId
        {
            get
            {
                return m_ControlId;
            }
            set
            {
                m_ControlId = value;
            }
        }

        private string m_ControlName;
        public string ControlName
        {
            get
            {
                return m_ControlName;
            }
            set
            {
                m_ControlName = value;
            }
        }

        private string m_TurnControlName;
        public string TurnControlName
        {
            get
            {
                return m_TurnControlName;
            }
            set
            {
                m_TurnControlName = value;
            }
        }

        private string m_DefaultValue;
        public string DefaultValue
        {
            get
            {
                return m_DefaultValue;
            }
            set
            {
                m_DefaultValue = value;
            }
        }

        public List<CTextBox> GetCTextBoxes(Control control)
        {
            List<CTextBox> ctxts = new List<CTextBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CTextBox))
                {
                    ctxts.Add((CTextBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCTextBoxes(con);
                }
            }
            return ctxts;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        //自定义控件的鼠标移动事件绑定方法
        private void CTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                //根据鼠标移动动态地设置控件的位置
                if (this.Cursor == System.Windows.Forms.Cursors.SizeAll)
                {
                    this.Location = new Point(this.Location.X + (e.X - offset.X),
                        this.Location.Y + (e.Y - offset.Y));
                }
                //根据鼠标移动动态地设置控件宽度
                if (this.Cursor == System.Windows.Forms.Cursors.SizeWE)
                {
                    this.Width = intWidth + (e.X - offset.X);
                }
                this.BackColor = Color.Red;
            }
            else
                this.BackColor = Color.White;
        }

        private void CTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void toolDeleteCTextBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (ControlId != 0)  //旧的控件
                {
                    CommClass cc = new CommClass();
                    DataOperate dataOper = new DataOperate();
                    try
                    {
                        if (cc.IsExistConstraint("tb_BillTemplate", ControlId.ToString()))  //对应的子表tb_BillText已生成外键数据，先删除外键记录
                        {
                            if (MessageBox.Show("该输入框已生成快递单数据，若继续执行将删除与之相关的数据，是否继续执行？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                return;  //停止执行
                            }
                        }
                        if (dataOper.ExecDataBySql("Delete From tb_BillTemplate Where ControlId = '" + ControlId + "'") == 0)  //从模板表中删除该控件对应的记录
                        {
                            MessageBox.Show("删除失败！", "软件提示");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "软件提示");
                        return;
                    }
                }
                this.Dispose();
                MessageBox.Show("删除成功！", "软件提示");
            }
        }

        //设置快递单号输入框"
        private void toolSetFlag_Click(object sender, EventArgs e)
        {
            List<CTextBox> ctxts = GetCTextBoxes(this.FormParent);
            foreach (CTextBox ctxt in ctxts)
            {
                if (ctxt.IsFlag == "1")
                {
                    ctxt.Text = "请输入名称";
                }
                ctxt.IsFlag = "0";
            }
            this.IsFlag = "1";
            this.Text = "快递单号输入框";
        }

        
    }
}
