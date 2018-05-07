using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ErrorLogger;

namespace DAL
{
    public class clsCommonSP : clsDBConnection
    {
        string methodName;

        /// <summary>
        /// Method for Error Log Add
        /// </summary>
        /// <param name="ErrorLogInfo"></param>
        public void ErrorLogAdd(clsErrorLogInfo ErrorLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_ErrorLogAdd", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@ERRORCODE", SqlDbType.NVarChar);
                sqlParameter.Value = ErrorLogInfo.ERRORCODE;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORTYPE", SqlDbType.VarChar);
                sqlParameter.Value = ErrorLogInfo.ERRORTYPE;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORDESCRIPTION", SqlDbType.NVarChar);
                sqlParameter.Value = ErrorLogInfo.ERRORDESCRIPTION;
                sqlParameter = sqlCommand.Parameters.Add("@CREATEDDATE", SqlDbType.DateTime);
                sqlParameter.Value = ErrorLogInfo.CREATEDDATE;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsErrorLogger objError = new clsErrorLogger();
                objError.LogErrorInFile("Exception(" + methodName + ") Common: {0}", ex.Message.ToString(), 0);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Error Log Edit
        /// </summary>
        /// <param name="ErrorLogInfo"></param>
        public void ErrorLogEdit(clsErrorLogInfo ErrorLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("EXEC sp_users_ErrorLogEdit(?,?,?,?)", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@ERRORLOGID", SqlDbType.Decimal);
                sqlParameter.Value = ErrorLogInfo.ERRORLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORCODE", SqlDbType.NVarChar);
                sqlParameter.Value = ErrorLogInfo.ERRORCODE;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORTYPE", SqlDbType.VarChar);
                sqlParameter.Value = ErrorLogInfo.ERRORTYPE;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORDESCRIPTION", SqlDbType.NVarChar);
                sqlParameter.Value = ErrorLogInfo.ERRORDESCRIPTION;
                sqlParameter = sqlCommand.Parameters.Add("@CREATEDDATE", SqlDbType.DateTime);
                sqlParameter.Value = ErrorLogInfo.CREATEDDATE;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_ErrorLogEdit";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Getting Error ID by Description
        /// </summary>
        /// <param name="ErrorDescript"></param>
        /// <returns></returns>
        public int GetErrorIdByDescription(string ErrorDescript)
        {
            int result = 0;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_GetErrorIdByDescription", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@ERRORDESCRIPTION", SqlDbType.VarChar);
                sqlParameter.Value = ErrorDescript;
                result = int.Parse(sqlCommand.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_GetErrorIdByDescription";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Method for Error Log ID Max
        /// </summary>
        /// <returns></returns>
        public int ErrorLogIDMax()
        {
            int result = 0;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                string cmdText = "select ISNULL(max(ERRORLOGID)+1,1)AS SE from TBLERRORlog";
                result = int.Parse(new SqlCommand(cmdText, this.connection)
                {
                    CommandType = CommandType.StoredProcedure
                }.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_ErrorLogIDMax";
                LogError(methodName, ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Method for Log Entry Details Add
        /// </summary>
        /// <param name="SentLogInfo"></param>
        public void LogEntryDetailsAdd(clsLogEntryDetailsInfo SentLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_LogEntryDetailsAdd", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@LOGENTRYID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.LOGENTRYID;
                sqlParameter = sqlCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.EMAIL;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORLOGID", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.ERRORLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@DELIVERYSTAUS", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.DELIVERYSTAUS;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_LogEntryDetailsAdd";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Log Entry Details Edit
        /// </summary>
        /// <param name="SentLogInfo"></param>
        public void LogEntryDetailsEdit(clsLogEntryDetailsInfo SentLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_LogEntryDetailsEdit", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@LOGENTRYDETAILSID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.LOGENTRYDETAILSID;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORLOGID", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.ERRORLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.EMAIL;
                sqlParameter = sqlCommand.Parameters.Add("@LOGENTRYID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.LOGENTRYID;
                sqlParameter = sqlCommand.Parameters.Add("@DELIVERYSTAUS", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.DELIVERYSTAUS;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_LogEntryDetailsEdit";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Sent Log ID Max
        /// </summary>
        /// <returns></returns>
        public int SentLogIDMax()
        {
            int result = 0;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                string cmdText = "select ISNULL(max(SENTLOGID)+1,1)AS ID from TBLsentlog";
                result = int.Parse(new SqlCommand(cmdText, this.connection)
                {
                    CommandType = CommandType.StoredProcedure
                }.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_SentLogIDMax";
                LogError(methodName, ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Method for Message Template Add
        /// </summary>
        /// <param name="MessageTemplateInfo"></param>
        public void MessageTemplateAdd(clsMessageTemplateInfo MessageTemplateInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("MessageTemplateAdd", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGETEMPLATEID", SqlDbType.Decimal);
                sqlParameter.Value = MessageTemplateInfo.MESSAGETEMPLATEID;
                sqlParameter = sqlCommand.Parameters.Add("@USERID", SqlDbType.Decimal);
                sqlParameter.Value = MessageTemplateInfo.MESSAGECODE;
                sqlParameter = sqlCommand.Parameters.Add("@FROMUSERTPYEID", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.MESSAGETYPE;
                sqlParameter = sqlCommand.Parameters.Add("@TOUSERTYPEID", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.MESSAGESUBJECTEN;
                sqlParameter = sqlCommand.Parameters.Add("@REQUESTDATE", SqlDbType.DateTime);
                sqlParameter.Value = MessageTemplateInfo.MESSAGESUBJECTAR;
                sqlParameter = sqlCommand.Parameters.Add("@REQUESTREMARK", SqlDbType.Text);
                sqlParameter.Value = MessageTemplateInfo.MESSAGEBODYEN;
                sqlParameter = sqlCommand.Parameters.Add("@REMARK", SqlDbType.Text);
                sqlParameter.Value = MessageTemplateInfo.MESSAGEBODYAR;
                sqlParameter = sqlCommand.Parameters.Add("@CREATEDDATE", SqlDbType.DateTime);
                sqlParameter.Value = MessageTemplateInfo.CREATEDBY;
                sqlParameter = sqlCommand.Parameters.Add("@UPDATEDDATE", SqlDbType.DateTime);
                sqlParameter.Value = MessageTemplateInfo.CREATEDDATE;
                sqlParameter = sqlCommand.Parameters.Add("@CREATEDBY", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.UPDATEDBY;
                sqlParameter = sqlCommand.Parameters.Add("@UPDATEDBY", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.UPDATEDDATE;
                sqlParameter = sqlCommand.Parameters.Add("@STATUS", SqlDbType.VarChar);
                sqlParameter.Value = MessageTemplateInfo.STATUS;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateAdd";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Message Template Edit
        /// </summary>
        /// <param name="MessageTemplateInfo"></param>
        public void MessageTemplateEdit(clsMessageTemplateInfo MessageTemplateInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("EXEC sp_users_MessageTemplateEdit(?,?,?,?)", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@USERID", SqlDbType.Decimal);
                sqlParameter.Value = MessageTemplateInfo.MESSAGECODE;
                sqlParameter = sqlCommand.Parameters.Add("@FROMUSERTPYEID", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.MESSAGETYPE;
                sqlParameter = sqlCommand.Parameters.Add("@TOUSERTYPEID", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.MESSAGESUBJECTEN;
                sqlParameter = sqlCommand.Parameters.Add("@REQUESTDATE", SqlDbType.DateTime);
                sqlParameter.Value = MessageTemplateInfo.MESSAGESUBJECTAR;
                sqlParameter = sqlCommand.Parameters.Add("@REQUESTREMARK", SqlDbType.Text);
                sqlParameter.Value = MessageTemplateInfo.MESSAGEBODYEN;
                sqlParameter = sqlCommand.Parameters.Add("@REMARK", SqlDbType.Text);
                sqlParameter.Value = MessageTemplateInfo.MESSAGEBODYAR;
                sqlParameter = sqlCommand.Parameters.Add("@CREATEDDATE", SqlDbType.DateTime);
                sqlParameter.Value = MessageTemplateInfo.CREATEDBY;
                sqlParameter = sqlCommand.Parameters.Add("@UPDATEDDATE", SqlDbType.DateTime);
                sqlParameter.Value = MessageTemplateInfo.CREATEDDATE;
                sqlParameter = sqlCommand.Parameters.Add("@CREATEDBY", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.UPDATEDBY;
                sqlParameter = sqlCommand.Parameters.Add("@UPDATEDBY", SqlDbType.Int);
                sqlParameter.Value = MessageTemplateInfo.UPDATEDDATE;
                sqlParameter = sqlCommand.Parameters.Add("@STATUS", SqlDbType.VarChar);
                sqlParameter.Value = MessageTemplateInfo.STATUS;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateEdit";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Message Temp[late View All
        /// </summary>
        /// <returns></returns>
        public DataTable MessageTemplateViewAll()
        {
            DataTable dataTable = new DataTable();
            try
            {
                new SqlDataAdapter("MessageTemplateViewAll", this.connection)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                }.Fill(dataTable);
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateViewAll";
                LogError(methodName, ex.Message);
            }
            return dataTable;
        }

        /// <summary>
        /// Method for Message Template View
        /// </summary>
        /// <param name="MESSAGECODE"></param>
        /// <returns></returns>
        public clsMessageTemplateInfo MessageTemplateView(string MESSAGECODE)
        {
            clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_MessageTemplateViewByCode", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGECODE", SqlDbType.VarChar);
                sqlParameter.Value = MESSAGECODE;
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    clsMessageTemplateInfo.MESSAGETEMPLATEID = int.Parse(sqlDataReader[0].ToString());
                    clsMessageTemplateInfo.MESSAGECODE = sqlDataReader[1].ToString();
                    clsMessageTemplateInfo.MESSAGETYPE = sqlDataReader[2].ToString();
                    clsMessageTemplateInfo.MESSAGESUBJECTEN = sqlDataReader[3].ToString();
                    clsMessageTemplateInfo.MESSAGESUBJECTAR = sqlDataReader[4].ToString();
                    clsMessageTemplateInfo.MESSAGEBODYEN = sqlDataReader[5].ToString();
                    clsMessageTemplateInfo.MESSAGEBODYAR = sqlDataReader[6].ToString();
                }
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateView";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
                sqlDataReader.Close();
            }
            return clsMessageTemplateInfo;
        }

        /// <summary>
        /// Method for Message Template Filter By Code N Type
        /// </summary>
        /// <param name="MESSAGECODE"></param>
        /// <param name="MESSAGETYPE"></param>
        /// <returns></returns>
        public clsMessageTemplateInfo MessageTemplateFilterByCodeNType(string MESSAGECODE, string MESSAGETYPE)
        {
            clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_MessageTemplateFilterByCodeNType", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGECODE", SqlDbType.VarChar);
                sqlParameter.Value = MESSAGECODE;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGETYPE", SqlDbType.VarChar);
                sqlParameter.Value = MESSAGETYPE;
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    clsMessageTemplateInfo.MESSAGETEMPLATEID = int.Parse(sqlDataReader["MESSAGETEMPLATEID"].ToString());
                    clsMessageTemplateInfo.MESSAGECODE = sqlDataReader["MESSAGECODE"].ToString();
                    clsMessageTemplateInfo.MESSAGETYPE = sqlDataReader["MESSAGETYPE"].ToString();
                    clsMessageTemplateInfo.MESSAGESUBJECTEN = sqlDataReader["MESSAGESUBJECT"].ToString();
                    clsMessageTemplateInfo.MESSAGEDESCRIPTEN = sqlDataReader["MESSAGEBODY"].ToString();
                    clsMessageTemplateInfo.MESSAGEBODYEN = sqlDataReader["SMSMESSAGEBODY"].ToString();
                    clsMessageTemplateInfo.ISBODYHTML = bool.Parse(sqlDataReader["ISBODYHTML"].ToString());
                }
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateFilterByCodeNType";
                LogError(methodName, ex.Message);

                clsErrorLogger objError = new clsErrorLogger();
                objError.LogErrorInFile(methodName, ex.Message, 0);
                
            }
            finally
            {
                this.connection.Close();
                this.connection.Dispose();
                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
            return clsMessageTemplateInfo;
        }

        /// <summary>
        /// Method for Message Template Delete
        /// </summary>
        /// <param name="MESSAGETEMPLATEID"></param>
        public void MessageTemplateDelete(decimal MESSAGETEMPLATEID)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_MessageTemplateDelete", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGETEMPLATEID", SqlDbType.Decimal);
                sqlParameter.Value = MESSAGETEMPLATEID;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateDelete";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Template Count
        /// </summary>
        /// <returns></returns>
        public int MessageTemplateCount()
        {
            int result = 0;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                result = int.Parse(new SqlCommand("MessageTemplateCount", this.connection)
                {
                    CommandType = CommandType.StoredProcedure
                }.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_MessageTemplateCount";
                LogError(methodName, ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Method for SMS Log Details Add
        /// </summary>
        /// <param name="SentLogInfo"></param>
        public void SMSLOGDetailsAdd(clsSMSLogDetailsInfo SentLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_smsLogDetailsAdd", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@SMSLOGID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.SMSLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@MOBILENOS", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.MOBILENOS;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORLOGID", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.ERRORLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@DELIVERYSTAUSCODE", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.DELIVERYSTAUSCODE;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlParameter = sqlCommand.Parameters.Add("@CONTRACTNO", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.CONTRACTNO;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_SMSLOGDetailsAdd";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for SMS LOG Details Edit
        /// </summary>
        /// <param name="SentLogInfo"></param>
        public void SMSLOGDetailsEdit(clsSMSLogDetailsInfo SentLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_smsLogDetailsEdit", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@SMSLOGDETAILSID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.SMSLOGDETAILSID;
                sqlParameter = sqlCommand.Parameters.Add("@ERRORLOGID", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.ERRORLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@MOBILENOS", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.MOBILENOS;
                sqlParameter = sqlCommand.Parameters.Add("@SMSLOGID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.SMSLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@DELIVERYSTAUSCODE", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.DELIVERYSTAUSCODE;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_SMSLOGDetailsEdit";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for SMS Log Add
        /// </summary>
        /// <param name="SentLogInfo"></param>
        /// <returns></returns>
        public decimal SMSLogAdd(clsSMSLogInfo SentLogInfo)
        {
            decimal result = 0m;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_SMSLogAdd", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@SERVER", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.SERVER;
                sqlParameter = sqlCommand.Parameters.Add("@REFERENCENO", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.REFERENCENO;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGECODE", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.MESSAGECODE;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGETYPE", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.MESSAGETYPE;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGE", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.MESSAGE;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlParameter = sqlCommand.Parameters.Add("@STATUS", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.STATUS;
                result = decimal.Parse(sqlCommand.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_SMSLogAdd";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Method for SMS Log Edit
        /// </summary>
        /// <param name="SentLogInfo"></param>
        public void SMSLogEdit(clsSMSLogInfo SentLogInfo)
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_SMSLogEdit", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@SentLOGID", SqlDbType.Decimal);
                sqlParameter.Value = SentLogInfo.SMSLOGID;
                sqlParameter = sqlCommand.Parameters.Add("@SERVER", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.SERVER;
                sqlParameter = sqlCommand.Parameters.Add("@REFERENCENO", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.REFERENCENO;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGETYPE", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.MESSAGETYPE;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGECODE", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.MESSAGECODE;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlParameter = sqlCommand.Parameters.Add("@STATUS", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.STATUS;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGE", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.MESSAGE;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_SMSLogEdit";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method for Log Entry Add
        /// </summary>
        /// <param name="SentLogInfo"></param>
        /// <returns></returns>
        public decimal LogEntryAdd(clsLogEntryInfo SentLogInfo)
        {
            decimal result = 0m;
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_LogEntryAdd", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = sqlCommand.Parameters.Add("@SERVER", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.SERVER;
                sqlParameter = sqlCommand.Parameters.Add("@REFERENCENO", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.REFERENCENO;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGECODE", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.MESSAGECODE;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGETYPE", SqlDbType.VarChar);
                sqlParameter.Value = SentLogInfo.MESSAGETYPE;
                sqlParameter = sqlCommand.Parameters.Add("@SUBJECT", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.SUBJECT;
                sqlParameter = sqlCommand.Parameters.Add("@MESSAGE", SqlDbType.NVarChar);
                sqlParameter.Value = SentLogInfo.MESSAGE;
                sqlParameter = sqlCommand.Parameters.Add("@DATE", SqlDbType.DateTime);
                sqlParameter.Value = SentLogInfo.DATE;
                sqlParameter = sqlCommand.Parameters.Add("@STATUS", SqlDbType.Int);
                sqlParameter.Value = SentLogInfo.STATUS;
                result = decimal.Parse(sqlCommand.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                methodName = "clsCommonSP_LogEntryAdd";
                LogError(methodName, ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Method for Log Error
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="errorMessage"></param>
        public void LogError(string methodName, string errorMessage)
         {
            try
            {
                string.Format("Exception(" + methodName + ") Common: {0}", errorMessage);
                clsErrorLogInfo errorLogInfo = new clsErrorLogInfo
                {
                    ERRORCODE = "",
                    ERRORDESCRIPTION = errorMessage,
                    ERRORTYPE = "",
                    CREATEDDATE = DateTime.Now
                };

                ErrorLogAdd(errorLogInfo);
            }

            catch (Exception)
            {
                clsErrorLogger objError = new clsErrorLogger();
                objError.LogErrorInFile("Exception(" + methodName + ") Common: {0}", errorMessage, 0);
            }
        }   

    }
}
