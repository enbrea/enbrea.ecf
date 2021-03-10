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
    /// A gap resolution: Lesson was substituted.
    /// </summary>
    public class EcfLessonGapSubstitution : EcfLessonGapResolution
    {
        /// <summary>
        /// Substitution lesson (Vertretungsunterricht)
        /// </summary>
        public string SubstituteLessonId { get; set; }

        /// <summary>
        /// Determines whether two <see cref="EcfGapResolution"> instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified Object is equal to the current Object; otherwise, false.</returns>
        public override bool Equals(EcfGapResolution obj)
        {
            return base.Equals(obj) && (SubstituteLessonId == ((EcfLessonGapSubstitution)obj).SubstituteLessonId);
        }
    }
}