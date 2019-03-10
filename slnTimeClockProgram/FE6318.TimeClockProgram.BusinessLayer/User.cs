using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FE6318.TimeClockProgram.BusinessLayer
{
    /// <summary>
    /// Keep tracks of a User
    /// Contains all methods relating to a User
    /// </summary>
    public class User
    {
        private string firstName;
        /// <value>
        /// Gets or sets the users first name
        /// </value>
        public string FirstName { get => firstName; set => firstName = value; }

        private string lastName;
        /// <value>
        /// Gets or sets the users last name
        /// </value>
        public string LastName { get => lastName; set => lastName = value; }

        /// <value>
        /// Returns the user's formatted name
        /// </value>
        public string Name { get => FirstName + " " + LastName; }

        private string userID;
        /// <value>
        /// Gets or sets the User's UserID
        /// </value>
        public string UserID { get => userID; set => userID = value; }
        
        /// <value>
        /// Gets the number of hours a user has been clocked in
        /// </value>
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
        /// <value>
        /// Gets or sets wether or not a user is clocked in
        /// </value>
        public bool IsClockedIn { get => isClockedIn; set => isClockedIn = value; }

        private List<DateTime> timeClockedIn;
        /// <value>
        /// Gets or sets a list of every time the user has clocked in
        /// </value>
        public List<DateTime> TimeClockedIn { get => timeClockedIn; set => timeClockedIn = value; }

        private List<DateTime> timeClockedOut;
        /// <value>
        /// Gets or sets a list of every time the user has clocked out
        /// </value>
        public List<DateTime> TimeClockedOut { get => timeClockedOut; set => timeClockedOut = value; }
        
        /// <summary>
        /// Sets <paramref name="userID"/>, <paramref name="firstName"/>, and <paramref name="lastName"/> respectively.
        /// Also initializes list of times clocked in and list of times clocked out
        /// </summary>
        /// <param name="userID">The user's ID</param>
        /// <param name="firstName">The user's first name</param>
        /// <param name="lastName">The user's last name</param>
        public User(String userID, String firstName, String lastName)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            timeClockedIn = new List<DateTime>();
            timeClockedOut = new List<DateTime>();
        }

        /// <summary>
        /// Initializes list of times clocked in and list of times clocked out
        /// </summary>
        public User()
        {
            timeClockedIn = new List<DateTime>();
            timeClockedOut = new List<DateTime>();
        }

        /// <summary>
        /// Clock the user in
        /// </summary>
        /// <returns>Wether or not the user was clocked in</returns>
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

        /// <summary>
        /// Gets the number of hours between the last times clocked in and out
        /// </summary>
        /// <returns>Number of hours between last clocks in and out</returns>
        public double getNumberOfHoursElapsedBetweenClocks()
        {
            TimeSpan tsTimeWorked = timeClockedOut[timeClockedOut.Count - 1].Subtract(timeClockedIn[timeClockedIn.Count - 1]);
            return tsTimeWorked.TotalHours;
        }

        /// <summary>
        /// Gets the last clock in time
        /// </summary>
        /// <returns>The last clock in time</returns>
        public String getFormatedClockInTime()
        {
            return timeClockedIn[timeClockedIn.Count - 1].ToShortDateString() + " " + timeClockedIn[timeClockedIn.Count - 1].ToLongTimeString();
        }

        /// <summary>
        /// Clocks the user in
        /// </summary>
        /// <returns>Wether or not the user was clocked out</returns>
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

        /// <summary>
        /// Gets the last clock out time formatted
        /// </summary>
        /// <returns>The last clock out time formatted</returns>
        public String getFormatedClockOutTime()
        {
            return timeClockedOut[timeClockedOut.Count - 1].ToShortDateString() + " " + timeClockedOut[timeClockedOut.Count - 1].ToLongTimeString();
        }

        /// <summary>
        /// Clocks in the user if they are not clocked in, or clocks out the user if they are clocked in
        /// </summary>
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
