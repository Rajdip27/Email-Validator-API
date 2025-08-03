var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();

    // ? ReDoc at /redoc
    app.UseReDoc(c =>
    {
        c.RoutePrefix = "redoc";
        c.DocumentTitle = "API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";
    });

    // ? Redirect root URL "/" to "/redoc"
    app.MapGet("/", context =>
    {
        context.Response.Redirect("/redoc");
        return Task.CompletedTask;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
