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

namespace Enbrea.Ecf
{
    public class EcfTableLineParser : CsvTableLineParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineParser"/> class.
        /// </summary>
        public EcfTableLineParser()
            : base(new EcfConfiguration(), new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineParser"/> class.
        /// </summary>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableLineParser(CsvHeaders csvHeaders)
            : base(new EcfConfiguration(), new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineParser"/> class.
        /// </summary>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableLineParser(params string[] csvHeaders)
            : this(new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineParser"/> class.
        /// </summary>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableLineParser(IList<string> csvHeaders)
            : this(new CsvHeaders(csvHeaders))
        {
        }
    }
}