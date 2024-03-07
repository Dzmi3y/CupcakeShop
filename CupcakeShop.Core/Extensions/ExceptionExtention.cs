namespace CupcakeShop.Core.Extensions
{
    public static class ExceptionExtention
    {
        public static string GetFormatedExceptionString(this Exception ex)
        {
            return string.Format("Message:{0}\n Source: {1}\n Date: {2}\n InnerException: {3}\n StackTrace: {4}",
                ex.Message, ex.Source, DateTime.Now, ex.InnerException, ex.StackTrace);
        }
    }
}
