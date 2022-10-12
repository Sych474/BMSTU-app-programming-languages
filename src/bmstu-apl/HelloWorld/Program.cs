namespace HelloWorld
{
    internal static class Program
    {
        internal enum UnitType
        {
            Air, 
            Land
        }

        internal class Unit
        {
            public Unit(UnitType type, string name)
            {
                Type = type;
                Name = name;
            }

            public UnitType Type { get; }
            
            public string Name { get; }
        }
        

        private static void Main(string[] args)
        {
            var list = new List<int>() { 1, 3, 2, 2, 4 };

            list.Count();
            var newList = list.Where(x => x > 2).ToList();
            var selectList = list.Select(x => new List<int>() { x }).ToArray();
            var set = list.Distinct().ToList();
            
            if (list.Any(x => x == 5))
                Console.WriteLine("Good");

            newList = list.SelectMany(x => new List<int>() { x, x + 10 }).ToList();

            var units = new List<Unit>()
            {
                new(UnitType.Air, "Беспилотник"),
                new(UnitType.Air, "Беспилотник"),

                new(UnitType.Land, "Эон"),
                
                new(UnitType.Air, "Самолет"),
                new(UnitType.Air, "Вертолет"),

                new(UnitType.Land, "Кибран"),
            };

            var res = units.GroupBy(x => x.Type);

            foreach (var group in res)
            {
                Console.WriteLine(group.Key);
                foreach (var unit in group)
                    Console.WriteLine(unit.Name);
            }


            Console.WriteLine("Hello World!");
        }
    }
}
