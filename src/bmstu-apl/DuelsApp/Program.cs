// See https://aka.ms/new-console-template for more information

using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

var context = new DuelsContext("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=DuelsDb");

var ork = new Character() { Name = "Gorka", Hp = 420, Race = Race.Ork };
var elf = new Character() { Name = "Elrond", Hp = 350, Race = Race.Elf };

if (!context.Characters.Any(x => x.Name == ork.Name))
    context.Characters.Add(ork);
if (!context.Characters.Any(x => x.Name == elf.Name))
    context.Characters.Add(elf);
context.SaveChanges();

var duel = new DuelResult() { ChallengerId = 1, ReceiverId = 2 };
context.DuelResults.Add(duel);
context.SaveChanges();

foreach (var character in context.Characters.ToList())
    Console.WriteLine(character);
    
var elrond = context.Characters.Include(x => x.ReceivedDuels).First(x => x.Race == Race.Elf);

foreach (var character in elrond.ReceivedDuels.ToList())
    Console.WriteLine(character);