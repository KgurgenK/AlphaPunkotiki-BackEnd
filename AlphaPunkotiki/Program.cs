using System.Text.Json.Serialization;
using AlphaPunkotiki.WebApi.Registrars;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services
    .AddSwagger()
    .AddPostgresDbContext(builder.Configuration)
    .AddInterviewsServices()
    .AddSurveysServices();

var app = builder.Build();

app.UseHsts();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
