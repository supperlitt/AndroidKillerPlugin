namespace WinAkPlugin
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSelectApk = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.chkMerge = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(13, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(460, 21);
            this.txtFile.TabIndex = 0;
            // 
            // btnSelectApk
            // 
            this.btnSelectApk.Location = new System.Drawing.Point(493, 13);
            this.btnSelectApk.Name = "btnSelectApk";
            this.btnSelectApk.Size = new System.Drawing.Size(75, 23);
            this.btnSelectApk.TabIndex = 1;
            this.btnSelectApk.Text = "浏览...";
            this.btnSelectApk.UseVisualStyleBackColor = true;
            this.btnSelectApk.Click += new System.EventHandler(this.btnSelectApk_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(13, 50);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(98, 23);
            this.btnReverse.TabIndex = 1;
            this.btnReverse.Text = "辅助创建工程";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 81);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(556, 218);
            this.txtContent.TabIndex = 0;
            // 
            // chkMerge
            // 
            this.chkMerge.AutoSize = true;
            this.chkMerge.Checked = true;
            this.chkMerge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMerge.Location = new System.Drawing.Point(129, 57);
            this.chkMerge.Name = "chkMerge";
            this.chkMerge.Size = new System.Drawing.Size(78, 16);
            this.chkMerge.TabIndex = 2;
            this.chkMerge.Text = "合并smali";
            this.chkMerge.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 306);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 335);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkMerge);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnSelectApk);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtFile);
            this.Name = "MainFrm";
            this.Text = "辅助解压APK";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSelectApk;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.CheckBox chkMerge;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

