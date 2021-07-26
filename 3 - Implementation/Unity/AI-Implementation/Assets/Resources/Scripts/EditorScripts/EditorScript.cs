using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This will do but it isn't really dynamic... Only works with BaseBehaviour and ChaserBehaviour
/// </summary>
public class EditorScript : MonoBehaviour
{
    [Header("Raycast Stuff")]
    public LayerMask agentMask;
    protected static Agent targetAgent;
    [Header("PlaceHolders")]
    public Text moveSpeed;
    public Text straightCost;
    public Text diagonalMovementCost;
    [Header("True Text Values")]
    public Text moveSpeedT;
    public Text straightCostT;
    public Text diagonalMovementCostT;

    public static void ChangeTargetAgent(Agent newAgent)
    {
        targetAgent = newAgent;
    }

    public static Agent GetAgent()
    {
        return targetAgent;
    }
    private void Awake()
    {
        targetAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<Agent>(); 
        UpdateEntityInfo();
    }

    /// <summary>
    /// Tries to apply everything that has been changed from the user to the agent
    /// </summary>
    public void Apply()
    {
        //Can only do if one of the boxes have been changed atleast
        if (moveSpeed.text != string.Empty || straightCost.text != string.Empty || diagonalMovementCost.text != string.Empty)
        {
            try
            {

                targetAgent.MoveTime = float.Parse(moveSpeedT.text);
                targetAgent.StraightCost = int.Parse(straightCostT.text);
                targetAgent.DiagonalCost = int.Parse(diagonalMovementCostT.text);
            }

            catch
            {
                //Silently continue
                Debug.Log("Something went wrong trying to parse the values");
            }
        }

        UpdateEntityInfo();
    }

    /// <summary>
    /// Just updates the entitys visual information
    /// </summary>
    public void UpdateEntityInfo()
    {
        moveSpeed.text = targetAgent.MoveTime.ToString();
        straightCost.text = targetAgent.StraightCost.ToString();
        diagonalMovementCost.text = targetAgent.DiagonalCost.ToString();
        moveSpeedT.text = String.Empty;
        straightCostT.text = String.Empty;
        diagonalMovementCostT.text = String.Empty;


    }

    private void Update()
    {
        //Middle mouse will select a new unit for us
        if (Input.GetMouseButtonDown(2))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, agentMask);


            if (hit.collider)
            {
                if (hit.collider.gameObject.TryGetComponent<Agent>(out Agent ag))
                {
                    //Update selection
                    ChangeTargetAgent(ag);
                    UnitSelection.UpdateAgent();
                    UpdateEntityInfo();
                }







            }

        }
    }

    public void DestroyEntity()
    {
        if(targetAgent == null) { return; }
        //We don't want to destroy our player

        if (!targetAgent.CompareTag("Player"))
            Destroy(targetAgent.gameObject);

        //Assign to a random ent
        ChangeTargetAgent(GameObject.FindObjectsOfType<Agent>()[0]);
        UnitSelection.UpdateAgent();
        UpdateEntityInfo();
    }
}
