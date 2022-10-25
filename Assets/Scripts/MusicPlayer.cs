using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public static MusicPlayer Instance;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Singleton();
    }
    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance._audioSource.clip != this._audioSource.clip)
        {
            Instance._audioSource.clip = this._audioSource.clip;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
