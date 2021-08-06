using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

public class TestBorderPoints
{
    private Vector3 _center = new Vector3(0.5f, 0.5f, 0.5f);
    
    [Test]
    public void WhenGetPoint_AndGetBorderPointRight_ThenPositionPointShouldBeVector_MathInfinity_CenterY_CenterZ()
    {
        // ARRANGE
        BorderPoint right = new BorderPointRight();

        // ACT
        Vector3 positionPoint = right.GetPoint(_center);

        // ASSERT
        positionPoint.Should().Be(new Vector3(Mathf.Infinity, _center.y, _center.z));
    }
    
    [Test]
    public void WhenGetPoint_AndGetBorderPointLeft_ThenPositionPointShouldBeVector_MinusMathInfinity_CenterY_CenterZ()
    {
        // ARRANGE
        BorderPoint left = new BorderPointLeft();

        // ACT
        Vector3 positionPoint = left.GetPoint(_center);

        // ASSERT
        positionPoint.Should().Be(new Vector3(-Mathf.Infinity, _center.y, _center.z));
    }
    
    [Test]
    public void WhenGetPoint_AndGetBorderPointUp_ThenPositionPointShouldBeVector_CenterX_MathInfinity_CenterZ()
    {
        // ARRANGE
        BorderPoint up = new BorderPointUp();

        // ACT
        Vector3 positionPoint = up.GetPoint(_center);

        // ASSERT
        positionPoint.Should().Be(new Vector3(_center.x, Mathf.Infinity, _center.z));
    }
    
    [Test]
    public void WhenGetPoint_AndGetBorderPointForward_ThenPositionPointShouldBeVector_CenterX_CenterY_MathInfinity()
    {
        // ARRANGE
        BorderPoint forward = new BorderPointForward();

        // ACT
        Vector3 positionPoint = forward.GetPoint(_center);

        // ASSERT
        positionPoint.Should().Be(new Vector3(_center.x, _center.y, Mathf.Infinity));
    }
    
    [Test]
    public void WhenGetPoint_AndGetBorderPointBehind_ThenPositionPointShouldBeVector_CenterX_CenterY_MinusMathInfinity()
    {
        // ARRANGE
        BorderPoint behind = new BorderPointBehind();

        // ACT
        Vector3 positionPoint = behind.GetPoint(_center);

        // ASSERT
        positionPoint.Should().Be(new Vector3(_center.x, _center.y, -Mathf.Infinity));
    }
    
}
