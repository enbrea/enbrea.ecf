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
using System.Collections.Generic;

namespace Enbrea.Ecf
{
    public class EcfLineTableReader : CsvLineTableReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableReader"/> class.
        /// </summary>
        /// <param name="csvLineParser">The <see cref="CsvLineParser"/> as source</param>
        public EcfLineTableReader(CsvLineParser csvLineParser)
            : base(csvLineParser, new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableReader"/> class.
        /// </summary>
        /// <param name="csvLineParser">The <see cref="CsvLineParser"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfLineTableReader(CsvLineParser csvLineParser, CsvHeaders csvHeaders)
            : base(csvLineParser, new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableReader"/> class.
        /// </summary>
        /// <param name="csvLineParser">The <see cref="CsvLineParser"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfLineTableReader(CsvLineParser csvLineParser, params string[] csvHeaders)
            : this(csvLineParser, new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableReader"/> class.
        /// </summary>
        /// <param name="csvLineParser">The <see cref="CsvLineParser"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfLineTableReader(CsvLineParser csvLineParser, IList<string> csvHeaders)
            : this(csvLineParser, new CsvHeaders(csvHeaders))
        {
        }
    }
}