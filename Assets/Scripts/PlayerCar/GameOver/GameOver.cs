using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
