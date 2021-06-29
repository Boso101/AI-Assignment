using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    protected List<PathNode> openList;
    protected List<PathNode> closedList;


    public List<PathNode> FindPath(PathNode[,] grid, Vector2 startPos, Vector2 endPos)
    {
        // Following algorithm, we have both an open and close list
        openList = new List<PathNode>();
        closedList = new List<PathNode>();

    }
}
