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
    /// Implementation of a <see cref="DateOnly"/> converter to or from CSV
    /// </summary>
    public class EcfDateOnlyConverter : CsvDateOnlyConverter
    {
        private static readonly string[] _formats =
        {
            "yyyy-MM-dd",
        };

        public EcfDateOnlyConverter() :
            base(CultureInfo.InvariantCulture, _formats)
        {
        }
    }
}