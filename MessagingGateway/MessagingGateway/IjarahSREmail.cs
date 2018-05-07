using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendSREmail", Namespace = "")]
    public class IjarahSREmail
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

        [DataMember(Name = "OpportunityNumber", Order = 4)]
        public string OpportunityNumber
        {
            get;
            set;
        }

        [DataMember(Name = "Category", Order = 5)]
        public string Category
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

        [DataMember(Name = "SubCategory", Order = 7)]
        public string SubCategory
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

        [DataMember(Name = "DueDate", Order = 12)]
        public string DueDate
        {
            get;
            set;
        }

        [DataMember(Name = "SadadReferenceNumber", Order = 13)]
        public string SadadReferenceNumber
        {
            get;
            set;
        }
        //Added by Zubair 16-May-17
        [DataMember(Name = "CustomerName", Order = 14)]
        public string CustomerName
        {
            get;
            set;
        }

        [DataMember(Name = "CustomerIBAN", Order = 15)]
        public string CustomerIBAN
        {
            get;
            set;
        }

        [DataMember(Name = "CustomerBankName", Order = 16)]
        public string CustomerBankName
        {
            get;
            set;
        }

        [DataMember(Name = "VirtualAccount", Order = 17)]
        public string VirtualAccount
        {
            get;
            set;
        }
    }
}