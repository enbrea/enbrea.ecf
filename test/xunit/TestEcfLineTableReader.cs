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
using Enbrea.Ecf;
using System;
using Xunit;

namespace Ecf.Enbrea.XUnit
{
    public class TestEcfLineTableReader
    {
        [Fact]
        public void TestDateTimeOffsetValues()
        {
            var csvHeaders = "A;B;C";
            var csvValues = "2020-12-18;2020-12-18T12:21:00+01:00;2020-12-18T12:21:07.000+01:00";

            var csvLineParser = new CsvLineParser(';');

            var ecfLineTableReader = new EcfLineTableReader(csvLineParser);

            Assert.NotNull(ecfLineTableReader);

            ecfLineTableReader.ReadHeaders(csvHeaders);
            Assert.Equal(3, ecfLineTableReader.Headers.Count);

            ecfLineTableReader.Read(csvValues);
            Assert.Equal(new DateTimeOffset(new DateTime(2020, 12, 18)), ecfLineTableReader.GetValue<DateTimeOffset>("A"));
            Assert.Equal(new DateTimeOffset(2020, 12, 18, 12, 21, 0, new TimeSpan(1, 0, 0)), ecfLineTableReader.GetValue<DateTimeOffset>("B"));
            Assert.Equal(new DateTimeOffset(2020, 12, 18, 12, 21, 7, new TimeSpan(1, 0, 0)), ecfLineTableReader.GetValue<DateTimeOffset>("C"));
        }
    }
}
