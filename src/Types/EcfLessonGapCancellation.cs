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

namespace Enbrea.Ecf
{
    /// <summary>
    /// A gap resolution: Lesson was cancelled.
    /// </summary>
    public class EcfLessonGapCancellation : EcfLessonGapResolution
    {
        public EcfLessonGapCancellationBehaviour Behaviour { get; set; }

        /// <summary>
        /// Determines whether two <see cref="EcfGapResolution"> instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified Object is equal to the current Object; otherwise, false.</returns>
        public override bool Equals(EcfGapResolution obj)
        {
            return base.Equals(obj) && (Behaviour == ((EcfLessonGapCancellation)obj).Behaviour);
        }
    }
}