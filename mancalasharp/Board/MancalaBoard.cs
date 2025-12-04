using mancalasharp.Board.Elements;

namespace mancalasharp.Board;


public class MancalaBoard
{
    private readonly Dictionary<MancalaBucketId, MancalaBucket> _buckets = new();

    public void Setup_AddBucket(MancalaBucketId id, MancalaBucket bucket)
    {
        _buckets.Add(id, bucket);
    }
    
    public MancalaBucket GetBucket(MancalaBucketId id) => _buckets[id];
}