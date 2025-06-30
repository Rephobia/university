using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace lab3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--init-db")
            {
                InitializeDatabase();
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        static void InitializeDatabase()
        {
            Console.WriteLine("Запуск инициализации базы данных...");

            using var db = new AppDbContext();
            string sql = File.ReadAllText("init.sql");
            db.Database.ExecuteSqlRaw(sql);

            Console.WriteLine("База данных инициализирована.");
        }
    }
}

