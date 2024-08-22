using UnityEngine;

public class Joystick : MonoBehaviour
{
    Hunter hunter;
    public Transform player;
    private bool touchStart = false;

    [HideInInspector] public Vector2 pointA;
    [HideInInspector] public Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

    void Start()
    {
        hunter = FindObjectOfType<Hunter>();
        pointA = circle.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //--to make joystick avaliable from everywhere
            //pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            //circle.transform.position = pointA * -1;
            outerCircle.transform.localPosition = pointA;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        }
        else
        {
            touchStart = false;
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 100f);
            moveCharacter(direction);

            circle.transform.localPosition = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * hunter.speed * Time.deltaTime);
        if(direction.x < 0f)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left;
        }
        else if(direction.x > 0f)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right;
        }
    }
}