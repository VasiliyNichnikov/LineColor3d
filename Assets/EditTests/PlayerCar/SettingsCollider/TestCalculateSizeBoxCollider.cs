using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class TestCalculateSizeBoxCollider
{
    private GameObject _cube;
    private BoxCollider _collider;
    private CalculateSizeBoxCollider _calculateSizeBoxCollider;

    [SetUp]
    public void SetUp()
    {
        _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _collider = _cube.GetComponent<BoxCollider>();
        _calculateSizeBoxCollider = _cube.AddComponent<CalculateSizeBoxCollider>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_cube);
    }

    [Test]
    public void WhenGetSizeBoxCollider_Andarrange_Thenassert()
    {
        // ARRANGE
        // _calculateSizeBoxCollider.ProvideBorders = Substitute.For<IProvideBordersObject>();
        // _calculateSizeBoxCollider.ProvideBorders.GetPositionMeshPoint(SideMeshObject.Right).Returns(new Vector3(0.5f, 0.5f, 0.5f));
        // _calculateSizeBoxCollider.ProvideBorders.GetPositionMeshPoint(SideMeshObject.Left).Returns(new Vector3(-0.5f, 0.5f, 0.5f));
        // _calculateSizeBoxCollider.ProvideBordersObject.Returns(provideBordersObject);
        Vector3 colliderSize = _collider.size;
        
        // ACT
        Vector3 sizeBoxCollider = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider);
        
        // ASSERT
        sizeBoxCollider.Should().Be(new Vector3(1f, colliderSize.y, colliderSize.z));
    }
}