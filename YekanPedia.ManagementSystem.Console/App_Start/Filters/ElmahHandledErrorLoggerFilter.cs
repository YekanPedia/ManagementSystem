namespace YekanPedia.ManagementSystem.Console.App_Start.Filters
{
    using System.Web.Mvc;
    using Elmah;
    public class ElmahHandledErrorLoggerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //if (context.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}