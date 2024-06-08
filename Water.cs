using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //store waters global position
    public int positionX = 50;
    public int positionY = 2;

    //takes in the characters around itself and makes a decision on what to do
    public string Move(char below, char left, char right, char bLeft, char bRight)
    {
        //vertical and diagonal
        if (below == ' ' && bLeft == ' ' && bRight == ' ') {
            Random rand = new Random();
            if(rand.Next(0, 3) == 0) {
                return "below";
            } 
            else if (rand.Next(0, 3) == 1){           
                return "bottomLeft";
            }
            else if (rand.Next(0, 3) == 2){ 
                return "bottomRight";
            }
        }
        else if (below == ' ' && bLeft == ' ') {
            Random rand = new Random();
            if(rand.Next(0, 2) == 1) {
                return "below";
            } 
            else {            
                return "bottomLeft";
            }
        }
        else if (below == ' ' && bRight == ' ') {
            Random rand = new Random();
            if(rand.Next(0, 2) == 1) {
                return "below";
            } 
            else {
                return "bottomRight";
            }
        }
        //vertical
        else if(below == ' '){
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
        
        return "stay";   
    }
}