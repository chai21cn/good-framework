using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace GoodFramework.Platform.EntityFrameworkCore
{
    public class PlatformModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public PlatformModelBuilderConfigurationOptions(
           [NotNull] string tablePrefix = "",
           [CanBeNull] string schema = null)
           : base(
               tablePrefix,
               schema)
        {

        }
    }
}
