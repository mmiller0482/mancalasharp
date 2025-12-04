using mancalasharp.Board;
using mancalasharp.Board.Elements;

namespace mancalasharp.Game;

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
            MancalaBoardPrinter.Print(Board);
            Console.WriteLine($"Turn: {_turn.ToDisplayString()}");
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
        _turn = _turn.Opposite();
    }
}
