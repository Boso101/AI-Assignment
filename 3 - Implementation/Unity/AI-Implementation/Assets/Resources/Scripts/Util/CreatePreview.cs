using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePreview : MonoBehaviour
{
    public Transform position;
    public GameObject spawnedObject;

    public void CreateObjectPreview(GameObject objectToPreview, Vector3 pos)
    {
        GameObject spawnedObject = Instantiate(objectToPreview, pos, Quaternion.identity);

        //Delete all monobehaviours
        foreach (MonoBehaviour behaviour in spawnedObject.GetComponents<MonoBehaviour>())
        {
            Destroy(behaviour);
        }
    }

    public void Clear()
    {
        Destroy(spawnedObject);
    }
}