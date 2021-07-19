using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePreview : MonoBehaviour
{
    public GameObject objectToPreview;



    public void CreateObjectPreview(Vector3 position)
    {
        GameObject preview = Instantiate(objectToPreview, position, Quaternion.identity);

        //Delete all monobehaviours
        foreach (MonoBehaviour behaviour in preview.GetComponents<MonoBehaviour>())
        {
            Destroy(behaviour);
        }
    }
}