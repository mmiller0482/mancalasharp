using mancalasharp.Game;

namespace mancalasharp.Board.Elements;

public enum MancalaBucketId
{
    Player1Store,
    Player2Store,
    Player1Pit1,
    Player2Pit1,
    Player1Pit2,
    Player2Pit2,
    Player1Pit3,
    Player2Pit3,
    Player1Pit4,
    Player2Pit4,
    Player1Pit5,
    Player2Pit5,
    Player1Pit6,
    Player2Pit6
}

public static class MancalaBucketIdExtensions
{
    public static PlayerId GetCorrespondingPlayerId(this MancalaBucketId id)
    {
        return id is MancalaBucketId.Player1Store 
            or MancalaBucketId.Player1Pit1 
            or MancalaBucketId.Player1Pit2
            or MancalaBucketId.Player1Pit3 
            or MancalaBucketId.Player1Pit4 
            or MancalaBucketId.Player1Pit5
            or MancalaBucketId.Player1Pit6
            ? PlayerId.Player1
            : PlayerId.Player2;
    }
}