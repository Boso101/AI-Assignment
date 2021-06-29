using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    //Constants for the costs of moving for priority purposes

    // We want to move straight more than diagonally
    private const int STRAIGHT = 14;
    private const int DIAGONAL = 10;





    /// Search given the 2d array, the start coordinates and the end goal coordinates
    //TODO: Probably make the grid a container class instead of just being a 2d array since then we won't have to pass the size
    public void FindPath(PathNode[,] grid, int gridRows, int gridColumns, int startX, int startY, int endX, int endY)
    {
      
        PathNode beginningNode = grid[startX, startY];
        PathNode endNode = grid[endX, endY];

        //First node in the open list is our starting node obviously
        List<PathNode> openList = new List<PathNode> { beginningNode };


        // Following algorithm, we have both an open and close list

        //Use a HashSet for the closed set
        HashSet<PathNode> closedList = new HashSet<PathNode>();



        // Get Lowest costs while we still have open nodes
        while (openList.Count > 0)
        {
            PathNode currNode = GetLowestFCostNode(openList);
            
            //Have we reached the end yet?
            if(currNode == endNode)
            {
                //Retrace the path and get out of 
                RetracePath(currNode, endNode);
            }
            //Else remove from the open list since we have checked it, then add to closedList
            openList.Remove(currNode);
            closedList.Add(currNode);
        }
    }

    private void RetracePath(PathNode currNode, PathNode endNode)
    {
        throw new NotImplementedException();
    }

    private List<PathNode> GetNeighbouringList(PathNode[,] grid, PathNode currNode, int rows, int columns)
    {
        List<PathNode> neighbours = new List<PathNode>();

        if(currNode.GetXPosition() - 1 >= 0)
        {
            // Left side
            neighbours.Add(grid[currNode.GetXPosition() - 1, currNode.GetYPosition()]);
            // Left down
            if (currNode.GetYPosition() - 1 >= 0)
                neighbours.Add(grid[currNode.GetXPosition() - 1, currNode.GetYPosition() - 1]);
            //Left up
            if (currNode.GetYPosition() + 1 < columns)
                neighbours.Add(grid[currNode.GetXPosition() - 1, currNode.GetYPosition() + 1]);


        }
    }

    private List<PathNode> CalculatePath(PathNode finalNode)
    {
        return null;
    }


    //Again, should probably use a container for the grid so that the dimensions are with it
    /// <summary>
    /// Get the minimum fCost node
    /// </summary>
    /// <param name="pathNodeList"></param>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    public PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        // Grab the first node
        PathNode lowestFCost = pathNodeList[0];

        // Loop through the list and see if we find anything smaller
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if(pathNodeList[i].fCost < lowestFCost.fCost)
            {
                lowestFCost = pathNodeList[i];
            }

        }

        return lowestFCost;
    }
}
