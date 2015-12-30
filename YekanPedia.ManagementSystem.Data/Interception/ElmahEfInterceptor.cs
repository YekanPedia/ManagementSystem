namespace YekanPedia.ManagementSystem.Data.Interception
{
    using Logging;

    public class ElmahEfInterceptor : EfExceptionsInterceptor
    {
        public ElmahEfInterceptor() : base(new ElmahEfExceptionsLogger())
        { }
    }
}
