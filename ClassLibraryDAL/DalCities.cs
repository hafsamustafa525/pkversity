using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassLibraryEntities;

namespace ClassLibraryDAL
{
    public class DalCities
    {
        public static List<EntCities> GetCities()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntCities> CitiesList = new List<EntCities>();
            while (sdr.Read())
            {
                EntCities ee = new EntCities();
                ee.CityId = sdr["CityId"].ToString();
                ee.CityName = sdr["CityName"].ToString();
                ee.CityCode = sdr["CityCode"].ToString();
                CitiesList.Add(ee);
            }
            con.Close();
            return CitiesList;
        }


        //GetCityById
        public static EntCities GetCityById(string CityId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCityById", con);
            cmd.Parameters.AddWithValue("@CityId", CityId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntCities ee = new EntCities();
            while (sdr.Read())
            {
                ee.CityId = sdr["CityId"].ToString();
                ee.CityName = sdr["CityName"].ToString();
                ee.CityCode = sdr["CityCode"].ToString();
            }
            con.Close();
            return ee;
        }

        public static void SaveCities(EntCities ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveCities", con);
            cmd.Parameters.AddWithValue("@CityName", ee.CityName);
            cmd.Parameters.AddWithValue("@CityCode", ee.CityCode);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public static void DeleteCities(string CityId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteCities", con);
            cmd.Parameters.AddWithValue("@CityId", int.Parse(CityId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void UpdateCities(EntCities ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateCities", con);
            cmd.Parameters.AddWithValue("@CityId", int.Parse(ee.CityId));
            cmd.Parameters.AddWithValue("@CityName", ee.CityName);
            cmd.Parameters.AddWithValue("@CityCode", ee.CityCode);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }




}
