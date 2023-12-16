using DiyorMarket.Domain.Exceptions;
using System.Net;

namespace DiyorMarket.Middlewares
{
    public class ErrorHendlerMiddlewares
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHendlerMiddlewares> _logger;

        public ErrorHendlerMiddlewares(RequestDelegate next, ILogger<ErrorHendlerMiddlewares> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context,ex);
            }
        }
        private async Task HandleAsync(HttpContext context,Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string massage = $"Internal server error. Something went wrong, pleace try again later. ";

            if(exception is EntityNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                massage = exception.Message;
            }

            await context.Response.WriteAsync(massage);
            _logger.LogError($"{massage}. {exception.Message}");
        }
    }
}
