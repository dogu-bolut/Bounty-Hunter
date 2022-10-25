using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused;
    public GameObject pauseMenuUI;
    Joystick joystick;
    //public MusicPlayer musicPlayer;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    public void StopAndGo()
    {
        if (isGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {
        //joystick.circle.transform.position = joystick.pointA;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        AudioListener.pause = true;
        //musicPlayer.GetComponent<AudioSource>().Pause();
    }
    public void Resume()
    {
        //joystick.circle.transform.position = joystick.pointA;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        AudioListener.pause = false;
        //musicPlayer.GetComponent<AudioSource>().Play();
    }
}
