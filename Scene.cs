class Scene{
    public void SceneOne(){
        Shapes.BlankCanvas(Program.width, Program.height);
        Shapes.SteepSlopeL(60, 6);
        Shapes.SteepSlopeR(36, 11);
        Shapes.SteepSlopeL(60, 15);
        Shapes.GentleSlopeL(65, 27);
        Shapes.GentleSlopeR(20, 37);
        Shapes.Platform(40, 52);
        Shapes.Platform(70, 52);
        Shapes.GentleSlopeR(100, 52);
        Shapes.GentleSlopeL(160, 67);
    }

    public void SceneTwo(){
        Shapes.BlankCanvas(Program.width, Program.height);
        Shapes.Platform(40, 8);
        Shapes.Platform(70, 8);
        Shapes.Platform(90, 15);
        Shapes.Platform(80, 30);
        Shapes.Platform(115, 30);
        Shapes.GentleSlopeR(30,20);
        Shapes.GentleSlopeR(45,35);
        Shapes.GentleSlopeR(60,50);
        Shapes.Platform(70, 70);
        Shapes.Platform(100, 70);
    }

    public void SceneThree(){
        Shapes.BlankCanvas(Program.width, Program.height);
        Shapes.GentleSlopeR(40, 8);
        Shapes.Platform(70, 19);
        Shapes.Platform(100, 19);
        Shapes.Platform(130, 19);
        Shapes.SteepSlopeL(165, 25);
        Shapes.Platform(128, 35);
        Shapes.Platform(115, 45);
        Shapes.Platform(88, 55);
        Shapes.Platform(135, 55);
        
    }

    public void Clear(int width, int height){
         //clear terminal and add floors and walls represented by hyphens
        for (int i = 0; i < width - 1; i++)
        {
            for (int j = 0; j < height; j++)
            {
                
                Console.SetCursorPosition(i,j);
                Console.Write(' ');
                Program.grid[i,j] = ' ';
                
            }
        }
        Console.SetCursorPosition(0,0);
    }
}