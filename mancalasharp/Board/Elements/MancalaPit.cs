namespace mancalasharp.Board.Elements;

public class MancalaPit : MancalaBucket
{
    private const int StoneCountDefault = 4;

    public MancalaPit(MancalaBucketId id) : base(id, StoneCountDefault)
    {
    }

    public MancalaPit(MancalaBucketId id, int stoneCount) : base(id, stoneCount)
    {
    }
    
    public MancalaBucket CrossBucket { get; private set; }
    
    public MancalaBucket MyPit { get; private set; }
    
    public void SetCrossBucket(MancalaBucket crossBucket) => CrossBucket = crossBucket;
    public void SetMyStore(MancalaBucket myPit) => MyPit = myPit;
}