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

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode originated;

    public PathNode(int row, int column)
    {
        Xposition = row;
        Yposition = column;

        // Just make the gCost absurdly high value for now
        gCost = int.MaxValue;

        originated = null;
    }

    public PathNode(int row, int column, int gCost, int hCost, int fCost)
    {
        Xposition = row;
        Yposition = column;

        this.gCost = gCost;
        this.hCost = hCost;
        this.fCost = fCost;

        originated = null;


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
    public int CalculateDistance(PathNode other)
    {
        // Differences between our points thus distance
        int xDist = Mathf.Abs(Xposition - other.GetXPosition());
        int yDist = Mathf.Abs(Yposition - other.GetYPosition());

        //Calculate true remainder oncew we have absolute values
        return Mathf.Abs(xDist - yDist);

    }
}
