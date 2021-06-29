using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// The node class that Astar algorithm will work with
/// </summary>
public class PathNode
{

    //Hold position data just incase
    protected Vector2 position;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode(int row, int column)
    {
        position = new Vector2(row, column);
    }
}
