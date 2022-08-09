using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntities;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibraryDAL
{
    public class DALPassingDSGroups
    {
        public static void SavePassingDSGroups(EntPassingDSGroups ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SavePassingDSGroups", con);
            cmd.Parameters.AddWithValue("@PassingDSGroups", ee.PassingDSGroups);
            cmd.Parameters.AddWithValue("@PassingDegreeId", ee.PassingDegreeId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

           
        }

        public static EntPassingDSGroups GetPassingDSGroupsById(string PassingDSGroupsId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetpassingDSGroupsById", con);
            cmd.Parameters.AddWithValue("@PassingDSGroupsId", PassingDSGroupsId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntPassingDSGroups ee = new EntPassingDSGroups();
            while (sdr.Read())
            {
                ee.PassingDSGroupsId = sdr["PassingDSGroupsId"].ToString();
                ee.PassingDSGroups = sdr["PassingDSGroups"].ToString();
            }
            con.Close();
            return ee;
        }

        public static void UpdatePassingDSGroups(EntPassingDSGroups ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdatePassingDSGroups", con);
            cmd.Parameters.AddWithValue("@PassingDSGroups ", ee.PassingDSGroups);
            cmd.Parameters.AddWithValue("@PassingDegreeId", ee.PassingDegreeId);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void DeletePassingDSGroups(string PassingDSGroupsId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeletePassingDSGroups", con);
            cmd.Parameters.AddWithValue("@PassingDSGroupsId", int.Parse(PassingDSGroupsId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static List<EntPassingDSGroups> GetPassingDSGroups()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetPassingDSGroups", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntPassingDSGroups> PassingDSGroupsList = new List<EntPassingDSGroups>();
            while (sdr.Read())
            {
                EntPassingDSGroups ee = new EntPassingDSGroups();
                ee.PassingDegreeId = sdr["PassingDegreeId"].ToString();
                ee.PassingDSGroups = sdr["PassingDSGroups"].ToString();
                ee.PassingDSGroupsId = sdr["PassingDSGroupsId"].ToString();

                PassingDSGroupsList.Add(ee);
            }
            con.Close();
            return PassingDSGroupsList;
        }

    }
}
