// Copyright © Qiang Huang, All rights reserved.

using System.Runtime.InteropServices;
using System.Text;

namespace SmartDictionary.DataAccess.Persistence
{
    public static class IniFile
    {
        public static void CreateIfNotExist()
        {
            if (System.IO.File.Exists(Path)) return;
            System.IO.File.Create(Path);
            WritePrivateProfileString("togglehotkey", "modifier1", "Alt", Path);
            WritePrivateProfileString("togglehotkey", "key", "C", Path);
            WritePrivateProfileString("savehotkey", "modifier1", "Ctrl", Path);
            WritePrivateProfileString("savehotkey", "modifier2", "Alt", Path);
            WritePrivateProfileString("savehotkey", "key", "C", Path);
        }

        public static void SetPath(string iniPath)
        {
            Path = iniPath;
        }

        public static string IniReadValue(string section, string key)
        {
            var temp = new StringBuilder(255);
            var i = GetPrivateProfileString(section, key, "", temp, 255, Path);
            return temp.ToString();
        }

        public static void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        public static string Path;
    }
}