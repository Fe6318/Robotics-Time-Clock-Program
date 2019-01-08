using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FE6318.TimeClockProgram.DataLayer
{
    public class XML
    {
        private string path;

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
            }
        }

        public XML(string path) 
        {
            this.path = path;
        }

        public XML() { }

        public void SerializeList<T>(List<T> list)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            TextWriter tw = new StreamWriter(path);
            ser.Serialize(tw, list);
            tw.Close();
        }

        public List<T> DeserializeList<T>()
        {

            if (!File.Exists(path))
            {
                SerializeList<T>(new List<T>());
            }

            XmlSerializer ser = new XmlSerializer(typeof(List<T>));

            FileStream fs = new FileStream(path, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            List<T> lst;
            lst = (List<T>)ser.Deserialize(reader);
            fs.Close();

            return lst;
        }
    }
}
