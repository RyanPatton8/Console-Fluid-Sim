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
        //up diagonal for overflow (Experimental)
        if(allowOverFlow)
        {
            if (tRight == ' ')
            {
                allowOverFlow = false;
                return "topright";
            }
            // else if (bRight == character && right == character && tLeft == ' ' && allowOverFlow)
            // {
            //     allowOverFlow = false;
            //     return "topleft";
            // }
        }
        
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

//maybe check recursively using the event if it logically could overflow starting from current position and spreading locally around it?

//maybe create static method to check for a space withing range of 5x - 2y that makes sense to overflow using logic similar to move method?

    //check the six to the right and six to left same as move method choose the one that makes sense
    public int[] FindWaterForOverFlow()
    {   
        //check if adjacent 3 around wall on right side are all water
        if(Program.grid[positionX + 5, positionY] == '0' &&
            Program.grid[positionX + 4, positionY] == '0' &&
            Program.grid[positionX + 3, positionY] == '0' )
        {
            //choose closest water to the wall
            if (Program.grid[positionX + 3, positionY - 1] == ' ')
            {
                return [3,0];
            }
            else if(Program.grid[positionX + 4, positionY - 1] == ' ')
            {
                return [4,0];
            }
            else if(Program.grid[positionX + 5, positionY - 1] == ' ')
            {
                return [5,0];
            }
        }
        //check if adjacent 3 around wall on right side are all water one row down
        else if (Program.grid[positionX + 5, positionY + 1] == '0' &&
                Program.grid[positionX + 4, positionY + 1] == '0' &&
                Program.grid[positionX + 3, positionY + 1] == '0' )
        {
            if (Program.grid[positionX + 3, positionY] == ' ')
            {
                return [3,1];
            }
            else if(Program.grid[positionX + 4, positionY] == ' ')
            {
                return [4,1];
            }
            else if(Program.grid[positionX + 5, positionY] == ' ')
            {
                return [5,1];
            }
        }

        return [0,0];
    }

    public void OnOverFlowed(object sender, OverFlowEventArgs e)
    {
        if(e.xPosition == positionX && e.yPosition == positionY){
            allowOverFlow = true;
        }
    }
}