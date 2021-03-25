using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedJump : MonoBehaviour
{
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float jumpForce;
    public bool collisionActive;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collisionActive = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collisionActive = false;
    }

    void Update()
    {
        if (collisionActive == true)
        {
            //Controls player jump
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpForce;
            }

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
