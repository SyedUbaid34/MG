using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MessagingGateway
{
    [DataContract(Name = "SendBulkEmail", Namespace="")]
    public class IjarahBulkEmail
    {
        [DataMember(Name = "RecipientsTo", Order = 1)]
        public string RecipientsTo
        {
            get;
            set;
        }

        [DataMember(Name = "MessageCode", Order = 2)]
        public string MessageCode
        {
            get;
            set;
        }

        [DataMember(Name = "MessageType", Order = 3)]
        public string MessageType
        {
            get;
            set;
        }

        [DataMember(Name = "CustomMessage", Order = 4)]
        public string CustomMessage
        {
            get;
            set;
        }

        [DataMember(Name = "CustomSubjectHead", Order = 5)]
        public string CustomSubjectHead
        {
            get;
            set;
        }

        [DataMember(Name = "OpportunityNumber", Order = 6)]
        public string OpportunityNumber
        {
            get;
            set;
        }

        [DataMember(Name = "SubjectN", Order = 7)]

        public string SubjectN
        {
            get;
            set;
        }

        [DataMember(Name = "SubjectU", Order = 8)]

        public string SubjectU
        {
            get;
            set;
        }

        [DataMember(Name = "RecipientsCc", Order = 9)]
        public string RecipientsCc
        {
            get;
            set;
        }
    }
}