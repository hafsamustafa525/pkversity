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
    public class DALProgramCategory
    {
        //public int ProgramCatagoryId { get; set; }
        //public string? CatagoryName { get; set; }
        public static List<EntProgramCategory> GetProgramCategory()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetProgramCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntProgramCategory> ProgramCategoryList = new List<EntProgramCategory>();
            while (sdr.Read())
            {
                EntProgramCategory ee = new EntProgramCategory();
                ee.ProgramCategoryId = sdr["ProgramCategoryId"].ToString();
                ee.CategoryName = sdr["CategoryName"].ToString();

                ProgramCategoryList.Add(ee);
            }
            con.Close();
            return ProgramCategoryList;
        }




        public static void SaveProgramCategory(EntProgramCategory ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveProgramCategory", con);

            cmd.Parameters.AddWithValue("@CategoryName", ee.CategoryName);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void DeleteProgramCategory(string ProgramCategoryId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteProgramCategory", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(ProgramCategoryId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateProgramCategory(EntProgramCategory ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateProgramCategory", con);
            cmd.Parameters.AddWithValue("@ProgramCategoryId", ee.ProgramCategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", ee.CategoryName);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static EntProgramCategory GetProgramCategoryById(string CategoryID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AddCategoryWithID", con);
            cmd.Parameters.AddWithValue("@CAID", int.Parse(CategoryID));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntProgramCategory ee = new EntProgramCategory();
            while (sdr.Read())
            {
                ee.ProgramCategoryId = sdr["ProgramCategoryId"].ToString();
                ee.CategoryName = sdr["CategoryName"].ToString();

            }
            con.Close();
            return ee;
        }
    }
}
