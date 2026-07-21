using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var logPath = Path.Combine(AppContext.BaseDirectory, "exception-log.txt");
        File.AppendAllText(logPath, $"{DateTime.Now}: {context.Exception}{Environment.NewLine}");

        context.Result = new ObjectResult(context.Exception.Message)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
