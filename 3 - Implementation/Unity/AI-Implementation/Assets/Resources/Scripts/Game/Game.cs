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
    protected Astar algorithm;
    protected List<GameObject> tileVisuals;


    private void Start()
    {
        grid = new Grid(rows, columns, 0.65f);
        CreateGridVisual(grid);

        //Try Path thing once
        algorithm = new Astar();

        algorithm.FindPath(grid, 0, 0, 1, 8);
    }


    private void ShowPath()
    {
        if (grid.path != null)
        {
         
        }

    }

    private void UpdateVisuals()
    {
        foreach(GameObject rend in tileVisuals)
        {
            rend.GetComponent<Renderer>().material.SetColor("_Color", grid.GetNode((int)rend.transform.position.x, (int)rend.transform.position.y).Color);
        }
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
                    PathNode node = grid.GetNode(i, j);
                    GameObject gridObj = Instantiate(gridPrefab);
                    gridObj.transform.SetParent(parent.transform);
                    gridObj.transform.position = new Vector2(node.GetXPosition(), node.GetYPosition());
                    gridObj.name = gridObj.transform.position.ToString();

                    gridObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", node.Color);
                
                tileVisuals.Add(gridObj);

                }
            }

        }

    
    
    public void PlaceFood(Vector2 pos)
    {

    }
    
}
