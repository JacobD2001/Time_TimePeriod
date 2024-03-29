﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public struct TimeStruct : IEquatable<TimeStruct>, IComparable<TimeStruct>
    {
        private byte Hours { get; }
        private byte Minutes { get; }
        private byte Seconds { get; }

        /// <summary>
        /// Determines so that incorrect values can't be animput
        /// </summary>
        /// <param name="time"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// 
        public TimeStruct(byte hours) : this() 
        {
            Hours = hours;
        }

        public TimeStruct(byte hours, byte minutes) : this() 
        {
            Hours = hours;
            Minutes = minutes;
        }

        public TimeStruct(byte hours, byte minutes, byte seconds) 
        {
            Hours = isProperValue(hours, 0, 23);
            Minutes = isProperValue(minutes, 0, 59);
            Seconds = isProperValue(seconds, 0, 59);

            byte isProperValue(byte timeValues, byte minimum, byte maxium) =>
               (timeValues >= minimum && timeValues <= maxium) ? timeValues : throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// returns time read from string format
        /// </summary>
        /// <param name="time"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        
        public TimeStruct(string time)
        {
            string[] timeAsString = time.Split(" ");

            Hours = isProperValue(byte.Parse(timeAsString[0]), 0, 23);
            Minutes = isProperValue(byte.Parse(timeAsString[1]), 0, 59);
            Seconds = isProperValue(byte.Parse(timeAsString[2]), 0, 59);

            byte isProperValue(byte timeValues, byte minimum, byte maxium) =>
               (timeValues >= minimum && timeValues <= maxium) ? timeValues : throw new ArgumentOutOfRangeException();
        }
     
        /// <summary>
        /// reads and returns format of time as __H __M __S
        /// </summary>
        /// <param name="time2"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Hours:00}{"H"} {Minutes:00}{"M"} {Seconds:00}{"S"}";
        }
        
        /************************************/
        public bool Equals(TimeStruct time2)
        {
            return Hours == time2.Hours && Minutes == time2.Minutes && Seconds == time2.Seconds;
        }

        public static bool operator ==(TimeStruct time1, TimeStruct time2)
        {
            return time1.Equals(time2);
        }

        public static bool operator !=(TimeStruct time1, TimeStruct time2)
        {
            return !(time1.Equals(time2));
        }
        /************************************/
        public int CompareTo(TimeStruct otherTime)
        {

            if (Hours.CompareTo(otherTime.Hours) != 0) return Hours.CompareTo(otherTime.Hours);
            else if (Minutes.CompareTo(otherTime.Minutes) != 0) return Minutes.CompareTo(otherTime.Minutes);
            else if (Seconds.CompareTo(otherTime.Seconds) != 0) return Seconds.CompareTo(otherTime.Seconds);
            else return 0;

        }

        public static bool operator <(TimeStruct left, TimeStruct right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(TimeStruct left, TimeStruct right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(TimeStruct left, TimeStruct right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(TimeStruct left, TimeStruct right)
        {
            return left.CompareTo(right) >= 0;
        }
        /*******************************/
        /// <summary>
        /// Calculates time to seconds and stores it in long variable
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>

        public static long timeToSeconds(TimeStruct time1)
        {
            long timeToSeconds = time1.Hours * 3600 + time1.Minutes * 60 + time1.Seconds;
            return timeToSeconds;
        }
      
        /// <summary>
        /// Enables adding two times 
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static TimeStruct operator +(TimeStruct time1, TimeStruct time2) //overload + operator
        {
            byte h;
            long secondsTmp = timeToSeconds(time1) + time1.Seconds;
            if (secondsTmp / 3600 > 23) h = (byte)((secondsTmp / 3600) % 24);
            else h = (byte)(secondsTmp / 3600);
            var m = (byte)((secondsTmp / 60) % 60);
            var s = (byte)(secondsTmp % 60);

            byte h2;
            long secondsTmp2 = timeToSeconds(time2) + time2.Seconds;
            if (secondsTmp2 / 3600 > 23) h2 = (byte)((secondsTmp2 / 3600) % 24);
            else h2 = (byte)((secondsTmp2 / 3600) + h);
            var m2 = (byte)(((secondsTmp2 / 60) % 60) + m);
            var s2 = (byte)((secondsTmp2 % 60) + s);

            return new TimeStruct(h2, m2, s2);

        }

        /// <summary>
        /// Enables substraction of two times
        /// </summary>
        /// <param name="time1"></para
        /// <param name="time2"></param>
        /// <returns></returns>
        public static TimeStruct operator -(TimeStruct time1, TimeStruct time2) //overload - operator
        {
            if (time1 >= time2)
            {

                byte h2;
                long secondsTmp2 = timeToSeconds(time2) + time2.Seconds;
                if (secondsTmp2 / 3600 > 23) h2 = (byte)((secondsTmp2 / 3600) % 24);
                else h2 = (byte)((secondsTmp2 / 3600));
                var m2 = (byte)(((secondsTmp2 / 60) % 60));
                var s2 = (byte)((secondsTmp2 % 60));

                byte h;
                long secondsTmp = timeToSeconds(time1) + time1.Seconds;
                if (secondsTmp / 3600 > 23) h = (byte)((secondsTmp / 3600) % 24);
                else h = (byte)(secondsTmp / 3600 - h2);
                var m = (byte)((secondsTmp / 60) % 60 - m2);
                var s = (byte)(secondsTmp % 60 - s2);

                return new TimeStruct(h, m, s);
            }
            else
            {
                byte h;
                long secondsTmp = timeToSeconds(time1) + time1.Seconds;
                if (secondsTmp / 3600 > 23) h = (byte)((secondsTmp / 3600) % 24);
                else h = (byte)(secondsTmp / 3600);
                var m = (byte)((secondsTmp / 60) % 60);
                var s = (byte)(secondsTmp % 60);

                byte h2;
                long secondsTmp2 = timeToSeconds(time2) + time2.Seconds;
                if (secondsTmp2 / 3600 > 23) h2 = (byte)((secondsTmp2 / 3600) % 24);
                else h2 = (byte)((secondsTmp2 / 3600) - h);
                var m2 = (byte)(((secondsTmp2 / 60) % 60) - m);
                var s2 = (byte)((secondsTmp2 % 60) - s);

                return new TimeStruct(h2, m2, s2);
            }

        }










    }
}
