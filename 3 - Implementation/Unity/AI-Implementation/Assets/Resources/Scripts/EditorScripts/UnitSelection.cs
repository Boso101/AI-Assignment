using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField] protected GameObject selectionObject;

    protected GameObject marker;
    protected static Agent agentPtr;

    private void Start()
    {
        marker = Instantiate(selectionObject);
        UpdateAgent();
    }

    private void Update()
    {

        if (marker && agentPtr)
            marker.transform.position = agentPtr.transform.position;
        else
            marker.transform.position = new Vector2(99, 99); // throw outside
    }

    //Static so other stuff can call this easily
    public static void UpdateAgent()
    {
        agentPtr = EditorScript.GetAgent();
    }
}
