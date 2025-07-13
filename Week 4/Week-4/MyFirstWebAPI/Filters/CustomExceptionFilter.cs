using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace MyFirstWebAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            // 🔥 Create log file and write error
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            var filePath = Path.Combine(logPath, "exceptions.txt");

            var log = $"[{DateTime.Now}] {exception.GetType().Name}: {exception.Message}\n{exception.StackTrace}\n\n";

            File.AppendAllText(filePath, log);

            // 🔴 Return friendly error to client
            context.Result = new ObjectResult("Oops! Something went wrong.")
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
