using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Game game;
    private GameObject selectedSpawnable;

    private void Awake()
    {
        game = GameObject.FindObjectOfType<Game>();
    }


    private void Update()
    {
        // Spawn GameObjects
        if(Input.GetMouseButtonDown(1))
        {
            SpawnObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }



        // Spawn Wall
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TrySpawnWall();
        }
    }

    public void SpawnObject(Vector2 pos)
    {
        if(selectedSpawnable != null)Instantiate(selectedSpawnable, pos, Quaternion.identity);
    }
    private void TrySpawnWall()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("GridComp"))
        {


            Debug.Log(hit.collider.transform.position);
            Vector2 pos = hit.collider.transform.position;
            // We left clicked so try place start spot
            PathNode node = game.Grid.GetNode((int)pos.x, (int)pos.y);
            node.IsWalkable = !node.IsWalkable;
            game.UpdateVisuals();
            
            



        }
    }

}
