namespace ztznpms.UI.工序管理
{
    partial class Formsx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formsx));
            this.btn_chaxun1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerend1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerstart1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.图号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.价格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序顺序 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.负责人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实际操作人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开始时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结束时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序外协开始 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序外协结束 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.二维码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标记 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_chaxun1
            // 
            this.btn_chaxun1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_chaxun1.Location = new System.Drawing.Point(530, 19);
            this.btn_chaxun1.Name = "btn_chaxun1";
            this.btn_chaxun1.Size = new System.Drawing.Size(75, 23);
            this.btn_chaxun1.TabIndex = 12;
            this.btn_chaxun1.Text = "查询";
            this.btn_chaxun1.UseVisualStyleBackColor = true;
            this.btn_chaxun1.Click += new System.EventHandler(this.btn_chaxun1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 11;
            // 
            // dateTimePickerend1
            // 
            this.dateTimePickerend1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerend1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerend1.Location = new System.Drawing.Point(337, 21);
            this.dateTimePickerend1.Name = "dateTimePickerend1";
            this.dateTimePickerend1.Size = new System.Drawing.Size(159, 21);
            this.dateTimePickerend1.TabIndex = 10;
            // 
            // dateTimePickerstart1
            // 
            this.dateTimePickerstart1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerstart1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerstart1.Location = new System.Drawing.Point(91, 21);
            this.dateTimePickerstart1.Name = "dateTimePickerstart1";
            this.dateTimePickerstart1.Size = new System.Drawing.Size(151, 21);
            this.dateTimePickerstart1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "结束时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "开始时间：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.项目名称,
            this.工作令号,
            this.设备名称,
            this.编码,
            this.图号,
            this.名称,
            this.设备编号,
            this.数量,
            this.工序名称,
            this.价格,
            this.工序顺序,
            this.工序内容,
            this.负责人,
            this.实际操作人,
            this.开始时间,
            this.结束时间,
            this.工序外协开始,
            this.工序外协结束,
            this.二维码,
            this.标记});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1321, 676);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "项目名称";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.Width = 200;
            // 
            // 工作令号
            // 
            this.工作令号.DataPropertyName = "工作令号";
            this.工作令号.HeaderText = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.Width = 180;
            // 
            // 设备名称
            // 
            this.设备名称.DataPropertyName = "设备名称";
            this.设备名称.HeaderText = "设备名称";
            this.设备名称.Name = "设备名称";
            this.设备名称.Width = 150;
            // 
            // 编码
            // 
            this.编码.DataPropertyName = "编码";
            this.编码.HeaderText = "编码";
            this.编码.Name = "编码";
            // 
            // 图号
            // 
            this.图号.DataPropertyName = "图号";
            this.图号.HeaderText = "图号";
            this.图号.Name = "图号";
            this.图号.Width = 200;
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "名称";
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.Width = 200;
            // 
            // 设备编号
            // 
            this.设备编号.DataPropertyName = "设备编号";
            this.设备编号.HeaderText = "设备编号";
            this.设备编号.Name = "设备编号";
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            // 
            // 工序名称
            // 
            this.工序名称.DataPropertyName = "工序名称";
            this.工序名称.HeaderText = "工序名称";
            this.工序名称.Name = "工序名称";
            // 
            // 价格
            // 
            this.价格.DataPropertyName = "价格";
            this.价格.HeaderText = "价格(元/件)";
            this.价格.Name = "价格";
            // 
            // 工序顺序
            // 
            this.工序顺序.DataPropertyName = "工序顺序";
            this.工序顺序.HeaderText = "工序顺序";
            this.工序顺序.Name = "工序顺序";
            // 
            // 工序内容
            // 
            this.工序内容.DataPropertyName = "工序内容";
            this.工序内容.HeaderText = "工序内容";
            this.工序内容.Name = "工序内容";
            this.工序内容.Width = 200;
            // 
            // 负责人
            // 
            this.负责人.DataPropertyName = "负责人";
            this.负责人.HeaderText = "负责人";
            this.负责人.Name = "负责人";
            // 
            // 实际操作人
            // 
            this.实际操作人.DataPropertyName = "实际操作人";
            this.实际操作人.HeaderText = "实际操作人";
            this.实际操作人.Name = "实际操作人";
            // 
            // 开始时间
            // 
            this.开始时间.DataPropertyName = "开始时间";
            this.开始时间.HeaderText = "开始时间";
            this.开始时间.Name = "开始时间";
            this.开始时间.Width = 150;
            // 
            // 结束时间
            // 
            this.结束时间.DataPropertyName = "结束时间";
            this.结束时间.HeaderText = "结束时间";
            this.结束时间.Name = "结束时间";
            this.结束时间.Width = 150;
            // 
            // 工序外协开始
            // 
            this.工序外协开始.DataPropertyName = "工序外协开始";
            this.工序外协开始.HeaderText = "工序外协开始";
            this.工序外协开始.Name = "工序外协开始";
            this.工序外协开始.Visible = false;
            this.工序外协开始.Width = 200;
            // 
            // 工序外协结束
            // 
            this.工序外协结束.DataPropertyName = "工序外协结束";
            this.工序外协结束.HeaderText = "工序外协结束";
            this.工序外协结束.Name = "工序外协结束";
            this.工序外协结束.Visible = false;
            this.工序外协结束.Width = 200;
            // 
            // 二维码
            // 
            this.二维码.DataPropertyName = "二维码";
            this.二维码.HeaderText = "二维码";
            this.二维码.Name = "二维码";
            this.二维码.Visible = false;
            // 
            // 标记
            // 
            this.标记.DataPropertyName = "标记";
            this.标记.HeaderText = "标记";
            this.标记.Name = "标记";
            this.标记.Width = 300;
            // 
            // Formsx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 753);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_chaxun1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerend1);
            this.Controls.Add(this.dateTimePickerstart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formsx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "筛选数据";
            this.Load += new System.EventHandler(this.Formsx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_chaxun1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerend1;
        private System.Windows.Forms.DateTimePicker dateTimePickerstart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 图号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 价格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序顺序;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 负责人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实际操作人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开始时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序外协开始;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序外协结束;
        private System.Windows.Forms.DataGridViewTextBoxColumn 二维码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标记;
    }
}