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
    /// Represents a daily recurrence
    /// </summary>
    /// <remarks>
    /// Example: Starting from 5/10/2015: Fortnightly (14-tägig) from 8:00 to 10:00 
    /// </remarks>
    public class EcfDailyTimePeriodExpression : EcfRecurringTimePeriodExpression
    {
        /// <summary>
        /// Day interval (e.g. every second day)
        /// </summary>
        public uint DaysInterval { get; set; }
    }
}