using GoodFramework.Abp.ExceptionHandling.Emailing.Localization;
using Volo.Abp.Localization;
using Volo.Abp.TextTemplating;

namespace GoodFramework.Abp.ExceptionHandling.Emailing.Templates
{
    public class ExceptionHandlingTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
               new TemplateDefinition(
                   ExceptionHandlingTemplates.SendEmail,
                   displayName: LocalizableString.Create<ExceptionHandlingResource>("TextTemplate:ExceptionHandlingTemplates.SendEmail"),
                   defaultCultureName: "en"
               ).WithVirtualFilePath("/GoodFramework/Abp/ExceptionHandling/Emailing/Templates/SendEmail", false)
           );
        }
    }
}
