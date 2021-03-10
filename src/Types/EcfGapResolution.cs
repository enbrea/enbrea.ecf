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
    /// An abstract gap resolution (Fehlstellenauflösung).
    /// </summary>
    /// <remarks>
    /// This class is the base class for <see cref="EcfLessonGapResolution"/> and <see cref="EcfSupervisionGapResolution"/>.
    /// </remarks>
    public abstract class EcfGapResolution : IEquatable<EcfGapResolution>
    {
        /// <summary>
        /// Determines whether two <see cref="EcfGapResolution"> instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified Object is equal to the current Object; otherwise, false.</returns>
        public virtual bool Equals(EcfGapResolution obj)
        {
            // Check for null values and compare run-time types.
            return (obj != null && GetType() == obj.GetType());
        }
    }
}