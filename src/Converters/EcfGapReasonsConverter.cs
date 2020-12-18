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
    /// Implementation of a <see cref="EcfGapReason"></see> list converter to or from CSV
    /// </summary>
    public class EcfGapReasonsConverter : ICsvConverter
    {
        public virtual object FromString(string value)
        {
            var gapReasons = new List<EcfGapReason>();

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
                                if (jsonProperty1.GetString() == "Absence")
                                {
                                    if (jsonElement.TryGetProperty("AbsenceId", out var jsonProperty2))
                                    {
                                        gapReasons.Add(new EcfAbsenceGapReason() { AbsenceId = jsonProperty2.GetString() });
                                    }
                                }
                                else if (jsonProperty1.GetString() == "Exam")
                                {
                                    if (jsonElement.TryGetProperty("ExamId", out var jsonProperty2))
                                    {
                                        gapReasons.Add(new EcfExamGapReason() { ExamId = jsonProperty2.GetString() });
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
            return gapReasons;
        }

        public string ToString(object value)
        {
            var jsonStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(jsonStream, new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

            jsonWriter.WriteStartArray();

            if (value is List<EcfGapReason> gapGapReasons)
            {
                foreach (var gapGapReason in gapGapReasons)
                {
                    jsonWriter.WriteStartObject();
                    if (gapGapReason is EcfAbsenceGapReason absenceGapReason)
                    {
                        jsonWriter.WriteString("_type", "Absence");
                        jsonWriter.WriteString("AbsenceId", absenceGapReason.AbsenceId.ToString());
                    }
                    else if (gapGapReason is EcfExamGapReason examGapReason)
                    {
                        jsonWriter.WriteString("_type", "Exam");
                        jsonWriter.WriteString("ExamId", examGapReason.ExamId.ToString());
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