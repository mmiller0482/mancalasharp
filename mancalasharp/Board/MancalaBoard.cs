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

    public MancalaPit GetPit(MancalaBucketId id)
    {
        var bucket = _buckets[id];
        if (bucket is not MancalaPit pit)
            throw new InvalidOperationException($"Bucket {id} is not a Pit");
        return pit;
    }

    public MancalaStore GetStore(MancalaBucketId id)
    {
        var bucket = _buckets[id];
        if (bucket is not MancalaStore store)
            throw new InvalidOperationException($"Bucket {id} is not a Store");
        return store;
    }
}