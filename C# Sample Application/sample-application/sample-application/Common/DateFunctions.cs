using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleApp.Common
{
    public static class DateFunctions
    {

        /// <summary>
        /// Compares two dates represented as strings in M(M)/D(D)/yyyy format
        /// </summary>
        /// <param name="date1Str">1st date to compare</param>
        /// <param name="date2Str">2nd date to compare</param>
        /// <returns> -1 if date1Str is less than date2Str, 0 if the dates are equal, and 1 if date1Str is greater than date2Str</returns>
        public static int CompareDates(string date1Str, string date2Str)
        {
            int[] date1 = DateToIntArray(date1Str);
            int[] date2 = DateToIntArray(date2Str);

            //compare years
            if (date1[2] < date2[2])
                return -1;
            else if(date1[2] == date2[2])
            {
                //compare months
                if (date1[0] < date2[0])
                    return -1;
                else if(date1[0] == date2[0])
                {
                    //compare days
                    if (date1[1] < date2[1])
                        return -1;
                    else if(date1[1] == date2[1])
                        return 0;
                }
            }

            return 1;
        }

        /// <summary>
        /// Formats a date from a datetimepicker object to mm/dd/yyy format
        /// </summary>
        /// <param name="dateStr">the string to format</param>
        /// <returns></returns>
        public static string FormatDate(string date)
        {
            string dateStr = date.Replace(",", ""); //remove commas from the date string
            dateStr = dateStr.Substring(dateStr.IndexOf(" ") + 1); //remove weekday at front of string
            string[] dateArray = dateStr.Split(' '); //separate month day and year

            return GetMonthAsInt(dateArray[0]) + "/" + dateArray[1] + "/" + dateArray[2];
        }

        public static DateTime StrToDateTime(string dateStr)
        {
            string[] dateArray = dateStr.Split('/');
            return new DateTime(int.Parse(dateArray[2]), int.Parse(dateArray[0]), int.Parse(dateArray[1]));
        }

        public static int[] GetCurrentDate()
        {
            DateTime today = DateTime.Today;
            int[] date = { today.Month, today.Day, today.Year };
            return date;
        }

        public static int GetMonthAsInt(string month)
        {
            switch (month)
            {
                case "January": return 1;
                case "February": return 2;
                case "March": return 3;
                case "April": return 4;
                case "May": return 5;
                case "June": return 6;
                case "July": return 7;
                case "August": return 8;
                case "September": return 9;
                case "October": return 10;
                case "November": return 11;
                case "December": return 12;
            }
            return -1;
        }

        public static string IncrementDate(string startDate, int numMonths)
        {
            int[] dateArray = DateToIntArray(startDate);

            for(int i = 0; i < numMonths; i++)
            {
                IncrementMonth(dateArray);
            }

            int daysInMonth = DateTime.DaysInMonth(dateArray[2], dateArray[0]);
            if(dateArray[1] > daysInMonth)
            {
                IncrementMonth(dateArray);
                dateArray[1] -= daysInMonth;
            }
            return dateArray[0] + "/" + dateArray[1] + "/" + dateArray[2];
        }

        private static void IncrementMonth(int[] dateArray)
        {
            if (++dateArray[0] == 13)
            {
                dateArray[0] = 1;
                dateArray[2]++;
            }
        }


        public static int[] DateToIntArray(string dateStr)
        {
            string[] dateArray = dateStr.Split('/');
            int[] date = new int[3];
            for (int i = 0; i < 3; i++)
            {
                date[i] = int.Parse(dateArray[i]);
            }
            return date;
        }

        public static DateTime DateStringToDateTime(string dateStr)
        {
            int[] dateArray = DateToIntArray(dateStr);
            return new DateTime(dateArray[2], dateArray[0], dateArray[1]);
        }

        public static string GetCurrentDateString()
        {
            int[] currDateArray = GetCurrentDate();

            return currDateArray[0] + "/" + currDateArray[1] + "/" + currDateArray[2];
        }
    }
}
