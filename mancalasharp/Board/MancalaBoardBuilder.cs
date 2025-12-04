using mancalasharp.Board.Elements;

namespace mancalasharp.Board;
public static class MancalaBoardBuilder
{
    public static MancalaBoard Build()
    {
        var board = new MancalaBoard();

        // P1
        // pit1
        var p1Pit1 = new MancalaPit(MancalaBucketId.Player1Pit1);
        board.Setup_AddBucket(MancalaBucketId.Player1Pit1, p1Pit1);

        // pit2
        var p1Pit2 = new MancalaPit(MancalaBucketId.Player1Pit2);
        board.Setup_AddBucket(MancalaBucketId.Player1Pit2, p1Pit2);

        // pit3
        var p1Pit3 = new MancalaPit(MancalaBucketId.Player1Pit3);
        board.Setup_AddBucket(MancalaBucketId.Player1Pit3, p1Pit3);

        // pit4
        var p1Pit4 = new MancalaPit(MancalaBucketId.Player1Pit4);
        board.Setup_AddBucket(MancalaBucketId.Player1Pit4, p1Pit4);

        // pit5
        var p1Pit5 = new MancalaPit(MancalaBucketId.Player1Pit5);
        board.Setup_AddBucket(MancalaBucketId.Player1Pit5, p1Pit5);

        // pit6
        var p1Pit6 = new MancalaPit(MancalaBucketId.Player1Pit6);
        board.Setup_AddBucket(MancalaBucketId.Player1Pit6, p1Pit6);

        // store
        var p1Store = new MancalaStore(MancalaBucketId.Player1Store);
        board.Setup_AddBucket(MancalaBucketId.Player1Store, p1Store);

        // P2
        // pit1
        var p2Pit1 = new MancalaPit(MancalaBucketId.Player2Pit1);
        board.Setup_AddBucket(MancalaBucketId.Player2Pit1, p2Pit1);

        // pit2
        var p2Pit2 = new MancalaPit(MancalaBucketId.Player2Pit2);
        board.Setup_AddBucket(MancalaBucketId.Player2Pit2, p2Pit2);

        // pit3
        var p2Pit3 = new MancalaPit(MancalaBucketId.Player2Pit3);
        board.Setup_AddBucket(MancalaBucketId.Player2Pit3, p2Pit3);

        // pit4
        var p2Pit4 = new MancalaPit(MancalaBucketId.Player2Pit4);
        board.Setup_AddBucket(MancalaBucketId.Player2Pit4, p2Pit4);

        // pit5
        var p2Pit5 = new MancalaPit(MancalaBucketId.Player2Pit5);
        board.Setup_AddBucket(MancalaBucketId.Player2Pit5, p2Pit5);

        // pit6
        var p2Pit6 = new MancalaPit(MancalaBucketId.Player2Pit6);
        board.Setup_AddBucket(MancalaBucketId.Player2Pit6, p2Pit6);

        // store
        var p2Store = new MancalaStore(MancalaBucketId.Player2Store);
        board.Setup_AddBucket(MancalaBucketId.Player2Store, p2Store);

        
        var p1Pits = new[] { p1Pit1, p1Pit2, p1Pit3, p1Pit4, p1Pit5, p1Pit6 };
        var p2Pits = new[] { p2Pit1, p2Pit2, p2Pit3, p2Pit4, p2Pit5, p2Pit6 };

        // Player 1
        for (int i = 0; i < 6; i++)
        {
            MancalaBucket next = i < 5 ? p1Pits[i + 1] : p1Store;
            var cross = p2Pits[5 - i]; // 0↔5, 1↔4, etc.
            p1Pits[i].Setup_Relations(next, cross, p1Store);
        }

        // Player 2
        for (int i = 0; i < 6; i++)
        {
            MancalaBucket next = i < 5 ? p2Pits[i + 1] : p2Store;
            var cross = p1Pits[5 - i];
            p2Pits[i].Setup_Relations(next, cross, p2Store);
        }

        // Stores
        p1Store.Setup_Relations(p2Pits[0]);
        p2Store.Setup_Relations(p1Pits[0]);
        
        return board;
    }
}
