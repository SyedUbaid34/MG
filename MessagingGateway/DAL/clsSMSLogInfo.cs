using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsSMSLogInfo
    {
        public decimal SMSLOGID
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
        public string RECIPIENTS
        {
            get;
            set;
        }

        public string CONTRACTNO
        {
            get;
            set;
        }
    }
}
