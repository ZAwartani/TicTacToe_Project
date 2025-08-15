using System;

class TicTacToe
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char currentPlayer = 'X';
    static int moves = 0;

    static void Main()
    {
        bool gameWon = false;

        while (!gameWon && moves < 9)
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine($"Player {currentPlayer}, choose a position (1-9): ");
            string input = Console.ReadLine();

            if (PlaceMarker(input))
            {
                moves++;
                gameWon = CheckWin();

                if (!gameWon)
                    SwitchPlayer();
            }
            else
            {
                Console.WriteLine("Invalid move. Press Enter to try again...");
                Console.ReadLine();
            }
        }

        Console.Clear();
        DrawBoard();
        if (gameWon)
            Console.WriteLine($"🎉 Player {currentPlayer} wins!");
        else
            Console.WriteLine("🤝 It's a draw!");
    }

    static void DrawBoard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}  ");
        Console.WriteLine("     |     |     ");
    }

    static bool PlaceMarker(string input)
    {
        if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = currentPlayer;
                return true;
            }
        }
        return false;
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool CheckWin()
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;
        }

        // Check diagonals
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }
}
