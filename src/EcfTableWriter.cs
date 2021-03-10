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
using System.Collections.Generic;

namespace Enbrea.Ecf
{
    public class EcfTableWriter : CsvTableWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="csvWriter">The <see cref="CsvWriter"/> as source</param>
        public EcfTableWriter(CsvWriter csvWriter)
            : base(csvWriter, new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="csvWriter">The <see cref="CsvWriter"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableWriter(CsvWriter csvWriter, CsvHeaders csvHeaders)
            : base(csvWriter, new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="csvWriter">The <see cref="CsvWriter"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableWriter(CsvWriter csvWriter, params string[] csvHeaders)
            : this(csvWriter, new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableWriter"/> class.
        /// </summary>
        /// <param name="csvWriter">The <see cref="CsvWriter"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableWriter(CsvWriter csvWriter, IList<string> csvHeaders)
            : this(csvWriter, new CsvHeaders(csvHeaders))
        {
        }

    }
}