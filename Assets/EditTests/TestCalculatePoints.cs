using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class TestCalculatePoints
{
    [Test]
    public void TestComparePoint_0_1_0_And_2_1_0_Get_2_1_0()
    {
        // ARRANGE
        
        // ACT
        Vector3 a = new Vector3(0, 1, 0);
        Vector3 b = new Vector3(2, 1, 0);
        
        // ASSERT
        Vector3 result = CalculatePoints.GetLergePoint(a, b);
        Assert.GreaterOrEqual(result.x, a.x);
        Assert.GreaterOrEqual(result.y, a.y);
        Assert.GreaterOrEqual(result.z, a.z);
    }
}
