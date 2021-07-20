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
    [Header("Chaser Properties")]
    public GameObject sensorInputBox;
    public Text sensorTitle;
    public Text sensorRange;
    public Text sensorCurrentValue;

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

    public void Apply()
    {
        if (moveSpeed.text != string.Empty && straightCost.text != string.Empty && diagonalMovementCost.text != string.Empty)
        {
            targetAgent.MoveTime = float.Parse(moveSpeedT.text);
            targetAgent.StraightCost = int.Parse(straightCostT.text);
            targetAgent.DiagonalCost = int.Parse(diagonalMovementCostT.text);
        }

        UpdateEntityInfo();
    }

    public void UpdateEntityInfo()
    {
        moveSpeed.text = targetAgent.MoveTime.ToString();
        straightCost.text = targetAgent.StraightCost.ToString();
        diagonalMovementCost.text = targetAgent.DiagonalCost.ToString();

        //If we have chasers then include some new stuff
        if (targetAgent.gameObject.TryGetComponent<ChaserBehaviour>(out ChaserBehaviour chaser))
        {

            sensorTitle.gameObject.SetActive(true);
            sensorInputBox.SetActive(true);
        }
        else
        {
            sensorTitle.gameObject.SetActive(false);
            sensorInputBox.SetActive(false);



        }
    }

    private void Update()
    {
        //Middle mouse will select a new unit for us
        if (Input.GetMouseButton(2))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, agentMask);


            if (hit.collider)
            {
                if(hit.collider.gameObject.TryGetComponent<Agent>(out Agent ag))
                {
                    ChangeTargetAgent(ag);
                    UnitSelection.UpdateAgent();
                }


           




            }

        }
    }
}
