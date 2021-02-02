using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float sprintSpeed;
    public float jumpForce;
 
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        
    }

    private void FixedUpdate()
    {
        var horizontalChange = Input.GetAxis("Horizontal");
        if (Input.GetButton("Sprint"))
        {
            transform.position += new Vector3(horizontalChange, 0, 0) * Time.deltaTime * sprintSpeed;
        }
        else
        {
            transform.position += new Vector3(horizontalChange, 0, 0) * Time.deltaTime * movementSpeed;
        }
        
       
        
    
        //Controls player jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
}
