using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class TestSettingsBehindPointOfObstacle
{
    private IParameterObstacle[] _parameterObstacles;
    private ProvideBordersObject _provideBorders;
    
    [SetUp]
    public void SetUp()
    {
        _provideBorders = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<ProvideBordersObject>();
        _parameterObstacles = new IParameterObstacle[3];
        GameObject[] objects =
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube),
            GameObject.CreatePrimitive(PrimitiveType.Cube),
            GameObject.CreatePrimitive(PrimitiveType.Cube)
        };
        Vector3[] positions = 
        {
            Vector3.zero,
            new Vector3(20, 0, 0),
            new Vector3(20, 0, 20)
        };

        for (int i = 0; i < _parameterObstacles.Length; i++)
        {
            objects[i].transform.position = positions[i];
            _parameterObstacles[i] = Substitute.For<IParameterObstacle>();
            _parameterObstacles[i].Transform.Returns(objects[i].transform);
            _parameterObstacles[i].ProvideBorders.Returns(_provideBorders);
        }
    }
    
    
    
    [Test]
    public void WhenGetCenterPointTransformObjects_AndRightCenterCounted_ThenCenterShouldBeRightCenter()
    {
        // ARRANGE
        int lenObstacles = _parameterObstacles.Length;
        Vector3 rightCenter = new Vector3(40, 0, 20) / lenObstacles;
        
        // ACT
        Vector3 center = SettingsBehindPointOfObstacle.GetCenterPointTransformObjects(_parameterObstacles);

        // ASSERT
        center.Should().Be(rightCenter);
    }

    [Test]
    public void WhenCreatingPointAndSelectingParent_AndPoint_NULL_Parent_CreatedObject_Position_Vector3Zero_ThenPointShouldNotBeNull()
    {
        // ARRANGE
        Transform point = null;
        Transform parent = new GameObject("Parent").transform;
        Vector3 position = Vector3.zero;
        
        // ACT
        point = SettingsBehindPointOfObstacle.CreatingPointAndSelectingParent(parent);
        
        // ASSERT
        point.Should().NotBeNull();
    }
    

    [Test]
    public void WhenGettingMostBehindPoint_AndRightBehindPosition_Vector3_CenterX_RightBehindPositionY_RightBehindPositionZ_ThenBehindPositionShouldBeRightBehindPosition()
    {
        // ARRANGE
        Vector3 center = SettingsBehindPointOfObstacle.GetCenterPointTransformObjects(_parameterObstacles);
        Vector3 rightBehindPosition = _parameterObstacles[0].ProvideBorders.GetPositionMeshPoint(SideMeshObject.Behind);
        rightBehindPosition = _provideBorders.transform.TransformPoint(rightBehindPosition);
        rightBehindPosition = new Vector3(center.x, rightBehindPosition.y, rightBehindPosition.z);
        
        // ACT
        Vector3 behindPosition = SettingsBehindPointOfObstacle.GettingMostBehindPoint(_parameterObstacles);

        // ASSERT
        behindPosition.Should().Be(rightBehindPosition);
    }


    
}
