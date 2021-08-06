using UnityEngine;

public class BorderPointForward: BorderPoint
{
    public override Vector3 GetPoint(Vector3 center)
    {
        return new Vector3(center.x, center.y, Mathf.Infinity);
    }
}
