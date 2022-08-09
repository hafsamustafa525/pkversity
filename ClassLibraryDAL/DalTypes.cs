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
    public class DalTypes
    {
        public static List<EntTypes> GetTypeOfs()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTypeOfs", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntTypes> TypesList = new List<EntTypes>();
            while (sdr.Read())
            {
                EntTypes ee = new EntTypes();
                ee.TypeOfId = sdr["TypeOfId"].ToString();
                ee.Type = sdr["Type"].ToString();
                TypesList.Add(ee);
            }
            con.Close();
            return TypesList;
        }

        //GetTypeById
        public static EntTypes GetTypeById(string? TypeOfId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTypeById", con);
            cmd.Parameters.AddWithValue("@TypeOfId", TypeOfId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntTypes ee = new EntTypes();
            while (sdr.Read())
            {
                ee.TypeOfId = sdr["TypeOfId"].ToString();
                ee.Type = sdr["Type"].ToString();
            }
            con.Close();
            return ee;
        }
        public static void SaveTypeOfs(EntTypes? ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveTypeOfs", con);
            cmd.Parameters.AddWithValue("@Type", ee.Type);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public static void DeleteTypeOfs(string TypeOfId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteTypeOfs", con);
            cmd.Parameters.AddWithValue("@TypeOfId", int.Parse(TypeOfId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void UpdateTypesOfs(EntTypes? ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateTypeOfs", con);
            cmd.Parameters.AddWithValue("@TypeOfId", int.Parse(ee.TypeOfId));
            cmd.Parameters.AddWithValue("@Type", ee.Type);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}
