/**************************
 * Copyleft (L) 2021 CENG - All Rights Not Reserved
 * You may use, distribute and modify this code.
 **************************/

/**
 * @file ce103-hw5-snake-dll
 * @author Resul BESER
 * @date 04 January 2022
 *
 * @brief <b> HW-5 Functions </b>
 *
 * HW-5 Sample Lib Functions
 *
 * @see http://bilgisayar.mmf.erdogan.edu.tr/en/
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ce103_hw5_snake_dll
{
    public class Class1
    {
        //First we need to define ConsoleKey and then assign the keys.
        //We have defined the variables, now let's assign the values.
        public const int SNAKE_ARRAY_SIZE = 310;
        public const ConsoleKey UP_ARROW = ConsoleKey.UpArrow;
        public const ConsoleKey LEFT_ARROW = ConsoleKey.LeftArrow;
        public const ConsoleKey RIGHT_ARROW = ConsoleKey.RightArrow;
        public const ConsoleKey DOWN_ARROW = ConsoleKey.DownArrow;
        public const ConsoleKey ENTER_KEY = ConsoleKey.Enter;
        // esc means exit button
        public const ConsoleKey EXIT_BUTTON = ConsoleKey.Escape;
        // pause button means p. p key.
        public const ConsoleKey PAUSE_BUTTON = ConsoleKey.P;
        const char SNAKE_HEAD = (char)177;
        const char SNAKE_BODY = (char)178;
        const char WALL = (char)219;
        const char FOOD = (char)254;
        const char BLANK = ' ';

        /**
         * @name waitForAnyKey
         * 
         * 
         **/

        public ConsoleKey WaitForAnyKey()
        {
            ConsoleKey pressed;

            while (!Console.KeyAvailable) ;
            pressed = Console.ReadKey(false).Key;
            return pressed;
        }
        /**
         * @name GetGameSpeed
         * 
         **/

        public int GetGameSpeed()
        {
            //speed is equal to 50
            int speed = 10;
            //clear the function
            Console.Clear();
            Console.SetCursorPosition(10, 5);
            Console.Write("Select The game speed between 1 and 9, and press enter.\n");
            //Press a number between 1 and 9 to start the game.
            //Because Convert.ToInt ie integer is used.
            int pressed = Convert.ToInt32(Console.ReadLine());
            
            switch (pressed)
            {
                case 1:
                    //When you press the number 1, the speed is 100ms.
                    speed = 85;
                    break;
                case 2:
                    //When you press the number 2, the speed is 90ms.
                    speed = 75;
                    break;
                case 3:
                    //When you press the number 3, the speed is 80ms.
                    speed = 65;
                    break;
                case 4:
                    //When you press the number 4, the speed is 70ms.
                    speed = 55;
                    break;
                case 5:
                    //When you press the number 5, the speed is 60ms.
                    speed = 45;
                    break;
                case 6:
                    //When you press the number 6, the speed is 50ms.
                    speed = 35;
                    break;
                case 7:
                    //When you press the number 7, the speed is 40ms.
                    speed = 25;
                    break;
                case 8:
                    //When you press the number 8, the speed is 30ms.
                    speed = 15;
                    break;
                case 9:
                    //When you press the number 9, the speed is 20ms.
                    speed = 5;
                    break;
            }
            return speed;
        }
        /**
         * @name PauseMenu 
         * 
         */
        public void PauseMenu()
        {
            
            Console.SetCursorPosition(28, 23);
            Console.Write("**Paused**");

            WaitForAnyKey();
            Console.SetCursorPosition(28, 23);
            Console.Write("            ");

            return;
        }
        /**
         * @name CheckKeysPressed
         * @param [in] direction [\b ConsoleKey]
         * 
         **/
        ConsoleKey CheckKeysPressed(ConsoleKey direction)
        {
            ConsoleKey pressed;          
            //If a key has been pressed
            if (Console.KeyAvailable) 
            {               
                pressed = Console.ReadKey(false).Key;
                if (direction != pressed)
                {                  
                    if (pressed == DOWN_ARROW && direction != UP_ARROW)
                        direction = pressed;
                    else if (pressed == UP_ARROW && direction != DOWN_ARROW)
                        direction = pressed;
                    else if (pressed == LEFT_ARROW && direction != RIGHT_ARROW)
                        direction = pressed;
                    else if (pressed == RIGHT_ARROW && direction != LEFT_ARROW)
                        direction = pressed;
                    else if (pressed == EXIT_BUTTON || pressed == PAUSE_BUTTON)
                        PauseMenu();
                }
            }
            return (direction);
        }
        // It should return true or false.1=true. 0=false.

        /**
         * @name CollisionSnake
         * 
         * @param [in] x [\b int]
         * 
         * @param [in] y [\b int]
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] snakeLenght [\b int]
         * 
         * @param [in] detect [\b int]
         * 
         **/
        public bool CollisionSnake(int x, int y, int[,] snakeXY, int snakeLength, int detect)
        {
            int i;
            //Checks if the snake collided with itself
            for (i = detect; i < snakeLength; i++) 
            {
                if (x == snakeXY[0,i] && y == snakeXY[1,i])
                    return true;
            }
            return false;
        }

        /**
         * @name generateFood
         *  
         * @param [in] foodXY [\b int[]]
         * 
         * @param [in] width  [\b int]
         * 
         * @param [in] height [\b int]
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] snakeLength [\b int]
         **/
        public int GenerateFood(int[] foodXY, int width, int height, int[,] snakeXY, int snakeLength)
        {                   
            Random random = new Random();
            do
            {
                foodXY[0] = random.Next() % (width - 2) + 2;
                foodXY[1] = random.Next() % (height - 6) + 2;
              //This should prevent the "Food" from being created on top of the snake. - However the food has a chance to be created ontop of the snake, in which case the snake should eat it... 
            } while (CollisionSnake(foodXY[0], foodXY[1], snakeXY, snakeLength, 0)); 

            Console.SetCursorPosition(foodXY[0], foodXY[1]);
            Console.Write(FOOD);

            return (0);
        }
        /**
         * @name moveSnakeArray
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] snakeLenght [\b int]
         **/
        public void MoveSnakeArray(int[,]snakeXY, int snakeLength, ConsoleKey direction)
        {
            int i;
            for (i = snakeLength - 1; i >= 1; i--)
            {
                snakeXY[0,i] = snakeXY[0,i - 1];
                snakeXY[1,i] = snakeXY[1,i - 1];
            }

            /*
            because we dont actually know the new snakes head x y, 
            we have to check the direction and add or take from it depending on the direction.
            */
            
            switch (direction)
            {
                case DOWN_ARROW:
                    snakeXY[1,0]++;
                    break;
                case RIGHT_ARROW:
                    snakeXY[0,0]++;
                    break;
                case UP_ARROW:
                    snakeXY[1,0]--;
                    break;
                case LEFT_ARROW:
                    snakeXY[0,0]--;
                    break;
            }

            return;
        }
    /**
     * @name Move
     * 
     * @param [in]snakeXY [\b int[,]]
     * 
     * @param [in] snakeLenght [\b int]
     * 
     **/



        public void Move(int[,] snakeXY, int snakeLength, ConsoleKey direction)
        {
            int x;
            int y;
            
            //Remove the tail 
            x = snakeXY[0, snakeLength - 1];
            y = snakeXY[1, snakeLength - 1];

            Console.SetCursorPosition(x, y);
            Console.Write(BLANK);

            //Changes the head of the snake to a body part
            Console.SetCursorPosition(snakeXY[0,0], snakeXY[1,0]);
            Console.Write(SNAKE_BODY);

            MoveSnakeArray(snakeXY, snakeLength, direction);

            Console.SetCursorPosition(snakeXY[0,0], snakeXY[1,0]);
            Console.Write(SNAKE_HEAD);
            //Gets rid of the darn flashing underscore.
            Console.SetCursorPosition(1, 1); 

            return;
        }
        // definition of one-dimensional arrays.
        // eatFood should be bool and return true false.


        /**
         * 
         * @name eatFood
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] foodXY [\b int[]]
         * 
         **/
        public bool EatFood(int[,] snakeXY, int[] foodXY)
        {
            if (snakeXY[0,0] == foodXY[0] && snakeXY[1,0] == foodXY[1])
            {
                foodXY[0] = 0;
                //This should prevent a nasty bug (loops) need to check if the bug still exists...
                foodXY[1] = 0; 

      
                return true;
            }

            return false;
        }
        
        /** 
         * @name collisionDetection
         * 
         * @param [in] snakeXY [\b int[]]
         * 
         * @param [in] consoleWidth [\b int]
         * 
         * @param [in] consoleHeight [\b int]
         * 
         * @param [in] snakeLenght [\b int]
         * 
         * 
         **/

        public bool CollisionDetection(int[,] snakeXY, int consoleWidth, int consoleHeight, int snakeLength) 
        {
            bool colision = false;
            //Checks if the snake collided wit the wall or it's self
            if ((snakeXY[0,0] == 1) || (snakeXY[1,0] == 1) || (snakeXY[0,0] == consoleWidth) || (snakeXY[1,0] == consoleHeight - 4)) 
                colision = true;
            else
                //If the snake collided with the wall, theres no point in checking if it collided with itself.
                if (CollisionSnake(snakeXY[0,0], snakeXY[1,0], snakeXY, snakeLength, 1)) 
                colision = true;

            return (colision);
        }

        /**
         * @name refreshInfoBar
         * 
         * @param [in] score [\b int]
         * 
         * @param [in] speed [\b int]
         * 
         **/
        public void RefreshInfoBar(int score, int speed)
        {
            Console.SetCursorPosition(5, 23);
            Console.Write("Score:" + score);

            Console.SetCursorPosition(5, 24);
            Console.Write("Speed:" + speed);

            Console.SetCursorPosition(52, 23);
            Console.Write("Coder: Resul Beser");

            Console.SetCursorPosition(52, 24);
            Console.Write("Version: 0.5");

            return;
        }
        
        //void createHighScores()
        //{
        //    FILE* file;
        //    int i;

        //    file = fopen("highscores.txt", "w+");

        //    if (file == NULL)
        //    {
        //        Console.Write("FAILED TO CREATE HIGHSCORES!!! EXITING!");
        //        exit(0);
        //    }

        //    for (i = 0; i < 5; i++)
        //    {
        //        Console.Write(file, "%d", i + 1);
        //        Console.Write(file, "%s", "\t0\t\t\tEMPTY\n");
        //    }

        //    fclose(file);
        //    return;
        //}

        //int getLowestScore()
        //{
        //    FILE* fp;
        //    char str[128];
        //    int lowestScore = 0;
        //    int i;
        //    int intLength;

        //    if ((fp = fopen("highscores.txt", "r")) == NULL)
        //    {
        //        //Create the file, then try open it again.. if it fails this time exit.
        //        createHighScores(); //This should create a highscores file (If there isn't one)
        //        if ((fp = fopen("highscores.txt", "r")) == NULL)
        //            exit(1);
        //    }

        //    while (!feof(fp))
        //    {
        //        fgets(str, 126, fp);
        //    }
        //    fclose(fp);

        //    i = 0;

        //    //Gets the Int length
        //    while (str[2 + i] != '\t')
        //    {
        //        i++;
        //    }

        //    intLength = i;

        //    //Gets converts the string to int
        //    for (i = 0; i < intLength; i++)
        //    {
        //        lowestScore = lowestScore + ((int)str[2 + i] - 48) * pow(10, intLength - i - 1);
        //    }

        //    return (lowestScore);
        //}

        //void inputScore(int score) //This seriously needs to be cleaned up
        //{
        //    FILE* fp;
        //    FILE* file;
        //    char str[20];
        //    int fScore;
        //    int i, s, y;
        //    int intLength;
        //    int scores[5];
        //    int x;
        //    char highScoreName[20];
        //    char highScoreNames[5][20];

        //    char name[20];

        //    int entered = 0;

        //    clrscr(); //clear the console

        //    if ((fp = fopen("highscores.txt", "r")) == NULL)
        //    {
        //        //Create the file, then try open it again.. if it fails this time exit.
        //        createHighScores(); //This should create a highscores file (If there isn't one)
        //        if ((fp = fopen("highscores.txt", "r")) == NULL)
        //            exit(1);
        //    }
        //    gotoxy(10, 5);
        //    Console.Write("Your Score made it into the top 5!!!");
        //    gotoxy(10, 6);
        //    Console.Write("Please enter your name: ");
        //    gets(name);

        //    x = 0;
        //    while (!feof(fp))
        //    {
        //        fgets(str, 126, fp);  //Gets a line of text

        //        i = 0;

        //        //Gets the Int length
        //        while (str[2 + i] != '\t')
        //        {
        //            i++;
        //        }

        //        s = i;
        //        intLength = i;
        //        i = 0;
        //        while (str[5 + s] != '\n')
        //        {
        //            //printf("%c",str[5+s]);
        //            highScoreName[i] = str[5 + s];
        //            s++;
        //            i++;
        //        }
        //        //printf("\n");

        //        fScore = 0;
        //        //Gets converts the string to int
        //        for (i = 0; i < intLength; i++)
        //        {
        //            //printf("%c", str[2+i]);
        //            fScore = fScore + ((int)str[2 + i] - 48) * pow(10, intLength - i - 1);
        //        }

        //        if (score >= fScore && entered != 1)
        //        {
        //            scores[x] = score;
        //            strcpy(highScoreNames[x], name);

        //            //printf("%d",x+1);
        //            //printf("\t%d\t\t\t%s\n",score, name);		
        //            x++;
        //            entered = 1;
        //        }

        //        //printf("%d",x+1);
        //        //printf("\t%d\t\t\t%s\n",fScore, highScoreName);
        //        //strcpy(text, text+"%d\t%d\t\t\t%s\n");
        //        strcpy(highScoreNames[x], highScoreName);
        //        scores[x] = fScore;

        //        //highScoreName = "";
        //        for (y = 0; y < 20; y++)
        //        {
        //            highScoreName[y] = 0x00; //NULL
        //        }

        //        x++;
        //        if (x >= 5)
        //            break;
        //    }

        //    fclose(fp);

        //    file = fopen("highscores.txt", "w+");

        //    for (i = 0; i < 5; i++)
        //    {
        //        //printf("%d\t%d\t\t\t%s\n", i+1, scores[i], highScoreNames[i]);
        //        fprintf(file, "%d\t%d\t\t\t%s\n", i + 1, scores[i], highScoreNames[i]);
        //    }

        //    fclose(file);

        //    return;
        //}
  
        //void displayHighScores(void) //NEED TO CHECK THIS CODE!!!
        //{
        //    FILE* fp;
        //    char str[128];
        //    int y = 5;

        //    clrscr(); //clear the console

        //    if ((fp = fopen("highscores.txt", "r")) == NULL)
        //    {
        //        //Create the file, then try open it again.. if it fails this time exit.
        //        createHighScores(); //This should create a highscores file (If there isn't one)
        //        if ((fp = fopen("highscores.txt", "r")) == NULL)
        //            exit(1);
        //    }

        //    gotoxy(10, y++);
        //    Console.Write("High Scores");
        //    gotoxy(10, y++);
        //    Console.Write("Rank\tScore\t\t\tName");
        //    while (!feof(fp))
        //    {
        //        gotoxy(10, y++);
        //        if (fgets(str, 126, fp))
        //            Console.Write("%s", str);
        //    }

        //    fclose(fp); //Close the file
        //    gotoxy(10, y++);

        //    Console.Write("Press any key to continue...");
        //    waitForAnyKey();
        //    return;
        //}

        //**************END HIGHSCORE STUFF**************//

        /**
         * @name YouWinScreen
         * 
         **/

        public void YouWinScreen()
        {
            int x = 6, y = 7;
            Console.SetCursorPosition(x, y++);
            Console.Write("'##:::'##::'#######::'##::::'##::::'##:::::'##:'####:'##::: ##:'####:");
            Console.SetCursorPosition(x, y++);
            Console.Write(". ##:'##::'##.... ##: ##:::: ##:::: ##:'##: ##:. ##:: ###:: ##: ####:");
            Console.SetCursorPosition(x, y++);
            Console.Write(":. ####::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ####: ##: ####:");
            Console.SetCursorPosition(x, y++);
            Console.Write("::. ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ## ## ##:: ##::");
            Console.SetCursorPosition(x, y++);
            Console.Write("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##. ####::..:::");
            Console.SetCursorPosition(x, y++);
            Console.Write("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##:. ###:'####:");
            Console.SetCursorPosition(x, y++);
            Console.Write("::: ##::::. #######::. #######:::::. ###. ###::'####: ##::. ##: ####:");
            Console.SetCursorPosition(x, y++);
            Console.Write(":::..::::::.......::::.......:::::::...::...:::....::..::::..::....::");
            Console.SetCursorPosition(x, y++);

            WaitForAnyKey();
            //clear the console 
            Console.Clear(); 
            return;
        }


        /**
         * @name GameOverScreen
         * 
         * 
         **/
        public void GameOverScreen()
        {
            int x = 17, y = 3;

            Console.SetCursorPosition(x, y++);
            Console.Write(":'######::::::'###::::'##::::'##:'########:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("'##... ##::::'## ##::: ###::'###: ##.....::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::..::::'##:. ##:: ####'####: ##:::::::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##::'####:'##:::. ##: ## ### ##: ######:::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##::: ##:: #########: ##. #: ##: ##...::::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##::: ##:: ##.... ##: ##:.:: ##: ##:::::::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(". ######::: ##:::: ##: ##:::: ##: ########:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(":......::::..:::::..::..:::::..::........::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(":'#######::'##::::'##:'########:'########::'####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("'##.... ##: ##:::: ##: ##.....:: ##.... ##: ####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##: ##:::: ##: ##::::::: ##:::: ##: ####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##: ##:::: ##: ######::: ########::: ##::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##:. ##:: ##:: ##...:::: ##.. ##::::..:::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##::. ## ##::: ##::::::: ##::. ##::'####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(". #######::::. ###:::: ########: ##:::. ##: ####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(":.......::::::...:::::........::..:::::..::....::\n");

            WaitForAnyKey();
            //clear the console
            Console.Clear(); 
            return;
        }


        /**
         * @name StartGame
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] foodXY [\b int[]]
         * 
         * @param [in] consoleWidth [\b int]
         * 
         * @param [in] consoleHeight [\b int]
         * 
         * @param [in] snakeLength [\b int]
         * 
         * @param [in] score [\b int]
         * 
         * @param [in] speed [\b int]
         **/
        public void StartGame(int[,] snakeXY, int[] foodXY, int consoleWidth, int consoleHeight, int snakeLength, ConsoleKey direction, int score, int speed)
        {
            bool gameOver = false;
         
            ConsoleKey oldDirection = ConsoleKey.NoName;
            bool canChangeDirection = true;
            //int seconds = 1;
            int gameOver2 = 1;

            do
            {
                if (canChangeDirection)
                {
                    oldDirection = direction;
                    direction = CheckKeysPressed(direction);
                }
                //Temp fix to prevent the snake from colliding with itself
                if (oldDirection != direction)
                    _ = false; 

                if (true)  
                {
                    //gotoxy(1,1);
                    //printf(clock() , endWait);
                    Move(snakeXY, snakeLength, direction);
                    canChangeDirection = true;

                    
                    if (EatFood(snakeXY, foodXY))
                    {
                        //Generate More Food
                        GenerateFood(foodXY, consoleWidth, consoleHeight, snakeXY, snakeLength); 
                        snakeLength++;
                        score += speed;
                        switch (speed)
                        {
                        case 5:
                                score += 85;
                                break;
                        case 15:
                                score += 75;
                                break;
                        case 25:
                                score += 65;
                                break;
                        case 35:
                                score += 55;
                                break;
                        case 45:
                                score += 45;
                                break;
                        case 55:
                                score += 35;
                                break;
                        case 65:
                                score += 25;
                                break;
                        case 75:
                                score += 15;
                                break;
                        case 85:
                                score += 5;
                                break;
                        } 
                        
                        

                        RefreshInfoBar(score, speed);
                    }
                        Thread.Sleep(speed);
                }
                
                gameOver = CollisionDetection(snakeXY, consoleWidth, consoleHeight, snakeLength);
                //Just to make sure it doesn't get longer then the array size & crash
                if (snakeLength >= SNAKE_ARRAY_SIZE - 5) 
                {
                    //You Win! <- doesn't seem to work - NEED TO FIX/TEST THIS
                    gameOver2 = 2;
                    //When you win you get an extra 1500 points!
                    score += 1500; 
                }

            } while (!gameOver); 

            switch (gameOver2)
            {
                case 1:
                    //Console.Write("\7"); //Beep
                    //Console.Write("\7"); //Beep

                    GameOverScreen();

                    break;
                case 2:
                    YouWinScreen();
                    break;
            }     
            return;
        }


        /**
         * @name loadEnviroment 
         * 
         * @param [in] consoleWidth [\b int]
         * 
         * @param [in] consoleHeight [\b int]
         * 
         **/
        public void LoadEnviroment(int consoleWidth, int consoleHeight)//This can be done in a better way... FIX ME!!!! Also i think it doesn't work properly in ubuntu <- Fixed
        {
           
            int x = 1, y = 1;
            int rectangleHeight = consoleHeight - 4;
            //clear the console
            Console.Clear();
            //Top left corner
            Console.SetCursorPosition(x, y); 

            for (; y < rectangleHeight; y++)
            {
                //Left Wall
                Console.SetCursorPosition(x, y);  
                Console.Write(WALL);
                //Right Wall
                Console.SetCursorPosition(consoleWidth, y); 
                Console.Write(WALL);
            }

            y = 1;
            for (; x < consoleWidth + 1; x++)
            {
                //Left Wall
                Console.SetCursorPosition(x, y);  
                Console.Write(WALL);
                //Right Wall
                Console.SetCursorPosition(x, rectangleHeight); 
                Console.Write(WALL);
            }

            
            return;
        }


        /**
         * @name loadSnake
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] snakeLength [\b int]
         * 
         **/


        public void LoadSnake(int[,] snakeXY, int snakeLength)
        {
            int i;
            /*
            First off, The snake doesn't actually have enough XY coordinates (only 1 - the starting location), thus we use
            these XY coordinates to "create" the other coordinates. For this we can actually use the function used to move the snake.
            This helps create a "whole" snake instead of one "dot", when someone starts a game.
            */
            
            for (i = 0; i < snakeLength; i++)
            {
                Console.SetCursorPosition(snakeXY[0, i], snakeXY[1, i]);
                Console.Write(SNAKE_BODY); //Meh, at some point I should make it so the snake starts off with a head...
            }

            return;
        }

        /* NOTE, This function will only work if the snakes starting direction is left!!!! 
        Well it will work, but the results wont be the ones expected.. I need to fix this at some point.. */


        /**
         * @name PrepairSnakeArray
         * 
         * @param [in] snakeXY [\b int[,]]
         * 
         * @param [in] snakeLenght [\b int]
         * 
         **/
        public void PrepairSnakeArray(int[,] snakeXY, int snakeLength)
        {
            int i;
            int snakeX = snakeXY[0,0];
            int snakeY = snakeXY[1,0];

            for (i = 1; i <= snakeLength; i++)
            {
                snakeXY[0,i] = snakeX + i;
                snakeXY[1,i] = snakeY;
            }

            return;
        }


        /**
        * @name loadGame
        * 
        **/
        public void LoadGame()
        {
            //Two Dimentional Array, the first array is for the X coordinates and the second array for the Y coordinates
            int[,] snakeXY = new int[2, SNAKE_ARRAY_SIZE]; 
            //Starting Length
            int snakeLength = 4;
            //DO NOT CHANGE THIS TO RIGHT ARROW, THE GAME WILL INSTANTLY BE OVER IF YOU DO!!! <- Unless the prepairSnakeArray function is changed to take into account the direction....
            ConsoleKey direction = LEFT_ARROW; 
            //Stores the location of the food
            int[] foodXY = { 5, 5 };

            int score = 0;
            //int level = 1;

            //Window Width * Height - at some point find a way to get the actual dimensions of the console... <- Also somethings that display dont take this dimentions into account.. need to fix this...
            int consoleWidth = 80;
            int consoleHeight = 25;
            // this function is the function that takes the velocity
            int speed = GetGameSpeed();

            //The starting location of the snake
            snakeXY[0,0] = 40;
            snakeXY[1,0] = 10;
            //borders
            LoadEnviroment(consoleWidth, consoleHeight); 
            PrepairSnakeArray(snakeXY, snakeLength);
            LoadSnake(snakeXY, snakeLength);
            GenerateFood(foodXY, consoleWidth, consoleHeight, snakeXY, snakeLength);
            //Bottom info bar. Score, Level etc.
            RefreshInfoBar(score, speed); 
            StartGame(snakeXY, foodXY, consoleWidth, consoleHeight, snakeLength, direction, score, speed);

            return;
        }

        /**
         * @name MenuSelector
         * 
         * @param [in] x [\b int]
         * 
         * @param [in] y [\b int]
         * 
         * @param [in] yStart [\b int]
         * 
         **/
        public int MenuSelector(int x, int y, int yStart)
        {
            ConsoleKey key;
            int i = 0;
            x = x - 2;
            Console.SetCursorPosition(x, yStart);

            Console.Write(">");

            Console.SetCursorPosition(1, 1);
            // Even if it is not char, it converts it to char, called explicit conversion.
            do
            {
                key = WaitForAnyKey();               
                if (key == UP_ARROW)
                {
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(" ");

                    if (yStart >= yStart + i)
                        i = y - yStart - 2;
                    else
                        i--;
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(">");
                }
                else
                    if (key == DOWN_ARROW)
                {
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(" ");

                    if (i + 2 >= y - yStart)
                        i = 0;
                    else
                        i++;
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(">");
                }             
            } while (key != ENTER_KEY); 
            return (i);
        }
       

        /**
         * @name welcomeArt
         * 
         */
        public void WelcomeArt()
        {  
            //clear the console
            Console.Clear(); 
            Console.Write("\n");
            Console.Write("\t\t    _________          ________		    	\n");
            Console.Write("\t\t   /         \\       /        \\ 			\n");
            Console.Write("\t\t  /  /~~~~\\  \\     /  /~~~\\  \\ 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  | 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  | 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  |         /	\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  |       //	\n");
            Console.Write("\t\t (o  o)   \\  \\____/  /     \\  \\___/ / 	\n");
            Console.Write("\t\t \\___/    \\         /       \\       / 	\n");
            Console.Write("\t\t    |        ~~~~~~~~~         ^~~~~~~~ 	\n");
            Console.Write("\t\t    ^										\n");
            Console.Write("\t		Welcome To The Snake Game!			    \n");
            Console.Write("\t	    Press Any Key To Continue...	        \n");
            Console.Write("\n");

            WaitForAnyKey();
            return;
        }
        /**
         * @name controls
         * 
         * 
         */
        public void Controls()
        {
            int x = 10, y = 5;
            //clear the console
            Console.Clear(); 
            Console.SetCursorPosition(x, y++);
            Console.Write("Controls\n");
            Console.SetCursorPosition(x++, y++);
            Console.Write("Use the following arrow keys to direct the snake to the food: ");
            Console.SetCursorPosition(x, y++);
            Console.Write("Right Arrow");
            Console.SetCursorPosition(x, y++);
            Console.Write("Left Arrow");
            Console.SetCursorPosition(x, y++);
            Console.Write("Top Arrow");
            Console.SetCursorPosition(x, y++);
            Console.Write("Bottom Arrow");
            Console.SetCursorPosition(x, y++);
            Console.SetCursorPosition(x, y++);
            Console.Write("P & Esc pauses the game.");
            Console.SetCursorPosition(x, y++);
            Console.SetCursorPosition(x, y++);
            Console.Write("Press any key to continue...");
            WaitForAnyKey();
            return;
        }

        /**
         * @name ExitYN
         * 
         **/
        public void ExitYN()
        {
            ConsoleKey pressed;
            Console.SetCursorPosition(9, 8);
            Console.Write("Are you sure you want to exit(Y/N)\n");

            do
            {
                pressed = WaitForAnyKey();
            } while (!(pressed == ConsoleKey.Y || pressed == ConsoleKey.N));

            if (pressed == ConsoleKey.Y)
            {
                //clear the console
                Console.Clear(); 
                Environment.Exit(1);
            }
            return;
        }
        /**
         * @name MainMenu
         * 
         */
        public int MainMenu()
        {
            int x = 10, y = 5;
            int yStart = y;

            int selected;
            //clear the console
            Console.Clear(); 
            Console.SetCursorPosition(x, y++);
            Console.Write("New Game\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("High Scores\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("Controls\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("Exit\n");
            Console.SetCursorPosition(x, y++);

            selected = MenuSelector(x, y, yStart);

            return (selected);
        }
    }
}
