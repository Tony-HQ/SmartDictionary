// Copyright © Qiang Huang, All rights reserved.

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SmartDictionary.DataAccess.Persistence;

namespace SmartDictionary
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataSource.Init().Wait();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "preferences.ini");
            IniFile.SetPath(path);
            IniFile.CreateIfNotExist();
            Application.Run(new MainForm());
        }
    }
}