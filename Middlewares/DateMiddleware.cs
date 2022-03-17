public class HourMiddleware
{
        readonly RequestDelegate next;

        public HourMiddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(HttpContext context)
        {
            await next(context);

            if(context.Request.Query.Any(p=> p.Key== "hour"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }

    }

    public static class HourMiddlewareExtension
    {
        public static IApplicationBuilder UseHourMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HourMiddleware>();
        }
    }