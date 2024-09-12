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
    /// A timeslot (Zeiteinheit) within a timeframe (Zeitrahmen).
    /// </summary>
    public class EcfTimeSlot : IEquatable<EcfTimeSlot>
    {
        /// <summary>
        /// Color (Farbe)
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// End time (Endzeit)
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Label (Beschriftung)
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Start time (Startzeit)
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Number of sub slots (Anzahl der Untereinheiten)
        /// </summary>
        public uint SubSlots { get; set; } = 1;

        /// <summary>
        /// Determines whether two <see cref="EcfTimeSlot"> instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified Object is equal to the current Object; otherwise, false.</returns>
        public virtual bool Equals(EcfTimeSlot obj)
        {
            // Check for null values and compare run-time types.
            return (obj != null && GetType() == obj.GetType());
        }
    }
}