using PartyGames.Engine;
using PartyGames.Engine.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddSingleton<PartyGamesEngine>();
builder.Services.AddSingleton<PlayerService>();
builder.Services.AddSingleton<LobbyService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:8100");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

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

app.UseCors("AllowedOrigins");

app.Run();

// https://localhost:7023/swagger/index.html