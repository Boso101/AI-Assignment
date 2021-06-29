using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Settings")]
    public int rows;
    public int columns;

    [SerializeField] protected GameObject gridPrefab;
    /// <summary>
    /// Here we will use some sort of Node system to create our grids for our AI to then use 
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// 


    private void Start()
    {
        CreateGrid(rows, columns);
    }

    public void CreateGrid(int rows, int columns)
    {

        for (int i = 0; i < rows; i++)
        {


            for (int j = 0; j < columns; j++)
            {
                //Instantiate Grid Object 
                GameObject gridObj = Instantiate(gridPrefab);
                gridObj.transform.position = new Vector2(i, j);


            }

        }

    }



    
    public void PlaceFood(Vector2 pos)
    {

    }
    
}
