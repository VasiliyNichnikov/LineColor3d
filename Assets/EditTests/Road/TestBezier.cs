using System;
using NUnit.Framework;
using UnityEngine;

public class TestBezier
{
    [Test]
    public void TestGetPointBezier()
    {
        // ARRANGE
        Vector2 p0 = new Vector2(0, 0);
        Vector2 p1 = new Vector2(-1, 3);
        Vector2 p2 = new Vector2(3, 2);
        Vector2 p3 = new Vector2(4, 1);
        float t = 0.4f;

        // ACT
        Vector2 result = new Vector2(0.69f, 1.94f);

        // ASSERT
        Vector2 point = Bezier.GetPoint(p0, p1, p2, p3, t);
        Vector2 roundedPoint = new Vector2(RoundingTwoDecimalPlaces(point.x), RoundingTwoDecimalPlaces(point.y));
        Assert.AreEqual(roundedPoint, result);
    }

    private float RoundingTwoDecimalPlaces(float number)
    {
        return (float) Math.Round(number, 2);
    }
}