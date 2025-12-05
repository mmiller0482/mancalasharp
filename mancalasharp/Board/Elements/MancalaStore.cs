using mancalasharp.Game;

namespace mancalasharp.Board.Elements;

/// <summary>
///     A player's store of stones. May not be tampered with except through adding stones.
/// </summary>
public class MancalaStore : MancalaBucket
{
    private const int StoneCountDefault = 0;

    public MancalaStore(MancalaBucketId id, PlayerId owner) : base(id, owner, StoneCountDefault)
    {
    }

    public MancalaStore(MancalaBucketId id, PlayerId owner, int stoneCount) : base(id, owner, stoneCount)
    {
    }
}