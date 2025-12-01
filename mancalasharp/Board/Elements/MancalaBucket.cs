namespace mancalasharp.Board.Elements;

public abstract class MancalaBucket
{
    protected MancalaBucket(MancalaBucketId id, int stoneCount)
    {
        Id = id;
        StoneCount = stoneCount;
    }

    public int StoneCount { get; private set; }
    public MancalaBucketId Id { get; init; }

    public void AddStones(int numNewStones)
    {
        StoneCount += numNewStones;
    }
}