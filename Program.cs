using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        //making array of 9 indexes 1-9,
        static char[] arr = { '1','2', '3', '4', '5', '6', '7', '8', '9'};
        static int player = 1; //By default player 1 is set, that is the player that will start the game
        static int choice; //This holds the choice at which position user want to mark
        // The gameRunning variable checks who has won if it's value is 1 then someone has won the match
        //if -1 then Match has Draw if 0 then match is still running
        static int gameRunning = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();// whenever loop will be again start then screen will be clear
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//checking the chance of the player
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Board();// calling the board Function
                choice = int.Parse(Console.ReadLine());//Taking users choice
                choice = choice -1;
                // checking that position where user want to run is marked (with X or O) or not
                if (choice >= 0 && choice <= 8){
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //if chance is of player 2 then mark O else mark X
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                
                else
                //If there is any possition where user want to run
                //and that is already marked then show message and load board again
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait while the board loads again.....");
                    Thread.Sleep(4000);
                }
                gameRunning = CheckWin();// calling of check win
                
            }
            else {
                Console.WriteLine("Please Enter a number between 0 and 8");
            }}
            while (gameRunning != 1 && gameRunning != -1);
            // This loop will be run until all cell of the grid is not marked
            //with X and O or some player is not win
            Console.Clear();// clearing the console
            Board();// getting filled board again
            if (gameRunning == 1)
            // if gameRunning value is 1 then someone has win or
            //means who played marked last time which has win
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else// if gameRunning value is -1 the match will be draw and no one is winner
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        // Board method which creats board
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0], arr[1], arr[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[3], arr[4], arr[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[6], arr[7], arr[8]);
            Console.WriteLine("     |     |      ");
        }
        //Checking that any player has won or not
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (arr[3] == arr[4] && arr[4] == arr[5])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (arr[5] == arr[6] && arr[6] == arr[7])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (arr[0] == arr[3] && arr[3] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[0] == arr[4] && arr[4] == arr[8])
            {
                return 1;
            }
            else if (arr[2] == arr[4] && arr[4] == arr[6])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match
            else if (arr[0] != '1' && arr[1] != '2' && arr[2] != '3' && arr[3] != '4' && arr[4] != '5' && arr[5] != '6' && arr[6] != '7' && arr[7] != '8' && arr[8] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}
