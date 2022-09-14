using System.Runtime.CompilerServices;

namespace Lecture3;


internal class ListNode<ElemT>
{
    internal ElemT Value { get; }
    
    internal ListNode<ElemT>? Next { get; set; } = null;

    internal ListNode(ElemT val) => Value = val;
}

public class List<T>
{
    private ListNode<T>? _firstNode;

    public void Append(T value)
    {
        var node = new ListNode<T>(value);
        if (_firstNode == null)
            _firstNode = node;
        else
        {
            var prevNode = _firstNode;
            var nextNode = _firstNode.Next;
            while (nextNode != null)
            {
                prevNode = nextNode;
                nextNode = nextNode.Next;
            }
            prevNode.Next = node;
        }
    }
    
    // ... other methods of list
}

public interface ICrudRepository<T> where T : notnull
{
    Guid Create(T item);
    
    T? Read(Guid id);
    
    void Update(Guid id, T itemToUpdate);
    
    T? Remove(Guid id);
}

public class InMemoryStringRepository : ICrudRepository<string>
{
    private readonly Dictionary<Guid, string> _items = new();

    public Guid Create(string item)
    {
        var id = Guid.NewGuid();
        _items[id] = item;
        return id; 
    }

    public string? Read(Guid id) => _items.TryGetValue(id, out var item) ? item : null;

    public void Update(Guid id, string itemToUpdate) => _items[id] = itemToUpdate;

    public string? Remove(Guid id)
    {
        var itemContains = _items.TryGetValue(id, out var item); 
        if (itemContains)
            _items.Remove(id);
        return item;
    }
}