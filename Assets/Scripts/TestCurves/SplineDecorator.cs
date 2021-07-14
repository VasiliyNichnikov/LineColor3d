using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineDecorator : MonoBehaviour
{
    public BezierSpline spline;

    public int frequency;

    public bool lookForward;

    public Transform Road;

    private void Awake()
    {
        if (frequency <= 0 || Road == null)
        {
            return;
        }

        float stepSize = 1f / frequency;
        for (int p = 0, f = 0; f < frequency; f++)
        {
            Transform item = Instantiate(Road);
            // item.localScale = new Vector3(item.localScale.x, item.localScale.y, item.localScale.z);
            Vector3 position = spline.GetPoint(1 * stepSize);
            item.transform.localPosition = position;
            if (lookForward)
            {
                item.transform.LookAt(position + spline.GetDirection(1 * stepSize));
            }

            item.transform.parent = transform;
        }
    }
}