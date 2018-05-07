using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendSaleSMS", Namespace = "")]
    public class IjarahSaleSMS
    {
        [DataMember(Name = "PartnerCode", Order = 0)]
        public string PartnerCode
        {
            get;
            set;
        }

        [DataMember(Name = "Recipients", Order = 1)]
        public string Recipients
        {
            get;
            set;
        }

        [DataMember(Name = "ApplicationNum", Order = 2)]
        public string ApplicationNum
        {
            get;
            set;
        }

        [DataMember(Name = "Gender", Order = 3)]
        public string Gender
        {
            get;
            set;
        }

        [DataMember(Name = "Firstname", Order = 4)]
        public string Firstname
        {
            get;
            set;
        }

        [DataMember(Name = "DownPayment", Order = 5)]
        public string DownPayment
        {
            get;
            set;
        }

        [DataMember(Name = "AdminFee", Order = 6)]
        public string AdminFee
        {
            get;
            set;
        }

        [DataMember(Name = "MessageCode", Order = 7)]
        public string MessageCode
        {
            get;
            set;
        }

        [DataMember(Name = "CustomMessage", Order = 8)]
        public string CustomMessage
        {
            get;
            set;
        }

        [DataMember(Name = "MessageType", Order = 9)]
        public string MessageType
        {
            get;
            set;
        }

        [DataMember(Name = "VirtualAccntNum", Order = 10)]
        public string VirtualAccntNum
        {
            get;
            set;
        }

        [DataMember(Name = "SADADRefNum", Order = 11)]
        public string SADADRefNum
        {
            get;
            set;
        }

        [DataMember(Name = "SMSReference", Order = 12)]
        public string SMSReference
        {
            get;
            set;
        }

        [DataMember(Name = "Totalamount", Order = 13)]
        public string Totalamount
        {
            get;
            set;
        }

        [DataMember(Name = "Carbrand", Order = 14)]
        public string Carbrand
        {
            get;
            set;
        }

        [DataMember(Name = "Numberplate", Order = 15)]
        public string Numberplate
        {
            get;
            set;
        }
    }
}