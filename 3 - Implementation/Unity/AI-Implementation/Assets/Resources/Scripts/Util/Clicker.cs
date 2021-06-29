using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    protected Game game;


    private void Awake()
    {
        game = GameObject.FindObjectOfType<Game>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Debug.Log("Left");
            SendRayCast("left");
        }

        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right");
            SendRayCast("right");
        }
    }


    private void SendRayCast(string type)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("GridComp"))
        {
            Vector2 pos = hit.collider.transform.position;
            // We left clicked so try place start spot
            if(type == "left")
            {
                //Set Start Pos
                PathNode node = game.Grid.GetNode((int)pos.x, (int)pos.y);
            }
            else
            {
                // We right clicked so try place end spot

                //Set End Pos

            }

        }
    }

}
