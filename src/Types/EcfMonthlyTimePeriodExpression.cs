#region ENBREA ECF - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA ECF
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace Enbrea.Ecf
{
    /// <summary>
    /// Represents a monthly recurrence
    /// </summary>
    /// <remarks>
    /// Example: Starting from 5/10/2015: The first 14 days in each of the following months (Jan, Feb Mar) from 8:00 to 10:00 
    /// </remarks>
    public class EcfMonthlyTimePeriodExpression : EcfRecurringTimePeriodExpression
    {
        /// <summary>
        /// Set of days within a month (e.g. First day, second day etc.)
        /// </summary>
        public EcfDayOfMonthSet DaysOfMonth { get; set; }

        /// <summary>
        /// Set of months
        /// </summary>
        public EcfMonthSet MonthsOfYear { get; set; }
    }
}