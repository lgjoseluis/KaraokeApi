using Karaoke.Song.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Versioning
builder.Services.AddApiVersioningConfigured();
builder.Services.AddVersionedApiExplorerConfigured();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenConfigured();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUIConfigured();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
