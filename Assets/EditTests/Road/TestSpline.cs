using NSubstitute;
using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class TestSpline
    {
        private ISpline _spline;
        
        [Test]
        public void TestAddOneCurve()
        {
            // ARRANGE
            _spline = Substitute.For<ISpline>();
            
            // ACT
            _spline.AddCurve();
            
            // ASSERT
            _spline.LengthPoints.Returns(7);
            Assert.AreEqual(_spline.LengthPoints, 7);
        }
        
        [Test]
        public void TestAddAndRemoveOneCurve()
        {
            // ARRANGE
           _spline = Substitute.For<ISpline>();
           
            // ACT
            _spline.AddCurve();
            _spline.RemoveCurve();
            
            // ASSERT
            _spline.LengthPoints.Returns(4);
            Assert.AreEqual(_spline.LengthPoints, 4);
        }
    }
}
