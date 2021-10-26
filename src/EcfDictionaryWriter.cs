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
    public class EcfDictionaryWriter : CsvDictionaryWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfDictionaryWriter"/> class.
        /// </summary>
        /// <param name="csvWriter">The <see cref="CsvWriter"/> as source</param>
        public EcfDictionaryWriter(CsvWriter csvWriter)
            : base(csvWriter, new EcfConverterResolver())
        {
        }
    }
}