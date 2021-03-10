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
    /// A set of all 12 months
    /// </summary>
    [Flags]
    public enum EcfMonthSet
    {
        January   = 1 << 1,
        February  = 1 << 2,
        March     = 1 << 3,
        April     = 1 << 4,
        May       = 1 << 5,
        June      = 1 << 6,
        July      = 1 << 7,
        August    = 1 << 8,
        Septmeber = 1 << 10,
        October   = 1 << 11,
        November  = 1 << 12,
        December  = 1 << 13,
    };
}