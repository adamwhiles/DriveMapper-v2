using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication1
{
    class nextDrive
    {
        public static string GetNextDriveLetter()
        {
            List<string> InUse = new List<string>();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
                InUse.Add(drive.Name.Substring(0, 1).ToUpper());

            char[] alphas = "EFGHIJKLMNOPQRSTUVWXY".ToCharArray();

            foreach (char alpha in alphas)
                if (!InUse.Contains(alpha.ToString())) return alpha.ToString();

            return null;
        }
    }
}