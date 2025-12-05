using mancalasharp.Board;

namespace mancalasharp.Game;

public class MancalaGame
{
    private bool _gameOver;

    private PlayerId _currentTurn = PlayerId.Player1;

    public MancalaBoard Board { get; } = MancalaBoardBuilder.Build();

    public void Run()
    {
        while (!_gameOver)
        {
            MancalaBoardPrinter.Print(Board);
            Console.WriteLine($"Turn: {_currentTurn.ToDisplayString()}");
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
        Console.Write($"{_currentTurn} Enter a number: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var result))
            Console.WriteLine($"You entered the number: {result}");
        else
            Console.WriteLine("That was not a valid integer.");

        return result;
    }

    private void TogglePits(int selectedPit)
    {
        var pitId = PitSelect.Get(_currentTurn, selectedPit);
        var pit = Board.GetPit(pitId);

        pit.Distribute(_currentTurn);
    }

    private void SwitchTurn()
    {
        _currentTurn = _currentTurn.Opposite();
    }
}