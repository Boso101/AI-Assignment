using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePreview : MonoBehaviour
{
    public GameObject spawnedObject;

    public void CreateObjectPreview(GameObject objectToPreview)
    {
        GameObject spawnedObject = Instantiate(objectToPreview);

        //Delete all monobehaviours
        foreach (MonoBehaviour behaviour in spawnedObject.GetComponents<MonoBehaviour>())
        {
            Destroy(behaviour);
        }
    }

    public void CreateObjectPreviewSprite(SpriteRenderer spr, Image img)
    {
        img.sprite = spr.sprite;
        img.color = spr.color;
    }

    public void Clear()
    {
        if(spawnedObject)Destroy(spawnedObject);
    }

    private void Update()
    {
        if(spawnedObject)
        {
            spawnedObject.transform.position = Input.mousePosition;
        }
    }
}