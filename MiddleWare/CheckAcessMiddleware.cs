namespace Demo.MiddleWare;

public class CheckAcessMiddleware
{
    private readonly RequestDelegate _next;
    public CheckAcessMiddleware (RequestDelegate next) => _next = next;
    public async Task  Invoke (HttpContext httpContext)
    {
        

    }

    }
