using mancalasharp.Board;
using mancalasharp.Board.Elements;

namespace mancalasharp;

public class MancalaGame
{
    private bool _gameOver;

    private PlayerTurn _turn = PlayerTurn.Player1;

    public MancalaGame()
    {
        Board = MancalaBoardBuilder.Build();
    }

    public MancalaBoard Board { get; }

    public void Run()
    {
        while (!_gameOver)
        {
            Board.PrintBoard();
            Console.WriteLine($"Turn: {_turn}");
            var result = GetUserPit();
            if (result > 0 && result <= 6)
            {
                // handle valid
                TogglePits(result);
                SwitchTurn();
            }
            else
            {
                _gameOver = true;
            }
        }
    }

    private int GetUserPit()
    {
        Console.Write($"{_turn} Enter a number: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var result))
            Console.WriteLine($"You entered the number: {result}");
        else
            Console.WriteLine("That was not a valid integer.");

        return result;
    }

    private void TogglePits(int selectedPit)
    {
        MancalaBucketId pitId;
        if (_turn == PlayerTurn.Player1)
        {
            if (selectedPit == 1)
                pitId = MancalaBucketId.Player1Pit1;
            else if (selectedPit == 2)
                pitId = MancalaBucketId.Player1Pit2;
            else if (selectedPit == 3)
                pitId = MancalaBucketId.Player1Pit3;
            else if (selectedPit == 4)
                pitId = MancalaBucketId.Player1Pit4;
            else if (selectedPit == 5)
                pitId = MancalaBucketId.Player1Pit5;
            else
                pitId = MancalaBucketId.Player1Pit6;
        }
        else
        {
            if (selectedPit == 1)
                pitId = MancalaBucketId.Player2Pit1;
            else if (selectedPit == 2)
                pitId = MancalaBucketId.Player2Pit2;
            else if (selectedPit == 3)
                pitId = MancalaBucketId.Player2Pit3;
            else if (selectedPit == 4)
                pitId = MancalaBucketId.Player2Pit4;
            else if (selectedPit == 5)
                pitId = MancalaBucketId.Player2Pit5;
            else
                pitId = MancalaBucketId.Player2Pit6;
        }

        var bucket = Board.GetBucket(pitId) as MancalaPit;

        bucket.Distribute();
    }

    private void SwitchTurn()
    {
        _turn = _turn == PlayerTurn.Player1 ? PlayerTurn.Player2 : PlayerTurn.Player1;
    }
}

public enum PlayerTurn
{
    Player1,
    Player2
}