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
    public class DALProgramDegreeDetails
    {

        public static List<EntProgramDegreeDetails> GetProgramDegreeDetails()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetProgramDegreeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntProgramDegreeDetails> ProgramDegreeDetailList = new List<EntProgramDegreeDetails>();
            while (sdr.Read())
            {
                EntProgramDegreeDetails ee = new EntProgramDegreeDetails();
                ee.ProgramDegreeDetailsId = sdr["ProgramDegreeDetailsId"].ToString();
                ee.Duration = sdr["Duration"].ToString();
                ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                ee.TotalFee = sdr["TotalFee"].ToString();
                ee.SemesterFee = sdr["SemesterFee"].ToString();
                ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                ee.ApprovedById = sdr["ApprovedById"].ToString();
                ee.CityId = sdr["CityId"].ToString();
                ee.Morning = sdr["Morning"].ToString();
                ee.Evening = sdr["Evening"].ToString();
                ee.Weekened = sdr["Weekened"].ToString();
                ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                ee.InstituteId = sdr["InstituteId"].ToString();
                ee.Percentage = sdr["Percentage"].ToString();

                ProgramDegreeDetailList.Add(ee);
            }
            con.Close();
            return ProgramDegreeDetailList;
        }



        //[ProgramDegreeDetailsId], [Duration], [TotalSemesters], [TotalFee], [SemesterFee], [ApprovedById], [CityId], [Morning], [Evening], [Weekened],
        //[PassingDegreeGroups], [ProgramDegreeId], [InstituteId], [Percentage]
        public static void SaveProgramDegreeDetails(EntProgramDegreeDetails ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveProgramDegreeDetails", con);
            cmd.Parameters.AddWithValue("@Duration", ee.Duration);
            cmd.Parameters.AddWithValue("@TotalSemesters", ee.TotalSemesters);
            cmd.Parameters.AddWithValue("@TotalFee", ee.TotalFee);
            cmd.Parameters.AddWithValue("@SemesterFee", ee.SemesterFee);
            cmd.Parameters.AddWithValue("@ClosingMerit", ee.ClosingMerit);
            cmd.Parameters.AddWithValue("@ApprovedById", ee.ApprovedById);
            cmd.Parameters.AddWithValue("@CityId", ee.CityId);
            cmd.Parameters.AddWithValue("@Morning", ee.Morning);
            cmd.Parameters.AddWithValue("@Evening", ee.Evening);
            cmd.Parameters.AddWithValue("@Weekened", ee.Weekened);
            cmd.Parameters.AddWithValue("@PassingDegreeGroups", ee.PassingDegreeGroups);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
            cmd.Parameters.AddWithValue("@InstituteId", ee.InstituteId);
            cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void DeleteProgramDegreeDetails(string ProgramDegreeDetailsId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteProgramDegreeDetails", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeDetailsId", int.Parse(ProgramDegreeDetailsId));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateProgramCategory(EntProgramDegreeDetails ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateProgramDegreeDetails", con);
            cmd.Parameters.AddWithValue("@ProgramDegreeDetailsId", ee.ProgramDegreeDetailsId);
            cmd.Parameters.AddWithValue("@Duration", ee.Duration);
            cmd.Parameters.AddWithValue("@TotalSemesters", ee.TotalSemesters);
            cmd.Parameters.AddWithValue("@TotalFee", ee.TotalFee);
            cmd.Parameters.AddWithValue("@SemesterFee", ee.SemesterFee);
            cmd.Parameters.AddWithValue("@ClosingMerit", ee.ClosingMerit);
            cmd.Parameters.AddWithValue("@ApprovedById", ee.ApprovedById);
            cmd.Parameters.AddWithValue("@CityId", ee.CityId);
            cmd.Parameters.AddWithValue("@Morning", ee.Morning);
            cmd.Parameters.AddWithValue("@Evening", ee.Evening);
            cmd.Parameters.AddWithValue("@Weekened", ee.Weekened);
            cmd.Parameters.AddWithValue("@PassingDegreeGroups", ee.PassingDegreeGroups);
            cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
            cmd.Parameters.AddWithValue("@InstituteId", ee.InstituteId);
            cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static EntProgramDegreeDetails GetProgramDegreeDetailsByID(string ProgramDegreeDetailsId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AddProgramDegreeDetailsById", con);
            cmd.Parameters.AddWithValue("@DDID", int.Parse(ProgramDegreeDetailsId));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            EntProgramDegreeDetails ee = new EntProgramDegreeDetails();
            while (sdr.Read())
            {

                ee.ProgramDegreeDetailsId = sdr["ProgramDegreeDetailsId"].ToString();
                ee.Duration = sdr["Duration"].ToString();
                ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                ee.TotalFee = sdr["TotalFee"].ToString();
                ee.SemesterFee = sdr["SemesterFee"].ToString();
                ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                ee.ApprovedById = sdr["ApprovedById"].ToString();
                ee.CityId = sdr["CityId"].ToString();
                ee.Morning = sdr["Morning"].ToString();
                ee.Evening = sdr["Evening"].ToString();
                ee.Weekened = sdr["Weekened"].ToString();
                ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                ee.InstituteId = sdr["InstituteId"].ToString();
                ee.Percentage = sdr["Percentage"].ToString();
            }
            con.Close();
            return ee;
        }


    }
}
