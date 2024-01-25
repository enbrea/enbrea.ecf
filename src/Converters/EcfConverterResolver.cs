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
using System.Drawing;

namespace Enbrea.Ecf
{
    /// <summary>
    /// ECF implementation of an <see cref="ICsvConverterResolver"/>
    /// </summary>
    public class EcfConverterResolver : CsvDefaultConverterResolver
    {
        protected override void RegisterDefaultConverters()
        {
            AddConverter(typeof(bool), new CsvBooleanConverter());
            AddConverter(typeof(byte), new CsvByteConverter());
            AddConverter(typeof(char), new CsvCharConverter());
            AddConverter(typeof(Color), new EcfColorConverter());
            AddConverter(typeof(DateOnly), new EcfDateOnlyConverter());
            AddConverter(typeof(DateTime), new EcfDateTimeConverter());
            AddConverter(typeof(DateTimeOffset), new EcfDateTimeOffsetConverter());
            AddConverter(typeof(decimal), new CsvDecimalConverter());
            AddConverter(typeof(double), new CsvDoubleConverter());
            AddConverter(typeof(EcfGender), new EcfGenderConverter());
            AddConverter(typeof(EcfHolidayType), new EcfHolidayTypeConverter());
            AddConverter(typeof(EcfStudentStatus), new EcfStudentStatusConverter());
            AddConverter(typeof(Guid), new CsvGuidConverter());
            AddConverter(typeof(int), new CsvInt32Converter());
            AddConverter(typeof(List<EcfGapReason>), new EcfGapReasonsConverter());
            AddConverter(typeof(List<EcfGapResolution>), new EcfGapResolutionsConverter());
            AddConverter(typeof(List<EcfTemporalExpression>), new EcfTemporalExpressionsConverter());
            AddConverter(typeof(List<EcfTimeSlot>), new EcfTimeSlotsConverter());
            AddConverter(typeof(List<Guid>), new EcfListConverter<Guid>());
            AddConverter(typeof(List<string>), new EcfListConverter<string>());
            AddConverter(typeof(long), new CsvInt64Converter());
            AddConverter(typeof(sbyte), new CsvSByteConverter());
            AddConverter(typeof(short), new CsvInt16Converter());
            AddConverter(typeof(string), new CsvStringConverter());
            AddConverter(typeof(TimeOnly), new EcfTimeOnlyConverter());
            AddConverter(typeof(TimeSpan), new CsvTimeSpanConverter());
            AddConverter(typeof(uint), new CsvUInt32Converter());
            AddConverter(typeof(ulong), new CsvUInt64Converter());
            AddConverter(typeof(Uri), new CsvUriConverter());
            AddConverter(typeof(ushort), new CsvUInt16Converter());
        }
    }
}