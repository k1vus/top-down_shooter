using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void RestartGameController()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        MonoBehaviour[] components = FindObjectsOfType<MonoBehaviour>();
        
        foreach (MonoBehaviour component in components)
        {
            if (component is IRestartable restartable)
            {
                restartable.Restart();
            }
        }

        RestartGameController();
    }
}
