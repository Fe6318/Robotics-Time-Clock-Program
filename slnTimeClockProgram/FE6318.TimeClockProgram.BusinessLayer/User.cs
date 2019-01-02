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
                for (int i = 0; File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\out.6318").Count() > i; i++)
                {

                    DateTime cIn = DateTime.Parse(System.IO.File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\in.6318").Skip(i).Take(1).First());
                    DateTime cOut = DateTime.Parse(System.IO.File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\out.6318").Skip(i).Take(1).First());

                    TimeSpan tWorked = cOut.Subtract(cIn);
                    lHours = lHours + tWorked.TotalHours;

                }
                return lHours;
            }
        }

        private bool isClockedIn;
        public bool IsClockedIn { get => isClockedIn; set => isClockedIn = value; }

        private DateTime timeClockedIn;
        public DateTime TimeClockedIn { get => timeClockedIn; set => timeClockedIn = value; }

        private DateTime timeClockedOut;
        public DateTime TimeClockedOut { get => timeClockedOut; set => timeClockedOut = value; }

        private string logDirectory;

        private String userDirectory;
        

        public User(String userID, String firstName, String lastName)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;

            logDirectory = Environment.CurrentDirectory + @"\Information\Log";

            //create a directory for the user
            System.IO.Directory.CreateDirectory(this.logDirectory + @"\" + firstName + lastName);

            //create the log files
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(this.logDirectory + @"\" + firstName + lastName + @"\in.6318", true)) { }

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(this.logDirectory + @"\" + firstName + lastName + @"\out.6318", true)) { }

            if(System.IO.File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\in.6318").Count() > System.IO.File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\out.6318").Count())
            {
                isClockedIn = true;
                timeClockedIn = DateTime.Parse(System.IO.File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\in.6318").Skip(System.IO.File.ReadLines(logDirectory + @"\" + firstName + lastName + @"\in.6318").Count() - 1).Take(1).First());
            } else
            {
                isClockedIn = false;
            }

            userDirectory = Environment.CurrentDirectory + @"\Information\Users\" + FirstName + LastName;
        }

        
        public bool clockIn()
        {
            if(isClockedIn)
            {
                return false;
            }
            timeClockedIn = DateTime.Now;
            login(timeClockedIn);
            isClockedIn = true;
            return true;
        }

        public double getNumberOfHoursElapsedBetweenClocks()
        {
            TimeSpan tsTimeWorked = timeClockedOut.Subtract(timeClockedIn);
            return tsTimeWorked.TotalHours;
        }

        public String getFormatedClockInTime()
        {
            return timeClockedIn.ToShortDateString() + " " + timeClockedIn.ToLongTimeString();
        }

        public bool clockOut()
        {
            if(!isClockedIn)
            {
                return false;
            }

            timeClockedOut = DateTime.Now;
            isClockedIn = false;
            logOut(timeClockedOut);
            return true;
        }

        public String getFormatedClockOutTime()
        {
            return timeClockedOut.ToShortDateString() + " " + timeClockedOut.ToLongTimeString();
        }

        public void clock()
        {
            //if clocked out, clock in
            if(isClockedIn)
            {
                timeClockedOut = DateTime.Now;
                isClockedIn = false;
                logOut(timeClockedOut);
                logTimes(timeClockedIn, timeClockedOut);
                saveHours(timeClockedIn, timeClockedOut);
            } else
            {
                timeClockedIn = DateTime.Now;
                login(timeClockedIn);
                isClockedIn = true;
            }
        }

        private void logTimes(DateTime cIn, DateTime cOut)
        {
            //log when the users clocked in and out
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(logDirectory + @"\log.txt" , true))
            {
                file.WriteLine(Name + " Clocked In: " + cIn.ToShortDateString() +  " " + cIn.ToLongTimeString() + " Clocked Out: " + cOut.ToShortDateString() + cOut.ToLongTimeString());
            }
        }

        private void login(DateTime cIn)
        {
            //log when the users clocked in
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(logDirectory + @"\" + FirstName + LastName + @"\in.6318", true))
            {
                file.WriteLine(cIn.ToString());
            }
        }

        private void logOut(DateTime cOut)
        {
            //log when the users clocked out
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(logDirectory + @"\" + FirstName + LastName + @"\out.6318", true))
            {
                file.WriteLine(cOut.ToString());
            }
        }

        

        private void saveHours(DateTime cIn, DateTime cOut)
        {
            //store the current user directory
            String strCurrentUserDirectory = userDirectory + @"\" + firstName + lastName + ".6318";

            //write to the file the number of hours worked
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(strCurrentUserDirectory, false)) //false means it will overwrite the current file
            {
                //not possible to write to a certain line of a file (as far as I know) So we have to re-write the whole file
                file.WriteLine(userID);
                file.WriteLine(firstName);
                file.WriteLine(lastName);
                //now we finally can write the number of hours worked
                file.WriteLine((LoggedHours).ToString());
            }
        }
    }
}
