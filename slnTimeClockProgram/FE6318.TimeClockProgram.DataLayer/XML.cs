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
    /// <summary>
    /// A class for saving files in the XML format
    /// </summary>
    public class XML
    {
        private string path;
        /// <value>
        /// File path where the XML will be saved or read from
        /// </value>
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
            }
        }

        /// <summary>
        /// Sets <paramref name="path"/> to the path
        /// </summary>
        /// <param name="path">Path where the file will be saved or read</param>
        public XML(string path) 
        {
            this.path = path;
        }

        /// <summary>
        /// Doesn't set anything
        /// </summary>
        public XML() { }

        /// <summary>
        /// Saves of List of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type that the list will be</typeparam>
        /// <param name="list">List of things to save</param>
        public void SerializeList<T>(List<T> list)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            TextWriter tw = new StreamWriter(path);
            ser.Serialize(tw, list);
            tw.Close();
        }

        /// <summary>
        /// Reads the list of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">type of the List that will be read</typeparam>
        /// <returns>The List that is read from</returns>
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
