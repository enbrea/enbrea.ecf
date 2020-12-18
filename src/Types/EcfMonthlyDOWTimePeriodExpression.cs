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

namespace Enbrea.Ecf
{
    /// <summary>
    /// Represents a monthly recurrence
    /// </summary>
    /// <remarks>
    /// Example: Starting from 5/10/2015: Every Monday and Tuesday on the last week of every month from 8:00 to 10:00 
    /// </remarks>
    public class EcfMonthlyDOWTimePeriodExpression : EcfDaysOfWeekBasedExpression
    {
        /// <summary>
        /// Set of weeks wihtin a month (e.g. First week, second week)
        /// </summary>
        public EcfWeekOfMonthSet WeeksOfMonth { get; set; }
    }
}