using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendSaleEmail", Namespace = "")]
    public class IjarahSalesEmail
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

        [DataMember(Name = "ApplicationNum", Order = 4)]
        public string ApplicationNum
        {
            get;
            set;
        }

        [DataMember(Name = "Gender", Order = 5)]
        public string Gender
        {
            get;
            set;
        }

        [DataMember(Name = "Firstname", Order = 6)]
        public string Firstname
        {
            get;
            set;
        }

        [DataMember(Name = "DownPayment", Order = 7)]
        public string DownPayment
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

        [DataMember(Name = "AdminFee", Order = 12)]
        public string AdminFee
        {
            get;
            set;
        }

        [DataMember(Name = "VirtualAccntNum", Order = 13)]
        public string VirtualAccntNum
        {
            get;
            set;
        }

        [DataMember(Name = "SADADRefNum", Order = 14)]
        public string SADADRefNum
        {
            get;
            set;
        }

        [DataMember(Name = "Totalamount", Order = 15)]
        public string Totalamount
        {
            get;
            set;
        }

        [DataMember(Name = "Carbrand", Order = 16)]
        public string Carbrand
        {
            get;
            set;
        }

        [DataMember(Name = "Numberplate", Order = 17)]
        public string Numberplate
        {
            get;
            set;
        }
    }
}