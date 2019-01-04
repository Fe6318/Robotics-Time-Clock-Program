using FE6318.TimeClockProgram.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE6318.TimeClockProgram.BusinessLayer
{
    public class UserList : List<User>
    {
        public void Save()
        {
            XML xml = new XML(Environment.CurrentDirectory + @"\Information\userlist.6318");
            xml.SerializeList<User>((List<User>)this);
        }

        public void Read()
        {
            XML xml = new XML(Environment.CurrentDirectory + @"\Information\userlist.6318");
            List<User> lst;
            lst = xml.DeserializeList<User>();
            foreach(User usr in lst)
            {
                this.Add(usr);
            }
        }
    }
}
