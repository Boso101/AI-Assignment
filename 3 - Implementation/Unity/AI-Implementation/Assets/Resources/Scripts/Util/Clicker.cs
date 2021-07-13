﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    protected Game visual;
    public Agent playerAgent;


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
            Debug.Log(hit.collider.transform.position);
            Vector2 pos = hit.collider.transform.position;
            // We left clicked so try place start spot
            if(playerAgent)
            {
                playerAgent?.CalculateMovement(pos);
                return;
            }



        
        }
    }

}
