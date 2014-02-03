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
using WcfService1;
using WcfService1.HelperClass;

namespace CodeTechnologiesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CodeTechnologiesServices : ICodeTechnologiesServices
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

        #region "GetAllAcademies"
        public List<Academy> GetAllAcademies()
        {
            MySqlConnection connection = new MySqlConnection();
            List<Academy> academies = new List<Academy>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllAcademies";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Academy academyObj = new Academy();
                    academyObj.Id = Convert.ToInt32(dr["Id"]);
                    academyObj.Name = dr["Name"].ToString();
                    academyObj.POCName = dr["POCName"].ToString();
                    academyObj.Phone = Convert.ToInt32(dr["Phone"]);
                    academyObj.Email = dr["Email"].ToString();
                    academyObj.Address = dr["Address"].ToString();
                    academies.Add(academyObj);
                }
                return academies;

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
