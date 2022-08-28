using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryEntities;

namespace ClassLibraryDAL
{
    public  class DALUserLogin
    {
        public static EntUserlogin GetUserByName(string UserName)
        {
            SqlConnection con = ClassLibraryDAL.DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_GetUserByName", con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntUserlogin ee = new EntUserlogin();
            while (sdr.Read())
            {
                ee.UserId = sdr["UserId"].ToString();
                ee.Username = sdr["UserName"].ToString();
                ee.Password = sdr["Password"].ToString();


            }
            con.Close();
            return ee;

        }

        public static void SaveSignUp (EntUserlogin ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_SaveSignUp", con);
            cmd.Parameters.AddWithValue("@Email", ee.Email);
            cmd.Parameters.AddWithValue("@UserName", ee.Username);
            cmd.Parameters.AddWithValue("@Password", ee.Password);
            cmd.Parameters.AddWithValue("@Role", ee.Role);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
