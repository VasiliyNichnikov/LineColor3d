using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortObjectsRoad
{
    public Queue<Vector3> GettingSortArray(IDisplayAndGetBehindPointOfObstacle[] behindPointOfObstacles)
    {
        Queue<Vector3> positions = new Queue<Vector3>();
        Vector3[] points = new Vector3[behindPointOfObstacles.Length];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = behindPointOfObstacles[i].Point.position;
        }
        
        points = points.OrderBy(v => v.z).ToArray();
        foreach (var position in points)
        {
            positions.Enqueue(position);
        }

        return positions;
    }
}
