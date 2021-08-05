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
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Default implementation of an <see cref="ICsvConverterResolver"/>
    /// </summary>
    public class EcfConverterResolver : CsvDefaultConverterResolver
    {
        protected override void RegisterDefaultConverters()
        {
            AddConverter(typeof(bool), new CsvBooleanConverter());
            AddConverter(typeof(bool?), new CsvBooleanConverter());
            AddConverter(typeof(byte), new CsvByteConverter());
            AddConverter(typeof(byte?), new CsvByteConverter());
            AddConverter(typeof(char), new CsvCharConverter());
            AddConverter(typeof(char?), new CsvCharConverter());
            AddConverter(typeof(Color), new EcfColorConverter());
            AddConverter(typeof(Color?),new EcfColorConverter());
            AddConverter(typeof(Date), new EcfDateConverter());
            AddConverter(typeof(Date?), new EcfDateConverter());
            AddConverter(typeof(DateTime), new EcfDateTimeConverter());
            AddConverter(typeof(DateTime?), new EcfDateTimeConverter());
            AddConverter(typeof(DateTimeOffset), new EcfDateTimeOffsetConverter());
            AddConverter(typeof(DateTimeOffset?), new EcfDateTimeOffsetConverter());
            AddConverter(typeof(decimal), new CsvDecimalConverter());
            AddConverter(typeof(decimal?), new CsvDecimalConverter());
            AddConverter(typeof(double), new CsvDoubleConverter());
            AddConverter(typeof(double?), new CsvDoubleConverter());
            AddConverter(typeof(EcfGender), new EcfGenderConverter());
            AddConverter(typeof(EcfGender?), new EcfGenderConverter());
            AddConverter(typeof(Guid), new CsvGuidConverter());
            AddConverter(typeof(Guid?), new CsvGuidConverter());
            AddConverter(typeof(int), new CsvInt32Converter());
            AddConverter(typeof(int?), new CsvInt32Converter());
            AddConverter(typeof(List<EcfGapReason>), new EcfGapReasonsConverter());
            AddConverter(typeof(List<EcfGapResolution>), new EcfGapResolutionsConverter());
            AddConverter(typeof(List<EcfTemporalExpression>), new EcfTemporalExpressionsConverter());
            AddConverter(typeof(List<EcfTimeSlot>), new EcfTimeSlotsConverter());
            AddConverter(typeof(List<Guid>), new EcfListConverter<Guid>());
            AddConverter(typeof(List<string>), new EcfListConverter<string>());
            AddConverter(typeof(long), new CsvInt64Converter());
            AddConverter(typeof(long?), new CsvInt64Converter());
            AddConverter(typeof(sbyte), new CsvSByteConverter());
            AddConverter(typeof(sbyte?), new CsvSByteConverter());
            AddConverter(typeof(short), new CsvInt16Converter());
            AddConverter(typeof(short?), new CsvInt16Converter());
            AddConverter(typeof(string), new CsvStringConverter());
            AddConverter(typeof(TimeSpan), new CsvTimeSpanConverter());
            AddConverter(typeof(TimeSpan?), new CsvTimeSpanConverter());
            AddConverter(typeof(uint), new CsvUInt32Converter());
            AddConverter(typeof(uint), new CsvUInt32Converter());
            AddConverter(typeof(ulong), new CsvUInt64Converter());
            AddConverter(typeof(ulong), new CsvUInt64Converter());
            AddConverter(typeof(Uri), new CsvUriConverter());
            AddConverter(typeof(ushort), new CsvUInt16Converter());
            AddConverter(typeof(ushort?), new CsvUInt16Converter());
        }
    }
}