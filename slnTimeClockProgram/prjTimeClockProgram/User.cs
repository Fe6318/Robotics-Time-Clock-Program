using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjTimeClockProgram
{
    public class User
    {
        /*
         * Keeps track of a user. Some of this information is also stored in STARTUPPATH\Information\Users
         */ 
        private String strFirstName;
        private String strLastName;
        private String strUserID;
        private double dblLoggedHours;
        private bool bolIsClockedIn;
        private DateTime dtiClockedIn;
        private DateTime dtiClockedOut;
        private String strLOG_DIRECTORY;
        private String strUSER_DIRECTORY;


        public User(String userID, String firstName, String lastName, double loggedHours, String logDirectory, String userDirectory)
        {
            strUserID = userID;
            strFirstName = firstName;
            strLastName = lastName;
            
            strLOG_DIRECTORY = logDirectory;
            strUSER_DIRECTORY = userDirectory;

            //create a directory for the user
            System.IO.Directory.CreateDirectory(strLOG_DIRECTORY + @"\" + firstName + lastName);

            //create the log files
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\in.6318", true)) { }

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\out.6318", true)) { }

            if(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\in.6318").Count() > System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\out.6318").Count())
            {
                bolIsClockedIn = true;
                dtiClockedIn = DateTime.Parse(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\in.6318").Skip(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\in.6318").Count() - 1).Take(1).First());
            } else
            {
                bolIsClockedIn = false;
            }

            double lHours = 0;
            //calculate the logged hours using the log files
            for (int i = 0; System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\out.6318").Count() > i;i++)
            {

                DateTime cIn = DateTime.Parse(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\in.6318").Skip(i).Take(1).First());
                DateTime cOut = DateTime.Parse(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + firstName + lastName + @"\out.6318").Skip(i).Take(1).First());

                TimeSpan tWorked = cOut.Subtract(cIn);
                lHours = lHours + tWorked.TotalHours;

            }
            dblLoggedHours = lHours;
        }

        public bool getIsClockedIn()
        {
            return bolIsClockedIn;
        }

        public double getLoggedHours()
        {
            return dblLoggedHours;
        }

        public String getName()
        {
            return strFirstName + " " + strLastName;
        }

        public String getFirstName()
        {
            return strFirstName;
        }

        public String getLastName()
        {
            return strLastName;
        }

        public String getUserID()
        {
            return strUserID;
        }

        public DateTime getTimeClockedIn()
        {
            return dtiClockedIn;
        }

        public DateTime getTimeClockedOut()
        {
            return dtiClockedOut;
        }
        public bool clockIn()
        {
            if(bolIsClockedIn)
            {
                return false;
            }
            dtiClockedIn = DateTime.Now;
            login(dtiClockedIn);
            bolIsClockedIn = true;
            return true;
        }

        public double getNumberOfHoursElapsedBetweenClocks()
        {
            TimeSpan tsTimeWorked = dtiClockedOut.Subtract(dtiClockedIn);
            return tsTimeWorked.TotalHours;
        }

        public String getFormatedClockInTime()
        {
            return dtiClockedIn.ToShortDateString() + " " + dtiClockedIn.ToLongTimeString();
        }

        public bool clockOut()
        {
            if(!bolIsClockedIn)
            {
                return false;
            }

            dtiClockedOut = DateTime.Now;
            bolIsClockedIn = false;
            logOut(dtiClockedOut);
            return true;
        }

        public String getFormatedClockOutTime()
        {
            return dtiClockedOut.ToShortDateString() + " " + dtiClockedOut.ToLongTimeString();
        }

        public void clock()
        {
            //if clocked out, clock in
            if(bolIsClockedIn)
            {
                dtiClockedOut = DateTime.Now;
                bolIsClockedIn = false;
                logOut(dtiClockedOut);
                logTimes(dtiClockedIn, dtiClockedOut);
                saveHours(dtiClockedIn, dtiClockedOut);
            } else
            {
                dtiClockedIn = DateTime.Now;
                login(dtiClockedIn);
                bolIsClockedIn = true;
            }
        }

        private void logTimes(DateTime cIn, DateTime cOut)
        {
            //log when the users clocked in and out
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(strLOG_DIRECTORY + @"\log.txt" , true))
            {
                file.WriteLine(getName() + " Clocked In: " + cIn.ToShortDateString() +  " " + cIn.ToLongTimeString() + " Clocked Out: " + cOut.ToShortDateString() + cOut.ToLongTimeString());
            }
        }

        private void login(DateTime cIn)
        {
            //log when the users clocked in
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(strLOG_DIRECTORY + @"\" + getFirstName() + getLastName() + @"\in.6318", true))
            {
                file.WriteLine(cIn.ToString());
            }
        }

        private void logOut(DateTime cOut)
        {
            //log when the users clocked out
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(strLOG_DIRECTORY + @"\" + getFirstName() + getLastName() + @"\out.6318", true))
            {
                file.WriteLine(cOut.ToString());
            }
        }

        public void updateHours()
        {
            double lHours = 0;
            for (int i = 0; System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + strFirstName + strLastName + @"\out.6318").Count() > i; i++)
            {

                DateTime cIn = DateTime.Parse(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + strFirstName + strLastName + @"\in.6318").Skip(i).Take(1).First());
                DateTime cOut = DateTime.Parse(System.IO.File.ReadLines(strLOG_DIRECTORY + @"\" + strFirstName + strLastName + @"\out.6318").Skip(i).Take(1).First());

                TimeSpan tWorked = cOut.Subtract(cIn);
                lHours = lHours + tWorked.TotalHours;

            }
            dblLoggedHours = lHours;
        }

        private void saveHours(DateTime cIn, DateTime cOut)
        {
            //store the current user directory
            String strCurrentUserDirectory = strUSER_DIRECTORY + @"\" + strFirstName + strLastName + ".6318";

            //write to the file the number of hours worked
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(strCurrentUserDirectory, false)) //false means it will overwrite the current file
            {
                //not possible to write to a certain line of a file (as far as I know) So we have to re-write the whole file
                file.WriteLine(strUserID);
                file.WriteLine(strFirstName);
                file.WriteLine(strLastName);
                //now we finally can write the number of hours worked
                file.WriteLine((getNumberOfHoursElapsedBetweenClocks() + dblLoggedHours).ToString());
                dblLoggedHours = dblLoggedHours + getNumberOfHoursElapsedBetweenClocks(); //update the logged hours
            }
        }
    }
}
