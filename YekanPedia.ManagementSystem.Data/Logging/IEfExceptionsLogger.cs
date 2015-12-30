namespace YekanPedia.ManagementSystem.Data.Logging
{
    using System.Data.Common;
    using System.Data.Entity.Infrastructure.Interception;

    public interface IEfExceptionsLogger
    {
        void LogException<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext);
    }
}
