using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbmovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector3 movement;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
    
        rb.velocity = new Vector3(xMov, rb.velocity.y, zMov) * speed;
    }
}
