using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryDAL;
using ClassLibraryEntities;


namespace ClassLibraryDAL
{
    public class DALFutureScope
    {
        public static void SaveDesciption(EntFutureScope ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveDescription", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
            cmd.Parameters.AddWithValue("@Description", ee.Description);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public static void UpdateDesciption(EntFutureScope ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateDescription", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
            cmd.Parameters.AddWithValue("@Description", ee.Description);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public static List<EntFutureScope> GetFutureScopeById(string ProgramDegreeId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetFutureScopeById", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", int.Parse(ProgramDegreeId));  //
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntFutureScope> FutureList = new List<EntFutureScope>();
            while (sdr.Read())
            {
                EntFutureScope ee = new EntFutureScope();
                ee.ProgramDegreeId= sdr["ProgramDegreeId"].ToString();
                ee.Description = sdr["Description"].ToString();
               FutureList.Add(ee);
            }
            con.Close();
            return FutureList;
        }

    }
}
