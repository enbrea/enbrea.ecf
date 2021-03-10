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
using System.Drawing;
using System.Globalization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="Color"> converter to or from CSV
    /// </summary>
    public class EcfColorConverter : CsvDefaultFormattableConverter
    {
        public EcfColorConverter() : base(typeof(Color))
        {
        }

        public EcfColorConverter(CultureInfo cultureInfo, string[] formats)
            : base(typeof(Color), cultureInfo, formats)
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
                return Color.FromName(value);
            }
        }
    }
}