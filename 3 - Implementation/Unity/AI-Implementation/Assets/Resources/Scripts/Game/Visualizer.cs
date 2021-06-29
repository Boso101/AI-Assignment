using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    [Header("Settings")]
    public int rows;
    public int columns;
    public float percentageWalkable;
    [SerializeField] protected GameObject gridPrefab;

    [Header("Debugging")]
    [SerializeField] protected Text userInput;

    protected Grid grid;
    protected Astar algorithm;

    //Associate each visual with its data version
    protected Dictionary<PathNode,GameObject> tileVisuals;

    public PathNode start;
    public PathNode end;

    public Grid Grid { get => grid; }

    private void Start()
    {
        grid = new Grid(rows, columns, percentageWalkable);
        CreateGridVisual(grid);

        //Try Path thing once
        algorithm = new Astar();

    }


    /// <summary>
    /// Draws the path calculated by the algorithm
    /// </summary>
    private void ShowPath()
    {
        if (grid.path != null)
        {
         foreach(PathNode node in grid.path)
            {
                tileVisuals[node].GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.green);
            }
        }

    }

    /// <summary>
    /// Colors the start and end points
    /// </summary>
public void RecolorImportant()
    {
        UpdateVisuals();
        ColorStart();
        ColorEnd();
    }

    protected void ColorStart()
    {
        try
        {
            GameObject starter = tileVisuals[start];
            starter?.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.blue);


        }
        catch
        {
            Debug.LogError("Something went wrong while fetching visual version of node");

        }
    }

    protected void ColorEnd()
    {
        try
        {
            GameObject ender = tileVisuals[end];
            ender?.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);

        }
        catch
        {
            Debug.LogError("Something went wrong while fetching visual version of node");

        }

    }

    /// <summary>
    /// Colors everything depending if its walkable or not
    /// </summary>
    private void UpdateVisuals()
    {
        foreach(KeyValuePair<PathNode, GameObject> entry in tileVisuals)
        {
            entry.Value.GetComponentInChildren<Renderer>().material.SetColor("_Color", entry.Key.Color);
        }

    }

  
    /// <summary>
    /// Randomize the current maze
    /// </summary>
    public void Randomize()
    {
        // go through each node and change whether or not they are walkable based on user %
        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {

                try
                {

                grid.GetNode(i, j).IsWalkable = Random.value <= float.Parse(userInput.text);
                }
                catch
                {
                    Debug.LogError("Invalid % given");
                }


            }
        }

        //Loop through and update visuals
        start = null;
        end = null;
        UpdateVisuals();
        

       
    }

    /// <summary>
    /// The visualized version of the grid
    /// </summary>
    public void CreateGridVisual(Grid grid)
        {
        GameObject parent = new GameObject();
        parent.transform.position = Vector3.zero;
        tileVisuals = new Dictionary<PathNode, GameObject>();
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
                
                tileVisuals.Add(node, gridObj);

                }
            }

        }

    /// <summary>
    /// Uses the debug button to find a path
    /// </summary>
    public void FindPath()
    {
        if(start != null && end != null)
        {

        algorithm.FindPath(grid, start.GetXPosition(), start.GetYPosition(), end.GetXPosition(), end.GetYPosition());
        ShowPath();
        }

    }





}
