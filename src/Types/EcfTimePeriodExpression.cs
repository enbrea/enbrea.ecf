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
    /// An abstract temporal time period expression set
    /// </summary>
    /// <remarks>
    /// A TimePeriodExpression is the base class for <see cref="EcfOneTimeExpression"/> and <see cref="EcfRecurringTimePeriodExpression"/>.
    /// </remarks>
    public abstract class EcfTimePeriodExpression : EcfTemporalExpression
    {
        private EcfTimePeriod _timePeriod;

        /// <summary>
        /// The time span between StartTimepoint and EndTimepoint
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return _timePeriod.Duration;
            }
            set
            {
                _timePeriod.Duration = value;
            }
        }

        /// <summary>
        /// End timepoint
        /// </summary>
        public DateTimeOffset EndTimepoint
        {
            get
            {
                return _timePeriod.EndTimepoint;
            }
            set
            {
                _timePeriod.EndTimepoint = value;
            }
        }

        /// <summary>
        /// Start timepoint
        /// </summary>
        public DateTimeOffset StartTimepoint
        {
            get
            {
                return _timePeriod.StartTimepoint;
            }
            set
            {
                _timePeriod.StartTimepoint = value;
            }
        }

        /// <summary>
        /// Start timepoint
        /// </summary>
        public EcfTimePeriod TimePeriod
        {
            get
            {
                return _timePeriod;
            }
            set
            {
                _timePeriod = value;
            }
        }
    }
}