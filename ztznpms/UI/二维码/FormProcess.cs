using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ztznpms.UI.二维码
{
    public partial class FormProcess : DevExpress.XtraEditors.XtraForm
    {
        public FormProcess()
        {
            InitializeComponent();
        }

        private void FormProcess_Load(object sender, EventArgs e)
        {

        }

        public void SetProgressValue(int value)
        {
            this.progressBar1.Value = value;
            this.label1.Text =  value.ToString() + "%";

            // 这里关闭，比较好，呵呵！
            if (value == this.progressBar1.Maximum - 1) this.Close();
        }
        

    }
}