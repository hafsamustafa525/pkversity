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
    public class DalInstitutes
    {
       
        public static List<EntInstitutes> GetInstitutes()
        {
           
           SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetInstitutes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntInstitutes> instituteList = new List<EntInstitutes>();
            while (sdr.Read())
            {
                EntInstitutes ee = new EntInstitutes();
                ee.@InstituteId = sdr["InstituteId"].ToString();
                ee.@Title = sdr["Title"].ToString();
                ee.@Email = sdr["Email"].ToString();
                ee.@Phone = sdr["Phone"].ToString();
                ee.@Logo = sdr["Logo"].ToString();
                ee.@UserName = sdr["UserName"].ToString();
                ee.@Password = sdr["Password"].ToString();
                ee.@CreatedOn = sdr["CreatedOn"].ToString();
                ee.@IsActive = sdr["IsActive"].ToString();
                ee.@CityId = sdr["CityId"].ToString();
                ee.@TypeOfId = sdr["TypeOfId"].ToString();
                ee.@Location = sdr["Location"].ToString();
                ee.@AdminId = sdr["AdminId"].ToString();
                instituteList.Add(ee);

            }
            con.Close();
            return instituteList;
        }


        public static EntInstitutes GetInstituteBtId(string InstituteId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetInstituteBtId", con);
            cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntInstitutes ee = new EntInstitutes();
            while (sdr.Read())
            {
                ee.InstituteId = sdr["InstituteId"].ToString();
                ee.Title = sdr["Title"].ToString();
                ee.Email = sdr["Email"].ToString();
                ee.Phone = sdr["Phone"].ToString();
                ee.Logo = sdr["Logo"].ToString();
                ee.UserName = sdr["UserName"].ToString();
                ee.Password = sdr["Password"].ToString();
                ee.CreatedOn = sdr["CreatedOn"].ToString();
                ee.IsActive = sdr["IsActive"].ToString();
                ee.CityId = sdr["CityId"].ToString();
                ee.TypeOfId = sdr["TypeOfId"].ToString();
                ee.Location = sdr["Location"].ToString();
                ee.AdminId = sdr["AdminId"].ToString();
            }
            con.Close();
            return ee;
        }


        public static void SaveInstitutes(EntInstitutes ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveInstitutes", con);
            cmd.Parameters.AddWithValue("@Title", ee.Title);
            cmd.Parameters.AddWithValue("@Email", ee.Email);
            cmd.Parameters.AddWithValue("@Phone", ee.Phone);
            cmd.Parameters.AddWithValue("@Logo", ee.Logo);
            cmd.Parameters.AddWithValue("@UserName", ee.UserName);

            cmd.Parameters.AddWithValue("@Password", ee.Password);


            cmd.Parameters.AddWithValue("@CityId", ee.CityId);
            cmd.Parameters.AddWithValue("@TypeOfId", ee.TypeOfId);
            cmd.Parameters.AddWithValue("@Location", ee.Location);
            cmd.Parameters.AddWithValue("@AdminId", 1234);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public static void DeleteInstitutes(string InstituteId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteInstitutes", con);
            cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void UpdateInstitutes(EntInstitutes ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateInstitute", con);
            cmd.Parameters.AddWithValue("@InstituteId", ee.InstituteId);
            cmd.Parameters.AddWithValue("@Title", ee.Title);
            cmd.Parameters.AddWithValue("@Email", ee.Email);
            cmd.Parameters.AddWithValue("@Phone", ee.Phone);
            cmd.Parameters.AddWithValue("@Logo", ee.Logo);

            cmd.Parameters.AddWithValue("@UserName", ee.UserName);
            cmd.Parameters.AddWithValue("@Password", ee.Password);
            cmd.Parameters.AddWithValue("@CreatedOn", ee.CreatedOn);
            cmd.Parameters.AddWithValue("@IsActive", ee.IsActive);
            cmd.Parameters.AddWithValue("@CityId", ee.CityId);
            cmd.Parameters.AddWithValue("@TypeOfId", ee.TypeOfId);
            cmd.Parameters.AddWithValue("@Location", ee.Location);
            cmd.Parameters.AddWithValue("@AdminId", ee.AdminId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}
