using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathContainer
{
    private int currentIndex = 0;
    private List<PathNode> path;

    public List<PathNode> Path { get => path; }

    public void SetPath(List<PathNode> path)
    {
        currentIndex = 0;
        this.path = path;
    }

    public void Next()
    {

        currentIndex++;

   

    }

    // Just Returns the next node, doesn't do anything with movement
    public PathNode ViewNextNode()
    {
        if ( path == null || currentIndex >= path.Count || currentIndex < 0) return null;
        return path[currentIndex];
    }

    public PathNode ViewPreviousNode()
    {
        if (path == null || currentIndex >= path.Count || currentIndex < 0) return null;
        return path[currentIndex - 1];
    }

    public PathNode ViewFirstNode()
    {
        return path[0];
    }

    public PathNode ViewLastNode()
    {
        return path[path.Count - 1];
    }


}
