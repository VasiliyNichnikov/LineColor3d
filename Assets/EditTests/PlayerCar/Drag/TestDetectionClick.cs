using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

public class TestDetectionClick
{
    private Camera _camera;
    private DetectionClick _detectionClick;
    private const float _sensitivity = 3.5f;

    [SetUp]
    public void SetUp()
    {
        _camera = new GameObject("Camera").AddComponent<Camera>();
        _detectionClick = new GameObject(nameof(DetectionClick)).AddComponent<DetectionClick>();
        _detectionClick.Camera = _camera;
        _detectionClick.Sensitivity = _sensitivity;
    }

    [Test]
    public void WhenGetDirection_AndMousePositionDown_Vector2Zero_MousePositionDrag_Vector2_10_2_ThenDirectionShouldBeResult()
    {
        // ARRANGE
        _detectionClick.MousePositionDown = Vector2.zero;
        _detectionClick.MousePositionDrag = new Vector2(10, 2);

        // ACT
        Vector2 direction = _detectionClick.GetDirection();

        // ASSERT
        Vector2 result = (new Vector2(10, 2) - Vector2.zero) * _sensitivity;
        result = _camera.ScreenToViewportPoint(result);
        direction.Should().Be(result);
    }
    
    [Test]
    public void WhenResetingMousePositionDownAndMousePositionDrag_AndMousePositionDown_Vector2Zero_ThenMousePositionDownShouldBe_VectorZero()
    {
        // ARRANGE
        _detectionClick.MousePositionDown = Vector2.zero;

        // ACT
        _detectionClick.ResetingMousePositionDownAndMousePositionDrag();

        // ASSERT
        _detectionClick.MousePositionDown.Should().Be(Vector2.zero);
    }

    [Test]
    public void WhenResetingMousePositionDownAndMousePositionDrag_AndMousePositionDrag_Vector2_10_2_ThenMousePositionDragShouldBe_VectorZero()
    {
        // ARRANGE
        _detectionClick.MousePositionDrag = new Vector2(10, 2);

        // ACT
        _detectionClick.ResetingMousePositionDownAndMousePositionDrag();

        // ASSERT
        _detectionClick.MousePositionDrag.Should().Be(Vector2.zero);
    }
}
