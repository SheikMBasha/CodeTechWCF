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
using WcfService1.HelperClass.Exams;
using System.Web.Hosting;
using System.IO;
using System.Data.OleDb;

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
        public List<AcademyModel> GetAllAcademies()
        {
            MySqlConnection connection = new MySqlConnection();
            List<AcademyModel> academies = new List<AcademyModel>();
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
                    AcademyModel academyObj = new AcademyModel();
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
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void AdddAcademy(AcademyModel academyObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddAcademy";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("NameParam", academyObj.Name);
                cmd.Parameters.AddWithValue("POCNameParam", academyObj.POCName);
                cmd.Parameters.AddWithValue("PhoneParam", academyObj.Phone);
                cmd.Parameters.AddWithValue("EmailParam", academyObj.Email);
                cmd.Parameters.AddWithValue("AddressParam", academyObj.Address);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public int getAcademyId(string name)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAcademyId";
                cmd.Parameters.AddWithValue("AcademyNameParam", name);
                cmd.Connection = connection;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return Convert.ToInt32(dr["Id"]);
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return 0;
        }

        public AcademyModel getAcademy(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAcademy";
                    cmd.Parameters.AddWithValue("@academyId", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    AcademyModel academyObj = new AcademyModel();
                    academyObj.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    academyObj.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    academyObj.POCName = ds.Tables[0].Rows[0]["POCName"].ToString();
                    academyObj.Phone = Convert.ToInt32(ds.Tables[0].Rows[0]["Phone"]);
                    academyObj.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    academyObj.Address = ds.Tables[0].Rows[0]["Address"].ToString();

                    return academyObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }

        public void UpdateAcademy(AcademyModel academyObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAcademy";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("academyId", academyObj.Id);
                cmd.Parameters.AddWithValue("NameParam", academyObj.Name);
                cmd.Parameters.AddWithValue("POCNameParam", academyObj.POCName);
                cmd.Parameters.AddWithValue("PhoneParam", academyObj.Phone);
                cmd.Parameters.AddWithValue("EmailParam", academyObj.Email);
                cmd.Parameters.AddWithValue("AddressParam", academyObj.Address);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeleteAcademy(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAcademy";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("academyId", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region "PrometricCandidate"
        public List<PrometricCandidate> GetAllPrometricCandidates()
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                List<PrometricCandidate> pcList = new List<PrometricCandidate>();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPrometricCandidates";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PrometricCandidate pcObj = new PrometricCandidate();
                    pcObj.Id = Convert.ToInt32(dr["Id"]);
                    pcObj.Name = dr["Name"].ToString();
                    pcObj.ExamNature = Convert.ToInt32(dr["ExamNature"]);
                    pcObj.CandidateId = dr["CandidateId"].ToString();
                    pcObj.ExamStatus = dr["ExamStatus"].ToString();
                    pcObj.Attempts = (dr["Attempts"].ToString() == String.Empty) ? String.Empty : dr["Attempts"].ToString();
                    pcObj.ExamDate = (dr["ExamDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["ExamDate"]);
                    pcObj.EmailAddress = dr["EmailAddress"].ToString();
                    pcObj.Address = (dr["Address"].ToString() == String.Empty) ? String.Empty : dr["Address"].ToString();
                    pcObj.Phone = (dr["Phone"].ToString() == String.Empty) ? 0 : Convert.ToInt32(dr["Phone"]);
                    pcObj.InstituteId = (dr["InstituteId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["InstituteId"]);
                    pcObj.SiteId = Convert.ToInt32(dr["SiteId"]);

                    pcList.Add(pcObj);
                }
                return pcList;
            }

        }

        public void AddPrometricCandidate(PrometricCandidate pcObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPrometricCandidate";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("SiteIdParam", pcObj.SiteId);
                cmd.Parameters.AddWithValue("NameParam", pcObj.Name);
                cmd.Parameters.AddWithValue("ExamNatureParam", pcObj.ExamNature);
                cmd.Parameters.AddWithValue("ExamIdParam", pcObj.ExamId);
                cmd.Parameters.AddWithValue("CandidateIdParam", pcObj.CandidateId);
                cmd.Parameters.AddWithValue("InstituteId", pcObj.InstituteId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public PrometricCandidate getPrometricCandidate(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getPrometricCandidate";
                    cmd.Parameters.AddWithValue("IdParam", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    PrometricCandidate pcObj = new PrometricCandidate();
                    pcObj.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    pcObj.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    pcObj.ExamNature = Convert.ToInt32(ds.Tables[0].Rows[0]["ExamNature"]);
                    pcObj.CandidateId = ds.Tables[0].Rows[0]["CandidateId"].ToString();
                    pcObj.ExamStatus = ds.Tables[0].Rows[0]["ExamStatus"].ToString();
                    pcObj.Attempts = (ds.Tables[0].Rows[0]["Attempts"].ToString() == String.Empty) ? String.Empty : ds.Tables[0].Rows[0]["Attempts"].ToString();
                    pcObj.ExamDate = (ds.Tables[0].Rows[0]["ExamDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[0].Rows[0]["ExamDate"]);
                    pcObj.EmailAddress = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    pcObj.Address = (ds.Tables[0].Rows[0]["Address"].ToString() == String.Empty) ? String.Empty : ds.Tables[0].Rows[0]["Address"].ToString();
                    pcObj.Phone = (ds.Tables[0].Rows[0]["Phone"].ToString() == String.Empty) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["Phone"]);
                    pcObj.InstituteId = (ds.Tables[0].Rows[0]["InstituteId"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["InstituteId"]);
                    pcObj.SiteId = Convert.ToInt32(ds.Tables[0].Rows[0]["SiteId"]);

                    return pcObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void UpdatePrometricCandidate(PrometricCandidate pcObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePrometricCandidate";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("IdParam", pcObj.Id);
                cmd.Parameters.AddWithValue("SiteIdParam", pcObj.SiteId);
                cmd.Parameters.AddWithValue("NameParam", pcObj.Name);
                cmd.Parameters.AddWithValue("ExamNatureParam", pcObj.ExamNature);
                cmd.Parameters.AddWithValue("ExamIdParam", pcObj.ExamId);
                cmd.Parameters.AddWithValue("CandidateIdParam", pcObj.CandidateId);
                cmd.Parameters.AddWithValue("InstituteId", pcObj.InstituteId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeletePrometricCandidate(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePrometricCandidate";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("IdParam", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void BulkUploadPrometricCandidates(FileData inputexcel)
        {
            bool result = false;
            string FilePath = HostingEnvironment.MapPath("~/App_Data/ExcelFiles/" + inputexcel.FileName);
            try
            {
                //string FilePath = "";// Path.Combine("~/App_Data/ExcelFiles/", inputexcel.FileName);
                
                //if (System.IO.File.Exists(FilePath))
                //    System.IO.File.Delete(FilePath);

                if (inputexcel.FilePosition == 0)
                    File.Create(FilePath).Close();

                using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    fileStream.Seek(inputexcel.FilePosition, SeekOrigin.Begin);
                    fileStream.Write(inputexcel.BufferData, 0, inputexcel.BufferData.Length);
                }

                /* Excel Upload */
                string excelConnectionString = String.Empty;
                string fileExtension = Path.GetExtension(inputexcel.FileName);
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                if (fileExtension == ".xls")
                {
                    excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (fileExtension == ".xlsx")
                {

                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                excelConnection.Open();
                DataTable dt = new DataTable();

                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    //return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int t = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[t] = row["TABLE_NAME"].ToString();
                    t++;
                }
                OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
                DataSet ds = new DataSet();

                string query = string.Format("Select * from [{0}]", excelSheets[0]);
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                {
                    dataAdapter.Fill(ds);
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PrometricCandidate pcObj = new PrometricCandidate();
                    string instituteName = ds.Tables[0].Rows[i]["InstituteName"].ToString();
                    int instituteId = getInstituteId(instituteName);
                    pcObj.InstituteId = instituteId;
                    pcObj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    pcObj.ExamNature = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamNature"]);
                    pcObj.ExamId = ds.Tables[0].Rows[i]["ExamId"].ToString();
                    pcObj.CandidateId = ds.Tables[0].Rows[i]["CandidateId"].ToString();
                    //Need To get siteId with SP
                    pcObj.SiteId = 101;
                    AddPrometricCandidate(pcObj);

                }
            }
            catch (Exception e)
            {
                ErrorDetails ed = new ErrorDetails();
                ed.ErrorCode = 1001;
                ed.ErrorMessage = e.Message;
                throw new FaultException<ErrorDetails>(ed);
            }
            finally
            {
                
            }
        }

        public int getInstituteId(string name)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetInstituteId";
                cmd.Parameters.AddWithValue("NameParam", name);
                cmd.Connection = connection;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return Convert.ToInt32(dr["Id"]);
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            return 0;
        }
        #endregion

        #region "Prometric"
        public List<Prometric> GetAllPrometrics()
        {
            MySqlConnection connection = new MySqlConnection();
            List<Prometric> prometricList = new List<Prometric>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPrometrics";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Prometric prometricObj = new Prometric();
                    prometricObj.SiteId = Convert.ToInt32(dr["SiteId"]);
                    prometricObj.Name = dr["Name"].ToString();
                    prometricObj.POCName = dr["POCName"].ToString();
                    prometricObj.POCEmail = dr["POCEmail"].ToString();
                    prometricObj.SiteAddress = dr["SiteAddress"].ToString();
                    prometricObj.IsHired = (dr["IsHired"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsHired"]);
                    prometricObj.PerExamProfit = dr["PerExamProfit"].ToString();
                    prometricObj.TCAAdminId = Convert.ToInt32(dr["TCAAdminId"]);
                    prometricObj.SiteOwnerName = dr["SiteOwnerName"].ToString();
                    prometricList.Add(prometricObj);
                }
                return prometricList;

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

        public void AddPrometric(Prometric pObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPrometric";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("SiteIdParam", pObj.SiteId);
                cmd.Parameters.AddWithValue("NameParam", pObj.Name);
                cmd.Parameters.AddWithValue("POCNameParam", pObj.POCName);
                cmd.Parameters.AddWithValue("POCPhoneParam", pObj.POCPhone);
                cmd.Parameters.AddWithValue("POCEmailParam", pObj.POCEmail);
                cmd.Parameters.AddWithValue("SiteAddressParam", pObj.SiteAddress);
                cmd.Parameters.AddWithValue("IsHiredParam", pObj.IsHired);
                cmd.Parameters.AddWithValue("PerExamProfitParam", pObj.PerExamProfit);
                cmd.Parameters.AddWithValue("TCAAdminIdParam", pObj.TCAAdminId);
                cmd.Parameters.AddWithValue("SiteOwnerNameParam", pObj.SiteOwnerName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public Prometric getPrometric(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetPrometric";
                    cmd.Parameters.AddWithValue("siteIdParam", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    Prometric pObj = new Prometric();
                    pObj.SiteId = Convert.ToInt32(ds.Tables[0].Rows[0]["SiteId"]);
                    pObj.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    pObj.POCName = ds.Tables[0].Rows[0]["POCName"].ToString();
                    pObj.POCPhone = Convert.ToInt32(ds.Tables[0].Rows[0]["POCPhone"]);
                    pObj.POCEmail = ds.Tables[0].Rows[0]["POCEmail"].ToString();
                    pObj.SiteAddress = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                    pObj.IsHired = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHired"]);
                    pObj.PerExamProfit = ds.Tables[0].Rows[0]["PerExamProfit"].ToString();
                    pObj.TCAAdminId = Convert.ToInt32(ds.Tables[0].Rows[0]["TCAAdminId"]);
                    pObj.SiteOwnerName = ds.Tables[0].Rows[0]["SiteOwnerName"].ToString();

                    return pObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void UpdatePrometric(Prometric pObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePrometric";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("SiteIdParam", pObj.SiteId);
                cmd.Parameters.AddWithValue("NameParam", pObj.Name);
                cmd.Parameters.AddWithValue("POCNameParam", pObj.POCName);
                cmd.Parameters.AddWithValue("POCPhoneParam", pObj.POCPhone);
                cmd.Parameters.AddWithValue("POCEmailParam", pObj.POCEmail);
                cmd.Parameters.AddWithValue("SiteAddressParam", pObj.SiteAddress);
                cmd.Parameters.AddWithValue("IsHiredParam", pObj.IsHired);
                cmd.Parameters.AddWithValue("PerExamProfitParam", pObj.PerExamProfit);
                cmd.Parameters.AddWithValue("TCAAdminIdParam", pObj.TCAAdminId);
                cmd.Parameters.AddWithValue("SiteOwnerNameParam", pObj.SiteOwnerName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        public void DeletePrometric(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePrometric";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("SiteIdParam", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region "PrometricPromotions"
        public List<PrometricPromotions> getAllPrometricPromotions()
        {
            MySqlConnection connection = new MySqlConnection();
            List<PrometricPromotions> ppList = new List<PrometricPromotions>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPrometricPromotions";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PrometricPromotions ppObj = new PrometricPromotions();
                    ppObj.id = Convert.ToInt32(dr["Id"]);
                    ppObj.SiteId = Convert.ToInt32(dr["SiteId"]);
                    ppObj.DateFrom = (dr["DateFrom"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DateFrom"]);
                    ppObj.DateTo = (dr["DateTo"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DateTo"]);
                    ppObj.MarginGain = Convert.ToInt32(dr["MarginGain"]);
                    ppObj.MarginMiss = Convert.ToInt32(dr["MarginMiss"]);
                    ppList.Add(ppObj);
                }
                return ppList;

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

        public List<PrometricPromotions> getPrometricPromotionWithSiteId(int? siteId)
        {
            MySqlConnection connection = new MySqlConnection();
            List<PrometricPromotions> ppList = new List<PrometricPromotions>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getPrometricPromotionWithSiteId";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("siteIdParam", siteId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PrometricPromotions ppObj = new PrometricPromotions();
                    ppObj.id = Convert.ToInt32(dr["Id"]);
                    ppObj.SiteId = Convert.ToInt32(dr["SiteId"]);
                    ppObj.DateFrom = (dr["DateFrom"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DateFrom"]);
                    ppObj.DateTo = (dr["DateTo"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DateTo"]);
                    ppObj.MarginGain = Convert.ToInt32(dr["MarginGain"]);
                    ppObj.MarginMiss = Convert.ToInt32(dr["MarginMiss"]);
                    ppList.Add(ppObj);
                }
                return ppList;

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

        public void AddPrometricPromotion(PrometricPromotions ppObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPrometricPromotion";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("SiteIdParam", ppObj.SiteId);
                cmd.Parameters.AddWithValue("DateFromParam", ppObj.DateFrom);
                cmd.Parameters.AddWithValue("DateToParam", ppObj.DateTo);
                cmd.Parameters.AddWithValue("MarginGainParam", ppObj.MarginGain);
                cmd.Parameters.AddWithValue("MarginMissParam", ppObj.MarginMiss);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public PrometricPromotions getPrometricPromotion(int id)
        {

            MySqlConnection connection = new MySqlConnection();
            List<PrometricPromotions> ppList = new List<PrometricPromotions>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getPrometricPromotion";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("idParam", id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PrometricPromotions ppObj = new PrometricPromotions();
                    ppObj.id = Convert.ToInt32(dr["Id"]);
                    ppObj.SiteId = Convert.ToInt32(dr["SiteId"]);
                    ppObj.DateFrom = (dr["DateFrom"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DateFrom"]);
                    ppObj.DateTo = (dr["DateTo"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DateTo"]);
                    ppObj.MarginGain = Convert.ToInt32(dr["MarginGain"]);
                    ppObj.MarginMiss = Convert.ToInt32(dr["MarginMiss"]);
                    ppList.Add(ppObj);
                }
                return ppList[0];

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

        public void UpdatePrometricPromotion(PrometricPromotions ppObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePrometricPromotion";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("idParam", ppObj.id);
                cmd.Parameters.AddWithValue("SiteIdParam", ppObj.SiteId);
                cmd.Parameters.AddWithValue("DateFromParam", ppObj.DateFrom);
                cmd.Parameters.AddWithValue("DateToParam", ppObj.DateTo);
                cmd.Parameters.AddWithValue("MarginGainParam", ppObj.MarginGain);
                cmd.Parameters.AddWithValue("MarginMissParam", ppObj.MarginMiss);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeletePrometricPromotion(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePrometricPromotion";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("idParam", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region "Institute"
        public List<Institute> GetAllInstitutes()
        {
            MySqlConnection connection = new MySqlConnection();
            List<Institute> institutes = new List<Institute>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllInstitutes";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Institute instiObj = new Institute();
                    instiObj.Id = Convert.ToInt32(dr["Id"]);
                    instiObj.Name = dr["Name"].ToString();
                    instiObj.POCName = dr["POCName"].ToString();
                    instiObj.Phone = Convert.ToInt32(dr["Phone"]);
                    instiObj.Email = dr["Email"].ToString();
                    instiObj.Address = dr["Address"].ToString();
                    instiObj.CreditAllowed = Convert.ToInt32(dr["CreditAllowed"]);
                    instiObj.CreditRemaining = Convert.ToInt32(dr["CreditRemaining"]);

                    institutes.Add(instiObj);
                }
                return institutes;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void AddInstitute(Institute instiObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddInstitute";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("NameParam", instiObj.Name);
                cmd.Parameters.AddWithValue("POCNameParam", instiObj.POCName);
                cmd.Parameters.AddWithValue("PhoneParam", instiObj.Phone);
                cmd.Parameters.AddWithValue("EmailParam", instiObj.Email);
                cmd.Parameters.AddWithValue("AddressParam", instiObj.Address);
                cmd.Parameters.AddWithValue("CreditAllowedParam", instiObj.CreditAllowed);
                cmd.Parameters.AddWithValue("CreditRemainingParam", instiObj.CreditRemaining);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public Institute getInstitute(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetInstitute";
                    cmd.Parameters.AddWithValue("@instituteId", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    Institute instiObj = new Institute();
                    instiObj.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    instiObj.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    instiObj.POCName = ds.Tables[0].Rows[0]["POCName"].ToString();
                    instiObj.Phone = Convert.ToInt32(ds.Tables[0].Rows[0]["Phone"]);
                    instiObj.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    instiObj.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    instiObj.CreditAllowed = Convert.ToInt32(ds.Tables[0].Rows[0]["CreditAllowed"]);
                    instiObj.CreditRemaining = Convert.ToInt32(ds.Tables[0].Rows[0]["CreditRemaining"]);

                    return instiObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void UpdateInstitute(Institute instiObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateInstitute";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("instituteId", instiObj.Id);
                cmd.Parameters.AddWithValue("NameParam", instiObj.Name);
                cmd.Parameters.AddWithValue("POCNameParam", instiObj.POCName);
                cmd.Parameters.AddWithValue("PhoneParam", instiObj.Phone);
                cmd.Parameters.AddWithValue("EmailParam", instiObj.Email);
                cmd.Parameters.AddWithValue("AddressParam", instiObj.Address);
                cmd.Parameters.AddWithValue("CreditAllowedParam", instiObj.CreditAllowed);
                cmd.Parameters.AddWithValue("CreditRemainingParam", instiObj.CreditRemaining);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeleteInstitute(int id)     // For Editing...
        {
            // This code doesn't work as ID column in Institute table is a foreign key for InstituteId column in Mail table
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteInstitute";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("instituteId", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        #endregion

        #region "Expenses"
        public List<Expense> getAllExpenses()
        {
            MySqlConnection connection = new MySqlConnection();
            List<Expense> expenses = new List<Expense>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllExpenses";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Expense expenseObj = new Expense();
                    expenseObj.Id = Convert.ToInt32(dr["Id"]);
                    expenseObj.ExpenseType = dr["ExpenseType"].ToString();
                    expenseObj.AmountPaid = Convert.ToInt32(dr["AmountPaid"]);
                    expenseObj.Date = Convert.ToDateTime(dr["Date"]);
                    expenseObj.PaymentChannel = dr["PaymentChannel"].ToString();
                    expenseObj.SiteId = Convert.ToInt32(dr["SiteId"]);
                    expenses.Add(expenseObj);
                }
                return expenses;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public Expense getExpense(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetExpense";
                    cmd.Parameters.AddWithValue("IdParam", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    Expense expenseObj = new Expense();
                    expenseObj.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    expenseObj.ExpenseType = ds.Tables[0].Rows[0]["ExpenseType"].ToString();
                    expenseObj.AmountPaid = Convert.ToInt32(ds.Tables[0].Rows[0]["AmountPaid"]);
                    expenseObj.Date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);
                    expenseObj.PaymentChannel = ds.Tables[0].Rows[0]["PaymentChannel"].ToString();
                    expenseObj.SiteId = Convert.ToInt32(ds.Tables[0].Rows[0]["SiteId"]);

                    return expenseObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void AddExpense(Expense expObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddExpense";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("ExpenseTypeParam", expObj.ExpenseType);
                cmd.Parameters.AddWithValue("AmountPaidParam", expObj.AmountPaid);
                cmd.Parameters.AddWithValue("DateParam", expObj.Date);
                cmd.Parameters.AddWithValue("PaymentChannelParam", expObj.PaymentChannel);
                cmd.Parameters.AddWithValue("SiteIdParam", expObj.SiteId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void UpdateExpense(Expense expObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExpense";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("IdParam", expObj.Id);
                cmd.Parameters.AddWithValue("ExpenseTypeParam", expObj.ExpenseType);
                cmd.Parameters.AddWithValue("AmountPaidParam", expObj.AmountPaid);
                cmd.Parameters.AddWithValue("DateParam", expObj.Date);
                cmd.Parameters.AddWithValue("PaymentChannelParam", expObj.PaymentChannel);
                cmd.Parameters.AddWithValue("SiteIdParam", expObj.SiteId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeleteExpense(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteExpense";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("IdParam", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region "PearsonCandidate"
        public List<PearsonCandidate> GetAllPearsonCandidates()
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                List<PearsonCandidate> pcList = new List<PearsonCandidate>();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPearsonCandidates";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PearsonCandidate pcObj = new PearsonCandidate();
                    pcObj.Id = Convert.ToInt32(dr["Id"]);
                    pcObj.FirstName = dr["FirstName"].ToString();
                    pcObj.LastName = dr["LastName"].ToString();
                    pcObj.ExamNature = Convert.ToInt32(dr["ExamNature"]);
                    pcObj.CiscoClientId = dr["CiscoClientId"].ToString();
                    pcObj.ExamStatus = dr["ExamStatus"].ToString();
                    pcObj.Attempts = (dr["Attempts"].ToString() == String.Empty) ? String.Empty : dr["Attempts"].ToString();
                    pcObj.ExamDate = (dr["ExamDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["ExamDate"]);
                    pcObj.EmailAddress = dr["EmailAddress"].ToString();
                    pcObj.Address = (dr["Address"].ToString() == String.Empty) ? String.Empty : dr["Address"].ToString();
                    pcObj.Phone = (dr["Phone"].ToString() == String.Empty) ? 0 : Convert.ToInt32(dr["Phone"]);
                    pcObj.InstituteId = (dr["InstituteId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["InstituteId"]);
                    pcObj.AcademyId = Convert.ToInt32(dr["AcademyId"]);
                    pcObj.SiteId = Convert.ToInt32(dr["SiteId"]);

                    pcList.Add(pcObj);
                }
                return pcList;
            }
        }

        public void BulkUploadPearsonCandidates(FileData inputexcel)
        {
            bool result = false;
            string FilePath = HostingEnvironment.MapPath("~/App_Data/ExcelFiles/" + inputexcel.FileName);
            try
            {
                //string FilePath = "";// Path.Combine("~/App_Data/ExcelFiles/", inputexcel.FileName);

                //if (System.IO.File.Exists(FilePath))
                //    System.IO.File.Delete(FilePath);

                if (inputexcel.FilePosition == 0)
                    File.Create(FilePath).Close();

                using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    fileStream.Seek(inputexcel.FilePosition, SeekOrigin.Begin);
                    fileStream.Write(inputexcel.BufferData, 0, inputexcel.BufferData.Length);
                }

                /* Excel Upload */
                string excelConnectionString = String.Empty;
                string fileExtension = Path.GetExtension(inputexcel.FileName);
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                if (fileExtension == ".xls")
                {
                    excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (fileExtension == ".xlsx")
                {

                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                excelConnection.Open();
                DataTable dt = new DataTable();

                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    //return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int t = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[t] = row["TABLE_NAME"].ToString();
                    t++;
                }
                OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
                DataSet ds = new DataSet();

                string query = string.Format("Select * from [{0}]", excelSheets[0]);
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                {
                    dataAdapter.Fill(ds);
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PearsonCandidate pcObj = new PearsonCandidate();
                    string instituteName = ds.Tables[0].Rows[i]["InstituteName"].ToString();
                    int instituteId = getInstituteId(instituteName);
                    pcObj.InstituteId = instituteId;
                    pcObj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    pcObj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    pcObj.ExamNature = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamNature"]);
                    pcObj.ExamId = ds.Tables[0].Rows[i]["ExamId"].ToString();
                    pcObj.AcademyId = getAcademyId(ds.Tables[0].Rows[i]["AcademyName"].ToString());
                    //Need To get siteId with SP
                    pcObj.SiteId = 101;
                    AddPearsonCandidate(pcObj);

                }
            }
            catch (Exception e)
            {
                ErrorDetails ed = new ErrorDetails();
                ed.ErrorCode = 1001;
                ed.ErrorMessage = e.Message;
                throw new FaultException<ErrorDetails>(ed);
            }
            finally
            {

            }
        }

        public void AddPearsonCandidate(PearsonCandidate pcObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPearsonCandidate";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("SiteIdParam", pcObj.SiteId);
                cmd.Parameters.AddWithValue("FirstNameParam", pcObj.FirstName);
                cmd.Parameters.AddWithValue("LastNameParam", pcObj.LastName);
                cmd.Parameters.AddWithValue("ExamNatureParam", pcObj.ExamNature);
                cmd.Parameters.AddWithValue("ExamIdParam", pcObj.ExamId);
                cmd.Parameters.AddWithValue("InstituteIdParam", pcObj.InstituteId);
                cmd.Parameters.AddWithValue("AcademyIdParam", pcObj.AcademyId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public PearsonCandidate getPearsonCandidate(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getPrometricCandidate";
                    cmd.Parameters.AddWithValue("IdParam", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    PearsonCandidate pcObj = new PearsonCandidate();
                    pcObj.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    pcObj.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    pcObj.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    pcObj.ExamNature = Convert.ToInt32(ds.Tables[0].Rows[0]["ExamNature"]);
                    pcObj.ExamStatus = ds.Tables[0].Rows[0]["ExamStatus"].ToString();
                    pcObj.Attempts = (ds.Tables[0].Rows[0]["Attempts"].ToString() == String.Empty) ? String.Empty : ds.Tables[0].Rows[0]["Attempts"].ToString();
                    pcObj.ExamDate = (ds.Tables[0].Rows[0]["ExamDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[0].Rows[0]["ExamDate"]);
                    pcObj.EmailAddress = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    pcObj.Address = (ds.Tables[0].Rows[0]["Address"].ToString() == String.Empty) ? String.Empty : ds.Tables[0].Rows[0]["Address"].ToString();
                    pcObj.Phone = (ds.Tables[0].Rows[0]["Phone"].ToString() == String.Empty) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["Phone"]);
                    pcObj.InstituteId = (ds.Tables[0].Rows[0]["InstituteId"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["InstituteId"]);
                    pcObj.AcademyId = (ds.Tables[0].Rows[0]["AcademyId"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["AcademyId"]);
                    pcObj.SiteId = Convert.ToInt32(ds.Tables[0].Rows[0]["SiteId"]);
                    return pcObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void UpdatePearsonCandidate(PearsonCandidate pcObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePrometricCandidate";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("IdParam", pcObj.Id);
                cmd.Parameters.AddWithValue("SiteIdParam", pcObj.SiteId);
                cmd.Parameters.AddWithValue("FirstNameParam", pcObj.FirstName);
                cmd.Parameters.AddWithValue("LastNameParam", pcObj.LastName);
                cmd.Parameters.AddWithValue("ExamNatureParam", pcObj.ExamNature);
                cmd.Parameters.AddWithValue("ExamIdParam", pcObj.ExamId);
                cmd.Parameters.AddWithValue("InstituteIdParam", pcObj.InstituteId);
                cmd.Parameters.AddWithValue("AcademyIdParam", pcObj.AcademyId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeletePearsonCandidate(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePearsonCandidate";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("IdParam", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region "Exam Training"

        public List<ExamTrainings> GetAllExamTrainings()
        {
            MySqlConnection connection = new MySqlConnection();
            List<ExamTrainings> trainings = new List<ExamTrainings>();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllExamTrainings";
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ExamTrainings trngObj = new ExamTrainings();
                    trngObj.Id = Convert.ToInt32(dr["Id"]);
                    trngObj.ExamId = dr["ExamId"].ToString();
                    trngObj.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    trngObj.EndDate = Convert.ToDateTime(dr["EndDate"]);
                    trngObj.TrainingCost = Convert.ToInt32(dr["TrainingCost"]);
                    trngObj.TotalAmountReceived = Convert.ToInt32(dr["TotalAmountReceived"]);
                    trngObj.TrainerId = Convert.ToInt32(dr["TrainerId"]);

                    trainings.Add(trngObj);
                }
                return trainings;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void AddExamTraining(ExamTrainings trngObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddExamTrainings";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("ExamIdParam", trngObj.ExamId);
                cmd.Parameters.AddWithValue("StartDateParam", trngObj.StartDate);
                cmd.Parameters.AddWithValue("EndDateParam", trngObj.EndDate);
                cmd.Parameters.AddWithValue("TrainingCostParam", trngObj.TrainingCost);
                cmd.Parameters.AddWithValue("TotalAmountReceivedParam", trngObj.TotalAmountReceived);
                cmd.Parameters.AddWithValue("TrainerIdParam", trngObj.TrainerId);                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public ExamTrainings getExamTraining(int id)
        {
            using (MySqlConnection connection = new MySqlConnection())
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetExamTraining";
                    cmd.Parameters.AddWithValue("@examId", id);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    ExamTrainings trngObj = new ExamTrainings();
                    trngObj.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                    trngObj.ExamId = ds.Tables[0].Rows[0]["ExamId"].ToString();
                    trngObj.StartDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]);
                    trngObj.EndDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]);
                    trngObj.TrainingCost = Convert.ToInt32(ds.Tables[0].Rows[0]["TrainingCost"]);
                    trngObj.TotalAmountReceived = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalAmountReceived"]);
                    trngObj.TrainerId = Convert.ToInt32(ds.Tables[0].Rows[0]["TrainerId"]);

                    return trngObj;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void UpdateInstitute(ExamTrainings trngObj)
        {
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExamTraining";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("NameParam", trngObj.ExamId);
                cmd.Parameters.AddWithValue("POCNameParam", trngObj.StartDate);
                cmd.Parameters.AddWithValue("PhoneParam", trngObj.EndDate);
                cmd.Parameters.AddWithValue("EmailParam", trngObj.TrainingCost);
                cmd.Parameters.AddWithValue("AddressParam", trngObj.TotalAmountReceived);
                cmd.Parameters.AddWithValue("CreditAllowedParam", trngObj.TrainerId); 
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }

        public void DeleteExamTraining(int id)     
        {           
            MySqlConnection connection = new MySqlConnection();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteExamTraining";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("instituteId", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
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
