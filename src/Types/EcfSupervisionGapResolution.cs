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

namespace Enbrea.Ecf
{
    /// <summary>
    /// An abstract supervision gap resolution (Fehlstellenauflösung für eine Aufsicht).
    /// </summary>
    /// <remarks>
    /// This class is the base class for <see cref="EcfSupervisionGapSubstitution"/> and <see cref="EcfSupervisionGapCancellation"/>.
    /// </remarks>
    public abstract class EcfSupervisionGapResolution : EcfGapResolution
    {
    }
}