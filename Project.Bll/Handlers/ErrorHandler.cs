
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
    }

}

