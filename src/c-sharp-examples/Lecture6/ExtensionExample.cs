namespace Lecture6;

public static class StringExtension
{
    public static int CharactersCount(this string str, char c)
    {
        var counter = 0;
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i] == c)
                counter++;
        }
        return counter;
    }
}