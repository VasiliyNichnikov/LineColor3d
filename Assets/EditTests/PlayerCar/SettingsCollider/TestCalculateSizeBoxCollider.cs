using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class TestCalculateSizeBoxCollider
{
    // private GameObject _cube;
    // private BoxCollider _collider;
    // private CalculateSizeBoxCollider _calculateSizeBoxCollider;
    // private IProvideBordersObject _provideBorders;
    // private Vector3 _colliderSize;
    //
    // [SetUp]
    // public void SetUp()
    // {
    //     _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     _collider = _cube.GetComponent<BoxCollider>();
    //     _calculateSizeBoxCollider = _cube.AddComponent<CalculateSizeBoxCollider>();
    //     
    //     _provideBorders = Substitute.For<IProvideBordersObject>();
    //     Vector3 right = new Vector3(0.5f, 0f, 0f);
    //     Vector3 left = new Vector3(-0.5f, 0f, 0f);
    //     _provideBorders.GetPositionMeshPoint(SideMeshObject.Right).Returns(right);
    //     _provideBorders.GetPositionMeshPoint(SideMeshObject.Left).Returns(left);
    //     _provideBorders.Transform.Returns(_cube.transform);
    //     _colliderSize = _collider.size;
    // }
    //
    // [TearDown]
    // public void TearDown()
    // {
    //     Object.DestroyImmediate(_cube);
    // }
    //
    // [Test]
    // public void WhenGetSizeBoxCollider_AndColliderSizeDefined_ThenSizeBoxColliderShouldBe_Vector3_1_colliderSizeY_colliderSizeZ()
    // {
    //     // ACT
    //     Vector3 sizeBoxCollider = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider, _provideBorders);
    //
    //     // ASSERT
    //     sizeBoxCollider.Should().Be(new Vector3(1f, _colliderSize.y, _colliderSize.z));
    // }
    //
    // [Test]
    // public void WhenGetSizeBoxCollider_AndInitRightAndLeftPoint_ThenSizeBoxColliderShouldBe_Vector3_001_colliderSizeY_colliderSizeZ()
    // {
    //     // ARRANGE
    //     Vector3 right = new Vector3(0.5f, 0.5f, 0.5f);
    //     Vector3 left = new Vector3(-0.5f, 0.5f, 0.5f);
    //
    //     // ACT
    //     Vector3 sizeBoxCollider = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider, right, left);
    //
    //     // ASSERT
    //     sizeBoxCollider.Should().Be(new Vector3(0.01f, _colliderSize.y, _colliderSize.z));
    // }
    //
    // [Test]
    // public void WhenGetPositionRigthAndLeftPointMeshCar_AndInitCenterObject_ThenRightShouldBe_Vector3_05_centerY_centerZ()
    // {
    //     // ARRANGE
    //     Vector3 center = Vector3.zero;
    //
    //     // ACT
    //     var (right,left) = _calculateSizeBoxCollider.GetPositionRigthAndLeftPointMeshCar(_provideBorders);
    //
    //     // ASSERT
    //     right.Should().Be(new Vector3(0.5f, center.y, center.z));
    // }
    //
    // [Test]
    // public void WhenGetPositionRigthAndLeftPointMeshCar_AndInitCenterObject_ThenLeftShouldBe_Vector3_Minus05_centerY_centerZ()
    // {
    //     // ARRANGE
    //     Vector3 center = Vector3.zero;
    //     // ACT
    //     var (right,left) = _calculateSizeBoxCollider.GetPositionRigthAndLeftPointMeshCar(_provideBorders);
    //
    //     // ASSERT
    //     left.Should().Be(new Vector3(-0.5f, center.y, center.z));
    // }
}