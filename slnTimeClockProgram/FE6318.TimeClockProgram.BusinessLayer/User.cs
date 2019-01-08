using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FE6318.TimeClockProgram.BusinessLayer
{
   /*
    * Keeps track of a user.
    */
    public class User
    {
        private string firstName;
        public string FirstName { get => firstName; set => firstName = value; }

        private string lastName;
        public string LastName { get => lastName; set => lastName = value; }

        public string Name { get => FirstName + " " + LastName; }

        private string userID;
        public string UserID { get => userID; set => userID = value; }
        
        public double LoggedHours
        {
            //calculate the logged hours using the log files
            get
            {
                double lHours = 0;
                for(int i = 0; i < timeClockedOut.Count; i++)
                {
                    lHours += timeClockedOut[i].Subtract(timeClockedIn[i]).Hours;
                }
                return lHours;
            }
        }

        private bool isClockedIn;
        public bool IsClockedIn { get => isClockedIn; set => isClockedIn = value; }

        private List<DateTime> timeClockedIn;
        public List<DateTime> TimeClockedIn { get => timeClockedIn; set => timeClockedIn = value; }

        private List<DateTime> timeClockedOut;
        public List<DateTime> TimeClockedOut { get => timeClockedOut; set => timeClockedOut = value; }
        

        public User(String userID, String firstName, String lastName)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            timeClockedIn = new List<DateTime>();
            timeClockedOut = new List<DateTime>();
        }

        public User()
        {
            timeClockedIn = new List<DateTime>();
            timeClockedOut = new List<DateTime>();
        }
        
        public bool clockIn()
        {
            if(isClockedIn)
            {
                return false;
            }
            timeClockedIn.Add(DateTime.Now);
            isClockedIn = true;
            return true;
        }

        public double getNumberOfHoursElapsedBetweenClocks()
        {
            TimeSpan tsTimeWorked = timeClockedOut[timeClockedOut.Count - 1].Subtract(timeClockedIn[timeClockedIn.Count - 1]);
            return tsTimeWorked.TotalHours;
        }

        public String getFormatedClockInTime()
        {
            return timeClockedIn[timeClockedIn.Count - 1].ToShortDateString() + " " + timeClockedIn[timeClockedIn.Count - 1].ToLongTimeString();
        }

        public bool clockOut()
        {
            if(!isClockedIn)
            {
                return false;
            }

            timeClockedOut.Add(DateTime.Now);
            isClockedIn = false;
            return true;
        }

        public String getFormatedClockOutTime()
        {
            return timeClockedOut[timeClockedOut.Count - 1].ToShortDateString() + " " + timeClockedOut[timeClockedOut.Count - 1].ToLongTimeString();
        }

        public void clock()
        {
            //if clocked out, clock in
            if(isClockedIn)
            {
                timeClockedOut.Add(DateTime.Now);
                isClockedIn = false;
            } else
            {
                timeClockedIn.Add(DateTime.Now);
                isClockedIn = true;
            }
        }
    }
}
