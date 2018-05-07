using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsLogEntryDetailsInfo
    {
        public decimal LOGENTRYDETAILSID
        {
            get;
            set;
        }

        public decimal LOGENTRYID
        {
            get;
            set;
        }

        public string EMAIL
        {
            get;
            set;
        }

        public int ERRORLOGID
        {
            get;
            set;
        }

        public int DELIVERYSTAUS
        {
            get;
            set;
        }

        public DateTime DATE
        {
            get;
            set;
        }
    }
}
