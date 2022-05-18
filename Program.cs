using Demo.Databases.Master;
using Demo.Extentions;
using Demo.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureMySqlContext("Server=167.71.221.116;Database=master;Uid=setup;Pwd=qweqwe123$;Allow Zero Datetime=true;convert zero datetime=True;old guids=True;");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<CheckAcessMiddleware>();

app.Run();
