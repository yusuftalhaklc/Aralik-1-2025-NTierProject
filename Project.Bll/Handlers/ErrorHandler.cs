using Project.Bll.Exceptions;

namespace Project.Bll.Handlers
{
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);

    public static class ErrorHandler
    {
        public static async Task<T> ExecuteAsync<T>(object sender, Func<Task<T>> operation, ErrorEventHandler? onError = null)
        {
            try
            {
                return await operation();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                onError?.Invoke(sender, new ErrorEventArgs(ex.Message));
                throw new BusinessException(ex.Message, ex);
            }
        }

        public static async Task ExecuteAsync(object sender, Func<Task> operation, ErrorEventHandler? onError = null)
        {
            try
            {
                await operation();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                onError?.Invoke(sender, new ErrorEventArgs(ex.Message));
                throw new BusinessException(ex.Message, ex);
            }
        }

        public static T Execute<T>(object sender, Func<T> operation, ErrorEventHandler? onError = null)
        {
            try
            {
                return operation();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                onError?.Invoke(sender, new ErrorEventArgs(ex.Message));
                throw new BusinessException(ex.Message, ex);
            }
        }
    }
}

