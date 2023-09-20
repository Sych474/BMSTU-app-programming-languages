namespace Lecture5;

public class Account
{
    public Account(int startBalance)
    {
        _balance = startBalance;
    }
        
    public event Action<int>? BalanceUpdated;

    private int _balance;

    public int Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            BalanceUpdated?.Invoke(_balance);
        }
    }
}

public static class Caller
{
    public static void Call()
    {
        var account = new Account(100);
        account.BalanceUpdated += newBalance => Console.WriteLine($"Текущий баланс: {newBalance}");

        account.Balance -= 10;
        account.Balance -= 20;
        account.Balance -= 30;
    }
}