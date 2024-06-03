using System.Text.Json.Serialization;
using AlphaPunkotiki.WebApi.Registrars;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services
    .AddCors()
    .AddSwagger()
    .AddPostgresDbContext(builder.Configuration)
    .AddInterviewsServices()
    .AddSurveysServices()
    .AddAccountsServices();

var app = builder.Build();

app.UseCors(b => b
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHsts();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
