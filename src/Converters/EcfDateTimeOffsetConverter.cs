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
using System;
using System.Globalization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="DateTimeOffset"> converter to or from ECF
    /// </summary>
    public class EcfDateTimeOffsetConverter : CsvDateTimeOffsetConverter
    {
        private static readonly string[] _formats =
        {
            "yyyy-MM-dd'T'HH:mm:ss.FFFK",
            "yyyy-MM-dd'T'HH:mm.FFFK",
            "yyyy-MM-dd"
        };

        public EcfDateTimeOffsetConverter() :
            base(CultureInfo.InvariantCulture, _formats)
        {
        }
    }
}