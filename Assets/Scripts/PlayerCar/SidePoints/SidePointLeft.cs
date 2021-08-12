using UnityEngine;

namespace PlayerCar.SidePoints
{
    public class SidePointLeft: MonoBehaviour, ISidePoint
    {
        public Transform Transform => transform;
        
        public void ChangingPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}