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
    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
