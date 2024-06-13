using System;

class Water 
{
    //how we will represent the water
    public char character = '0';
    //store waters global position
    public int positionX = 50;
    public int positionY = 2;
    //overflow move direction
    private string mDirection = "none";
    


    //takes in the characters around itself and makes a decision on what to do
    public string Move(char below, char left, char right, char bLeft, char bRight, char tLeft, char tRight, char above)
    {
        if (character == '0'){
            return NotMerged(below, left, right, bLeft, bRight, above);
        }
        else if (character == 'O' || character == '1'){
            return Merged(below, left, right, bLeft, bRight, above);
        }
        else{
            return "stay";
        }
    }

    private string NotMerged(char below, char left, char right, char bLeft, char bRight, char above)
    {
        if (below == ' ' && bLeft == ' ' && bRight == ' ')
        {
            Random rand = new Random();
            if (rand.Next(0, 3) == 0)
            {
                return "below";
            }
            else if (rand.Next(0, 3) == 1)
            {
                return "bottomLeft";
            }
            else if (rand.Next(0, 3) == 2)
            {
                return "bottomRight";
            }
        }
        else if (below == ' ' && bLeft == ' ')
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 1)
            {
                return "below";
            }
            else
            {
                return "bottomLeft";
            }
        }
        else if (below == ' ' && bRight == ' ')
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 1)
            {
                return "below";
            }
            else
            {
                return "bottomRight";
            }
        }

        //vertical
        else if (below == ' ')
        {
            return "below";
        }

        //diagonal
        else if (bLeft == ' ' && bRight == ' ')
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 1)
            {
                return "bottomLeft";
            }
            else
            {
                return "bottomRight";
            }
        }
        else if (bLeft == ' ')
        {
            return "bottomLeft";
        }
        else if (bRight == ' ')
        {
            return "bottomRight";
        }
        else if (left == ' ' && right == ' ')
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 1)
            {
                return "left";
            }
            else
            {
                return "right";
            }
        }
        else if (left == ' ')
        {
            return "left";
        }
        else if (right == ' ')
        {
            return "right";
        }
        //make it overflow
        else if (right == '-' && below == '0' && bRight == '0' && Program.grid[positionX + 4, positionY] != '0')
        {
            character = 'O';
            mDirection = "right";
            return "bottomRight";
        }
        else if (left == '-' && below == '0' && bLeft == '0' && Program.grid[positionX - 4, positionY] != '0')
        {
            character = 'O';
            mDirection = "left";
            return "bottomLeft";
        }
        return "stay";
    }

    private string Merged(char below, char left, char right, char bLeft, char bRight, char above)
    {
        if (above == ' ') {
            character = '0';
            return "above";
        }
        else if (above == '0'){
            return "above";
        }
        else if (mDirection == "right"){
            if (right != '-'){
                return "right";
            }
            else {
                mDirection = "left";
            }
        }
        else if (mDirection == "left"){
            if (left != '-'){
                return "left";
            }
            else{
                mDirection = "right";
            }
        }
        return "stay";
    }
}