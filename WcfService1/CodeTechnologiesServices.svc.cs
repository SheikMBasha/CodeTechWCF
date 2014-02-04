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
            catch (Exception )
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
                        pcObj.ExamNature = dr["ExamNature"].ToString();
                        pcObj.CandidateId = dr["CandidateId"].ToString();
                        pcObj.ExamStatus = dr["ExamStatus"].ToString();
                        pcObj.Attempts = (dr["Attempts"].ToString() == String.Empty) ? String.Empty : dr["Attempts"].ToString();
                        pcObj.ExamDate = (dr["ExamDate"] == DBNull.Value ) ? DateTime.MinValue : Convert.ToDateTime(dr["ExamDate"]);
                        pcObj.EmailAddress = dr["EmailAddress"].ToString();
                        pcObj.Address = (dr["Address"].ToString() == String.Empty) ? String.Empty : dr["Address"].ToString();
                        pcObj.Phone = (dr["Phone"].ToString() == String.Empty) ? 0 : Convert.ToInt32(dr["Phone"]);
                        pcObj.InstituteId = Convert.ToInt32(dr["InstituteId"]);
                        pcObj.SiteId = Convert.ToInt32(dr["SiteId"]);

                        pcList.Add(pcObj);
                    }
                    return pcList;
                }
                
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
                            prometricObj.IsHired = Convert.ToBoolean(dr["IsHired"]);
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











               

                

               
    }

}
