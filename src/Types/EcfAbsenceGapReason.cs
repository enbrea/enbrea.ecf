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
    /// A gap due to an absence.
    /// </summary>
    public class EcfAbsenceGapReason : EcfGapReason
    {
        /// <summary>
        /// Absence (Abwesenheit) of a teacher, room, course etc.
        /// </summary>
        public string AbsenceId { get; set; }

        /// <summary>
        /// Determines whether two <see cref="EcfGapReason"> instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified Object is equal to the current Object; otherwise, false.</returns>
        public override bool Equals(EcfGapReason obj)
        {
            return base.Equals(obj) && (AbsenceId == ((EcfAbsenceGapReason)obj).AbsenceId);
        }
    }
}