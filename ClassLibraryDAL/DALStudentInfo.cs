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
    public class DALStudentInfo
    {


        public static List<EntStudentInfo> GetStudentInfo()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntStudentInfo> CitiesList = new List<EntStudentInfo>();
            while (sdr.Read())
            {
                EntStudentInfo ee = new EntStudentInfo();
                ee.FirstName = sdr["FirstName"].ToString();
                ee.LastName = sdr["LastName"].ToString();
                ee.Gender = sdr["Gender"].ToString();
                ee.CNIC = sdr["CNIC"].ToString();
                ee.DateOfBirth = sdr["DateOfBirth"].ToString();
                ee.City = sdr["City"].ToString();
                ee.Address = sdr["Address"].ToString();
                ee.StudentMobileNo = sdr["StudentMobileNo"].ToString();
                ee.Email = sdr["Email"].ToString();
                CitiesList.Add(ee);
            }
            con.Close();
            return CitiesList;
        }


        //GetCityById
        public static EntStudentInfo GetStudentInfoByID(string CityId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCityById", con);
            cmd.Parameters.AddWithValue("@CityId", CityId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntStudentInfo ee = new EntStudentInfo();
            while (sdr.Read())
            {
                
                ee.FirstName = sdr["FirstName"].ToString();
                ee.LastName = sdr["LastName"].ToString();
                ee.Gender = sdr["Gender"].ToString();
                ee.CNIC = sdr["CNIC"].ToString();
                ee.DateOfBirth =sdr["DateOfBirth"].ToString();
                ee.City = sdr["City"].ToString();
                ee.Address = sdr["Address"].ToString();
                ee.StudentMobileNo = sdr["StudentMobileNo"].ToString();
                ee.Email = sdr["Email"].ToString();
            }
            con.Close();
            return ee;
        }

        public static void SaveStudentInfo(EntStudentInfo ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveStudentInfo", con);
            cmd.Parameters.AddWithValue("@FirstName", ee.FirstName);
            cmd.Parameters.AddWithValue("@FatherName", ee.FatherName);
            cmd.Parameters.AddWithValue("@Gender", ee.Gender);
            cmd.Parameters.AddWithValue("@CNIC", ee.CNIC);
            cmd.Parameters.AddWithValue("@DateOfBirth", ee.DateOfBirth);
            cmd.Parameters.AddWithValue("@City", ee.City);
            cmd.Parameters.AddWithValue("@Address", ee.Address);
            cmd.Parameters.AddWithValue("@StudentMobileNo", ee.StudentMobileNo);
            cmd.Parameters.AddWithValue("@Email", ee.Email);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        



        public static void UpdateStudentInfo(EntStudentInfo ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateCities", con);
            cmd.Parameters.AddWithValue("@SID ", int.Parse(ee.SID));
            cmd.Parameters.AddWithValue("@FirstName", ee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", ee.LastName);
            cmd.Parameters.AddWithValue("@Gender", ee.Gender);
            cmd.Parameters.AddWithValue("@CNIC", ee.CNIC);
            cmd.Parameters.AddWithValue("@DateOfBirth", ee.DateOfBirth);
            cmd.Parameters.AddWithValue("@City", ee.City);
            cmd.Parameters.AddWithValue("@Address", ee.Address);
            cmd.Parameters.AddWithValue("@StudentMobileNo", ee.StudentMobileNo);
            cmd.Parameters.AddWithValue("@Email", ee.Email);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }



}

