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
            TakeTurn();
        }
    }

    private void TakeTurn()
    {
        var result = GetUserPitRequest();
        if (result == 0) 
        {
            _gameOver = true;
        }
        else
        {
            // handle valid
            TogglePits(result);
            SwitchTurn();
        }
    }

    /// <summary>
    /// Get user input for pit selection. Will keep asking until valid input is given.
    /// Returns 0 if user wishes to exit.
    /// </summary>
    /// <returns> user pit selection, or 0 for exit</returns>
    private int GetUserPitRequest()
    {
        while (true)
        {
            Console.Write($"{_currentTurn} Enter which pit to move stones from (1-6), or 0 to quit: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("That was not a valid integer. Try again!");
                continue;
            }

            if (result is < 0 or > 6)
            {
                Console.WriteLine("Invalid pit number. Please enter 1–6, or 0 for exit.");
                continue;
            }

            Console.WriteLine($"You entered the number: {result}");
            return result; // 0..6 only
        }
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