using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 maxDistance;

    public float hoverSpeed;


    private float startingPositionY;
    public float yRadius;
    private float pivotPointY;

    private bool turnAround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startingPositionY = transform.position.y;

        pivotPointY = startingPositionY + yRadius;

        maxDistance = new Vector2(0, pivotPointY);

    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y >= pivotPointY)
        {
            turnAround = true;
        }
        else if (transform.position.y <= startingPositionY)
        {
            turnAround = false;
        }
    }

    private void FixedUpdate()
    {
        moveObject(maxDistance, turnAround);
    }

    private void moveObject(Vector2 length, bool direction)
    {
        if (turnAround)
        {
            rb.MovePosition((Vector2)transform.position + (-length * hoverSpeed * Time.deltaTime));
        }
        else if (!turnAround)
        {
            rb.MovePosition((Vector2)transform.position + (length * hoverSpeed * Time.deltaTime));
        }
    }
}
