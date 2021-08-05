using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TestProvideBordersCar
    {
        private ProvideBordersObject _bordersObject;
        private GameObject _cube;

        [SetUp]
        public void SetUp()
        {
            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _bordersObject = _cube.AddComponent<ProvideBordersObject>();
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
                _bordersObject.transform.TransformPoint(_bordersObject.GetPositionMeshPoint(SideMeshObject.Left));

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
                _bordersObject.transform.TransformPoint(_bordersObject.GetPositionMeshPoint(SideMeshObject.Up));

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
                _bordersObject.transform.TransformPoint(_bordersObject.GetPositionMeshPoint(SideMeshObject.Center));

            // ASSERT
            meshCenterPoint.Should().Be(positionCenterPoint);
        }
    }
}