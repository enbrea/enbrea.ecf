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
    /// Possible operations of a temporal expression
    /// </summary>
    /// <remarks>
    /// A temporal expression can be included to a schedule or excluded from a schedule
    /// </remarks>
    public enum EcfTemporalExpressionOperation
    {
        Include, Exclude
    };
}