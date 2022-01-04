using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ce103_hw5_snake_dll;

namespace ce103_hw5_snake_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 snakeGameFunctions = new Class1();
           
            snakeGameFunctions.WelcomeArt();
            do
            {
                switch (snakeGameFunctions.MainMenu())
                {
                    case 0:
                        snakeGameFunctions.LoadGame();
                        break;
                    //case 1:
                     //snakeGameFunctions.displayHighScores();
                       // break;
                    case 2:
                        snakeGameFunctions.Controls();
                        break;
                    case 3:
                        snakeGameFunctions.ExitYN();
                        break;
                }
            } while (true);
        }
    }
}
