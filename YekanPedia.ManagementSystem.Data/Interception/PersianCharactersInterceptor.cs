namespace YekanPedia.ManagementSystem.Data.Interception
{
    using System.Data.Common;
    using System.Data.Entity.Infrastructure.Interception;
    using InfraStructure.Extension;

    /// <summary>
    /// کلاسی برای اینترسپت کردن پرس و جو ساخته شده 
    /// </summary>
    public class PersianCharactersInterceptor : IDbCommandInterceptor
    {
        /// <summary>
        ///اجرا می شود System.Data.Common.DbCommand.ExecuteNonQuery() این متد بعد از متد 
        /// </summary>
        /// <param name="command">پرس و جو ساخته شده</param>
        /// <param name="interceptionContext">اطلاعات کانتکس پرس و جو</param>
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            command.ApplyCorrectPersianCharacters();
        }

        /// <summary>
        ///اجرا می شود System.Data.Common.DbCommand.ExecuteNonQuery() این متد قبل از متد 
        /// </summary>
        /// <param name="command">پرس و جو ساخته شده</param>
        /// <param name="interceptionContext">اطلاعات کانتکس پرس و جو</param>
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            command.ApplyCorrectPersianCharacters();
        }

        /// <summary>
        ///اجرا می شود System.Data.Common.DbCommand.ExecuteReader(System.Data.CommandBehavior) این متد بعد از متد 
        /// </summary>
        /// <param name="command">پرس و جو ساخته شده</param>
        /// <param name="interceptionContext">اطلاعات کانتکس پرس و جو</param>
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            command.ApplyCorrectPersianCharacters();
        }

        /// <summary>
        ///اجرا می شود System.Data.Common.DbCommand.ExecuteReader(System.Data.CommandBehavior) این متد قبل از متد 
        /// </summary>
        /// <param name="command">پرس و جو ساخته شده</param>
        /// <param name="interceptionContext">اطلاعات کانتکس پرس و جو</param>
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            command.ApplyCorrectPersianCharacters();
        }

        /// <summary>
        ///اجرا می شود System.Data.Common.DbCommand.ExecuteScalar() این متد بعد از متد 
        /// </summary>
        /// <param name="command">پرس و جو ساخته شده</param>
        /// <param name="interceptionContext">اطلاعات کانتکس پرس و جو</param>
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            command.ApplyCorrectPersianCharacters();
        }

        /// <summary>
        ///اجرا می شود System.Data.Common.DbCommand.ExecuteScalar() این متد قبل از متد 
        /// </summary>
        /// <param name="command">پرس و جو ساخته شده</param>
        /// <param name="interceptionContext">اطلاعات کانتکس پرس و جو</param>
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            command.ApplyCorrectPersianCharacters();
        }
    }
}
