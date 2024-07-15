using System;
using System.Reflection;
using System.Threading;
using System.Text.RegularExpressions;

class Program
{
    //width and height of terminal
    public static int width; 
    public static int height;
    //create a matrix to keep track of all characters in terminal
    static public char[,] grid = {{},{}};
    //water variables
    static public int waterAmount = 0;//how much water to drop
    static private int flowRate = 0;//how long it should wait to loop (effectively how fast the water moves)
    static public List<Object> waterList = new List<Object>();//list to hold and loop through all instances of water
    static Scene scene= new Scene();

    public static void Simulate()
    {
        bool simulating = true;

        while (simulating)
        {   // for every drop of water check adjacent tiles and move accordingly replacing previous placement with a blank tile
            foreach (Water water in waterList){
                try{
                        string direction = water.Move(grid[water.positionX, water.positionY + 1],       //below 
                                                grid[water.positionX - 1, water.positionY],             //left
                                                grid[water.positionX + 1, water.positionY],             //right
                                                grid[water.positionX - 1, water.positionY + 1],         //bottom left
                                                grid[water.positionX + 1, water.positionY + 1]);        //bottom right  

                    if (direction == "below"){
                        Console.SetCursorPosition(water.positionX, water.positionY + 1);
                        Console.Write(water.character);
                        grid[water.positionX, water.positionY + 1] = water.character;

                        Console.SetCursorPosition(water.positionX, water.positionY);
                        Console.Write(' ');
                        grid[water.positionX, water.positionY] = ' ';

                        water.positionY ++;
                    }
                    else if (direction == "bottomLeft"){
                        Console.SetCursorPosition(water.positionX - 1, water.positionY + 1);
                        Console.Write(water.character);
                        grid[water.positionX - 1, water.positionY + 1] = water.character;

                        Console.SetCursorPosition(water.positionX, water.positionY);
                        Console.Write(' ');
                        grid[water.positionX, water.positionY] = ' ';

                        water.positionX --;
                        water.positionY ++;
                    }
                    else if (direction == "bottomRight"){
                        Console.SetCursorPosition(water.positionX + 1, water.positionY + 1);
                        Console.Write(water.character);
                        grid[water.positionX + 1, water.positionY + 1] = water.character;

                        Console.SetCursorPosition(water.positionX, water.positionY);
                        Console.Write(' ');
                        grid[water.positionX, water.positionY] = ' ';

                        water.positionX ++;
                        water.positionY ++;
                    }
                    else if (direction == "left"){
                        Console.SetCursorPosition(water.positionX - 1, water.positionY);
                        Console.Write(water.character);
                        grid[water.positionX - 1, water.positionY] = water.character;

                        Console.SetCursorPosition(water.positionX, water.positionY);
                        Console.Write(' ');
                        grid[water.positionX, water.positionY] = ' ';

                        water.positionX --;
                    }
                    else if (direction == "right"){
                        Console.SetCursorPosition(water.positionX + 1, water.positionY);
                        Console.Write(water.character);
                        grid[water.positionX + 1, water.positionY] = water.character;

                        Console.SetCursorPosition(water.positionX, water.positionY);
                        Console.Write(' ');
                        grid[water.positionX, water.positionY] = ' ';

                        water.positionX ++;
                    }
                    if (direction == "above"){
                        Console.SetCursorPosition(water.positionX, water.positionY - 1);
                        Console.Write(water.character);
                        grid[water.positionX, water.positionY - 1] = water.character;

                        Console.SetCursorPosition(water.positionX, water.positionY);
                        Console.Write('0');
                        grid[water.positionX, water.positionY] = '0';

                        water.positionY --;
                    }
                }
                catch(ArgumentOutOfRangeException){
                    simulating = false;
                    break;
                }
            }
            //how long to wait until next loop
            Thread.Sleep(flowRate);  
        }
        Menu();
    }

    // set all starting variables accordingly
    static private void SetUp()
    {
        //set window height and width to current position
        width = Console.WindowWidth;
        height = Console.WindowHeight;

        waterAmount = 18 * height;

        if(waterAmount > 2500)
            waterAmount = 2500;
        
        grid = new char[width, height];

        // create a list of instantiated water objects
        waterList.Clear();

        for(int i = waterAmount; i > 0; i--){
            Water water = new Water();
            waterList.Add(water);
        }
        
        //ensure the speed at which it loops is relatively the same regardless of the amount of water
        flowRate = 30 - (waterAmount / 100);

        if(flowRate < 0){
            flowRate = 0;
        }
    }
    static void Menu()
    {
        bool settingUp = true;
        //ensure cursor is invisible for aesthetic
        Console.CursorVisible = true;
        while(settingUp){
            try{
                SetUp();
                scene.Clear(width, height);
                settingUp = false;
            }
            catch(ArgumentOutOfRangeException){
                continue;
            }
        }

        Regex regex = new Regex("[123]");

        string? input = "blank";
        bool validInput = false;

        Console.WriteLine("Enter a number (1, 2, 3) or type 'exit' to quit:");
        
        while(!validInput){
            input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                Environment.Exit(0);
            }
            else if(regex.IsMatch(input)){
                validInput = true;
            }
            else{
                Console.WriteLine("You MUST Input either 1, 2, 3 or 'exit'!");
            }
        }

        SetUp();
        //ensure cursor is invisible for aesthetic
        Console.CursorVisible = false;

        if(input == "1"){
            scene.SceneOne();
        }
        else if(input == "2"){
            scene.SceneTwo();
        }
        else if(input == "3"){
            scene.SceneThree();
        }
        Simulate();
    }

    static void Main(string[] args)
    {
        Menu();
    }
}
