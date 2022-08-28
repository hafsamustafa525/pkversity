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
    public class DalFilter
    {
        public static List<EntFilter> GetResultByid(string PDSGID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_GetResultById", con);
            cmd.Parameters.AddWithValue("@PDSGID", PDSGID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntFilter> FilterList = new List<EntFilter>();
            while (sdr.Read())
            {
                EntFilter ee = new EntFilter();
                ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                ee.Title = sdr["Title"].ToString();
                ee.InstituteId = sdr["InstituteId"].ToString();
                ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                ee.DegreeName = sdr["DegreeName"].ToString();
                ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                ee.CityId = sdr["CityId"].ToString();
                ee.CityName = sdr["CityName"].ToString();
                FilterList.Add(ee);

            }
            con.Close();
            return FilterList;
        }
        public static List<EntFilter> GetDepartmentsbyID(string PDSGID,string CityId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_GetDepartmentCountByGroupIdAndCityId", con);
            cmd.Parameters.AddWithValue("@PDSGID", PDSGID);
            cmd.Parameters.AddWithValue("@CityId", int.Parse(CityId));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntFilter> FilterList = new List<EntFilter>();
            while (sdr.Read())
            {
                EntFilter ee = new EntFilter();
                
                ee.Title = sdr["Title"].ToString();
                ee.InstituteId = sdr["InstituteId"].ToString();
                ee.Departments = sdr["Departments"].ToString();
                FilterList.Add(ee);

            }
            con.Close();
            return FilterList;
        }

        public static List<EntProgramDegreeDetails> GetDepartmentDetailsbyID(string PDSGID, string @InstituteID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_GetDepartmentDetails", con);
            cmd.Parameters.AddWithValue("@PDSGID", PDSGID);
            cmd.Parameters.AddWithValue("@InstituteID", int.Parse(@InstituteID));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntProgramDegreeDetails> DepartmentList = new List<EntProgramDegreeDetails>();
            while (sdr.Read())
            {
                EntProgramDegreeDetails ee = new EntProgramDegreeDetails();

                ee.DegreeName = sdr["DegreeName"].ToString();
                ee.SemesterFee = sdr["SemesterFee"].ToString();
                ee.TotalFee= sdr["TotalFee"].ToString();
                DepartmentList.Add(ee);

            }
            con.Close();
            return DepartmentList;
        }
    }
}
