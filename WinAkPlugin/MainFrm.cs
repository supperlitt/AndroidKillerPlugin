using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            // string de_apk_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, apkName);
            string dex2jar_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dex2jar", "dex2jar.bat");
            try
            {
                this.progressBar1.Value = 0;

                // 1、解压apk包
                File.Copy(apkPath, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apktool", apkName_andExtend));
                bool result = ZipHelper.UnZip(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apktool", apkName_andExtend), Path.Combine(tempDir, apkName));
                if (!result)
                {
                    this.ShowMsg("解压文件失败");

                    return;
                }

                this.progressBar1.Value = 10;

                // 2、apktool反编译apk包，-r不处理资源文件
                ProcessTool.ProecssCmd(apktool_path, "d -r -f \"" + apkName_andExtend + "\"");
                this.progressBar1.Value = 30;

                // 3、dex2jar 把apktool转成jar
                int size = 20;
                string[] files = Directory.GetFiles(Path.Combine(tempDir, apkName), "*.dex");
                int step = size / files.Length;
                for (int i = 0; i < files.Length; i++)
                {
                    string dexFile = files[i].Substring(files[i].LastIndexOf("\\") + 1);
                    File.Copy(files[i], Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dex2jar", dexFile));
                    ProcessTool.ProecssCmd(dex2jar_path, dexFile);

                    this.progressBar1.Value += step;
                }

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

                    ZipHelper.UnZip(jarFile, Path.Combine(tempDir, apkName, smaliName));
                    this.progressBar1.Value += step;
                }

                // 5、拷贝（合并）.smali和.class文件

                // 6、存放到ak指定位置

                // 7、完成
            }
            catch (Exception e)
            {
                this.ShowMsg("ex:" + e.ToString());
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
