using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float visionRange;
    private bool inRange = false;

    public Transform target;
    private Rigidbody2D enemyRigidbody;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 range = target.position - transform.position;
        movement = range;
        inRange = isInRange(range);
    }

    private void FixedUpdate()
    {
        moveObject(movement, inRange);
    }

    void moveObject(Vector2 direction, bool objectInRange)
    {
        if (objectInRange)
        {
            enemyRigidbody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
        
    }
    
    bool isInRange(Vector2 range)
    {
        if (range.x < visionRange && range.x > -visionRange)
        {
            return true;
        }
        return false;
    }
}
