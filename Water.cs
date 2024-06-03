using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //we will use this to check if the water has not been adjacent to another water for a set amount of time and delete it
    private int lifeTime = 20;
    private int maxLifeTime = 20;
    private bool alive = true;

    public int positionX = 13;
    public int positionY = 2;

    //takes in the characters around itself and makes a decision on what to do
    public string Move(char below, char left, char right, char bLeft, char bRight, char above)
    {
        CheckLifeTime();

        if (alive) {
            //vertical
            if(below == ' '){
                lifeTime = maxLifeTime;
                return "below";
            }
            //diagonal
            else if (bLeft == ' ' && bRight == ' ') {
                Random rand = new Random();
                if(rand.Next(0, 2) == 1) {
                    return "bottomLeft";
                } 
                else {
                    return "bottomRight";
                }
            }
            else if (bLeft == ' '){
                return "bottomLeft";
            } 
            else if (bRight == ' ') {
                return "bottomRight";
            }   
            // horizontal
            else if (left == ' ' && right == ' ') {
                Random rand = new Random();
                if(rand.Next(0, 2) == 1) {
                    return "left";
                } 
                else {
                    return "right";
                }
            }
            else if (left == ' '){
                if(above != '0' && below != '0'){
                    lifeTime --;
                }
                return "left";
            } 
            else if (right == ' ') {
                if(above != '0' && below != '0'){
                    lifeTime --;
                }
                return "right";
            }
            //none 
            else {
                return "stay";
            }
        }
        
        return "dead";
    }

    private void CheckLifeTime()
    {
        if (lifeTime == 0 && alive == true) {
            character = ' ';
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(character);
            Program.grid[positionX, positionY] = ' ';
            alive = false;
        }
    }
}