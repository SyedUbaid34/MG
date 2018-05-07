using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessagingGateway
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IijaraMessagingGateway" in both code and config file together.
    [ServiceContract]
    public interface IijaraMessagingGateway
    {
        [OperationContract]
        string SendSMS(IjarahSMS ObjIjarahSMS);

        [OperationContract]
        string SendEMail(IjarahEMail objIjarahEmail);

        [OperationContract]
        string SendSRSms(IjarahSRSms objIjarahSRSMS);

        [OperationContract]
        string SendSREmail(IjarahSREmail objIjarahSREmail);

        [OperationContract]
        string SendSaleSMS(IjarahSaleSMS objIjarahSalesSMS);

        [OperationContract]
        string SendSaleEmail(IjarahSalesEmail objIjarahSalesEmail);

        [OperationContract]
        string SendPOSSMS(IjarahPOSSms objIjarahPOSSMS);

        [OperationContract]
        string SendOTP(IjarahOTPSMS objIjarahOTPSMS);

        [OperationContract]
        string SendBulkEmail(IjarahBulkEmail objIjarahBulkEmail);
    }
}
