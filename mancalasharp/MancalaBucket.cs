namespace mancalasharp;

public abstract class MancalaBucket
{
    public int StoneCount { get; private set; }
    public MancalaBucketId Id { get; init; }

    protected MancalaBucket(MancalaBucketId id, int stoneCount)
    {
        Id = id;
        StoneCount = stoneCount;
    }
    
    public void AddStones(int numNewStones) => StoneCount += numNewStones;
}