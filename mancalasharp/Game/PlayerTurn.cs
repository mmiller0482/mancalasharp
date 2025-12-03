namespace mancalasharp.Game;

public enum PlayerTurn
{
    Player1,
    Player2
}


public static class PlayerTurnExtensions
{
    public static string ToDisplayString(this PlayerTurn turn) => turn == PlayerTurn.Player1 ? "Player 1" : "Player 2";
    
    public static PlayerTurn Opposite(this PlayerTurn turn) => 
        turn == PlayerTurn.Player1 ? PlayerTurn.Player2 : PlayerTurn.Player1;
}

