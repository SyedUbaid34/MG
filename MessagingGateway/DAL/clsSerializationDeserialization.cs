using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    internal class clsSerializationDeserialization<T> where T : class
    {
        /// <summary>
        /// Method for Serialization
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize<t>(T value)
        {
            string result;
            try
            {
                Encoding uTF = Encoding.UTF8;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add("", "");
                Encoding encoding = new UTF8Encoding(false);
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
                xmlTextWriter.Formatting = Formatting.None;
                xmlSerializer.Serialize(xmlTextWriter, value, xmlSerializerNamespaces);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                result = uTF.GetString(memoryStream.ToArray());
            }

            catch (Exception ex)
            {
                string methodName = "clsSerializationDeserialization_Serialize";
                clsCommonSP objCommonSP = new clsCommonSP();
                objCommonSP.LogError(methodName, ex.Message);
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Method for Deserialization
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="XMLstring"></param>
        /// <returns></returns>
        public static T Deserialize<t>(string XMLstring)
        {
            if (string.IsNullOrEmpty(XMLstring))
            {
                return default(T);
            }
            T result;
            try
            {
                Encoding uTF = Encoding.UTF8;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream();
                StreamWriter streamWriter = new StreamWriter(memoryStream, uTF);
                streamWriter.Write(XMLstring);
                streamWriter.Flush();
                memoryStream.Position = 0L;
                T ta = (T)((object)xmlSerializer.Deserialize(memoryStream));
                memoryStream.Close();
                result = ta;
            }
            catch (Exception ex)
            {
                string methodName = "clsSerializationDeserialization_Deserialize";
                clsCommonSP objCommonSP = new clsCommonSP();
                objCommonSP.LogError(methodName, ex.Message);
                result = default(T);
            }
            return result;
        }
    }
}
