using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bits and pieces used from GitHub 
public class Astar
{
    //Constants for the costs of moving for priority purposes

    // We want to move straight more than diagonally
    public const int STRAIGHT = 14;
    public const int DIAGONAL = 10;


    public Astar()
    {

    }


    /// Search given the 2d array, the start coordinates and the end goal coordinates
    public void FindPath(Grid grid, PathContainer container, int startX, int startY, int endX, int endY, int straightCost = STRAIGHT, int diagonalCost = DIAGONAL)
    {

        PathNode beginningNode = grid.GetNode(startX, startY);
        PathNode endNode = grid.GetNode(endX, endY);

        //Checks
        if(beginningNode == null || endNode == null) { return; }

        if (!endNode.IsWalkable) { return; }


        //First node in the open list is our starting node obviously
        List<PathNode> openList = new List<PathNode> { beginningNode };


        // Following algorithm, we have both an open and close list

        //Use a HashSet for the closed set since everything will be unique anyway,
        //will be much faster too.
        HashSet<PathNode> closedList = new HashSet<PathNode>();


        // Get Lowest costs while we still have open nodes
        while (openList.Count > 0)
        {
            PathNode currNode = GetLowestFCostNode(openList);



            openList.Remove(currNode);
            closedList.Add(currNode);


            //Have we reached the end yet?
            if (currNode == endNode)
            {
                //Retrace the path and get out 
                RetracePath(container, beginningNode, endNode);
                return;
            }






            //Now go through the neighbours of current node and make sure it's walkable and isn't closed
            foreach (PathNode neighbour in grid.GetNeighbours(currNode))
            {
                if (!neighbour.IsWalkable || closedList.Contains(neighbour))
                {
                    //Skip the bad nodes
                    continue;
                }
                // Get the new cost by adding our current cost to the distance cost of the neighbour node
                int newNeighbourCost = currNode.gCost + currNode.GetDistance(neighbour, straightCost, diagonalCost);

                // if our new cost is less than our neighbours cost or our neighbour doesnt exist in the open list
                if (newNeighbourCost < neighbour.gCost || !openList.Contains(neighbour))
                {
                    //Update node costs
                    neighbour.gCost = newNeighbourCost;
                    neighbour.hCost = neighbour.GetDistance(endNode, straightCost, diagonalCost);
                    neighbour.parent = currNode;

                    // if it doesnt contain then add it
                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }

            }
        }



    }

    private void RetracePath(PathContainer pathContainer, PathNode startNode, PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        PathNode currentNode = endNode;
        // Transverse 
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        //Reverse it
        path.Reverse();

        pathContainer.SetPath(path);
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
        for (int i = 0; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].FCost < lowestFCost.FCost)
            {
                lowestFCost = pathNodeList[i];
            }

        }

        return lowestFCost;
    }
}
