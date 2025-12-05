using mancalasharp.Board.Elements;
using mancalasharp.Game;

namespace mancalasharp.Board;

public static class MancalaBoardBuilder
{
    public static MancalaBoard Build()
    {
        var board = new MancalaBoard();

        // Player 1 pits
        var p1Pits = new[]
        {
            AddPit(board, MancalaBucketId.Player1Pit1, PlayerTurn.Player1),
            AddPit(board, MancalaBucketId.Player1Pit2, PlayerTurn.Player1),
            AddPit(board, MancalaBucketId.Player1Pit3, PlayerTurn.Player1),
            AddPit(board, MancalaBucketId.Player1Pit4, PlayerTurn.Player1),
            AddPit(board, MancalaBucketId.Player1Pit5, PlayerTurn.Player1),
            AddPit(board, MancalaBucketId.Player1Pit6, PlayerTurn.Player1)
        };

        var p1Store = AddStore(board, MancalaBucketId.Player1Store, PlayerTurn.Player1);

        // Player 2 pits
        var p2Pits = new[]
        {
            AddPit(board, MancalaBucketId.Player2Pit1, PlayerTurn.Player2),
            AddPit(board, MancalaBucketId.Player2Pit2, PlayerTurn.Player2),
            AddPit(board, MancalaBucketId.Player2Pit3, PlayerTurn.Player2),
            AddPit(board, MancalaBucketId.Player2Pit4, PlayerTurn.Player2),
            AddPit(board, MancalaBucketId.Player2Pit5, PlayerTurn.Player2),
            AddPit(board, MancalaBucketId.Player2Pit6, PlayerTurn.Player2)
        };

        var p2Store = AddStore(board, MancalaBucketId.Player2Store, PlayerTurn.Player2);

        // Player 1 relations
        for (var i = 0; i < 6; i++)
        {
            MancalaBucket next = i < 5 ? p1Pits[i + 1] : p1Store;
            var cross = p2Pits[5 - i]; // 0↔5, 1↔4, etc.
            p1Pits[i].Setup_Relations(next, cross, p1Store);
        }

        // Player 2 relations
        for (var i = 0; i < 6; i++)
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

    private static MancalaPit AddPit(MancalaBoard board, MancalaBucketId id, PlayerTurn owner)
    {
        var pit = new MancalaPit(id, owner);
        board.Setup_AddBucket(id, pit);
        return pit;
    }

    private static MancalaStore AddStore(MancalaBoard board, MancalaBucketId id, PlayerTurn owner)
    {
        var store = new MancalaStore(id, owner);
        board.Setup_AddBucket(id, store);
        return store;
    }
}