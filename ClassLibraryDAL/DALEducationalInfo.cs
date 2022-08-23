using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DALEducationalInfo
    {
        //public static List<EntEducationalInfo> GetStudentInfo()
        //{
        //    SqlConnection con = DBHelper.GetConnection();
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SP_GetCities", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    List<EntStudentInfo> CitiesList = new List<EntStudentInfo>();
        //    while (sdr.Read())
        //    {
        //        EntStudentInfo ee = new EntStudentInfo();
        //        ee.FirstName = sdr["FirstName"].ToString();
        //        ee.LastName = sdr["LastName"].ToString();
        //        ee.Gender = sdr["Gender"].ToString();
        //        ee.CNIC = sdr["CNIC"].ToString();
        //        ee.DateOfBirth = sdr["DateOfBirth"].ToString();
        //        ee.City = sdr["City"].ToString();
        //        ee.Address = sdr["Address"].ToString();
        //        ee.StudentMobileNo = sdr["StudentMobileNo"].ToString();
        //        ee.Email = sdr["Email"].ToString();
        //        CitiesList.Add(ee);
        //    }
        //    con.Close();
        //    return CitiesList;
        //}

        public static void SaveStdMatricInfo(EntEducationalInfo ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveStdMatric", con);
            cmd.Parameters.AddWithValue("@SID", ee.SID);
            cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
            cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
            cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
            cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
            cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
            cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
            cmd.Parameters.AddWithValue("@Institute", ee.Institute);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void SaveStdFscInfo(EntEducationalInfo ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveStdFsc", con);
            cmd.Parameters.AddWithValue("@SID", ee.SID);
            cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
            cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
            cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
            cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
            cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
            cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
            cmd.Parameters.AddWithValue("@Institute", ee.Institute);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
