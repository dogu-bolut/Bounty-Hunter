using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    //FindObjectOfType<GameSession>().AddToScore(scoreValue); add to event to make points count
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = GetScore().ToString();
        PlayerPrefs.SetInt("lastScore", score);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
    public void DelFromScore(int delValue)
    {
        if (score <= 0) { return; }
        score -= delValue;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
