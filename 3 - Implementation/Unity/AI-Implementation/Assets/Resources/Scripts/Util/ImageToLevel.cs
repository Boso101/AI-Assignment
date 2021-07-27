using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageToLevel : MonoBehaviour
{

    [SerializeField] protected Color playerColor;
    [SerializeField] protected Color wallColor;
    [SerializeField] protected Color chaserColor;

    public bool Generate(Grid grid, string levelDir, GameObject playerPrefab, GameObject chaserPrefab)
    {
        Texture2D level = LoadImage(levelDir, 40, 40);
        if (level == null) { return false; }
        int i, j, counter;
        PathNode node;
        Color[] pixels = level.GetPixels(); // we use counter to index into this
        counter = 0;
        for (i = 0; i < level.width; i++)
        {
            for (j = 0; j < level.height; j++)
            {
                 node = grid.GetNode(j, i);

                //Found player color
                if (pixels[counter] == playerColor)
                {
                    Instantiate(playerPrefab, node.GetPosition(), Quaternion.identity);
                    node.IsWalkable = true;
                }
                //Found chaser color
                else if (pixels[counter] == chaserColor)
                {
                    Instantiate(chaserPrefab, node.GetPosition(), Quaternion.identity);
                    node.IsWalkable = true;

                }
                //Found wall color
                else if (pixels[counter] == wallColor)
                {
                    if (node != null)
                        node.IsWalkable = false;

                }
                else
                {
                    //Walkable
                    if (node != null)
                        node.IsWalkable = true;
                }

                counter++;
            }
        }
        return true;

    }

    public Texture2D LoadImage(string filePath, int width, int height)
    {
        Texture2D tex = null; // Set to null so that we can return tex later
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(width, height);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
}

