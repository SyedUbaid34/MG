using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.IO;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Text;
using DAL;
using System.Linq;
using System.Configuration;
using ErrorLogger;

namespace MessagingGateway
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IjarahMessagingGateway" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IjarahMessagingGateway.svc or IjarahMessagingGateway.svc.cs at the Solution Explorer and start debugging.
    public class ijaraMessagingGateway : IijaraMessagingGateway
    {
        private static Semaphore mailSendSemaphore = new Semaphore(10, 10);

        clsCommonSP objCommonSP = new clsCommonSP();

        clsErrorLogger objError = new clsErrorLogger();       

        string methodName;

        /// <summary>
        /// Method for sending SMS
        /// </summary>
        /// <param name="objIjarahSMS"></param>
        /// <returns></returns>
        public string SendSMS(IjarahSMS objIjarahSMS)
        {

            objError.LogErrorInFile("SendSMS_"+DateTime.Now.ToString(), objIjarahSMS.Recipients.ToString() , 0);

            string result = "FAIL";
            if (objIjarahSMS != null)
            {
                clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                try
                {
                    if (objIjarahSMS.CustomMessage != null && objIjarahSMS.CustomMessage != string.Empty)
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahSMS.CustomMessage;
                        clsMessageTemplateInfo.MESSAGECODE = "CUSTOM";
                    }
                    else
                    {

                        clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahSMS.MessageCode, objIjarahSMS.MessageType);
                        
                        if (objIjarahSMS.MessageCode == "0001")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0002")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0003")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0004")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0005")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0006")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0007")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSMS.Amount.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "0012")
                        {
                            if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#123#", objIjarahSMS.Amount.ToString()).Replace("#123456#", objIjarahSMS.SMSReference.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "CLN0101")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.ToString();
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.ToString();
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "CLC0103")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString());
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSMS.AccountNumber.ToString());
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "CLY0102")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.ToString();
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.ToString();
                            }
                        } //Added by zubair.23-02-17
                        else if (objIjarahSMS.MessageCode == "CESSMS01")
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#INSD#", objIjarahSMS.DueDate.ToString()).Replace("#AMT#", objIjarahSMS.Amount.ToString());
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#INSD#", objIjarahSMS.DueDate.ToString()).Replace("#AMT#", objIjarahSMS.Amount.ToString());
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "SMSIEGTBE") //Added by Satish.M on 19/12/2017
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CARPLTNO#", objIjarahSMS.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarahSMS.AccountNumber.ToString());
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CARPLTNO#", objIjarahSMS.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarahSMS.AccountNumber.ToString());
                            }
                        }
                        else if (objIjarahSMS.MessageCode == "SMSIEE") //Added by Satish.M on 19/12/2017
                        {
                            if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CARPLTNO#", objIjarahSMS.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarahSMS.AccountNumber.ToString());
                            }
                            else if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CARPLTNO#", objIjarahSMS.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarahSMS.AccountNumber.ToString());
                            }
                        }

                        else if (objIjarahSMS.MessageCode == "TAMMSMS") // Added by Zubair on 20-Mar-2018
                        {
                            if (objIjarahSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN;

                            }
                            else if (objIjarahSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN;
                            }
                        }

                    }

                    //Added by KISL:Satish.M on 24072017
                    if (!(clsMessageTemplateInfo.MESSAGEBODYEN.Contains("\r\n")))
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("\n", Environment.NewLine);
                    }
                    

                    if (objIjarahSMS.AccountNumber.ToString() == "" || objIjarahSMS.AccountNumber.ToString() == string.Empty)
                    {
                        clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                        {
                            MESSAGETYPE = objIjarahSMS.MessageType,
                            MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                            MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                            SERVER = objIjarahSMS.PartnerCode,
                            REFERENCENO = objIjarahSMS.SMSReference,
                            RECIPIENTS = objIjarahSMS.Recipients.Trim(),
                            DATE = DateTime.Now,
                            STATUS = 1,
                            CONTRACTNO = ""
                        };

                        CommonSendSMS(sentLogInfo, ref result);
                    }
                    else
                    {
                        if (objIjarahSMS.AccountNumber.Length > 5)
                        {
                            clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                            {
                                MESSAGETYPE = objIjarahSMS.MessageType,
                                MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                                MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                                SERVER = objIjarahSMS.PartnerCode,
                                REFERENCENO = objIjarahSMS.SMSReference,
                                RECIPIENTS = objIjarahSMS.Recipients.Trim(),
                                DATE = DateTime.Now,
                                STATUS = 1,
                                CONTRACTNO = objIjarahSMS.AccountNumber.Substring(5) //Added by KISL on 30/01/2018
                            };

                            CommonSendSMS(sentLogInfo, ref result);
                        }
                        else
                        {
                            clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                            {
                                MESSAGETYPE = objIjarahSMS.MessageType,
                                MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                                MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                                SERVER = objIjarahSMS.PartnerCode,
                                REFERENCENO = objIjarahSMS.SMSReference,
                                RECIPIENTS = objIjarahSMS.Recipients.Trim(),
                                DATE = DateTime.Now,
                                STATUS = 1,
                                CONTRACTNO = ""
                            };

                            CommonSendSMS(sentLogInfo, ref result);
                        }
                       
                    }                        
                }
                catch (Exception ex)
                {
                    methodName = "IjarahMessagingGateway_SendSMS";
                    objCommonSP.LogError(methodName, ex.Message);


                    string Message = string.Empty;

                    if (clsMessageTemplateInfo.MESSAGEBODYEN != "" && clsMessageTemplateInfo.MESSAGEBODYEN != string.Empty && clsMessageTemplateInfo.MESSAGEBODYEN != null)
                    {
                        Message = clsMessageTemplateInfo.MESSAGEBODYEN;
                    }

                    if (objIjarahSMS.AccountNumber.ToString() == "" || objIjarahSMS.AccountNumber.ToString() == string.Empty)               //Added by KISL on 01/03/2018
                    {
                        clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                        {
                            MESSAGETYPE = objIjarahSMS.MessageType,
                            MESSAGE = Message,
                            MESSAGECODE = objIjarahSMS.MessageCode,
                            SERVER = objIjarahSMS.PartnerCode,
                            REFERENCENO = objIjarahSMS.SMSReference,
                            RECIPIENTS = objIjarahSMS.Recipients.Trim(),
                            DATE = DateTime.Now,
                            STATUS = 1,
                            CONTRACTNO = ""
                        };

                        decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                        clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                        {
                            SMSLOGID = sMSLOGID,
                            ERRORLOGID = 0,
                            MOBILENOS = sentLogInfo.RECIPIENTS,
                            DELIVERYSTAUSCODE = "422",
                            DATE = DateTime.Now,
                            CONTRACTNO = sentLogInfo.CONTRACTNO
                        };
                        new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                    }
                    else
                    {
                        if (objIjarahSMS.AccountNumber.Length > 5)
                        {
                            clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                            {
                                MESSAGETYPE = objIjarahSMS.MessageType,
                                MESSAGE = Message,
                                MESSAGECODE = objIjarahSMS.MessageCode,
                                SERVER = objIjarahSMS.PartnerCode,
                                REFERENCENO = objIjarahSMS.SMSReference,
                                RECIPIENTS = objIjarahSMS.Recipients.Trim(),
                                DATE = DateTime.Now,
                                STATUS = 1,
                                CONTRACTNO = objIjarahSMS.AccountNumber.Substring(5) 
                            };

                            decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                            clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                            {
                                SMSLOGID = sMSLOGID,
                                ERRORLOGID = 0,
                                MOBILENOS = sentLogInfo.RECIPIENTS,
                                DELIVERYSTAUSCODE = "422",
                                DATE = DateTime.Now,
                                CONTRACTNO = sentLogInfo.CONTRACTNO
                            };
                            new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                        }
                        else
                        {
                            clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                            {
                                MESSAGETYPE = objIjarahSMS.MessageType,
                                MESSAGE = Message,
                                MESSAGECODE = objIjarahSMS.MessageCode,
                                SERVER = objIjarahSMS.PartnerCode,
                                REFERENCENO = objIjarahSMS.SMSReference,
                                RECIPIENTS = objIjarahSMS.Recipients.Trim(),
                                DATE = DateTime.Now,
                                STATUS = 1,
                                CONTRACTNO = ""
                            };

                            decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                            clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                            {
                                SMSLOGID = sMSLOGID,
                                ERRORLOGID = 0,
                                MOBILENOS = sentLogInfo.RECIPIENTS,
                                DELIVERYSTAUSCODE = "422",
                                DATE = DateTime.Now,
                                CONTRACTNO = sentLogInfo.CONTRACTNO
                            };
                            new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Method for sending OTP
        /// </summary>
        /// <param name="objIjarahOTPSMS"></param>
        /// <returns></returns>
        public string SendOTP(IjarahOTPSMS objIjarahOTPSMS)
        {
            objError.LogErrorInFile("SendOTP_" + DateTime.Now.ToString(), objIjarahOTPSMS.Recipients.ToString(), 0);

            string result = "FAIL";
            if (objIjarahOTPSMS != null)
            {
                clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                try
                {                  
                    if (objIjarahOTPSMS.CustomMessage != null && objIjarahOTPSMS.CustomMessage != string.Empty)
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahOTPSMS.CustomMessage;
                        clsMessageTemplateInfo.MESSAGECODE = "CUSTOM";
                    }
                    else
                    {
                        clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahOTPSMS.MessageCode, objIjarahOTPSMS.MessageType);

                        if (objIjarahOTPSMS.MessageCode == "0001")
                        {
                            if (objIjarahOTPSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahOTPSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahOTPSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahOTPSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahOTPSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahOTPSMS.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                    }

                    //Added by KISL:Satish.M on 24072017
                    if (!(clsMessageTemplateInfo.MESSAGEBODYEN.Contains("\r\n")))
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("\n", Environment.NewLine);
                    }

                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                    {
                        MESSAGETYPE = objIjarahOTPSMS.MessageType,
                        MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                        MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                        SERVER = objIjarahOTPSMS.PartnerCode,
                        REFERENCENO = objIjarahOTPSMS.SMSReference,
                        RECIPIENTS = objIjarahOTPSMS.Recipients.Trim(),
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahOTPSMS.OpportunityNumber.Trim()
                    };
                    CommonSendSMS(sentLogInfo, ref result, "OTP");
                }
                catch (Exception ex)
                {
                    methodName = "IjarahMessagingGateway_SendOTP";
                    objCommonSP.LogError(methodName, ex.Message);

                    string Message = string.Empty;

                    if (clsMessageTemplateInfo.MESSAGEBODYEN != "" && clsMessageTemplateInfo.MESSAGEBODYEN != string.Empty && clsMessageTemplateInfo.MESSAGEBODYEN != null)
                    {
                        Message = clsMessageTemplateInfo.MESSAGEBODYEN;
                    }


                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo                   //Added by Satish.M on 01/03/2018
                    {
                        MESSAGETYPE = objIjarahOTPSMS.MessageType,
                        MESSAGE = Message,
                        MESSAGECODE = objIjarahOTPSMS.MessageCode,
                        SERVER = objIjarahOTPSMS.PartnerCode,
                        REFERENCENO = objIjarahOTPSMS.SMSReference,
                        RECIPIENTS = objIjarahOTPSMS.Recipients.Trim(),
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahOTPSMS.OpportunityNumber.Trim()
                    };

                    decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                    clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                    {
                        SMSLOGID = sMSLOGID,
                        ERRORLOGID = 0,
                        MOBILENOS = sentLogInfo.RECIPIENTS,
                        DELIVERYSTAUSCODE = "422",   
                        DATE = DateTime.Now,
                        CONTRACTNO = sentLogInfo.CONTRACTNO                        
                    };
                    new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                }
            }
            return result;
        }

        /// <summary>
        /// Method for sending SRSMS
        /// </summary>
        /// <param name="objIjarahSRSMS"></param>
        /// <returns></returns>
        public string SendSRSms(IjarahSRSms objIjarahSRSMS)
        {
            objError.LogErrorInFile("SendSRSms_" + DateTime.Now.ToString(), objIjarahSRSMS.Recipients.ToString(), 0);

            string result = "FAIL";
            if (objIjarahSRSMS != null)
            {
                clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                try
                {

                    if (objIjarahSRSMS.CustomMessage != null && objIjarahSRSMS.CustomMessage != string.Empty)
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahSRSMS.CustomMessage;
                        clsMessageTemplateInfo.MESSAGECODE = "CUSTOM";
                    }
                    else
                    {
                        clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahSRSMS.MessageCode, objIjarahSRSMS.MessageType);

                        if (objIjarahSRSMS.MessageCode == "0001")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0002")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0003")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0004")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0005")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0006")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0007")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0008")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFACC#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("#REFDATE#", objIjarahSRSMS.DueDate.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFACC#", objIjarahSRSMS.OpportunityNumber.ToString()).Replace("#REFDATE#", objIjarahSRSMS.DueDate.ToString());
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0009")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFACC#", objIjarahSRSMS.SubCategory.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.SadadReferenceNumber.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSRSMS.Amount.ToString()).Replace("#REFACC#", objIjarahSRSMS.SubCategory.ToString()).Replace("#REFSADAD#", objIjarahSRSMS.SadadReferenceNumber.ToString());
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "0010")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSRSMS.SubCategory.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSRSMS.SubCategory.ToString());
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "CRSMS01")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFCRNO#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFCRNO#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "CRSMS02")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFCRNO#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFCRNO#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "ADCUST")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFCRNO#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFCRNO#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                        }
                        else if (objIjarahSRSMS.MessageCode == "CSSSSMS01")
                        {
                            if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.ToString();
                            }
                            else if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.ToString();
                            }
                        }/*//Adde by Zubair 17-Apr-2017*/
                        else if (objIjarahSRSMS.MessageCode == "SRPRSMS01")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#SRN#", objIjarahSRSMS.SMSReference.ToString()).Replace("#AMT#", objIjarahSRSMS.Amount.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#SRN#", objIjarahSRSMS.SMSReference.ToString()).Replace("#AMT#", objIjarahSRSMS.Amount.ToString());
                            }
                        }
                        //Added by KISL on 9th July 2017
                        else if (objIjarahSRSMS.MessageCode == "ACICSMS01")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CN#", objIjarahSRSMS.Category.ToString()).Replace("#AN#", objIjarahSRSMS.SadadReferenceNumber.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CN#", objIjarahSRSMS.Category.ToString()).Replace("#AN#", objIjarahSRSMS.SadadReferenceNumber.ToString()); 
                            }                           
                        }
                        //Added by Zubair on 12th March 2018
                        else if (objIjarahSRSMS.MessageCode == "CRISMS01")
                        {
                            if (objIjarahSRSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CN#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                            else if (objIjarahSRSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#CN#", objIjarahSRSMS.OpportunityNumber.ToString());
                            }
                        }
                    }

                    //Added by KISL:Satish.M on 24072017
                    if (!(clsMessageTemplateInfo.MESSAGEBODYEN.Contains("\r\n")))
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("\n", Environment.NewLine);
                    }

                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                    {
                        MESSAGETYPE = objIjarahSRSMS.MessageType,
                        MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                        MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                        RECIPIENTS = objIjarahSRSMS.Recipients.Trim(),
                        SERVER = objIjarahSRSMS.PartnerCode,
                        REFERENCENO = objIjarahSRSMS.SMSReference,
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahSRSMS.OpportunityNumber                        
                    };
                    CommonSendSMS(sentLogInfo, ref result);
                }
                catch (Exception ex)
                {
                    methodName = "IjarahMessagingGateway_SendSRSms";
                    objCommonSP.LogError(methodName, ex.Message);

                    string Message = string.Empty;

                    if (clsMessageTemplateInfo.MESSAGEBODYEN != "" && clsMessageTemplateInfo.MESSAGEBODYEN != string.Empty && clsMessageTemplateInfo.MESSAGEBODYEN != null)
                    {
                        Message = clsMessageTemplateInfo.MESSAGEBODYEN;
                    }
              
                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                    {
                        MESSAGETYPE = objIjarahSRSMS.MessageType,
                        MESSAGE = Message,
                        MESSAGECODE = objIjarahSRSMS.MessageCode,
                        RECIPIENTS = objIjarahSRSMS.Recipients.Trim(),
                        SERVER = objIjarahSRSMS.PartnerCode,
                        REFERENCENO = objIjarahSRSMS.SMSReference,
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahSRSMS.OpportunityNumber
                    };

                    decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                    clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                    {
                        SMSLOGID = sMSLOGID,
                        ERRORLOGID = 0,
                        MOBILENOS = sentLogInfo.RECIPIENTS,
                        DELIVERYSTAUSCODE = "422",
                        DATE = DateTime.Now,
                        CONTRACTNO = sentLogInfo.CONTRACTNO
                    };
                    new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                }
            }
            return result;
        }

        /// <summary>
        /// Method for sending Sale SMS
        /// </summary>
        /// <param name="objIjarahSalesSMS"></param>
        /// <returns></returns>
        public string SendSaleSMS(IjarahSaleSMS objIjarahSalesSMS)
        {
            objError.LogErrorInFile("SendSaleSMS_" + DateTime.Now.ToString(), objIjarahSalesSMS.Recipients.ToString(), 0);

            clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();

            string result = "FAIL";

            if (objIjarahSalesSMS != null)
            {
                try
                {                   
                    if (objIjarahSalesSMS.CustomMessage != null && objIjarahSalesSMS.CustomMessage != string.Empty)
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahSalesSMS.CustomMessage;

                        clsMessageTemplateInfo.MESSAGECODE = "CUSTOM";
                    }
                    else
                    {
                        clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahSalesSMS.MessageCode, objIjarahSalesSMS.MessageType);

                        if (objIjarahSalesSMS.MessageCode == "0001")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0002")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0003")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0004")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0005")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0006")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString());
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0007")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("8001111800", "920033800");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0008")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFACC#", objIjarahSalesSMS.ApplicationNum.ToString());
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFACC#", objIjarahSalesSMS.ApplicationNum.ToString());
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0009")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFACC#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.SADADRefNum.ToString());
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFACC#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.SADADRefNum.ToString());
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "0010")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSalesSMS.AdminFee.ToString());
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSalesSMS.AdminFee.ToString());
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSRV0101")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString());
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString());
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSAP0102")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesSMS.DownPayment.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFTAMT#", objIjarahSalesSMS.Totalamount.ToString()).Replace("#REFACC#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesSMS.Totalamount.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFTAMT#", objIjarahSalesSMS.DownPayment.ToString()).Replace("#REFACC#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSAP0203")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesSMS.DownPayment.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFDUAMT#", objIjarahSalesSMS.Totalamount.ToString()).Replace("#REFACC#", objIjarahSalesSMS.SADADRefNum.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesSMS.DownPayment.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.AdminFee.ToString()).Replace("#REFDUAMT#", objIjarahSalesSMS.Totalamount.ToString()).Replace("#REFACC#", objIjarahSalesSMS.SADADRefNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSDP0104")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.Totalamount.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.Totalamount.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSGC0105")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSDS0106")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSPI0107")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSCR0108")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSPD0109")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "SSAR0110")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFCAR#", objIjarahSalesSMS.Carbrand.ToString()).Replace("#REFCARPLATE#", objIjarahSalesSMS.Numberplate.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.SADADRefNum.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("Ijarah", "Ijarah Finance");
                                objIjarahSalesSMS.MessageType = "U";
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFCAR#", objIjarahSalesSMS.Carbrand.ToString()).Replace("#REFCARPLATE#", objIjarahSalesSMS.Numberplate.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.SADADRefNum.ToString()).Replace("#REFAMT#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "INS0101")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }
                        else if (objIjarahSalesSMS.MessageCode == "INS0102")
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("8001111800", "920033800").Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFSADAD#", objIjarahSalesSMS.VirtualAccntNum.ToString()).Replace("8001111800", "920033800").Replace("إيجارة", "إيجارة للتمويل");
                            }
                        }

                        else if (objIjarahSalesSMS.MessageCode == "SSPA0111") // Added by KISL on 14th Nov 2016
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#REFNAME#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString());
                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("123", objIjarahSalesSMS.Firstname.ToString()).Replace("456", objIjarahSalesSMS.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()).Replace("@", Environment.NewLine);
                            }
                        }

                        else if (objIjarahSalesSMS.MessageCode == "SSCC0111") // Added by Zubair on 29-May-17
                        {
                            if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#FN#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString());

                            }
                            else if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#FN#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString()); //Added refgender by KISL: Satish.M on 26072017
                            }
                        }

                        else if (objIjarahSalesSMS.MessageCode == "SMST") // Added by Zubair on 29-May-17
                        {
                            if (objIjarahSalesSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#FN#", objIjarahSalesSMS.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesSMS.Gender.ToString());

                            }
                            else if (objIjarahSalesSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("#FN#", objIjarahSalesSMS.Firstname.ToString());
                            }
                        }

                    }

                    //Added by KISL:Satish.M on 24072017
                    if (!(clsMessageTemplateInfo.MESSAGEBODYEN.Contains("\r\n")))
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("\n", Environment.NewLine);
                    }


                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                    {
                        MESSAGETYPE = objIjarahSalesSMS.MessageType,
                        MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                        MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                        RECIPIENTS = objIjarahSalesSMS.Recipients.Trim(),
                        SERVER = objIjarahSalesSMS.PartnerCode,
                        REFERENCENO = objIjarahSalesSMS.SMSReference,
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahSalesSMS.ApplicationNum
                    };
                    CommonSendSMS(sentLogInfo, ref result);
                }
                catch (Exception ex)
                {
                    methodName = "IjarahMessagingGateway_SendSaleSMS";
                    objCommonSP.LogError(methodName, ex.Message);

                    string Message = string.Empty;

                    if (clsMessageTemplateInfo.MESSAGEBODYEN != "" && clsMessageTemplateInfo.MESSAGEBODYEN != string.Empty && clsMessageTemplateInfo.MESSAGEBODYEN != null)
                    {
                        Message = clsMessageTemplateInfo.MESSAGEBODYEN;
                    }

                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo                                   //Added by Satish.M on 01/03/2018
                    {
                        MESSAGETYPE = objIjarahSalesSMS.MessageType,
                        MESSAGE = Message,
                        MESSAGECODE = objIjarahSalesSMS.MessageCode,
                        RECIPIENTS = objIjarahSalesSMS.Recipients.Trim(),
                        SERVER = objIjarahSalesSMS.PartnerCode,
                        REFERENCENO = objIjarahSalesSMS.SMSReference,
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahSalesSMS.ApplicationNum
                    };

                    decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                    clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                    {
                        SMSLOGID = sMSLOGID,
                        ERRORLOGID = 0,
                        MOBILENOS = sentLogInfo.RECIPIENTS,
                        DELIVERYSTAUSCODE = "422",
                        DATE = DateTime.Now,
                        CONTRACTNO = sentLogInfo.CONTRACTNO                        
                    };
                    new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                }
            }
            return result;
        }

        /// <summary>
        /// Metthod for sending POS SMS
        /// </summary>
        /// <param name="objIjarahPOSSMS"></param>
        /// <returns></returns>
        public string SendPOSSMS(IjarahPOSSms objIjarahPOSSMS)
        {
            objError.LogErrorInFile("SendPOSSMS_" + DateTime.Now.ToString(), objIjarahPOSSMS.Recipients.ToString(), 0);

            string result = "FAIL";
            if (objIjarahPOSSMS != null)
            {
                clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                try
                {                                   
                    if (objIjarahPOSSMS.CustomMessage != null && objIjarahPOSSMS.CustomMessage != string.Empty)
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahPOSSMS.CustomMessage;
                        clsMessageTemplateInfo.MESSAGECODE = "CUSTOM";
                    }
                    else
                    {
                        clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahPOSSMS.MessageCode, objIjarahPOSSMS.MessageType);

                        if (objIjarahPOSSMS.MessageCode == "0011")
                        {
                            if (objIjarahPOSSMS.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("×12×", objIjarahPOSSMS.amount.ToString()).Replace("×123456×", objIjarahPOSSMS.referencenumber.ToString()).Replace("Ijarah", "Ijarah Finance");
                            }
                            else if (objIjarahPOSSMS.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("×12×", objIjarahPOSSMS.amount.ToString()).Replace("×123456×", objIjarahPOSSMS.referencenumber.ToString());
                            }
                        }
                    }

                    //Added by KISL:Satish.M on 24072017
                    if (!(clsMessageTemplateInfo.MESSAGEBODYEN.Contains("\r\n")))
                    {
                        clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEBODYEN.Replace("\n", Environment.NewLine);
                    }

                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo
                    {
                        MESSAGETYPE = objIjarahPOSSMS.MessageType,
                        MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                        MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                        RECIPIENTS = objIjarahPOSSMS.Recipients.Trim(),
                        SERVER = objIjarahPOSSMS.PartnerCode,
                        REFERENCENO = objIjarahPOSSMS.SMSReference,
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahPOSSMS.referencenumber
                    };
                    CommonSendSMS(sentLogInfo, ref result);
                }
                catch (Exception ex)
                {
                    methodName = "IjarahMessagingGateway_SendPOSSMS";
                    objCommonSP.LogError(methodName, ex.Message);

                    string Message = string.Empty;

                    if (clsMessageTemplateInfo.MESSAGEBODYEN != "" && clsMessageTemplateInfo.MESSAGEBODYEN != string.Empty && clsMessageTemplateInfo.MESSAGEBODYEN != null)
                    {
                        Message = clsMessageTemplateInfo.MESSAGEBODYEN;
                    }

                    clsSMSLogInfo sentLogInfo = new clsSMSLogInfo                           //Added by Satish.M on 01/03/2018
                    {
                        MESSAGETYPE = objIjarahPOSSMS.MessageType,
                        MESSAGE = Message,
                        MESSAGECODE = objIjarahPOSSMS.MessageCode,
                        RECIPIENTS = objIjarahPOSSMS.Recipients.Trim(),
                        SERVER = objIjarahPOSSMS.PartnerCode,
                        REFERENCENO = objIjarahPOSSMS.SMSReference,
                        DATE = DateTime.Now,
                        STATUS = 1,
                        CONTRACTNO = objIjarahPOSSMS.referencenumber
                    };

                    decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);

                    clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                    {
                        SMSLOGID = sMSLOGID,
                        ERRORLOGID = 0,
                        MOBILENOS = sentLogInfo.RECIPIENTS,
                        DELIVERYSTAUSCODE = "422",
                        DATE = DateTime.Now,
                        CONTRACTNO = sentLogInfo.CONTRACTNO
                    };
                    new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
                }
            }
            return result;
        }

        /// <summary>
        /// Method for checking SMS Credit
        /// </summary>
        /// <returns></returns>
        public string CheckSMSCredit()
        {
            try
            {
                string requestUriString = ConfigurationManager.AppSettings["CHECKSMS"];
                CookieContainer cookieContainer = new CookieContainer();
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Proxy = null;
                httpWebRequest.UseDefaultCredentials = true;
                httpWebRequest.KeepAlive = false;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                httpWebRequest.CookieContainer = cookieContainer;
                WebResponse response = httpWebRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                return streamReader.ReadToEnd();
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_CheckSMSCredit";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }

        }

        /// <summary>
        /// Method for converting text to hex
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string ConvertTextTohex(string message)
        {
            try
            {
                string text = "";
                for (int i = 0; i < message.Length; i++)
                {
                    char c = message[i];
                    int num = (int)c;
                    string str = num.ToString("X4");
                    text += str;
                }
                return text;
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_ConvertTextTohex";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Method for converting String to Hex
        /// </summary>
        /// <param name="asciiString"></param>
        /// <returns></returns>
        public string ConvertStringToHex(string asciiString)
        {
            try
            {
                string text = "";
                for (int i = 0; i < asciiString.Length; i++)
                {
                    char c = asciiString[i];
                    int num = (int)c;
                    text += string.Format("{0:x2}", Convert.ToUInt32(num.ToString()));
                }
                return text;
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_ConvertStringToHex";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Method for Accepting all Certificates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private bool AcceptAllCertificates(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            try
            {
                return true;
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_AcceptAllCertificates";
                objCommonSP.LogError(methodName, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method for certificate validation Call Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        public static bool CertificateValidationCallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            try
            {
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }
                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) != SslPolicyErrors.None)
                {
                    if (chain != null && chain.ChainStatus != null)
                    {
                        X509ChainStatus[] chainStatus = chain.ChainStatus;
                        for (int i = 0; i < chainStatus.Length; i++)
                        {
                            X509ChainStatus x509ChainStatus = chainStatus[i];
                            if ((!(certificate.Subject == certificate.Issuer) || x509ChainStatus.Status != X509ChainStatusFlags.UntrustedRoot) && x509ChainStatus.Status != X509ChainStatusFlags.NoError)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {
                string method = "IjarahMessagingGateway_CertificateValidationCallBack";
                clsCommonSP objCom = new clsCommonSP();
                objCom.LogError(method, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method for Redirection Url Validation Call back
        /// </summary>
        /// <param name="redirectionUrl"></param>
        /// <returns></returns>
        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            try
            {
                bool result = false;
                Uri uri = new Uri(redirectionUrl);
                if (uri.Scheme == "https")
                {
                    result = true;
                }
                return result;
            }

            catch (Exception ex)
            {
                string method = "IjarahMessagingGateway_RedirectionUrlValidationCallback";
                clsCommonSP objCom = new clsCommonSP();
                objCom.LogError(method, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Method for Email Cover
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Emailcover(string input)
        {
            try
            {
                string text = input.Replace("<p>", "").Replace("<p>", "<p style='line-height:4px;margin:5px 0px;'>");
                string str = text.Replace("<p></p>", "").Replace("<style>body{font-family:Arial, sans-serif; }", "<style>body{font-family:Neo Sans W23;}");
                return FormatEmail(str, "N");
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_Emailcover";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Method for Email Cover Arabic
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EmailcoverArabic(string input)
        {
            try
            {
                string text = input.Replace("<p>", "<p style='line-height:17px;direction:rtl;text-align:right;margin:5px 0px;'>");
                string text2 = text.Replace("<p></p>", "");
                string str = text2.Replace("<style>body{font-family:Arial, sans-serif;direction:RTL }", "<style>body{font-family:Neo Sans W23;}");
                return FormatEmail(str, "U");
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_EmailcoverArabic";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Method for common Email
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Emailcommon(string input)
        {
            try
            {
                return input.Replace("<!doctype html><html><head><meta charset='utf-8'><title>Untitled Document</title><style>body{font-family:Arial, sans-serif; }", "<!doctype html><html><head><meta charset='utf-8'><title>Untitled Document</title><style>@font-face {font-family: 'Neosans';src: url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.eot');src: url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.eot?#iefix') format('embedded-opentype'),url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.svg#Neo Sans W23') format('svg'),url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.woff') format('woff'),url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.ttf') format('truetype');font-weight: normal;font-style: normal;}");
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_Emailcommon";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Email for Email Ramadan
        /// </summary>
        /// <returns></returns>
        public string EmailRamadan()
        {
            try
            {
                return "<!doctype html><html><head><meta charset='utf-8'><title>Ijarah</title></head><body leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'><center><img src='http://ijarah.sa/sites/all/themes/successinc/images/email/Ramadan-Invitation-ar.jpg'></center></body></html>";
            }

            catch (Exception ex)
            {
                methodName = "ijaraMessagingGateway_EmailRamadan";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// method for sending email in arabic Ramadan
        /// </summary>
        /// <returns></returns>
        public string EmailRamadanArabic()
        {
            try
            {
                return "<!doctype html><html><head><meta charset='utf-8'><title>Ijarah</title></head><body leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'><center><img src='http://ijarah.sa/sites/all/themes/successinc/images/email/Ramadan-Invitation.jpg'></center></body></html>";
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_EmailRamadanArabic";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Email for Common Arabic
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EmailcommonArabic(string input)
        {
            try
            {
                return input.Replace("<!doctype html><html><head><meta charset='utf-8'><title>Untitled Document</title><style>body{font-family:Arial, sans-serif;direction:RTL }", "<!doctype html><html><head><meta charset='utf-8'><title>Untitled Document</title><style>body{direction:RTL }@font-face {font-family: 'Neosans';src: url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.eot');src: url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.eot?#iefix') format('embedded-opentype'),url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.svg#Neo Sans W23') format('svg'),url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.woff') format('woff'),url('http://ijarah.sa/sites/default/files/fontyourface/local_fonts/Neosans-Regular/582122803-ba790ed5-7463-4fcc-96d1-4849d1d663a4.ttf') format('truetype');font-weight: normal;font-style: normal;}");
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_EmailcommonArabic";
                objCommonSP.LogError(methodName, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Method for sending Email
        /// </summary>
        /// <param name="objIjarhEmail"></param>
        public string SendEMail(IjarahEMail objIjarhEmail)
        {
            string result = "FAIL";
            try
            {              
                if (objIjarhEmail != null)
                {

                    try
                    {
                        clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                        if (objIjarhEmail.CustomMessage != null && objIjarhEmail.CustomMessage != string.Empty)
                        {
                            clsMessageTemplateInfo.MESSAGESUBJECTEN = objIjarhEmail.CustomSubjectHead;
                            clsMessageTemplateInfo.MESSAGEBODYEN = objIjarhEmail.CustomMessage.Replace("\n", Environment.NewLine);
                            clsMessageTemplateInfo.MESSAGECODE = string.Empty;
                        }
                        else
                        {
                            clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarhEmail.MessageCode, objIjarhEmail.MessageType);

                            if (objIjarhEmail.MessageCode == "0001")
                            {

                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0002")
                            {

                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0003")
                            {

                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0004")
                            {

                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0005")
                            {

                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0006")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0007")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800").Replace("Ijarah Collections Department", "Ijarah Finance"));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarhEmail.Amount.ToString()).Replace("8001111800", "920033800"));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "0008")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.ToString();
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.ToString();
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "CLE0101")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "CLE0202")
                            {
                                if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString()));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "CLE0303")
                            {
                                if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFSADAD#", objIjarhEmail.AccountNumber.ToString());
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "INVIJARAH")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = "Ijarah Invitation";
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailRamadan();
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = "Ijarah Invitation";
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailRamadanArabic();
                                }
                            }
                            //--adde by Zubair date 02-Apr-2017
                            else if (objIjarhEmail.MessageCode == "CESEMAIL01")
                            {
                                if (objIjarhEmail.MessageType == "U")
                                {
                                    //clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#LICN#", objIjarhEmail.LicensePlateNo.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#LICN#", objIjarhEmail.LicensePlateNo.ToString()).Replace("#ACTN#", objIjarhEmail.AccountNumber.ToString()).Replace("#AMT#", objIjarhEmail.Amount.ToString()).Replace("#DUD#", objIjarhEmail.DueDate.ToString());
                                }
                            }
                            //added by KISL: Satish.M on 27-July-2017 
                            else if (objIjarhEmail.MessageCode == "AMLE0101")
                            {
                                if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN;
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarhEmail.EmailReference.ToString()).Replace("#IDN#", objIjarhEmail.LicensePlateNo.ToString()).Replace("#OPN#", objIjarhEmail.AccountNumber.ToString());
                                }
                            }
                            //added by KISL: Satish.M on 19-Dec-2017
                            else if (objIjarhEmail.MessageCode == "EMAILIEE")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN;
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CARPLTNO#", objIjarhEmail.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarhEmail.AccountNumber.ToString()));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN;
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CARPLTNO#", objIjarhEmail.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarhEmail.AccountNumber.ToString()));
                                }
                            }

                            //added by KISL: Satish.M on 19-Dec-2017
                            else if (objIjarhEmail.MessageCode == "EMAILIEGTBE")
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN;
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CARPLTNO#", objIjarhEmail.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarhEmail.AccountNumber.ToString()));
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN;
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CARPLTNO#", objIjarhEmail.LicensePlateNo.ToString()).Replace("#ACCNO#", objIjarhEmail.AccountNumber.ToString()));
                                }
                            }
                            else if (objIjarhEmail.MessageCode == "OBITEST")
                            {
                                if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#OBITEST#", objIjarhEmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#OBITEST#", objIjarhEmail.AccountNumber.ToString());
                                }
                            }

                            else if (objIjarhEmail.MessageCode == "TAMMEMAIL") // added by Zubair 20-Mar-18
                            {
                                if (objIjarhEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.ToString());
                                }
                                else if (objIjarhEmail.MessageType == "U")
                                {
                                    //clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.ToString());
                                }
                            }

                            else if (objIjarhEmail.MessageCode == "TAMMCI") // added by Zubair 25-Mar-18
                            {
                                if (objIjarhEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN;
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#LPNO#", objIjarhEmail.LicensePlateNo.ToString());
                                }
                            }
                        }
                        clsLogEntryInfo sentLogInfo = new clsLogEntryInfo
                        {
                            MESSAGETYPE = objIjarhEmail.MessageType,
                            MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                            SUBJECT = clsMessageTemplateInfo.MESSAGESUBJECTEN,
                            MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                            SERVER = objIjarhEmail.PartnerCode,
                            REFERENCENO = objIjarhEmail.EmailReference,
                            RECIPIENTSTO = objIjarhEmail.RecipientsTo,
                            RECIPIENTSCC = objIjarhEmail.RecipientsCc,
                            MSGCODE = objIjarhEmail.MessageCode,
                            DATE = DateTime.Now,
                            STATUS = 1
                        };

                        string mail = "SENDEMAIL";

                        CommonSendEmail(sentLogInfo, mail, ref result);

                    }
                    catch (Exception ex6)
                    {
                        methodName = "IjarahMessagingGateway_SendEmail";
                        objCommonSP.LogError(methodName, ex6.Message);
                    }
                }
            }
            catch (Exception ex7)
            {
                methodName = "IjarahMessagingGateway_SendEmail";
                objCommonSP.LogError(methodName, ex7.Message);
            }
            return result;
        }

        /// <summary>
        /// Method for sending SREmail
        /// </summary>
        /// <param name="objIjarahSREmail"></param>
        public string SendSREmail(IjarahSREmail objIjarahSREmail)
        {
            string result = "FAIL";
            try
            {
                if (objIjarahSREmail != null)
                {

                    try
                    {
                        clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                        if (objIjarahSREmail.CustomMessage != null && objIjarahSREmail.CustomMessage != string.Empty)
                        {
                            clsMessageTemplateInfo.MESSAGESUBJECTEN = objIjarahSREmail.CustomSubjectHead;
                            clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahSREmail.CustomMessage.Replace("\n", Environment.NewLine);
                            clsMessageTemplateInfo.MESSAGECODE = string.Empty;
                        }
                        else
                        {
                            clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahSREmail.MessageCode, objIjarahSREmail.MessageType);

                            if (objIjarahSREmail.MessageCode == "0001")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFSADAD#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFSADAD#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0002")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFSADAD#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFSADAD#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0003")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFSADAD#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFSADAD#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0004")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0005")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0006")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0007")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0008")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCAT#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFACC#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString());
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCAT#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFACC#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0009")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFACC#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFACC#", objIjarahSREmail.SubCategory.ToString()).Replace("#REFSADAD#", objIjarahSREmail.SadadReferenceNumber.ToString()));
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFACC#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSREmail.Amount.ToString()).Replace("#REFACC#", objIjarahSREmail.SubCategory.ToString()).Replace("#REFSADAD#", objIjarahSREmail.SadadReferenceNumber.ToString()));
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "0010")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFSADAD#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFSADAD#", objIjarahSREmail.SubCategory.ToString()));
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFSADAD#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFSADAD#", objIjarahSREmail.SubCategory.ToString()));
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL04")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL05")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL06")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL07")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL08")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL09")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL10")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL11")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL12")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CREMAIL13")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            //Created by satish.M on 25-12-2016
                            else if (objIjarahSREmail.MessageCode == "CREMAIL14")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CRN#", objIjarahSREmail.Amount.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CUSNAME#", objIjarahSREmail.Category.ToString()).Replace("#CRDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#CRN#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CSSSEMAIL01" && objIjarahSREmail.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString());
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSREmail.Category.ToString()).Replace("#REFDATE#", objIjarahSREmail.DueDate.ToString()).Replace("#REFCRNO#", objIjarahSREmail.Amount.ToString()).Replace("إيجارة", "إيجارة للتمويل");
                            }

                            // Changes by Zubair For The New CR message codes 10-FEB-2017
                            else if ((objIjarahSREmail.MessageCode == "SRTRESE01") ||
                                   (objIjarahSREmail.MessageCode == "SRTRESE02") ||
                                   (objIjarahSREmail.MessageCode == "SRTRESE03"))
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CONT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#SRN#", objIjarahSREmail.Category.ToString()).Replace("#CRDT#", objIjarahSREmail.DueDate.ToString()).Replace("#CAT#", objIjarahSREmail.SubCategory.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "SRTRESE04")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CONT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#SRN#", objIjarahSREmail.Category.ToString()).Replace("#CAT#", objIjarahSREmail.SubCategory.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "SRTRESE05")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CONT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#SRN#", objIjarahSREmail.Category.ToString()).Replace("#CRDT#", objIjarahSREmail.DueDate.ToString()).Replace("#CAT#", objIjarahSREmail.SubCategory.ToString()).Replace("#CANRE#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CANBY#", objIjarahSREmail.Amount.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "SRTRESE06")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CONT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#SRN#", objIjarahSREmail.Category.ToString()).Replace("#CRDT#", objIjarahSREmail.DueDate.ToString()).Replace("#CAT#", objIjarahSREmail.SubCategory.ToString()).Replace("#USR#", objIjarahSREmail.Amount.ToString());
                                }
                                else if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CONT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#SRN#", objIjarahSREmail.Category.ToString()).Replace("#CAT#", objIjarahSREmail.SubCategory.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "SRTRESE07")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CONT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            //"Commented by Meera on 11-05-2017"
                            //Commented by meera on 11-05-2017 for deploying bulkmail - Start
                            else if (objIjarahSREmail.MessageCode == "CSESCLEMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CSESCLEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "CSESCLEMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "ASESCLEMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "ASESCLEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ASESCLEMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            //added by Zubair 17-APR-2017
                            else if (objIjarahSREmail.MessageCode == "SRPREMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#SRN#", objIjarahSREmail.EmailReference.ToString()).Replace("#AMT#", objIjarahSREmail.Amount.ToString()).Replace("#SDN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#NM#", objIjarahSREmail.CustomerName.ToString()).Replace("#CIBN#", objIjarahSREmail.CustomerIBAN.ToString()).Replace("#CBN#", objIjarahSREmail.CustomerBankName.ToString()).Replace("#VA#", objIjarahSREmail.VirtualAccount.ToString());
                                }
                            }//added by Zubair 16-May-17
                            else if (objIjarahSREmail.MessageCode == "SRPREMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN;
                                }
                            }
                            //added by Zubair 23-APR-2017
                            else if (objIjarahSREmail.MessageCode == "COEEMAIL1")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#SCAT#", objIjarahSREmail.SubCategory.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "COEEMAIL")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    //clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            // Addition of new message codes -- 08-05-2017 : Satish.M
                            else if (objIjarahSREmail.MessageCode == "CSLEMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "CSLEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "CSLEMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ASLEMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ASLEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ASLEMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            // Commented by meera on 11-05-2017 for deploying bulkmail - End */

                            //added by Zubair on 24-May-2017
                            else if (objIjarahSREmail.MessageCode == "COEASF")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.Category.ToString()).Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            else if (objIjarahSREmail.MessageCode == "COECOT")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CAT#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            //Added by KISL on 9th July 2017
                            else if (objIjarahSREmail.MessageCode == "ACICEMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ACICEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#ACD#", objIjarahSREmail.DueDate.ToString()); //CN : Contract Number
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ACICEMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.CustomerName.ToString()).Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()); //CN : Customer Name
                                }
                                else if (objIjarahSREmail.MessageType == "N")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.CustomerName.ToString()).Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()); //CN : Customer Name
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ACICEMAIL04")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ACICEMAIL05")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#ACD#", objIjarahSREmail.DueDate.ToString());
                                }
                            }


                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL01") //updated by KISL:Satish.M on 16-08-2017
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#REFNO#", objIjarahSREmail.EmailReference.ToString()).Replace("#COMT#", objIjarahSREmail.Category).Replace("#COMD#", objIjarahSREmail.DueDate);
                                }
                            }


                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }


                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL03")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#ACD#", objIjarahSREmail.DueDate.ToString()).Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }


                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL04")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#ACD#", objIjarahSREmail.DueDate.ToString()).Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            //Added by KISL : Satish on 
                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL05")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#AN#", objIjarahSREmail.SadadReferenceNumber.ToString());
                                }
                            }



                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL06")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#APIN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CDA#", objIjarahSREmail.Amount.ToString()).Replace("#VAIBAN#", objIjarahSREmail.VirtualAccount.ToString()).Replace("#CN#", objIjarahSREmail.CustomerName.ToString()).Replace("#CIBAN#", objIjarahSREmail.CustomerIBAN.ToString()).Replace("#CB#", objIjarahSREmail.CustomerBankName.ToString()).Replace("#VADA#", objIjarahSREmail.Category.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL07")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#APIN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#RCN#", objIjarahSREmail.CustomerName.ToString()).Replace("#RCIBAN#", objIjarahSREmail.CustomerIBAN.ToString()).Replace("#RCBN#", objIjarahSREmail.CustomerBankName.ToString()).Replace("#RDA#", objIjarahSREmail.Amount.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ACTPEMAIL08")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {

                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#APIN#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#APN#", objIjarahSREmail.CustomerName.ToString()).Replace("#APIBAN#", objIjarahSREmail.CustomerIBAN.ToString()).Replace("#APBN#", objIjarahSREmail.CustomerBankName.ToString()).Replace("#ADA#", objIjarahSREmail.Amount.ToString()).Replace("#VAIBAN#", objIjarahSREmail.VirtualAccount.ToString()).Replace("#VADA#", objIjarahSREmail.Category.ToString());
                                }
                            }
                            //created by zubair on 22-Aug-17
                            else if (objIjarahSREmail.MessageCode == "SRTRETE01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {

                                    //clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#AN#", objIjarahSREmail.EmailReference.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }
                            //created by satish on 18-Sep-17
                            else if (objIjarahSREmail.MessageCode == "SRTRETE02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#ER#", objIjarahSREmail.EmailReference.ToString());
                                }
                            }

                            //Created by Zubair on 10-Oct-17(06-Mar-18)
                            else if (objIjarahSREmail.MessageCode == "SRTLEMAIL01")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#CNM#", objIjarahSREmail.CustomerName.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "SRTLEMAIL02")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSREmail.OpportunityNumber.ToString());
                                }
                            }

                            else if (objIjarahSREmail.MessageCode == "ST0001")
                            {
                                if (objIjarahSREmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.ToString();
                                }
                            }

                            //Created by Satish.M on 1-Mar-18
                            //Updated By Syed Ubaid 1-May-18
                            else if (objIjarahSREmail.MessageCode == "ENTD0001")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    //clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#VCHNO#", objIjarahSREmail.SubCategory.ToString()).Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#IDN#", objIjarahSREmail.Category.ToString()).Replace("#PLTNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CRMOD#", objIjarahSREmail.Amount.ToString()).Replace("#CRMAKE#", objIjarahSREmail.CustomerName.ToString()).Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).
                                                                                                           Replace("#CUSNAME#", objIjarahSREmail.CustomerName.ToString()).
                                                                                                           Replace("#IDN#", objIjarahSREmail.CustomerIBAN.ToString()).
                                                                                                           Replace("#SadadRefNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).
                                                                                                           Replace("#Amnt#", objIjarahSREmail.Amount.ToString()).
                                                                                                           Replace("#CRMOD#", objIjarahSREmail.SubCategory.ToString()).
                                                                                                           Replace("#CRMAKE#", objIjarahSREmail.Category.ToString()).
                                                                                                           Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString()).
                                                                                                           Replace("#VA#", objIjarahSREmail.VirtualAccount.ToString());
                                }
                            }

                            //Created by Zubair on 04-Apr-18
                            //Updated By  07-May-18
                            else if (objIjarahSREmail.MessageCode == "ENTD0002")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    //clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#VCHNO#", objIjarahSREmail.SubCategory.ToString()).Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#IDN#", objIjarahSREmail.Category.ToString()).Replace("#PLTNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CRMOD#", objIjarahSREmail.Amount.ToString()).Replace("#CRMAKE#", objIjarahSREmail.CustomerName.ToString()).Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).
                                                                                                        Replace("#CUSNAME#", objIjarahSREmail.CustomerName.ToString()).
                                                                                                        Replace("#IDN#", objIjarahSREmail.CustomerIBAN.ToString()).
                                                                                                        Replace("#SadadRefNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).
                                                                                                        Replace("#Amnt#", objIjarahSREmail.Amount.ToString()).
                                                                                                        Replace("#CRMOD#", objIjarahSREmail.SubCategory.ToString()).
                                                                                                        Replace("#CRMAKE#", objIjarahSREmail.Category.ToString()).
                                                                                                        Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString()).
                                                                                                        Replace("#VA#", objIjarahSREmail.VirtualAccount.ToString());

                                }
                            }

                            //Created by Syed Ubaid on 07-May-18
                            else if (objIjarahSREmail.MessageCode == "ENTD0003")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    //clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#VCHNO#", objIjarahSREmail.SubCategory.ToString()).Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#IDN#", objIjarahSREmail.Category.ToString()).Replace("#PLTNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CRMOD#", objIjarahSREmail.Amount.ToString()).Replace("#CRMAKE#", objIjarahSREmail.CustomerName.ToString()).Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).
                                                                                                        Replace("#CUSNAME#", objIjarahSREmail.CustomerName.ToString()).
                                                                                                        Replace("#IDN#", objIjarahSREmail.CustomerIBAN.ToString()).
                                                                                                        Replace("#SadadRefNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).
                                                                                                        Replace("#Amnt#", objIjarahSREmail.Amount.ToString()).
                                                                                                        Replace("#CRMOD#", objIjarahSREmail.SubCategory.ToString()).
                                                                                                        Replace("#CRMAKE#", objIjarahSREmail.Category.ToString()).
                                                                                                        Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString()).
                                                                                                        Replace("#VA#", objIjarahSREmail.VirtualAccount.ToString());

                                }
                            }

                            //Created by Syed Ubaid on 07-May-18
                            else if (objIjarahSREmail.MessageCode == "ENTD0004")
                            {
                                if (objIjarahSREmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.ToString();
                                    //clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#VCHNO#", objIjarahSREmail.SubCategory.ToString()).Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).Replace("#IDN#", objIjarahSREmail.Category.ToString()).Replace("#PLTNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).Replace("#CRMOD#", objIjarahSREmail.Amount.ToString()).Replace("#CRMAKE#", objIjarahSREmail.CustomerName.ToString()).Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#OPPNO#", objIjarahSREmail.OpportunityNumber.ToString()).
                                                                                                        Replace("#CUSNAME#", objIjarahSREmail.CustomerName.ToString()).
                                                                                                        Replace("#IDN#", objIjarahSREmail.CustomerIBAN.ToString()).
                                                                                                        Replace("#SadadRefNO#", objIjarahSREmail.SadadReferenceNumber.ToString()).
                                                                                                        Replace("#Amnt#", objIjarahSREmail.Amount.ToString()).
                                                                                                        Replace("#CRMOD#", objIjarahSREmail.SubCategory.ToString()).
                                                                                                        Replace("#CRMAKE#", objIjarahSREmail.Category.ToString()).
                                                                                                        Replace("#AGENCY#", objIjarahSREmail.CustomerBankName.ToString()).
                                                                                                        Replace("#VA#", objIjarahSREmail.VirtualAccount.ToString());

                                }
                            }
                        }



                        clsLogEntryInfo sentLogInfo = new clsLogEntryInfo
                        {
                            MESSAGETYPE = objIjarahSREmail.MessageType,
                            MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                            SUBJECT = clsMessageTemplateInfo.MESSAGESUBJECTEN,
                            MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                            SERVER = objIjarahSREmail.PartnerCode,
                            REFERENCENO = objIjarahSREmail.EmailReference,
                            RECIPIENTSTO = objIjarahSREmail.RecipientsTo,
                            RECIPIENTSCC = objIjarahSREmail.RecipientsCc,
                            MSGCODE = objIjarahSREmail.MessageCode,
                            DATE = DateTime.Now,
                            STATUS = 1
                        };

                        string mail = "SENDSREMAIL";

                        CommonSendEmail(sentLogInfo, mail, ref result);

                    }
                    catch (Exception ex6)
                    {

                        methodName = "IjarahMessagingGateway_SendSREmail";
                        objCommonSP.LogError(methodName, ex6.Message);
                    }
                }
            }
            catch (Exception ex7)
            {
                methodName = "IjarahMessagingGateway_SendSREmail";
                objCommonSP.LogError(methodName, ex7.Message);
            }
            return result;
        }

        /// <summary>
        /// Method for sending Sale Email
        /// </summary>
        /// <param name="objIjarahSalesEmail"></param>
        public string SendSaleEmail(IjarahSalesEmail objIjarahSalesEmail)
        {
            string result = "FAIL";
            try
            {
                objCommonSP.LogError("", "Invoke Service " + DateTime.Now.ToLongTimeString());
                if (objIjarahSalesEmail != null)
                {

                    try
                    {
                        clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                        if (objIjarahSalesEmail.CustomMessage != null && objIjarahSalesEmail.CustomMessage != string.Empty)
                        {
                            clsMessageTemplateInfo.MESSAGESUBJECTEN = objIjarahSalesEmail.CustomSubjectHead;
                            clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahSalesEmail.CustomMessage.Replace("\n", Environment.NewLine);
                            clsMessageTemplateInfo.MESSAGECODE = string.Empty;
                        }
                        else
                        {
                            clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahSalesEmail.MessageCode, objIjarahSalesEmail.MessageType);
                            objCommonSP.LogError("", "After Getting tempate info " + DateTime.Now.ToLongTimeString());
                            if (objIjarahSalesEmail.MessageCode == "0001")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "0002")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "0003")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "0004")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "0005")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "0006")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "0007")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("8001111800", "920033800");
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENRV0101")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENAP0102")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesEmail.DownPayment.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFTAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFACC#", objIjarahSalesEmail.VirtualAccntNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFTAMT#", objIjarahSalesEmail.DownPayment.ToString()).Replace("#REFACC#", objIjarahSalesEmail.VirtualAccntNum.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENAP0203")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesEmail.DownPayment.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFDUAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFACC#", objIjarahSalesEmail.SADADRefNum.ToString()).Replace("Ijarah", "Ijarah Finance").Replace("#REFSABB#", objIjarahSalesEmail.VirtualAccntNum.ToString()));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFDAMT#", objIjarahSalesEmail.DownPayment.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.AdminFee.ToString()).Replace("#REFDUAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFACC#", objIjarahSalesEmail.SADADRefNum.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل").Replace("#REFSABB#", objIjarahSalesEmail.VirtualAccntNum.ToString()));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENDP0104")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENGC0105")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENDS0106")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENPI0107")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENCR0108")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENPD0109")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENAR0110")
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFCAR#", objIjarahSalesEmail.Carbrand.ToString()).Replace("#REFCARPLATE#", objIjarahSalesEmail.Numberplate.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.SADADRefNum.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.VirtualAccntNum.ToString()));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFCAR#", objIjarahSalesEmail.Carbrand.ToString()).Replace("#REFCARPLATE#", objIjarahSalesEmail.Numberplate.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.SADADRefNum.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.VirtualAccntNum.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENAR0211" && objIjarahSalesEmail.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#REFACC#", objIjarahSalesEmail.VirtualAccntNum.ToString());
                                clsMessageTemplateInfo.MESSAGEBODYEN = clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFACC#", objIjarahSalesEmail.VirtualAccntNum.ToString());
                            }
                            else if (objIjarahSalesEmail.MessageCode == "ENPA0111") // Added by KISL on 14th Nov 2016
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#REFNAME#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFSADAD#", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("Ijarah", "Ijarah Finance"));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("123", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFAMT#", objIjarahSalesEmail.Totalamount.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("456", objIjarahSalesEmail.ApplicationNum.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }

                            else if (objIjarahSalesEmail.MessageCode == "ENCC0111") // added by Zubair 25-May-17
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#FN#", objIjarahSalesEmail.Firstname.ToString()));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTAR.Replace("#CN#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }

                            else if (objIjarahSalesEmail.MessageCode == "ENCC01111") // added by Zubair 25-May-17
                            {
                                if (objIjarahSalesEmail.MessageType == "N")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#FN#", objIjarahSalesEmail.Firstname.ToString()));
                                }
                                else if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#CN#", objIjarahSalesEmail.Firstname.ToString()).Replace("#REFGENDER#", objIjarahSalesEmail.Gender.ToString()).Replace("إيجارة", "إيجارة للتمويل"));
                                }
                            }
                            else if (objIjarahSalesEmail.MessageCode == "SCEMAIL01") // added by Satish.M on 25-Dec-17
                            {
                                if (objIjarahSalesEmail.MessageType == "U")
                                {
                                    clsMessageTemplateInfo.MESSAGESUBJECTEN = clsMessageTemplateInfo.MESSAGESUBJECTEN.Replace("#OPNAME#", objIjarahSalesEmail.VirtualAccntNum.ToString());
                                    clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Replace("#OPSCN#", objIjarahSalesEmail.DownPayment.ToString()).Replace("#OPNAME#", objIjarahSalesEmail.VirtualAccntNum.ToString()).Replace("#ASCN#", objIjarahSalesEmail.Firstname.ToString()));
                                }
                            }

                        }
                        objCommonSP.LogError("", "Before create log entry " + DateTime.Now.ToLongTimeString());
                        clsLogEntryInfo sentLogInfo = new clsLogEntryInfo
                        {
                            MESSAGETYPE = objIjarahSalesEmail.MessageType,
                            MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                            SUBJECT = clsMessageTemplateInfo.MESSAGESUBJECTEN,
                            MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                            SERVER = objIjarahSalesEmail.PartnerCode,
                            REFERENCENO = objIjarahSalesEmail.EmailReference,
                            RECIPIENTSTO = objIjarahSalesEmail.RecipientsTo,
                            RECIPIENTSCC = objIjarahSalesEmail.RecipientsCc,
                            DATE = DateTime.Now,
                            STATUS = 1
                        };

                        string smsType = "SENDSALEEMAIL";
                        objCommonSP.LogError("", "Before common send email " + DateTime.Now.ToLongTimeString());
                        CommonSendEmail(sentLogInfo, smsType, ref result);
                        objCommonSP.LogError("", "After common send email " + DateTime.Now.ToLongTimeString());

                    }
                    catch (Exception ex6)
                    {
                        methodName = "IjarahMessagingGateway_SendSaleEmail";
                        objCommonSP.LogError(methodName, ex6.Message);
                    }
                }
            }
            catch (Exception ex7)
            {
                methodName = "IjarahMessagingGateway_SendSaleEmail";
                objCommonSP.LogError(methodName, ex7.Message);
            }

            return result;
        }

        /// <summary>
        /// Method for sending Bulk Emails at a time
        /// </summary>
        /// <param name="objIjarahBulkEmail"></param>
        /// <returns></returns>
        public string SendBulkEmail(IjarahBulkEmail objIjarahBulkEmail)
        {
            string result = "FAIL";
            try
            {
                if (objIjarahBulkEmail != null)
                {
                    try
                    {
                        clsMessageTemplateInfo clsMessageTemplateInfo = new clsMessageTemplateInfo();
                        if (objIjarahBulkEmail.CustomMessage != null && objIjarahBulkEmail.CustomMessage != string.Empty)
                        {
                            clsMessageTemplateInfo.MESSAGESUBJECTEN = objIjarahBulkEmail.CustomSubjectHead;
                            clsMessageTemplateInfo.MESSAGEBODYEN = objIjarahBulkEmail.CustomMessage.Replace("\n", Environment.NewLine);
                            clsMessageTemplateInfo.MESSAGECODE = string.Empty;
                        }
                        else
                        {
                            clsMessageTemplateInfo = new clsCommonSP().MessageTemplateFilterByCodeNType(objIjarahBulkEmail.MessageCode, objIjarahBulkEmail.MessageType);


                            if (objIjarahBulkEmail.MessageType == "N")
                            {
                                clsMessageTemplateInfo.MESSAGESUBJECTEN = objIjarahBulkEmail.SubjectN;
                                clsMessageTemplateInfo.MESSAGEBODYEN = this.Emailcover(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Trim());
                            }
                            else if (objIjarahBulkEmail.MessageType == "U")
                            {
                                clsMessageTemplateInfo.MESSAGESUBJECTEN = objIjarahBulkEmail.SubjectU;
                                clsMessageTemplateInfo.MESSAGEBODYEN = this.EmailcoverArabic(clsMessageTemplateInfo.MESSAGEDESCRIPTEN.Trim());
                            }

                        }

                        clsLogEntryInfo sentLogInfo = new clsLogEntryInfo
                        {
                            MESSAGETYPE = objIjarahBulkEmail.MessageType,
                            MESSAGE = clsMessageTemplateInfo.MESSAGEBODYEN,
                            SUBJECT = clsMessageTemplateInfo.MESSAGESUBJECTEN,
                            MESSAGECODE = clsMessageTemplateInfo.MESSAGECODE,
                            SERVER = "IJARAH",
                            RECIPIENTSTO = objIjarahBulkEmail.RecipientsTo,
                            RECIPIENTSCC = objIjarahBulkEmail.RecipientsCc,
                            MSGCODE = objIjarahBulkEmail.MessageCode,
                            DATE = DateTime.Now,
                            STATUS = 1
                        };

                        string mail = "SENDBULKEMAIL";

                        CommonSendEmail(sentLogInfo, mail, ref result);
                    }
                    catch (Exception ex1)
                    {

                        methodName = "IjarahMessagingGateway_SendBulkEmail";
                        objCommonSP.LogError(methodName, ex1.Message);
                    }
                }
            }


            catch (Exception ex2)
            {

                methodName = "IjarahMessagingGateway_SendBulkEmail";
                objCommonSP.LogError(methodName, ex2.Message);
            }

            return result;
        }

        /// <summary>
        /// To send all the sms for common function
        /// </summary>
        /// <param name="sentLogInfo"></param>
        /// <param name="result"></param>
        private void CommonSendSMS(clsSMSLogInfo sentLogInfo, ref string result, string OTP = "")
        {
            try
            {
                decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);
                string requestUriString = string.Empty;
                string strMessageBody;
                string strMessageBodyNew;

                string smsUrl = ConfigurationManager.AppSettings["SMSURL"];


                strMessageBody = sentLogInfo.MESSAGETYPE == "N" ? sentLogInfo.MESSAGE : this.ConvertTextTohex(sentLogInfo.MESSAGE);

                strMessageBodyNew = sentLogInfo.MESSAGE;


                //  done changes by KISL Satish on 10-Jul-17
                if (OTP == string.Empty)
                {
                    requestUriString = string.Concat(new string[]
                          {
                                   /*smsUrl,
                                   sentLogInfo.RECIPIENTS.Trim(),
                                   "&from=IJARAH&message=",
                                   strMessageBody.Trim(),
                                   "&lang=8&action=send"*/
                                   /*smsUrl,
                                   sentLogInfo.RECIPIENTS.Trim(),
                                   "&Text=",
                                   strMessageBody.Trim(),
                                   "&lang=1&sender=IJARAH"*/
                                   

                                   smsUrl, //changed by KISL on 10-07-2017 for new sms url
                                   sentLogInfo.RECIPIENTS.Trim(),
                                   "&sender=ijarah",
                                   "&msg=",
                                   strMessageBodyNew.Trim()
                          });
                }
                else
                {
                    smsUrl = ConfigurationManager.AppSettings["SMSSTC"];
                    if (sentLogInfo.MESSAGETYPE == "N")
                    {
                        requestUriString = string.Concat(new string[]
                    {
                        smsUrl,
                        sentLogInfo.RECIPIENTS.Trim(),
                        "&message=",
                        strMessageBody.Trim(),
                        "&sender=IJARAH"
                    });
                    }
                    else
                    {
                        requestUriString = string.Concat(new string[]
                    {
                        smsUrl,
                        sentLogInfo.RECIPIENTS.Trim(),
                        "&message=",
                        strMessageBody.Trim(),
                        "&sender=IJARAH&unicode=u"
                    });
                    }
                }
                
                CookieContainer cookieContainer = new CookieContainer();
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Proxy = null;
                httpWebRequest.UseDefaultCredentials = true;
                httpWebRequest.KeepAlive = false;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                httpWebRequest.CookieContainer = cookieContainer;
                WebResponse response = httpWebRequest.GetResponse();
                string arg_B31_0 = ((HttpWebResponse)response).StatusDescription;
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string strSendStatus = streamReader.ReadToEnd();
                
                string dELIVERYSTAUSCODE = "";
                if (OTP.Trim() == string.Empty)
                {
                    if (strSendStatus.Contains("Status : 200"))
                    {
                        dELIVERYSTAUSCODE = "200";
                        result = "SUCCESS";
                    }
                    if (strSendStatus.Contains("Sent"))
                    {
                        dELIVERYSTAUSCODE = "200";
                        result = "SUCCESS";
                    }
                    else if (strSendStatus.Contains("Status : 201"))
                    {
                        dELIVERYSTAUSCODE = "201";
                    }
                    else if (strSendStatus.Contains("Status : 202"))
                    {
                        dELIVERYSTAUSCODE = "202";
                    }
                    else if (strSendStatus.Contains("Status : 207"))
                    {
                        dELIVERYSTAUSCODE = "207";
                    }
                    else if (strSendStatus.Contains("Status : -998"))
                    {
                        dELIVERYSTAUSCODE = "-998";
                    }
                    else if (strSendStatus.Contains("Status : -999"))
                    {
                        dELIVERYSTAUSCODE = "-999";
                    }
                    else if (strSendStatus.Contains("Status : 224"))
                    {
                        dELIVERYSTAUSCODE = "224";
                    }
                    else if (strSendStatus.Contains("Invalid"))
                    {
                        dELIVERYSTAUSCODE = "403";
                    }
                    else if (strSendStatus.Contains("invalid"))
                    {
                        dELIVERYSTAUSCODE = "403";
                    }
                }
                else
                {
                    if (strSendStatus.Contains("-100"))
                    {
                        dELIVERYSTAUSCODE = "-100";
                    }
                    else if (strSendStatus.Contains("-110"))
                    {
                        dELIVERYSTAUSCODE = "-110";
                    }
                    else if (strSendStatus.Contains("-111"))
                    {
                        dELIVERYSTAUSCODE = "-111";
                    }
                    else if (strSendStatus.Contains("-112"))
                    {
                        dELIVERYSTAUSCODE = "-112";
                    }
                    else if (strSendStatus.Contains("-113"))
                    {
                        dELIVERYSTAUSCODE = "-113";
                    }
                    else if (strSendStatus.Contains("-114"))
                    {
                        dELIVERYSTAUSCODE = "-114";
                    }
                    else if (strSendStatus.Contains("-115"))
                    {
                        dELIVERYSTAUSCODE = "-115";
                    }
                    else if (strSendStatus.Contains("-116"))
                    {
                        dELIVERYSTAUSCODE = "-116";
                    }
                    else if (strSendStatus.Contains("-120"))
                    {
                        dELIVERYSTAUSCODE = "-120";
                    }
                    else
                    {
                        dELIVERYSTAUSCODE = "200";
                        result = "SUCCESS";
                    }
                }

                clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                {
                    SMSLOGID = sMSLOGID,
                    ERRORLOGID = 0,
                    MOBILENOS = sentLogInfo.RECIPIENTS,
                    DELIVERYSTAUSCODE = dELIVERYSTAUSCODE,
                    DATE = DateTime.Now,
                    CONTRACTNO = sentLogInfo.CONTRACTNO                        //Added by KISL on 31/01/2018
                };
                new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);
            }
            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_CommonSendSMS";
                objCommonSP.LogError(methodName, ex.Message);


                decimal sMSLOGID = new clsCommonSP().SMSLogAdd(sentLogInfo);                //Added by Satish.M on 01/03/2018

                clsSMSLogDetailsInfo sentLogInfo2 = new clsSMSLogDetailsInfo
                {
                    SMSLOGID = sMSLOGID,
                    ERRORLOGID = 0,
                    MOBILENOS = sentLogInfo.RECIPIENTS,
                    DELIVERYSTAUSCODE = "422",
                    DATE = DateTime.Now,
                    CONTRACTNO = sentLogInfo.CONTRACTNO                        
                };
                new clsCommonSP().SMSLOGDetailsAdd(sentLogInfo2);


            }
        }

        /// <summary>
        /// Method to send common Email
        /// </summary>
        /// <param name="sentLogInfo"></param>
        /// <param name="smsType"></param>
        private string CommonSendEmail(clsLogEntryInfo sentLogInfo, string mail, ref string result)
        {
            try
            {
                string text = "";
                decimal lOGENTRYID = 0m;
                string username = ConfigurationManager.AppSettings["USERNAME"];
                string password = ConfigurationManager.AppSettings["PASSWORD"];
                string domain = ConfigurationManager.AppSettings["DOMAIN"];
                string autoDiscoverUrl = ConfigurationManager.AppSettings["AUTODISCOVERURL"];

                //objCommonSP.LogError("", "Before insert log entry " + DateTime.Now.ToLongTimeString());
                lOGENTRYID = new clsCommonSP().LogEntryAdd(sentLogInfo);
                //objCommonSP.LogError("", "After insert log entry " + DateTime.Now.ToLongTimeString());
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ijaraMessagingGateway.CertificateValidationCallBack);
                ExchangeService exchangeService = new ExchangeService(ExchangeVersion.Exchange2010);
                //exchangeService.Credentials = new WebCredentials("notification", "Ijr_Noti@9965", "ijarah");
                exchangeService.Credentials = new WebCredentials(username, password, domain);
                exchangeService.TraceEnabled = true;
                exchangeService.TraceFlags = TraceFlags.All;
                exchangeService.EnableScpLookup = true;
                //objCommonSP.LogError("", "before AutodiscoverUrl " + DateTime.Now.ToLongTimeString());
                //exchangeService.AutodiscoverUrl("notification@ijarah.sa", new AutodiscoverRedirectionUrlValidationCallback(ijaraMessagingGateway.RedirectionUrlValidationCallback));
                exchangeService.AutodiscoverUrl(autoDiscoverUrl, new AutodiscoverRedirectionUrlValidationCallback(ijaraMessagingGateway.RedirectionUrlValidationCallback));

                //objCommonSP.LogError("", "After AutodiscoverUrl " + DateTime.Now.ToLongTimeString());
                exchangeService.Timeout = 20000;
                exchangeService.UseDefaultCredentials = false;
                EmailMessage emailMessage = new EmailMessage(exchangeService);

                if (mail == "SENDSREMAIL")
                {
                    //if (sentLogInfo.MSGCODE == "CREMAIL05" || sentLogInfo.MSGCODE == "CREMAIL06" || sentLogInfo.MSGCODE == "CREMAIL08" || sentLogInfo.MSGCODE == "CREMAIL09" || sentLogInfo.MSGCODE == "CREMAIL11" || sentLogInfo.MSGCODE == "CREMAIL02" || sentLogInfo.MSGCODE == "CREMAIL03" || sentLogInfo.MSGCODE == "CREMAIL12" || sentLogInfo.MSGCODE == "CSSSEMAIL01" || sentLogInfo.MSGCODE == "CSESCLEMAIL01" || sentLogInfo.MSGCODE == "CSESCLEMAIL02" || sentLogInfo.MSGCODE == "CSESCLEMAIL03" || sentLogInfo.MSGCODE == "ASESCLEMAIL01" || sentLogInfo.MSGCODE == "ASESCLEMAIL02" || sentLogInfo.MSGCODE == "ASESCLEMAIL03" || sentLogInfo.MSGCODE == "CSLEMAIL01" || sentLogInfo.MSGCODE == "CSLEMAIL02" || sentLogInfo.MSGCODE == "CSLEMAIL03" || sentLogInfo.MSGCODE == "ASLEMAIL01" || sentLogInfo.MSGCODE == "ASLEMAIL02" || sentLogInfo.MSGCODE == "ASLEMAIL03" || sentLogInfo.MSGCODE == "AMLE0101")
                    if (sentLogInfo.MSGCODE == "AMLE0101")
                        {
                        emailMessage.BccRecipients.Add("Adel.Abdullah@ijarah.sa");
                    }
                }
                else if (mail == "SENDEMAIL")
                {
                    if (sentLogInfo.MSGCODE == "AMLE0101")
                    {
                        emailMessage.BccRecipients.Add("Adel.Abdullah@ijarah.sa");
                    }
                }

                string[] array = sentLogInfo.RECIPIENTSTO.Split(new char[]
                    {
                        ','
                    });
                int num = 0;
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string text2 = array2[i];
                    ijaraMessagingGateway.mailSendSemaphore.WaitOne();
                    try
                    {
                        emailMessage.ToRecipients.Add(new EmailAddress(text2));
                        if (sentLogInfo.RECIPIENTSCC != null && sentLogInfo.RECIPIENTSCC != string.Empty)
                        {
                            string[] array3 = sentLogInfo.RECIPIENTSCC.Split(new char[]
                                {
                                    ','
                                });
                            string[] array4 = array3;
                            for (int j = 0; j < array4.Length; j++)
                            {
                                string smtpAddress = array4[j];
                                emailMessage.CcRecipients.Add(new EmailAddress(smtpAddress));
                            }
                        }

                        if (mail == "SENDSREMAIL")
                        {
                            emailMessage.Subject = sentLogInfo.SUBJECT;
                            emailMessage.Importance = Importance.High;
                        }
                        else
                        {
                            if (sentLogInfo.SUBJECT.ToString() != null)
                            {
                                emailMessage.Subject = sentLogInfo.SUBJECT;
                            }
                            else if (sentLogInfo.SUBJECT.ToString() == null)
                            {
                                emailMessage.Subject = "Ijarah Notifications";
                            }
                        }

                        if (mail == "SENDSALEEMAIL")
                        {
                            if (sentLogInfo.MESSAGECODE == "ENAR0211")
                            {
                                emailMessage.Importance = Importance.High;
                            }
                        }

                        emailMessage.Body = sentLogInfo.MESSAGE;
                        //Added by satish
                        //emailMessage.Deli
                        emailMessage.Save();
                        objCommonSP.LogError("", "Before  SendAndSaveCopy " + DateTime.Now.ToLongTimeString());
                        emailMessage.SendAndSaveCopy();
                        objCommonSP.LogError("", "After  SendAndSaveCopy " + DateTime.Now.ToLongTimeString());
                        num++;
                        result = "SUCCESS";
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        text = string.Format("Exception: Server Respond: {0}", ex.Message);
                        result = "FAIL";
                    }
                    catch (SmtpException ex2)
                    {
                        text = ex2.Message;
                        result = "FAIL";
                    }
                    catch (SocketException ex3)
                    {
                        text = string.Format("Exception: Networking Error: {0} {1}", ex3.ErrorCode, ex3.Message);
                        result = "FAIL";
                    }
                    catch (Win32Exception ex4)
                    {
                        text = string.Format("Exception: System Error: {0} {1}", ex4.ErrorCode, ex4.Message);
                        result = "FAIL";
                    }
                    catch (Exception ex5)
                    {
                        text = string.Format("Exception: Common: {0}", ex5.Message);
                        result = "FAIL";
                    }
                    finally
                    {
                        int dELIVERYSTAUS = 1;
                        int eRRORLOGID = 0;
                        if (text.Length > 0)
                        {
                            objCommonSP.LogError("", "Before  GetErrorIdByDescription " + DateTime.Now.ToLongTimeString());
                            eRRORLOGID = new clsCommonSP().GetErrorIdByDescription(text);
                            objCommonSP.LogError("", "After  GetErrorIdByDescription " + DateTime.Now.ToLongTimeString());
                            text = "";
                            dELIVERYSTAUS = 0;
                        }
                        ijaraMessagingGateway.mailSendSemaphore.Release();
                        clsLogEntryDetailsInfo sentLogInfo2 = new clsLogEntryDetailsInfo
                        {
                            LOGENTRYID = lOGENTRYID,
                            ERRORLOGID = eRRORLOGID,
                            EMAIL = text2,
                            DELIVERYSTAUS = dELIVERYSTAUS,
                            DATE = DateTime.Now
                        };
                        objCommonSP.LogError("", "Before  LogEntryDetailsAdd " + DateTime.Now.ToLongTimeString());
                        new clsCommonSP().LogEntryDetailsAdd(sentLogInfo2);
                        objCommonSP.LogError("", "After  LogEntryDetailsAdd " + DateTime.Now.ToLongTimeString());
                    }
                }
            }

            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_CommonSendEmail";
                objCommonSP.LogError(methodName, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// To format the email content fore all the kind of emails
        /// </summary>
        /// <param name="str"></param>
        /// <param name="MessageType"></param>
        /// <returns></returns>
        private string FormatEmail(string str, string MessageType)
        {
            string imgHeader = ConfigurationManager.AppSettings["IMGHEADER"];
            string imgPageHead = ConfigurationManager.AppSettings["IMGPAGEHEAD"];
            string imgFooter = ConfigurationManager.AppSettings["IMGFOOTER"];
            string imgSocial = ConfigurationManager.AppSettings["IMGSOCIAL"];

            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append(Environment.NewLine + "<html xmlns='http://www.w3.org/1999/xhtml'>");
                stringBuilder.Append(Environment.NewLine + "<head>");
                stringBuilder.Append(Environment.NewLine + "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />");
                stringBuilder.Append(Environment.NewLine + "<meta name='viewport' content='width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1'>");
                stringBuilder.Append(Environment.NewLine + " <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport'>");
                stringBuilder.Append(Environment.NewLine + " <meta name='viewport' content='initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no,width=device-width'>");
                stringBuilder.Append(Environment.NewLine + " <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' />");
                stringBuilder.Append(Environment.NewLine + "<title>Ijarah Finance</title>");
                stringBuilder.Append(Environment.NewLine + "<style type='text/css'>");
                stringBuilder.Append(Environment.NewLine + "@font-face {");
                stringBuilder.Append(Environment.NewLine + "font-family: Helvetica,‘Trebuchet MS’,sans-serif");
                stringBuilder.Append(Environment.NewLine + "font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "font-style: normal;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "#outlook a {");
                stringBuilder.Append(Environment.NewLine + "\tpadding: 0;");
                stringBuilder.Append(Environment.NewLine + "} /* Force Outlook to provide a 'view in browser' message */");
                stringBuilder.Append(Environment.NewLine + ".ReadMsgBody {");
                stringBuilder.Append(Environment.NewLine + "\twidth: 100%;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".ExternalClass {");
                stringBuilder.Append(Environment.NewLine + "\twidth: 100%;");
                stringBuilder.Append(Environment.NewLine + "} /* Force Hotmail to display emails at full width */");
                stringBuilder.Append(Environment.NewLine + ".ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {");
                stringBuilder.Append(Environment.NewLine + "\tline-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "} /* Force Hotmail to display normal line spacing */");
                stringBuilder.Append(Environment.NewLine + "body, table, td, p, a, li, blockquote {");
                stringBuilder.Append(Environment.NewLine + "\t-webkit-text-size-adjust: 100%;");
                stringBuilder.Append(Environment.NewLine + "\t-ms-text-size-adjust: 100%;");
                stringBuilder.Append(Environment.NewLine + "} /* Prevent WebKit and Windows mobile changing default text sizes */");
                stringBuilder.Append(Environment.NewLine + "table, td {");
                stringBuilder.Append(Environment.NewLine + "\tmso-table-lspace: 0pt;");
                stringBuilder.Append(Environment.NewLine + "\tmso-table-rspace: 0pt;");
                stringBuilder.Append(Environment.NewLine + "} /* Remove spacing between tables in Outlook 2007 and up */");
                stringBuilder.Append(Environment.NewLine + "img {");
                stringBuilder.Append(Environment.NewLine + "\t-ms-interpolation-mode: bicubic;");
                stringBuilder.Append(Environment.NewLine + "} /* Allow smoother rendering of resized image in Internet Explorer */");
                stringBuilder.Append(Environment.NewLine + "body {");
                stringBuilder.Append(Environment.NewLine + "\tmargin: 0;");
                stringBuilder.Append(Environment.NewLine + "\tpadding: 0;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "img {");
                stringBuilder.Append(Environment.NewLine + "\tborder: 0;");
                stringBuilder.Append(Environment.NewLine + "\theight: auto;");
                stringBuilder.Append(Environment.NewLine + "\tline-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "\toutline: none;");
                stringBuilder.Append(Environment.NewLine + "\ttext-decoration: none;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "table {");
                stringBuilder.Append(Environment.NewLine + "\tborder-collapse: collapse !important;");
                stringBuilder.Append(Environment.NewLine + "\tborder:none !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "body, #bodyTable, #bodyCell {");
                stringBuilder.Append(Environment.NewLine + "\theight: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "\tmargin: 0;");
                stringBuilder.Append(Environment.NewLine + "\tpadding: 0;");
                stringBuilder.Append(Environment.NewLine + "\twidth: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t/* ========== Page Styles ========== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "#bodyCell {");
                stringBuilder.Append(Environment.NewLine + "\tpadding: 20px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "#templateContainer {");
                stringBuilder.Append(Environment.NewLine + "\twidth: 600px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section background style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and top border for your email. You may want to choose colors that match your company's branding.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "body, #bodyTable {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ background-color: #fff");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section background style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and top border for your email. You may want to choose colors that match your company's branding.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#bodyCell {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-top: 1px solid #fff;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section email border");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the border for your email.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templateContainer {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border: 1px solid #fff;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section heading 1");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for all first-level headings in your emails. These should be the largest of your headings.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @style heading 1");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h1 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #202020 !important;");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: block;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 26px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-style: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: bold;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ letter-spacing: normal;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-right: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-bottom: 10px;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-left: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section heading 2");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for all second-level headings in your emails.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @style heading 2");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h2 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #404040 !important;");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: block;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 20px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-style: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: bold;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ letter-spacing: normal;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-right: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-bottom: 10px;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-left: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section heading 3");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for all third-level headings in your emails.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @style heading 3");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h3 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #606060 !important;");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: block;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 16px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-style: italic;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ letter-spacing: normal;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-right: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-bottom: 10px;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-left: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Page");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section heading 4");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for all fourth-level headings in your emails. These should be the smallest of your headings.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @style heading 4");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h4 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #808080 !important;");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: block;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 14px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-style: italic;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ letter-spacing: normal;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-right: 0;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-bottom: 10px;");
                stringBuilder.Append(Environment.NewLine + "\tmargin-left: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ========== Header Styles ========== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section preheader style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and bottom border for your email's preheader area.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templatePreheader {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ background-color: #F4F4F4;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-bottom: 1px solid #CCCCCC;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section preheader text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's preheader text. Choose a size and color that is easy to read.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".preheaderContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #808080;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 10px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 125%;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section preheader link");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's preheader links. Choose a color that helps them stand out from your text.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".preheaderContent a:link, .preheaderContent a:visited, /* Yahoo! Mail Override */ .preheaderContent a .yshortcuts /* Yahoo! Mail Override */ {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #606060;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-decoration: underline;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section header style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and borders for your email's header area.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templateHeader {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ background-color: #F4F4F4;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-top: 1px solid #FFFFFF;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-bottom: 1px solid #CCCCCC;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section header text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's header text. Choose a size and color that is easy to read.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".headerContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #505050;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 20px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: bold;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100%;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ padding-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ padding-right: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ padding-bottom: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ padding-left: 0;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ vertical-align: middle;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Header");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section header link");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's header links. Choose a color that helps them stand out from your text.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".headerContent a:link, .headerContent a:visited, /* Yahoo! Mail Override */ .headerContent a .yshortcuts /* Yahoo! Mail Override */ {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #EB4102;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-decoration: underline;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "#headerImage {");
                stringBuilder.Append(Environment.NewLine + "\theight: auto;");
                stringBuilder.Append(Environment.NewLine + "\tmax-width: 600px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ========== Body Styles ========== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Body");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section body style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and borders for your email's body area.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templateBody {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ background-color: #F4F4F4;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-top: 1px solid #FFFFFF;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-bottom: 1px solid #CCCCCC;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Body");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section body text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's main content text. Choose a size and color that is easy to read.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme main");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".bodyContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #505050;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 16px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 150%;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-top: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-right: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-bottom: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-left: 20px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Body");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section body link");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's main content links. Choose a color that helps them stand out from your text.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".bodyContent a:link, .bodyContent a:visited, /* Yahoo! Mail Override */ .bodyContent a .yshortcuts /* Yahoo! Mail Override */ {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #EB4102;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-decoration: underline;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".bodyContent img {");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: inline;");
                stringBuilder.Append(Environment.NewLine + "\theight: auto;");
                stringBuilder.Append(Environment.NewLine + "\tmax-width: 560px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ========== Column Styles ========== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + ".templateColumnContainer {");
                stringBuilder.Append(Environment.NewLine + "\twidth: 5px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Columns");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section column style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and borders for your email's column area.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templateColumns {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ background-color: #F4F4F4;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-top: 1px solid #FFFFFF;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-bottom: 1px solid #CCCCCC;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Columns");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section left column text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's left column content text. Choose a size and color that is easy to read.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".leftColumnContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #505050;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 14px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 150%;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-right: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-bottom: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-left: 20px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Columns");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section left column link");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's left column content links. Choose a color that helps them stand out from your text.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".leftColumnContent a:link, .leftColumnContent a:visited, /* Yahoo! Mail Override */ .leftColumnContent a .yshortcuts /* Yahoo! Mail Override */ {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #EB4102;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-decoration: underline;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Columns");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section right column text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's right column content text. Choose a size and color that is easy to read.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".rightColumnContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #505050;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 14px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 150%;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-top: 0;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-right: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-bottom: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-left: 20px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Columns");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section right column link");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's right column content links. Choose a color that helps them stand out from your text.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".rightColumnContent a:link, .rightColumnContent a:visited, /* Yahoo! Mail Override */ .rightColumnContent a .yshortcuts /* Yahoo! Mail Override */ {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #EB4102;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-decoration: underline;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".leftColumnContent img, .rightColumnContent img {");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: inline;");
                stringBuilder.Append(Environment.NewLine + "\theight: auto;");
                stringBuilder.Append(Environment.NewLine + "\tmax-width: 260px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ========== Footer Styles ========== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Footer");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section footer style");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the background color and borders for your email's footer area.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme footer");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templateFooter {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ background-color: #F4F4F4;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ border-top: 1px solid #FFFFFF;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Footer");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section footer text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's footer text. Choose a size and color that is easy to read.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @theme footer");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".footerContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #808080;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-family: Helvetica;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 10px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 150%;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-top: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-right: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-bottom: 20px;");
                stringBuilder.Append(Environment.NewLine + "\tpadding-left: 20px;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-align: left;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tab Footer");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @section footer link");
                stringBuilder.Append(Environment.NewLine + "\t\t\t* @tip Set the styling for your email's footer links. Choose a color that helps them stand out from your text.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".footerContent a:link, .footerContent a:visited, /* Yahoo! Mail Override */ .footerContent a .yshortcuts, .footerContent a span /* Yahoo! Mail Override */ {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ color: #606060;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-weight: normal;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ text-decoration: underline;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (min-width : 1200px) {");
                stringBuilder.Append(Environment.NewLine + "                .colr {");
                stringBuilder.Append(Environment.NewLine + "                background-color: #F96 !important;");
                stringBuilder.Append(Environment.NewLine + "                width: 17px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "                background-color: #000 !important;");
                stringBuilder.Append(Environment.NewLine + "                width: 18px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "                }");
                stringBuilder.Append(Environment.NewLine + "                ");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (min-width : 992px) {");
                stringBuilder.Append(Environment.NewLine + "                .colr {");
                stringBuilder.Append(Environment.NewLine + "                background-color: #F0F !important;");
                stringBuilder.Append(Environment.NewLine + "                width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "                background-color: #F0F !important;");
                stringBuilder.Append(Environment.NewLine + "                width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "                }");
                stringBuilder.Append(Environment.NewLine + "                ");
                stringBuilder.Append(Environment.NewLine + "    @media only screen and (min-width : 768px) {");
                stringBuilder.Append(Environment.NewLine + "                .colr {");
                stringBuilder.Append(Environment.NewLine + "                background-color: #F0F !important;");
                stringBuilder.Append(Environment.NewLine + "                width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "                background-color: #F0F !important;");
                stringBuilder.Append(Environment.NewLine + "                width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "                }");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 480px) {");
                stringBuilder.Append(Environment.NewLine + "body, table, td, p, a, li, blockquote {");
                stringBuilder.Append(Environment.NewLine + "\t-webkit-text-size-adjust: none !important;");
                stringBuilder.Append(Environment.NewLine + "} /* Prevent Webkit platforms from changing default text sizes */");
                stringBuilder.Append(Environment.NewLine + "body {");
                stringBuilder.Append(Environment.NewLine + "\twidth: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "\tmin-width: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "} /* Prevent iOS Mail from adding padding to the body */");
                stringBuilder.Append(Environment.NewLine + "#bodyCell {");
                stringBuilder.Append(Environment.NewLine + "\tpadding: 5px !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t/* ======== Page Styles ======== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section template width");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the template fluid for portrait or landscape view adaptability. If a fluid layout doesn't work for you, set the width to 300px instead.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#templateContainer {");
                stringBuilder.Append(Environment.NewLine + "\tmax-width: 600px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ width: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "\tbackground-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "\twidth: 16px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "\tbackground-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "\twidth: 17px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section heading 1");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the first-level headings larger in size for better readability on small screens.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h1 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 24px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section heading 2");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the second-level headings larger in size for better readability on small screens.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h2 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 20px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section heading 3");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the third-level headings larger in size for better readability on small screens.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h3 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 18px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section heading 4");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the fourth-level headings larger in size for better readability on small screens.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "h4 {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 16px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ======== Header Styles ======== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "#templatePreheader {");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: none !important;");
                stringBuilder.Append(Environment.NewLine + "} /* Hide the template preheader to save space */");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section header image");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the main header image fluid for portrait or landscape view adaptability, and set the image's original width as the max-width. If a fluid setting doesn't work, set the image width to half its original size instead.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + "#headerImage {");
                stringBuilder.Append(Environment.NewLine + "\theight: auto !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ max-width: 600px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ width: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section header text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the header content text larger in size for better readability on small screens. We recommend a font size of at least 16px.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".headerContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 20px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 125% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ======== Body Styles ======== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section body text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the body content text larger in size for better readability on small screens. We recommend a font size of at least 16px.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".bodyContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 18px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 125% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ======== Column Styles ======== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + ".templateColumnContainer {");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: block !important;");
                stringBuilder.Append(Environment.NewLine + "\twidth: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section column image");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the column image fluid for portrait or landscape view adaptability, and set the image's original width as the max-width. If a fluid setting doesn't work, set the image width to half its original size instead.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".columnImage {");
                stringBuilder.Append(Environment.NewLine + "\theight: auto !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ max-width: 480px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ width: 100% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section left column text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the left column content text larger in size for better readability on small screens. We recommend a font size of at least 16px.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".leftColumnContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 16px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 125% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section right column text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the right column content text larger in size for better readability on small screens. We recommend a font size of at least 16px.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".rightColumnContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 16px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 125% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "/* ======== Footer Styles ======== */");
                stringBuilder.Append(Environment.NewLine ?? "");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t/**");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tab Mobile Styles");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @section footer text");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t* @tip Make the body content text larger in size for better readability on small screens.");
                stringBuilder.Append(Environment.NewLine + "\t\t\t\t*/");
                stringBuilder.Append(Environment.NewLine + ".footerContent {");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ font-size: 14px !important;");
                stringBuilder.Append(Environment.NewLine + "\t/*@editable*/ line-height: 115% !important;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".footerContent a {");
                stringBuilder.Append(Environment.NewLine + "\tdisplay: block !important;");
                stringBuilder.Append(Environment.NewLine + "} /* Place footer social and utility links on their own lines, for easier access */");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (max-device-width:1440px){");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "width: 17px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "width: 18px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 414px) {");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 16px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 17px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 384px) {");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "width: 18px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 18px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 17px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "}");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 375px) and (max-device-width : 667px) {");
                else
                    stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 375px) {");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 15px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 16px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 16px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 15px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 360px) {");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "width: 18px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                stringBuilder.Append(Environment.NewLine + "width: 20px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "@media only screen and (max-width: 320px) {");
                stringBuilder.Append(Environment.NewLine + ".colr {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 21px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 17px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + ".colr2 {");
                stringBuilder.Append(Environment.NewLine + "background-color: #952927 !important;");
                if (MessageType == "N")
                    stringBuilder.Append(Environment.NewLine + "width: 19px;");
                else
                    stringBuilder.Append(Environment.NewLine + "width: 17px;");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "}");
                stringBuilder.Append(Environment.NewLine + "</style>");
                stringBuilder.Append(Environment.NewLine + "</head>");
                stringBuilder.Append(Environment.NewLine + "<body leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>");
                stringBuilder.Append(Environment.NewLine + "<center>");
                stringBuilder.Append(Environment.NewLine + "  <table align='center' border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable'>");
                stringBuilder.Append(Environment.NewLine + "    <tr>");
                stringBuilder.Append(Environment.NewLine + "      <td align='center' valign='top' id='bodyCell'><!-- BEGIN TEMPLATE // -->");
                stringBuilder.Append(Environment.NewLine + "        ");
                stringBuilder.Append(Environment.NewLine + "        <table border='0' cellpadding='0' cellspacing='0' id='templateContainer'>");
                stringBuilder.Append(Environment.NewLine + "          <tr>");
                stringBuilder.Append(Environment.NewLine + "            <td align='center' valign='top'><!-- BEGIN PREHEADER // --> ");
                stringBuilder.Append(Environment.NewLine + "              ");
                stringBuilder.Append(Environment.NewLine + "              <!-- // END PREHEADER --></td>");
                stringBuilder.Append(Environment.NewLine + "          </tr>");
                stringBuilder.Append(Environment.NewLine + "          <tr>");
                stringBuilder.Append(Environment.NewLine + "            <td align='center' valign='top'><!-- BEGIN HEADER // -->");
                stringBuilder.Append(Environment.NewLine + "              ");
                stringBuilder.Append(Environment.NewLine + "              <table border='0' cellpadding='0' cellspacing='0' width='100%' id='templateHeader'>");
                stringBuilder.Append(Environment.NewLine + "                <tr>");
                stringBuilder.Append(Environment.NewLine + @"                  <td valign='top' class='headerContent'><img src='" + imgHeader + "' width='600' height='145' alt='' style='max-width:600px; display:block !important;' id='headerImage' mc:label='header_image' mc:edit='header_image' mc:allowdesigner mc:allowtext ></td>");
                stringBuilder.Append(Environment.NewLine + "                </tr>");
                stringBuilder.Append(Environment.NewLine + "                <tr>");
                stringBuilder.Append(Environment.NewLine + "                  <td valign='top' class='headerContent'><img src='" + imgPageHead + "' width='600' height='33' alt='' style='max-width:600px;display:block !important;' id='headerImage' mc:label='header_image' mc:edit='header_image' mc:allowdesigner mc:allowtext></td>");
                stringBuilder.Append(Environment.NewLine + "                </tr>");
                stringBuilder.Append(Environment.NewLine + "                <tr>");
                stringBuilder.Append(Environment.NewLine + "                  <td align='center' valign='top'><!-- BEGIN COLUMNS // -->");
                stringBuilder.Append(Environment.NewLine + "                    ");
                stringBuilder.Append(Environment.NewLine + "                    <table border='0' cellpadding='0' cellspacing='0' width='100%' id='templateColumns' style='border:none !important;'>");
                stringBuilder.Append(Environment.NewLine + "                      <tr mc:repeatable>");
                stringBuilder.Append(Environment.NewLine + "                        <td align='center' valign='top'  width='14' style='background-color:#952927;' class='colr'><table border='0' cellpadding='0' cellspacing='0' width='100%'>");
                stringBuilder.Append(Environment.NewLine + "                          </table></td>");
                stringBuilder.Append(Environment.NewLine + "                        <td align='center' valign='top'  width='571'  style='background:#fff;'><table border='0' cellpadding='15' cellspacing='0' width='100%'><tr>");
                stringBuilder.Append(Environment.NewLine + "                            ");
                //stringBuilder.Append(Environment.NewLine + "                              <td valign='top'  mc:edit='center_column_content'><p style='color:#666;'>" + str + "</p></td>");
                stringBuilder.Append(Environment.NewLine + "                              <td valign='top'  mc:edit='center_column_content'><p>" + str + "</p></td>");
                stringBuilder.Append(Environment.NewLine + "                            </tr>");
                stringBuilder.Append(Environment.NewLine + "                          </table></td>");
                stringBuilder.Append(Environment.NewLine + "                        <td align='center' valign='top'  style='background-color:#952927;' width='15' class='colr2'><table border='0' cellpadding='0' cellspacing='0' width='100%'>");
                stringBuilder.Append(Environment.NewLine + "                            <tr>");
                stringBuilder.Append(Environment.NewLine + "                              <td  ></td>");
                stringBuilder.Append(Environment.NewLine + "                            </tr>");
                stringBuilder.Append(Environment.NewLine + "                            <tr>");
                stringBuilder.Append(Environment.NewLine + "                              <td valign='top'  mc:edit='right_column_content'></td>");
                stringBuilder.Append(Environment.NewLine + "                            </tr>");
                stringBuilder.Append(Environment.NewLine + "                          </table></td>");
                stringBuilder.Append(Environment.NewLine + "                      </tr>");
                stringBuilder.Append(Environment.NewLine + "                    </table>");
                stringBuilder.Append(Environment.NewLine + "                    ");
                stringBuilder.Append(Environment.NewLine + "                    <!-- // END COLUMNS --></td>");
                stringBuilder.Append(Environment.NewLine + "                </tr>");
                stringBuilder.Append(Environment.NewLine + "                <tr>");
                stringBuilder.Append(Environment.NewLine + "                  <td valign='top' class='headerContent'><img src='" + imgFooter + "' width='600' height='337' alt='' style='max-width:600px;display:block !important;' id='headerImage' mc:label='header_image' mc:edit='header_image' mc:allowdesigner mc:allowtext></td>");
                stringBuilder.Append(Environment.NewLine + "                </tr>");
                stringBuilder.Append(Environment.NewLine + "                ");
                stringBuilder.Append(Environment.NewLine + "                  <tr><td valign='top' class='headerContent'><img src='" + imgSocial + "' alt='' width='600' height='96' usemap='#headerImageMap' id='headerImage' style='max-width:600px;display:block !important;' mc:label='header_image' mc:edit='header_image' mc:allowdesigner mc:allowtext border='0'></td>");
                stringBuilder.Append(Environment.NewLine + "                </tr>");
                stringBuilder.Append(Environment.NewLine + "              </table>");
                stringBuilder.Append(Environment.NewLine + "              ");
                stringBuilder.Append(Environment.NewLine + "              <!-- // END HEADER --></td>");
                stringBuilder.Append(Environment.NewLine + "          </tr>");
                stringBuilder.Append(Environment.NewLine + "          <tr>");
                stringBuilder.Append(Environment.NewLine + "            <td align='center' valign='top'><!-- BEGIN BODY // --> ");
                stringBuilder.Append(Environment.NewLine + "              ");
                stringBuilder.Append(Environment.NewLine + "              <!-- // END BODY --></td>");
                stringBuilder.Append(Environment.NewLine + "          </tr>");
                stringBuilder.Append(Environment.NewLine + "          <tr>");
                stringBuilder.Append(Environment.NewLine + "            <td align='center' valign='top'><!-- BEGIN COLUMNS // --> ");
                stringBuilder.Append(Environment.NewLine + "              ");
                stringBuilder.Append(Environment.NewLine + "              <!-- // END COLUMNS --></td>");
                stringBuilder.Append(Environment.NewLine + "          </tr>");
                stringBuilder.Append(Environment.NewLine + "          <tr>");
                stringBuilder.Append(Environment.NewLine + "            <td align='center' valign='top'><!-- BEGIN FOOTER // --> ");
                stringBuilder.Append(Environment.NewLine + "              ");
                stringBuilder.Append(Environment.NewLine + "              <!-- // END FOOTER --></td>");
                stringBuilder.Append(Environment.NewLine + "          </tr>");
                stringBuilder.Append(Environment.NewLine + "        </table>");
                stringBuilder.Append(Environment.NewLine + "        ");
                stringBuilder.Append(Environment.NewLine + "        <!-- // END TEMPLATE --></td>");
                stringBuilder.Append(Environment.NewLine + "    </tr>");
                stringBuilder.Append(Environment.NewLine + "  </table>");
                stringBuilder.Append(Environment.NewLine + "</center>");
                stringBuilder.Append(Environment.NewLine + "<map name='headerImageMap' id='headerImageMap'>");
                stringBuilder.Append(Environment.NewLine + "  <area shape='rect' coords='127,63,259,86' href='http://ijarah.sa/' target='new' />");
                stringBuilder.Append(Environment.NewLine + "  <area shape='rect' coords='273,65,381,86' href='https://twitter.com/ijarah_sa' target='new' />");
                stringBuilder.Append(Environment.NewLine + "  <area shape='rect' coords='395,61,464,85' href='https://www.facebook.com/ijarah' />");
                stringBuilder.Append(Environment.NewLine + "</map>");
                stringBuilder.Append(Environment.NewLine + "</body>");
                stringBuilder.Append(Environment.NewLine + "</html>");
            }
            catch (Exception ex)
            {
                methodName = "IjarahMessagingGateway_FormatEmail";
                objCommonSP.LogError(methodName, ex.Message);
            }
            return stringBuilder.ToString();

        }


    }
}
