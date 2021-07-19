using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorScript : MonoBehaviour
{
    protected Agent playerObject;

    public Text playerMoveSpeed;
    public Text playerMovementCost;
    public Text diagonalmovementCost;



    public void Apply()
    {
        playerObject.MoveTime = int.Parse(playerMoveSpeed.text);
        playerObject.movem = int.Parse(playerMoveSpeed.text);

    }
}
