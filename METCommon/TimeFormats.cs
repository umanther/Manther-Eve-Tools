using System;
using System.Collections.Generic;
using System.Text;

namespace METCommon
{
    /// <summary>
    /// These constants represent the maximum allowed entries for
    /// any time entry used globaly in MET
    /// </summary>
    public enum MaxTimeConstants
    {
        /// <summary>Maximum Number of Weeks</summary>
        Weeks = 60,
        /// <summary>Maximum Number of Days</summary>
        Days = 6,
        /// <summary>Maximum Number of Hours</summary>
        Hours = 23,
        /// <summary>Maximum Number of Minutes</summary>
        Minutes = 59,
        /// <summary>Maximum Number of Seconds</summary>
        Seconds = 59
    }
    /// <summary>
    /// Time functions used in MET for various uses
    /// </summary>
    public class TimeFormats
    {
        /// <summary>
        /// Convert numeric time notaion to the equivilent number of seconds.
        /// </summary>
        /// <param name="Weeks">Number of Weeks</param>
        /// <param name="Days">Number of Days</param>
        /// <param name="Hours">Number of Hours</param>
        /// <param name="Minutes">Number of Minutes</param>
        /// <param name="Seconds">Number of Seconds</param>
        /// <returns>Total number of Seconds</returns>
        public static uint TimeToSeconds(uint Weeks, uint Days, uint Hours, uint Minutes, uint Seconds)
        {
            uint ReturnSeconds = 0;

            ReturnSeconds += Seconds;
            ReturnSeconds += Minutes * 60;
            ReturnSeconds += Hours * 3600;
            ReturnSeconds += Days * 86400;
            ReturnSeconds += Weeks * 604800;

            return ReturnSeconds;
        }
        /// <summary>
        /// Converts short-hand time notation to the equivilent number of seconds
        /// </summary>
        /// <param name="InputString">Input string representing time.  Follows the format 00A;
        /// where 00 is the number and A is the letter representing the time type.  Allowed time types are
        /// w = weeks, d = days, h = hours, m = minutes, s = seconds.  Seperate time types with spaces.</param>
        /// <returns>Number of total seconds</returns>
        public static uint TimeToSeconds(string InputString)
        {
            uint ReturnSeconds = 0;  // Variable to hold returned seconds

            InputString = InputString.Trim();  // Trim off any external whitespace
            InputString = InputString.ToLower();  // Change all letters to lowercase

            // ---Cut the input string into parts
            string[] StringSections;
            StringSections = InputString.Split(' ');

            foreach (string Section in StringSections)
            {
                try
                {
                    // ---Divide the section into number and letter parts
                    string LetterPart = Section.Substring(Section.Length - 1);
                    string NumberPart = Section.Substring(0, Section.Length - 1);

                    switch (LetterPart)
                    {
                        case "w":
                            ReturnSeconds += 604800 * Convert.ToUInt32(NumberPart);
                            break;
                        case "d":
                            ReturnSeconds += 86400 * Convert.ToUInt32(NumberPart);
                            break;
                        case "h":
                            ReturnSeconds += 3600 * Convert.ToUInt32(NumberPart);
                            break;
                        case "m":
                            ReturnSeconds += 60 * Convert.ToUInt32(NumberPart);
                            break;
                        case "s":
                            ReturnSeconds += Convert.ToUInt32(NumberPart);
                            break;
                        default:
                            break;
                    }
                }
                catch
                {}
            }

            return ReturnSeconds;
        }

        /// <summary>
        /// Function used to convert an ammount of seconds to a
        /// compact, short-hand string representing the total time
        /// </summary>
        /// <param name="Seconds">Total number of seconds</param>
        /// <returns>String containing short-hand notation</returns>
        public static string SecondsToTime(uint Seconds)
        {
            string ReturnString = "";

            if (Math.Truncate((double)Seconds / 604800) != 0)
                ReturnString += Math.Truncate((double)Seconds / 604800) + "w";

            if (Math.Truncate((double)Seconds / 86400) % 7 != 0)
            {
                if (ReturnString != "") ReturnString += " ";
                ReturnString += Math.Truncate((double)Seconds / 86400) % 7 + "d";
            }

            if (Math.Truncate((double)Seconds / 3600) % 24 != 0)
            {
                if (ReturnString != "") ReturnString += " ";
                ReturnString += Math.Truncate((double)Seconds / 3600) % 24 + "h";
            }

            if (Math.Truncate((double)Seconds / 60) % 60 != 0)
            {
                if (ReturnString != "") ReturnString += " ";
                ReturnString += Math.Truncate((double)Seconds / 60) % 60 + "m";
            }

            if (Seconds % 60 != 0)
            {
                if (ReturnString != "") ReturnString += " ";
                ReturnString += Seconds % 60 + "s";
            }

            if (ReturnString == "") ReturnString += "0s";

            return ReturnString;
        }
    }
}