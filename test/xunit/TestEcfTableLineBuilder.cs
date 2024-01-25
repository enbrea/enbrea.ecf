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

using System.Collections.Generic;
using Xunit;

namespace Enbrea.Ecf.XUnit
{
    public class TestEcfTableLineBuilder
    {
        [Fact]
        public void TestJsonArray()
        {
            var csvValues = "11;c1;\"[\"\"13\"\",\"\"14\"\",\"\"15\"\"]\"";

            var ecfLineBuilder = new EcfTableLineBuilder("A", "B", "C");

            Assert.Equal(3, ecfLineBuilder.Headers.Count);

            ecfLineBuilder.SetValue("A", "11");
            ecfLineBuilder.SetValue("B", "c1");
            ecfLineBuilder.SetValue("C", new List<string>() { "13", "14", "15" });

            Assert.Equal(csvValues, ecfLineBuilder.ToString());
        }
    }
}
