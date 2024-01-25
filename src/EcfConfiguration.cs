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

using Enbrea.Csv;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Default CSV configuration for ECF files
    /// </summary>
    public class EcfConfiguration : CsvConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfConfiguration"/> class.
        /// </summary>
        public EcfConfiguration()
            : base()
        {
            Separator = ';';
        }
    }
}