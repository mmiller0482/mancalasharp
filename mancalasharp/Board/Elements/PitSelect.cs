namespace mancalasharp.Board.Elements;

public static class PitSelect
{
    private static readonly MancalaBucketId[] Player1Pits =
    [
        MancalaBucketId.Player1Pit1,
        MancalaBucketId.Player1Pit2,
        MancalaBucketId.Player1Pit3,
        MancalaBucketId.Player1Pit4,
        MancalaBucketId.Player1Pit5,
        MancalaBucketId.Player1Pit6
    ];

    private static readonly MancalaBucketId[] Player2Pits =
    [
        MancalaBucketId.Player2Pit1,
        MancalaBucketId.Player2Pit2,
        MancalaBucketId.Player2Pit3,
        MancalaBucketId.Player2Pit4,
        MancalaBucketId.Player2Pit5,
        MancalaBucketId.Player2Pit6
    ];

    public static MancalaBucketId Get(PlayerTurn turn, int selectedPit)
    {
        if (selectedPit is < 1 or > 6)
            throw new ArgumentOutOfRangeException(nameof(selectedPit));

        return turn == PlayerTurn.Player1
            ? Player1Pits[selectedPit - 1]
            : Player2Pits[selectedPit - 1];
    }
}