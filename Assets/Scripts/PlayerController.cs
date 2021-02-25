using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    private Rigidbody2D rb;
    private float horizontalMovement;

    //private Animator animator;


    private bool isSprinting = false;

    private void Start()
    {
       // animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Sprint"))
        {
            isSprinting = true;
        }
    }

    private void FixedUpdate()
    {
        movementSpeed = walkSpeed;
        playerMove(horizontalMovement, isSprinting);
        //animator.SetFloat("moveX", horizontalMovement);
        //animator.SetFloat("moveY", 0);
    }

    private void playerMove(float horizontal, bool sprint)
    {
        if (sprint == true)
        {
            movementSpeed = sprintSpeed;
        }

        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * movementSpeed;
    }

    // upon collision with moving platform, player becomes child of platform allowing them to move with it
    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.name.Equals ("MovingPlatformLR")) {
            this.transform.parent = collide.transform;
        }
    }
    void OnCollisionExit2D(Collision2D collide) {
        if (collide.gameObject.name.Equals ("MovingPlatformLR")) {
            this.transform.parent = null;
        }
    }
}