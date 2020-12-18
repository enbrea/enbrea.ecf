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
    /// An abstract recurring time period expression 
    /// </summary>
    /// <remarks>
    /// A DaysOfWeekBasedExpression is the base class for <see cref="EcfWeeklyTimePeriodExpression"/> and <see cref="EcfMonthlyDOWTimePeriodExpression"/>.
    /// </remarks>
    public abstract class EcfDaysOfWeekBasedExpression : EcfRecurringTimePeriodExpression
    {
        /// <summary>
        /// Set of week days (e.g. Monday and Tuesday)
        /// </summary>
        public EcfDayOfWeekSet DaysOfWeek { get; set; }
    }
}