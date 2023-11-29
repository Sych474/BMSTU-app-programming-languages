using GameDatabase;
using GameModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IFightProcessor, FightProcessor>();
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=GamesDb"));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();