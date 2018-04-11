using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinAkPlugin
{
    public partial class MainFrm : Form
    {
        private static string tempDir = string.Empty;
        private static bool isFullSmali = true;

        public MainFrm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            this.btnReverse.Enabled = false;
            isFullSmali = this.chkMerge.Checked;
            Thread t = new Thread(Execute);
            t.IsBackground = true;
            t.Start();
        }

        private void Execute()
        {
            string apkPath = this.txtFile.Text;
            string apkName_andExtend = apkPath.Substring(apkPath.LastIndexOf("\\") + 1);
            string apkName = apkPath.Substring(apkPath.LastIndexOf("\\") + 1, apkPath.Length - apkPath.LastIndexOf("\\") - 5);
            string apktool_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apktool", "apktool.bat");
            string dex2jar_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dex2jar", "dex2jar.bat");
            try
            {
                this.progressBar1.Value = 0;

                // 1、拷贝，解压apk包
                string target_apk_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apktool", apkName_andExtend);
                string target_apk_dir_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apktool", apkName);
                if (this.chkCopyApk.Checked)
                {
                    this.ShowMsg("拷贝apk到目录下");
                    File.Copy(apkPath, target_apk_path, true);
                }

                string tempPath = Path.Combine(tempDir, apkName);
                if (this.chkUnzipApk.Checked)
                {
                    this.ShowMsg("开始解压apk");
                    bool result = ZipHelper.UnZip(target_apk_path, tempPath);
                    if (!result)
                    {
                        this.ShowMsg("解压文件失败");

                        return;
                    }
                }

                this.progressBar1.Value = 10;

                // 2、apktool反编译apk包，-r不处理资源文件
                if (this.chkApktool.Checked)
                {
                    this.ShowMsg("对apk执行apktool命令");
                    ProcessTool.ProecssCmd(apktool_path, "d -r -f " + apkName_andExtend);
                }

                this.progressBar1.Value = 30;

                // 3、dex2jar 把apktool转成jar
                string[] files = Directory.GetFiles(Path.Combine(tempDir, apkName), "*.dex");
                int size = 25;
                int step = size / files.Length;
                if (this.chkDex2jar.Checked)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        string dexFile = files[i].Substring(files[i].LastIndexOf("\\") + 1);

                        this.ShowMsg("拷贝：" + dexFile + "；并执行dex2jar命令");
                        File.Copy(files[i], Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dex2jar", dexFile));
                        ProcessTool.ProecssCmd(dex2jar_path, dexFile);

                        this.progressBar1.Value += step;
                    }
                }

                if (this.chkUnzipjar.Checked)
                {
                    // 4、解压jar
                    for (int i = 0; i < files.Length; i++)
                    {
                        string dexFile = files[i].Substring(files[i].LastIndexOf("\\") + 1);
                        string jarFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dex2jar", dexFile.Substring(0, dexFile.Length - 4) + "_dex2jar.jar");

                        string smaliName = "smali";
                        if (i >= 1)
                        {
                            smaliName = "smali_classes" + (i + 1);
                        }

                        this.ShowMsg("解压jar文件");
                        ZipHelper.UnZip(jarFile, Path.Combine(tempDir, apkName, smaliName));
                        this.progressBar1.Value += step;
                    }
                }

                // 5、拷贝（合并）.smali和.class文件
                // 6、存放到ak指定位置
                string akpath = ConfigurationManager.AppSettings["akpath"];
                string apkprojectPath = Path.Combine(akpath, "projects", apkName);
                string projectSrcPath = Path.Combine(apkprojectPath, "ProjectSrc");
                string projectPath = Path.Combine(apkprojectPath, "Project");
                if (this.chkCopyToAkSrc.Checked)
                {
                    this.ShowMsg("复制.class文件到，AK项目projectsrc目录下");
                    if (Directory.Exists(apkprojectPath))
                    {
                        // 拷贝.class相关内容到projectsrc中
                        for (int i = 0; i < files.Length; i++)
                        {
                            string smaliName = "smali";
                            if (i >= 1)
                            {
                                smaliName = "smali_classes" + (i + 1);
                            }

                            string smaliPath = Path.Combine(tempDir, apkName, smaliName);
                            ProcessTool.RunCmd("xcopy", "\"" + smaliPath + "\" \"" + Path.Combine(projectSrcPath, smaliName) + "\\\" /e /y");
                        }

                        this.progressBar1.Value += 10;
                    }
                }

                if (this.chkCopyToAkProject.Checked)
                {
                    this.ShowMsg("复制apktool解包文件到，AK项目project目录下");
                    if (Directory.Exists(apkprojectPath) && Directory.Exists(target_apk_dir_path))
                    {
                        string[] fis = Directory.GetFiles(target_apk_dir_path);
                        foreach (var f in fis)
                        {
                            // 拷贝apktool目录到Project
                            ProcessTool.RunCmd("xcopy", "\"" + f + "\" \"" + projectPath + "\\\" /e /y");
                        }

                        string[] dirs = Directory.GetDirectories(target_apk_dir_path);
                        foreach (var dir in dirs)
                        {
                            string dirName = dir.Substring(dir.LastIndexOf("\\") + 1);

                            // 拷贝apktool目录到Project
                            ProcessTool.RunCmd("xcopy", "\"" + dir + "\" \"" + Path.Combine(projectPath, dirName) + "\\\" /e /y");
                        }

                        this.progressBar1.Value += 10;
                    }
                }

                if (chkMerge.Checked)
                {
                    this.ShowMsg("合并所有smali和class文件到一个文件夹下");

                }

                // 7、完成
                this.ShowMsg("全部执行完成");
            }
            catch (Exception e)
            {
                this.ShowMsg("出现异常:" + e.ToString());
            }
            finally
            {
                this.progressBar1.Value = 100;
                this.btnReverse.Enabled = true;
            }
        }

        private void ShowMsg(string msg)
        {
            this.Invoke(new Action<TextBox>(p =>
            {
                if (p.TextLength > 30000)
                {
                    p.Clear();
                }

                p.AppendText(msg + "\r\n");
            }), this.txtContent);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            tempDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            ProcessTool.ShowMsg += ShowMsg;
        }

        private void btnSelectApk_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "安卓文件|*.apk";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = dialog.FileName;
            }
        }
    }
}
