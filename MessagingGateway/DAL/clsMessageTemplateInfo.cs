using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsMessageTemplateInfo
    {
        public int MESSAGETEMPLATEID
        {
            get;
            set;
        }

        public string MESSAGECODE
        {
            get;
            set;
        }

        public string MESSAGETYPE
        {
            get;
            set;
        }

        public string MESSAGESUBJECTEN
        {
            get;
            set;
        }

        public string MESSAGESUBJECTAR
        {
            get;
            set;
        }

        public string MESSAGEBODYEN
        {
            get;
            set;
        }

        public string MESSAGEBODYAR
        {
            get;
            set;
        }

        public string MESSAGEDESCRIPTEN
        {
            get;
            set;
        }

        public string MESSAGEDESCRIPTAR
        {
            get;
            set;
        }

        public string MESSAGESIGNATUREEN
        {
            get;
            set;
        }

        public string MESSAGESIGNATUREAR
        {
            get;
            set;
        }

        public bool ISBODYHTML
        {
            get;
            set;
        }

        public DateTime CREATEDDATE
        {
            get;
            set;
        }

        public int CREATEDBY
        {
            get;
            set;
        }

        public DateTime UPDATEDDATE
        {
            get;
            set;
        }

        public int UPDATEDBY
        {
            get;
            set;
        }

        public int STATUS
        {
            get;
            set;
        }
    }
}
