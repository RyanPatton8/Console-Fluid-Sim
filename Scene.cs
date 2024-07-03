class Scene{
    public void OriginalScene(){
        Shapes.BlankCanvas(Program.width, Program.height);
        Shapes.SteepSlopeL(60,9);
        Shapes.SteepSlopeR(36,14);
        Shapes.SteepSlopeL(60,18);
        Shapes.GentleSlopeL(65, 30);
        Shapes.GentleSlopeR(20,40);
        Shapes.Platform(40, 55);
    }
}