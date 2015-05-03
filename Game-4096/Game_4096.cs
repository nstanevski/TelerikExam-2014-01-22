using System;
using System.Text;

class Game_4096
{
    private static int NUM_CELLS = 4;   //Number of cells per row/column
    private static int CELL_WDT = 5; //Widht in number of chars
    private static int CELL_HGT = 3; //Height in number of chars
    //Array holding the current state of the game
    private static int[,] array = new int[NUM_CELLS, NUM_CELLS];



    private static void SetupConsoleWindow()
    {
        Console.BufferHeight = Console.WindowHeight = 25;
        Console.BufferWidth = Console.WindowWidth = 40;
        Console.Title = "4096";
    }

    //Draws grid of size NUM_CELLS by NUM_CELLS 
    //using '-' and '|' as vertical and horizontal dividers.
    //each cell is CELL_HGT high and CELL_WDT wide
    private static void DrawGrid()
    {
        //total number of chars, incl. those used to draw border
        int totalChars = NUM_CELLS * CELL_WDT + NUM_CELLS + 1;

        string horLine = new string('-', totalChars);
        string emptyCell = '|' + new string(' ', CELL_WDT);
        StringBuilder row = new StringBuilder();
        for (int cellIndex = 0; cellIndex < NUM_CELLS; cellIndex++)
        {
            row.Append(emptyCell);
        }
        row.Append('|');

        for (int rowNum = 0; rowNum < NUM_CELLS; rowNum++)
        {
            Console.WriteLine(horLine);
            for (int cellHgt = 0; cellHgt < CELL_HGT; cellHgt++)
            {
                Console.WriteLine(row.ToString());
            }
        }
        Console.WriteLine(horLine);  
    }

    //Randomly generates either number 2 or number 4
    private static int Generate2or4()
    {
        // 2 is generated more often than 4.
        // 4 is generated 1/N of the times
        // Change constant N to adjust the frequency.
        const int N = 8;
        Random rnd = new Random();
        int val = rnd.Next(N);

        if (val < N-1)
            return 2;
        else
            return 4;
    }

    //finds random empty position within the array
    private static void FindRandomEmptyPosition(out int row, out int col)
    {
        Random rnd = new Random();       
        do
        {
            row = rnd.Next(NUM_CELLS);
            col = rnd.Next(NUM_CELLS);
        } while (array[row, col] > 0);

    }

    //Initializes array with two random numbers (either 2 or 4)
    //at two random empty positions
    private static void InitArray()
    {
        for (int i = 0; i < 2; i++)
        {
            int num = Generate2or4();
            int row=0, col=0;
            FindRandomEmptyPosition(out row, out col);
            array[row, col] = num;
        }
    }

    

    private static void DrawArray()
    {
        //TODO:
    }



    static void Main()
    {
        SetupConsoleWindow();
        DrawGrid();
        InitArray();
        DrawArray();
        Console.SetCursorPosition(2, 2);
        Console.Write("2048");
    }



    

    
}