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
    public class EcfTableReader : CsvTableReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="csvReader">The <see cref="CsvReader"/> as source</param>
        public EcfTableReader(CsvReader csvReader)
            : base(csvReader, new EcfConverterResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="csvReader">The <see cref="CsvReader"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableReader(CsvReader csvReader, CsvHeaders csvHeaders)
            : base(csvReader, new EcfConverterResolver(), csvHeaders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="csvReader">The <see cref="CsvReader"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableReader(CsvReader csvReader, params string[] csvHeaders)
            : this(csvReader, new CsvHeaders(csvHeaders))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EcfTableReader"/> class.
        /// </summary>
        /// <param name="csvReader">The <see cref="CsvReader"/> as source</param>
        /// <param name="csvHeaders">List of csv headers</param>
        public EcfTableReader(CsvReader csvReader, IList<string> csvHeaders)
            : this(csvReader, new CsvHeaders(csvHeaders))
        {
        }
    }
}