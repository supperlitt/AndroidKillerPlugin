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
            this.chkCopyApk = new System.Windows.Forms.CheckBox();
            this.chkUnzipApk = new System.Windows.Forms.CheckBox();
            this.chkApktool = new System.Windows.Forms.CheckBox();
            this.chkDex2jar = new System.Windows.Forms.CheckBox();
            this.chkUnzipjar = new System.Windows.Forms.CheckBox();
            this.chkCopyToAkSrc = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCopyToAkProject = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.btnReverse.Text = "执行选中功能";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 156);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(556, 143);
            this.txtContent.TabIndex = 0;
            // 
            // chkMerge
            // 
            this.chkMerge.AutoSize = true;
            this.chkMerge.Location = new System.Drawing.Point(22, 20);
            this.chkMerge.Name = "chkMerge";
            this.chkMerge.Size = new System.Drawing.Size(108, 16);
            this.chkMerge.TabIndex = 2;
            this.chkMerge.Text = "合并smali和jar";
            this.chkMerge.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 306);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // chkCopyApk
            // 
            this.chkCopyApk.AutoSize = true;
            this.chkCopyApk.Location = new System.Drawing.Point(13, 88);
            this.chkCopyApk.Name = "chkCopyApk";
            this.chkCopyApk.Size = new System.Drawing.Size(66, 16);
            this.chkCopyApk.TabIndex = 4;
            this.chkCopyApk.Text = "拷贝apk";
            this.chkCopyApk.UseVisualStyleBackColor = true;
            // 
            // chkUnzipApk
            // 
            this.chkUnzipApk.AutoSize = true;
            this.chkUnzipApk.Location = new System.Drawing.Point(17, 20);
            this.chkUnzipApk.Name = "chkUnzipApk";
            this.chkUnzipApk.Size = new System.Drawing.Size(66, 16);
            this.chkUnzipApk.TabIndex = 4;
            this.chkUnzipApk.Text = "解压apk";
            this.chkUnzipApk.UseVisualStyleBackColor = true;
            // 
            // chkApktool
            // 
            this.chkApktool.AutoSize = true;
            this.chkApktool.Location = new System.Drawing.Point(17, 20);
            this.chkApktool.Name = "chkApktool";
            this.chkApktool.Size = new System.Drawing.Size(66, 16);
            this.chkApktool.TabIndex = 4;
            this.chkApktool.Text = "apktool";
            this.chkApktool.UseVisualStyleBackColor = true;
            // 
            // chkDex2jar
            // 
            this.chkDex2jar.AutoSize = true;
            this.chkDex2jar.Location = new System.Drawing.Point(104, 20);
            this.chkDex2jar.Name = "chkDex2jar";
            this.chkDex2jar.Size = new System.Drawing.Size(66, 16);
            this.chkDex2jar.TabIndex = 4;
            this.chkDex2jar.Text = "dex2jar";
            this.chkDex2jar.UseVisualStyleBackColor = true;
            // 
            // chkUnzipjar
            // 
            this.chkUnzipjar.AutoSize = true;
            this.chkUnzipjar.Location = new System.Drawing.Point(178, 20);
            this.chkUnzipjar.Name = "chkUnzipjar";
            this.chkUnzipjar.Size = new System.Drawing.Size(66, 16);
            this.chkUnzipjar.TabIndex = 4;
            this.chkUnzipjar.Text = "解压jar";
            this.chkUnzipjar.UseVisualStyleBackColor = true;
            // 
            // chkCopyToAkSrc
            // 
            this.chkCopyToAkSrc.AutoSize = true;
            this.chkCopyToAkSrc.Location = new System.Drawing.Point(259, 20);
            this.chkCopyToAkSrc.Name = "chkCopyToAkSrc";
            this.chkCopyToAkSrc.Size = new System.Drawing.Size(84, 16);
            this.chkCopyToAkSrc.TabIndex = 4;
            this.chkCopyToAkSrc.Text = "拷贝到AK下";
            this.chkCopyToAkSrc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUnzipApk);
            this.groupBox1.Controls.Add(this.chkDex2jar);
            this.groupBox1.Controls.Add(this.chkCopyToAkSrc);
            this.groupBox1.Controls.Add(this.chkUnzipjar);
            this.groupBox1.Location = new System.Drawing.Point(161, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "补全多个dex";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkApktool);
            this.groupBox2.Controls.Add(this.chkCopyToAkProject);
            this.groupBox2.Location = new System.Drawing.Point(161, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 49);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排除资源重新apktool";
            // 
            // chkCopyToAkProject
            // 
            this.chkCopyToAkProject.AutoSize = true;
            this.chkCopyToAkProject.Location = new System.Drawing.Point(104, 20);
            this.chkCopyToAkProject.Name = "chkCopyToAkProject";
            this.chkCopyToAkProject.Size = new System.Drawing.Size(84, 16);
            this.chkCopyToAkProject.TabIndex = 4;
            this.chkCopyToAkProject.Text = "拷贝到AK下";
            this.chkCopyToAkProject.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMerge);
            this.groupBox3.Location = new System.Drawing.Point(388, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(177, 49);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "合并";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 335);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCopyApk);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnSelectApk);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtFile);
            this.Name = "MainFrm";
            this.Text = "辅助解压APK（配置文件需要配置ak路径）";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkCopyApk;
        private System.Windows.Forms.CheckBox chkUnzipApk;
        private System.Windows.Forms.CheckBox chkApktool;
        private System.Windows.Forms.CheckBox chkDex2jar;
        private System.Windows.Forms.CheckBox chkUnzipjar;
        private System.Windows.Forms.CheckBox chkCopyToAkSrc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkCopyToAkProject;
    }
}

