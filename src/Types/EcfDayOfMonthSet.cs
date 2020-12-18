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
    /// A set of days for a month
    /// </summary>
    [Flags]
    public enum EcfDayOfMonthSet
    {
        Day1    = 1 << 1,
        Day2    = 1 << 2,
        Day3    = 1 << 3,
        Day4    = 1 << 4,
        Day5    = 1 << 5,
        Day6    = 1 << 6,
        Day7    = 1 << 7,
        Day8    = 1 << 8,
        Day9    = 1 << 9,
        Day10   = 1 << 10,
        Day11   = 1 << 11,
        Day12   = 1 << 12,
        Day13   = 1 << 13,
        Day14   = 1 << 14,
        Day15   = 1 << 15,
        Day16   = 1 << 16,
        Day17   = 1 << 17,
        Day18   = 1 << 18,
        Day19   = 1 << 19,
        Day20   = 1 << 20,
        Day21   = 1 << 21,
        Day22   = 1 << 22,
        Day23   = 1 << 23,
        Day24   = 1 << 24,
        Day25   = 1 << 25,
        Day26   = 1 << 26,
        Day27   = 1 << 27,
        Day28   = 1 << 28,
        Day29   = 1 << 29,
        Day30   = 1 << 30,
        Day31   = 1 << 31,
        LastDay = 1 << 32
    };
}