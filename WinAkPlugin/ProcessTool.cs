using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace WinAkPlugin
{
    public class ProcessTool
    {
        public static Action<string> ShowMsg;

        public static string ProecssCmd(string filename, string args = "")
        {
            Process process = new Process();
            if (filename.Contains(":"))
            {
                process.StartInfo.WorkingDirectory = filename.Substring(0, filename.LastIndexOf("\\") + 1);
            }

            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("gbk");

            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.WaitForExit();

            return null;
        }

        public static string RunCmd(string filename, string args = "")
        {
            Process process = new Process();
            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("gbk");

            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.WaitForExit();

            return null;
        }

        private static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (ShowMsg != null)
            {
                ShowMsg(e.Data);
            }
        }
    }
}
