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

namespace Enbrea.Ecf
{
    /// <summary>
    /// Implementation of a <see cref="EcfStudentStatus"></see> converter to or from ECF
    /// </summary>
    public class EcfStudentStatusConverter : CsvDefaultEnumConverter
    {
        public EcfStudentStatusConverter() : 
            base(typeof(EcfStudentStatus), null, true)
        {
        }
    }
}