using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Settings")]
    public int rows;
    public int columns;

    [SerializeField] protected GameObject gridPrefab;


    protected Grid grid;


    private void Start()
    {
        grid = new Grid(rows, columns);
    }



   

    /// <summary>
    /// The visualized version of the grid
    /// </summary>
        public void CreateGridVisual(Grid grid)
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
