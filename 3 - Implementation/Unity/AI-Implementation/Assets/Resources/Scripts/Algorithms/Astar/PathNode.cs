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

    public Vector2 GetPosition()
    {
        return new Vector2(Xposition, Yposition);
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
