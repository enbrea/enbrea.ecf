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

namespace Enbrea.Ecf
{
    /// <summary>
    /// An abstract lesson gap resolution (Fehlstellenauflösung für eine Unterrichtseinheit).
    /// </summary>
    /// <remarks>
    /// This class is the base class for <see cref="EcfLessonGapSubstitution"/> and <see cref="EcfLessonGapCancellation"/>.
    /// </remarks>
    public abstract class EcfLessonGapResolution : EcfGapResolution
    {
    }
}