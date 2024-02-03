Console.WriteLine("             ");
Console.WriteLine($"   |   |    ");
Console.WriteLine($"---+---+---" );
Console.WriteLine($"   |   |    ");
Console.WriteLine($"---+---+---" );
Console.WriteLine($"   |   |    ");

while (TicTacToe.GameStatusChecker())
{
    TicTacToe.Player(1);

    TicTacToe.GameStatusChecker();

    if (TicTacToe.wonGame) { break; }

    TicTacToe.turnCounter++;

    if (TicTacToe.turnCounter == 9)
    {
        Console.WriteLine("Draw! Nobody wins.");
        break;
    }

    TicTacToe.Player(2);

    TicTacToe.GameStatusChecker();

    if (TicTacToe.wonGame) { break; }

    TicTacToe.turnCounter++;

    if (TicTacToe.turnCounter == 9)
    {
        Console.WriteLine("Draw! Nobody wins.");
        break;
    }
}

class TicTacToe
{
    public static int turnCounter = 0;
    public static bool wonGame;

    public static string[] gameBoard = new string[9] { " ", " ", " ", " ", " ", " ", " ", " ", " " };

    public static string[] row1 = { TicTacToe.gameBoard[6], TicTacToe.gameBoard[7], TicTacToe.gameBoard[8] };
    public static string[] row2 = { TicTacToe.gameBoard[3], TicTacToe.gameBoard[4], TicTacToe.gameBoard[5] };
    public static string[] row3 = { TicTacToe.gameBoard[0], TicTacToe.gameBoard[1], TicTacToe.gameBoard[2] };
    public static string[] column1 = { TicTacToe.gameBoard[6], TicTacToe.gameBoard[3], TicTacToe.gameBoard[0] };
    public static string[] column2 = { TicTacToe.gameBoard[7], TicTacToe.gameBoard[4], TicTacToe.gameBoard[1] };
    public static string[] column3 = { TicTacToe.gameBoard[8], TicTacToe.gameBoard[5], TicTacToe.gameBoard[2] };
    public static string[] diag1 = { TicTacToe.gameBoard[6], TicTacToe.gameBoard[4], TicTacToe.gameBoard[2] };
    public static string[] diag2 = { TicTacToe.gameBoard[8], TicTacToe.gameBoard[4], TicTacToe.gameBoard[0] };

    public static void UpdateGameState()
    {
        Console.WriteLine("                                                       ");
        Console.WriteLine($" {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} ");

        row1 = new string[3] { TicTacToe.gameBoard[6], TicTacToe.gameBoard[7], TicTacToe.gameBoard[8] };
        row2 = new string[3] { TicTacToe.gameBoard[3], TicTacToe.gameBoard[4], TicTacToe.gameBoard[5] };
        row3 = new string[3] { TicTacToe.gameBoard[0], TicTacToe.gameBoard[1], TicTacToe.gameBoard[2] };
        column1 = new string[3] { TicTacToe.gameBoard[6], TicTacToe.gameBoard[3], TicTacToe.gameBoard[0] };
        column2 = new string[3] { TicTacToe.gameBoard[7], TicTacToe.gameBoard[4], TicTacToe.gameBoard[1] };
        column3 = new string[3] { TicTacToe.gameBoard[8], TicTacToe.gameBoard[5], TicTacToe.gameBoard[2] };
        diag1 = new string[3] { TicTacToe.gameBoard[6], TicTacToe.gameBoard[4], TicTacToe.gameBoard[2] };
        diag2 = new string[3] { TicTacToe.gameBoard[8], TicTacToe.gameBoard[4], TicTacToe.gameBoard[0] };
    }

    public static bool ThreeInARow2(string[] arr)
    {
        if (arr[0] == arr[1] && arr[1] == arr[2] && arr[0] == "X")
        {
            Console.WriteLine("Player 1 has won the game. ");
            TicTacToe.wonGame = true;
            return true;
        }
        else if (arr[0] == arr[1] && arr[1] == arr[2] && arr[0] == "O")
        {
            Console.WriteLine("Player 2 has won the game. ");
            TicTacToe.wonGame = true;
            return true;
        }
        return false;
    }

    public static bool GameStatusChecker()
    {
        if (TicTacToe.ThreeInARow2(row1) ||
           (TicTacToe.ThreeInARow2(row2) ||
           (TicTacToe.ThreeInARow2(row3) ||
           (TicTacToe.ThreeInARow2(column1) ||
           (TicTacToe.ThreeInARow2(column2) ||
           (TicTacToe.ThreeInARow2(column3) ||
           (TicTacToe.ThreeInARow2(diag1) ||
           (TicTacToe.ThreeInARow2(diag2)))))))))
        {
            return false;
        }
        return true;
    }

    public static void Player(int index)
    {
        string character = (index == 1) ? "X" : "O";
        Console.WriteLine($"Player {index}, it is your turn. Use the number pad to select a location for an {character} to be placed.");
        int playerInput = Convert.ToInt32(Console.ReadLine());

        int oLocation = playerInput switch
        {
            1 => 0,
            2 => 1,
            3 => 2,
            4 => 3,
            5 => 4,
            6 => 5,
            7 => 6,
            8 => 7,
            9 => 8,
        };

        if (TicTacToe.gameBoard[oLocation] == " ")
        {
            TicTacToe.gameBoard[oLocation] = character;
            TicTacToe.UpdateGameState();
        }
        else Console.WriteLine("You cannot place an O in a square that already has an X or an O!");
    }

    // The below represents an overengineered method for seeing if the board has three in a row currently on it.

    /*public static bool ThreeInARow(string[] arr)
    {
        HashSet<string> set = new HashSet<string>();

        for (int i = 0; i < arr.Length; i++)
        {
            set.Add(arr[i]);
        }
        if ((set.Count == 1) && (set.Contains("X")))
        {
            Console.WriteLine("Player 1 has won the game. ");
            TicTacToe.wonGame = true;
            return true;
        }
        else if ((set.Count == 1) && (set.Contains("O")))
        {
            Console.WriteLine("Player 2 has won the game. ");
            TicTacToe.wonGame = true;
            return true;
        }
        return false;
    } 
    */
}