using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendMail", Namespace = "")]
    public class IjarahEMail
    {
        [DataMember(Name = "PartnerCode", Order = 0)]
        public string PartnerCode
        {
            get;
            set;
        }

        [DataMember(Name = "RecipientsTo", Order = 1)]
        public string RecipientsTo
        {
            get;
            set;
        }

        [DataMember(Name = "RecipientsCc", Order = 2)]
        public string RecipientsCc
        {
            get;
            set;
        }

        [DataMember(Name = "EmailReference", Order = 3)]
        public string EmailReference
        {
            get;
            set;
        }

        [DataMember(Name = "AccountNumber", Order = 4)]
        public string AccountNumber
        {
            get;
            set;
        }

        [DataMember(Name = "LicensePlateNo", Order = 5)]
        public string LicensePlateNo
        {
            get;
            set;
        }

        [DataMember(Name = "Amount", Order = 6)]
        public string Amount
        {
            get;
            set;
        }

        [DataMember(Name = "DueDate", Order = 7)]
        public string DueDate
        {
            get;
            set;
        }

        [DataMember(Name = "MessageCode", Order = 8)]
        public string MessageCode
        {
            get;
            set;
        }

        [DataMember(Name = "CustomSubjectHead", Order = 9)]
        public string CustomSubjectHead
        {
            get;
            set;
        }

        [DataMember(Name = "CustomMessage", Order = 10)]
        public string CustomMessage
        {
            get;
            set;
        }

        [DataMember(Name = "MessageType", Order = 11)]
        public string MessageType
        {
            get;
            set;
        }
    }
}