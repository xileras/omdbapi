using Newtonsoft.Json;
using System.Net;

namespace Server.WebAPI.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                var exceptionWrapper = new ExceptionWrapper { Message = "An error has occurred" };

#if DEBUG
                exceptionWrapper.Exception = ex;
#endif

                var errorMessage = JsonConvert.SerializeObject(exceptionWrapper);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(errorMessage);
            }
        }
    }
}
