using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WinAkPlugin
{
    public class RarHelper
    {
        public static bool UnZip(string sourcePath, string targetDir)
        {
            try
            {
                string rarPath = ConfigurationManager.AppSettings["zip"];
                ProcessTool.ProecssCmd(rarPath, "x \"" + sourcePath + "\" \"" + targetDir + "\"");

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
