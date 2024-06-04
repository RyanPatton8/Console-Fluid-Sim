using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //store waters global position
    public int positionX = 50;
    public int positionY = 2;
    //store last move to continue same direction
    private string previousMove = "none";
    //how many moves the water can make before stopping is decided by the amount of water being poured
    private int extraMoves = Program.waterAmount / 8;
    private int maxExtraMoves = Program.waterAmount / 8;

    //takes in the characters around itself and makes a decision on what to do
    public string Move(char below, char left, char right, char bLeft, char bRight, char above)
    {
        // stop them moving when appropriate
        if(extraMoves > 0){
            if (below == ' ' && bLeft == ' ' && bRight == ' ') {
                Random rand = new Random();
                if(rand.Next(0, 3) == 0) {
                    extraMoves = maxExtraMoves;
                    return "below";
                } 
                else if (rand.Next(0, 3) == 1){
                    extraMoves = maxExtraMoves;              
                    return "bottomLeft";
                }
                else if (rand.Next(0, 3) == 2){
                    extraMoves = maxExtraMoves;              
                    return "bottomRight";
                }
            }
            else if (below == ' ' && bLeft == ' ') {
                Random rand = new Random();
                if(rand.Next(0, 2) == 1) {
                    extraMoves = maxExtraMoves;
                    return "below";
                } 
                else {
                    extraMoves = maxExtraMoves;              
                    return "bottomLeft";
                }
            }
            else if (below == ' ' && bRight == ' ') {
                Random rand = new Random();
                if(rand.Next(0, 2) == 1) {
                    extraMoves = maxExtraMoves;
                    return "below";
                } 
                else {
                    extraMoves = maxExtraMoves;
                    return "bottomRight";
                }
            }
            //vertical
            else if(below == ' '){
                extraMoves = maxExtraMoves;
                return "below";
            }
            //diagonal
            else if (bLeft == ' ' && bRight == ' ') {
                Random rand = new Random();
                if(rand.Next(0, 2) == 1) {
                    extraMoves = maxExtraMoves;
                    return "bottomLeft";
                } 
                else {
                    extraMoves = maxExtraMoves;
                    return "bottomRight";
                }
            }
            else if (bLeft == ' '){
                extraMoves = maxExtraMoves;
                return "bottomLeft";
            } 
            else if (bRight == ' ') {
                extraMoves = maxExtraMoves;
                return "bottomRight";
            }   
            //horizontal
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
        }
        //if when it has stopped it is a single character make it blank to make it look a bit cleaner and allow other water to move in its place
        else if(left == ' ' && right == ' ') {
            character = ' ';
        }
        //if it can move down bring allow movement again
        else if (below == ' ' || bLeft == ' ' || bRight == ' '){
            extraMoves = maxExtraMoves;
            character = '0';
        }
            
        return "stay";   
    }
}