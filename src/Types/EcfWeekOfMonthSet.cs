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

using System;

namespace Enbrea.Ecf
{
    /// <summary>
    /// A set of all weeks in a month
    /// </summary>
    [Flags]
    public enum EcfWeekOfMonthSet
    {
        Week1    = 1 << 1, 
        Week2    = 1 << 2,
        Week3    = 1 << 3,
        Week4    = 1 << 4,
        LastWeek = 1 << 5
    };
}