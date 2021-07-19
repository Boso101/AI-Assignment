using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorScript : MonoBehaviour
{
    protected Agent playerObject;

    public Text playerMoveSpeed;
    public Text playerStraightCost;
    public Text diagonalMovementCost;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Agent>();
    }

    public void Apply()
    {
        playerObject.MoveTime = int.Parse(playerMoveSpeed.text);
        playerObject.StraightCost = int.Parse(playerStraightCost.text);
        playerObject.DiagonalCost = int.Parse(diagonalMovementCost.text);


    }

    public void UpdateEntityInfo()
    {
        playerMoveSpeed.text = playerObject.MoveTime.ToString();
        playerStraightCost.text = playerObject.StraightCost.ToString();
        diagonalMovementCost.text = playerObject.DiagonalCost.ToString();
    }
}
