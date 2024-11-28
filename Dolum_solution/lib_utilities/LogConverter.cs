namespace lib_utilities
{
    public class LogConverter{
        public static void Log(Exception exception, IDictionary<string, object> ViewData)
        {
            if (ViewData == null)
                return;
            var message = exception.Message.ToString();
            if (exception.InnerException != null)
                message = exception.InnerException!.Message.ToString();
            
            if (message.Length >= 110)
                message = message.Substring(0, 110);
            
            var msg = lib_lenguages.rsErrors.ResourceManager.GetString(message);
            if (!string.IsNullOrEmpty(msg))
            {
                ViewData!["message"] = msg;
                return;
            }
            ViewData!["message"] = message;
        }
    }
}