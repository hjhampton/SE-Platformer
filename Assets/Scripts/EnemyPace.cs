using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPace : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private Vector2 maxDistance;

    public float moveSpeed;
   
    private float startingXPosition;
    public float xRadius;
    private float pivotPointX;
    
    

    private bool turnAround = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = this.GetComponent<Rigidbody2D>();
        startingXPosition = transform.position.x;

        pivotPointX = startingXPosition + xRadius;

        maxDistance = new Vector2(pivotPointX, 0);
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x >= pivotPointX)
        {
            turnAround = true;
        }
        else if (transform.position.x <= startingXPosition)
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
            enemyRigidbody.MovePosition((Vector2)transform.position + (-length * moveSpeed * Time.deltaTime));
        }
        else if (!turnAround)
        {
            enemyRigidbody.MovePosition((Vector2)transform.position + (length * moveSpeed * Time.deltaTime));
        }
      
    }


}
