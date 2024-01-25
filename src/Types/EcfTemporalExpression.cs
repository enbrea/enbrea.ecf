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

namespace Enbrea.Ecf
{
    /// <summary>
    /// An abstract temporal expression
    /// </summary>
    /// <remarks>
    /// A TemporalExpression is the base class for <see cref="EcfTimePeriodExpression"/>.
    /// </remarks>
    public abstract class EcfTemporalExpression
    {
        /// <summary>
        /// Should the temporal expression be included or excluded?
        /// </summary>
        public EcfTemporalExpressionOperation Operation { get; set; }
    }
}