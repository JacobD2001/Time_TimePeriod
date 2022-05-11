using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        //creating prop time in seconds
        long Seconds { get; }

        //creating constructors for 3,2,1 parameters
        public TimePeriod(long hours, byte minutes, byte seconds = 0)
        {
            this.Seconds = hours * 3600 + minutes * 60 + seconds;
        }

        public TimePeriod(long hours, byte minutes)
        {
            this.Seconds = hours * 3600 + minutes * 60;
        }

        public TimePeriod(long seconds)
        {
            Seconds = seconds;
        }
        //string overriding in correct format
        public override string ToString()
        {
            return $"{Seconds / 3600:00}H {Seconds / 60 % 60:00}M {Seconds % 60:00}S";
        }

        //calculating timeperiod

        public TimePeriod(TimeStruct time1, TimeStruct time2)
        {
            TimeStruct timePeriod1 = time1 - time2;
            string tmp = timePeriod1.ToString();
            string[] arr = tmp.Split(" ");
            Seconds = long.Parse(arr[0]) * 3600 + long.Parse(arr[1]) + long.Parse(arr[2]);
        }

        //overloading operators
        public static TimePeriod operator +(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            long sumOfTimePeriods = timePeriod1.Seconds + timePeriod2.Seconds;
            return new TimePeriod(sumOfTimePeriods);
        }

        public static TimePeriod operator -(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            long sumOfTimePeriods = timePeriod1.Seconds - timePeriod2.Seconds;
            return new TimePeriod(sumOfTimePeriods);
        }




        //implementing interfaces
        /************************************/
        public bool Equals(TimePeriod timePeriod)
        {
            return Seconds == timePeriod.Seconds;
        }

        public static bool operator ==(TimePeriod time1, TimePeriod time2)
        {
            return time1.Equals(time2);
        }

        public static bool operator !=(TimePeriod time1, TimePeriod time2)
        {
            return !(time1.Equals(time2));
        }
    
        /************************************/
        public int CompareTo(TimePeriod otherTime)
        {

            if (Seconds.CompareTo(otherTime.Seconds) != 0) return Seconds.CompareTo(otherTime.Seconds);
            else return 0;

        }
        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) >= 0;
        }


        /*******************************/
    }
}
