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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="EcfTimeSlot"></see> list converter to or from ECF
    /// </summary>
    public class EcfTimeSlotsConverter : ICsvConverter
    {
        private readonly string[] _dateTimeOffsetFormats =
        {
            "yyyy-MM-dd'T'HH:mm:ss.FFFK",
            "yyyy-MM-dd'T'HH:mm.FFFK",
            "yyyy-MM-dd"
        };

        public virtual object FromString(string value)
        {
            var timeSlots = new List<EcfTimeSlot>();

            if (!string.IsNullOrEmpty(value))
            {
                var jsonDocument = JsonDocument.Parse(value);

                JsonElement jsonInputRoot = jsonDocument.RootElement;

                if (jsonInputRoot.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement jsonElement in jsonInputRoot.EnumerateArray())
                    {
                        if (jsonElement.ValueKind == JsonValueKind.Object)
                        {
                            var timeSlot = new EcfTimeSlot();

                            if (jsonElement.TryGetProperty("Label", out var jsonProperty1))
                            {
                                timeSlot.Label = jsonProperty1.GetString();
                            }
                            if (jsonElement.TryGetProperty("Color", out var jsonProperty2))
                            {
                                timeSlot.Color = jsonProperty2.GetString();
                            }
                            if (jsonElement.TryGetProperty("StartTime", out var jsonProperty3))
                            {
                                timeSlot.StartTime = DateTimeOffset.ParseExact(jsonProperty3.GetString(), _dateTimeOffsetFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                            }
                            if (jsonElement.TryGetProperty("EndTime", out var jsonProperty4))
                            {
                                timeSlot.EndTime = DateTimeOffset.ParseExact(jsonProperty4.GetString(), _dateTimeOffsetFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                            }

                            timeSlots.Add(timeSlot);
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Value must be a JSON array. Instead it is {jsonInputRoot.ValueKind}.");
                }
            }
            return timeSlots;
        }

        public string ToString(object value)
        {
            var jsonStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(jsonStream, new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

            jsonWriter.WriteStartArray();

            if (value is List<EcfTimeSlot> timeSlots)
            {
                foreach (var timeSlot in timeSlots)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WriteString("Label", timeSlot.Label);
                    jsonWriter.WriteString("Color", timeSlot.Color);
                    jsonWriter.WriteString("StartTime", timeSlot.StartTime.ToString(_dateTimeOffsetFormats[0], CultureInfo.InvariantCulture));
                    jsonWriter.WriteString("EndTime", timeSlot.EndTime.ToString(_dateTimeOffsetFormats[0], CultureInfo.InvariantCulture));
                    jsonWriter.WriteEndObject();
                }
            }
            
            jsonWriter.WriteEndArray();
            jsonWriter.Flush();

            return Encoding.UTF8.GetString(jsonStream.ToArray());

        }
    }
}