var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.Map("/Home", (newApp) =>
{
    newApp.Use(async (context, next) =>
    {
        if (context.Request.QueryString.Value == "")
            await context.Response.WriteAsync("Ok From Map");
        else
            await next();
    });

    newApp.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello From Run From Map");
    });
});

app.Use(async (context, next) =>
{
    if (context.Request.QueryString.Value == "")
        await context.Response.WriteAsync("Ok From App");
    else
        await next();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from APP");
});

app.MapGet("/", () => "Hello World!");

app.Run();
