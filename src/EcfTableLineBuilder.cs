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
    public class EcfTableLineBuilder : CsvTableLineBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineBuilder"/> class.
        /// </summary>
        public EcfTableLineBuilder()
            : base(new EcfConfiguration(), new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineBuilder"/> class.
        /// </summary>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableLineBuilder(CsvHeaders csvHeaders)
            : base(new EcfConfiguration(), new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineBuilder"/> class.
        /// </summary>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableLineBuilder(params string[] csvHeaders)
            : this(new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableLineBuilder"/> class.
        /// </summary>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableLineBuilder(IList<string> csvHeaders)
            : this(new CsvHeaders(csvHeaders))
        {
        }
    }
}