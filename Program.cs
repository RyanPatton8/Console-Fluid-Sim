using System;
using System.Reflection;
using System.Threading;


// break the water into lists of 100
// loop through each list
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
        while (true)
        {   // for every drop of water check adjacent tiles and move accordingly replacing previous placement with a blank tile
            foreach (Water water in waterList){
                string direction = water.Move(grid[water.positionX, water.positionY + 1],       //below 
                                              grid[water.positionX - 1, water.positionY],       //left
                                              grid[water.positionX + 1, water.positionY],       //right
                                              grid[water.positionX - 1, water.positionY + 1],   //bottom left
                                              grid[water.positionX + 1, water.positionY + 1]);   //bottom right  

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
            //how long to wait until next loop
            Thread.Sleep(flowRate);  
        }
    }

    // set all starting variables accordingly
    static private void SetUp()
    {
        //ensure cursor is invisible for aesthetic
        Console.CursorVisible = false;
        //set window height and width to current position
        width = Console.WindowWidth;
        height = Console.WindowHeight;

        waterAmount = 18 * height;

        if(waterAmount > 2500)
            waterAmount = 2500;
        
        grid = new char[width, height];

        // create a list of instantiated water objects
        for(int i = waterAmount; i > 0; i--){
            Water water = new Water();
            waterList.Add(water);
        }
        //ensure the speed at which it loops is relatively the same regardless of the amount of water
        int potentialRate = 30 - (waterAmount / 100);

        if(potentialRate > 0){
            flowRate = potentialRate;
        }
    }

    static void Main(string[] args)
    {
        SetUp();
        scene.OriginalScene();
        Simulate();
    }
}
