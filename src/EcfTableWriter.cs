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
    public class EcfTableWriter : CsvTableWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter"/> as source</param>
        public EcfTableWriter(TextWriter textWriter)
            : base(textWriter, new EcfConfiguration(), new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableWriter(TextWriter textWriter, CsvHeaders csvHeaders)
            : base(textWriter, new EcfConfiguration(), new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableWriter(TextWriter textWriter, params string[] csvHeaders)
            : this(textWriter, new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="csvWriter">The <see cref="TextWriter"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableWriter(TextWriter textWriter, IList<string> csvHeaders)
            : this(textWriter, new CsvHeaders(csvHeaders))
        {
        }

    }
}