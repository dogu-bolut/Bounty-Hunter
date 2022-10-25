using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public int scoreValue1 = 50;
    public int scoreValue2 = 40;
    public int scoreValue3 = 60;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue1);
        }
    }
}
