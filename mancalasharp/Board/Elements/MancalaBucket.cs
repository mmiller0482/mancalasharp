using mancalasharp.Game;

namespace mancalasharp.Board.Elements;

public abstract class MancalaBucket
{
    protected MancalaBucket(MancalaBucketId id, PlayerTurn owner, int stoneCount)
    {
        Id = id;
        StoneCount = stoneCount;
        Owner = owner;
    }

    public PlayerTurn Owner { get; init; }
    public int StoneCount { get; protected set; }
    public MancalaBucketId Id { get; init; }
    public MancalaBucket NextBucket { get; private set; }

    // TODO: Do we actually need to support n number of new stones, or just singular? 
    public void AddStones(int numNewStones)
    {
        StoneCount += numNewStones;
    }

    public void Setup_Relations(MancalaBucket nextBucket)
    {
        NextBucket = nextBucket;
    }
}
