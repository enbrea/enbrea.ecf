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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="EcfGapResolution"></see> list converter to or from CSV
    /// </summary>
    public class EcfGapResolutionsConverter : ICsvConverter
    {
        public virtual object FromString(string value)
        {
            var gapResolutions = new List<EcfGapResolution>();

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
                            if (jsonElement.TryGetProperty("_type", out var jsonProperty1))
                            {
                                if (jsonProperty1.GetString() == "Cancellation")
                                {
                                    if (jsonElement.TryGetProperty("Behaviour", out var jsonProperty2))
                                    {
                                        gapResolutions.Add(new EcfLessonGapCancellation() { Behaviour = (EcfLessonGapCancellationBehaviour)Enum.Parse(typeof(EcfLessonGapCancellationBehaviour), jsonProperty2.GetString(), true) });
                                    }
                                }
                                else if (jsonProperty1.GetString() == "Substitution")
                                {
                                    if (jsonElement.TryGetProperty("SubstituteLessonId", out var jsonProperty2))
                                    {
                                        gapResolutions.Add(new EcfLessonGapSubstitution() { SubstituteLessonId = jsonProperty2.GetString() });
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Value must be a JSON array. Instead it is {jsonInputRoot.ValueKind}.");
                } 
            }
            return gapResolutions;
        }

        public string ToString(object value)
        {
            var jsonStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(jsonStream, new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

            jsonWriter.WriteStartArray();

            if (value is List<EcfGapResolution> gapResolutions)
            {
                foreach (var gapResolution in gapResolutions)
                {
                    jsonWriter.WriteStartObject();
                    if (gapResolution is EcfLessonGapCancellation lessonGapCancellation)
                    {
                        jsonWriter.WriteString("_type", "Cancellation");
                        jsonWriter.WriteString("Behaviour", lessonGapCancellation.Behaviour.ToString());
                    }
                    else if (gapResolution is EcfLessonGapSubstitution lessonGapResolution)
                    {
                        jsonWriter.WriteString("_type", "Substitution");
                        jsonWriter.WriteString("SubstituteLessonId", lessonGapResolution.SubstituteLessonId.ToString());
                    }
                    jsonWriter.WriteEndObject();
                }
            }
            
            jsonWriter.WriteEndArray();
            jsonWriter.Flush();

            return Encoding.UTF8.GetString(jsonStream.ToArray());

        }
    }
}