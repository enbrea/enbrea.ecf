#region ENBREA ECF - Copyright (C) 2020 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA ECF
 *    
 *    Copyright (C) 2020 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;

namespace Enbrea.Ecf
{
    /// <summary>
    /// A period defined by a start time (including date) and an end time (including date)
    /// </summary>
    public struct EcfTimePeriod
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTimepoint"></param>
        /// <param name="endTimepoint"></param>
        public EcfTimePeriod(DateTimeOffset startTimepoint, DateTimeOffset endTimepoint)
        {
            StartTimepoint = startTimepoint;
            EndTimepoint = endTimepoint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anotherTimePeriod"></param>
        public EcfTimePeriod(EcfTimePeriod anotherTimePeriod)
        {
            StartTimepoint = anotherTimePeriod.StartTimepoint;
            EndTimepoint = anotherTimePeriod.EndTimepoint;
        }

        /// <summary>
        /// Duration
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return EndTimepoint - StartTimepoint;
            }
            set
            {
                EndTimepoint = StartTimepoint + value;
            }
        }

        /// <summary>
        /// End timepoint
        /// </summary>
        public DateTimeOffset EndTimepoint { get; set; }

        /// <summary>
        /// Start timepoint
        /// </summary>
        public DateTimeOffset StartTimepoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMoment()
        {
            return StartTimepoint == EndTimepoint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public EcfTimePeriod Shift(TimeSpan timeSpan)
        {
            StartTimepoint = StartTimepoint.Add(timeSpan);
            EndTimepoint = EndTimepoint.Add(timeSpan);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftDays(double days)
        {
            StartTimepoint = StartTimepoint.AddDays(days);
            EndTimepoint = EndTimepoint.AddDays(days);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftHours(double hours)
        {
            StartTimepoint = StartTimepoint.AddHours(hours);
            EndTimepoint = EndTimepoint.AddHours(hours);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftMilliseconds(double milliseconds)
        {
            StartTimepoint = StartTimepoint.AddMilliseconds(milliseconds);
            EndTimepoint = EndTimepoint.AddMilliseconds(milliseconds);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftMinutes(double minutes)
        {
            StartTimepoint = StartTimepoint.AddMinutes(minutes);
            EndTimepoint = EndTimepoint.AddMinutes(minutes);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftMonths(int months)
        {
            StartTimepoint = StartTimepoint.AddMonths(months);
            EndTimepoint = EndTimepoint.AddMonths(months);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftSeconds(double seconds)
        {
            StartTimepoint = StartTimepoint.AddSeconds(seconds);
            EndTimepoint = EndTimepoint.AddSeconds(seconds);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftTicks(long ticks)
        {
            StartTimepoint = StartTimepoint.AddTicks(ticks);
            EndTimepoint = EndTimepoint.AddTicks(ticks);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStartTimePoint"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftTo(DateTimeOffset newStartTimePoint)
        {
            var duration = Duration;
            StartTimepoint = StartTimepoint = newStartTimePoint;
            EndTimepoint = EndTimepoint = newStartTimePoint + duration;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftWeeks(int weeks)
        {
            StartTimepoint = StartTimepoint.AddDays(7 * weeks);
            EndTimepoint = EndTimepoint.AddDays(7 * weeks);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public EcfTimePeriod ShiftYears(int years)
        {
            StartTimepoint = StartTimepoint.AddYears(years);
            EndTimepoint = EndTimepoint.AddYears(years);
            return this;
        }
    }
}