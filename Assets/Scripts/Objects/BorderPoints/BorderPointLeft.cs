using UnityEngine;

public class BorderPointLeft : BorderPoint
{
    public override Vector3 GetPoint(Vector3 center)
    {
        return new Vector3(-Mathf.Infinity, center.y, center.z);
    }
}
