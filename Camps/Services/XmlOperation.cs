using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Camps.Services
{
    public class XmlOperation
    {
        public bool PrepareXml<T>(T item, string filePath) where T : class
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (var writer = new System.IO.StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(writer, item);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while preparing the XML file: {ex.Message}", ex);
            }
        }
    }
}
