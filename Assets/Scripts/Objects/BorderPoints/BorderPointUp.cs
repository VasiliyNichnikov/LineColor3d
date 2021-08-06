using UnityEngine;

public class BorderPointUp: BorderPoint
{
    public override Vector3 GetPoint(Vector3 center)
    {
        return new Vector3(center.x, Mathf.Infinity, center.z);
    }
}
