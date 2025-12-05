using mancalasharp.Game;

namespace mancalasharp.Board.Elements;

public class MancalaPit : MancalaBucket
{
    private const int StoneCountDefault = 4;

    public MancalaPit(MancalaBucketId id, PlayerId owner) : base(id, owner, StoneCountDefault)
    {
    }

    public MancalaPit(MancalaBucketId id, PlayerId owner, int stoneCount) : base(id, owner, stoneCount)
    {
    }

    public MancalaBucket CrossBucket { get; private set; }

    public MancalaBucket MyStore { get; private set; }

    public void Setup_Relations(MancalaBucket nextBucket, MancalaBucket crossBucket, MancalaBucket myStore)
    {
        base.Setup_Relations(nextBucket);
        CrossBucket = crossBucket;
        MyStore = myStore;
    }

    public MancalaBucket Distribute(PlayerId currentPlayer)
    {
        int stones = TakeAllStones();
        if (stones == 0)
            return this; // no-op, but board should treat starting from empty as invalid

        MancalaBucket current = NextBucket;
        MancalaBucket last = null;

        while (stones > 0)
        {
            // Skip opponent's store
            if (current is MancalaStore store && store.Owner != currentPlayer)
            {
                current = current.NextBucket;
                continue;
            }

            // TODO: We should probably just remove AddStones for AddStone with no arg
            current.AddStones(1); 
            last = current;
            stones--;

            if (stones > 0)
                current = current.NextBucket;
        }

        return last!;
    }

    public int TakeAllStones()
    {
        var stones = StoneCount;
        StoneCount = 0;
        return stones;
    }
}