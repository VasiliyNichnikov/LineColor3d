using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private MovementCar movementCar;
    
    private void OnEnable()
    {
        EventManagerPlayerCar.EventGameOver += HitObstacle;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventGameOver -= HitObstacle;
    }

    private void HitObstacle()
    {
        movementCar.SetState(new ResetSpeedToMinSpeedState());
    }
    
}
