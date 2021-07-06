using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float gravityScale = 1;
    public CharacterController controller;

    public Vector3 moveDirection;

    private float directionY;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    } 

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        if (Input.GetButtonDown("Jump"))
        {
            directionY = jumpSpeed;
        }
        //moveDirection.y -= gravityScale;
        directionY -= gravityScale * Time.deltaTime;
        moveDirection.y = directionY;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
