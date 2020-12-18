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
    public class EcfLineTableWriter : CsvLineTableWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableWriter"/> class.
        /// </summary>
        /// <param name="csvLineBuilder">The <see cref="CsvLineBuilder"/> as source</param>
        public EcfLineTableWriter(CsvLineBuilder csvLineBuilder)
            : base(csvLineBuilder, new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableWriter"/> class.
        /// </summary>
        /// <param name="csvLineBuilder">The <see cref="CsvLineBuilder"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfLineTableWriter(CsvLineBuilder csvLineBuilder, CsvHeaders csvHeaders)
            : base(csvLineBuilder, new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableWriter"/> class.
        /// </summary>
        /// <param name="csvLineBuilder">The <see cref="CsvLineBuilder"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfLineTableWriter(CsvLineBuilder csvLineBuilder, params string[] csvHeaders)
            : this(csvLineBuilder, new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfLineTableWriter"/> class.
        /// </summary>
        /// <param name="csvLineBuilder">The <see cref="CsvLineBuilder"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfLineTableWriter(CsvLineBuilder csvLineBuilder, IList<string> csvHeaders)
            : this(csvLineBuilder, new CsvHeaders(csvHeaders))
        {
        }

    }
}