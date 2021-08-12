using UnityEngine;

namespace PlayerCar.SidePoints
{
    public interface ISidePoint
    {
        Transform Transform { get; }
        void ChangingPosition(Vector3 position);
    }
}