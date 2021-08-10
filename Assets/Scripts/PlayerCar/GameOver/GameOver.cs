using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private RejectionAnimationCar _rejectionAnimation;
    private static bool _isCrashed;
    public static bool IsCrashed => _isCrashed;

    public static void OffCrashed()
    {
        _isCrashed = false;
    }

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
        _isCrashed = true;
        _rejectionAnimation.ResettingHeightAndWidthAnimation();
        _rejectionAnimation.DepartureBack();
    }
    
}
