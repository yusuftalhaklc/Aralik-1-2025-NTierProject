
namespace Project.Bll.Handlers
{
    public static class DelegateErrorHandler
    {
        public static T Execute<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch
            {
                throw;
            }
        }
        
        public static string ExecuteStringAsync(Func<string> action)
        {
            try
            {
                return action();
            }
            catch
            {
                throw;
            }
        }
    }

}

