using GoodFramework.Abp.BackgroundTasks.Localization;
using Volo.Abp.Localization;
using Volo.Abp.TextTemplating;

namespace GoodFramework.Abp.BackgroundTasks.ExceptionHandling.Templates
{
    public class JobExceptionHandlingTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(GetTemplateDefinitions());
        }

        private static TemplateDefinition[] GetTemplateDefinitions()
        {
            return new[]
            {
                new TemplateDefinition(
                   JobExceptionHandlingTemplates.JobExceptionNotifier,
                   displayName: L("TextTemplate:JobExceptionNotifier"),
                   localizationResource: typeof(BackgroundTasksResource)
                ).WithVirtualFilePath(
                    "/GoodFramework/Abp/BackgroundTasks/ExceptionHandling/Templates/JobExceptionNotifier.tpl",
                    isInlineLocalized: true)
            };
        }

        private static ILocalizableString L(string name)
        {
            return LocalizableString.Create<BackgroundTasksResource>(name);
        }
    }
}
