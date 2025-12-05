using mancalasharp.Board.Elements;
using mancalasharp.Game;

namespace mancalasharp.Test;

public class MancalaStoreTest
{
    [Fact]
    public void MancalaStore_InstantiatedWith_0Stones()
    {
        // Arrange and Act
        MancalaStore myStore = new MancalaStore(MancalaBucketId.Player1Store, PlayerTurn.Player1);
        // Assert
        Assert.Equal(0, myStore.StoneCount);
    }
}