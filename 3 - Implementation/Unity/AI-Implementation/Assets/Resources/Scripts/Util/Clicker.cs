using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    protected Visualizer visual;


    private void Awake()
    {
        visual = GameObject.FindObjectOfType<Visualizer>();
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
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SendRayCast("middle");
        }
    }


    private void SendRayCast(string type)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("GridComp"))
        {
            Debug.Log(hit.collider.transform.position);
            Vector2 pos = hit.collider.transform.position;
            // We left clicked so try place start spot
            if(type == "left")
            {
                //Set Start Pos
                PathNode node = visual.Grid.GetNode((int)pos.x, (int)pos.y);
                if(node != null && node.IsWalkable && visual.start != node)visual.start = node;
                else
                {
                    visual.start = null;
                }
                
            }
            else if (type == "middle")
            {
                PathNode node = visual.Grid.GetNode((int)pos.x, (int)pos.y);

                //Invert whatever it is
                if (node != null) node.IsWalkable = !node.IsWalkable;
            }
            else
            {
                // We right clicked so try place end spot

                //Set End Pos
                PathNode node = visual.Grid.GetNode((int)pos.x, (int)pos.y);
                if (node != null && node.IsWalkable && visual.end != node) visual.end = node;
                else
                {
                    visual.end = null;
                }
            }


            visual.RecolorImportant();
        }
    }

}
