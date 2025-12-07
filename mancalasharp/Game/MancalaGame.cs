using mancalasharp.Board;
using mancalasharp.Board.Elements;

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
        if (result != 0)
        {
            // handle valid
            MoveResult moveResult = MakePlayerMove(result);
            if (moveResult.GameOver) _gameOver = true;
            if (!moveResult.ExtraTurn) SwitchTurn();
        }
        else
        {
            _gameOver = true;
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

    /// <summary>
    /// Makes a move on the board for the current player, given the selected start pit (for that player)
    /// </summary>
    /// <param name="selectedPit">integer pit # from 1-6</param>
    /// <returns>MoveResult --> Whether player should get extra turn, whether game is over</returns>
    private MoveResult MakePlayerMove(int selectedPit)
    {
        var pitId = PitSelect.Get(_currentTurn, selectedPit);
        var pit = Board.GetPit(pitId);

        MancalaBucket endBucket = pit.Distribute(_currentTurn);
        
        // How do we know if player gets an extra turn?
        bool extraTurn = endBucket.StoneCount == 1 && endBucket.Owner == _currentTurn;

        MoveResult moveResult = new MoveResult(){ExtraTurn = extraTurn, GameOver = false};

        return moveResult;
    }

    private void SwitchTurn()
    {
        _currentTurn = _currentTurn.Opposite();
    }
}

public struct MoveResult
{
    public required  bool ExtraTurn { get; init; }
    public required bool GameOver { get; init; }   
}


