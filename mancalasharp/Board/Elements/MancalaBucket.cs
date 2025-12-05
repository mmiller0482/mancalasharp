using mancalasharp.Game;

namespace mancalasharp.Board.Elements;

public abstract class MancalaBucket
{
    protected MancalaBucket(MancalaBucketId id, PlayerId owner, int stoneCount)
    {
        Id = id;
        StoneCount = stoneCount;
        Owner = owner;
    }

    public PlayerId Owner { get; init; }
    public int StoneCount { get; protected set; }
    public MancalaBucketId Id { get; init; }
    public MancalaBucket NextBucket { get; private set; }

    // TODO: We should probably just remove AddStones for AddStone with no arg
    public void AddStones(int numNewStones)
    {
        StoneCount += numNewStones;
    }

    public void Setup_Relations(MancalaBucket nextBucket)
    {
        NextBucket = nextBucket;
    }
}