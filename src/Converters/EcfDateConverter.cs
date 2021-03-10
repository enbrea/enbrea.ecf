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
using System.Globalization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="Date"> converter to or from CSV
    /// </summary>
    public class EcfDateConverter : CsvDefaultConverter
    {
        private readonly string[] _formats =
        {
            "yyyy-MM-dd"
        };

        public EcfDateConverter() : 
            base(typeof(Date), CultureInfo.InvariantCulture)
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
                return Date.ParseExact(value, _formats, CultureInfo, DateTimeStyles.None);
            }
        }

        public override string ToString(object value)
        {
            if ((value != null) && (value is Date date))
            {
                return date.ToString(_formats[0], CultureInfo);
            }
            else
            {
                return base.ToString(value);
            }
        }
    }
}