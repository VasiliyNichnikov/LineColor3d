using UnityEngine;

public class SubtractionAxisY : SubtractionAxis
{
    public override float Subtract(Vector3 one, Vector3 two)
    {
        return one.y - two.y;
    }
}
