using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lastScore;
    void Start()
    {
        if (highScore)
            highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        if (lastScore)
            lastScore.text = PlayerPrefs.GetInt("lastScore").ToString();
    }
}
