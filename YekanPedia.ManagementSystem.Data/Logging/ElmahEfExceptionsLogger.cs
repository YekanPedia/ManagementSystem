namespace YekanPedia.ManagementSystem.Data.Logging
{
    using Elmah;
    using System;
    using System.Data.Common;
    using System.Data.Entity.Infrastructure.Interception;

    public class ElmahEfExceptionsLogger : IEfExceptionsLogger
    {
        public void LogException<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            var ex = interceptionContext.OriginalException;
            if (ex == null)
                return;

            var sqlData = CommandDumper.LogSqlAndParameters(command, interceptionContext);
            var contextualMessage = string.Format("{0}{1}OriginalException:{1}{2} {1}", sqlData, Environment.NewLine, ex);


            if (!string.IsNullOrWhiteSpace(contextualMessage))
            {
                ex = new Exception(contextualMessage, new ElmahEfInterceptorException(ex.Message));
            }

            try
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            catch
            {
            }
        }
    }
}
