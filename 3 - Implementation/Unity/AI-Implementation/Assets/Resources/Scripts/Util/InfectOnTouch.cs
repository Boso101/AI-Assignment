using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectOnTouch : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Chaser"))
        {
            Vector2 pos = collision.gameObject.transform.position;
            Destroy(collision.gameObject);

            //25% chance of infecting
            if (Random.value <= 0.25f)
            {
                GameObject newZomb = Instantiate(gameObject, pos, Quaternion.identity);

                //Mess with its vars
                if (newZomb.TryGetComponent<Agent>(out Agent ag))
                {
                    ag.StraightCost = Random.Range(1, 20);
                    ag.DiagonalCost = Random.Range(1, 20);
                    ag.MoveTime = Random.Range(0.75f, 3);



                }
            }
        }
    }
}
