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

namespace Enbrea.Ecf
{
    public class EcfDictionaryReader : CsvDictionaryReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfDictionaryReader"/> class.
        /// </summary>
        /// <param name="csvReader">The <see cref="CsvReader"/> as source</param>
        public EcfDictionaryReader(CsvReader csvReader)
            : base(csvReader, new EcfConverterResolver())
        {
        }
    }
}