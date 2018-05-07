using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendPOSSMS", Namespace = "")]
    public class IjarahPOSSms
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

        [DataMember(Name = "amount", Order = 2)]
        public string amount
        {
            get;
            set;
        }

        [DataMember(Name = "referencenumber", Order = 3)]
        public string referencenumber
        {
            get;
            set;
        }

        [DataMember(Name = "MessageCode", Order = 4)]
        public string MessageCode
        {
            get;
            set;
        }

        [DataMember(Name = "CustomMessage", Order = 5)]
        public string CustomMessage
        {
            get;
            set;
        }

        [DataMember(Name = "MessageType", Order = 6)]
        public string MessageType
        {
            get;
            set;
        }

        [DataMember(Name = "SMSReference", Order = 7)]
        public string SMSReference
        {
            get;
            set;
        }
    }
}