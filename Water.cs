using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //we will use this to check if the water has not been adjacent to another water for a set amount of time and delete it
    private bool alive = true;

    public int positionX = 50;
    public int positionY = 2;

    //takes in the characters around itself and makes a decision on what to do
    public string Move(char below, char left, char right, char bLeft, char bRight, char above)
    {
        // instead of killing them make them keep momentum
        
        //vertical
        if(below == ' '){
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
            return "left";
        } 
        else if (right == ' ') {
            return "right";
        }
        //none 
        else {
            return "stay";
        }
    }
}