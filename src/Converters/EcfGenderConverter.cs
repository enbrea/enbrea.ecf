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
using System.Globalization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="EcfGender"></see> converter to or from CSV
    /// </summary>
    public class EcfGenderConverter : CsvDefaultEnumConverter
    {
        public EcfGenderConverter() : 
            base(typeof(EcfGender), CultureInfo.InvariantCulture, null, true)
        {
        }
    }
}