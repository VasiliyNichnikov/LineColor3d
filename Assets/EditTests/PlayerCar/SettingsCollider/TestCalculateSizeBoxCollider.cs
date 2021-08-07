using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

public class TestCalculateSizeBoxCollider
{
    private GameObject _cube;
    private BoxCollider _collider;
    private CalculateSizeBoxCollider _calculateSizeBoxCollider;
    private ProvideBordersObject _provideBorders;

    [SetUp]
    public void SetUp()
    {
        _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _collider = _cube.GetComponent<BoxCollider>();
        _calculateSizeBoxCollider = _cube.AddComponent<CalculateSizeBoxCollider>();
        _provideBorders = _cube.AddComponent<ProvideBordersObject>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_cube);
    }

    [Test]
    public void WhenGetSizeBoxCollider_AndColliderSizeDefined_ThenSizeBoxColliderShouldBe_Vector3_1_colliderSizeY_colliderSizeZ()
    {
        // ARRANGE
        _calculateSizeBoxCollider.ProvideBordersObject = _provideBorders;
        Vector3 colliderSize = _collider.size;

        // ACT
        Vector3 sizeBoxCollider = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider);

        // ASSERT
        sizeBoxCollider.Should().Be(new Vector3(1f, colliderSize.y, colliderSize.z));
    }
    
    [Test]
    public void WhenGetSizeBoxCollider_AndInitRightAndLeftPoint_ThenSizeBoxColliderShouldBe_Vector3_001_colliderSizeY_colliderSizeZ()
    {
        // ARRANGE
        _calculateSizeBoxCollider.ProvideBordersObject = _provideBorders;
        Vector3 right = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 left = new Vector3(-0.5f, 0.5f, 0.5f);
        Vector3 colliderSize = _collider.size;

        // ACT
        Vector3 sizeBoxCollider = _calculateSizeBoxCollider.GetSizeBoxCollider(_collider, right, left);

        // ASSERT
        sizeBoxCollider.Should().Be(new Vector3(0.01f, colliderSize.y, colliderSize.z));
    }
    
    [Test]
    public void WhenGetPositionRigthAndLeftPointMeshCar_AndInitCenterObject_ThenRightShouldBe_Vector3_05_centerY_centerZ()
    {
        // ARRANGE
        _calculateSizeBoxCollider.ProvideBordersObject = _provideBorders;
        Vector3 center = Vector3.zero;

        // ACT
        var (right,left) = _calculateSizeBoxCollider.GetPositionRigthAndLeftPointMeshCar();

        // ASSERT
        right.Should().Be(new Vector3(0.5f, center.y, center.z));
    }
    
    [Test]
    public void WhenGetPositionRigthAndLeftPointMeshCar_AndInitCenterObject_ThenLeftShouldBe_Vector3_Minus05_centerY_centerZ()
    {
        // ARRANGE
        _calculateSizeBoxCollider.ProvideBordersObject = _provideBorders;
        Vector3 center = Vector3.zero;

        // ACT
        var (right,left) = _calculateSizeBoxCollider.GetPositionRigthAndLeftPointMeshCar();

        // ASSERT
        left.Should().Be(new Vector3(-0.5f, center.y, center.z));
    }
}