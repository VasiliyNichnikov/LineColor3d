using NSubstitute;
using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class SplineTest
    {
        private ISpline _spline;

        public void SetUp()
        {
            _spline = Substitute.For<ISpline>();
        }

        [Test]
        public void TestAddOneCurve()
        {
            // ARRANGE
            _spline = Substitute.For<ISpline>();
            
            // ACT
            _spline.AddCurve();
            
            // ASSERT
            _spline.GetNumberPoints().Returns(7);
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
            _spline.GetNumberPoints().Returns(4);
        }
    }
}
