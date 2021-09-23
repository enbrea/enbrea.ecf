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
using System.Collections.Generic;
using Xunit;

namespace Ecf.Enbrea.XUnit
{
    public class TestEcfLineTableWriter
    {
        [Fact]
        public void TestJsonArray()
        {
            var csvValues = "11;c1;\"[\"\"13\"\",\"\"14\"\",\"\"15\"\"]\"";

            var csvLineBuilder = new CsvLineBuilder(';');

            var ecfLineTableWriter = new EcfLineTableWriter(csvLineBuilder, "A", "B", "C");

            Assert.Equal(3, ecfLineTableWriter.Headers.Count);

            ecfLineTableWriter.SetValue("A", "11");
            ecfLineTableWriter.SetValue("B", "c1");
            ecfLineTableWriter.SetValue("C", new List<string>() { "13", "14", "15" });

            ecfLineTableWriter.Write();

            Assert.Equal(csvValues, csvLineBuilder.ToString());
        }
    }
}
