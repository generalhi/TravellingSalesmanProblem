using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public List<Vector3> GetPoints()
    {
        var pointObjects = GetComponentsInChildren<Point>();
        var points = new List<Vector3>(pointObjects.Length);
        if (pointObjects.Length > 0)
        {
            foreach (var pointObject in pointObjects)
            {
                points.Add(pointObject.GetPoint());
            }
        }

        return points;
    }
}
