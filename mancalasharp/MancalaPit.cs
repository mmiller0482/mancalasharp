namespace mancalasharp;

public class MancalaPit : MancalaBucket
{
    private const int StoneCountDefault = 4;

    public MancalaPit(MancalaBucketId id) : base(id, StoneCountDefault)
    {
    }

    public MancalaPit(MancalaBucketId id, int stoneCount) : base(id, stoneCount)
    {
    }
}