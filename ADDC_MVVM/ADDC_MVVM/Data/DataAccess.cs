using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Resx;
using System.Diagnostics;

namespace ADDC_MVVM
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        string lang="en";
		string tableName = AppResource.LocateUSEng;
        string allServices = "All";
        string branch = AppResource.str_locate_branch;
        string kiosk = AppResource.str_locate_kiosk;
        string partners = AppResource.str_locate_partner;
        public DataAccess()
        {
            //if (lang.equalsIgnoreCase("ar"))
            //{
            //    tableName = "LocateUs_Ara";
            //}
            //else if (lang.equalsIgnoreCase("en"))
            //{
            //    tableName = "LocateUSEng";//"LocateUs_Eng";
            //}

            dbConn = Xamarin.Forms.DependencyService.Get<ISQLite>().GetConnection();

            // create the table(s)
            //dbConn.CreateTable<LocateUSEng>();
            //dbConn.CreateTable<LocateUs_Ara>();
        }
        public string regionLst
        { get; set; }
		public async Task <List<LocateUsBean>> GetAll(string tableName)
        {           
			var resul =  dbConn.Query<LocateUsBean>("SELECT DISTINCT Services FROM " + tableName + " ORDER BY Services ASC");
			return resul;
           
        } 
        public List<String> getOtherServices(String selectedPos, String tableName) //position
        {
            return dbConn.Query<String>("SELECT DISTINCT Services FROM " + tableName + " WHERE BKPLocation =? " , selectedPos + "ORDER BY Services ASC");
           //  

        }
        public async Task<List<LocateUsBean>> getAllServices(String tableName)
        {
                return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName);
         }

        //
        public List<LocateUsBean> getSelectedServices(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  "WHERE Services = ?" , selectedPos);
        }

        public List<LocateUsBean> getBranches(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName + 
			                                  " WHERE Services =? AND BKP1 =?"  , selectedPos , branch);
        }
        public List<LocateUsBean> getKiosks(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE Services =? AND BKP1=?" , selectedPos , kiosk );
        }

        public List<LocateUsBean> getPartners(String selectedPos, String tableName)
        {
			return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName + 
			                                  " WHERE Services =? AND BKP1=?", selectedPos , partners);
       
		}

        public List<LocateUsBean> getBrachesAndKiosks(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE Services=? AND (BKP1=? OR BKP1=?)", selectedPos , branch, kiosk );
        }
        public List<LocateUsBean> getBrachesAndParners(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE Services=? AND (BKP1=? OR BKP1=?)", selectedPos , branch, partners );
        }
        public List<LocateUsBean> getKiosksAndPartners(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName 
			                                  + " WHERE Services=? AND (BKP1=? OR BKP1=?)", selectedPos ,kiosk,partners);
        }

        public List<LocateUsBean> getSetviceBrachAndKioskListAndPartners(String selectedPos, String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName + 
			                                  " WHERE Services=? AND (BKP1 =? OR BKP1 =? OR BKP1 =?)" , selectedPos ,branch, kiosk, partners );
        }

        public List<LocateUsBean> getAllBranches(String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE BKP1=?" , branch);
        }

        public List<LocateUsBean> getAllPartners(String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE BKP1=?", partners);
        }
        public List<LocateUsBean> getAllKiosk(String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE BKP1=?", kiosk);
        }
        public List<LocateUsBean> getAllBrachesAndParners(String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName + 
			                                  " WHERE BKP1 =? OR BKP1 =?", branch, partners);
        }
        public List<LocateUsBean> getAllKiosksAndPartners(String tableName)
        {
            return dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1,BKPLocation,Latitude,Longitude,OpenDays,Timings,Address,Phone FROM " + tableName +
			                                  " WHERE BKP1 =? OR BKP1 =?", kiosk, partners);
        }

        public List<LocateUsBean> getAllBrachesAndKiosks(String tableName)
        {
			var query = dbConn.Query<LocateUsBean>("SELECT DISTINCT BKP1, BKPLocation, Latitude, Longitude, OpenDays, Timings, Address, Phone FROM " + tableName +
			                                       " WHERE BKP1 =? OR BKP1 =?",branch,kiosk );
			return query;
        }
    }
}
