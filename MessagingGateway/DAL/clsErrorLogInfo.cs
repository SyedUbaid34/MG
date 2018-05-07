using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsErrorLogInfo
    {
        public decimal ERRORLOGID
        {
            get;
            set;
        }

        public string ERRORCODE
        {
            get;
            set;
        }

        public string ERRORTYPE
        {
            get;
            set;
        }

        public string ERRORDESCRIPTION
        {
            get;
            set;
        }

        public DateTime CREATEDDATE
        {
            get;
            set;
        }
    }
}
