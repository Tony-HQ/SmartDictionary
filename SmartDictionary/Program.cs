using SmartDictionary.DataAccess.Persistence;
using SmartDictionary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDictionary
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Run().Wait();
            Application.Run(new Form1());
        }

        public static async Task Run()
        {
            await DataSource.Init();
            var dao = new SentenceDao();
            await dao.SaveAsync(new Sentence { Key = "Qiang Huang", CreatedTime = DateTime.Now, LastUsedTime = DateTime.Now });
            var saved = await dao.GetByKeyAsync("Qiang Huang");
            Console.WriteLine(saved.Key);
        }

    }
}
