using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 MIT License

Copyright (c) 2017 Sebastian Lague

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

// Bits and pieces used from GitHub https://github.com/SebLague/Pathfinding
public class Astar
{
    //Constants for the costs of moving for priority purposes

    // We want to move straight more than diagonally
    private const int STRAIGHT = 14;
    private const int DIAGONAL = 10;


    public Astar()
    {

    }


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
            
          
           
            openList.Remove(currNode);
            closedList.Add(currNode);


            //Have we reached the end yet?
            if (currNode == endNode)
            {
                //Retrace the path and get out 
                RetracePath(grid, beginningNode, endNode);
                return;
            }






            //Now go through the neighbours of current node and make sure it's walkable and isn't closed
            foreach (PathNode neighbour in grid.GetNeighbours(currNode))
            {
                if(!neighbour.IsWalkable || closedList.Contains(neighbour))
                {
                    //Some sort of debug here
                    continue;
                }
                // Get the new cost by adding our current cost to the distance cost of the neighbour node
                int newNeighbourCost = currNode.gCost + currNode.GetDistance(neighbour, STRAIGHT, DIAGONAL);

                    // if our new cost is less than our neighbours cost or our neighbour doesnt exist in the open list
                    if(newNeighbourCost < neighbour.gCost || !openList.Contains(neighbour))
                    {
                        //Update node costs
                        neighbour.gCost = newNeighbourCost;
                        neighbour.hCost = neighbour.GetDistance(endNode, STRAIGHT, DIAGONAL);
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
            if(pathNodeList[i].FCost < lowestFCost.FCost || pathNodeList[i].FCost == lowestFCost.FCost)
            {
                lowestFCost = pathNodeList[i];
            }

        }

        return lowestFCost;
    }
}
