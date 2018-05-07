using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsLogEntryInfo
    {
        public decimal LOGENTRYID
        {
            get;
            set;
        }

        public string SERVER
        {
            get;
            set;
        }

        public string REFERENCENO
        {
            get;
            set;
        }

        public string MESSAGETYPE
        {
            get;
            set;
        }

        public string MESSAGECODE
        {
            get;
            set;
        }

        public string MSGCODE
        {
            get;
            set;
        }

        public string SUBJECT
        {
            get;
            set;
        }

        public string MESSAGE
        {
            get;
            set;
        }

        public DateTime DATE
        {
            get;
            set;
        }

        public int STATUS
        {
            get;
            set;
        }

        //Added by KISL 
        public string RECIPIENTSTO
        {
            get;
            set;
        }

        //Added by KISL 
        public string RECIPIENTSCC
        {
            get;
            set;
        }
    }
}
