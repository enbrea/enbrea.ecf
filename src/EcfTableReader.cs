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
using System.Collections.Generic;
using System.IO;

namespace Enbrea.Ecf
{
    public class EcfTableReader : CsvTableReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="textReader">The <see cref="TextReader"/> as source</param>
        public EcfTableReader(TextReader textReader)
            : base(textReader, new EcfConfiguration(), new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="textReader">The <see cref="TextReader"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableReader(TextReader textReader, CsvHeaders csvHeaders)
            : base(textReader, new EcfConfiguration(), new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="csvReader">The <see cref="TextReader"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableReader(TextReader textReader, params string[] csvHeaders)
            : this(textReader, new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="textReader">The <see cref="TextReader"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableReader(TextReader textReader, IList<string> csvHeaders)
            : this(textReader, new CsvHeaders(csvHeaders))
        {
        }
    }
}