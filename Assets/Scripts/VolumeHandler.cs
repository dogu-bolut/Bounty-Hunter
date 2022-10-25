using UnityEngine;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Image soundOnImage;
    [SerializeField] Image soundOffImage;
    private bool muted = false;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (volumeSlider.value == 0) { AudioListener.pause = true; }
        if (!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 0.6f);
            AudioListener.volume = 0.6f;
            soundOffImage.gameObject.SetActive(false);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
        if (volumeSlider.value == 0)
        {
            muted = true;
            AudioListener.pause = true;
            soundOnImage.gameObject.SetActive(false);
            soundOffImage.gameObject.SetActive(true);
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            soundOnImage.gameObject.SetActive(true);
            soundOffImage.gameObject.SetActive(false);
        }
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            soundOnImage.gameObject.SetActive(false);
            soundOffImage.gameObject.SetActive(true);
            volumeSlider.value = 0f;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            soundOnImage.gameObject.SetActive(true);
            soundOffImage.gameObject.SetActive(false);
            volumeSlider.value = 0.6f;
        }
    }
    public void Load()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicvolume");
        volumeSlider.value = PlayerPrefs.GetFloat("musicvolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeSlider.value);
    }
}

