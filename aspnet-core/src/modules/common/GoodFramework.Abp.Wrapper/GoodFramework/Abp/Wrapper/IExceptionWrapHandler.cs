namespace GoodFramework.Abp.Wrapper
{
    public interface IExceptionWrapHandler
    {
        void Wrap(ExceptionWrapContext context);
    }
}
