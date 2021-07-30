﻿#region ENBREA ECF - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA ECF
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;

namespace Enbrea.Ecf
{
    /// <summary>
    /// An abstract recurring time period expression 
    /// </summary>
    /// <remarks>
    /// A RecurringTimePeriodExpression is the base class for <see cref="EcfDailyTimePeriodExpression"/>, <see cref="EcfMonthlyTimePeriodExpression"/> 
    /// and <see cref="EcfDaysOfWeekBasedExpression"/>.
    /// </remarks>
    public abstract class EcfRecurringTimePeriodExpression : EcfTimePeriodExpression
    {
        /// <summary>
        /// Valid from (Gültig von)
        /// </summary>
        public DateTimeOffset? ValidFrom { get; set; }

        /// <summary>
        /// Valid to (Gültig bis)
        /// </summary>
        public DateTimeOffset? ValidTo { get; set; }
    }
}