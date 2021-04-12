using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    private Rigidbody2D rb;
    public int playerHealth = 5;
    public static int healthNumber;
    private float horizontalMovement;

    public Animator animator;

    public Projectile bullet;
    public Transform LaunchOffset;

    private bool isSprinting = false;

    private void Start()
    {
       // animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        healthNumber = playerHealth;
        horizontalMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontalMovement);

        if (Input.GetButtonDown("Sprint"))
        {
            isSprinting = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, LaunchOffset.position, transform.rotation);
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

        if (collide.gameObject.tag.Equals("Enemy"))
        {
            GiveDamage();
            if(playerHealth == 0)
            {
                levelresetonDeath();
            }
        }

        if(collide.gameObject.tag.Equals("Restart Trigger"))
        {
            levelresetonDeath();
        }
    }
    void OnCollisionExit2D(Collision2D collide) {
        if (collide.gameObject.name.Equals("MovingPlatformLR")) {
            this.transform.parent = null;
        }
    }

    //*Player is given damage//
    public void GiveDamage()
    {
        playerHealth -= 1;
    }

    //*Resets level upon playerHealth reaching 0//
    void levelresetonDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}