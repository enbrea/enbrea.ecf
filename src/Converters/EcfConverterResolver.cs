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
            AddConverter<bool?>(new CsvBooleanConverter());
            AddConverter<bool>(new CsvBooleanConverter());
            AddConverter<byte?>(new CsvByteConverter());
            AddConverter<byte>(new CsvByteConverter());
            AddConverter<char?>(new CsvCharConverter());
            AddConverter<char>(new CsvCharConverter());
            AddConverter<Color?>(new EcfColorConverter());
            AddConverter<Color>(new EcfColorConverter());
            AddConverter<Date?>(new EcfDateConverter());
            AddConverter<Date>(new EcfDateConverter());
            AddConverter<DateTime?>(new EcfDateTimeConverter());
            AddConverter<DateTime>(new EcfDateTimeConverter());
            AddConverter<DateTimeOffset?>(new EcfDateTimeOffsetConverter());
            AddConverter<DateTimeOffset>(new EcfDateTimeOffsetConverter());
            AddConverter<decimal?>(new CsvDecimalConverter());
            AddConverter<decimal>(new CsvDecimalConverter());
            AddConverter<double?>(new CsvDoubleConverter());
            AddConverter<double>(new CsvDoubleConverter());
            AddConverter<EcfGender?>(new EcfGenderConverter());
            AddConverter<EcfGender>(new EcfGenderConverter());
            AddConverter<Guid?>(new CsvGuidConverter());
            AddConverter<Guid>(new CsvGuidConverter());
            AddConverter<int?>(new CsvInt32Converter());
            AddConverter<int>(new CsvInt32Converter());
            AddConverter<List<EcfGapReason>>(new EcfGapReasonsConverter());
            AddConverter<List<EcfGapResolution>>(new EcfGapResolutionsConverter());
            AddConverter<List<EcfTemporalExpression>>(new EcfTemporalExpressionsConverter());
            AddConverter<List<EcfTimeSlot>>(new EcfTimeSlotsConverter());
            AddConverter<List<Guid>>(new EcfListConverter<Guid>());
            AddConverter<List<string>>(new EcfListConverter<string>());
            AddConverter<long?>(new CsvInt64Converter());
            AddConverter<long>(new CsvInt64Converter());
            AddConverter<sbyte?>(new CsvSByteConverter());
            AddConverter<sbyte>(new CsvSByteConverter());
            AddConverter<short?>(new CsvInt16Converter());
            AddConverter<short>(new CsvInt16Converter());
            AddConverter<string>(new CsvStringConverter());
            AddConverter<TimeSpan?>(new CsvTimeSpanConverter());
            AddConverter<TimeSpan>(new CsvTimeSpanConverter());
            AddConverter<uint?>(new CsvUInt32Converter());
            AddConverter<uint>(new CsvUInt32Converter());
            AddConverter<ulong?>(new CsvUInt64Converter());
            AddConverter<ulong>(new CsvUInt64Converter());
            AddConverter<Uri>(new CsvUriConverter());
            AddConverter<ushort?>(new CsvUInt16Converter());
            AddConverter<ushort>(new CsvUInt16Converter());
        }
    }
}