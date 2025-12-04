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

        
        // setup bucket relations
        
        // Player 1
        // pit1
        p1Pit1.Setup_Relations(p1Pit2, p2Pit6, p1Store);
        
        // pit2
        p1Pit2.Setup_Relations(p1Pit3, p2Pit5, p1Store);
        
        // pit3
        p1Pit3.Setup_Relations(p1Pit4, p2Pit4, p1Store);
        
        // pit4
        p1Pit4.Setup_Relations(p1Pit5, p2Pit3, p1Store);
        
        // pit5
        p1Pit5.Setup_Relations(p1Pit6, p2Pit2, p1Store);
        
        // pit6
        p1Pit6.Setup_Relations(p1Store, p2Pit1, p1Store);
        
        // Player 2
        // pit1
        p2Pit1.Setup_Relations(p2Pit2, p1Pit6, p2Store);
        
        // pit2
        p2Pit2.Setup_Relations(p2Pit3, p1Pit5, p2Store);
        
        // pit3
        p2Pit3.Setup_Relations(p2Pit4, p1Pit4, p2Store);
        
        // pit4
        p2Pit4.Setup_Relations(p2Pit5, p1Pit3, p2Store);
        
        // pit5
        p2Pit5.Setup_Relations(p2Pit6, p1Pit2, p2Store);
        
        // pit6
        p2Pit6.Setup_Relations(p2Store, p1Pit1, p2Store);
        
        // stores
        p1Store.Setup_Relations(p2Pit1);
        p2Store.Setup_Relations(p1Pit1);
        
        return board;
    }
}
