using UnityEngine;

public class CrashObstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            print($"Part car: {gameObject.name}; Obstacle: {other.gameObject.name}");
            EventManagerPlayerCar.CallGameOver();
        }
    }
}
