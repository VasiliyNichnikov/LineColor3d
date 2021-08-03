using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TestProvideBordersCar
    {
        private ProvideBordersCar _bordersCar;
        private GameObject _cube;

        [SetUp]
        public void SetUp()
        {
            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _bordersCar = _cube.AddComponent<ProvideBordersCar>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_cube);
        }

        [Test]
        public void WhenGetPositionMeshPoint_AndParametersEqualLeftPoint_TheGettingPositionLeftPoint()
        {
            // ARRANGE
            Vector3 positionLeftPoint = new Vector3(-0.5f, 0.0f, 0.0f);

            // ACT
            Vector3 meshLeftPoint =
                _bordersCar.transform.TransformPoint(_bordersCar.GetPositionMeshPoint(SideMeshCar.Left));

            // ASSERT
            meshLeftPoint.Should().Be(positionLeftPoint);
        }


        [Test]
        public void WhenGetPositionMeshPoint_AndParametersEqualUpPoint_TheGettingPositionUpPoint()
        {
            // ARRANGE
            Vector3 positionUpPoint = new Vector3(0.0f, 0.5f, 0.0f);

            // ACT
            Vector3 meshUpPoint =
                _bordersCar.transform.TransformPoint(_bordersCar.GetPositionMeshPoint(SideMeshCar.Up));

            // ASSERT
            meshUpPoint.Should().Be(positionUpPoint);
        }

        [Test]
        public void WhenGetPositionMeshPoint_AndParametersEqualCenterPoint_TheGettingPositionCenterPoint()
        {
            // ARRANGE
            Vector3 positionCenterPoint = new Vector3(0.0f, 0.0f, 0.0f);

            // ACT
            Vector3 meshCenterPoint =
                _bordersCar.transform.TransformPoint(_bordersCar.GetPositionMeshPoint(SideMeshCar.Center));

            // ASSERT
            meshCenterPoint.Should().Be(positionCenterPoint);
        }
    }
}