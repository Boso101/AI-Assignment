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

    public PathNode GetNextNode()
    {
        if(currentIndex == path.Count - 1 || currentIndex < 0) return null;
        PathNode next = path[currentIndex];
        currentIndex++;

        return next;

    }


}
