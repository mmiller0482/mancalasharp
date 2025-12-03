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
        MancalaBucketId pitId = PitSelect.Get(_turn, selectedPit);
        MancalaPit? bucket = Board.GetBucket(pitId) as MancalaPit;

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