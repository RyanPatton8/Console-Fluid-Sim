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

    // uses parameters to add the water character to a new position and erase the old one
    public static void MoveWater(Water water, int xMovement, int yMovement)
    {
        Console.SetCursorPosition(water.positionX + xMovement, water.positionY + yMovement);
        Console.Write(water.character);
        grid[water.positionX + xMovement, water.positionY + yMovement] = water.character;

        Console.SetCursorPosition(water.positionX, water.positionY);
        Console.Write(' ');
        grid[water.positionX, water.positionY] = ' ';

        water.positionX += xMovement;
        water.positionY += yMovement;
    }
    
    // calls every water in a loop asking which direction it wants to go based on its current position and the tiles that surround it
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
                        MoveWater(water, 0, 1);
                    }
                    else if (direction == "bottomLeft"){
                        MoveWater(water, -1, 1);
                    }
                    else if (direction == "bottomRight"){
                        MoveWater(water, 1, 1);
                    }
                    else if (direction == "left"){
                        MoveWater(water, -1, 0);
                    }
                    else if (direction == "right"){
                        MoveWater(water, 1, 0);
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
