using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

public class TestCalculateTwoPoints 
{
    [Test]
    public void WhenGetLengthBetweenTwoPointsOnSelectedAxis_AndOne_Vector3_0_23_34_And_Two_Vector3_23_4_2_ThenLengthXShouldBe23()
    {
        // ARRANGE
        Vector3 one = new Vector3(0, 23, 34);
        Vector3 two = new Vector3(23, 4, 2);

        // ACT
        float lengthX = CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(one, two, Axis.X);

        // ASSERT
        lengthX.Should().Be(23);
    }
    
    [Test]
    public void WhenGetLengthBetweenTwoPointsOnSelectedAxis_AndOne_Vector3_0_23_34_And_Two_Vector3_23_4_2_ThenLengthYShouldBe19()
    {
        // ARRANGE
        Vector3 one = new Vector3(0, 23, 34);
        Vector3 two = new Vector3(23, 4, 2);

        // ACT
        float lengthY = CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(one, two, Axis.Y);

        // ASSERT
        lengthY.Should().Be(19);
    }
    
    [Test]
    public void WhenGetLengthBetweenTwoPointsOnSelectedAxis_AndOne_Vector3_0_23_34_And_Two_Vector3_23_4_2_ThenLengthZShouldBe32()
    {
        // ARRANGE
        Vector3 one = new Vector3(0, 23, 34);
        Vector3 two = new Vector3(23, 4, 2);

        // ACT
        float lengthZ = CalculateTwoPoints.GetLengthBetweenTwoPointsOnSelectedAxis(one, two, Axis.Z);

        // ASSERT
        lengthZ.Should().Be(32);
    }

}
