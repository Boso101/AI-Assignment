﻿using System;
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
    public void FindPath(Grid grid, int startX, int startY, int endX, int endY)
    {

        PathNode beginningNode = grid.GetNode(startX, startY);
        PathNode endNode = grid.GetNode(endX, endY);

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
                RetracePath(grid, currNode, endNode);
            }
            //Else remove from the open list since we have checked it, then add to closedList
            openList.Remove(currNode);
            closedList.Add(currNode);









            //Now go through the neighbours of current node and make sure it's walkable and isn't closed
            foreach (PathNode neighbour in grid.GetNeighbours(currNode))
            {
                if(neighbour.IsWalkable || !closedList.Contains(neighbour))
                {
                    // Get the new cost by adding our current cost to the distance cost of the neighbour node
                    int newNeighbourCost = currNode.gCost + currNode.CalculateDistance(neighbour, STRAIGHT, DIAGONAL);

                    // if our new cost is less than our neighbours cost or our neighbour doesnt exist in the open list
                    if(newNeighbourCost < neighbour.gCost || !openList.Contains(neighbour))
                    {
                        //Update node costs
                        neighbour.gCost = newNeighbourCost;
                        neighbour.hCost = neighbour.CalculateDistance(endNode, STRAIGHT, DIAGONAL);
                        neighbour.parent = currNode;

                        // if it doesnt contain then add it
                        if(!openList.Contains(neighbour))
                        {
                            openList.Add(neighbour);
                        }
                    }
                }
            }
        }


        
    }

    private void RetracePath(Grid grid, PathNode startNode, PathNode endNode)
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

        grid.path = path;
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
