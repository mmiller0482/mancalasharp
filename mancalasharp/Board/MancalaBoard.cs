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

    public void PrintBoard()
    {
        // Upper row (Player 2 pits, right-to-left)
        var p2Row = new[]
        {
            MancalaBucketId.Player2Pit6,
            MancalaBucketId.Player2Pit5,
            MancalaBucketId.Player2Pit4,
            MancalaBucketId.Player2Pit3,
            MancalaBucketId.Player2Pit2,
            MancalaBucketId.Player2Pit1
        };

        // Lower row (Player 1 pits, left-to-right)
        var p1Row = new[]
        {
            MancalaBucketId.Player1Pit1,
            MancalaBucketId.Player1Pit2,
            MancalaBucketId.Player1Pit3,
            MancalaBucketId.Player1Pit4,
            MancalaBucketId.Player1Pit5,
            MancalaBucketId.Player1Pit6
        };

        var p2StoreId = MancalaBucketId.Player2Store;
        var p1StoreId = MancalaBucketId.Player1Store;

        Console.WriteLine();
        Console.WriteLine("                --- Player 2 ---");
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");

        // Top pits: labels + counts
        Console.Write("           ");
        foreach (var id in p2Row)
        {
            var bucket = _buckets[id];
            Console.Write($"| {ShortName(id),3}:{bucket.StoneCount,2} ");
        }

        Console.WriteLine("|");
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");

        // Stores row: labels + counts
        var p2Store = _buckets[p2StoreId];
        var p1Store = _buckets[p1StoreId];

        Console.WriteLine("+---------+-------------------------------------------------+---------+");
        Console.WriteLine(
            $"| {ShortName(p2StoreId),3}:{p2Store.StoneCount,2} |                                                 | {ShortName(p1StoreId),3}:{p1Store.StoneCount,2} |");
        Console.WriteLine("+---------+-------------------------------------------------+---------+");

        // Bottom pits: labels + counts
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");
        Console.Write("           ");
        foreach (var id in p1Row)
        {
            var bucket = _buckets[id];
            Console.Write($"| {ShortName(id),3}:{bucket.StoneCount,2} ");
        }

        Console.WriteLine("|");
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");
        Console.WriteLine("                --- Player 1 ---");
        Console.WriteLine();
    }

    /// <summary>
    ///     Helper to shorten enum names, e.g. Player1Pit3 -> P1P3, Player2Store -> P2S
    /// </summary>
    private static string ShortName(MancalaBucketId id)
    {
        // Adjust this to taste based on your actual enum names
        var s = id.ToString(); // e.g. "Player1Pit3"
        s = s.Replace("Player", "P") // "P1Pit3"
            .Replace("Pit", "P") // "P1P3"
            .Replace("Store", "S"); // "P1S"
        return s;
    }
}