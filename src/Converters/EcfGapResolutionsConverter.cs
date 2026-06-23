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
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="EcfGapResolution"></see> list converter to or from ECF
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
                                    var gapCancellation = new EcfLessonGapCancellation();
                                    if (jsonElement.TryGetProperty("Behaviour", out var jsonProperty2))
                                    {
                                        gapCancellation.Behaviour = Enum.Parse<EcfLessonGapCancellationBehaviour>(jsonProperty2.GetString(), true);
                                            }
                                    if (jsonElement.TryGetProperty("Description", out var jsonProperty3))
                                    {
                                        gapCancellation.Description = jsonProperty3.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Message", out var jsonProperty4))
                                    {
                                        gapCancellation.Message = jsonProperty4.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Notes", out var jsonProperty5))
                                    {
                                        gapCancellation.Notes = jsonProperty5.GetString();
                                    }
                                    gapResolutions.Add(gapCancellation);
                                }
                                else if (jsonProperty1.GetString() == "Substitution")
                                {
                                    var gapSubstitution = new EcfLessonGapSubstitution();
                                    if (jsonElement.TryGetProperty("SubstituteLessonId", out var jsonProperty2))
                                    {
                                        gapSubstitution.SubstituteLessonId = jsonProperty2.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Description", out var jsonProperty3))
                                    {
                                        gapSubstitution.Description = jsonProperty3.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Message", out var jsonProperty4))
                                    {
                                        gapSubstitution.Message = jsonProperty4.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Notes", out var jsonProperty5))
                                    {
                                        gapSubstitution.Notes = jsonProperty5.GetString();
                                    }
                                    gapResolutions.Add(gapSubstitution);
                                }
                                else if (jsonProperty1.GetString() == "SupervisionCancellation")
                                {
                                    var gapCancellation = new EcfSupervisionGapCancellation();
                                    if (jsonElement.TryGetProperty("Behaviour", out var jsonProperty2))
                                    {
                                        gapCancellation.Behaviour = Enum.Parse<EcfSupervisionGapCancellationBehaviour>(jsonProperty2.GetString(), true);
                                    }
                                    if (jsonElement.TryGetProperty("Description", out var jsonProperty3))
                                    {
                                        gapCancellation.Description = jsonProperty3.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Message", out var jsonProperty4))
                                    {
                                        gapCancellation.Message = jsonProperty4.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Notes", out var jsonProperty5))
                                    {
                                        gapCancellation.Notes = jsonProperty5.GetString();
                                    }
                                    gapResolutions.Add(gapCancellation);
                                }
                                else if (jsonProperty1.GetString() == "SupervisionSubstitution")
                                {
                                    var gapSubstitution = new EcfSupervisionGapSubstitution();
                                    if (jsonElement.TryGetProperty("SubstituteSupervisionId", out var jsonProperty2))
                                    {
                                        gapSubstitution.SubstituteSupervisionId = jsonProperty2.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Description", out var jsonProperty3))
                                    {
                                        gapSubstitution.Description = jsonProperty3.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Message", out var jsonProperty4))
                                    {
                                        gapSubstitution.Message = jsonProperty4.GetString();
                                    }
                                    if (jsonElement.TryGetProperty("Notes", out var jsonProperty5))
                                    {
                                        gapSubstitution.Notes = jsonProperty5.GetString();
                                    }
                                    gapResolutions.Add(gapSubstitution);
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
                        if (lessonGapCancellation.Description != null) jsonWriter.WriteString("Description", lessonGapCancellation.Description);
                        if (lessonGapCancellation.Message != null) jsonWriter.WriteString("Message", lessonGapCancellation.Message);
                        if (lessonGapCancellation.Notes != null) jsonWriter.WriteString("Notes", lessonGapCancellation.Notes);
                    }
                    else if (gapResolution is EcfLessonGapSubstitution lessonGapSubstitution)
                    {
                        jsonWriter.WriteString("_type", "Substitution");
                        jsonWriter.WriteString("SubstituteLessonId", lessonGapSubstitution.SubstituteLessonId.ToString());
                        if (lessonGapSubstitution.Description != null) jsonWriter.WriteString("Description", lessonGapSubstitution.Description);
                        if (lessonGapSubstitution.Message != null) jsonWriter.WriteString("Message", lessonGapSubstitution.Message);
                        if (lessonGapSubstitution.Notes != null) jsonWriter.WriteString("Notes", lessonGapSubstitution.Notes);
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