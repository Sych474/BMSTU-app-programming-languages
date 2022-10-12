namespace DataBase.Models;

public class DuelResult
{
    public int Id { get; set; }
    
    public int ChallengerId { get; set; } 
    
    public int ReceiverId { get; set; } 
    
    public Character Challenger { get; set; }
    
    public Character Receiver { get; set; }

    public override string ToString() => $"{ChallengerId} - {ReceiverId} dueled";
}