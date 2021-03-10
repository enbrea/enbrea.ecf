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

using Enbrea.Csv;
using System;
using System.Globalization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="DateTimeOffset"> converter to or from CSV
    /// </summary>
    public class EcfDateTimeOffsetConverter : CsvDefaultConverter
    {
        private readonly string[] _formats =
        {
            "yyyy-MM-dd'T'HH:mm:ss.FFFK",
            "yyyy-MM-dd'T'HH:mm.FFFK",
            "yyyy-MM-dd"
        };

        public EcfDateTimeOffsetConverter() : 
            base(typeof(DateTimeOffset), CultureInfo.InvariantCulture)
        {
        }

        public override object FromString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return DateTimeOffset.ParseExact(value, _formats, CultureInfo, DateTimeStyles.None);
            }
        }

        public override string ToString(object value)
        {
            if ((value != null) && (value is DateTimeOffset dateTimeValue))
            {
                return dateTimeValue.ToString(_formats[0], CultureInfo);
            }
            else
            {
                return base.ToString(value);
            }
        }
    }
}