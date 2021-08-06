using UnityEngine;

public class BorderPointCenter : BorderPoint
{
    public override Vector3 GetPoint(Vector3 center)
    {
        return center;
    }
}
