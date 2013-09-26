/* *
 * 
 *  Gekko Stocks Web Service
 *  Robert Petre
 *  
 * */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;

namespace StoXService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Gekko : IService1
    {

        //Return all existing indexes.
        public List<string> GetIndexes()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnString"].ToString());
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT Symbol FROM TodayStock", con);
            SqlDataReader sread = null;
            sread = sqlCmd.ExecuteReader();
            if (!sread.HasRows) return null;
            List<string> Result = new List<string>();
            while (sread.Read())
            {
                Result.Add(sread["Symbol"].ToString());
            }
            con.Close();
            return Result;
        }
        //Returns a list of companies matching the search phrase. Null if there is no result.
        public List<Company> Search(string phrase)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnString"].ToString());
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM TodayStock WHERE Name LIKE @Phrase OR Symbol LIKE @Phrase", con);
            sqlCmd.Parameters.AddWithValue("@Phrase", "%"+phrase+"%");
            SqlDataReader sread = null;
            sread = sqlCmd.ExecuteReader();
            if (!sread.HasRows) return null;
            List<Company> ResultList = new List<Company>();           
            while (sread.Read())
            {
                Company Result = new Company();
                Result.Name = sread["Name"].ToString();
                Result.Symbol = sread["Symbol"].ToString();
                Result.Datetime = Convert.ToDateTime(sread["Datetime"].ToString());
                Result.CurrentPrice = Convert.ToDouble(sread["CurrentPrice"].ToString());
                Result.ChangeValue = Convert.ToDouble(sread["ChangeValue"].ToString());
                Result.ChangePercent = Convert.ToDouble(sread["ChangePercent"].ToString());
                Result.PreviousClose = Convert.ToDouble(sread["PreviousClose"].ToString());
                Result.Open = Convert.ToDouble(sread["Open"].ToString());
                Result.Volume = Convert.ToInt32(sread["Volume"].ToString());
                Result.DayMinPrice = Convert.ToDouble(sread["DayMinPrice"].ToString());
                Result.DayMaxPrice = Convert.ToDouble(sread["DayMaxPrice"].ToString());
                Result.YearMinPrice = Convert.ToDouble(sread["YearMinPrice"].ToString());
                Result.YearMaxPrice = Convert.ToDouble(sread["YearMaxPrice"].ToString());
                ResultList.Add(Result);
            }
            con.Close();
            return ResultList;
        }

        //Returns all information about the company matching the provided index. If no company exists it returns Null.
        public Company GetInfo(string index)
        {           
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnString"].ToString());
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM TodayStock WHERE Symbol=@Symbol", con);
            sqlCmd.Parameters.AddWithValue("@Symbol", index);
            SqlDataReader sread = null;
            sread = sqlCmd.ExecuteReader();
            if (!sread.HasRows) return null;
            Company Result = new Company();
            while (sread.Read())
            {
                Result.Name = sread["Name"].ToString();
                Result.Symbol = sread["Symbol"].ToString();
                Result.Datetime = Convert.ToDateTime(sread["Datetime"].ToString());
                Result.CurrentPrice = Convert.ToDouble(sread["CurrentPrice"].ToString());
                Result.ChangeValue = Convert.ToDouble(sread["ChangeValue"].ToString());
                Result.ChangePercent = Convert.ToDouble(sread["ChangePercent"].ToString());
                Result.PreviousClose = Convert.ToDouble(sread["PreviousClose"].ToString());
                Result.Open = Convert.ToDouble(sread["Open"].ToString());
                Result.Volume = Convert.ToInt32(sread["Volume"].ToString());
                Result.DayMinPrice = Convert.ToDouble(sread["DayMinPrice"].ToString());
                Result.DayMaxPrice = Convert.ToDouble(sread["DayMaxPrice"].ToString());
                Result.YearMinPrice = Convert.ToDouble(sread["YearMinPrice"].ToString());
                Result.YearMaxPrice = Convert.ToDouble(sread["YearMaxPrice"].ToString());
            }
            con.Close();
            return Result;
        }       
    }
}
