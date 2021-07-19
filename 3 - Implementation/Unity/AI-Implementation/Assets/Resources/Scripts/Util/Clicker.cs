using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    protected Game visual;
    public BaseBehaviour playerAgent;

    public void SetPlayer(BaseBehaviour agent)
    {
        playerAgent = agent;
    }

    private void Awake()
    {
        visual = GameObject.FindObjectOfType<Game>();
    }
    private void Update()
    {
       
        if(Input.GetMouseButtonDown(0))
        {

            SendRayCast();
        }



    }


    private void SendRayCast()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("GridComp"))
        {



            Vector2 pos = hit.collider.transform.position;
            // We left clicked so try place start spot
            PathNode node = visual.Grid.GetNode((int)pos.x, (int)pos.y);
            
            if (node != null && node.IsWalkable)
            {

           


            if (playerAgent)
            {
                playerAgent?.TryMoveTo(node);
                
               
                return;
            }


            }



        }
    }

}
