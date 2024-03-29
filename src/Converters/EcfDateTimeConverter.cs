﻿#region ENBREA.ECF - Copyright (c) STÜBER SYSTEMS GmbH
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
    /// Implementation of a <see cref="DateTime"> converter to or from ECF
    /// </summary>
    public class EcfDateTimeConverter : CsvDateTimeConverter
    {
        private static readonly string[] _formats =
        {
            "yyyy-MM-dd'T'HH:mm:ss",
            "yyyy-MM-dd'T'HH:mm",
            "yyyy-MM-dd",
        };

        public EcfDateTimeConverter() : 
            base(CultureInfo.InvariantCulture, _formats)
        {
        }
    }
}