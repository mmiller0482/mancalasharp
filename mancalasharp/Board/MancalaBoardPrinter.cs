using mancalasharp.Board.Elements;

namespace mancalasharp.Board;

public static class MancalaBoardPrinter
{
    public static void Print(MancalaBoard board)
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

        // Top pits row
        Console.Write("           ");
        foreach (var id in p2Row)
        {
            var bucket = board.GetBucket(id);
            Console.Write($"| {ShortName(id),3}:{bucket.StoneCount,2} ");
        }

        Console.WriteLine("|");
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");

        var p2Store = board.GetBucket(p2StoreId);
        var p1Store = board.GetBucket(p1StoreId);

        Console.WriteLine("+---------+-------------------------------------------------+---------+");
        Console.WriteLine(
            $"| {ShortName(p2StoreId),3}:{p2Store.StoneCount,2} |                                                 | {ShortName(p1StoreId),3}:{p1Store.StoneCount,2} |");
        Console.WriteLine("+---------+-------------------------------------------------+---------+");

        // Bottom pits row
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");
        Console.Write("           ");
        foreach (var id in p1Row)
        {
            var bucket = board.GetBucket(id);
            Console.Write($"| {ShortName(id),3}:{bucket.StoneCount,2} ");
        }

        Console.WriteLine("|");
        Console.WriteLine("           +---------+---------+---------+---------+---------+---------+");
        Console.WriteLine("                --- Player 1 ---");
        Console.WriteLine();
    }

    private static string ShortName(MancalaBucketId id)
    {
        var s = id.ToString();
        s = s.Replace("Player", "P")
            .Replace("Pit", "P")
            .Replace("Store", "S");
        return s;
    }
}