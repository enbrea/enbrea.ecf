#region ENBREA.ECF - Copyright (c) ST�BER SYSTEMS GmbH
/*    
 *    ENBREA.ECF 
 *    
 *    Copyright (c) ST�BER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Ecf.XUnit
{
    public class TestEcfTableReader
    {
        [Fact]
        public async Task TestDateTimeOffsetValues()
        {
            var csvData =
                "A;B;C" + Environment.NewLine +
                "2020-12-18;2020-12-18T12:21:00+01:00;2020-12-18T12:21:07.000+01:00";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(3, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
            Assert.Equal(new DateTimeOffset(new DateTime(2020, 12, 18)), ecfTableReader.GetValue<DateTimeOffset>("A"));
            Assert.Equal(new DateTimeOffset(2020, 12, 18, 12, 21, 0, new TimeSpan(1, 0, 0)), ecfTableReader.GetValue<DateTimeOffset>("B"));
            Assert.Equal(new DateTimeOffset(2020, 12, 18, 12, 21, 7, new TimeSpan(1, 0, 0)), ecfTableReader.GetValue<DateTimeOffset>("C"));
        }

        [Fact]
        public async Task TestDateTimeValues()
        {
            var csvData =
                "A;B;C" + Environment.NewLine +
                "2020-12-18;2020-12-18T12:21;2020-12-18T12:21:07";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(3, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
            Assert.Equal(new DateTime(2020, 12, 18, 0, 0, 0), ecfTableReader.GetValue<DateTime>("A"));
            Assert.Equal(new DateTime(2020, 12, 18, 12, 21, 0), ecfTableReader.GetValue<DateTime>("B"));
            Assert.Equal(new DateTime(2020, 12, 18, 12, 21, 7), ecfTableReader.GetValue<DateTime>("C"));
        }

        [Fact]
        public async Task TestDateValues()
        {
            var csvData =
                "A;B;C" + Environment.NewLine +
                "2020-01-01;2020-12-18;2020-12-31";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(3, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
#if NET6_0_OR_GREATER
            Assert.Equal(new DateOnly(2020, 01, 01), ecfTableReader.GetValue<DateOnly>("A"));
            Assert.Equal(new DateOnly(2020, 12, 18), ecfTableReader.GetValue<DateOnly>("B"));
            Assert.Equal(new DateOnly(2020, 12, 31), ecfTableReader.GetValue<DateOnly>("C"));
#else
            Assert.Equal(new Date(2020, 01, 01), ecfTableReader.GetValue<Date>("A"));
            Assert.Equal(new Date(2020, 12, 18), ecfTableReader.GetValue<Date>("B"));
            Assert.Equal(new Date(2020, 12, 31), ecfTableReader.GetValue<Date>("C"));
#endif
        }

        [Fact]
        public async Task TestJsonArray()
        {
            var csvData =
                "A;B;C" + Environment.NewLine +
                "11;c1;\"[\"\"13\"\",\"\"14\"\",\"\"15\"\"]\"" + Environment.NewLine +
                "22;c2;\"[\"\"23\"\",\"\"24\"\",\"\"25\"\"]\"" + Environment.NewLine +
                "33;c3;";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(3, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
            Assert.Equal("11", ecfTableReader.GetValue<string>("A"));
            Assert.Equal("c1", ecfTableReader.GetValue<string>("B"));
            Assert.Equal(new List<string>() { "13", "14", "15" }, ecfTableReader.GetValue<List<string>>("C"));

            await ecfTableReader.ReadAsync();
            Assert.Equal("22", ecfTableReader.GetValue<string>("A"));
            Assert.Equal("c2", ecfTableReader.GetValue<string>("B"));
            Assert.Equal(new List<string>() { "23", "24", "25" }, ecfTableReader.GetValue<List<string>>("C"));

            await ecfTableReader.ReadAsync();
            Assert.Equal("33", ecfTableReader.GetValue<string>("A"));
            Assert.Equal("c3", ecfTableReader.GetValue<string>("B"));
            Assert.Equal(new List<string>(), ecfTableReader.GetValue<List<string>>("C"));
        }

        [Fact]
        public async Task TestLessonGapReasons()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Absence\"\",\"\"AbsenceId\"\":\"\"6cade88a-ff84-48f9-8652-d8b7e8837034\"\"}]\"" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Exam\"\",\"\"ExamId\"\":\"\"6cade88a-ff84-48f9-8652-d8b7e8837034\"\"}]\"";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(2, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
            Assert.Equal("Text", ecfTableReader.GetValue<string>("A"));
            Assert.Single(ecfTableReader.GetValue<List<EcfGapReason>>("B"));
            Assert.Equal(new EcfAbsenceGapReason() { AbsenceId = "6cade88a-ff84-48f9-8652-d8b7e8837034" }, ecfTableReader.GetValue<List<EcfGapReason>>("B")[0]);

            await ecfTableReader.ReadAsync();
            Assert.Equal("Text", ecfTableReader.GetValue<string>("A"));
            Assert.Single(ecfTableReader.GetValue<List<EcfGapReason>>("B"));
            Assert.Equal(new EcfExamGapReason() { ExamId = "6cade88a-ff84-48f9-8652-d8b7e8837034" }, ecfTableReader.GetValue<List<EcfGapReason>>("B")[0]);
        }

        [Fact]
        public async Task TestLessonGapResolutions()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Cancellation\"\",\"\"Behaviour\"\":\"\"None\"\"}]\"" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Substitution\"\",\"\"SubstituteLessonId\"\":\"\"6cade88a-ff84-48f9-8652-d8b7e8837034\"\"}]\"";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(2, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
            Assert.Equal("Text", ecfTableReader.GetValue<string>("A"));
            Assert.Single(ecfTableReader.GetValue<List<EcfGapResolution>>("B"));
            Assert.Equal(new EcfLessonGapCancellation() { Behaviour = EcfLessonGapCancellationBehaviour.None }, ecfTableReader.GetValue<List<EcfGapResolution>>("B")[0]);

            await ecfTableReader.ReadAsync();
            Assert.Equal("Text", ecfTableReader.GetValue<string>("A"));
            Assert.Single(ecfTableReader.GetValue<List<EcfGapResolution>>("B"));
            Assert.Equal(new EcfLessonGapSubstitution() { SubstituteLessonId = "6cade88a-ff84-48f9-8652-d8b7e8837034" }, ecfTableReader.GetValue<List<EcfGapResolution>>("B")[0]);
        }

        [Fact]
        public async Task TestTemporalExpressions()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"OneTime\"\",\"\"Operation\"\":\"\"Include\"\",\"\"StartTimepoint\"\":\"\"2020-08-17T07:45:00+02:00\"\",\"\"EndTimepoint\"\":\"\"2020-08-17T09:15:00+02:00\"\"}]\"" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Weekly\"\",\"\"Operation\"\":\"\"Include\"\",\"\"StartTimepoint\"\":\"\"1899-12-30T13:45:00+01:00\"\",\"\"EndTimepoint\"\":\"\"1899-12-30T15:15:00+01:00\"\",\"\"DaysOfWeek\"\":\"\"Friday\"\",\"\"WeeksInterval\"\":1,\"\"ValidFrom\"\":\"\"2020-08-17\"\",\"\"ValidTo\"\":\"\"2021-01-31\"\"}]\"";

            using var csvStream = new StringReader(csvData);

            var ecfTableReader = new EcfTableReader(csvStream);

            Assert.NotNull(ecfTableReader);

            await ecfTableReader.ReadHeadersAsync();
            Assert.Equal(2, ecfTableReader.Headers.Count);

            await ecfTableReader.ReadAsync();
            Assert.Equal("Text", ecfTableReader.GetValue<string>("A"));
            Assert.Single(ecfTableReader.GetValue<List<EcfTemporalExpression>>("B"));

            await ecfTableReader.ReadAsync();
            Assert.Equal("Text", ecfTableReader.GetValue<string>("A"));
            Assert.Single(ecfTableReader.GetValue<List<EcfTemporalExpression>>("B"));
        }
    }
}
