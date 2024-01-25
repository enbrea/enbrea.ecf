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
    /// An abstract gap reason (Fehlstellengrund).
    /// </summary>
    /// <remarks>
    /// This class is the base class for <see cref="EcfAbsenceGapReason"/> and <see cref="EcfExamGapReason"/>.
    /// </remarks>
    public abstract class EcfGapReason : IEquatable<EcfGapReason>
    {
        /// <summary>
        /// Determines whether two <see cref="EcfGapReason"> instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified Object is equal to the current Object; otherwise, false.</returns>
        public virtual bool Equals(EcfGapReason obj)
        {
            // Check for null values and compare run-time types.
            return (obj != null && GetType() == obj.GetType());
        }
    }
}