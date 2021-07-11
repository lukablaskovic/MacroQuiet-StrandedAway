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
        animator.SetBool("gameStart", true);
    } 

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Jump", !controller.isGrounded);
        animator.SetBool("isGrounded", controller.isGrounded);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection = controller.transform.forward * verticalInput;
        animator.SetFloat("Speed", moveDirection.magnitude);

        if (controller.isGrounded)
        {
            animator.SetBool("gameStart", false);
            animator.SetBool("isGrounded", false);
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                directionY = jumpHeight;
                
            }
        }
        directionY -= gravityScale * Time.deltaTime;
        moveDirection.y = directionY;

        controller.transform.Rotate(Vector3.up * horizontalInput * (175f * Time.deltaTime));

        animator.SetBool("isGrounded", controller.isGrounded);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        
    }
}
