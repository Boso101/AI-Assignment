using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container class that holds an agents next path with A*
/// </summary>
public class PathContainer
{
    private int currentIndex = 0;
    private List<PathNode> path;

    public List<PathNode> Path { get => path; }

    /// <summary>
    /// Sets our path to follow
    /// </summary>
    /// <param name="path"></param>
    public void SetPath(List<PathNode> path)
    {
        currentIndex = 0;
        this.path = path;
    }

    /// <summary>
    /// Increases index counter
    /// </summary>
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

    /// <summary>
    /// Returns previous node
    /// </summary>
    /// <returns></returns>
    public PathNode ViewPreviousNode()
    {
        if (path == null || currentIndex >= path.Count || currentIndex < 0) return null;
        return path[currentIndex - 1];
    }

    /// <summary>
    /// Returns the very first node in the list of nodes
    /// </summary>
    /// <returns></returns>
    public PathNode ViewFirstNode()
    {
        return path[0];
    }

    /// <summary>
    /// Returns the very last node in the list of nodes.
    /// Useful when we want to track what our target location is
    /// </summary>
    /// <returns></returns>
    public PathNode ViewLastNode()
    {
        if(path == null || path.Count == 0)
        {
            return null;
        }


        return path[path.Count - 1];
        
    
    }


}
