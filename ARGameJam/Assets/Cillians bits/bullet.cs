using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public Transform player, enemy;
    public Rigidbody rb;
    Vector3 moveDirection;

    public float speed = 5;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }

    
    void Update()
    {
        DestroyObjectDelayed();
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(this.gameObject, 2);
    }

  
}
