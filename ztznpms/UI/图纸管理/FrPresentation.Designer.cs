namespace ztznpms.UI.图纸管理
{
    partial class FrPresentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrPresentation));
            this.btn_xztz = new System.Windows.Forms.Button();
            this.btn_sctz = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_xztz
            // 
            this.btn_xztz.Location = new System.Drawing.Point(61, 82);
            this.btn_xztz.Name = "btn_xztz";
            this.btn_xztz.Size = new System.Drawing.Size(75, 23);
            this.btn_xztz.TabIndex = 0;
            this.btn_xztz.Text = "选择图纸";
            this.btn_xztz.UseVisualStyleBackColor = true;
            this.btn_xztz.Click += new System.EventHandler(this.btn_xztz_Click);
            // 
            // btn_sctz
            // 
            this.btn_sctz.Location = new System.Drawing.Point(337, 153);
            this.btn_sctz.Name = "btn_sctz";
            this.btn_sctz.Size = new System.Drawing.Size(75, 23);
            this.btn_sctz.TabIndex = 1;
            this.btn_sctz.Text = "上传图纸";
            this.btn_sctz.UseVisualStyleBackColor = true;
            this.btn_sctz.Click += new System.EventHandler(this.btn_sctz_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 84);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(252, 21);
            this.txtName.TabIndex = 2;
            // 
            // FrPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 232);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btn_sctz);
            this.Controls.Add(this.btn_xztz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrPresentation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上传图纸";
            this.Load += new System.EventHandler(this.FrPresentation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_xztz;
        private System.Windows.Forms.Button btn_sctz;
        private System.Windows.Forms.TextBox txtName;
    }
}