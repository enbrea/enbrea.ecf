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
    /// Implementation of a <see cref="TimeOnly"/> converter to or from Ecf
    /// </summary>
    public class EcfTimeOnlyConverter : CsvTimeOnlyConverter
    {
        private static readonly string[] _formats =
        {
            "HH:mm:ss",
            "HH:mm"
        };

        public EcfTimeOnlyConverter()
            : base(CultureInfo.InvariantCulture, _formats)
        {
        }
    }
}