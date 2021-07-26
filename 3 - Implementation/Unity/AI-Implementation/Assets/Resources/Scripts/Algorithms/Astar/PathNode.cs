using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// The node class that Astar algorithm will work with
/// </summary>
public class PathNode
{


    //Hold position data just incase
    protected int Xposition;
    protected int Yposition;

    protected bool isWalkable;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode parent;

    public bool IsWalkable { get => isWalkable; set => isWalkable = value; }
    public Color Color
    { 
    
    get
        {

            if (isWalkable) return Color.gray;
            return Color.black;

        }

       
    
    
    }

    public float FCost
    { 
    
    get
        {

            return gCost + hCost;

        }
    }
    


    public PathNode(int row, int column, bool walkable)
    {
        Xposition = row;
        Yposition = column;

   

        parent = null;
        isWalkable = walkable;
  
    }

    public PathNode(int row, int column, int gCost, int hCost, int fCost, bool walkable)
    {
        Xposition = row;
        Yposition = column;

        this.gCost = gCost;
        this.hCost = hCost;
        this.fCost = fCost;

        isWalkable = walkable;
        parent = null;



    }


    public int GetXPosition()
    {
        return Xposition;
    }

    public int GetYPosition()
    {
        return Yposition;
    }
    public Vector2 GetPosition()
    {
        return new Vector2(Xposition, Yposition);
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    /// <summary>
    /// Calculates the distance between this node and another
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int GetDistance(PathNode other, int straightCost, int diagonalCost)
    {
      

        ////Calculate true remainder oncew we have absolute values
        //int remainder = Mathf.Abs(xDist - yDist);

        //// Use the costs to determine the minimum cost
        //return diagonalCost * Mathf.Min(xDist, yDist) + straightCost * remainder;

        int dstX = Mathf.Abs(GetXPosition() - other.GetXPosition());
        int dstY = Mathf.Abs(GetYPosition() - other.GetYPosition());

        if (dstX > dstY)
            return straightCost * dstY + diagonalCost * (dstX - dstY);
        
        return straightCost * dstX + diagonalCost * (dstY - dstX);

    }
}
