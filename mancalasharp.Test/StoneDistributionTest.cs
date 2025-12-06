using mancalasharp.Board;
using mancalasharp.Board.Elements;
using mancalasharp.Game;

namespace mancalasharp.Test;

public class MancalaDistributionTests
{
    // Adjust this to match your enum values / order.
    // This encodes the *intended* ring layout.
    private static readonly MancalaBucketId[] RingOrder =
    {
        MancalaBucketId.Player1Pit1,
        MancalaBucketId.Player1Pit2,
        MancalaBucketId.Player1Pit3,
        MancalaBucketId.Player1Pit4,
        MancalaBucketId.Player1Pit5,
        MancalaBucketId.Player1Pit6,
        MancalaBucketId.Player1Store,
        MancalaBucketId.Player2Pit1,
        MancalaBucketId.Player2Pit2,
        MancalaBucketId.Player2Pit3,
        MancalaBucketId.Player2Pit4,
        MancalaBucketId.Player2Pit5,
        MancalaBucketId.Player2Pit6,
        MancalaBucketId.Player2Store
    };

    [Fact]
    public void InitialBoard_HasExpectedStoneCounts()
    {
        var board = MancalaBoardBuilder.Build();
        var counts = GetStoneCounts(board);

        // Assuming standard Kalah: 4 stones per pit, 0 per store.
        foreach (var id in RingOrder)
            if (IsPit(id))
                Assert.Equal(4, counts[id]);
            else
                Assert.Equal(0, counts[id]);

        Assert.Equal(4 * 12, counts.Values.Sum());
    }

    [Theory]
    [InlineData(MancalaBucketId.Player1Pit1)]
    [InlineData(MancalaBucketId.Player1Pit2)]
    [InlineData(MancalaBucketId.Player1Pit3)]
    [InlineData(MancalaBucketId.Player1Pit4)]
    [InlineData(MancalaBucketId.Player1Pit5)]
    [InlineData(MancalaBucketId.Player1Pit6)]
    [InlineData(MancalaBucketId.Player2Pit1)]
    [InlineData(MancalaBucketId.Player2Pit2)]
    [InlineData(MancalaBucketId.Player2Pit3)]
    [InlineData(MancalaBucketId.Player2Pit4)]
    [InlineData(MancalaBucketId.Player2Pit5)]
    [InlineData(MancalaBucketId.Player2Pit6)]
    public void Distribute_FromEachPit_ProducesExpectedBoard(MancalaBucketId startPitId)
    {
        // Arrange
        var board = MancalaBoardBuilder.Build();
        var initialCounts = GetStoneCounts(board);

        var startPit = board.GetPit(startPitId);
        var stonesToSow = initialCounts[startPitId];

        // Sanity: we should be starting from a pit, not a store
        Assert.True(IsPit(startPitId));
        Assert.True(stonesToSow > 0);

        // Act
        startPit.Distribute(startPitId.GetCorrespondingPlayerId());

        var finalCounts = GetStoneCounts(board);

        // Assert total stones preserved
        Assert.Equal(initialCounts.Values.Sum(), finalCounts.Values.Sum());

        // Assert starting pit is now empty
        Assert.Equal(0, finalCounts[startPitId]);

        // Build expected counts based on ring order logic
        var expectedCounts = new Dictionary<MancalaBucketId, int>(initialCounts);

        // Remove all stones from the starting pit
        expectedCounts[startPitId] -= stonesToSow;

        // Sow one stone into each subsequent bucket along the ring
        // NOTE: from the initial state with 4 stones, we never hit the opponent's store,
        // so no skip-opponent-store behavior is needed for these tests.
        var startIndex = Array.IndexOf(RingOrder, startPitId);
        Assert.True(startIndex >= 0, "Start pit must exist in ring order.");

        for (var k = 1; k <= stonesToSow; k++)
        {
            var idx = (startIndex + k) % RingOrder.Length;
            var targetId = RingOrder[idx];
            expectedCounts[targetId]++;
        }

        // Compare each bucket
        foreach (var id in RingOrder) Assert.Equal(expectedCounts[id], finalCounts[id]);
    }

    // Helpers

    private static Dictionary<MancalaBucketId, int> GetStoneCounts(MancalaBoard board)
    {
        return RingOrder.ToDictionary(
            id => id,
            id => board.GetBucket(id).StoneCount // <-- adjust if your property is named differently
        );
    }

    private static bool IsPit(MancalaBucketId id)
    {
        return id is MancalaBucketId.Player1Pit1
            or MancalaBucketId.Player1Pit2
            or MancalaBucketId.Player1Pit3
            or MancalaBucketId.Player1Pit4
            or MancalaBucketId.Player1Pit5
            or MancalaBucketId.Player1Pit6
            or MancalaBucketId.Player2Pit1
            or MancalaBucketId.Player2Pit2
            or MancalaBucketId.Player2Pit3
            or MancalaBucketId.Player2Pit4
            or MancalaBucketId.Player2Pit5
            or MancalaBucketId.Player2Pit6;
    }
    
}