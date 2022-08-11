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
    public class DALProgramDegree
    {

        public static List<EntProgramDegree> GetProgramDegree()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetProgramDegree", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntProgramDegree> ProgramDegreeList = new List<EntProgramDegree>();
            while (sdr.Read())
            {
                EntProgramDegree ee = new EntProgramDegree();
                ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                ee.DegreeName = sdr["DegreeName"].ToString();
                ee.ProgramCategoryid = sdr["ProgramCategoryid"].ToString();

                ProgramDegreeList.Add(ee);
            }
            con.Close();
            return ProgramDegreeList;
        }


        public static void SaveProgramDegree(EntProgramDegree ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveProgramDegree", con);

            cmd.Parameters.AddWithValue("@DegreeName", ee.DegreeName);
            cmd.Parameters.AddWithValue("@ProgramCategoryid", ee.ProgramCategoryid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public static void DeleteProgramDegree(string ProgramDegreeId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteProgramDegree", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", int.Parse(ProgramDegreeId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void UpdateProgramDegree(EntProgramDegree ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateProgramDegree", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
            cmd.Parameters.AddWithValue("@DegreeName", ee.DegreeName);
            cmd.Parameters.AddWithValue("@ProgramCategoryid", ee.ProgramCategoryid);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public static EntProgramDegree GetProgramDegreeById(string id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AddDegreeWithID", con);
            cmd.Parameters.AddWithValue("@DID", int.Parse(id));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntProgramDegree ee = new EntProgramDegree();
            while (sdr.Read())
            {
                ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                ee.DegreeName = sdr["DegreeName"].ToString();
                ee.ProgramCategoryid = sdr["ProgramCategoryId"].ToString();

            }
            con.Close();
            return ee;
        }
    }
}
