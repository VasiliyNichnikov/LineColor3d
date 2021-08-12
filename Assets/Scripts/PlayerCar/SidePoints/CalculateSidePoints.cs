using UnityEngine;

namespace PlayerCar.SidePoints
{
    public static class CalculateSidePoints
    {
        public static float GetLengthBetweenTwoPointsOnSelectedAxisModule(SubtractionAxis axis, ISidePoint one, ISidePoint two)
        {
            Vector3 positionOne = one.Transform.position;
            Vector3 positionTwo = two.Transform.position;
            return Mathf.Abs(axis.Subtract(positionOne, positionTwo));
        }
    }
}