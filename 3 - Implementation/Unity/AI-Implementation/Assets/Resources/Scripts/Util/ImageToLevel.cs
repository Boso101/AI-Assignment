using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageToLevel : MonoBehaviour
{
  
    [SerializeField] protected Color playerColor;
   [SerializeField] protected Color wallColor;
   [SerializeField] protected Color chaserColor;



   


    public void Generate(Grid grid, Texture2D level, GameObject playerPrefab, GameObject chaserPrefab)
    {
        int i, j,counter;
        Color[] pixels = level.GetPixels();
        counter = 0;
        for (i = 0; i < level.width; i++)
        {
            for (j = 0; j < level.height; j++)
            {
                PathNode node = grid.GetNode(j, i);

                if(pixels[counter] == playerColor)
                {
                    Instantiate(playerPrefab, node.GetPosition(), Quaternion.identity);
                }
                else if (pixels[counter] == chaserColor)
                {
                    Instantiate(chaserPrefab, node.GetPosition(), Quaternion.identity);

                }
                else if(pixels[counter] == wallColor)
                {
                    if (node != null)
                        node.IsWalkable = false;

                }
                else
                {
                    //Walkable
                    if(node != null)
                        node.IsWalkable = true;
                }

                counter++;
            }
        }
    }
}
