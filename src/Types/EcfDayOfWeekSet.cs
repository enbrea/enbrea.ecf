#region ENBREA.ECF - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ECF
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;

namespace Enbrea.Ecf
{
    /// <summary>
    /// A set of days in a weeks
    /// </summary>
    /// <remarks>
    /// ENBREA does not define a DayOfWeek enumeration. We take the one from the System namespace.
    /// </remarks>
    [Flags]
    public enum EcfDayOfWeekSet
    {
        Sunday    = 1 << 0,
        Monday    = 1 << 1,
        Tuesday   = 1 << 2,
        Wednesday = 1 << 3,
        Thursday  = 1 << 4,
        Friday    = 1 << 5,
        Saturday  = 1 << 6
    };
}