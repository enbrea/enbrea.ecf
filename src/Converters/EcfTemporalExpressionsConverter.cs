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
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="EcfTemporalExpression"></see> list converter to or from CSV
    /// </summary>
    public class EcfTemporalExpressionsConverter : ICsvConverter
    {
        private readonly string[] _dateFormats =
        {
            "yyyy-MM-dd"
        };

        private readonly string[] _dateTimeOffsetFormats =
        {
            "yyyy-MM-dd'T'HH:mm:ss.FFFK",
            "yyyy-MM-dd'T'HH:mm.FFFK",
            "yyyy-MM-dd"
        };

        public object FromString(string value)
        {
            var temporalExpressions = new List<EcfTemporalExpression>();

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
                                if (jsonProperty1.GetString() == "OneTime")
                                {
                                    var oneTimeExpression = new EcfOneTimeExpression();

                                    if (jsonElement.TryGetProperty("Operation", out var jsonProperty2))
                                    {
                                        oneTimeExpression.Operation = (EcfTemporalExpressionOperation)Enum.Parse(typeof(EcfTemporalExpressionOperation), jsonProperty2.GetString(), true);
                                    }
                                    if (jsonElement.TryGetProperty("StartTimepoint", out var jsonProperty3))
                                    {
                                        oneTimeExpression.StartTimepoint = DateTimeOffset.ParseExact(jsonProperty3.GetString(), _dateTimeOffsetFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    if (jsonElement.TryGetProperty("EndTimepoint", out var jsonProperty4))
                                    {
                                        oneTimeExpression.EndTimepoint = DateTimeOffset.ParseExact(jsonProperty4.GetString(), _dateTimeOffsetFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    
                                    temporalExpressions.Add(oneTimeExpression);
                                }
                                else if (jsonProperty1.GetString() == "Weekly")
                                {
                                    var weeklyExpression = new EcfWeeklyTimePeriodExpression();

                                    if (jsonElement.TryGetProperty("Operation", out var jsonProperty2))
                                    {
                                        weeklyExpression.Operation = (EcfTemporalExpressionOperation)Enum.Parse(typeof(EcfTemporalExpressionOperation), jsonProperty2.GetString(), true);
                                    }
                                    if (jsonElement.TryGetProperty("StartTimepoint", out var jsonProperty3))
                                    {
                                        weeklyExpression.StartTimepoint = DateTimeOffset.ParseExact(jsonProperty3.GetString(), _dateTimeOffsetFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    if (jsonElement.TryGetProperty("EndTimepoint", out var jsonProperty4))
                                    {
                                        weeklyExpression.EndTimepoint = DateTimeOffset.ParseExact(jsonProperty4.GetString(), _dateTimeOffsetFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    if (jsonElement.TryGetProperty("ValidFrom", out var jsonProperty5))
                                    {
                                        weeklyExpression.ValidFrom = Date.ParseExact(jsonProperty5.GetString(), _dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    if (jsonElement.TryGetProperty("ValidTo", out var jsonProperty6))
                                    {
                                        weeklyExpression.ValidTo = Date.ParseExact(jsonProperty6.GetString(), _dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    if (jsonElement.TryGetProperty("DaysOfWeek", out var jsonProperty7))
                                    {
                                        weeklyExpression.DaysOfWeek = (EcfDayOfWeekSet)Enum.Parse(typeof(EcfDayOfWeekSet), jsonProperty7.GetString(), true);
                                    }
                                    if (jsonElement.TryGetProperty("WeeksInterval", out var jsonProperty8))
                                    {
                                        weeklyExpression.WeeksInterval = uint.Parse(jsonProperty8.GetString());
                                    }

                                    temporalExpressions.Add(weeklyExpression);
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
            return temporalExpressions;
        }

        public string ToString(object value)
        {
            var jsonStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(jsonStream, new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping } );

            jsonWriter.WriteStartArray();

            if (value is List<EcfTemporalExpression> temporalExpressions)
            {
                foreach (var temporalExpression in temporalExpressions)
                {
                    jsonWriter.WriteStartObject();
                    if (temporalExpression is EcfOneTimeExpression oneTimeExpression)
                    {
                        jsonWriter.WriteString("_type", "OneTime");
                        jsonWriter.WriteString("Operation", oneTimeExpression.Operation.ToString());
                        jsonWriter.WriteString("StartTimepoint", oneTimeExpression.StartTimepoint.ToString(_dateTimeOffsetFormats[0], CultureInfo.InvariantCulture));
                        jsonWriter.WriteString("EndTimepoint", oneTimeExpression.EndTimepoint.ToString(_dateTimeOffsetFormats[0], CultureInfo.InvariantCulture));
                    }
                    else if (temporalExpression is EcfWeeklyTimePeriodExpression weeklyExpression)
                    {
                        jsonWriter.WriteString("_type", "Weekly");
                        jsonWriter.WriteString("Operation", weeklyExpression.Operation.ToString());
                        jsonWriter.WriteString("StartTimepoint", weeklyExpression.StartTimepoint.ToString(_dateTimeOffsetFormats[0], CultureInfo.InvariantCulture));
                        jsonWriter.WriteString("EndTimepoint", weeklyExpression.EndTimepoint.ToString(_dateTimeOffsetFormats[0], CultureInfo.InvariantCulture));
                        jsonWriter.WriteString("DaysOfWeek", weeklyExpression.DaysOfWeek.ToString());
                        jsonWriter.WriteNumber("WeeksInterval", weeklyExpression.WeeksInterval);
                        if (weeklyExpression.ValidFrom != null) jsonWriter.WriteString("ValidFrom", weeklyExpression.ValidFrom?.ToString(_dateFormats[0], CultureInfo.InvariantCulture));
                        if (weeklyExpression.ValidTo != null) jsonWriter.WriteString("ValidTo", weeklyExpression.ValidTo?.ToString(_dateFormats[0], CultureInfo.InvariantCulture));
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