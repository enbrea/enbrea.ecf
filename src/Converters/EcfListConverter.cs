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
using System.Collections.Generic;
using System.Text.Json;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a generic list converter to or from CSV
    /// </summary>
    public class EcfListConverter<T> : ICsvConverter
    {
        public virtual object FromString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new List<T>();
            }
            else 
            {
                return JsonSerializer.Deserialize<List<T>>(value);
            }
        }

        public string ToString(object value)
        {
            if (value is List<T> objectValue)
            {
                return JsonSerializer.Serialize(objectValue, new JsonSerializerOptions { WriteIndented = false });
            }
            else
            {
                return string.Empty;
            }
        }
    }
}