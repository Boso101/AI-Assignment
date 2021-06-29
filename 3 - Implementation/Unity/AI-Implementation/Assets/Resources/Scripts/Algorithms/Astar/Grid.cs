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

    public Grid(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
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
                pathNodeGrid[i, j] = new PathNode(i, j);
            }
        }
    }
}
