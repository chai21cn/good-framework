using System;

namespace GoodFramework.Abp.Wrapper
{
    public interface IExceptionWrapHandlerFactory
    {
        IExceptionWrapHandler CreateFor(ExceptionWrapContext context);
    }
}
