using UnityEngine;

public class SubtractionAxisX : SubtractionAxis
{
    public override float Subtract(Vector3 one, Vector3 two)
    {
        return one.x - two.x;
    }
}
