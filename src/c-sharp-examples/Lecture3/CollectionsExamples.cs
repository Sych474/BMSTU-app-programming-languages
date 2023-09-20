namespace Lecture3;

public static class CollectionsExampleCall
{
    public static void ForeachCall()
    {
        var emails = new string[] { "petya@kek.ru", "sasha@rar.ru", "masha@bst.ru" };

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}