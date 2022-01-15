using JetBrains.Annotations;
using Good.Framework.Abp.Localization.Dynamic;

namespace Volo.Abp.Localization
{
    public static class DynamicLocalizationResourceExtensions
    {
        public static LocalizationResource AddDynamic(
            [NotNull] this LocalizationResource localizationResource)
        {
            Check.NotNull(localizationResource, nameof(localizationResource));

            localizationResource.Contributors.Add(
                new DynamicLocalizationResourceContributor(
                    localizationResource.ResourceName));

            return localizationResource;
        }
    }
}
