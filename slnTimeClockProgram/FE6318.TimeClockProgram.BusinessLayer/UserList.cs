using FE6318.TimeClockProgram.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE6318.TimeClockProgram.BusinessLayer
{
    /// <summary>
    /// Adds save and read functionality to  the List class
    /// </summary>
    public class UserList : List<User>
    {
        /// <summary>
        /// Saves all the users in the list
        /// </summary>
        public void Save()
        {
            XML xml = new XML(Environment.CurrentDirectory + @"\Information\UserList.6318");
            xml.SerializeList<User>((List<User>)this);
        }

        /// <summary>
        /// Reads all of the saved users then adds them to the list
        /// </summary>
        public void Read()
        {
            this.Clear();
            XML xml = new XML(Environment.CurrentDirectory + @"\Information\UserList.6318");
            List<User> lst;
            lst = xml.DeserializeList<User>();
            foreach(User usr in lst)
            {
                this.Add(usr);
            }
        }
    }
}
