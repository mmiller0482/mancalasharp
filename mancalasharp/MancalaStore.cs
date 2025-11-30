namespace mancalasharp;

/// <summary>
/// A player's store of stones. May not be tampered with except through adding stones.
/// </summary>
public class MancalaStore : MancalaBucket
{
    
    private const int StoneCountDefault = 0;
    public MancalaStore(MancalaBucketId id) : base(id, StoneCountDefault)
    {
    }
    
    public MancalaStore(MancalaBucketId id, int stoneCount) : base(id, stoneCount)
    {
    }
    
}