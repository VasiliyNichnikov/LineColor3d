using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestBeziersFirstOrder
    {
        private BeziersFirstOrder _bezier;

        [SetUp]
        public void SetUp()
        {
            _bezier = new GameObject("Name Object", typeof(BeziersFirstOrder)).GetComponent<BeziersFirstOrder>();
        }

        [UnityTest]
        public IEnumerator TestGetPoint()
        {
            _bezier.P0 = new Vector3(0, 0, 0);
            _bezier.P1 = new Vector3(5, 0, 0);

            float t = 0.5f;
            Vector3 result = new Vector3(2.5f, 0, 0);
            yield return null;
            Vector3 getPoint = _bezier.GetPoint(t);
            Assert.AreEqual(result, getPoint);
        }
    }
}