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
        var result = CalculatePoints.GetLergePoint(a, b);
        Assert.GreaterOrEqual(result.max.x, result.min.x);
        Assert.GreaterOrEqual(result.max.y, result.min.y);
        Assert.GreaterOrEqual(result.max.z, result.min.z);
    }
}
