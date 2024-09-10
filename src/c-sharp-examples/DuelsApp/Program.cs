using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

var context = new DuelsContext("User ID=postgres;Password=зщыепкуы;Server=localhost;Port=5432;Database=DuelsDb");

// добавление сущностей 
var ork = new Character() { Name = "Gorka", Hp = 420, Race = Race.Ork };
var elf = new Character() { Name = "Elrond", Hp = 350, Race = Race.Elf };

if (!context.Characters.Any(x => x.Name == ork.Name))
    context.Characters.Add(ork);
if (!context.Characters.Any(x => x.Name == elf.Name))
    context.Characters.Add(elf);
context.SaveChanges();

// добавление свзок
var duel = new DuelResult()
{
    Challenger = ork,
    Receiver = elf,
    Result = "Ничья"
};
context.DuelResults.Add(duel);
context.SaveChanges();

// Получение данных из БД 
foreach (var character in context.Characters.ToList())
    Console.WriteLine(character);

// Получение данных c join
var firstElf = context.Characters.Include(x => x.ReceivedDuels).First(x => x.Race == Race.Elf);

foreach (var elfDuel in firstElf.ReceivedDuels.ToList())
    Console.WriteLine(elfDuel);