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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Ecf.XUnit
{
    public class TestEcfTableWriter
    {
        [Fact]
        public async Task TestDates()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "2022-08-08;2022-08-08T12:00:00" + Environment.NewLine +
                "2022-08-08;2022-08-08T12:00:00";

            var sb = new StringBuilder();

            using var csvStream = new StringWriter(sb);

            var ecfTableWriter = new EcfTableWriter(csvStream);

            await ecfTableWriter.WriteHeadersAsync("A", "B");

            Assert.Equal(2, ecfTableWriter.Headers.Count);

            ecfTableWriter.SetValue("A", new DateOnly(2022, 8, 8));
            ecfTableWriter.SetValue("B", new DateTime(2022, 8, 8, 12, 0, 0));

            await ecfTableWriter.WriteAsync();

            ecfTableWriter.SetValue<DateOnly?>("A", new DateOnly(2022, 8, 8));
            ecfTableWriter.SetValue<DateTime?>("B", new DateTime(2022, 8, 8, 12, 0, 0));

            await ecfTableWriter.WriteAsync();

            var s = sb.ToString();

            Assert.Equal(csvData, s);
        }

        [Fact]
        public async Task TestJsonArray()
        {
            var csvData =
                "A;B;C" + Environment.NewLine +
                "11;c1;\"[\"\"13\"\",\"\"14\"\",\"\"15\"\"]\"" + Environment.NewLine +
                "22;c2;\"[\"\"23\"\",\"\"24\"\",\"\"25\"\"]\"";

            var sb = new StringBuilder();

            using var csvStream = new StringWriter(sb);

            var ecfTableWriter = new EcfTableWriter(csvStream);

            await ecfTableWriter.WriteHeadersAsync("A", "B", "C");

            Assert.Equal(3, ecfTableWriter.Headers.Count);

            ecfTableWriter.SetValue("A", "11");
            ecfTableWriter.SetValue("B", "c1");
            ecfTableWriter.SetValue("C", new List<string>() { "13", "14", "15" });

            await ecfTableWriter.WriteAsync();

            ecfTableWriter.SetValue("A", "22");
            ecfTableWriter.SetValue("B", "c2");
            ecfTableWriter.SetValue("C", new List<string>() { "23", "24", "25" });

            await ecfTableWriter.WriteAsync();

            Assert.Equal(csvData, sb.ToString());
        }

        [Fact]
        public async Task TestLessonGapReasons()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Absence\"\",\"\"AbsenceId\"\":\"\"6cade88a-ff84-48f9-8652-d8b7e8837034\"\"}]\"" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Exam\"\",\"\"ExamId\"\":\"\"6cade88a-ff84-48f9-8652-d8b7e8837034\"\"}]\"";

            var sb = new StringBuilder();

            using var csvStream = new StringWriter(sb);

            var ecfTableWriter = new EcfTableWriter(csvStream);

            await ecfTableWriter.WriteHeadersAsync("A", "B");

            Assert.Equal(2, ecfTableWriter.Headers.Count);

            ecfTableWriter.SetValue("A", "Text");
            ecfTableWriter.SetValue("B", new List<EcfGapReason>() { new EcfAbsenceGapReason() { AbsenceId = "6cade88a-ff84-48f9-8652-d8b7e8837034" } });

            await ecfTableWriter.WriteAsync();

            ecfTableWriter.SetValue("A", "Text");
            ecfTableWriter.SetValue("B", new List<EcfGapReason>() { new EcfExamGapReason() { ExamId = "6cade88a-ff84-48f9-8652-d8b7e8837034" } });

            await ecfTableWriter.WriteAsync();

            var s = sb.ToString();

            Assert.Equal(csvData, s);
        }

        [Fact]
        public async Task TestLessonGapResolutions()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Cancellation\"\",\"\"Behaviour\"\":\"\"None\"\"}]\"" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Substitution\"\",\"\"SubstituteLessonId\"\":\"\"6cade88a-ff84-48f9-8652-d8b7e8837034\"\"}]\"";

            var sb = new StringBuilder();

            using var csvStream = new StringWriter(sb);

            var ecfTableWriter = new EcfTableWriter(csvStream);

            await ecfTableWriter.WriteHeadersAsync("A", "B");

            Assert.Equal(2, ecfTableWriter.Headers.Count);

            ecfTableWriter.SetValue("A", "Text");
            ecfTableWriter.SetValue("B", new List<EcfGapResolution>() { new EcfLessonGapCancellation() { Behaviour = EcfLessonGapCancellationBehaviour.None } });

            await ecfTableWriter.WriteAsync();

            ecfTableWriter.SetValue("A", "Text");
            ecfTableWriter.SetValue("B", new List<EcfGapResolution>() { new EcfLessonGapSubstitution() { SubstituteLessonId = "6cade88a-ff84-48f9-8652-d8b7e8837034" } });

            await ecfTableWriter.WriteAsync();

            var s = sb.ToString();

            Assert.Equal(csvData, s);
        }
        [Fact]
        public async Task TestTemporalExpressions()
        {
            var csvData =
                "A;B" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"OneTime\"\",\"\"Operation\"\":\"\"Include\"\",\"\"StartTimepoint\"\":\"\"2020-08-17T07:45:00+02:00\"\",\"\"EndTimepoint\"\":\"\"2020-08-17T09:15:00+02:00\"\"}]\"" + Environment.NewLine +
                "Text;\"[{\"\"_type\"\":\"\"Weekly\"\",\"\"Operation\"\":\"\"Include\"\",\"\"StartTimepoint\"\":\"\"1899-12-30T13:45:00+01:00\"\",\"\"EndTimepoint\"\":\"\"1899-12-30T15:15:00+01:00\"\",\"\"ValidFrom\"\":\"\"2020-08-17T00:00:00+01:00\"\",\"\"ValidTo\"\":\"\"2021-01-31T00:00:00+01:00\"\"}]\"";

            var sb = new StringBuilder();

            using var csvStream = new StringWriter(sb);

            var ecfTableWriter = new EcfTableWriter(csvStream);

            await ecfTableWriter.WriteHeadersAsync("A", "B");

            Assert.Equal(2, ecfTableWriter.Headers.Count);

            ecfTableWriter.SetValue("A", "Text");
            ecfTableWriter.SetValue("B", new List<EcfTemporalExpression>() { new EcfOneTimeExpression()
                {
                    StartTimepoint = new DateTimeOffset(2020, 8, 17, 7, 45, 0, new TimeSpan(2, 0, 0)),
                    EndTimepoint = new DateTimeOffset(2020, 8, 17, 9, 15, 0, new TimeSpan(2, 0, 0))
                }});

            await ecfTableWriter.WriteAsync();

            ecfTableWriter.SetValue("A", "Text");
            ecfTableWriter.SetValue("B", new List<EcfTemporalExpression>() { new EcfWeeklyTimePeriodExpression()
                {
                    StartTimepoint = new DateTimeOffset(1899, 12, 30, 13, 45, 0, new TimeSpan(1, 0, 0)),
                    EndTimepoint = new DateTimeOffset(1899, 12, 30, 15, 15, 0, new TimeSpan(1, 0, 0)),
                    ValidFrom = new DateTimeOffset(2020, 8, 17, 0, 0, 0, new TimeSpan(1, 0, 0)),
                    ValidTo = new DateTimeOffset(2021, 1, 31, 0, 0, 0, new TimeSpan(1, 0, 0)),
                }});

            await ecfTableWriter.WriteAsync();

            var s = sb.ToString();

            Assert.Equal(csvData, s);
        }
    }
}
