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
        public void TestGetPositionMeshPointLeft()
        {
            // ARRANGE

            // ACT
            Vector3 result = new Vector3(-0.5f, 0.0f, 0.0f);

            // ASSERT
            Vector3 leftPoint =
                _bordersCar.transform.TransformPoint(_bordersCar.GetPositionMeshPoint(SideMeshCar.Left));
            Assert.AreEqual(result, leftPoint);
        }
        
        [Test]
        public void TestGetPositionMeshUpPoint()
        {
            // ARRANGE

            // ACT
            Vector3 result = new Vector3(0.0f, 0.5f, 0.0f);

            // ASSERT
            Vector3 upPoint =
                _bordersCar.transform.TransformPoint(_bordersCar.GetPositionMeshPoint(SideMeshCar.Up));
            Assert.AreEqual(result, upPoint);
        }
        
        [Test]
        public void TestGetPositionMeshCenterPoint()
        {
            // ARRANGE

            // ACT
            Vector3 result = new Vector3(0.0f, 0.0f, 0.0f);

            // ASSERT
            Vector3 centerPoint =
                _bordersCar.transform.TransformPoint(_bordersCar.GetPositionMeshPoint(SideMeshCar.Center));
            Assert.AreEqual(result, centerPoint);
        }
    }
}