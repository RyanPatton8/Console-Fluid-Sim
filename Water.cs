using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //we will use this to check if the water has not been adjacent to another water for a set amount of time and delete it
    int lifeTime = 3;

    public int positionX = 13;
    public int positionY = 13;

    //functionality to be added
    //will add all move functionality
    public string Move(char below, char left, char right)
    {
        if(below == ' '){
            return "below";
        } 
        else if (left == ' ' && right == ' ') {
            Random rand = new Random();
            if(rand.Next(0, 2) == 0) {
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
        else {
            return "stay";
        }
    }
}