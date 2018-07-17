using ADDC_MVVM.iOS;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]
namespace ADDC_MVVM.iOS
{
    public class SqliteService : ISQLite
    {
        public SqliteService()
        {
        }
        #region ISQLite implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            //var sqliteFilename = "LocateUsNew1.sqlite";
            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            //string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            //var path = Path.Combine(libraryPath, sqliteFilename);

            //// This is where we copy in the prepopulated database
            //Console.WriteLine(path);
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}

            //var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            //var conn = new SQLite.Net.SQLiteConnection(plat, path);

            //// Return the database connection 
            //return conn;

			            var sqliteFilename = "LocateUsNew.sqlite";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder							  
			// This is where we copy in the prepopulated database
			 var path = Path.Combine(libraryPath, sqliteFilename);
			Console.WriteLine(path);
			if (!File.Exists(path))
			{
				File.Copy(sqliteFilename, path);
			}

			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Return the database connection 
			return conn;

			//var sqliteFilename = "SQLiteEx.db3";
			//string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			//string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			//var path = Path.Combine(libraryPath, sqliteFilename);

			//// This is where we copy in the prepopulated database
			//Console.WriteLine(path);
			//if (!File.Exists(path))
			//{
			//	File.Create(path);
			//}

			//var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			//var conn = new SQLite.Net.SQLiteConnection(plat, path);

			//// Return the database connection 
			//return conn;
        }
        #endregion
    }
}
