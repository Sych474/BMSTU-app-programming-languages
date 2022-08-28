namespace Lecture2.Examples;

public class Message
{
    private string _title;
    private string _text;

    public int Id;

    public Message(int id)
    {
        Id = id;
    }
    
    public Message(string title, string text, int id) : this(id)
    {
        this._title = title;
        this._text = text;
    }

    public string Render() => $"\t {_title} \n\n  {_text}";
}