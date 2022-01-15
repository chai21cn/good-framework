using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Good.Framework.Abp.Localization.Dynamic
{
    public class LocalizationDictionary : Dictionary<string, Dictionary<string, ILocalizationDictionary>>
    {

    }
}
