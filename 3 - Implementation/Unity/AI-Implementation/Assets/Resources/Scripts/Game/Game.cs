using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Settings")]
    public int rows;
    public int columns;

    [SerializeField] protected GameObject gridPrefab;

    protected PathNode[,] grid;
    /// <summary>
    /// Here we will use some sort of Node system to create our grids for our AI to then use 
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// 


    private void Start()
    {
        CreateGrid();
        CreateGridVisual();
    }



    /// <summary>
    /// The stored version of the grid
    /// </summary>
    public void CreateGrid()
    {
        grid = new PathNode[rows, columns];

        for (int i = 0; i < rows; i++)
        {


            for (int j = 0; j < columns; j++)
            {
                grid[i,j] = new PathNode(i, j);
            }
        }
    }

    /// <summary>
    /// The visualized version of the grid
    /// </summary>
        public void CreateGridVisual()
        {

            for (int i = 0; i < rows; i++)
            {


                for (int j = 0; j < columns; j++)
                {
                    //Instantiate Grid Object 
                    GameObject gridObj = Instantiate(gridPrefab);
                    gridObj.transform.position = grid[i,j].GetPosition();
                    gridObj.name = gridObj.transform.position.ToString();
                }
            }

        }

    
    
    public void PlaceFood(Vector2 pos)
    {

    }
    
}
