using mancalasharp.Board;
using mancalasharp.Board.Elements;

namespace mancalasharp.Game;

public class MancalaGame
{
    private bool _gameOver;

    private PlayerTurn _turn = PlayerTurn.Player1;

    public MancalaBoard Board { get; } = MancalaBoardBuilder.Build();

    public void Run()
    {
        while (!_gameOver)
        {
            MancalaBoardPrinter.Print(Board);
            Console.WriteLine($"Turn: {_turn.ToDisplayString()}");
            var result = GetUserPitRequest();
            if (result is > 0 and <= 6)
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

    private int GetUserPitRequest()
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
        MancalaPit pit = Board.GetPit(pitId);

        pit.Distribute();
    }

    private void SwitchTurn()
    {
        _turn = _turn.Opposite();
    }
}
