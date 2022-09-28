namespace Lecture5;



public class GameObject2D
{
    private int _x;
    private int _y;

    public GameObject2D(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void ChangePosition(int newX, int newY)
    {
        PositionsHistory.Add((x:_x, y: _y));
        _x = newX;
        _y = newY;
    }

    public readonly List<(int x, int y)> PositionsHistory = new();

    public (int x, int y) GetPosition => (_x, _y);
}

