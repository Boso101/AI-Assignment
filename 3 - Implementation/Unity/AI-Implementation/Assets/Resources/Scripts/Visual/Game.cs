using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Settings")]
    public int rows;
    public int columns;
    public float percentageWalkable;

    [Header("GameObjects")]
    [SerializeField] protected GameObject gridPrefab;
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected GameObject playerPrefab;



    [Header("Debugging")]
    [SerializeField] protected Text userInput;

    protected Grid grid;

    //Associate each data node with its visual version
    protected Dictionary<PathNode,GameObject> tileVisuals;



    public PathNode start;
    public PathNode end;

    public Grid Grid { get => grid; }

    private void Awake()
    {

        grid = new Grid(rows, columns, percentageWalkable);


        
        CreateGridVisual(grid);
        UpdateVisuals();
        SpawnPlayer();

    }


   



 

   

    /// <summary>
    /// Colors everything depending if its walkable or not
    /// </summary>
    public void UpdateVisuals()
    {
        foreach(KeyValuePair<PathNode, GameObject> entry in tileVisuals)
        {
            entry.Value.GetComponentInChildren<Renderer>().material.SetColor("_Color", entry.Key.Color);
        }

    }

  


    /// <summary>
    /// The visualized version of the grid
    /// </summary>
    /// 

    //Not the most efficient solution, but it works for the scope of this project
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
                // Add to dictionary with the node as the key and the visual as the value
                tileVisuals.Add(node, gridObj);

                }
            }


        }

 

    public void SpawnPlayer()
    {

        //Spawn Player
        GameObject p = Instantiate(playerPrefab);






        //Set Player
        GameObject.FindObjectOfType<Clicker>().SetPlayer(p.GetComponent<BaseBehaviour>());
    }

    public void Clear()
    {
        grid.ClearGrid();
        UpdateVisuals();
    }

}
