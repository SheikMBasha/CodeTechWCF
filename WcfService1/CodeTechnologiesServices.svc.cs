using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CodeTechnologiesWCF.HelperClass.Exams;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CodeTechnologiesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CodeTechnologiesServices : IExams
    {

        #region "GetAllExamNature"
        public List<ExamNature> GetAllExamNature()
        {
            MySqlConnection connection = new MySqlConnection();
            List<ExamNature> examsNatures = new List<ExamNature>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllExamNature";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ExamNature examnature = new ExamNature();
                    examnature.Id = dr["Id"].ToString();
                    examnature.Name = dr["Name"].ToString();
                    examsNatures.Add(examnature);
                }
                return examsNatures;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion        

        #region "GetAllExamTypes"
        public List<ExamsType> GetAllExamTypes()
        {
            MySqlConnection connection = new MySqlConnection();
            List<ExamsType> examsNatures = new List<ExamsType>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllExamType";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ExamsType examnature = new ExamsType();
                    examnature.Id = dr["Id"].ToString();
                    examnature.ExamType = dr["ExamType"].ToString();
                    examsNatures.Add(examnature);
                }
                return examsNatures;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region "GetAllExamCodes"
        public List<ExamCodes> GetAllExamCodes()
        {
            MySqlConnection connection = new MySqlConnection();
            List<ExamCodes> examsCodes = new List<ExamCodes>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllExamCodes";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ExamCodes examCode = new ExamCodes();
                    //examCode.Id = dr["Id"].ToString();
                    examCode.ExamType = dr["ExamType"].ToString();
                    examsCodes.Add(examCode);
                }
                return examsCodes;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion
        
    }

}
