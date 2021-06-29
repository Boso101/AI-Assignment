using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    protected List<PathNode> openList;
    protected List<PathNode> closedList;



    /// Search given the 2d array, the start coordinates and the end goal coordinates
    //TODO: Probably make the grid a container class instead of just being a 2d array since then we won't have to pass the size
    public List<PathNode> FindPath(PathNode[,] grid, int gridRows, int gridColumns, int startX, int startY, int endX, int endY)
    {
        // Following algorithm, we have both an open and close list
        PathNode beginningNode = grid[startX, startY];
        
        //First node in the open list is our starting node obviously
        openList = new List<PathNode> { beginningNode };
        closedList = new List<PathNode>();


        //Now lets loop through the nodes
        for (int i = 0; i < gridRows; i++)
        {


            for (int j = 0; j < gridColumns; j++)
            {



            }


        }

    }
}
