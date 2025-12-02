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
        p1Pit1.SetNextBucket(p1Pit2);
        p1Pit1.SetCrossBucket(p2Pit6);
        p1Pit1.SetMyStore(p1Store);
        
        // pit2
        p1Pit2.SetNextBucket(p1Pit3);
        p1Pit2.SetCrossBucket(p2Pit5);
        p1Pit2.SetMyStore(p1Store);
        
        // pit3
        p1Pit3.SetNextBucket(p1Pit4);
        p1Pit3.SetCrossBucket(p2Pit4);
        p1Pit3.SetMyStore(p1Store);
        
        // pit4
        p1Pit4.SetNextBucket(p1Pit5);
        p1Pit4.SetCrossBucket(p2Pit3);
        p1Pit4.SetMyStore(p1Store);
        
        // pit5
        p1Pit5.SetNextBucket(p1Pit6);
        p1Pit5.SetCrossBucket(p2Pit2);
        p1Pit5.SetMyStore(p1Store);
        
        // pit6
        p1Pit6.SetNextBucket(p1Store);
        p1Pit6.SetCrossBucket(p2Pit1);
        p1Pit6.SetMyStore(p1Store);
        
        // Player 2
        // pit1
        p2Pit1.SetNextBucket(p2Pit2);
        p2Pit1.SetCrossBucket(p1Pit6);
        p2Pit1.SetMyStore(p2Store);
        
        // pit2
        p2Pit2.SetNextBucket(p2Pit3);
        p2Pit2.SetCrossBucket(p1Pit5);
        p2Pit2.SetMyStore(p2Store);
        
        // pit3
        p2Pit3.SetNextBucket(p2Pit4);
        p2Pit3.SetCrossBucket(p1Pit4);
        p2Pit3.SetMyStore(p2Store);
        
        // pit4
        p2Pit4.SetNextBucket(p2Pit5);
        p2Pit4.SetCrossBucket(p1Pit3);
        p2Pit4.SetMyStore(p2Store);
        
        // pit5
        p2Pit5.SetNextBucket(p2Pit6);
        p2Pit5.SetCrossBucket(p1Pit2);
        p2Pit5.SetMyStore(p2Store);
        
        // pit6
        p2Pit6.SetNextBucket(p2Store);
        p2Pit6.SetCrossBucket(p1Pit1);
        p2Pit6.SetMyStore(p2Store);
        
        // stores
        p1Store.SetNextBucket(p2Pit1);
        p2Store.SetNextBucket(p1Pit1);
        
        return board;
    }
}
