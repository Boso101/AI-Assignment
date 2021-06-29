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

    public bool IsWalkable { get => isWalkable; }

    public PathNode(int row, int column, bool walkable)
    {
        Xposition = row;
        Yposition = column;

        // Just make the gCost absurdly high value for now
        gCost = int.MaxValue;

        parent = null;
        isWalkable = walkable;
        CalculateFCost();
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
        CalculateFCost();



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
    public int CalculateDistance(PathNode other, int straightCost, int diagonalCost)
    {
        // Differences between our points thus distance
        int xDist = Mathf.Abs(Xposition - other.GetXPosition());
        int yDist = Mathf.Abs(Yposition - other.GetYPosition());

        //Calculate true remainder oncew we have absolute values
        int remainder = Mathf.Abs(xDist - yDist);

        // Use the costs to determine the minimum cost
        return diagonalCost * Mathf.Min(xDist, yDist) + straightCost * remainder;

    }
}
