namespace Lecture6;

public class LinqExamples
{
    public static void UsingOperators()
    {
        string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

        // создаем новый список для результатов
        var selectedPeople = from p in people 
            // передаем каждый элемент из people в переменную p
            where p.ToUpper().StartsWith("T") //фильтрация по критерию
            orderby p // упорядочиваем по возрастанию
            select p; // выбираем объект в создаваемую коллекцию
        
        foreach (var person in selectedPeople)
            Console.WriteLine(person);
    }

    public static void UsingExtensions()
    {
        string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
 
        var selectedPeople = people
            .Where(p => p.ToUpper().StartsWith("T"))
            .OrderBy(p => p);
 
        foreach (var person in selectedPeople)
            Console.WriteLine(person);
    }

    public class UserAction
    {
        public UserAction(string actionText, DateTime date)
        {
            ActionText = actionText;
            Date = date;
        }

        public string ActionText { get; }
        
        public DateTime Date { get; }
    }


    public static void Select()
    {
        string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
        
        var where = people.Where(x => x.StartsWith("T"));
        
        var hellos = people.Select(x => $"Hello, {x}!");
        var lengths = people.Select(x => x.Length);

        int[][] arrays = {
            new[] {1, 2, 3},
            new[] {4},
            new[] {5, 6, 7, 8},
            new[] {12, 14}
        };
        
        // Will return { 1, 2, 3, 4, 5, 6, 7, 8, 12, 14 }
        var result = arrays.SelectMany(array => array);


        var haveSam = people.Any(x => x == "Sam");

        var haveNoEmptyStrings = people.All(x => !string.IsNullOrWhiteSpace(x));

        var peoplesCount = people.Count(); 

        var peoplesStartsFromTCount = people.Count(x => x.StartsWith("T")); 

        
        UserAction[] actions = new[]
        {
            new UserAction("Authorize", DateTime.Now.AddDays(-1)),
            new UserAction("Authorize", DateTime.Now.AddDays(-2)),
            new UserAction("Authorize", DateTime.Now.AddDays(-3)),

            new UserAction("Update name", DateTime.Now.AddDays(-2).AddHours(-2)),
            new UserAction("Update email", DateTime.Now.AddDays(-2)),
            new UserAction("Confirm email", DateTime.Now.AddDays(-2)),
            new UserAction("Fill balance", DateTime.Now.AddDays(-1)),
        };
        
        var ordered = actions.OrderBy(x => x.Date);

        var orderedByDesc = actions.OrderByDescending(x => x.Date);


        var noActions = new List<UserAction>();
        
        var firstName = people.First();
        var firstNameStartsFromT = people.First(x => x.StartsWith("T"));
        var firstUpdateAction = actions.First();
        actions.First(); // exception 

        var defaultAction = actions.FirstOrDefault(); // null 
        
        var singleConfirm = actions.Single(x => x.ActionText.Contains("Confirm")); 
        var singleAuthorize = actions.Single(x => x.ActionText == "Authorize"); // exception 
        var single = actions.Single(); // exception

        defaultAction = actions.SingleOrDefault(); // exception
        defaultAction = actions.SingleOrDefault(x => string.IsNullOrWhiteSpace(x.ActionText)); null 

        var numbers = new List<int>() { 1, 3, 2, 1};

        var numbersSum = numbers.Sum(); // 7 
        var min = numbers.Min(); // 1
        var max = numbers.Max(); // 3
        var avg = numbers.Average(); // 7 / 4
        
        var names = people.Aggregate("Names:", (first, next) => $"{first} {next}");
        // Names: Tom, Bob, Sam, Tim, Tomas, Bill
        
        var distinctNumbers = numbers.Distinct(); // 1, 2, 3

        var firstTwoActions = actions.Take(2);
        
        var skipTwoActions = actions.Skip(2);

        var takeTwoActionsInSecondPage = actions.Skip(2).Take(2);

        
        var actionsByDate = actions.GroupBy(x => x.Date);
        
        var actionsByDateDictionary = actions.ToLookup(x => x.Date);
    }
}