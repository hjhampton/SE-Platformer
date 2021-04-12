using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 15.0f;
    
    void Update()
    {
        
        transform.position += transform.right * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
       Destroy(this.gameObject);
        
    }

}
