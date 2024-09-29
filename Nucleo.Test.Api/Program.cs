using Nucleo.EventBus.Cap;
using Nucleo.Test.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCapEventBus(builder.Configuration);
// builder.Services.AddSingleton<SubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.AddCapEventBus(app.Configuration);
app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();
app.Run();
