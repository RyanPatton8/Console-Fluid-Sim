using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //store waters global position
    public int positionX = 50;
    public int positionY = 2;
    //overflow boolean to determine whether or not to try to overflow
    public bool allowOverFlow = false;

    //takes in the characters around itself and makes a decision on what to do
    public string Move(char below, char left, char right, char bLeft, char bRight, char tLeft, char tRight, char above)
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

        //check if needs to make another water overflow
        if (bLeft == character && below == character && bRight == character && right == '-' && left == character && above == character)
        {
            return "tryOverFlow";
        }

        //up diagonal for overflow (Experimental)
        if(allowOverFlow)
        {
            if (below == '-' && bLeft == character && left == character && right == '-' && tRight == ' ' && allowOverFlow)
            {
                allowOverFlow = false;
                return "topright";
            }
            else if (below == '-' && bRight == character && right == character && left == '-' && tLeft == ' ' && allowOverFlow)
            {
                allowOverFlow = false;
                return "topleft";
            }   
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

    public void OnOverFlowed(object sender, OverFlowEventArgs e)
    {
        if(e.xPosition == positionX && e.yPosition == positionY){
            allowOverFlow = true;
        }
    }
}