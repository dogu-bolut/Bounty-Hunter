using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Canvas tutorialCanvas;
    void Awake()
    {
        tutorialCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("showhelp"))
        {
            tutorialCanvas.gameObject.SetActive(false);
            return;
            // Not the first time because pref already exists
            // Do nothing here
        }
        else
        {
            // First time because pref does not exist
            // Create pref
            PlayerPrefs.SetInt("showhelp", 0);
            // Call coroutine here
            tutorialCanvas.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutorialCanvas.gameObject.SetActive(false);
        }
    }
    public void CallTutorial()
    {
        tutorialCanvas.gameObject.SetActive(true);
    }
}
