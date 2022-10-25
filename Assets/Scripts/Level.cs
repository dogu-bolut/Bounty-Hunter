using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    PauseMenu pauseMenu;
    [SerializeField] float delayInSeconds = 2f;
    [SerializeField] float lastWaveWait = 25f;
    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenu.Resume();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadGameOver());
    }
    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadSuccess()
    {
        StartCoroutine(WaitAndLoadSuccess());
    }
    IEnumerator WaitAndLoadSuccess()
    {
        yield return new WaitForSeconds(lastWaveWait);
        SceneManager.LoadScene("Success");
    }
    public void LoadHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
