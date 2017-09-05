// Copyright © Qiang Huang, All rights reserved.

using System;
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
            Application.Run(new Form1());
        }
    }
}