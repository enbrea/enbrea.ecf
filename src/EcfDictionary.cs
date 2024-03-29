﻿#region ENBREA.ECF - Copyright (c) STÜBER SYSTEMS GmbH
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

namespace Enbrea.Ecf
{
    public class EcfDictionary : CsvDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcfDictionary"/> class.
        /// </summary>
        public EcfDictionary()
            : base(new EcfConfiguration(), new EcfConverterResolver())
        {
        }
    }
}