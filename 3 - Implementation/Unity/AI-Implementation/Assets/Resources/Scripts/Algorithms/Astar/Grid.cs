using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    protected PathNode[,] pathNodeGrid;
    /// <summary>
    /// Here we will use some sort of Node system to create our grids for our AI to then use 
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// 

    public int rows;
    public int columns;

    //Holds best path
    public List<PathNode> path;


    public Grid(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        CreateGrid();
    }

    /// <summary>
    /// The stored version of the grid
    /// </summary>
    public void CreateGrid()
    {
        pathNodeGrid = new PathNode[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // 50% for the spot to be walkable
                pathNodeGrid[i, j] = new PathNode(i, j, Random.value > 0.5f);
            }
        }
    }

    public PathNode GetNode(int row, int column)
    {
        return pathNodeGrid[row, column];
    }


    public List<PathNode> GetNeighbours(PathNode node)
    {
        // Create neighbour list
        List<PathNode> neighbours = new List<PathNode>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                // {0,0} 
                if (x == 0 && y == 0)
                    continue;
                // Offset the current node by var values of x and y for neighbour checks
                int checkX = node.GetXPosition() + x;
                int checkY = node.GetYPosition() + y;

                // if our coordinates isn't invalid, add it to the neighbour list
                if (checkX >= 0 && checkX < rows && checkY >= 0 && checkY < columns)
                {
                    neighbours.Add(GetNode(checkX, checkY));
                }
            }
        }

        return neighbours;
    }
}
