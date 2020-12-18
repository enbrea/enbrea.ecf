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
    /// Represents a weekly recurrence
    /// </summary>
    /// <remarks>
    /// Example: Starting from 5/10/2015: Every week on Monday and Tuesday from 8:00 to 10:00 
    /// </remarks>
    public class EcfWeeklyTimePeriodExpression : EcfDaysOfWeekBasedExpression
    {
        /// <summary>
        /// Week interval (e.g. every second week)
        /// </summary>
        public uint WeeksInterval { get; set; }
    }
}