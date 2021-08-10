using UnityEngine;

public class SubtractionAxisZ: SubtractionAxis
{
    public override float Subtract(Vector3 one, Vector3 two)
    {
        return one.z - two.z;
    }
}
