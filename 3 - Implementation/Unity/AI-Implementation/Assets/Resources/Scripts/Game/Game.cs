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
        CreateGridVisual(grid);
    }



   

    /// <summary>
    /// The visualized version of the grid
    /// </summary>
        public void CreateGridVisual(Grid grid)
        {
        GameObject parent = new GameObject();
        parent.transform.position = Vector3.zero;

            for (int i = 0; i < rows; i++)
            {


                for (int j = 0; j < columns; j++)
                {
                    //Instantiate Grid Object 
                    GameObject gridObj = Instantiate(gridPrefab);
                    gridObj.transform.SetParent(parent.transform);
                    gridObj.transform.position = new Vector2(grid.GetNode(i, j).GetXPosition(), grid.GetNode(i, j).GetYPosition());
                    gridObj.name = gridObj.transform.position.ToString();

                // Change the color
                if(!grid.GetNode(i,j).IsWalkable)
                {
                    gridObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.black);
                }

                }
            }

        }

    
    
    public void PlaceFood(Vector2 pos)
    {

    }
    
}
