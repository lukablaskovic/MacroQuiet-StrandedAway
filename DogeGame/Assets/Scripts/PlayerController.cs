using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravityScale = 3f;
    public CharacterController controller;

    public Vector3 moveDirection;

    private Animator animator;

    private float directionY;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetBool("Jump", false);
        animator.SetBool("isGrounded", true);
    } 

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Jump", !controller.isGrounded);
        animator.SetBool("isGrounded", controller.isGrounded);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        animator.SetFloat("Speed", moveDirection.magnitude);

            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                directionY = jumpHeight;
                animator.SetBool("Jump", !controller.isGrounded);
        }
            
        directionY -= gravityScale * Time.deltaTime;
        moveDirection.y = directionY;
        
        animator.SetBool("isGrounded", controller.isGrounded);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
