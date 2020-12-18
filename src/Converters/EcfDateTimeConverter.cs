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

using Enbrea.Csv;
using System;
using System.Globalization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="DateTime"> converter to or from CSV
    /// </summary>
    public class EcfDateTimeConverter : CsvDefaultConverter
    {
        private readonly string[] _formats =
        {
            "yyyy-MM-dd'T'HH:mm:ss",
            "yyyy-MM-dd'T'HH:mm",
            "yyyy-MM-dd",
        };

        public EcfDateTimeConverter() : 
            base(typeof(DateTime), CultureInfo.InvariantCulture)
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
                return DateTime.ParseExact(value, _formats, CultureInfo, DateTimeStyles.None);
            }
        }

        public override string ToString(object value)
        {
            if ((value != null) && (value is DateTime dateTimeValue))
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