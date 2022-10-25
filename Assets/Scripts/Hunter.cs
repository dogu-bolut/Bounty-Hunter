using UnityEngine;
using System.Collections;
using TMPro;

public class Hunter : MonoBehaviour
{
    public float speed = 0.09f;
    [SerializeField] float fastSpeed = 0.13f;
    [SerializeField] float slowSpeed = 0.05f;
    float normalSpeed;

    [SerializeField] TextMeshProUGUI Warning1;
    [SerializeField] TextMeshProUGUI PickedUp1;
    [SerializeField] TextMeshProUGUI Prison1;
    public int[] scores = new int[3];
    public GameObject[] bandits = new GameObject[3];
    public GameObject[] shinebandits = new GameObject[3];
    [SerializeField] float banditDisappearTime = 0.3f;
    [SerializeField] Transform whipSparkle;
    [SerializeField] Transform nailSparkle;
    bool hasBounty;
    bool shineBandit;
    Rigidbody2D myRigidbody;
    GameObject banditClone;
    int randomBanditNumber;
    public RectTransform canvas;
    void Start()
    {
        normalSpeed = speed;
        myRigidbody = GetComponent<Rigidbody2D>();
        Invoke("ShineBandits", 6f);

        randomBanditNumber = Random.Range(0, 3);
        Vector2 position = Camera.main.ScreenToViewportPoint(new Vector2(Random.Range(canvas.rect.xMin, canvas.rect.xMax) * 20, Random.Range(canvas.rect.yMin, canvas.rect.yMax) * 15)); // -18, 18), Random.Range(-7, 9));
        banditClone = Instantiate(bandits[randomBanditNumber], position, Quaternion.identity);
        
        whipSparkle.GetComponent<ParticleSystem>().enableEmission = false;
        nailSparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
    void Update()
    {
        if (shineBandit)
        {
            banditClone.GetComponent<SpriteRenderer>().sprite = shinebandits[randomBanditNumber].GetComponent<SpriteRenderer>().sprite;
        }
    }
    private void FixedUpdate()
    {
        FlipSprite();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Border")) { return; }
        FindObjectOfType<GameSession>().DelFromScore(5);
        Debug.Log("Collision detected");
        StartCoroutine(FadeText(0.5f, Warning1));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bandit"))
        {
            if (hasBounty) 
            {
                return;
            }
            hasBounty = true;
            StartCoroutine(FadeText(0.5f, PickedUp1));
            Destroy(collision.gameObject, banditDisappearTime);
            
        }
        if (collision.CompareTag("Jail") && hasBounty)
        {
            int randomScoreNumber = Random.Range(0, 3);
            FindObjectOfType<GameSession>().AddToScore(scores[randomScoreNumber]);
            StartCoroutine(FadeText(0.5f, Prison1));
            Debug.Log("Reward earned");
            hasBounty = false;
            shineBandit = false;
            Invoke("ShineBandits", 6f);
            randomBanditNumber = Random.Range(0, 3);
            Vector2 position = new Vector2(Random.Range(-18, 18), Random.Range(-7, 9));
            banditClone = Instantiate(bandits[randomBanditNumber], position, Quaternion.identity);
        }
        if (collision.CompareTag("Whip"))
        {
            whipSparkle.transform.position = collision.transform.position;
            whipSparkle.GetComponent<ParticleSystem>().enableEmission = true;
            Invoke("StopSparkles", 0.4f);
            speed = fastSpeed;
            Invoke("BackToNormalSpeed", 5f);
        }
        if (collision.CompareTag("Nail"))
        {
            nailSparkle.transform.position = collision.transform.position;
            nailSparkle.GetComponent<ParticleSystem>().enableEmission = true;
            Invoke("StopSparkles", 0.4f);
            speed = slowSpeed;
            Invoke("BackToNormalSpeed", 5f);
        }
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
    private void BackToNormalSpeed()
    {
        speed = normalSpeed;
    }
    private void ShineBandits()
    {
        shineBandit = true;
        Debug.Log("shine");
    }
    private void StopSparkles()
    {
        whipSparkle.GetComponent<ParticleSystem>().enableEmission = false;
        nailSparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
    public IEnumerator FadeText(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 0.7f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0.7f);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
