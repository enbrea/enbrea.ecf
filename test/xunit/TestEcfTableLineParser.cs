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

using System;
using Xunit;

namespace Enbrea.Ecf.XUnit
{
    public class TestEcfTableLineParser
    {
        [Fact]
        public void TestDateTimeOffsetValues()
        {
            var csvHeaders = "A;B;C";
            var csvValues = "2020-12-18;2020-12-18T12:21:00+01:00;2020-12-18T12:21:07.000+01:00";

            var ecfLineParser = new EcfTableLineParser();

            Assert.NotNull(ecfLineParser);

            ecfLineParser.ParseHeaders(csvHeaders);
            Assert.Equal(3, ecfLineParser.Headers.Count);

            ecfLineParser.Parse(csvValues);
            Assert.Equal(new DateTimeOffset(new DateTime(2020, 12, 18)), ecfLineParser.GetValue<DateTimeOffset>("A"));
            Assert.Equal(new DateTimeOffset(2020, 12, 18, 12, 21, 0, new TimeSpan(1, 0, 0)), ecfLineParser.GetValue<DateTimeOffset>("B"));
            Assert.Equal(new DateTimeOffset(2020, 12, 18, 12, 21, 7, new TimeSpan(1, 0, 0)), ecfLineParser.GetValue<DateTimeOffset>("C"));
        }
    }
}
