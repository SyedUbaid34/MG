﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendSRSms", Namespace = "")]
    public class IjarahSRSms
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

        [DataMember(Name = "SMSReference", Order = 2)]
        public string SMSReference
        {
            get;
            set;
        }

        [DataMember(Name = "OpportunityNumber", Order = 3)]
        public string OpportunityNumber
        {
            get;
            set;
        }

        [DataMember(Name = "Category", Order = 4)]
        public string Category
        {
            get;
            set;
        }

        [DataMember(Name = "Amount", Order = 5)]
        public string Amount
        {
            get;
            set;
        }

        [DataMember(Name = "SubCategory", Order = 6)]
        public string SubCategory
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

        [DataMember(Name = "DueDate", Order = 10)]
        public string DueDate
        {
            get;
            set;
        }

        [DataMember(Name = "SadadReferenceNumber", Order = 11)]
        public string SadadReferenceNumber
        {
            get;
            set;
        }
    }
}