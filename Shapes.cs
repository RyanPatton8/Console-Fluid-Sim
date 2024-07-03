class Shapes{
     public static void BlankCanvas(int width, int height)
    {
        //clear terminal and add floors and walls represented by hyphens
        for (int i = 0; i < width - 1; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(j == height - 1) {
                    Console.SetCursorPosition(i,j);
                    Console.Write('-');
                    Program.grid[i,j] = '-';
                }else if (i == width - 2 || i == 0) {
                    Console.SetCursorPosition(i,j);
                    Console.Write('-');
                    Program.grid[i,j] = '-';
                }else {
                    Console.SetCursorPosition(i,j);
                    Console.Write(' ');
                    Program.grid[i,j] = ' ';
                } 
            }
        }
    }

    public static void SteepSlopeR(int startX, int startY)
    {
        //move cursor to the right one and down one for i doubling up on y axis to ensure water doesn't penetrate
        for (int i = 0; i < 11; i++){
            if (i + startY > Program.height - 1)
                break;
            Console.SetCursorPosition(startX + i, startY + i);
            Console.Write('-');
            Program.grid[startX + i, startY + i] = '-';

            Console.SetCursorPosition(startX + i + 1, startY + i);
            Console.Write('-');
            Program.grid[startX + i + 1, startY + i] = '-';
        }
    }

    public static void SteepSlopeL(int startX, int startY)
    {
        //move cursor to the left one and down one for i doubling up on y axis to ensure water doesn't penetrate
        for (int i = 0; i < 11; i++){
            if (i + startY > Program.height - 1)
                break;
            Console.SetCursorPosition(startX - i, startY + i);
            Console.Write('-');
            Program.grid[startX - i, startY + i] = '-';

            Console.SetCursorPosition(startX - i - 1, startY + i);
            Console.Write('-');
            Program.grid[startX - i - 1, startY + i] = '-';
        }
    }

    public static void GentleSlopeR(int startX, int startY)
    {
        int xIncrement = 0;

        for (int i = 0; i < 11; i++){
            if (i + startY > Program.height - 1)
                break;
            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
            xIncrement++;

            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
            xIncrement++;

            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
            xIncrement++;

            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
        }
    }

    public static void GentleSlopeL(int startX, int startY)
    {
        int xIncrement = 0;

        for (int i = 0; i < 11; i++){
            if (i + startY > Program.height - 1)
                break;
            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
            xIncrement--;

            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
            xIncrement--;

            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
            xIncrement--;

            Console.SetCursorPosition(startX + xIncrement, startY + i);
            Console.Write('-');
            Program.grid[startX + xIncrement, startY + i] = '-';
        }
    }

    public static void Platform(int startX, int startY)
    {
        for (int i = 0; i < 30; i++){
            if (startY > Program.height - 1)
                break;
            Console.SetCursorPosition(startX + i, startY);
            Console.Write('-');
            Program.grid[startX + i, startY ] = '-';
        }
    }
}