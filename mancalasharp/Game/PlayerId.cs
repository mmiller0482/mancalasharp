namespace mancalasharp.Game;

public enum PlayerId
{
    Player1,
    Player2
}

public static class PlayerIdExtensions
{
    public static string ToDisplayString(this PlayerId id)
    {
        return id == PlayerId.Player1 ? "Player 1" : "Player 2";
    }

    public static PlayerId Opposite(this PlayerId id)
    {
        return id == PlayerId.Player1 ? PlayerId.Player2 : PlayerId.Player1;
    }
}